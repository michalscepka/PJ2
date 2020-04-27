using System;
using System.Collections.Generic;
using System.IO;

namespace cv7_2
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Text file");

			string path = @"..\..\..\data.txt";

			List<Contact> contacts = new List<Contact>
			{
				new Contact { Name = "Petr", Age = 30, Email = "petr@gmail.com", Weight = 80, Alive = true },
				new Contact { Name = "Pavel", Age = 35, Email = "pavel@gmail.com", Weight = 85, Alive = true }
			};

			WriteToFile(path, contacts);

			List<Contact> contacts2 = ReadFromFile(path);

			foreach (Contact item in contacts2)
				Console.WriteLine(item);
			Console.WriteLine();

			Console.WriteLine("Binary file");

			const string fileName = @"..\..\..\mujBinaryFile.dat";

			WriteToBinaryFile(fileName, contacts);

			List<Contact> list_binarnich_kontaktu = ReadFromBinaryFile(fileName);
			
			foreach (Contact item in list_binarnich_kontaktu)
				Console.WriteLine(item);
		}

		private static List<Contact> ReadFromFile(string path)
		{
			List<Contact> contacts = new List<Contact>();

			string[] lines = File.ReadAllLines(path);
			
			foreach (string line in lines)
			{
				string[] items = line.Split(", ");
				contacts.Add(new Contact { Name = items[0], Age = int.Parse(items[1]), Email = items[2], Weight = int.Parse(items[3]), Alive = bool.Parse(items[4]) });
			}

			return contacts;
		}

		private static void WriteToFile(string path, List<Contact> contacts)
		{
			using StreamWriter file = new StreamWriter(path, false);
			foreach (Contact item in contacts)
				file.WriteLine(item);
			file.Close();
		}

		private static void WriteToBinaryFile(string fileName, List<Contact> contacts)
		{
			using BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create));
			foreach (Contact item in contacts)
			{
				writer.Write(item.Name);
				writer.Write(item.Age);
				writer.Write(item.Email);
				writer.Write(item.Weight);
				writer.Write(item.Alive);
			}
		}

		private static List<Contact> ReadFromBinaryFile(string fileName)
		{
			if (File.Exists(fileName))
			{
				List<Contact> contacts = new List<Contact>();
				using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
				{
					while (reader.BaseStream.Position != reader.BaseStream.Length)
					{
						Contact contact = new Contact
						{
							Name = reader.ReadString(),
							Age = reader.ReadInt32(),
							Email = reader.ReadString(),
							Weight = reader.ReadInt32(),
							Alive = reader.ReadBoolean()
						};

						contacts.Add(contact);
					}
				}
				return contacts;
			}
			return null;
		}
	}
}
