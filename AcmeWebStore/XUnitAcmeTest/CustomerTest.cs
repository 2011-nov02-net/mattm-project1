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
        [InlineData("")]
        public void CustomerNameFalse(string value)
        {
            var customer = new Library.Model.Customer();
            customer.firstName = value;
            bool result = customer.firstName == value;

            Assert.False(result, $"{value} should not be addable as a customer first name");

        }
    }
}
