using System;
using System.Collections.Generic;

namespace cv4
{
	class Program
	{
		static void Main(string[] args)
		{
			Calculator cal = new Calculator();
			cal.OnSetXY += OnSet;
			cal.SetXY(1, 2);

			cal.OnCompute += Print;
			//cal.OnCompute += (int x) => Console.WriteLine("Výsledek: " + x);
			//cal.OnCompute += (x) => Console.WriteLine("Výsledek: " + x);
			//cal.OnCompute += x => Console.WriteLine("Výsledek: " + x);
			//cal.OnCompute += (x) => { Console.WriteLine("Výsledek: " + x); };
			//cal.OnCompute += delegate (int x) { Console.WriteLine("Výsledek: " + x); };

			int result = cal.Execute(Sum);
			result = cal.Execute((a, b) => a * b);
			//result = cal.Execute((a, b) => { return a * b; });
			result = cal.Execute((a, b) => a / b);




			int[] numbers = new int[] { 5, 20, -60, -6, 1, 3, -4 };

			Console.WriteLine("\nKladna cisla:");
			int[] positiveNumbers = Filter<int>(numbers, x => x > 0);
			foreach (int item in positiveNumbers)
				Console.WriteLine(item);

			Console.WriteLine("\nSuda cisla:");
			int[] evenNumbers = Filter<int>(numbers, x => x % 2 == 0);
			foreach (int item in evenNumbers)
				Console.WriteLine(item);

			string[] letters = new string[] { "ahoj", "cau", "Hello" };

			Console.WriteLine("\nDelka mensi nez 4:");
			string[] filteredLetters = Filter<string>(letters, x => x.Length < 4);
			foreach (string item in filteredLetters)
				Console.WriteLine(item);

			Console.WriteLine("\nVsechna pismena jsou mala:");
			string[] filteredLetters2 = Filter<string>(letters, x => IsUpper(x));
			foreach (string item in filteredLetters2)
				Console.WriteLine(item);
		}

		private static void OnSet(object sender, MyEventArgs args)
		{
			Console.WriteLine(string.Format("Nastaveno: ({0}, {1})", args.X, args.Y));
		}

		private static void Print(int x)
		{
			Console.WriteLine("Vysledek: " + x);
		}

		private static int Sum(int x, int y)
		{
			return x + y;
		}




		delegate bool FilterCondition<TData>(TData item);

		private static T[] Filter<T>(T[] data, FilterCondition<T> condition)
		{
			List<T> result = new List<T>();
			foreach(T item in data)
			{
				if(condition(item))
				{
					result.Add(item);
				}
			}
			return result.ToArray();
		}

		private static bool IsUpper(string input)
		{
			for(int i = 0; i < input.Length; i++)
			{
				if (char.IsUpper(input[i]))
					return false;
			}
			return true;
		}
	}
}
