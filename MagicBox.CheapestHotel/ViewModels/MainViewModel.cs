using MagicBox.CheapestHotel.Models;
using MagicBox.CheapestHotel.Service;
using Prism.Commands;
using Prism.Windows.Mvvm;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MagicBox.CheapestHotel.ViewModels
{
    /// <summary>
    /// The data context for the Main page.
    /// </summary>
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        private readonly IReservationService _reservationService;
        private ObservableCollection<IHotelChoice> _resultHotelChoices;

        public ICommand ReadFileCommand { get; set; }

        public ObservableCollection<IHotelChoice> ResultHotelChoices
        {
            get { return _resultHotelChoices; }
            set { SetProperty(ref _resultHotelChoices, value); }
        }

        public MainViewModel(IReservationService reservationService)
        {
            _reservationService = reservationService;

            ReadFileCommand = DelegateCommand.FromAsyncHandler(ReadFileAsync);
        }

        private async Task ReadFileAsync()
        {
            var result = await _reservationService.ResolveCheapestHotelsFromFileAsync();

            if (result != null)
            {
                ResultHotelChoices = new ObservableCollection<IHotelChoice>(result);
            }
        }
    }
}