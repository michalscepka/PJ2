using System;

namespace cv8_2
{
	[Serializable]
	public class Contact
	{
		public string Name { get; set; }
		public int Age { get; set; }
		public string Email { get; set; }
		public DateTime BirthDate { get; set; }
		public int Weight {
			get { return Weight; } 
			set
			{
				Weight = value;
				StateChanged?.Invoke(this, EventArgs.Empty);
			}
		}
		public bool IsMarried { get; set; }

		[field: NonSerialized]
		public event EventHandler StateChanged;

		public override string ToString()
		{
			return string.Format("{0}, {1}, {2}, {3}, {4}, {5}", Name, Age, Email, BirthDate.ToString("dd.MM.yyyy"), Weight, IsMarried);
		}
	}
}
