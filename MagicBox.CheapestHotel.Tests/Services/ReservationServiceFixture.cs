using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicBox.CheapestHotel.Service;
using MagicBox.UWP.Services;
using MagicBox.UWP.Tests.Interfaces;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace MagicBox.CheapestHotel.Tests.Services
{
    /// <summary>
    /// Set of methods used to ensure the quality on the <see cref="IReservationService"/>.
    /// </summary>
    [TestClass]
    public sealed class ReservationServiceFixture : ITestable
    {
        private IFileReaderService _fileReaderService;
        private IReservationService _reservationService;

        [TestInitialize]
        public void Initialize()
        {
            _fileReaderService = new FileReaderService();
            _reservationService = new ReservationService(_fileReaderService);
        }

        [TestMethod]
        public void VerifyInitialization()
        {
            Assert.IsNotNull(_fileReaderService);
            Assert.IsNotNull(_reservationService);
        }
    }
}
