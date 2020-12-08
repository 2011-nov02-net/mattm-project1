using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Library.Model;


namespace XUnitAcmeTest
{
    public class CustomerTest
    {
        [Theory]
        [InlineData(6)]

        public void EarnedDiscountTestFalse(int value)
        {
            var customer = new Library.Model.Customer();
            for(int i = 0; i <= value; i++)
            {
                Library.Model.Order newOrder = new Order();
                customer.Orders.Add(newOrder);
            }
            customer.CreateEarnedDiscount();
            bool result = customer.Discount == 0.95;
            Assert.False(result, $"{value} should be too low to trigger a discount");
        }
        [Theory]
        [InlineData(16)]

        public void EarnedDiscountTestTrue(int value)
        {
            var customer = new Library.Model.Customer();
            for (int i = 0; i <= value; i++)
            {
                Library.Model.Order newOrder = new Order();
                newOrder.Id = i + 1;
                customer.Orders.Add(newOrder);
            }
            customer.CreateEarnedDiscount();
            bool result = customer.Discount == 0.95; 
            Assert.True(result, $"{value} should be enough to trigger a discount");
        }
        [Theory]
        [InlineData(1, 6)]
        public void SetFavoriteStoreTrue(int value, int times)
        {
            var customer = new Library.Model.Customer();
            for (int i = 0; i <= times; i++)
            {
                Library.Model.Order newOrder = new Order();
                newOrder.LocationId = value;
                customer.Orders.Add(newOrder);            
            }
            customer.DefaultFavoriteStore();
            bool result = customer.favoriteStore == value;
            Assert.True(result, $"{value} should be favorite store");
        }

        [Theory]
        [InlineData(1, 4)]
        public void SetFavoriteStoreFalse(int value, int times)
        {
            var customer = new Library.Model.Customer();
            for (int i = 0; i <= times; i++)
            {
                Library.Model.Order newOrder = new Order();
                newOrder.LocationId = value;
                customer.Orders.Add(newOrder);
            }
            customer.DefaultFavoriteStore();
            bool result = customer.favoriteStore == value;
            Assert.False(result, $"{value} should not be favorite store");
        }
    }
}
