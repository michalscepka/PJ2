using System;
using System.Collections.Generic;
using System.Text;

namespace MyAdt
{
	public class MojeFronta<T> : IFronta<T>
	{
		private T[] data;
		private int index;
		private int length;

		public MojeFronta(int length)
		{
			data = new T[length];
			index = 0;
			this.length = 0;
		}

		public void Add(T x)
		{
			if(IsFull())
				throw new ApplicationException("Queue is full");
			data[(index + length) % data.Length] = x;
			length++;
		}

		public void Clear()
		{
			index = 0;
			length = 0;
		}

		public T Get()
		{
			if (IsEmpty())
				throw new ApplicationException("Queue is empty");
			T tmp = data[index];
			index = (index + 1) % data.Length;
			length--;
			return tmp;
		}

		public bool IsEmpty()
		{
			return length == 0;
		}

		public bool IsFull()
		{
			return data.Length - 1 == length;
		}
	}
}
