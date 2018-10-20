using InterfaceExample.Entities;
using InterfaceExample.ServiceNoInterface;
using System;
using System.Globalization;

namespace InterfaceExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dados do Aluguel");
            Console.Write("Modelo do Carro: ");
            string model = Console.ReadLine();
            Console.Write("Entrada (dd/MM/yyyy dd:mm): ");
            DateTime dateStart = DateTime.ParseExact(Console.ReadLine(),
                                            "dd/MM/yyyy hh:mm", CultureInfo.InstalledUICulture);
            Console.Write("Saída (dd/MM/yyyy dd:mm): ");
            DateTime dateFinish = DateTime.ParseExact(Console.ReadLine(),
                                            "dd/MM/yyyy hh:mm", CultureInfo.InstalledUICulture);
            
            Console.Write("Digite o valor por hora (R$): ");
            double hour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Digite o valor por dia (R$): ");
            double day = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            //create obj_Rental
            CarRental carRental = new CarRental(dateStart,
                                               dateFinish,
                                               new Vehicle(model));

            //Calculate RENTAL - by DAY or HOUR
            RentalService rentalService = new RentalService(hour, day, new BrazilTaxService());
            rentalService.ProcessInvoice(carRental);

            Console.WriteLine("INVOICE: ");
            Console.WriteLine(carRental.Invoice);

            Console.ReadKey();
        }
    }
}
