using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
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
using System.Windows.Shapes;
using System.Xml;

namespace WeekPicker
{
	/// <summary>
	/// Interaction logic for PicksWindow.xaml
	/// </summary>
	public partial class PicksWindow : Window
	{
		private class MatchOptions
		{
			public RadioButton VisitorPick;
			public RadioButton HomePick;
		}

		private const int TEST = 16;
		private XmlDocument weekData;
		private List<MatchOptions> picks;

		public PicksWindow(string rawWeekData)
		{
			InitializeComponent();

			weekData = new XmlDocument();
			weekData.LoadXml(rawWeekData);

			picks = new List<MatchOptions>();

			XmlNodeList gamesList = weekData.SelectNodes("//g");
			for(int i = 0; i < gamesList.Count; i++)
			{
				CreateElementForMatch(ref PicksGrid, gamesList[i], i);
			}
		}

		private void PicksWindow1_Loaded(object sender, RoutedEventArgs e)
		{
			// Parse matches
			// Create match elements
		}

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{
			// Save the picks to json
		}

		private void CreateElementForMatch(ref Grid picksGrid, XmlNode game, int rowIndex)
		{
			Image visitImage = new Image()
			{
				Source = ConvertBitmap(NFLTeamDB.GetLogo(game.Attributes["v"].Value))
			};
			visitImage.SetValue(Grid.ColumnProperty, 0);
			visitImage.SetValue(Grid.RowProperty, rowIndex);
			picksGrid.Children.Add(visitImage);

			string visitName = game.Attributes["vnn"].Value;
			visitName.Replace(visitName[0], char.ToUpper(visitName[0]));
			var visit = new RadioButton()
			{
				Content = $"{NFLTeamDB.GetFullname(game.Attributes["v"].Value)} {visitName}",
				GroupName = rowIndex.ToString(),
				VerticalAlignment = VerticalAlignment.Center
			};
			visit.SetValue(Grid.ColumnProperty, 1);
			visit.SetValue(Grid.RowProperty, rowIndex);
			picksGrid.Children.Add(visit);

			Label vs = new Label()
			{
				Content = "VS.",
				HorizontalAlignment = HorizontalAlignment.Center,
				VerticalAlignment = VerticalAlignment.Center
			};
			vs.SetValue(Grid.ColumnProperty, 2);
			vs.SetValue(Grid.RowProperty, rowIndex);
			picksGrid.Children.Add(vs);

			string homeName = game.Attributes["hnn"].Value;
			homeName.Replace(homeName[0], char.ToUpper(homeName[0]));
			var home = new RadioButton()
			{
				Content = $"{NFLTeamDB.GetFullname(game.Attributes["h"].Value)} {homeName}",
				GroupName = rowIndex.ToString(),
				VerticalAlignment = VerticalAlignment.Center
			};
			home.SetValue(Grid.ColumnProperty, 3);
			home.SetValue(Grid.RowProperty, rowIndex);
			picksGrid.Children.Add(home);

			Image homeImage = new Image()
			{
				Source = ConvertBitmap(NFLTeamDB.GetLogo(game.Attributes["h"].Value))
			};
			homeImage.SetValue(Grid.ColumnProperty, 4);
			homeImage.SetValue(Grid.RowProperty, rowIndex);
			picksGrid.Children.Add(homeImage);

			picks.Add(new MatchOptions() { HomePick = home, VisitorPick = visit });
		}

		private BitmapImage ConvertBitmap(System.Drawing.Bitmap bitmap)
		{
			using (MemoryStream ms = new MemoryStream())
			{
				bitmap.Save(ms, ImageFormat.Bmp);
				ms.Seek(0, SeekOrigin.Begin);

				var image = new BitmapImage();
				image.BeginInit();
				image.StreamSource = ms;
				image.CacheOption = BitmapCacheOption.OnLoad;
				image.EndInit();

				return image;
			}
		}
	}
}
