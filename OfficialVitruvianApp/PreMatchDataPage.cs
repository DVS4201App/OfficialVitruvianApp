using System;
using Xamarin.Forms;
using Parse;
using System.Threading.Tasks;

namespace OfficialVitruvianApp
{
	public class PreMatchDataPage:ContentPage
	{
		ParseObject MatchData = new ParseObject("MatchData");

		public PreMatchDataPage ()
		{
			Label matchNoLabel = new Label {
				Text = "Match Number:",
			};

			Entry matchNo = new Entry {
				Placeholder = "[Enter Match No.]"
			};
			matchNo.Keyboard = Keyboard.Numeric;

			Label teamNoLabel = new Label {
				Text = "Team Number:",
			};

			Entry teamNo = new Entry {
				Placeholder = "[Enter Team No.]"
			};
			teamNo.Keyboard = Keyboard.Numeric;

			//Start Match Scout
			Button beginScoutBtn = new Button {
				Text = "Begin Match",
				TextColor = Color.Green,
				BackgroundColor = Color.Black
			};
			beginScoutBtn.Clicked += (object sender, EventArgs e) => {
				MatchData.Add("team_Match", teamNo.Text+"-"+matchNo.Text);
				MatchData.Add("teamNo", Convert.ToInt32(teamNo.Text));
				MatchData.Add("matchNo", Convert.ToInt32(matchNo.Text));
				SaveData();
				Console.WriteLine(MatchData["team_Match"].ToString());
				Navigation.PushModalAsync(new matchTest(MatchData));
			};


			//Back Button
			Button backBtn = new Button ();
			backBtn.Text = "Back";
			backBtn.TextColor = Color.Green;
			backBtn.BackgroundColor = Color.Black;

			backBtn.Clicked += (object sender, EventArgs e) => {
				Navigation.PushModalAsync(new MainMenuPage());
			};

			StackLayout navigationBtns = new StackLayout () {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Horizontal,
				BackgroundColor = Color.Green,

				Children = {
					backBtn,
					beginScoutBtn
				}
			};

			this.Content = new StackLayout () {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,

				Children = {
					matchNoLabel,
					matchNo,
					teamNoLabel,
					teamNo,
					navigationBtns
				}
			};
		}
		async void SaveData(){
			Console.WriteLine ("Saving...");
			await MatchData.SaveAsync ();
			Console.WriteLine ("Done Saving");
		}
	}
}

