using System;

namespace ZkusebniTest
{
	delegate void EnergyProducedDelegate(uint amount);

	class PowerPlant
	{
		public string Name { get; }
		public Unit Unit { get; }

		public PowerPlant(string name, Unit unit)
		{
			Name = name;
			Unit = unit;
		}

		public void Produce(uint amount)
		{
			OnEnergyProduced?.Invoke(amount);
			Console.WriteLine("Pocet vyrobe energie: " + amount);
		}

		public event EnergyProducedDelegate OnEnergyProduced;
	}
}
