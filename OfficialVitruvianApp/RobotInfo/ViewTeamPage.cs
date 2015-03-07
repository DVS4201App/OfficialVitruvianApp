using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Parse;
using System.Threading.Tasks;

namespace OfficialVitruvianApp
{
	public class ViewTeamPage:ContentPage
	{
		ParseObject data;

		public ViewTeamPage (ParseObject teamData)
		{
			Grid grid = new Grid () {
				//Padding = new Thickness(0,20,0,0), 
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,

				RowDefinitions = {
					new RowDefinition{ Height = new GridLength(160, GridUnitType.Absolute) },
					new RowDefinition{ Height = GridLength.Auto },
					new RowDefinition{ Height = new GridLength(40, GridUnitType.Star) }
				},
				ColumnDefinitions = {
					new ColumnDefinition{ Width = new GridLength(160, GridUnitType.Absolute) },
					new ColumnDefinition{ Width = GridLength.Auto }
				}
			};

			Image robotImage = new Image ();
			try {
				if (teamData ["robotImage"] != null) {
					ParseFile robotImageURL = (ParseFile)teamData ["robotImage"]; //Gets the image from parse and converts it to ParseFile

					//How to write this so caching actually works?
					robotImage.Source = new UriImageSource{
						Uri = robotImageURL.Url,
						CachingEnabled = true,
						CacheValidity = new TimeSpan(7,0,0,0) //Caches Images onto your device for a week
					};
				} else {}
			}
			catch {
				robotImage.Source = "Placeholder_image_placeholder.png";
			}
			robotImage.Aspect = Aspect.AspectFit; //Need better way to scale an image while keeping aspect ratio, but not overflowing everything else


			ListView teamInfo = new ListView ();

			Label teamNumber = new Label ();
			try {
				if (teamData ["teamNumber"] != null) {
					teamNumber.Text = teamData ["teamNumber"].ToString();
				} else {}
			}
			catch {
				teamNumber.Text = "<No Team Number>";
			}
			teamNumber.FontSize = (36);

			Label teamName = new Label ();
			try {
				if (teamData ["teamName"] != null) {
					teamName.Text = teamData ["teamName"].ToString();
				} else {} 
			} catch {
				teamName.Text = "<No Team Name>";
			}
			teamName.FontSize = (24);

			Label teamType = new Label ();
			try {
				if (teamData ["teamType"] != null) {
					teamType.Text = "Type: " + teamData ["teamType"].ToString();
				} else {}
			}
			catch {
				teamType.Text = "Team Type: <No Team Type>";
			}

			Label driveType = new Label ();
			try {
				if (teamData ["driveType"] != null) {
					driveType.Text = "Drive Type: " + teamData ["driveType"].ToString();
				} else {}
			}
			catch {
				driveType.Text = "Drive Type: <No Drive Type>";
			}
				
			Label toteOrientation = new Label ();
			try {
				if (teamData ["toteOrientation"] != null) {
					toteOrientation.Text = "Tote Orientation: " + teamData ["toteOrientation"].ToString();
				} else {}
			}
			catch {
				toteOrientation.Text = "Tote Orientation: <No Tote Orientation>";
			}

			Label canOrientation = new Label ();
			try {
				if (teamData ["canOrientation"] != null) {
					canOrientation.Text = "Can Orientation: " + teamData ["canOrientation"].ToString();
				} else {}
			}
			catch {
				canOrientation.Text = "Can Orientation: <No Can Orientation>";
			}

			data = teamData;

			//Refresh Button
			Button refreshBtn = new Button () {
				Text = "Refresh",
				TextColor = Color.Green,
				BackgroundColor = Color.Black
			};
			refreshBtn.Clicked += (object sender, EventArgs e) => {
				Navigation.PushModalAsync(new ViewTeamPage(teamData));
			};

			//Back Button
			Button backBtn = new Button () {
				Text = "Back",
				TextColor = Color.Green,
				BackgroundColor = Color.Black
			};

			backBtn.Clicked += (object sender, EventArgs e) => {
				Navigation.PushModalAsync(new RobotInfoPage());
			};

			StackLayout side = new StackLayout () {
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,

				Children = {
					teamNumber,
					teamName
				}
			};

			ScrollView scrollView = new ScrollView ();
			scrollView.HorizontalOptions = LayoutOptions.FillAndExpand;
			scrollView.VerticalOptions = LayoutOptions.FillAndExpand;
			scrollView.Content = new StackLayout () {

				Children = {
					teamType,
					driveType,
					toteOrientation,
					canOrientation
				}
			};

			StackLayout navigationBtns = new StackLayout () {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Horizontal,
				BackgroundColor = Color.Green,

				Children = {
					backBtn,
					refreshBtn
				}
			};

			StackLayout bottom = new StackLayout () {
				HorizontalOptions = LayoutOptions.FillAndExpand,

				Children = {
					navigationBtns
				}
			};

			grid.Children.Add (robotImage, 0, 0);
			grid.Children.Add (side, 1, 0);
			grid.Children.Add (scrollView, 0, 2, 1, 2);
			grid.Children.Add (bottom, 0, 2, 2, 3);

			this.Content = grid;
		}
	}
}

