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
using Newtonsoft.Json.Linq;

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

			public JObject GameData;

			/// <summary>
			/// This functions will return either "h" if the player picked the home team and "v" if they picked the visitor team
			/// </summary>
			/// <returns>"h" or "v"</returns>
			public string SerializePick()
			{
                if (VisitorPick != null && VisitorPick.IsChecked.HasValue && VisitorPick.IsChecked.Value)
                {
                    GameData.TryGetValue("strAwayTeam", out JToken awayFullname);
                    return NFLTeamDB.GetShortName(awayFullname.ToString());
                }
				else if (HomePick != null && HomePick.IsChecked.HasValue && HomePick.IsChecked.Value)
                {
                    GameData.TryGetValue("strHomeTeam", out JToken homeFullname);
                    return NFLTeamDB.GetShortName(homeFullname.ToString());
                }
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

		private JObject weekData;
		private List<MatchPick> picks;

		public PicksWindow(JObject rawWeekData, int s, int w)
		{
			InitializeComponent();

			season = s;
			week = w;

			weekData = rawWeekData;

			picks = new List<MatchPick>();
		}

		private void PicksWindow1_Loaded(object sender, RoutedEventArgs e)
		{
            weekData.TryGetValue("events", out JToken eventsToken);

            JArray gamesList = (JArray)eventsToken;
			for(int i = 0; i < gamesList.Count; i++)
			{
				CreateElementForMatch(ref PicksGrid, (JObject)gamesList[i], i);
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

			string filename = $"{toWrite.pooler}-{season}-semaine{week}.json";
			File.WriteAllText(filename, output);

			Close();
		}

		private void CreateElementForMatch(ref Grid picksGrid, JObject game, int rowIndex)
		{
            game.TryGetValue("strHomeTeam", out JToken homeFullname);
            string homeShortname = NFLTeamDB.GetShortName(homeFullname.ToString());

            game.TryGetValue("strAwayTeam", out JToken awayFullname);
            string awayShortname = NFLTeamDB.GetShortName(awayFullname.ToString());

            Image visitImage = new Image()
			{
				Source = ConvertBitmap(NFLTeamDB.GetLogo(awayShortname))
			};
			picksGrid.Children.Add(visitImage.SetGridCoords(rowIndex, (int)ColumnType.VisitLogo) as Image);

			var visit = CreateTeamButton(awayFullname.ToString(), rowIndex);
			picksGrid.Children.Add(visit.SetGridCoords(rowIndex, (int)ColumnType.VisitTeam) as RadioButton);

			Label vs = new Label()
			{
				Content = "VS.",
				HorizontalAlignment = HorizontalAlignment.Center,
				VerticalAlignment = VerticalAlignment.Center
			};
			picksGrid.Children.Add(vs.SetGridCoords(rowIndex, (int)ColumnType.VsLabel) as Label);

			var home = CreateTeamButton(homeFullname.ToString(), rowIndex);
			picksGrid.Children.Add(home.SetGridCoords(rowIndex, (int)ColumnType.HomeTeam) as RadioButton);

			Image homeImage = new Image()
			{
				Source = ConvertBitmap(NFLTeamDB.GetLogo(homeShortname))
			};
			picksGrid.Children.Add(homeImage.SetGridCoords(rowIndex, (int)ColumnType.HomeLogo) as Image);

			picks.Add(new MatchPick() { HomePick = home, VisitorPick = visit, GameData = game });
		}

		private RadioButton CreateTeamButton(string fullname, int rowIndex)
		{
			string visitName = $"{char.ToUpper(fullname[0])}{fullname.Substring(1)}";
			return new RadioButton()
			{
				Content = visitName,
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
