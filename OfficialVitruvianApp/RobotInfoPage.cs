using System;
using Xamarin.Forms;
using Parse;
using System.Threading.Tasks;

namespace OfficialVitruvianApp
{
	public class RobotInfoPage : ContentPage
	{
		public RobotInfoPage ()
		{
			//Team 4201 Button
			Button vitBtn = new Button ();
			vitBtn.Text = "Robot Information";
			vitBtn.TextColor = Color.Green;
			vitBtn.BackgroundColor = Color.Black;
			vitBtn.Clicked += (object sender, EventArgs e) => {
			//	Navigation.PushModalAsync (new OurRobotPage ());
			};

			//A button to toggle between looking at teams and adding data about teams
			//Code here

			//A button to look for teams based on categories
			//Code here

			//A table with a bunch of other teams
			//Code here

			//Back Button
			Button backBtn = new Button ();
			backBtn.Text = "Back";
			backBtn.TextColor = Color.Green;
			backBtn.BackgroundColor = Color.Black;
<<<<<<< Upstream, based on origin/master
			//backBtn.Clicked += (object sender, EventArgs e) => {
			//	return new NavigationPage (new MainMenuPage ());
			//};
=======
			backBtn.Clicked += (object sender, EventArgs e) => {
			//	Navigation.PushModalAsync (new MainMenuPage ());
			};
>>>>>>> 22928bf Main Menu Edits
		}
	}
}

