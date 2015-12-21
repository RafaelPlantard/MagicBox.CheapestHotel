using MagicBox.CheapestHotel.Entities;
using MagicBox.CheapestHotel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagicBox.CheapestHotel.Service
{
    /// <summary>
    /// Defines the methods and properties that all reservation service must to have.
    /// </summary>
    public interface IReservationService
    {
        /// <summary>
        /// A list of the settes to available hotels to the customers.
        /// </summary>
        IEnumerable<IHotel> AvailableHotels { get; }

        /// <summary>
        /// Calculate how much a customer will spend in a particular hotel.
        /// </summary>
        /// <param name="customer">The customer input values.</param>
        /// <param name="hotel">The hotel to calculate the reservation value.</param>
        /// <returns>The money value that a customer will spend in a particular hotel.</returns>
        decimal CalculateTotalToReservationHotel(ICustomerInput customer, IHotel hotel);

        /// <summary>
        /// Tries to convert a text line to a CustomerInput object.
        /// </summary>
        /// <param name="text">The text line to convert.</param>
        /// <returns>A new customer input object.</returns>
        ICustomerInput ConvertToCustomerInputFromTextLine(string text);

        /// <summary>
        /// Accordingly of the customer input this routine will generate a new hotel choice object, that represents the cheapest hotel.
        /// </summary>
        /// <param name="input">The customer type and dates to reserve.</param>
        /// <returns>The cheapest hotel for this customer.</returns>
        IHotelChoice ResolveCheapestHotel(ICustomerInput input);

        /// <summary>
        /// Shows a file picker to the user select a file that contains its reservation inputs.
        /// </summary>
        /// <returns>A best hotel choice for each line from the file.</returns>
        Task<IEnumerable<IHotelChoice>> ResolveCheapestHotelsFromFileAsync();
    }
}