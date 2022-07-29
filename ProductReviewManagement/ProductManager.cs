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
        public void RetrieveRecords(List<ProductReview> productReview)
        {
            var recordData = from productReviews in productReview
                             where (productReviews.ProductId == 1 && productReviews.Rating > 3)
                             || (productReviews.ProductId == 4 && productReviews.Rating > 3)
                             || (productReviews.ProductId == 9 && productReviews.Rating > 3)
                             select productReviews;
            foreach (var data in recordData)
            {
                Console.WriteLine("ProductId: " + data.ProductId + "  UserId: " + data.UserId
                                + "  Rating: " + data.Rating + "  Review: " + data.Review + "  IsLike: " + data.IsLike);
            }
        }
        public void CountforEachProductID(List<ProductReview> productReview)
        {
            var recordedData = productReview.GroupBy(x => x.ProductId).Select(x => new { ProductId = x.Key, Count = x.Count() });
            foreach (var data in recordedData)
            {
                Console.WriteLine(data.ProductId + "      " + data.Count);
            }
        }
        public void RetrieveAndReview(List<ProductReview> productReview)
        {
            var records = from productReviews in productReview where (productReviews.ProductId > 0) select productReviews;
            foreach (var record in records)
            {
                Console.WriteLine("Product Id: " + record.ProductId + "  Reeview: " + record.Review);
            }
        }
    }

}
