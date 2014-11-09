using System;
using Xamarin.Forms;
using Parse;
using System.Threading.Tasks;

namespace OfficialVitruvianApp
{
	public class RawDataPage : ContentPage
	{
		public RawDataPage ()
		{
			//Access All Data Button
			Button dataBtn = new Button ();
			dataBtn.Text = "Pure Data Banks";
			dataBtn.TextColor = Color.Green;
			dataBtn.BackgroundColor = Color.Black;
			dataBtn.Clicked += (object sender, EventArgs e) => {
				Navigation.PushModalAsync (new 
			};

			//Access Graphs Button

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
			//stack.Children.Add (blankBtn);
			//stack.Children.Add (blankBtn);
			stack.Children.Add (backBtn);
			Content = stack;

		}
	}
}

