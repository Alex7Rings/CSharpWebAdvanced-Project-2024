using System.ComponentModel.DataAnnotations;

namespace MoonGameRev.Web.ViewModels.Review
{
    public class ReviewDetailsViewModel
    {
        public string Id { get; set; }
        public double Rating { get; set; }
        public string Pros { get; set; } 
        public string Cons { get; set; } 
        public string Comment { get; set; } 
        public DateTime ReviewDate { get; set; }
        public string UserName { get; set; } 
    }
}
