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
				//This button should change the table of teams to show only teams attending this competition.
			};


			//Competition Two Button
			Button twoBtn = new Button ();
			twoBtn.Text = "Name Coming Soon";
			twoBtn.TextColor = Color.Green;
			twoBtn.BackgroundColor = Color.Black;
			twoBtn.Clicked += (object sender, EventArgs e) => {
				//This button should change the table of teams to show only teams attending this competition.
			};


			//Competition Three Button
			Button threeBtn = new Button ();
			threeBtn.Text = "Name Coming Soon";
			threeBtn.TextColor = Color.Green;
			threeBtn.BackgroundColor = Color.Black;
			threeBtn.Clicked += (object sender, EventArgs e) => {
				//This button should change the table of teams to show only teams attending this competition.
			};

			//Divider
			Label dividerLabel = new Label();
			dividerLabel.TextColor = Color.Green;
			dividerLabel.HorizontalOptions = LayoutOptions.Center;
			dividerLabel.Text = "-------------------------------------------";

			//Match Label
			Label matchesLabel = new Label();
			matchesLabel.TextColor = Color.Green;
			matchesLabel.HorizontalOptions = LayoutOptions.Center;
			matchesLabel.Text = "Matches:";

			//A table with a bunch of other teams that changes based on the selected competition.
			//TODO: add contentview page from view
			//TODO: add ot this after compiling with Dao.
			/*
			StackLayout matchStack = new StackLayout ();

			ScrollView matchScroll = new ScrollView ();
			matchList.content = matchStack;

			matchStack.Children.Add ();
			*/

			//Back Button Navigation. Could be in the corner or on the bottom.
			Button backBtn = new Button ();
			backBtn.Text = "Back";
			backBtn.TextColor = Color.Green;
			backBtn.BackgroundColor = Color.Black;
			backBtn.Clicked += (object sender, EventArgs e) => {
				Navigation.PopModalAsync();
			};

			//Page Layout
			StackLayout stack = new StackLayout ();
			stack.Padding = 20; //new Thickness (5, 10, 5, 10); Use this to control padding or spacing on the Left, Right, Top, Bottom
			stack.Spacing = 20;
			stack.Children.Add (oneBtn);
			stack.Children.Add (twoBtn);
			stack.Children.Add (threeBtn);
			//stack.Children.Add (blankTable);
			stack.Children.Add (backBtn);
			Content = stack;
		}
	}
}

