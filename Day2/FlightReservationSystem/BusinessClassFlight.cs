/*
 * BusinessClassFlight.cs
 * 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem
{
    // Class representing a Business Class Flight,inheriting from the Flight class
    public class BusinessClassFlight : Flight
    {
        // Properties specific to Business Class Flight
        public string Amenities { get; set; }
        public DateTime ArrivalDate { get; set; }

        // initializing Business Class Flight properties through constructor
        public BusinessClassFlight(string flightNumber, string departureAirport, string destinationAirport, DateTime departureDT, DateTime arrivalDate, int seatCapacity, float baggageallowance, decimal ticketPrice, string DepartureCountry, string amenities)
        {
            // Initialize properties
            FlightNumber = flightNumber;
            DepartureAirport = departureAirport;
            DestinationAirport = destinationAirport;
            DepartureDT = departureDT;
            ArrivalDate = arrivalDate;
            TicketPrice = ticketPrice;
            SeatCapacity = seatCapacity;
            Amenities = amenities;
            baggageAllowance = baggageallowance; // Corrected property name to match usage in code
        }

        // Implementation of abstract method to book ticket
        public override bool bookTicket()
        {
            // Check if there are available seats
            if (SeatCapacity == 0)
            {
                return false;
            }
            return true;
        }

        // Implementation of abstract method to cancel booking
        public override string cancelBooking()
        {

            return $"Cancleing the ticket for the Business Class Flight {FlightNumber}";
        }

        // Implementation of abstract method to check availability
        public override string checkAvailability()
        {

            return $"Checking availability for the Business Class Flight {FlightNumber}";
        }

        // Implementation of abstract method to print flight details
        public override string printDetails()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("flightNumber  = {0}{1}", FlightNumber, Environment.NewLine);
            sb.AppendFormat("departureAirport = {0}{1}", DepartureAirport, Environment.NewLine);
            sb.AppendFormat("destinationAirport  = {0}{1}", DestinationAirport, Environment.NewLine);
            sb.AppendFormat("departureDT  = {0}{1}", DepartureDT, Environment.NewLine);
            sb.AppendFormat("ArrivalDate  = {0}{1}f", ArrivalDate, Environment.NewLine);
            sb.AppendFormat("SeatCapacity  = {0}{1}", SeatCapacity, Environment.NewLine);
            sb.AppendFormat("Amenities = {0}{1}", Amenities, Environment.NewLine);
            sb.AppendFormat("TicketPrice  = {0:C}{1}", TicketPrice, Environment.NewLine);
            return sb.ToString();
        }

        // Method to upgrade class
        public string UpgradeClass()
        {
            return "Upgrading to the First Class";
        }

        // Implementation of abstract method to check baggage allowance
        public sealed override string CheckBaggageAllowance()
        {
            // Checking baggage allowance for the Business Class Flight
            StringBuilder sb = new StringBuilder();
            sb.Append($"The Baggage Allowance For the Business flight {FlightNumber} is {baggageAllowance} kg");
            return sb.ToString();
        }
    }
}
