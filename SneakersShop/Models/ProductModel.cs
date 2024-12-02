namespace SneakersShop.Models
{
    public class GetProductsModel : BaseModel
    {
        public string? Name { get; set; }
        public string? Brand { get; set; }
        public string? Code { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Price { get; set; }
        public string? Image { get; set; }
        public List<string>? Colors { get; set; }
        public List<Sizes>? Sizes { get; set; }
        public List<Review>? Reviews { get; set; }

        public string AvgStar
        {
            get
            {
                if (Reviews == null || Reviews.Count == 0)
                {
                    return "0";
                }

                return  Reviews.Average(review => review.Stars).ToString();
            }
        }
        public string ReviewCount
        {
            get
            {
                if (Reviews == null || Reviews.Count == 0)
                {
                    return "0";
                }

                return Reviews.Count().ToString();
            }
        }
    }

    

    public class Sizes
    {
        public double Size { get; set; }
        public List<StoreSizes>? StoreSizes { get; set; }
    }

    public class StoreSizes
    {
        public string? Store { get; set; }
        public int Quantity { get; set; }
    }

    public class Review : BaseModel
    {
        public string? User { get; set; }
        public string? Text { get; set; }
        public int Stars { get; set; }
        public DateTime CommentedAt { get; set; }
        public List<ChildReview>? ChildReviews { get; set; }
    }

    public class ChildReview : BaseModel
    {
        public string? User { get; set; }
        public string? Text { get; set; }
        public DateTime CommentedAt { get; set; }
        public List<ChildReview>? ChildReviews { get; set; }
    }
}
