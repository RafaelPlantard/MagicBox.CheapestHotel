using MagicBox.CheapestHotel.Entities;
using Prism.Mvvm;
using System;
using System.Collections.Generic;

namespace MagicBox.CheapestHotel.Models
{
    /// <summary>
    /// Represents the data that a single customer must enter to reserve a hotel.
    /// </summary>
    public class CustomerInput : BindableBase, ICustomerInput
    {
        private CustomerType _customer;
        private IEnumerable<DateTime> _dateToReserve;

        public CustomerType Customer
        {
            get { return _customer; }
            set { SetProperty(ref _customer, value); }
        }

        public IEnumerable<DateTime> DatesToReserve
        {
            get { return _dateToReserve; }
            set { SetProperty(ref _dateToReserve, value); }
        }
    }
}