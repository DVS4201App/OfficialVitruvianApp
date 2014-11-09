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
				//return new NavigationPage (new CompetitionOnePage ());
			};


			//Competition Two Button
			Button twoBtn = new Button ();
			twoBtn.Text = "Name Coming Soon";
			twoBtn.TextColor = Color.Green;
			twoBtn.BackgroundColor = Color.Black;
			twoBtn.Clicked += (object sender, EventArgs e) => {
				//return new NavigationPage (new CompetitionTwoPage ());
			};


			//Competition Three Button
			Button threeBtn = new Button ();
			threeBtn.Text = "Name Coming Soon";
			threeBtn.TextColor = Color.Green;
			threeBtn.BackgroundColor = Color.Black;

			threeBtn.Clicked += (object sender, EventArgs e) => {
				//return new NavigationPage (new CompetitionThreePage ());
			};


			//A table with a bunch of other teams that changes based on the selected competition.

			//Back Button Navigation. Could be in the corner or on the bottom.
			Button backBtn = new Button ();
			backBtn.Text = "Back";
			backBtn.TextColor = Color.Green;
			backBtn.BackgroundColor = Color.Black;

			backBtn.Clicked += (object sender, EventArgs e) => {
				//return new NavigationPage (new MainMenuPage ());
<<<<<<< Upstream, based on origin/master
			};
=======
			};
>>>>>>> c415c67 test

		}
	}
}

