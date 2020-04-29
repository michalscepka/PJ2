namespace cv8_2
{
	class SqlDBFactory : IContactDBFactory
	{
		public IContactDao CreateContactDao()
		{
			return new SqlContactDao();
		}
	}
}
