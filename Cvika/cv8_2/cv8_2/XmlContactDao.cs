using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace cv8_2
{
	class XmlContactDao : IContactDao
	{
		private List<Contact> contacts = new List<Contact>();

		public XmlContactDao()
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<Contact>));
			try
			{
				using FileStream fs = new FileStream("contacts.xml", FileMode.Open, FileAccess.ReadWrite);
				contacts = (List<Contact>)serializer.Deserialize(fs);
			}
			catch (FileNotFoundException) { }
		}

		public void CreateContact(Contact c)
		{
			contacts.Add(c);
			SaveContacts(contacts);
		}

		public void DeleteContact(Contact c)
		{
			contacts.Remove(c);
			SaveContacts(contacts);
		}

		public IEnumerable<Contact> FindAllContacts()
		{
			return contacts;
		}

		public void SaveContact(Contact c)
		{
			if(!contacts.Contains(c))
			{
				throw new Exception("Please use CreateContact");
			}
			SaveContacts(contacts);
		}

		private void SaveContacts(List<Contact> contacts)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(List<Contact>));
			using FileStream fs = new FileStream("contacts.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
			serializer.Serialize(fs, contacts);
		}
	}
}
