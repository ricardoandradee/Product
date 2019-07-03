using Xunit;
using Xunit.Abstractions;

namespace Product.xUnit
{
    public class AssertFantasticAttribute
    {
        private readonly Service.ProductRepository _product;
        private readonly ITestOutputHelper _testOutputHelper;

        public AssertFantasticAttribute(ITestOutputHelper helper)
        {
            _testOutputHelper = helper;
            _product = new Service.ProductRepository();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        [Trait("Category", "Is fantactic attribute filter is working")]
        public void FantasticFilterIsWorking(bool isFantastic)
        {

            _testOutputHelper.WriteLine("calling method GetProductsIsFantastic.");
            var json = _product.GetProductsIsFantastic(isFantastic);

            _testOutputHelper.WriteLine("Converting Json to Product object.");
            var products = json.JsonToProduct();

            _testOutputHelper.WriteLine("Assert.NotNull");
            Assert.NotNull(products);

            _testOutputHelper.WriteLine("Assert value inside product.attribute.fantastic.value");

            if (isFantastic)
                Assert.All(products, prod => Assert.True(prod.attribute.fantastic.value));
            else
                Assert.All(products, prod => Assert.False(prod.attribute.fantastic.value));
        }
    }
}
