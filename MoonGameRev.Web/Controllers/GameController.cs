using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoonGameRev.Services.Data.Interfaces;
using MoonGameRev.Services.Data.Models.Game;
using MoonGameRev.Web.ViewModels.Game;
using static MoonGameRev.Common.NotificationMessagesConstants;

namespace MoonGameRev.Web.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly IGenreService genreService;
        private readonly IGameService gameService;

        public GameController(IGenreService genreService, IGameService gameService)
        {
            this.genreService = genreService;
            this.gameService = gameService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllGamesQueryModel queryModel)
        {
            AllGamesFilteredAndPagedServiceModel serviceModel =
                await this.gameService.AllAsync(queryModel);

            queryModel.Games = serviceModel.Games;
            queryModel.TotalGames = serviceModel.TotalGamesCount;
            queryModel.Genres = await this.genreService.AllGenresNamesAsync();

            return View(queryModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> UpcomingGames([FromQuery] UpcomingGamesQueryModel queryModel)
        {
            AllUpcomingGamesPagedServiceModel serviceModel = 
                await this.gameService.AllUpcomingGamesAsync(queryModel);

            queryModel.UpcomingGames = serviceModel.UpcomingGames;
            queryModel.TotalGames = serviceModel.TotalUpcomingGames;

            return View(queryModel);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            try
            {
				GameFormModel formModel = new GameFormModel()
				{
					Genres = await this.genreService.AllGenresAsync()
				};

				return View(formModel);
			}
            catch (Exception)
            {
				this.TempData[ErrorMessage] = "Unexpected error occurred.";

				return this.RedirectToAction("All", "Games");
			}
        }

        [HttpPost]
        public async Task<IActionResult> Add(GameFormModel model)
        {
            if (model.GenreIds == null || !model.GenreIds.Any())
            {
                ModelState.AddModelError(nameof(model.GenreIds), "Please select at least one genre!");
            }
            else
            {
                // Check if all selected genre IDs exist
                foreach (int genreId in model.GenreIds)
                {
                    bool genreExist = await this.genreService.ExistsByIdAsync(genreId);
                    if (!genreExist)
                    {
                        ModelState.AddModelError(nameof(model.GenreIds), $"Selected genre with ID {genreId} does not exist!");
                    }
                }
            }
            if (ModelState.IsValid)
            {
                try
                {
                    string gameId = await this.gameService.CreateAsync(model);

                    this.TempData[SuccessMessage] = "Game was added successfully";
                    return RedirectToAction("Details", "Game", new {id = gameId});
                }
                catch (Exception)
                {
                    ModelState.AddModelError(string.Empty, "An unexpected error occurred while trying to add a new game!");
                }
            }

            // If the model state is not valid, retrieve the genres again
            model.Genres = await this.genreService.AllGenresAsync();
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(string id)
        {
            bool gameExists = await this.gameService
                .ExistsByIdAsync(id);

            if (!gameExists)
            {
                this.TempData[ErrorMessage] = "Game with the provided ID does not exists!";
                return this.RedirectToAction("All", "Game");
            }

            try
            {
				GameDetailsViewModel viewModel = await this.gameService
				.GetDetailsByIdAsync(id);

				return View(viewModel);
			}
            catch (Exception)
            {

				this.TempData[ErrorMessage] = "Unexpected error occurred.";

				return this.RedirectToAction("All", "Games");
			}
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool gameExists = await this.gameService
                .ExistsByIdAsync(id);

            if (!gameExists)
            {
                this.TempData[ErrorMessage] = "Game with the provided ID does not exists!";
                return this.RedirectToAction("All", "Game");
            }

            try
            {
				GameFormModel formModel = await this.gameService
				.GetGameForEditByIdAsync(id);

				formModel.Genres = await this.genreService.AllGenresAsync();

				return this.View(formModel);
			}
            catch (Exception)
            {
				this.TempData[ErrorMessage] = "Unexpected error occurred. Please try again later or contact administrator.";
				return this.RedirectToAction("All", "Game");
			}
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, GameFormModel model)
        {
            if(!this.ModelState.IsValid)
            {
                model.Genres = await this.genreService.AllGenresAsync();
                return this.View(model);
            }

            bool gameExists = await this.gameService
                .ExistsByIdAsync(id);

            if (!gameExists)
            {
                this.TempData[ErrorMessage] = "Game with the provided ID does not exists!";
                return this.RedirectToAction("All", "Game");
            }

            try
            {
                await this.gameService.EditGameByIdAndFormModel(id, model);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to update the game!");
                model.Genres = await this.genreService.AllGenresAsync();

                return this.View(model);
            }

            this.TempData[SuccessMessage] = "Game was edited successfully";
            return this.RedirectToAction("Details", "Game", new { id });

        }
    }
}
