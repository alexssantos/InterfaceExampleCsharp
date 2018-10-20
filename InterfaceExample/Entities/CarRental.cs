using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceExample.Entities
{
    class CarRental
    {
        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }
        public Vehicle Vehicle { get; set; }
        public Invoice Invoice { get; set; }

        public CarRental(DateTime dateStart, DateTime dateFinish, Vehicle vehicle)
        {
            DateStart = dateStart;
            DateFinish = dateFinish;
            Vehicle = vehicle;
            Invoice = null;
        }
    }
}
