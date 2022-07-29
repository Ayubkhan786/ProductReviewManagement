using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProductReviewManagement
{
    public class ProductManager
    {
        public readonly DataTable dataTable = new DataTable();
        public void HighRatingRecords(List<ProductReview> productReview)
        {
            var recordedData = (from productReviews in productReview
                                orderby productReviews.Rating descending
                                select productReviews).Take(3);
            foreach (var data in recordedData)
            {
                Console.WriteLine("ProductId: " + data.ProductId + "  UserId: " + data.UserId
                                + "  Rating: " + data.Rating + "  Review: " + data.Review + "  IsLike: " + data.IsLike);
            }
        }
    }
}
