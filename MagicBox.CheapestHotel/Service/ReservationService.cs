using MagicBox.CheapestHotel.Entities;
using MagicBox.CheapestHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicBox.UWP.Services;

namespace MagicBox.CheapestHotel.Service
{
    /// <summary>
    /// The current core of machine processing to reservation the cheapest hotel for a customer.
    /// </summary>
    public sealed class ReservationService : IReservationService
    {
        private readonly IFileReaderService _fileReaderService;

        public IEnumerable<IHotel> AvailableHotels { get; private set; }

        /// <summary>
        /// Creates the service and set up it for ready to go.
        /// </summary>
        public ReservationService(IFileReaderService fileReaderService)
        {
            _fileReaderService = fileReaderService;

            LoadAvailableHotels();
        }

        public decimal CalculateTotalToReservationHotel(ICustomerInput customer, IHotel hotel)
        {
            var rate = (customer.Customer == CustomerType.Regular)
                ? hotel.RateForRegularCustomer
                : hotel.RateForRewardsCustomer;

            var rateOnWeekend = (customer.Customer == CustomerType.Regular)
                ? hotel.WeekendRateForRegularCustomer
                : hotel.WeekendRateForRewardsCustomer;

            return customer.DatesToReserve.Sum(date => (IsWeekend(date)) ? rateOnWeekend : rate);
        }

        public ICustomerInput ConvertToCustomerInputFromTextLine(string text)
        {
            var positionOfColon = text.IndexOf(':');

            var customerTypeString = text.Substring(0, positionOfColon);

            var dates = text.Substring(positionOfColon).Split(',');
            var dateTimes = dates.Select(Convert.ToDateTime);

            CustomerType customerType;

            Enum.TryParse(customerTypeString, true, out customerType);

            return new CustomerInput
            {
                Customer = customerType,
                DatesToReserve = dateTimes
            };
        }

        public IHotelChoice ResolveCheapestHotel(ICustomerInput input)
        {
            var hotelsToPay = AvailableHotels.Select(availableHotel => new HotelChoice
            {
                BestHotel = availableHotel,
                TotalValue = CalculateTotalToReservationHotel(input, availableHotel)
            }).ToList().OrderBy(h => h.TotalValue);

            var minValueToPay = hotelsToPay.Min(h => h.TotalValue);

            var hotelsToEval = hotelsToPay.Where(h => h.TotalValue == minValueToPay).ToList();


            if (hotelsToEval.Count <= 1)
            {
                return hotelsToEval[0];
            }

            var maxRating = hotelsToEval.Max(h => h.BestHotel.Rating);

            return hotelsToEval.Find(h => h.BestHotel.Rating == maxRating);
        }

        public async Task<IEnumerable<IHotelChoice>> ResolveCheapestHotelsFromFileAsync()
        {
            var linesFromFile = await _fileReaderService.ReadTextLinesFromFilePickerAsync();

            var usersInput = linesFromFile.Select(ConvertToCustomerInputFromTextLine).ToList();

            return usersInput.Select(ResolveCheapestHotel);
        }

        private bool IsWeekend(DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday;
        }

        private void LoadAvailableHotels()
        {
            AvailableHotels = new IHotel[]
            {
                new Hotel { Name = "Lakewood", Rating = 3, RateForRegularCustomer = 110, RateForRewardsCustomer = 80, WeekendRateForRegularCustomer = 90, WeekendRateForRewardsCustomer = 80 },

                new Hotel { Name = "Bridgewood", Rating = 4, RateForRegularCustomer = 160, RateForRewardsCustomer = 110, WeekendRateForRegularCustomer = 60, WeekendRateForRewardsCustomer = 50 },

                new Hotel { Name = "Ridgewood", Rating = 5, RateForRegularCustomer = 220, RateForRewardsCustomer = 100, WeekendRateForRegularCustomer = 150, WeekendRateForRewardsCustomer = 40 },
            };
        }
    }
}