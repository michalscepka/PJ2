namespace cv7_2
{
	public class Contact
	{
		public string Name { get; set; }
		public int Age { get; set; }
		public string Email { get; set; }
		public int Weight { get; set; }
		public bool Alive { get; set; }

		public override string ToString()
		{
			return string.Format("{0}, {1}, {2}, {3}, {4}", Name, Age, Email, Weight, Alive);
		}
	}
}
