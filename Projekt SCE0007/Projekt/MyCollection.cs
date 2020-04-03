using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Projekt
{
	class MyCollection : IEnumerable
	{
		private Processor[] data;
		private int maxId;

		public MyCollection()
		{
			data = new Processor[0];
			maxId = 0;
		}

		public Processor this[int index]
		{
			get
			{
				if (data.Length <= index)
					return null;
				return data[index];
			}
			set
			{
				Add(value);
			}
		}

		public void Add(Processor obj)
		{
			if (obj.Id == null)
				obj.Id = ++maxId;
			else
				maxId++;

			Processor[] new_array = new Processor[data.Length + 1];
			for (int i = 0; i < data.Length; i++)
			{
				new_array[i] = data[i];
			}
			new_array[new_array.Length - 1] = obj;
			data = new_array;
		}

		public void RemoveById(int id)
		{
			for(int i = 0; i < data.Length; i++)
			{
				if (data[i].Id == id)
					RemoveAt(i);
			}
		}

		public void RemoveAt(int pos)
		{
			Processor[] new_array = new Processor[data.Length - 1];
			int index = 0;
			for (int i = 0; i < data.Length; i++)
			{
				if (i != pos)
				{
					new_array[index] = data[i];
					index++;
				}
			}
			data = new_array;
		}

		public int IndexOf(int id)
		{
			for (int i = 0; i < data.Length; i++)
			{
				if (data[i].Id == id)
					return i;
			}
			return -1;
		}

		public void OrderByName()
		{
			IEnumerable<Processor> sorted = data.OrderBy(cpu => cpu.Name);
			data = sorted.ToArray();
		}

		public void OrderByPrice()
		{
			IEnumerable<Processor> sorted = data.OrderBy(cpu => cpu.Price);
			data = sorted.ToArray();
		}

		public IEnumerator GetEnumerator()
		{
			for (int i = 0; i < data.Length; i++)
				yield return data[i];
		}

		public void Print()
		{
			foreach (Processor item in data)
				Console.WriteLine(item);
			Console.WriteLine();
		}
	}
}
