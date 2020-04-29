using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace cv8_2
{
    class BinaryContactDao : IContactDao
    {
        private List<Contact> contacts = new List<Contact>();

        public BinaryContactDao()
        {
            BinaryFormatter serializer = new BinaryFormatter();
            try
            {
                using (FileStream fs = new FileStream("contacts.bin", FileMode.Open, FileAccess.ReadWrite))
                {
                    this.contacts = (List<Contact>)serializer.Deserialize(fs);
                }
            }
            catch (FileNotFoundException)
            {
                // pokud nebyl soubor nalezen, tak nechceme nic dělat. Ale zároveň nechceme aby aplikace spadla...
            }
        }



        public void CreateContact(Contact c)
        {
            this.contacts.Add(c);
            this.SaveContacts(this.contacts);
        }

        public void DeleteContact(Contact c)
        {
            this.contacts.Remove(c);
            this.SaveContacts(this.contacts);
        }

        public IEnumerable<Contact> FindAllContacts()
        {
            return this.contacts;
        }

        public void SaveContact(Contact c)
        {
            if (!this.contacts.Contains(c))
            {
                throw new Exception("Please use CreateContact");
            }
            this.SaveContacts(this.contacts);

        }


        private void SaveContacts(List<Contact> contacts)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            using (FileStream fs = new FileStream("contacts.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                serializer.Serialize(fs, contacts);
            }
        }
    }
}
