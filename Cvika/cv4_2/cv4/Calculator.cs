using System;

namespace cv4
{
	delegate int Operation(int a, int b);
	delegate void Computed(int result);

	class Calculator
	{
		private int x;
		private int y;

		public event EventHandler<MyEventArgs> OnSetXY;
		public event Computed OnCompute;

		public void SetXY(int x, int y)
		{
			this.x = x;
			this.y = y;

			OnSetXY?.Invoke(this, new MyEventArgs() { X = x, Y = y });
		}

		public int Execute(Operation op)
		{
			int result = op(x, y);

			OnCompute?.Invoke(result);

			return result;
		}
	}
}
