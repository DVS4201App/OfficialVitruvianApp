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
			Label optionLabel = new Label();
			optionLabel.HorizontalOptions = LayoutOptions.Center;
			optionLabel.Text = "Admin Hub";

			//Edit Current Competitions
			//Code here

			//Add/remove teams from competitions
			//Code here

			//Add/remove matches from competitions
			//Code here

			//Add/remove teams from matches
			//Code here

			//Alter someone's clearance level
			//Code here

			//Revise someone's account info
			//Code here

			//Back Button
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
			stack.Children.Add (optionLabel);
			//stack.Children.Add (blankBtn);
			//stack.Children.Add (blankBtn);
			//stack.Children.Add (blankBtn);
			//stack.Children.Add (blankBtn);
			//stack.Children.Add (blankBtn);
			//stack.Children.Add (blankBtn);
			stack.Children.Add (backBtn);
			Content = stack;
		}
	}
}

