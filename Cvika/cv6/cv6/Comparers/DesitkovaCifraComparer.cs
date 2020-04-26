using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace cv6.Comparers
{
	class DesitkovaCifraComparer : IComparer<int>
	{
		public int Compare([AllowNull] int x, [AllowNull] int y)
		{
			int xUnit = x % 10;
			int yUnit = y % 10;
			if (xUnit == yUnit)
			{
				return x - y;
			}
			return xUnit - yUnit;
		}
	}
}
