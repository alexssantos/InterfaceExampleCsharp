using InterfaceExample.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceExample.ServiceNoInterface
{
    class RentalService
    {
        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }
        private ITexService _taxService;

        public RentalService(double pricePerHour, double pricePerDay, ITexService taxService)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            _taxService = taxService;
        }

        public void ProcessInvoice(CarRental carRental)
        {
            TimeSpan duration = carRental.DateFinish.Subtract(carRental.DateStart);

            double basicPayment = 0.0;

            //Rental Logic
            if (duration.TotalHours <= 12.0)
            {
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours); //Ceiling -> round Up
            }
            else
            {
                basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
            }

            //calculate the tax based on basic payment
            double tax = _taxService.Tax(basicPayment);

            //Passing Payment + Tax to some.
            carRental.Invoice = new Invoice(basicPayment, tax);
        }
    }
}
