using Xunit;
using Xunit.Abstractions;

namespace Product.xUnit
{
    public class AssertInsertProducts
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly Service.ProductRepository _product;

        public AssertInsertProducts(ITestOutputHelper helper)
        {
            _testOutputHelper = helper;
            _product = new Service.ProductRepository();
        }

        [Fact]
        [Trait("Category", "Insert Products collection")]
        public void InsertProductMongoCollection()
        {            
            _testOutputHelper.WriteLine("ready to insert items.");
            Assert.True(_product.InsertProductMongoCollection());
        }
    }
}
