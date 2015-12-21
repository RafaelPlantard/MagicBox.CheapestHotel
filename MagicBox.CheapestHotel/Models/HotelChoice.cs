using MagicBox.CheapestHotel.Entities;
using Prism.Mvvm;

namespace MagicBox.CheapestHotel.Models
{
    /// <summary>
    /// The data processed from a specific hotel after the customer has inputted its data.
    /// </summary>
    public class HotelChoice : BindableBase, IHotelChoice
    {
        private IHotel _bestHotel;
        private decimal _totalValue;

        public IHotel BestHotel
        {
            get { return _bestHotel; }
            set { SetProperty(ref _bestHotel, value); }
        }

        public decimal TotalValue
        {
            get { return _totalValue; }
            set { SetProperty(ref _totalValue, value); }
        }
    }
}