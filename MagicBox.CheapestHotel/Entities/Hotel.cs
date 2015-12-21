using Prism.Mvvm;

namespace MagicBox.CheapestHotel.Entities
{
    /// <summary>
    /// Represents a hotel from the chain of hotel.
    /// </summary>
    public class Hotel : BindableBase, IHotel
    {
        private string _name;
        private decimal _rateForRegularCustomer;
        private decimal _rateForRewarsCustomer;
        private byte _rating;
        private decimal _weekendRateForRegularCustomer;
        private decimal _weekendRateForRewardsCustomer;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public decimal RateForRegularCustomer
        {
            get { return _rateForRegularCustomer; }
            set { SetProperty(ref _rateForRegularCustomer, value); }
        }

        public decimal RateForRewardsCustomer
        {
            get { return _rateForRewarsCustomer; }
            set { SetProperty(ref _rateForRewarsCustomer, value); }
        }

        public byte Rating
        {
            get { return _rating; }
            set { SetProperty(ref _rating, value); }
        }

        public decimal WeekendRateForRegularCustomer
        {
            get { return _weekendRateForRegularCustomer; }
            set { SetProperty(ref _weekendRateForRegularCustomer, value); }
        }

        public decimal WeekendRateForRewardsCustomer
        {
            get { return _weekendRateForRewardsCustomer; }
            set { SetProperty(ref _weekendRateForRewardsCustomer, value); }
        }
    }
}