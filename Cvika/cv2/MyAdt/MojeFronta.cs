using System;
using System.Collections.Generic;
using System.Text;

namespace MyAdt
{
	public class MojeFronta : IFronta
	{
		int[] data;
		int index;
		int length;

		public MojeFronta(int length)
		{
			data = new int[length];
			index = 0;
			this.length = 0;
		}

		public void Add(int x)
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

		public int Get()
		{
			if (IsEmpty())
				throw new ApplicationException("Queue is empty");
			int tmp = data[index];
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
