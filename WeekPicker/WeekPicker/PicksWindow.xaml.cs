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

using Newtonsoft.Json;

namespace WeekPicker
{
	/// <summary>
	/// Interaction logic for PicksWindow.xaml
	/// </summary>
	public partial class PicksWindow : Window
	{
		private enum ColumnType
		{
			VisitLogo,
			VisitTeam,
			VsLabel,
			HomeTeam,
			HomeLogo,
		}

		private class MatchPick
		{
			public RadioButton VisitorPick;
			public RadioButton HomePick;

			public XmlNode GameData;

			/// <summary>
			/// This functions will return either "h" if the player picked the home team and "v" if they picked the visitor team
			/// </summary>
			/// <returns>"h" or "v"</returns>
			public string SerializePick()
			{
				if (VisitorPick != null && VisitorPick.IsChecked.HasValue && VisitorPick.IsChecked.Value)
					return GameData.Attributes["v"].Value;

				else if (HomePick != null && HomePick.IsChecked.HasValue && HomePick.IsChecked.Value)
					return GameData.Attributes["h"].Value;

				else
					return "N/A";
			}
		}

		[Serializable]
		private class PickData
		{
			public string pooler;
			public string[] picks;
		}

		private int season;
		private int week;
		private string type;

		private XmlDocument weekData;
		private List<MatchPick> picks;

		public PicksWindow(string rawWeekData, int s, int w, string t)
		{
			InitializeComponent();

			season = s;
			week = w;
			type = t;

			weekData = new XmlDocument();
			weekData.LoadXml(rawWeekData);

			picks = new List<MatchPick>();
		}

		private void PicksWindow1_Loaded(object sender, RoutedEventArgs e)
		{
			XmlNodeList gamesList = weekData.SelectNodes("//g");
			for(int i = 0; i < gamesList.Count; i++)
			{
				CreateElementForMatch(ref PicksGrid, gamesList[i], i);
			}
		}

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{
			PickData toWrite = new PickData()
			{
				pooler = PoolerName.Text,
				picks = picks.Select(p => p.SerializePick()).ToArray()
			};

			string output = JsonConvert.SerializeObject(toWrite);
			Console.WriteLine(output);

			string filename = $"{toWrite.pooler}-{season}-semaine{week}-{type}.json";
			File.WriteAllText(filename, output);

			Close();
		}

		private void CreateElementForMatch(ref Grid picksGrid, XmlNode game, int rowIndex)
		{
			Image visitImage = new Image()
			{
				Source = ConvertBitmap(NFLTeamDB.GetLogo(game.Attributes["v"].Value))
			};
			picksGrid.Children.Add(visitImage.SetGridCoords(rowIndex, (int)ColumnType.VisitLogo) as Image);

			var visit = CreateTeamButton(game.Attributes["v"].Value, game.Attributes["vnn"].Value, rowIndex);
			picksGrid.Children.Add(visit.SetGridCoords(rowIndex, (int)ColumnType.VisitTeam) as RadioButton);

			Label vs = new Label()
			{
				Content = "VS.",
				HorizontalAlignment = HorizontalAlignment.Center,
				VerticalAlignment = VerticalAlignment.Center
			};
			picksGrid.Children.Add(vs.SetGridCoords(rowIndex, (int)ColumnType.VsLabel) as Label);

			var home = CreateTeamButton(game.Attributes["h"].Value, game.Attributes["hnn"].Value, rowIndex);
			picksGrid.Children.Add(home.SetGridCoords(rowIndex, (int)ColumnType.HomeTeam) as RadioButton);

			Image homeImage = new Image()
			{
				Source = ConvertBitmap(NFLTeamDB.GetLogo(game.Attributes["h"].Value))
			};
			picksGrid.Children.Add(homeImage.SetGridCoords(rowIndex, (int)ColumnType.HomeLogo) as Image);

			picks.Add(new MatchPick() { HomePick = home, VisitorPick = visit, GameData = game });
		}

		private RadioButton CreateTeamButton(string shortname, string fullname, int rowIndex)
		{
			string visitName = $"{char.ToUpper(fullname[0])}{fullname.Substring(1)}";
			return new RadioButton()
			{
				Content = $"{NFLTeamDB.GetFullname(shortname)} {visitName}",
				GroupName = rowIndex.ToString(),
				VerticalAlignment = VerticalAlignment.Center
			};
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
