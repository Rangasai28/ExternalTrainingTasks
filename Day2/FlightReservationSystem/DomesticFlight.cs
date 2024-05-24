/*
 * DoesticFlight.cs
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem
{
    // Class representing an Domestic Flight, inheriting from the Flight class
    public class DomesticFlight : Flight
    {



        // Properties specific to International Flight
        public decimal childDiscount { get; set; }


        // initializing International Flight properties through constructor
        public DomesticFlight(string flightNumber, string departureAirport, string destinationAirport, DateTime departureDT, TimeOnly arrivalT, int seatCapacity, decimal ticketPrice, float baggageallowance, decimal ChildDiscount)
        {
            // Initializing properties
            FlightNumber = flightNumber;
            DepartureAirport = departureAirport;
            DestinationAirport = destinationAirport;
            DepartureDT = departureDT;
            ArrivalT = arrivalT;
            TicketPrice = ticketPrice;
            SeatCapacity = seatCapacity;
            baggageAllowance = baggageallowance;
            childDiscount = ChildDiscount;
        }

        // Implementation of abstract method to book ticket
        public override bool bookTicket()
        {
            if (SeatCapacity == 0)
            {
                return false;
            }
            return true;
        }


        // Implementation of abstract method to cancel booking
        public override string cancelBooking()
        {


            return $"Cancleing the ticket for the Domestic FLight {FlightNumber} ";
        }


        // Implementation of abstract method to check availability
        public override string checkAvailability()
        {
            return $"Checking the availability for the Domestic FLight {FlightNumber} ";

        }


        // Implementation of abstract method to print flight details
        public override string printDetails()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("flightNumber  = {0}{1}", FlightNumber, Environment.NewLine);
            sb.AppendFormat("departureAirport = {0}{1}", DepartureAirport, Environment.NewLine);
            sb.AppendFormat(" destinationAirport  = {0}{1}", DestinationAirport, Environment.NewLine);
            sb.AppendFormat("departureDT  = {0}{1}", DepartureDT, Environment.NewLine);
            sb.AppendFormat("seatCapacity  = {0}{1}f", ArrivalT, Environment.NewLine);
            sb.AppendFormat("SeatCapacity  = {0}{1}", SeatCapacity, Environment.NewLine);
            sb.AppendFormat("Ticket Price = {0:C}{1}", TicketPrice, Environment.NewLine);
            return sb.ToString();
        }


        // Implementation of abstract method to check baggage allowance
        public sealed override string CheckBaggageAllowance()
        {
            // Checking baggage allowance for the International Flight
            StringBuilder sb = new StringBuilder();
            sb.Append($"The Baggage Allowance For the Domestic flight {FlightNumber} is {baggageAllowance} kg");
            return sb.ToString();
        }


        //Method to Update Baggage Allowance
        public string UpdateBaggageAllowance()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" Updating the BaggageAllowance for the Domestic Flight ");
            return sb.ToString();
        }
    }
}