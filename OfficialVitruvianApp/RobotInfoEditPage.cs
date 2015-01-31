using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Parse;
using System.Threading.Tasks;

namespace OfficialVitruvianApp
{
	public class RobotInfoEditPage : ContentPage
	{
		StackLayout teamStack;

		public RobotInfoEditPage ()
		{
			//Team 4201 Button
			Button vitBtn = new Button () {
				Text = "Robot Information (Edit Mode)",
				TextColor = Color.Green,
				BackgroundColor = Color.Black
			};
			vitBtn.Clicked += (object sender, EventArgs e) => {
			//	Navigation.PushModalAsync (new OurRobotPage ());
			};

			//A button to toggle between looking at teams and adding data about teams
			Button modeToggle = new Button {
				Text = "Mode Switch",
				TextColor = Color.Green,
				BackgroundColor = Color.Black
			};
			modeToggle.Clicked += (object sender, EventArgs e) => {
				Navigation.PushModalAsync (new RobotInfoPage ());
			};
			//A button to add a new team to the list
			Button addTeam = new Button {
				Text = "Add Team",
				TextColor = Color.Green,
				BackgroundColor = Color.Black
			};
			addTeam.Clicked += (object sender, EventArgs e) => {
				AddNewTeam();
			};

			//A button to look for teams based on categories
			//Code here

			//Refresh Button
			Button refreshBtn = new Button () {
				Text = "Refresh",
				TextColor = Color.Green,
				BackgroundColor = Color.Black
			};
			refreshBtn.Clicked += (object sender, EventArgs e) => {
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


			//Page Layout
			teamStack = new StackLayout ();

			ScrollView teamList = new ScrollView ();
			teamList.Content = teamStack;
			//UpdateTeamList();
			this.Appearing += (object sender, EventArgs e) => {
				UpdateTeamList();
			};

			this.Content = new StackLayout {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,

				Children = {
					vitBtn,
					modeToggle,
					addTeam,
					teamList,
					refreshBtn,
					backBtn
				}
			};
		}
		void SetupTeamList(){

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
			Navigation.PushModalAsync (new AddTeamPage (newTeam));
		}

		async Task UpdateTeamList(){
			ParseQuery<ParseObject> query = ParseObject.GetQuery("TeamData");
			var allTeams = await query.FindAsync();
			teamStack.Children.Clear();
			foreach (ParseObject obj in allTeams) {
				await obj.FetchAsync ();
				TeamListCell cell = new TeamListCell ();
				cell.teamName.Text = "Team " + obj["teamNumber"];
				teamStack.Children.Add (cell);
				TapGestureRecognizer tap = new TapGestureRecognizer ();
				tap.Tapped += (object sender, EventArgs e) => {
					Navigation.PushModalAsync (new AddTeamPage (obj));
				};
				cell.GestureRecognizers.Add (tap);
			}
		}
	}
}