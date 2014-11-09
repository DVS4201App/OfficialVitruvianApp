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
				Navigation.PushModalAsync (new RobotInfoPage ());
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
				
			//Admin Options Tab Navigation
			Button adminBtn = new Button ();
			adminBtn.Text = "Admin Hub";
			adminBtn.TextColor = Color.Green;
			adminBtn.BackgroundColor = Color.Black;
			adminBtn.Clicked += (object sender, EventArgs e) => {
				Navigation.PushModalAsync (new AdminOptionsPage ());
			};

			//Back Button Navigation
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
			stack.Children.Add (infoBtn);
			stack.Children.Add (scoutingBtn);
			stack.Children.Add (dataBtn);
			stack.Children.Add (adminBtn);
			stack.Children.Add (backBtn);
			Content = stack;

		}
	}
}

