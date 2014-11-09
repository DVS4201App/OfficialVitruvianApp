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
		StackLayout matchStack = new StackLayout ();

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

			ScrollView matchList = new ScrollView ();
			matchList.Content = matchStack;

			UpdateMatchList();

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
					matchList,
					backBtn
				}
			};
		}



		void SetupMatchList(){

		}
		async void AddNewMatch () {
			ParseQuery<ParseObject> query = ParseObject.GetQuery("MatchData");
			int matchCount = await query.CountAsync();
			matchCount++;
			ParseObject newMatch = new ParseObject("MatchData");
			newMatch["matchNumber"] = matchCount;
			await newMatch.SaveAsync();
			await UpdateMatchList ();
		}

		async Task UpdateMatchList(){
			ParseQuery<ParseObject> query = ParseObject.GetQuery("MatchData");
			var allMatches = await query.FindAsync();
			matchStack.Children.Clear();
			foreach (ParseObject obj in allMatches) {
				await obj.FetchAsync ();
				MatchListCell cell = new MatchListCell ();
				cell.matchName.Text = "Match " + obj["matchNumber"];
				matchStack.Children.Add (cell);
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

