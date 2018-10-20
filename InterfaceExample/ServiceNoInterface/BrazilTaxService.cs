using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceExample.ServiceNoInterface
{
    class BrazilTaxService : ITexService
    {
        public double Tax(double amount)
        {
            if(amount <= 100)
            {
                return amount * 0.2;
            }
            else
            {
                return amount * 0.15;
            }
        }
    }
}
