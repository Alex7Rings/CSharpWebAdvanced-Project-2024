namespace MoonGameRev.Web.ViewModels.Review
{
    public class ReviewAllViewModel
    {
        public string Id { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string Date { get; set; } = null!;

        public double Rating { get; set; }

        public string Pros { get; set; } = null!;

        public string Cons { get; set; } = null!;

        public string Comment { get; set; } = null!;
    }
}
