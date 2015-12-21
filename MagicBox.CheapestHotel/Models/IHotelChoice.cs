using MagicBox.CheapestHotel.Entities;

namespace MagicBox.CheapestHotel.Models
{
    /// <summary>
    /// Defines the properties that all hotel response must to have.
    /// </summary>
    public interface IHotelChoice
    {
        /// <summary>
        /// The cheapest hotel.
        /// </summary>
        IHotel BestHotel { get; set; }

        /// <summary>
        /// The total value to that reservation input.
        /// </summary>
        decimal TotalValue { get; set; }
    }
}