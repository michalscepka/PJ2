using System;
using System.Linq;

namespace cv3
{
	class DynamicArray
	{
		private int?[] data;

		public enum Info
		{
			Empty,
			SomeData,
			Full
		}

		public DynamicArray(int length = 5)
		{
			data = new int?[length];
		}

		public int Length
		{
			get
			{
				return data.Length;
			}
			set
			{
				if (value < data.Length)
				{
					throw new ApplicationException("New size small then before.");
				}
				Resize(value);
			}
		}

		private void Resize(int new_size)
		{
			int?[] new_array = new int?[new_size];
			Array.Copy(data, new_array, data.Length);
			data = new_array;
		}

		public int? this[int index]
		{
			get
			{
				if (data.Length <= index)
					return null;
				return data[index];
			}
			set
			{
				if (data.Length <= index)
					Resize(index + 1);
				data[index] = value;
			}
		}

		public override string ToString()
		{
			return string.Join(", ", data.Select(x => x.HasValue ? x.Value : 0));
		}

		public void Sum(ref int result)
		{
			foreach(int? value in data)
			{
				result += value.HasValue ? value.Value : 0;
			}
		}

		public Info Inf
		{
			get
			{
				return Info.Empty;
			}
		}
	}
}
