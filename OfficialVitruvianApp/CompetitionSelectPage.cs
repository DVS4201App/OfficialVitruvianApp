using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System;
using Parse;


namespace OfficialVitruvianApp
{
	public class CompetitionSelectPage : ContentPage
	{
		StackLayout matchStack;
		StackLayout competitionStack;
		public CompetitionSelectPage ()
		{
			//Title
			Label competitionLabel = new Label();
			competitionLabel.TextColor = Color.Green;
			competitionLabel.HorizontalOptions = LayoutOptions.Center;
			competitionLabel.Text = "Competition Select";

			//Competition One Button
			Button oneBtn = new Button ();
			oneBtn.Text = "Name Coming Soon";
			oneBtn.TextColor = Color.Green;
			oneBtn.BackgroundColor = Color.Black;
			oneBtn.Clicked += (object sender, EventArgs e) => {
				//This button should change the table of matches to show only matches for this competition.
			};


			//Competition Two Button
			Button twoBtn = new Button ();
			twoBtn.Text = "Name Coming Soon";
			twoBtn.TextColor = Color.Green;
			twoBtn.BackgroundColor = Color.Black;
			twoBtn.Clicked += (object sender, EventArgs e) => {
				//This button should change the table of matches to show only matches for this competition.
			};


			//Competition Three Button
			Button threeBtn = new Button ();
			threeBtn.Text = "Name Coming Soon";
			threeBtn.TextColor = Color.Green;
			threeBtn.BackgroundColor = Color.Black;
			threeBtn.Clicked += (object sender, EventArgs e) => {
				//This button should change the table of matches to show only matches for this competition.
			};
			//Competition scroll
			ScrollView competitionList = new ScrollView ();
			competitionStack = new StackLayout ();
			competitionList.Content = competitionStack;

			//Match scroll
			ScrollView matchList = new ScrollView ();
			matchList.Content = matchStack;

			UpdateCompetitionList();

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

			//Back Button Navigation. Could be in the corner or on the bottom.
			Button backBtn = new Button ();
			backBtn.Text = "Back";
			backBtn.TextColor = Color.Green;
			backBtn.BackgroundColor = Color.Black;

			backBtn.Clicked += (object sender, EventArgs e) => {
				//return new NavigationPage (new MainMenuPage ());
			};

			BackgroundColor = Color.Green;

			//Page Layout
			this.Content = new StackLayout {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,

				Children = {
					competitionLabel,
					oneBtn,
					twoBtn,
					threeBtn,
					competitionList,
					matchList,
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

		async Task UpdateCompetitionList(){
			ParseQuery<ParseObject> query = ParseObject.GetQuery("CompetitionData");
			var allCompetitions = await query.FindAsync();
			competitionStack.Children.Clear();
			foreach (ParseObject obj in allCompetitions) {
				await obj.FetchAsync ();
				TeamListCell cell = new TeamListCell ();
				cell.teamName.Text = "Competition " + obj["name"];
				competitionStack.Children.Add (cell);
				TapGestureRecognizer tap = new TapGestureRecognizer ();
				tap.Tapped += (object sender, EventArgs e) => {
					//Navigation.PushModalAsync (new AddTeamPage (obj));
					ParseRelation<ParseObject> matchList = obj.GetRelation<ParseObject>("matches");
					ParseObject tempM = new ParseObject("RobotMatches");
					tempM["name"] = "testName";
					matchList.Add(tempM);
					obj.SaveAsync();
					UpdateMatchList(obj);
				};
				cell.GestureRecognizers.Add (tap);
			}
		}
		async Task UpdateMatchList(ParseObject competition){
			ParseRelation<ParseObject> matchList = competition.GetRelation<ParseObject>("matches");
			ParseQuery<ParseObject> query = matchList.Query;
			var allMatches = await query.FindAsync();
			matchStack.Children.Clear();
			foreach (ParseObject obj in allMatches) {
				await obj.FetchAsync ();
				TeamListCell cell = new TeamListCell ();
				cell.teamName.Text = "Match " + obj["name"];
				competitionStack.Children.Add (cell);
				TapGestureRecognizer tap = new TapGestureRecognizer ();
				tap.Tapped += (object sender, EventArgs e) => {
					//Navigation.PushModalAsync (new AddTeamPage (obj));
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

