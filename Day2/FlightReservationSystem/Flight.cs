/*
 * Flight.cs
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem
{

    public interface ITransport
    {


        DateTime DepartureDT { get; set; }

        TimeOnly ArrivalT { get; set; }

        int SeatCapacity { get; set; }

        decimal TicketPrice { get; set; }



        public bool bookTicket();
        public string cancelBooking();

        public string checkAvailability();

        string printDetails();

        string DelayStatus(int hours);



    }
    public abstract class Flight : ITransport
    {


        //Properties that are common to all Classes
        public string? FlightNumber { get; set; }

        public string? DepartureAirport { get; set; }
        public string? DestinationAirport { get; set; }

        public DateTime DepartureDT { get; set; }

        public TimeOnly ArrivalT { get; set; }

        public int SeatCapacity { get; set; }

        public decimal TicketPrice { get; set; }

        public float baggageAllowance { get; set; }


        //Declaration of abstract method to book ticket
        public abstract bool bookTicket();

        //Declaration of abstract method to cancle booking
        public abstract string cancelBooking();


        //Declaration of abstract method to checkavailability
        public abstract string checkAvailability();


        // Virtual method to Print Flight Details
        public virtual string printDetails()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("flightNumber  = {0}{1}", FlightNumber, Environment.NewLine);
            sb.AppendFormat("departureAirport = {0}{1}", DepartureAirport, Environment.NewLine);
            sb.AppendFormat(" destinationAirport  = {0}{1}", DestinationAirport, Environment.NewLine);
            sb.AppendFormat("departureDT  = {0}{1}", DepartureDT, Environment.NewLine);
            sb.AppendFormat("seatCapacity  = {0}{1}f", ArrivalT, Environment.NewLine);
            sb.AppendFormat("SeatCapacity  = {0}{1}", SeatCapacity, Environment.NewLine);
            sb.AppendFormat("Ticket Price = {0}{1}", TicketPrice, Environment.NewLine);


            return sb.ToString();
        }


        //Abstract method that Check's BaggageAllowance
        public abstract string CheckBaggageAllowance();



        //Method That Tells about the Flight Delay Status
        public string DelayStatus(int hours)
        {
            return $"Flight {FlightNumber} has been delayed by {hours} hours.";
        }


    }
}