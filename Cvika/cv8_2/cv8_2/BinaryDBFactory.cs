namespace cv8_2
{
	class BinaryDBFactory : IContactDBFactory
	{
		public IContactDao CreateContactDao()
		{
			return new BinaryContactDao();
		}
	}
}
