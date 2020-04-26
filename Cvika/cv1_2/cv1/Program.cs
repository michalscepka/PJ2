using System;
using Model;

namespace cv1
{
	class Program
	{
		static void Main(string[] args)
		{
			Class1 c1 = new Class1();
			string input = Console.ReadLine();
			Console.WriteLine(c1.Greeting(input));
		}
	}
}
