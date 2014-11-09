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
			Button vitBtn = new Button () {
				Text = "Robot Information",
				TextColor = Color.Green,
				BackgroundColor = Color.Black
			};
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

			backBtn.Clicked += (object sender, EventArgs e) => {
				Navigation.PushModalAsync(new MainMenuPage());
			};

			StackLayout teamStack = new StackLayout ();

			ScrollView teamList = new ScrollView ();
			teamList.Content = teamStack;
			teamList.HeightRequest = 150;
			TeamListCell cell1 = new TeamListCell ();
			cell1.teamName.Text = "4201";
			TeamListCell cell2 = new TeamListCell ();
			cell2.teamName.Text = "4210";
			TeamListCell cell3 = new TeamListCell ();
			cell3.teamName.Text = "4000";
			TeamListCell cell4 = new TeamListCell ();
			cell4.teamName.Text = "4200";
			TeamListCell cell5 = new TeamListCell ();
			cell5.teamName.Text = "4205";
			teamStack.Children.Add (cell1);
			teamStack.Children.Add (cell2);
			teamStack.Children.Add (cell3);
			teamStack.Children.Add (cell4);
			teamStack.Children.Add (cell5);


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

			this.Content = new StackLayout {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,

				Children = {
					vitBtn,
					teamList,
					//modeBtn,
					//teamGrid,
					backBtn
				}
			};
		}
	}
}

