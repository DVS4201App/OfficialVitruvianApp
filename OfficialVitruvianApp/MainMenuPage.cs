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

			//Match Scouting Tab Navigation
			Button matchBtn = new Button ();
			matchBtn.Text = "Match Scouting";
			matchBtn.TextColor = Color.Green;
			matchBtn.BackgroundColor = Color.Black;
			matchBtn.Clicked += (object sender, EventArgs e) => {
				Navigation.PushModalAsync (new PreMatchDataPage ());
			};

			//Robot Info Tab Navigation
			Button infoBtn = new Button ();
			infoBtn.Text = "Robot Information";
			infoBtn.TextColor = Color.Green;
			infoBtn.BackgroundColor = Color.Black;
			infoBtn.Clicked += (object sender, EventArgs e) => {
				Navigation.PushModalAsync (new RobotInfoPage());
			};

			//Team Stats
			Button teamStatsBtn = new Button ();
			teamStatsBtn.Text = "Team Stats";
			teamStatsBtn.TextColor = Color.Green;
			teamStatsBtn.BackgroundColor = Color.Black;
			teamStatsBtn.Clicked += (object sender, EventArgs e) => {
				Navigation.PushModalAsync (new TeamStatsPage());
			};

			//Analytics Tab Navigation
			/*
			Button analyticsBtn = new Button ();
			analyticsBtn.Text = "Data Analyics";
			analyticsBtn.TextColor = Color.Green;
			analyticsBtn.BackgroundColor = Color.Black;
			analyticsBtn.Clicked += (object sender, EventArgs e) => {
				Navigation.PushModalAsync (new AnalyticsPage());
			};
			*/
			//Alliance Pick
			Button alliancePickBtn = new Button ();
			alliancePickBtn.Text = "Alliance Pick";
			alliancePickBtn.TextColor = Color.Green;
			alliancePickBtn.BackgroundColor = Color.Black;
			alliancePickBtn.Clicked += (object sender, EventArgs e) => {
				Navigation.PushModalAsync (new AlliancePick());
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
					teamStatsBtn,
					//analyticsBtn,
					alliancePickBtn,
					logoutBtn
				}
			};
		}
	}
}

