using System.Collections.Generic;

namespace ZkusebniTest
{
	interface IConsumer
	{
		public double Balance { get; set; }
		public List<uint> History { get; set; }
		public string Name { get; set; }
		public PowerPlant PowerPlant { get; set; }
	}
}
