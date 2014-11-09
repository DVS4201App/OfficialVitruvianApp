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

			//Access Graphs Button

			//Back Button
			Button backBtn = new Button ();
			backBtn.Text = "Back";
			backBtn.TextColor = Color.Green;
			backBtn.BackgroundColor = Color.Black;
			backBtn.Clicked += (object sender, EventArgs e) => {
				return new NavigationPage (new MainMenuPage ());
			};
		}
	}
}

