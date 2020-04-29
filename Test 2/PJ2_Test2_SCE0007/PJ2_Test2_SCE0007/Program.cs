using System;
using System.Collections.Generic;
using System.Linq;

namespace PJ2_Test2_SCE0007
{
	class Program
	{
		static void Main(string[] args)
		{
            ReservationSystem rs = new ReservationSystem();

            rs.Rules.Add((List<Reservation> reservations, Reservation newReservation) =>
            {
                return !reservations.Any(x => newReservation.From < x.To && newReservation.To > x.From);
            });

            rs.Rules.Add((List<Reservation> reservations, Reservation newReservation) => { return newReservation.Capacity <= 10; });

            rs.OnReservation += (bool created) => Console.WriteLine("Rezervace se " + (created ? "ZDAŘILA" : "NEZDAŘILA") + ".");

            rs.CreateReservation(new Reservation()
            {
                From = new DateTime(2018, 5, 7, 10, 0, 0),
                To = new DateTime(2018, 5, 7, 11, 0, 0),
                Capacity = 10,
                Name = "Pepa"
            });
            rs.CreateReservation(new Reservation()
            {
                From = new DateTime(2018, 5, 7, 9, 0, 0),
                To = new DateTime(2018, 5, 7, 11, 0, 0),
                Capacity = 5,
                Name = "Tomáš"
            });
            rs.CreateReservation(new Reservation()
            {
                From = new DateTime(2018, 5, 7, 11, 0, 0),
                To = new DateTime(2018, 5, 7, 12, 0, 0),
                Capacity = 5,
                Name = "Lenka"
            });
            rs.CreateReservation(new Reservation()
            {
                From = new DateTime(2018, 5, 7, 13, 0, 0),
                To = new DateTime(2018, 5, 7, 14, 0, 0),
                Capacity = 20,
                Name = "Michala"
            });

            rs.Save();

            rs = new ReservationSystem();
            rs.Load();

            rs.Print();
        }
	}
}
