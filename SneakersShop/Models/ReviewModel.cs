using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Models
{
    public class ReviewModel
    {
        public int ProductId { get; set; }
        public int Stars { get; set; }
        public int ParentReviewId { get; set; }
        public string Text { get; set; }
    }
}
