using Xunit;
using Xunit.Abstractions;

namespace Product.xUnit
{
    public class AssertJsonNeitherNullOrEmpty
    {
        private readonly Service.ProductRepository _product;
        private readonly ITestOutputHelper _testOutputHelper;
        
        public AssertJsonNeitherNullOrEmpty(ITestOutputHelper helper)
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
        [Trait("Category", "Is json is null or empty")]
        public void PriceFilterIsNeitherNullOrEmpty(bool asc, bool? isFantastic)
        {
            _testOutputHelper.WriteLine("calling method GetProductsFilterPriceMinMax.");
            var json = _product.GetProductsFilterPriceMinMax(asc, isFantastic);

            _testOutputHelper.WriteLine("ready to test.");
            Assert.False(string.IsNullOrWhiteSpace(json));
        }

        [Theory]
        [InlineData(true, null)]
        [InlineData(false, null)]
        [InlineData(true, true)]
        [InlineData(false, false)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [Trait("Category", "Is json is null or empty")]
        public void RatingFilterIsNeitherNullOrEmpty(bool asc, bool? isFantastic)
        {
            _testOutputHelper.WriteLine("calling method GetProductsFilterRatingMinMax.");
            var json = _product.GetProductsFilterRatingMinMax(asc, isFantastic);

            _testOutputHelper.WriteLine("ready to test.");
            Assert.False(string.IsNullOrWhiteSpace(json));
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        [Trait("Category", "Is json is null or empty")]
        public void FantasticFilterIsNeitherNullOrEmpty(bool isFantastic)
        {
            _testOutputHelper.WriteLine("calling method GetProductsIsFantastic.");
            var json = _product.GetProductsIsFantastic(isFantastic);

            _testOutputHelper.WriteLine("ready to test.");
            Assert.False(string.IsNullOrWhiteSpace(json));
        }
    }
}
