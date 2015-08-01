using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Parse;
using System.Threading.Tasks;

namespace OfficialVitruvianApp
{
	public class RobotInfoPage : ContentPage
	{
		StackLayout teamStack = new StackLayout();

		public RobotInfoPage ()
		{
			//Page Title
			Label title = new Label () {
				Text = "Robot Information",
				FontSize =18,
				TextColor = Color.Green,
				BackgroundColor = Color.Black
			};

			//A button to toggle between looking at teams and adding data about teams
			/*
			Button modeToggle = new Button {
				Text = "Mode Switch",
				TextColor = Color.Green,
				BackgroundColor = Color.Black
			};
			modeToggle.Clicked += (object sender, EventArgs e) => {
				Navigation.PushModalAsync (new RobotInfoEditPage ());
			};
			*/

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

			ScrollView teamList = new ScrollView ();
			teamList.Content = teamStack;
			this.Appearing += (object sender, EventArgs e) => {
				UpdateTeamList();
			};

			StackLayout navigationBtns = new StackLayout () {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Horizontal,
				BackgroundColor = Color.Green,

				Children = {
					backBtn,
					refreshBtn
				}
			};

			this.Content = new StackLayout {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,

				Children = {
					title,
					teamList,
					navigationBtns
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
			ParseQuery<ParseObject> sorted = query.OrderBy("teamNumber");

			var allTeams = await sorted.FindAsync();
			teamStack.Children.Clear();
			foreach (ParseObject obj in allTeams) {
				await obj.FetchAsync ();
				TeamListCell cell = new TeamListCell ();
				cell.teamName.Text = "Team " + obj["teamNumber"];
				teamStack.Children.Add (cell);
				TapGestureRecognizer tap = new TapGestureRecognizer ();
				tap.Tapped += (object sender, EventArgs e) => {
					Navigation.PushModalAsync (new ViewTeamPage (obj));
				};
				cell.GestureRecognizers.Add (tap);
			}
		}
	}
}

