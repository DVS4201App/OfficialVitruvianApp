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

			//Robot Info Tab Navigation
			Button infoBtn = new Button ();
			infoBtn.Text = "Robot Information";
			infoBtn.TextColor = Color.Green;
			infoBtn.BackgroundColor = Color.Black;
			infoBtn.Clicked += (object sender, EventArgs e) => {
				Navigation.PushModalAsync (new RobotInfoViewPage());
			};

			//Scouting Tab Navigation
			Button scoutingBtn = new Button ();
			scoutingBtn.Text = "Match Scouting";
			scoutingBtn.TextColor = Color.Green;
			scoutingBtn.BackgroundColor = Color.Black;
			scoutingBtn.Clicked += (object sender, EventArgs e) => {
				Navigation.PushModalAsync (new CompetitionSelectPage ());
			};

			//Raw Data Tab Navigation
			Button dataBtn = new Button ();
			dataBtn.Text = "Raw Data";
			dataBtn.TextColor = Color.Green;
			dataBtn.BackgroundColor = Color.Black;
			dataBtn.Clicked += (object sender, EventArgs e) => {
				Navigation.PushModalAsync (new RawDataPage ());
			};
				
			//Pit Scouting Navigation
			Button pitBtn = new Button ();
			pitBtn.Text = "Pit Scouting";
			pitBtn.TextColor = Color.Green;
			pitBtn.BackgroundColor = Color.Black;
			pitBtn.Clicked += (object sender, EventArgs e) => {
				Navigation.PushModalAsync (new PitScoutingPage ());
			};

			//Back Button Navigation
			Button backBtn = new Button ();
			backBtn.Text = "Logout";
			backBtn.TextColor = Color.Green;
			backBtn.BackgroundColor = Color.Black;
			backBtn.Clicked += (object sender, EventArgs e) => {
				Navigation.PushModalAsync(new LoginPage ());
			};

			//Page Layout
			this.Content = new StackLayout (){
				Padding = 20, Spacing = 20, //new Thickness (5, 10, 5, 10); Use this to control padding or spacing on the Left, Right, Top, Bottom

				Children = {
					infoBtn,
					scoutingBtn,
					dataBtn,
					pitBtn,
					backBtn
				}
			};
		}
	}
}

