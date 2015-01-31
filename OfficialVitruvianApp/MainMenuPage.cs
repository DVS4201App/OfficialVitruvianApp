using System;
using Xamarin.Forms;
using Parse;
using System.Threading.Tasks;

namespace OfficialVitruvianApp
{
	public class MainMenuPage : ContentPage
	{
		public MainMenuPage ()
		{
			//Title
			Label menuLabel = new Label();
			menuLabel.TextColor = Color.Green;
			menuLabel.HorizontalOptions = LayoutOptions.Center;
			menuLabel.Text = "Main Menu";

			//Pit Scouting Navigation
			Button pitBtn = new Button ();
			pitBtn.Text = "Pit Scouting";
			pitBtn.TextColor = Color.Green;
			pitBtn.BackgroundColor = Color.Black;
			pitBtn.Clicked += (object sender, EventArgs e) => {
				Navigation.PushModalAsync (new PitScoutingPage ());
			};

			//Scouting Tab Navigation
			Button matchBtn = new Button ();
			matchBtn.Text = "Match Scouting";
			matchBtn.TextColor = Color.Green;
			matchBtn.BackgroundColor = Color.Black;
			matchBtn.Clicked += (object sender, EventArgs e) => {
				Navigation.PushModalAsync (new CompetitionSelectPage ());
			};

			//Robot Info Tab Navigation
			Button infoBtn = new Button ();
			infoBtn.Text = "Robot Information";
			infoBtn.TextColor = Color.Green;
			infoBtn.BackgroundColor = Color.Black;
			infoBtn.Clicked += (object sender, EventArgs e) => {
				Navigation.PushModalAsync (new RobotInfoPage());
			};

			//Back Button Navigation
			Button logoutBtn = new Button ();
			logoutBtn.Text = "Logout";
			logoutBtn.TextColor = Color.Green;
			logoutBtn.BackgroundColor = Color.Black;
			logoutBtn.Clicked += (object sender, EventArgs e) => {
				Navigation.PushModalAsync(new LoginPage ());
			};

			//Page Layout
			this.Content = new StackLayout (){
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Padding = 20, Spacing = 20, //new Thickness (5, 10, 5, 10); Use this to control padding or spacing on the Left, Right, Top, Bottom

				Children = {
					infoBtn,
					pitBtn,
					matchBtn,
					pitBtn,
					logoutBtn
				}
			};
		}
	}
}

