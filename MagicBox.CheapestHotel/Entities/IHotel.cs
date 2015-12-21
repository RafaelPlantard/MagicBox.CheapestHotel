namespace MagicBox.CheapestHotel.Entities
{
    /// <summary>
    /// Defines the properties that all hotel type must to have.
    /// </summary>
    public interface IHotel
    {
        /// <summary>
        /// Hotel name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The valid rate for a regular customer.
        /// </summary>
        decimal RateForRegularCustomer { get; set; }

        /// <summary>
        /// The promotional rate for a customer where he/she is in a loyalty program.
        /// </summary>
        decimal RateForRewardsCustomer { get; set; }

        /// <summary>
        /// The hotel classification.
        /// </summary>
        byte Rating { get; set; }

        /// <summary>
        /// The valid rate for a regular customer when the date inputted is in weekend.
        /// </summary>
        decimal WeekendRateForRegularCustomer { get; set; }

        /// <summary>
        /// The promotional rate for a customer where he/she is in a loyalty program valid only for dates in weekend period.
        /// </summary>
        decimal WeekendRateForRewardsCustomer { get; set; }
    }
}