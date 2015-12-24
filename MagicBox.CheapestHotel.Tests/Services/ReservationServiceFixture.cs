using System;
using System.Collections.Generic;
using MagicBox.CheapestHotel.Entities;
using MagicBox.CheapestHotel.Models;
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

        /// <summary>
        /// Verifies whether the customer input generate from a text line is correct.
        /// </summary>
        [TestMethod]
        public void VerifyConvertToCustomerInputFromTextLine()
        {
            var mockedValues = new[]
            {
                "Regular: 16Mar2009(mon), 17Mar2009(tues), 18Mar2009(wed)",
                "Regular: 20Mar2009(fri), 21Mar2009(sat), 22Mar2009(sun)",
                "Rewards: 26Mar2009(thur), 27Mar2009(fri), 28Mar2009(sat)"
            };

            var expectedValues = new[]
            {
                new CustomerInput
                {
                    Customer = CustomerType.Regular,
                    DatesToReserve = new List<DateTime>
                    {
                        new DateTime(2009, 03, 16),
                        new DateTime(2009, 03, 17),
                        new DateTime(2009, 03, 18),
                    }
                },

                new CustomerInput
                {
                    Customer = CustomerType.Regular,
                    DatesToReserve = new List<DateTime>
                    {
                        new DateTime(2009, 03, 20),
                        new DateTime(2009, 03, 21),
                        new DateTime(2009, 03, 22),
                    }
                },

                new CustomerInput
                {
                    Customer = CustomerType.Rewards,
                    DatesToReserve = new List<DateTime>
                    {
                        new DateTime(2009, 03, 26),
                        new DateTime(2009, 03, 27),
                        new DateTime(2009, 03, 28),
                    }
                }
            };

            for (var i = 0; i < mockedValues.Length; i++)
            {
                var actual = _reservationService.ConvertToCustomerInputFromTextLine(mockedValues[i]);

                Assert.IsNotNull(actual);

                Assert.AreEqual(expectedValues[i].Customer, (i < 2) ? CustomerType.Regular : CustomerType.Rewards);

                Assert.AreEqual(expectedValues[i], actual);
            }
        }

        [TestMethod]
        public void VerifyInitialization()
        {
            Assert.IsNotNull(_fileReaderService);
            Assert.IsNotNull(_reservationService);
            Assert.IsNotNull(_reservationService.AvailableHotels);
        }
    }
}