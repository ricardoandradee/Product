using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Interface
{
    public interface IProductRepository
    {
        bool InsertProductMongoCollection();
        string GetProductsFilterPriceMinMax(bool priceAsc, bool? isFantastic); //string GetProductsFilterPriceMinMax(bool asc, bool? isFantastic);
        string GetProductsFilterRatingMinMax(bool ratingAsc, bool? isFantastic);
        string GetProductsIsFantastic(bool isFantastic);
        string GetAllProducts();
        //string GetProductsRating(bool priceAsc);
    }
}
