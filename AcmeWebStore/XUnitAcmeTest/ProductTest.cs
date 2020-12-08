using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Library.Model;


namespace XUnitAcmeTest
{
    public class ProductTest
    {
        [Theory]
        [InlineData(0.25)]
        [InlineData(0.5)]
        [InlineData(0.9)]
        public void DiscountTest(decimal value)
        {
            var product = new Library.Model.Product();
            product.Price = 100;
            product.Discount(value);
            bool result = product.Price == 100*value;

            Assert.True(result, $"{value} should lower price");

        }

    }
}
