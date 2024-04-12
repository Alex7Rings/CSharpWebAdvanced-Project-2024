using System.ComponentModel.DataAnnotations.Schema;

namespace MoonGameRev.Data.Models
{
    public class GameGenre
    {

        public Guid GameID { get; set; }
        [ForeignKey(nameof(GameID))]
        public Game Game { get; set; } = null!;

        public int GenreID { get; set; }

        [ForeignKey(nameof(GenreID))]
        public Genre Genre { get; set; } = null!;
    }
}
