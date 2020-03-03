using System;
using System.Collections.Generic;
using System.Text;

namespace MyAdt
{
	public class MujZasobnik<T> : IZasobnik<T>
	{
		private T[] data;
		private int index;

		public MujZasobnik(int length)
		{
			data = new T[length];
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

		public T Pop()
		{
			if (IsEmpty())
				throw new ApplicationException("Stack is empty");
			return data[--index];
		}

		public void Push(T x)
		{
			if (IsFull())
				throw new ApplicationException("Stack is full");
			data[index++] = x;
		}

		public T Top()
		{
			if (IsEmpty())
				throw new ApplicationException("Stack is empty");
			return data[index - 1];
		}
	}
}
