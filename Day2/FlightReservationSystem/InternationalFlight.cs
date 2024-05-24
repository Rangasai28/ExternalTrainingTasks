/*
 * InternationalFlight.cs
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem
{
    // Class representing an International Flight, inheriting from the Flight class
    public class InternationalFlight : Flight
    {
        // Properties specific to International Flight
        public string departureCountry { get; set; }
        public bool IsvisaApproved { get; set; }
        public DateTime ArrivalDate { get; set; }

        // initializing International Flight properties through constructor
        public InternationalFlight(string flightNumber, string departureAirport, string destinationAirport, DateTime departureDT, DateTime arrivalDate, float baggageallowance, int seatCapacity, decimal ticketPrice, string DepartureCountry, bool isvisaApproved)
        {
            // Initializing properties
            FlightNumber = flightNumber;
            DepartureAirport = departureAirport;
            DestinationAirport = destinationAirport;
            DepartureDT = departureDT;
            ArrivalDate = arrivalDate;
            TicketPrice = ticketPrice;
            SeatCapacity = seatCapacity;
            baggageAllowance = baggageallowance;
            departureCountry = DepartureCountry;
            IsvisaApproved = isvisaApproved;
        }

        // Implementation of abstract method to book ticket
        public override bool bookTicket()
        {
            // Checking if there are available seats
            if (SeatCapacity == 0)
            {
                return false;
            }
            return true;
        }

        // Implementation of abstract method to cancel booking
        public override string cancelBooking()
        {

            return $"Cancleing the ticket for the International FLight {FlightNumber}";
        }

        // Implementation of abstract method to check availability
        public override string checkAvailability()
        {

            return $"Checking availability for the International FLight {FlightNumber}";
        }

        // Implementation of abstract method to print flight details
        public override string printDetails()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("flightNumber  = {0}{1}", FlightNumber, Environment.NewLine);
            sb.AppendFormat("DepartureAirport = {0}{1}", DepartureAirport, Environment.NewLine);
            sb.AppendFormat("DestinationAirport  = {0}{1}", DestinationAirport, Environment.NewLine);
            sb.AppendFormat("DepartureCountry  = {0}{1}", departureCountry, Environment.NewLine);
            sb.AppendFormat("DepartureDT  = {0}{1}", DepartureDT, Environment.NewLine);
            sb.AppendFormat("ArrivalDate  = {0}{1}f", ArrivalDate, Environment.NewLine);
            sb.AppendFormat("SeatCapacity  = {0}{1}", SeatCapacity, Environment.NewLine);
            sb.AppendFormat("IsvisaApproved = {0}{1}", IsvisaApproved, Environment.NewLine);
            sb.AppendFormat("TicketPrice  = {0:C}{1}", TicketPrice, Environment.NewLine);
            return sb.ToString();
        }

        // Method to check visa status
        public string visaStatus()
        {
            if (IsvisaApproved)
            {
                return "Your Visa is Approved";
            }
            return "your Visa is Rejected";
        }

        // Implementation of abstract method to check baggage allowance
        public sealed override string CheckBaggageAllowance()
        {
            // Checking baggage allowance for the International Flight
            StringBuilder sb = new StringBuilder();
            sb.Append($"The Baggage Allowance For the International flight {FlightNumber} is {baggageAllowance} kg");
            return sb.ToString();
        }
    }
}
