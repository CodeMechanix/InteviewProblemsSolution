using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemDesign.ParkingLot
{
    public class ParkingLot
    {
        public ParkingLot()
        {
            ParkingFloor = new ParkingFloor(4);
            EntrancePanel = new EntrancePanel();
        }

        public int Id { get; set; }
        public string Location { get; set; }
        public ParkingRate ParkingRate { get; set; }
        public ExitPanel ExitPanel { get; set; }

        public EntrancePanel EntrancePanel { get; set; }

        // public HashSet<ParkingTicket> Tickets { get; set; }
        public ParkingFloor ParkingFloor { get; set; }




        public bool AddParkingFloor()
        {
            throw new NotImplementedException();
        }

        public bool AddEnterancePanel()
        {
            throw new NotImplementedException();
        }

        public void GetNewParkingTicket()
        {
            if (IsFull())
            {
                EntrancePanel.ShowMessage("Parking is Full");
            }
            else
            {
                var parkingTicket = new ParkingTicket()
                {
                    CreatedAt = DateTime.Now,
                    Id = new Random().Next(int.MaxValue),
                    ParkingTicketStatus = ParkingTicketStatus.Active,
                };

                //Tickets.Add(parkingTicket);

                EntrancePanel.PrintTicket(parkingTicket);
                EntrancePanel.OpenGate();
                ParkingFloor.AddVehicle();
            }
        }

        public bool IsFull()
        {
            return ParkingFloor.IsFull();
        }
    }

    public class ParkingFloor
    {
        public string Name { get; set; }
        public int Capacity { get; }
        public int Used { get; set; }

        public ParkingDisplayBoard ParkingDisplayBoard { get; set; }

        public ParkingFloor(int capacity)
        {
            Capacity = capacity;
        }

        public bool IsFull()
        {
            return Capacity > Used;
        }

        public void AddVehicle()
        {
            Used++;
            ParkingDisplayBoard.FreeSpots = Capacity - Used;
        }
    }

    public class ParkingDisplayBoard
    {
        public int FreeSpots { get; set; }
    }
}