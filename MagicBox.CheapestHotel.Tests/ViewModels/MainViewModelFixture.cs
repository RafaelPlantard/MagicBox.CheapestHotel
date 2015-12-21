using MagicBox.CheapestHotel.Service;
using MagicBox.CheapestHotel.ViewModels;
using MagicBox.UWP.Services;
using MagicBox.UWP.Tests.Interfaces;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace MagicBox.CheapestHotel.Tests.ViewModels
{
    /// <summary>
    /// Set of method used to quality assurance on the view model for the Main page.
    /// </summary>
    [TestClass]
    public class MainViewModelFixture : ITestable
    {
        private IFileReaderService _fileReaderService;
        private IMainViewModel _mainViewModel;
        private IReservationService _reservationService;

        [TestInitialize]
        public void Initialize()
        {
            _fileReaderService = new FileReaderService();
            _reservationService = new ReservationService(_fileReaderService);
            _mainViewModel = new MainViewModel(_reservationService);
        }

        [TestMethod]
        public void VerifyInitialization()
        {
            Assert.IsNotNull(_fileReaderService);
            Assert.IsNotNull(_reservationService);
            Assert.IsNotNull(_mainViewModel);
        }
    }
}