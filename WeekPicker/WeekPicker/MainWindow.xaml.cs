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

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WeekPicker
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private const int SEASON_WEEK_COUNT = 21;

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
		}

		private void GoButton_Click(object sender, RoutedEventArgs e)
		{
			if (!int.TryParse(SeasonText.Text, out int season))
			{
				// Could not parse season year to int
				return;
			}
			int week = WeekPick.SelectedIndex + 1;

			// Web request to get the match data
			JObject json;
			string url = $"https://www.thesportsdb.com/api/v1/json/1/eventsround.php?id=4391&r={week}&s={season}";

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

			using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
			using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            using (JsonTextReader jReader = new JsonTextReader(reader))
			{
                json = (JObject)JToken.ReadFrom(jReader);
			}

			var picksWindow = new PicksWindow(json, season, week);
			picksWindow.ShowDialog();
		}
	}
}
