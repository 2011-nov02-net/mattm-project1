using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Model
{
    public class Location
    {
        private int _id;
        private string _city;
        private string? _state;
        private string _country;

        public string city
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
        public string state
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
        public string country
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
