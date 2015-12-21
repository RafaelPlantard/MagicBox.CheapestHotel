namespace MagicBox.CheapestHotel.Entities
{
    /// <summary>
    /// Represents the possible type of customers that can go to those hotels.
    /// </summary>
    public enum CustomerType
    {
        /// <summary>
        /// They are customers have no special rates.
        /// </summary>
        Regular,

        /// <summary>
        /// They are customers that have special rates as a part of loyalty program.
        /// </summary>
        Rewards
    }
}