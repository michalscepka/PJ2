using System;

namespace cv8_2
{
	class ContactListener
	{
		public void Changed(object sender, EventArgs args)
		{
			Console.WriteLine("Vaha se zmenila.");
		}
	}
}
