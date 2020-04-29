using System.Collections.Generic;

namespace cv8_2
{
	class ContactsDB
	{
		private IContactDBFactory db;

		public ContactsDB(IContactDBFactory db)
		{
			this.db = db;
		}

		public void SaveContact(Contact c)
		{
			IContactDao contactDao = db.CreateContactDao();
			contactDao.CreateContact(c);
		}

		public IEnumerable<Contact> FindAllContacts()
		{
			IContactDao contactDao = db.CreateContactDao();
			return contactDao.FindAllContacts();
		}
	}
}
