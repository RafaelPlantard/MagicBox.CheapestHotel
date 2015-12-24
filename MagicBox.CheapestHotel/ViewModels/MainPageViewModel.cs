using MagicBox.CheapestHotel.Models;
using MagicBox.CheapestHotel.Service;
using MagicBox.UWP.Services;
using Prism.Commands;
using Prism.Windows.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MagicBox.CheapestHotel.ViewModels
{
    /// <summary>
    /// The data context for the Main page.
    /// </summary>
    public class MainPageViewModel : ViewModelBase, IMainPageViewModel
    {
        private readonly IAlertMessageService _alertMessageService;
        private readonly IReservationService _reservationService;

        private ObservableCollection<IHotelChoice> _resultHotelChoices;
        public ICommand ReadFileCommand { get; set; }

        public ObservableCollection<IHotelChoice> ResultHotelChoices
        {
            get { return _resultHotelChoices; }
            set { SetProperty(ref _resultHotelChoices, value); }
        }

        /// <summary>
        /// Initializes the dependencies injections and commands.
        /// </summary>
        /// <param name="alertMessageService">The current service for show alert messages for the user.</param>
        /// <param name="reservationService">The current reservation service.</param>
        public MainPageViewModel(IAlertMessageService alertMessageService, IReservationService reservationService)
        {
            _alertMessageService = alertMessageService;
            _reservationService = reservationService;

            ReadFileCommand = DelegateCommand.FromAsyncHandler(ReadFileAsync);
        }

        private async Task ReadFileAsync()
        {
            try
            {
                var result = await _reservationService.ResolveCheapestHotelsFromFileAsync();

                if (result != null)
                {
                    ResultHotelChoices = new ObservableCollection<IHotelChoice>(result);
                }
            }
            catch (Exception)
            {
                await _alertMessageService.ShowAsync("Hey, your file is malformed, check it.", "Errors on file");
            }
        }
    }
}