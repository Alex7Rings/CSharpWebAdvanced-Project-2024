using System.ComponentModel.DataAnnotations;

namespace MoonGameRev.Web.ViewModels.Review
{
    public class ReviewFormModel
    {

        public string Rating { get; set; } = null!;

        
        public string Pros { get; set; } = null!;
        public string Cons { get; set; } = null!;
        public string Commentary { get; set; } = null!;

        //// Original comment property can be retained if needed
        //public string OriginalComment { get; set; } = null!;

        public DateTime ReviewDate { get; set; } 
    }
}
