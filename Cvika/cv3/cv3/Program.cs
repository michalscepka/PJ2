using System;

namespace cv3
{
	class Program
	{
		static void Main(string[] args)
		{
			DynamicArray array = new DynamicArray();

			Console.WriteLine(array.Length);
			array.Length = 7;
			Console.WriteLine(array.Length);

			array[1] = 6;
			array[8] = 9;
			Console.WriteLine(array.Length);
			Console.WriteLine(array);

			int tmp = 0;
			array.Sum(ref tmp);
			Console.WriteLine(tmp);
		}
	}
}
