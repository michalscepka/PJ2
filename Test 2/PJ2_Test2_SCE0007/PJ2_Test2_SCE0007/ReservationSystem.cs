using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PJ2_Test2_SCE0007
{
	delegate void ReservationProcessed(bool created);
	delegate bool ValidationRule(List<Reservation> existingReservations, Reservation newReservation);

	class ReservationSystem
	{
		string path = @"..\..\..\data.txt";
		private List<Reservation> reservations = new List<Reservation>();
		public List<ValidationRule> Rules = new List<ValidationRule>();

		public bool CreateReservation(Reservation reservation)
		{
			for(int i = 0; i < Rules.Count; i++)
			{
				if (!Rules[i].Invoke(reservations, reservation))
				{
					OnReservation?.Invoke(false);
					return false;
				}
			}
			reservations.Add(reservation);
			OnReservation?.Invoke(true);
			return true;
		}

		public void Load()
		{
			string[] lines = File.ReadAllLines(path);

			foreach (string line in lines)
			{
				string[] items = line.Split(", ");
				reservations.Add(new Reservation { Name = items[0], Capacity = int.Parse(items[1]), From = DateTime.Parse(items[2]), To = DateTime.Parse(items[3]) });
			}
		}

		public void Print()
		{
			foreach (Reservation item in reservations)
				Console.WriteLine(item);
		}

		public void Save()
		{
			using StreamWriter file = new StreamWriter(path, false);
			foreach (Reservation item in reservations)
				file.WriteLine(item);
		}

		public event ReservationProcessed OnReservation;
	}
}
