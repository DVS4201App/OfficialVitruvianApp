using System;
using Xamarin.Forms;
using Parse;
using Xamarin;
using System.Threading.Tasks;

namespace OfficialVitruvianApp
{
	public class PitScoutingPage : ContentPage
	{
		StackLayout pitStack = new StackLayout();

		public PitScoutingPage ()
		{
			//Page Title
			Label pageLabel = new Label () {
				Text = "Pit Scouting",
				FontSize =18,
				TextColor = Color.Green,
				BackgroundColor = Color.Black
			};

			//Team List
			ScrollView teamList = new ScrollView ();
			teamList.HorizontalOptions = LayoutOptions.CenterAndExpand;
			teamList.Content = pitStack;
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

			//Refresh Button
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
				BackgroundColor = Color.Green,

				Children = {
					backBtn,
					refreshBtn,
					addTeamBtn
				}
			};

			this.Content = new StackLayout () {
				//Padding = new Thickness(0,20,0,0), //How to avoid padding issues once phone reboots?
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,

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
			ParseObject newTeam = new ParseObject("TeamData");
			//newTeam["teamNumber"] = teamCount;
			//await newTeam.SaveAsync();
			//await UpdateTeamList ();
			Console.WriteLine ("Test");
			Navigation.PushModalAsync (new AddPitTeam (newTeam));
		}

		async Task UpdateTeamList(){
			ParseQuery<ParseObject> query = ParseObject.GetQuery("TeamData");
			ParseQuery<ParseObject> sorted = query.OrderBy("teamNumber");

			var allTeams = await sorted.FindAsync();
			pitStack.Children.Clear();
			foreach (ParseObject obj in allTeams) {
				await obj.FetchAsync ();
				TeamListCell cell = new TeamListCell ();
				cell.teamName.Text = "Team " + obj["teamNumber"];
				cell.teamName.TextColor = Color.FromRgb(Convert.ToInt32(obj["pitScoutStatus"].ToString()), 255, Convert.ToInt32(obj["pitScoutStatus"].ToString()));

				if (Convert.ToInt16(obj["pitScoutStatus"].ToString())==0){
					cell.teamName.TextColor = Color.Green;
				} else {
					cell.teamName.TextColor = Color.White;
				}

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