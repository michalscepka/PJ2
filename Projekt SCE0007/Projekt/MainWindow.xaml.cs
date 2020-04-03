using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Xml;

namespace Projekt
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private MyCollection array = new MyCollection();
		private readonly string path = @"C:\Users\Michal\Dropbox\School\4. semestr\PJ2\Projekt\Projekt\data.xml";

		public MainWindow()
		{
			InitializeComponent();
			ClearLabels();
			id_label.Content = string.Empty;
		}

		private void Load_Click(object sender, RoutedEventArgs e)
		{
			array = new MyCollection();

			XmlReader reader = XmlReader.Create(path);

			Processor cpu = new Processor();

			while (reader.Read())
			{
				if (reader.IsStartElement())
				{
					switch (reader.Name.ToString())
					{
						case "id":
							cpu.Id = ToNullableInt(reader.ReadElementContentAsString());
							break;
						case "name":
							cpu.Name = reader.ReadElementContentAsString();
							break;
						case "price":
							cpu.Price = ParseDouble(reader.ReadElementContentAsString());
							break;
						case "cores":
							cpu.Cores = ParseInt(reader.ReadElementContentAsString());
							break;
						case "frequency":
							cpu.Frequency = ParseDouble(reader.ReadElementContentAsString());
							break;
						case "architecture":
							cpu.Architecture = reader.ReadElementContentAsString();
							break;
						case "overclock":
							cpu.Overclock = Convert.ToBoolean(reader.ReadElementContentAsString());

							array.Add(cpu);
							cpu = new Processor();
							break;
					}
				}
			}
			reader.Close();
			PrintData();
		}

		private void Add_Click(object sender, RoutedEventArgs e)
		{
			info_label.Content = string.Empty;

			Processor new_cpu = new Processor
			{
				Name = name_tb.Text,
				Price = ParseDouble(price_tb.Text),
				Cores = ParseInt(cores_tb.Text),
				Frequency = ParseDouble(freq_tb.Text),
				Architecture = arch_tb.Text,
				Overclock = Convert.ToBoolean(overclock_chb.IsChecked)
			};

			array.Add(new_cpu);
			PrintData();
		}

		private void Edit_Click(object sender, RoutedEventArgs e)
		{
			info_label.Content = string.Empty;

			int index = array.IndexOf(ParseInt(id_tb.Text));

			array[index].Name = name_tb.Text;
			array[index].Price = ParseDouble(price_tb.Text);
			array[index].Cores = ParseInt(cores_tb.Text);
			array[index].Frequency = ParseDouble(freq_tb.Text);
			array[index].Architecture = arch_tb.Text;
			array[index].Overclock = Convert.ToBoolean(overclock_chb.IsChecked);

			PrintData();
		}

		private void Remove_Click(object sender, RoutedEventArgs e)
		{
			array.RemoveById(ParseInt(id_tb.Text));
			PrintData();
		}

		private void Save_Click(object sender, RoutedEventArgs e)
		{
			XmlWriterSettings settings = new XmlWriterSettings
			{
				Indent = true
			};

			XmlWriter writer = XmlWriter.Create(path, settings);

			writer.WriteStartDocument();

			writer.WriteStartElement("processors");
			foreach(Processor cpu in array)
			{
				writer.WriteStartElement("processor");
				writer.WriteElementString("id", cpu.Id.ToString());
				writer.WriteElementString("name", cpu.Name);
				writer.WriteElementString("price", cpu.Price.ToString());
				writer.WriteElementString("cores", cpu.Cores.ToString());
				writer.WriteElementString("frequency", cpu.Frequency.ToString());
				writer.WriteElementString("architecture", cpu.Architecture);
				writer.WriteElementString("overclock", cpu.Overclock.ToString());
				writer.WriteEndElement();
			}
			writer.WriteEndElement();
			writer.WriteEndDocument();
			writer.Flush();
			writer.Close();

			info_label.Content = "Saved to file";
		}

		private void PrintData()
		{
			ClearLabels();
			foreach (Processor cpu in array)
			{
				id_label.Content += cpu.Id.ToString() + "\n";
				names_label.Content += cpu.Name + "\n";
				price_label.Content += cpu.Price.ToString() + "\n";
				cores_label.Content += cpu.Cores.ToString() + "\n";
				freq_label.Content += cpu.Frequency.ToString() + "\n";
				arch_label.Content += cpu.Architecture + "\n";
				overclock_label.Content += cpu.Overclock.ToString() + "\n";
			}
		}

		private int? ToNullableInt(string s)
		{
			if (Int32.TryParse(s, out int number))
				return number;
			return null;
		}

		private int ParseInt(string s)
		{
			bool success = Int32.TryParse(s, out int number);
			if (success)
			{
				return number;
			}
			else
			{
				info_label.Content += "-Bad integer input\n";
				return -1;
			}
		}

		private double ParseDouble(string s)
		{
			NumberStyles style = NumberStyles.AllowDecimalPoint;
			CultureInfo culture = CultureInfo.CreateSpecificCulture("cs-CZ");

			bool success = Double.TryParse(s, style, culture, out double number);
			if (success)
			{
				return number;
			}
			else
			{
				info_label.Content += "-Bad double input (CultureInfo cs-CZ)\n";
				return -1;
			}
		}

		private void ClearLabels()
		{
			id_label.Content = string.Empty;
			names_label.Content = string.Empty;
			price_label.Content = string.Empty;
			cores_label.Content = string.Empty;
			freq_label.Content = string.Empty;
			arch_label.Content = string.Empty;
			overclock_label.Content = string.Empty;
		}

		private void Sort_by_name_Click(object sender, RoutedEventArgs e)
		{
			array.OrderByName();
			PrintData();
		}

		private void Sort_by_price_Click(object sender, RoutedEventArgs e)
		{
			array.OrderByPrice();
			PrintData();
		}
	}
}
