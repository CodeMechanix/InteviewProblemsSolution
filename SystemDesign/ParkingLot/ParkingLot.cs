using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemDesign.ParkingLot
{
    public class ParkingLot
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public ParkingRate ParkingRate { get; set; }
        public ExitPanel ExitPanel { get; set; }

        public bool AddParkingFloor()
        {
            throw new NotImplementedException();
        }

        public bool AddEnterancePanel()
        {
            throw new NotImplementedException();
        }

        public ParkingTicket GetNewParkingTicket()
        {
            throw new NotImplementedException();
        }

        public bool IsFull()
        {
            throw new NotImplementedException();
        }
    }
}