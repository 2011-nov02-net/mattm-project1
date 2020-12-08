using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Model
{
    public class Product
    {
        private int _id;
        private string _name;
        private decimal _price;
        public int Id
        {
            get => _id;
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Id must be greater than 0");
                }
                _id = value;
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                if (value.Length < 1)
                {
                    throw new ArgumentException("Name must be at least 1 character in length");
                }
                _name = value;
            }
        }
        public decimal Price
        {
            get => _price;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price must be greater than 0");
                }

                _price = value;
            }
        }

        public void Discount(decimal discount)
        {
            this.Price *= discount;

        }
        
    }
}
