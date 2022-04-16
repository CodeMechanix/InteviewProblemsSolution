using System.Diagnostics;

namespace SystemDesign.ParkingLot
{
    public class EntrancePanel
    {
        public int Id { get; set; }
       

        public bool PrintTicket(ParkingTicket parkingTicket)
        {
            Debug.WriteLine($"Printed new: {parkingTicket}");
            return true;
        }

        public bool ShowMessage(string s)
        {
            Debug.WriteLine(s);
            return true;
        }

        public void OpenGate()
        {
            Debug.WriteLine("Open gate");
        }
    }
}