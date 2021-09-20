using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._1396DesignUndergroundSystem
{
    public class UndergroundSystem
    {
        private Dictionary<int, TravelData> _dictionary = new Dictionary<int, TravelData>();

        private Dictionary<string, Dictionary<string, AvgData>> _fromToTime =
            new Dictionary<string, Dictionary<string, AvgData>>();

        public UndergroundSystem()
        {
        }

        public void CheckIn(int id, string stationName, int t)
        {
            _dictionary[id] = new TravelData() {InStation = stationName, InTime = t};
        }

        public void CheckOut(int id, string stationName, int t)
        {
            var travelData = _dictionary[id];
            travelData.OutStation = stationName;
            travelData.OutTime = t;


            if (!_fromToTime.ContainsKey(travelData.InStation))
            {
                _fromToTime[travelData.InStation] = new Dictionary<string, AvgData>();
            }

            if (!_fromToTime[travelData.InStation].ContainsKey(travelData.OutStation))
            {
                _fromToTime[travelData.InStation][travelData.OutStation] = new AvgData();
            }

            _fromToTime[travelData.InStation][travelData.OutStation].Add(travelData);
        }

        public double GetAverageTime(string startStation, string endStation)
        {
            return _fromToTime[startStation][endStation].GetAVG();
        }

        private class TravelData
        {
            public string InStation { get; set; }
            public int InTime { get; set; }
            public string OutStation { get; set; }
            public int OutTime { get; set; }
        }

        private class AvgData
        {
            private double totalTime;
            private int totalTravels;

            public void Add(TravelData travelData)
            {
                totalTime += travelData.OutTime - travelData.InTime;
                totalTravels++;
            }

            public double GetAVG()
            {
                return totalTime / totalTravels;
            }
        }
    }

    /**
     * Your UndergroundSystem object will be instantiated and called as such:
     * UndergroundSystem obj = new UndergroundSystem();
     * obj.CheckIn(id,stationName,t);
     * obj.CheckOut(id,stationName,t);
     * double param_3 = obj.GetAverageTime(startStation,endStation);
     */
}