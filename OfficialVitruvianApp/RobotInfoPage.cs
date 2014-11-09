using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Parse; // Remeber to also add it to the Components folder under BOTH iOS and Andriod
using System.Threading.Tasks;

namespace OfficialVitruvianApp
{
	public class RobotInfoPage : ContentPage
	{
		StackLayout teamStack;

		public RobotInfoPage ()
		{
			//Team 4201 Button
			Button vitBtn = new Button () {
				Text = "Robot Information",
				TextColor = Color.Green,
				BackgroundColor = Color.Black
			};
			vitBtn.Clicked += (object sender, EventArgs e) => {
			//	Navigation.PushModalAsync (new OurRobotPage ());
			};

			//A button to toggle between looking at teams and adding data about teams
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

			//A table with a bunch of other teams
			//Code here

			//Back Button
			Button backBtn = new Button ();
			backBtn.Text = "Back";
			backBtn.TextColor = Color.Green;
			backBtn.BackgroundColor = Color.Black;

			backBtn.Clicked += (object sender, EventArgs e) => {
				Navigation.PushModalAsync(new MainMenuPage());
			};

			teamStack = new StackLayout ();

			ScrollView teamList = new ScrollView ();
			teamList.Content = teamStack;
			//UpdateTeamList();
			this.Appearing += (object sender, EventArgs e) => {
				UpdateTeamList();
			};

			/*Grid teamGrid = new Grid {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				RowDefinitions = {
					new RowDefinition {Hieght = GridLength.Auto},
					new RowDefinition {Hieght = GridLength.Auto},
					new RowDefinition {
					}
				},
				ColumnDefinitions = {
				},

				Children = {

				}

			};*/

			this.Content = new StackLayout {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,

				Children = {
					vitBtn,
					addTeam,
					//modeBtn,
					teamList,
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
		/*async Task UpdateMatches() {
			busyIcon.IsVisible = true;
			busyIcon.IsRunning = true;
			ParseQuery<ParseObject> query = ParseObject.GetQuery("RobotMatches");
			var allMatches = await query.FindAsync();
			matchData.Clear ();
			foreach (ParseObject obj in allMatches) {
				await obj.FetchAsync ();
				matchData.Add(new RobotMatch(obj.Get<int>("matchNumber"), obj));
			}
			busyIcon.IsVisible = false;
			busyIcon.IsRunning = false;
			//listView.ItemsSource = matchData;
		}*/
	}
}

