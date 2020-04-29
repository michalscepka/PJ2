using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ZkusebniTest
{
	class House : IConsumer, IComparable<House>
	{
		public double Balance { get; set; }
		public List<uint> History { get; set; }
		public string Name { get; set; }
		public PowerPlant PowerPlant { get; set; }

		public House(string name, double balance)
		{
			Name = name;
			Balance = balance;
			History = new List<uint>();
		}

		public int CompareTo([AllowNull] House other)
		{
			if(this.Balance.CompareTo(other.Balance) == 0)
			{
				return this.Name.Length.CompareTo(other.Name.Length);
			}
			return this.Balance.CompareTo(other.Balance);
		}

		public void ConsumeEnergy(uint amount)
		{
			Balance -= PowerPlant.Unit.Price * amount;
			if (Balance > 0)
			{
				History.Add(amount);
				Console.WriteLine("Consumed: " + amount);
			}
			else
			{
				PowerPlant.OnEnergyProduced -= this.ConsumeEnergy;
				throw new ApplicationException("Nedostatek penez");
			}
		}
	}
}
