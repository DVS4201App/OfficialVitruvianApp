using System;
using Xamarin.Forms;
using Parse;
using System.Threading.Tasks;

namespace OfficialVitruvianApp
{
	public class AdminOptionsPage : ContentPage
	{
		public AdminOptionsPage ()
		{
			//Title
			Label title = new Label {
				Text = "Admin Options",
				HorizontalOptions = LayoutOptions.Center
			};
			//Edit Current Competitions

			//Add/remove teams from competitions

			//Add/remove matches from competitions

			//Add/remove teams from matches

			//Alter someone's clearance level

			//Revise someone's account info

			//Back Button
			Button backBtn = new Button {
				Text = "Back",
				TextColor = Color.Green,
				BackgroundColor = Color.Black
			};
			backBtn.Clicked += (object sender, EventArgs e) => {
					Navigation.PushModalAsync(new MainMenuPage());
			};

			this.Content = new StackLayout {
				Children = {
					title,
					backBtn
				}
			};
		}
	}
}

