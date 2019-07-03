﻿using System;
using Xunit;
using Xunit.Abstractions;

namespace Product.xUnit
{
    public class AssertJsonValid
    {

        private readonly Service.ProductRepository _product;
        private readonly ITestOutputHelper _testOutputHelper;

        public AssertJsonValid(ITestOutputHelper helper)
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
        [Trait("Category", "Is json format")]
        public void PriceFilterIsValidJson(bool asc, bool? isFantastic)
        {
            _testOutputHelper.WriteLine("calling method GetProductsFilterPriceMinMax.");
            var json = _product.GetProductsFilterPriceMinMax(asc, isFantastic);

            _testOutputHelper.WriteLine("Assert.True");
            Assert.True(json.ValidateJson());
        }

        [Theory]
        [InlineData(true, null)]
        [InlineData(false, null)]
        [InlineData(true, true)]
        [InlineData(false, false)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [Trait("Category", "Is json format")]
        public void RatingFilterIsValidJson(bool asc, bool? isFantastic)
        {
            _testOutputHelper.WriteLine("calling method GetProductsFilterRatingMinMax.");
            var json = _product.GetProductsFilterRatingMinMax(asc, isFantastic);

            _testOutputHelper.WriteLine("Assert.True");
            Assert.True(json.ValidateJson());
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        [Trait("Category", "Is json format")]
        public void FantasticFilterIsValidJson(bool isFantastic)
        {
            _testOutputHelper.WriteLine("calling method GetProductsIsFantastic.");
            var json = _product.GetProductsIsFantastic(isFantastic);

            _testOutputHelper.WriteLine("Assert.True");
            Assert.True(json.ValidateJson());
        }
    }
}
