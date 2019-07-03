using Microsoft.AspNetCore.Mvc;
using Product.Interface;
using Newtonsoft.Json;

namespace Product.Controllers
{
    [Route("Products")]
    public class ValuesController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ValuesController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _productRepository.InsertProductMongoCollection();
        }

        [HttpGet()]
        public ActionResult GetAllProducts()
        {
            var jsonString = _productRepository.GetAllProducts();

            var obj = JsonConvert.DeserializeObject(jsonString);
            var formatted = JsonConvert.SerializeObject(obj, Formatting.Indented);

            return Content(formatted);
        }

        [HttpGet("GetProductsFilterPriceMinMax/{asc}/{*isFantastic}")]
        public ActionResult GetProductsFilterPriceMin(bool asc, bool? isFantastic)
        {
            var jsonString = _productRepository.GetProductsFilterPriceMinMax(asc, isFantastic);

            var obj = JsonConvert.DeserializeObject(jsonString);
            var formatted = JsonConvert.SerializeObject(obj, Formatting.Indented);

            return Content(formatted);
        }

        [HttpGet("GetProductsFilterRatingMinMax/{asc}/{*isFantastic}")]
        public ActionResult GetProductsFilterRatingMinMax(bool asc, bool? isFantastic)
        {
            var jsonString = _productRepository.GetProductsFilterRatingMinMax(asc, isFantastic);

            var obj = JsonConvert.DeserializeObject(jsonString);
            var formatted = JsonConvert.SerializeObject(obj, Formatting.Indented);

            return Content(formatted);
        }

        [HttpGet("GetProductsIsFantastic/{isFantastic}")]
        public ActionResult GetProductsIsFantastic(bool isFantastic)
        {
            var jsonString = _productRepository.GetProductsIsFantastic(isFantastic);

            var obj = JsonConvert.DeserializeObject(jsonString);
            var formatted = JsonConvert.SerializeObject(obj, Formatting.Indented);

            return Content(formatted);
        }
    }
}
