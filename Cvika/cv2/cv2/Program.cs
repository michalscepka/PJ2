using System;
using MyAdt;

namespace cv2
{
	class Program
	{
		public static void Main(string[] args)
		{
			IZasobnik<int?> stack = new MujZasobnik<int?>(5);	//Nullable<int> = int? - int kde muze byt i null
			stack.Push(1);
			stack.Push(2);
			stack.Push(null);
			stack.Push(4);
			Console.WriteLine(stack.Top());
			Console.WriteLine(stack.Pop());
			Console.WriteLine(stack.Pop());
			Console.WriteLine(stack.Pop());
			Console.WriteLine(stack.Pop());

			Console.WriteLine("Fronta");

			IFronta<string> fronta = new MojeFronta<string>(5);
			fronta.Add("1");
			Console.WriteLine(fronta.Get());
			fronta.Add("2");
			fronta.Add("3");
			fronta.Add("4");
			fronta.Add("5");
			Console.WriteLine(fronta.Get());
		}
	}
}
