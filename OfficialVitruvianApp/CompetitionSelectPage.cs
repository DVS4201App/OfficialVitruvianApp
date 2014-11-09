using System;
using Xamarin.Forms;
using Parse;
using System.Threading.Tasks;

namespace OfficialVitruvianApp
{
	public class CompetitionSelectPage : ContentPage
	{
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


			//A table with a bunch of other matches that changes based on the selected competition.
			StackLayout matchStack = new StackLayout ();

			ScrollView matchList = new ScrollView ();
			matchList.Content = matchStack;
			matchList.HeightRequest = 150;
			MatchListCell cell1 = new MatchListCell ();
			cell1.matchName.Text = "1";
			MatchListCell cell2 = new MatchListCell ();
			cell2.matchName.Text = "2";
			MatchListCell cell3 = new MatchListCell ();
			cell3.matchName.Text = "3";
			MatchListCell cell4 = new MatchListCell ();
			cell4.matchName.Text = "4";
			MatchListCell cell5 = new MatchListCell ();
			cell5.matchName.Text = "5";
			matchStack.Children.Add (cell1);
			matchStack.Children.Add (cell2);
			matchStack.Children.Add (cell3);
			matchStack.Children.Add (cell4);
			matchStack.Children.Add (cell5);

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
	}
}

