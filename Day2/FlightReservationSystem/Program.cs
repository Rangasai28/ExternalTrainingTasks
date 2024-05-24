namespace FlightReservationSystem
{
    public class Program
    {

        //Method That Console the Details about the Domestic Flight Class
        public static void DomesticFlight(DomesticFlight flight)
        {
            Console.WriteLine(flight.printDetails());
            Console.WriteLine(flight.cancelBooking());
            Console.WriteLine(flight.CheckBaggageAllowance());
            Console.WriteLine(flight.checkAvailability());
            Console.WriteLine(flight.DelayStatus(2));

            Console.WriteLine();
        }


        //Method That Console the Details about the International Flight Class
        public static void InternationalFlight(InternationalFlight flight)
        {
            Console.WriteLine(flight.printDetails());
            Console.WriteLine(flight.cancelBooking());
            Console.WriteLine(flight.CheckBaggageAllowance());
            Console.WriteLine(flight.checkAvailability());
            Console.WriteLine(flight.DelayStatus(2));
            Console.WriteLine(flight.visaStatus());
            Console.WriteLine();
        }

        //Method That Console the Details about the BusinessClass Flight Class
        public static void BusinessClassFlight(BusinessClassFlight flight)
        {
            Console.WriteLine(flight.printDetails());
            Console.WriteLine(flight.cancelBooking());
            Console.WriteLine(flight.CheckBaggageAllowance());
            Console.WriteLine(flight.checkAvailability());
            Console.WriteLine(flight.DelayStatus(2));
            Console.WriteLine(flight.UpgradeClass());
            Console.WriteLine();
        }

        //public static void SpecificFlight(Flight flight)
        //{
        //    if(flight is DomesticFlight dst)
        //    {

        //    }
        //}
        static void Main(string[] args)
        {
            //Declaration and Initialization of Date and Time variables
            DateTime departureTime = new DateTime(2024, 4, 14, 8, 0, 0);
            DateTime arrivalDT = new DateTime(2024, 4, 14, 9, 0, 0);
            TimeOnly arrivalTime = new TimeOnly(10, 0, 0);


            //Creating Instances For the Derived classes
            Flight Domflight = new DomesticFlight("X34SD", "Hyderabad", "Vizag", departureTime, arrivalTime, 40, 3000m, 20f, 500);
            Flight InterFlight = new InternationalFlight("S34T3", "Hyderabad", "NewYork", departureTime, new DateTime(2024, 4, 15, 6, 0, 0), 20.0f, 50, 50000m, "India", false);
            Flight Businessflight = new BusinessClassFlight("R3SO7", "Vizag", "Hyderabad", departureTime, arrivalDT, 60, 20.0f, 5000m, "India", "Special Meals");



            ITransport businessflight = new BusinessClassFlight("R3SO7", "Vizag", "Hyderabad", departureTime, arrivalDT, 60, 20.0f, 5000m, "India", "Special Meals");

            ITransport internationalflight = new InternationalFlight("S34T3", "Hyderabad", "NewYork", departureTime, new DateTime(2024, 4, 15, 6, 0, 0), 20.0f, 50, 50000m, "India", false);

            ITransport domesticflight = new DomesticFlight("X34SD", "Hyderabad", "Vizag", departureTime, arrivalTime, 40, 3000m, 20f, 500);



            Transp(domesticflight);
            Transp(internationalflight);
            Transp(businessflight);


        }

        public static void Transp(ITransport trap)
        {
            Console.WriteLine(trap.DelayStatus(3));
            Console.WriteLine(trap.checkAvailability());
            Console.WriteLine(trap.bookTicket());
            Console.WriteLine(trap.cancelBooking());

        }
    }
}