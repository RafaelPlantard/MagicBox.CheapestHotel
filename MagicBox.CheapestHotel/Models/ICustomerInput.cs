using MagicBox.CheapestHotel.Entities;
using System;
using System.Collections.Generic;

namespace MagicBox.CheapestHotel.Models
{
    /// <summary>
    /// The input that the user must have enter.
    /// </summary>
    public interface ICustomerInput
    {
        /// <summary>
        /// The customer type.
        /// </summary>
        CustomerType Customer { get; set; }

        /// <summary>
        /// A list that contains all dates that the user wants to reserve.
        /// </summary>
        IEnumerable<DateTime> DatesToReserve { get; set; }
    }
}