using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
	class Processor
	{
		public int? Id { set; get; }
		public string Name { set; get; }
		public double Price { set; get; }
		public int Cores { set; get; }
		public double Frequency { set; get; }
		public string Architecture { set; get; }
		public bool Overclock { set; get; }

		public Processor() { }
		public Processor(int id, string name, double price, int cores, double freq, string arch, bool overclock)
		{
			Id = id;
			Name = name;
			Price = price;
			Cores = cores;
			Frequency = freq;
			Architecture = arch;
			Overclock = overclock;
		}

		public override string ToString()
		{
			return string.Format("id: {0}\tname: {1}\tprice: {2}\tcores: {3}\tfreq: {4}\t arch: {5}\t overclock: {6}",
				Id, Name, Price, Cores, Frequency, Architecture, Overclock);
		}
	}
}
