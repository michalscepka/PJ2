using System;
using System.Collections.Generic;
using System.Text;

namespace PJ2_Test2_SCE0007
{
	class Reservation
	{
		public int Capacity { get; set; }
		public DateTime From { get; set; }
		public string Name { get; set; }
		public DateTime To { get; set; }

		public override string ToString()
		{
			return string.Format("{0}, {1}, {2}, {3}", Name, Capacity, From, To);
		}
	}
}
