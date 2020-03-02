using System;
using MyAdt;

namespace cv2
{
	class Program
	{
		public static void Main(string[] args)
		{
			IZasobnik stack = new MujZasobnik(5);
			stack.Push(65);
			stack.Push(54);
			stack.Push(98);
			Console.WriteLine(stack.Top());

			Console.WriteLine(stack.Pop());

			Console.WriteLine(stack.Top());

			Console.WriteLine(stack.Pop());
			Console.WriteLine(stack.Pop());

			Console.WriteLine("Fronta");

			IFronta fronta = new MojeFronta(5);
			fronta.Add(1);
			Console.WriteLine(fronta.Get());
			fronta.Add(2);
			fronta.Add(3);
			fronta.Add(4);
			fronta.Add(5);
			Console.WriteLine(fronta.Get());
		}
	}
}
