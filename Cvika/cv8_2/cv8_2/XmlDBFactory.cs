namespace cv8_2
{
	class XmlDBFactory : IContactDBFactory
	{
		public IContactDao CreateContactDao()
		{
			return new XmlContactDao();
		}
	}
}
