using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace cv6.Comparers
{
	public class SudaLichaComparer : IComparer<int>
	{
		public int Compare([AllowNull] int x, [AllowNull] int y)
		{
			//obe jsou suda nebo licha
			if(x % 2 == y % 2)
			{
				//podle velikosti...
				// zaporny vysledek = x mensi nez y
				// kladny = y vetsi nez x
				return x - y;
			}

			//x je sude
			return x % 2 == 0 ? -1 : 1;
		}
	}
}
