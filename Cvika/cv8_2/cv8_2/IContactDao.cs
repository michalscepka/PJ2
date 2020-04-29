using System.Collections.Generic;

namespace cv8_2
{
	interface IContactDao
	{
		void CreateContact(Contact c);
		void DeleteContact(Contact c);
		IEnumerable<Contact> FindAllContacts();
		void SaveContact(Contact c);
	}
}
