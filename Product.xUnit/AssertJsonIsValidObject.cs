using Xunit;
using Xunit.Abstractions;

namespace Product.xUnit
{
    public class AssertJsonIsValidObject
    {
        private readonly Service.ProductRepository _product;
        private readonly ITestOutputHelper _testOutputHelper;

        public AssertJsonIsValidObject(ITestOutputHelper helper)
        {
            _testOutputHelper = helper;
            _product = new Service.ProductRepository();
        }

        [Theory]
        [InlineData(true, null)]
        [InlineData(false, null)]
        [InlineData(true, true)]
        [InlineData(false, false)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [Trait("Category", "Is Json valid Product List")]
        public void RatingFilterIsProductObject(bool asc, bool? isFantastic)
        {
            _testOutputHelper.WriteLine("calling method GetProductsFilterRatingMinMax.");
            var json = _product.GetProductsFilterRatingMinMax(asc, isFantastic);

            _testOutputHelper.WriteLine("Assert.NotNull");
            Assert.NotNull(json.JsonToProduct());
        }

        [Theory]
        [InlineData(true, null)]
        [InlineData(false, null)]
        [InlineData(true, true)]
        [InlineData(false, false)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [Trait("Category", "Is Json valid Product List")]
        public void PriceFilterIsProductObject(bool asc, bool? isFantastic)
        {
            _testOutputHelper.WriteLine("calling method GetProductsFilterPriceMinMax.");
            var json = _product.GetProductsFilterPriceMinMax(asc, isFantastic);

            _testOutputHelper.WriteLine("Assert.NotNull");
            Assert.NotNull(json.JsonToProduct());
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        [Trait("Category", "Is Json valid Product List")]
        public void FantasticFilterIsProductObject(bool isFantastic)
        {
            _testOutputHelper.WriteLine("calling method GetProductsIsFantastic.");
            var json = _product.GetProductsIsFantastic(isFantastic);

            _testOutputHelper.WriteLine("Assert.NotNull");
            Assert.NotNull(json.JsonToProduct());
        }
    }
}
