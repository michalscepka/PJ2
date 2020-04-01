using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Shapes;
using System.Xml;

namespace Projekt
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		MyCollection array = new MyCollection();

		public MainWindow()
		{
			InitializeComponent();
			ClearLabels();
		}

		private void Load_Click(object sender, RoutedEventArgs e)
		{
			array = new MyCollection();

			string path = @"C:\Users\Michal\Dropbox\School\4. semestr\PJ2\Projekt\Projekt\data.xml";

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
							cpu.Price = Convert.ToDouble(reader.ReadElementContentAsString());
							break;
						case "cores":
							cpu.Cores = Convert.ToInt32(reader.ReadElementContentAsString());
							break;
						case "frequency":
							cpu.Frequency = Convert.ToDouble(reader.ReadElementContentAsString());
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
			Processor new_cpu = new Processor();

			//TODO prepsat na metodu + osetrit prazdny input
			new_cpu.Name = name_tb.Text;
			new_cpu.Price = Convert.ToDouble(price_tb.Text);
			new_cpu.Cores = Convert.ToInt32(cores_tb.Text);
			new_cpu.Frequency = Convert.ToDouble(freq_tb.Text);
			new_cpu.Architecture = arch_tb.Text;
			new_cpu.Overclock = Convert.ToBoolean(overclock_chb.IsChecked);

			array.Add(new_cpu);
			PrintData();
		}

		private void Edit_Click(object sender, RoutedEventArgs e)
		{
			int index = array.IndexOf(Convert.ToInt32(id_tb.Text));

			array[index].Name = name_tb.Text;
			array[index].Price = Convert.ToDouble(price_tb.Text);
			array[index].Cores = Convert.ToInt32(cores_tb.Text);
			array[index].Frequency = Convert.ToDouble(freq_tb.Text);
			array[index].Architecture = arch_tb.Text;
			array[index].Overclock = Convert.ToBoolean(overclock_chb.IsChecked);

			PrintData();
		}

		private void Remove_Click(object sender, RoutedEventArgs e)
		{
			array.RemoveById(Convert.ToInt32(id_tb.Text));
			PrintData();
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

		public int? ToNullableInt(string s)
		{
			if (int.TryParse(s, out int number))
				return number;
			return null;
		}

		public void ClearLabels()
		{
			id_label.Content = string.Empty;
			names_label.Content = string.Empty;
			price_label.Content = string.Empty;
			cores_label.Content = string.Empty;
			freq_label.Content = string.Empty;
			arch_label.Content = string.Empty;
			overclock_label.Content = string.Empty;
		}
	}
}
