using System.Collections;
using System.Collections.Generic;

namespace cv6
{
	class MujZasobnikEnumerator : IEnumerator<int>
	{
		private int[] data;
		private int top;
		private int currentIndex = -1;

		public MujZasobnikEnumerator(int[] data, int top)
		{
			this.data = data;
			this.top = top;
		}

		public int Current
		{
			get
			{
				return data[currentIndex];
			}
		}

		object IEnumerator.Current
		{
			get
			{
				return data[currentIndex];
			}
		}

		public void Dispose()
		{
			//throw new NotImplementedException();
		}

		public bool MoveNext()
		{
			if(currentIndex < top - 1)
			{
				currentIndex++;
				return true;
			}
			return false;
		}

		public void Reset()
		{
			currentIndex = -1;
		}
	}
}
