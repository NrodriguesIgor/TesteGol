using System;
using TesteGol.Model.Base;

namespace TesteGol.Model.Entities
{
    public class Flight : Entity
    {
        public Flight(string name, DateTime departureTime, string origin, string destination)
        {
            Name = name;
            DepartureTime = departureTime;
            Origin = origin;
            Destination = destination;
        }

        public string Name { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }


        public void ChangeInfos(string name, DateTime departureTime,string origin, string destination)
        {
            Name = name;
            DepartureTime = departureTime;
            Origin = origin;
            Destination = destination;
        }

    }
}
