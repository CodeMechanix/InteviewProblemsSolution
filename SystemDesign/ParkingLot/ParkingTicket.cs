using System;

namespace SystemDesign.ParkingLot
{
    public class ParkingTicket
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime PayedAt { get; set; }
        public double PayedAmount  { get; set; }
        public ParkingTicketStatus ParkingTicketStatus { get; set; }
        //public Payment Payment { get; set; }

        public override string ToString()
        {
            return $"{this.GetType().Name}, Id{Id}, CreatedAt:{CreatedAt}, ParkingTicketStatus:{ParkingTicketStatus}";
        }
    }

    public enum ParkingTicketStatus
    {
        Active, Paid, Lost
    }
}