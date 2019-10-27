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
			// Web request to get the match data

			if (!int.TryParse(SeasonText.Text, out int season))
			{
				// Could not parse season year to int
				return;
			}
			int week = WeekPick.SelectedIndex + 1;
			string type = TypePick.SelectedItem.ToString();
		}
	}
}
