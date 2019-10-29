using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace WeekPicker
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private const int SEASON_WEEK_COUNT = 17;
		private enum Types
		{
			PRE,
			REG,
			POST // Still need to find what value works for this
		}

		public MainWindow()
		{
			InitializeComponent();
		}

		private void MainWindow1_Loaded(object sender, RoutedEventArgs e)
		{
			// Init season textbox
			SeasonText.Text = DateTime.Now.Year.ToString();

			// Init week picker items
			for (int i = 0; i < SEASON_WEEK_COUNT; i++)
			{
				WeekPick.Items.Add(new ComboBoxItem() { Content = $"semaine {i + 1}" });
			}
			WeekPick.SelectedIndex = 0;

			// Init type picker items
			TypePick.ItemsSource = Enum.GetValues(typeof(Types));
			TypePick.SelectedIndex = 1;
		}

		private void GoButton_Click(object sender, RoutedEventArgs e)
		{
			if (!int.TryParse(SeasonText.Text, out int season))
			{
				// Could not parse season year to int
				return;
			}
			int week = WeekPick.SelectedIndex + 1;
			string type = TypePick.SelectedItem.ToString();

			// Web request to get the match data
			string xml = string.Empty;
			string url = $"http://www.nfl.com/ajax/scorestrip?season={season}&week={week}&seasonType={type}";

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

			using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
			using (Stream stream = response.GetResponseStream())
			using (StreamReader reader = new StreamReader(stream))
			{
				xml = reader.ReadToEnd();
			}

			var picksWindow = new PicksWindow(xml, season, week, type);
			picksWindow.ShowDialog();
		}
	}
}
