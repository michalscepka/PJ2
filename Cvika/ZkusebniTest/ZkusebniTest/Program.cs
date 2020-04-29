using System;
using System.Collections.Generic;
using System.IO;

namespace ZkusebniTest
{
	class Program
	{
		static void Main(string[] args)
		{
			Unit unit1 = new Unit("Ropa", 10);
			PowerPlant pw1 = new PowerPlant("Skvela elektrarna", unit1);
			House h1 = new House("Motakuv dum", 900);
			House h2 = new House("Michaluv", 50000);
			House h3 = new House("Najety dum", 15000);
			House h4 = new House("Bravkuv dum", 10000);

			List<House> houses = new List<House> { h1, h2, h3, h4 };

			PriradDumKElekrarne(h1, pw1);
			PriradDumKElekrarne(h2, pw1);
			PriradDumKElekrarne(h3, pw1);
			PriradDumKElekrarne(h4, pw1);

			foreach (House item in houses)
				Console.WriteLine(item.Name + ", " + item.Balance);

			for(uint i = 0; i < 100; i++)
			{
				try
				{
					pw1.Produce(1);
				}
				catch (ApplicationException e)
				{
					Console.WriteLine(e);
				}
			}

			houses.Sort();

			foreach (House item in houses)
				Console.WriteLine(item.Name + ", " + item.Balance);
			
			string path = @"..\..\..\data.txt";

			WriteToFile(path, houses[houses.Count - 1]);
		}

		static void PriradDumKElekrarne(House house, PowerPlant powerPlant)
		{
			if(house.Balance > powerPlant.Unit.Price)
			{
				house.PowerPlant = powerPlant;
				powerPlant.OnEnergyProduced += house.ConsumeEnergy;
			}
			else
			{
				Console.WriteLine("Dum nema dostatek penez");
			}
		}

		private static void WriteToFile(string path, House house)
		{
			using StreamWriter file = new StreamWriter(path, false);
			file.WriteLine(house.Name);
		}
	}
}
