using System;
using Xamarin.Forms;
using Parse;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Media;
using System.IO;

namespace OfficialVitruvianApp
{
	public class RobotImagePage:ContentPage
	{
		ParseObject data;

		public RobotImagePage (ParseObject teamData)
		{
			Image robotImage = new Image ();
			robotImage.Source = (Uri)teamData ["robotImage"];

			//Back Button
			Button backBtn = new Button ();
			backBtn.Text = "Back";
			backBtn.TextColor = Color.Green;
			backBtn.BackgroundColor = Color.Black;

			backBtn.Clicked += (object sender, EventArgs e) => {
				Navigation.PushModalAsync(new AddPitTeam(teamData));
			};

			//Save Picture Button
			Button savePicBtn = new Button ();
			savePicBtn.Text = "Back";
			savePicBtn.TextColor = Color.Green;
			savePicBtn.BackgroundColor = Color.Black;

			savePicBtn.Clicked += (object sender, EventArgs e) => {
				//downloads the image to your device
			};

			StackLayout rowBtns = new StackLayout () {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Horizontal,
				Children = {
					backBtn,
					savePicBtn
				}
			};

			this.Content = new StackLayout(){
				Padding = new Thickness(0,10,0,0),
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,

				Children = {
					robotImage,
					rowBtns
				}
			};
		}
	}
}

