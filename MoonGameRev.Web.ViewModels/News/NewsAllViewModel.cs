using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonGameRev.Web.ViewModels.News
{
    public class NewsAllViewModel
    {
        public string Id { get; set; } = null!;

        public string JournalistId { get; set; } = null!;

        public string Title { get; set; } = null!;

        [Display(Name ="Image Link")]
        public string PictureUrl { get; set; } = null!;

        public string Date { get; set; } = null!;
    }
}
