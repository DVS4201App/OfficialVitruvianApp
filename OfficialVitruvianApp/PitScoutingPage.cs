using System;
using Xamarin.Forms;
using Parse;
using System.Threading.Tasks;

namespace OfficialVitruvianApp
{
	public class PitScoutingPage : ContentPage
	{
		StackLayout pitStack = new StackLayout ();

		public PitScoutingPage ()
		{
			//Page Title
			Label pageLabel = new Label () {
				Text = "Pit Scouting",
				TextColor = Color.Green,
				BackgroundColor = Color.Black
			};
			pageLabel.FontSize = 18;

			//Team List
			ScrollView teamList = new ScrollView ();
			teamList.Content = pitStack;
			UpdateTeamList();
			this.Appearing += (object sender, EventArgs e) => {
				UpdateTeamList();
			};

			//Back Button
			Button backBtn = new Button ();
			backBtn.Text = "Back";
			backBtn.TextColor = Color.Green;
			backBtn.BackgroundColor = Color.Black;

			backBtn.Clicked += (object sender, EventArgs e) => {
				Navigation.PushModalAsync(new MainMenuPage());
			};

			//RefershBtn
			Button refreshBtn = new Button () {
				Text = "Refresh",
				TextColor = Color.Green,
				BackgroundColor = Color.Black
			};
			refreshBtn.Clicked += (object sender, EventArgs e) => {
				UpdateTeamList();
			};

			//Add Team Button
			Button addTeamBtn = new Button {
				Text = "Add Team",
				TextColor = Color.Green,
				BackgroundColor = Color.Black
			};
			addTeamBtn.Clicked += (object sender, EventArgs e) => {
				AddNewTeam();
			};

			//Page Layout

			StackLayout navigationBtns = new StackLayout () {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Horizontal,
				Children = {
					backBtn,
					refreshBtn,
					addTeamBtn
				}
			};

			this.Content = new StackLayout () {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,


				Children = {
					pageLabel,
					teamList,
					navigationBtns
				}
			};
		}

		async void AddNewTeam () {
			//ParseQuery<ParseObject> query = ParseObject.GetQuery("TeamData");
			//int teamCount = await query.CountAsync();
			//teamCount++;
			ParseObject newTeam = new ParseObject("TeamPitData");
			//newTeam["teamNumber"] = teamCount;
			//await newTeam.SaveAsync();
			//await UpdateTeamList ();
			Console.WriteLine ("Test");
			Navigation.PushModalAsync (new AddPitTeam (newTeam));
		}

		async Task UpdateTeamList(){
			ParseQuery<ParseObject> query = ParseObject.GetQuery("TeamData");
			var allTeams = await query.FindAsync();
			pitStack.Children.Clear();
			foreach (ParseObject obj in allTeams) {
				await obj.FetchAsync ();
				TeamListCell cell = new TeamListCell ();
				cell.teamName.Text = "Team " + obj["teamNumber"];
				pitStack.Children.Add (cell);
				TapGestureRecognizer tap = new TapGestureRecognizer ();
				tap.Tapped += (object sender, EventArgs e) => {
					Navigation.PushModalAsync (new AddPitTeam (obj));
				};
				cell.GestureRecognizers.Add (tap);
			}
		}
	}
}