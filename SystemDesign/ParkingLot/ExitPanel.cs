using System;

namespace SystemDesign.ParkingLot
{
    public class ExitPanel
    {
        public int Id { get; set; }

        public bool ScanTicket(ParkingTicket parkingTicket)
        {
            throw new NotImplementedException();
        }

        public bool ProcessPayment(ParkingTicket parkingTicket)
        {
            throw new NotImplementedException();
        }
    }
}