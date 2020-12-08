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
        private List<Library.Model.Order> _orders;
        private double _discount;

        public Customer()
        {
            Orders = new List<Order>();
        }

        public double Discount { get; set; }
        public List<Library.Model.Order> Orders
        {
            get => _orders;
            set
            {
                _orders = value;
            }
        }

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

        public void CreateEarnedDiscount()
        {
            if(Orders.Count > 10)
            {
                this.Discount = 0.95;
            } 
        }

        public void DefaultFavoriteStore()
        {
            int count = 0;
            int trackId = 0;
            foreach(Order order in Orders)
            {
                if (order.LocationId == trackId)
                {
                    count++;
                    if (count == 5)
                    {
                        this.favoriteStore = order.LocationId;
                    }

                }
                else
                {
                    count = 0;
                }
                trackId = order.LocationId;
            }
        }


    }
}
