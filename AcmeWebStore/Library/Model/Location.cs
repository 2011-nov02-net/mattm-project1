using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Model
{
    public class Location
    {
        private int _id;
        private string _address;
        private string _city;
        private string _state;
        private string _country;

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
        public string Address
        {
            get => _address;
            set
            {
                if (value.Length < 1)
                {
                    throw new ArgumentException("Address must be at least 1 character in length");
                }
                _address = value;
            }
        }
        public string City
        {
            get => _city;
            set
            {
                if (value.Length < 1)
                {
                    throw new ArgumentException("City must be at least 1 character in length");
                }
                _city = value;
            }
        }
        public string State
        {
            get => _state;
            set
            {
                if (value.Length != 2)
                {
                    throw new ArgumentException("State must be 2 characters in length");
                }
                _state = value;
            }
        }
        public string Country
        {
            get => _country;
            set
            {
                if (value.Length < 1)
                {
                    throw new ArgumentException("City must be at least 1 character in length");
                }
                _country = value;
            }
        }

        public Dictionary<Product, int> inventory { get; set; } = new Dictionary<Product, int>();

        public List<Order> locationOrders = new List<Order>();
    }
}
