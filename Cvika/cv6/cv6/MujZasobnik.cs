using System;
using System.Collections;
using System.Collections.Generic;

namespace cv6
{
	public class MujZasobnik : IEnumerable<int>
	{
		private int[] data;
		private int index;

		public MujZasobnik(int length)
		{
			data = new int[length];
			index = 0;
		}

		public int?[] Elements
		{
			get
			{
				int?[] elements = new int?[data.Length];
				for (int i = 0; i <= index; i++)
				{
					elements[i] = data[i];
				}
				return elements;
			}
		}

		public void Clear()
		{
			index = 0;
		}

		public bool IsEmpty()
		{
			return index <= 0;
		}

		public bool IsFull()
		{
			return data.Length == index;
		}

		public int Pop()
		{
			if (IsEmpty())
				throw new ApplicationException("Stack is empty");
			return data[--index];
		}

		public void Push(int x)
		{
			if (IsFull())
				throw new ApplicationException("Stack is full");
			data[index++] = x;
		}

		public int Top()
		{
			if (IsEmpty())
				throw new ApplicationException("Stack is empty");
			return data[index - 1];
		}

		public IEnumerator<int> GetEnumerator()
		{
			return new MujZasobnikEnumerator(data, index);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new MujZasobnikEnumerator(data, index);
		}
	}
}
