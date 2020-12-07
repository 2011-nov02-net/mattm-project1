using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Model
{
    public class Customer
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private int? _favoriteStore = 0;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
            }
        }
        public string firstName
        {
            get => _firstName;
            set
            {
                if (value.Length < 1)
                {
                    throw new ArgumentException("First name must be at least one character long");
                }
                _firstName = value;
            }
        }

        public string lastName
        {
            get => _lastName;
            set
            {
                if (value.Length < 1)
                {
                    throw new ArgumentException("Last name must be at least one character long");
                }
                _lastName = value;
            }
        }

        public int? favoriteStore
        {
            get => _favoriteStore;
            set
            {
                _favoriteStore = value;
            }
        }

        public List<Order> customerOrders { get; set; } = new List<Order>();




    }
}
