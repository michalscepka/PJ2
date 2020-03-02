using System;
using System.Collections.Generic;
using System.Text;

namespace MyAdt
{
	public class MujZasobnik : IZasobnik
	{
		int[] data;
		int index;

		public MujZasobnik(int length)
		{
			data = new int[length];
			index = 0;
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
	}
}
