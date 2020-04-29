using System;
using System.Collections.Generic;

namespace cv8_2
{
	class Program
	{
		static void Main(string[] args)
		{
			/*List<Contact> contacts = new List<Contact>
			{
				new Contact { Name = "Petr", Age = 30, Email = "petr@gmail.com", BirthDate = new DateTime(1990, 1, 1), Weight = 80, Married = true },
				new Contact { Name = "Pavel", Age = 35, Email = "pavel@gmail.com", BirthDate = new DateTime(2000, 1, 1), Weight = 85, Married = false }
			};

			foreach (Contact item in contacts)
				Console.WriteLine(item);*/

            Test(new XmlDBFactory());
            //Test(new BinaryDBFactory());
        }

        private static void Test(IContactDBFactory factory)
        {
            ContactsDB db = new ContactsDB(factory);

            Contact contact = new Contact()
            {
                Age = 31,
                BirthDate = new DateTime(1988, 11, 2),
                Email = "jan@vsb.cz",
                IsMarried = false,
                Name = "Jan",
                Weight = 74
            };

            ContactListener listener = new ContactListener();

            contact.StateChanged += listener.Changed;
            contact.Weight = 75;

            db.SaveContact(contact);

            foreach (Contact tmp in db.FindAllContacts())
            {
                Console.WriteLine(tmp);
            }
        }
    }
}
