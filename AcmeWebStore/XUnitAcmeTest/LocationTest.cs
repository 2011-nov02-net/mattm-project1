using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Library.Model;


namespace XUnitAcmeTest
{
    public class LocationTest
    {
        [Theory]
        [InlineData(1,22)]
        public void StockTest(int prodId, int value)
        {
            var location = new Library.Model.Location();
            location.Inventory.Add(1, 20);
            bool result = location.CheckStock(prodId, value);

            Assert.False(result, $"{value} should be more than available stock");

        }

        [Theory]
        [InlineData(1, 50)]
        public void AddStockTest(int prodId, int quant)
        {
            var location = new Library.Model.Location();
            location.Inventory.Add(1, 0);
            location.AddStock(prodId, quant);
            bool result = location.Inventory[prodId] == 50;
            Assert.True(result, "Inventory should be set to 50");
        }
        [Theory]
        [InlineData(1, 50)]
        public void RemoveStockTestTrue(int prodId, int quant)
        {
            var location = new Library.Model.Location();
            location.Inventory.Add(1, 100);
            location.RemoveStock(prodId, quant);
            bool result = location.Inventory[prodId] == 50;
            Assert.True(result, "Inventory should be set to 50");
        }
       
        [Theory]
        [InlineData(50)]
        public void CheckPurchaseLimitTestFalse(int quant)
        {
            var location = new Library.Model.Location();
            location.PurchaseLimit = 25;

            bool result = location.CheckPurchaseSize(quant);
            Assert.False(result, "Purchase should be too large");
        }
        [Theory]
        [InlineData(5)]
        public void CheckPurchaseLimitTestTrue(int quant)
        {
            var location = new Library.Model.Location();
            location.PurchaseLimit = 25;

            bool result = location.CheckPurchaseSize(quant);
            Assert.True(result, "Purchase should be small enough");
        }


    }


}
