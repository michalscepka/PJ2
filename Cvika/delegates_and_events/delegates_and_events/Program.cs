using System;

namespace delegates_and_events
{
	class Program
	{
		delegate void Notifier(string name);
		
		static void Main(string[] args)
		{
			DBEdu dbe = new DBEdu();

			dbe.OnAdd += Print;

			Project pr1 = new Project
			{
				Name = "Vlaky",
				Points = 0
			};
			Project pr2 = new Project
			{
				Name = "Polibte Motakovi",
				Points = -10
			};

			Notifier notifier = Notification;

			notifier("Kokos");

			dbe.AddProject(pr1);
			//System.Threading.Thread.Sleep(5000);
			dbe.AddProject(pr2);
		}

		private static void Print(object sender, EventArgs args)
		{
			Console.WriteLine(DateTime.Now);
		}

		private static void Notification(string name)
		{
			Console.WriteLine("Vitejte na dbEdu: " + name);
		}
	}
}
