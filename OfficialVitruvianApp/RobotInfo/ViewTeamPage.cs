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
					new RowDefinition{ Height = GridLength.Auto },
					new RowDefinition{ Height = new GridLength(40, GridUnitType.Star) }
				},
				ColumnDefinitions = {
					new ColumnDefinition{ Width = new GridLength(160, GridUnitType.Absolute) },
					new ColumnDefinition{ Width = GridLength.Auto }
				}
			};

			Image robotImage = new Image();
			try {
				if (teamData ["robotImage"].ToString() != null) {
					ParseFile robotImageURL = (ParseFile)teamData ["robotImage"];
					//Gets the image from parse and converts it to ParseFile
					//robotImage.Source = "I"+teamData["teamNumber"]+".jpg"; //Must scale down images manually before upload, & all images must be .jpg
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
			//robotImage.GestureRecognizers.Add (imageTap);

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

			Label robotWeightLabel = new Label {
				Text = "Robot Weight:",
				TextColor = Color.Green,
				FontSize = 14
			};

			Label robotWeight = new Label ();
			try {
				if (teamData ["robotWeight"] != null) {
					robotWeight.Text = teamData ["robotWeight"].ToString();
				} else {}
			}
			catch {
				robotWeight.Text = "<No Data Recorded>";
			}

			Label rampLabel = new Label {
				Text = "Requires Ramp:",
				TextColor = Color.Green,
				FontSize = 14
			};

			Label ramp = new Label ();
			try {
				if (teamData ["ramp"] != null) {
					ramp.Text = teamData ["ramp"].ToString();
				} else {}
			}
			catch {
				ramp.Text = "<No Data Recorded";
			}

			Label driveTypeLabel = new Label {
				Text = "Drive Type:",
				TextColor = Color.Green,
				FontSize = 14
			};

			Label driveType = new Label ();
			try {
				if (teamData ["driveType"] != null) {
					driveType.Text = teamData ["driveType"].ToString();
				} else {}
			}
			catch {
				driveType.Text = "<No Data Recorded";
			}

			Label toteOrientationLabel = new Label {
				Text = "Tote Pickup Orientation:",
				TextColor = Color.Green,
				FontSize = 14
			};
				
			Label toteOrientation = new Label ();
			try {
				if (teamData ["toteOrientation"] != null) {
					toteOrientation.Text = teamData ["toteOrientation"].ToString();
				} else {}
			}
			catch {
				toteOrientation.Text = "<No Data Recoreded>";
			}

			Label canOrientationLabel = new Label {
				Text = "Can Pickup Orientation:",
				TextColor = Color.Green,
				FontSize = 14
			};

			Label canOrientation = new Label ();
			try {
				if (teamData ["canOrientation"] != null) {
					canOrientation.Text = teamData ["canOrientation"].ToString();
				} else {}
			}
			catch {
				canOrientation.Text = "<No Data Recorded>";
			}

			Label autoStrategyLabel = new Label {
				Text = "Auto Strategy:",
				TextColor = Color.Green,
				FontSize = 14
			};

			Label autoStrategy = new Label ();
			try {
				if (teamData ["autoStrategy"] != null) {
					autoStrategy.Text = teamData ["autoStrategy"].ToString();
				} else {}
			}
			catch {
				autoStrategy.Text = "<No Data Recorded>";
			}

			Label autoToteLabel = new Label {
				Text = "Able to push tote in Auto?:",
				TextColor = Color.Green,
				FontSize = 14
			};

			Label autoTote = new Label ();
			try {
				if (teamData ["autoTote"] != null) {
					autoTote.Text = teamData ["autoTote"].ToString();
				} else {}
			}
			catch {
				autoTote.Text = "<No Data Recorded>";
			}

			Label teleOpStrategyLabel = new Label {
				Text = "TeleOp Strategy:",
				TextColor = Color.Green,
				FontSize = 14
			};

			Label teleOpStrategy = new Label ();
			try {
				if (teamData ["teleOpStrategy"] != null) {
					teleOpStrategy.Text = teamData ["teleOpStrategy"].ToString();
				} else {}
			}
			catch {
				teleOpStrategy.Text = "<No Data Recorded>";
			}

			Label coopertitionTotesLabel = new Label {
				Text = "Number of Co-Op Totes they can stack:",
				TextColor = Color.Green,
				FontSize = 14
			};

			Label coopertitionTotes = new Label ();
			try {
				if (teamData ["coopertitionTotes"] != null) {
					coopertitionTotes.Text = teamData ["coopertitionTotes"].ToString();
				} else {}
			}
			catch {
				coopertitionTotes.Text = "<No Data Recorded>";
			}

			Label notesLabel = new Label {
				Text = "Additional Notes:",
				TextColor = Color.Green,
				FontSize = 14
			};

			Label notes = new Label ();
			try {
				if (teamData ["notes"] != null) {
					notes.Text = teamData ["notes"].ToString();
				} else {}
			}
			catch {
				notes.Text = "<No Data Recorded>";
			}

			data = teamData;

			/*
			Button viewStatsBtn = new Button {
				Text = "View Stats",
				TextColor = Color.Green,
				BackgroundColor= Color.Black
			};
			viewStatsBtn.Clicked += (object sender, EventArgs e) => {
				//Navigation.PushModalAsync(new TeamStatGenerator(Convert.ToInt32(teamData["teamNumber"].ToString())));
			};
			*/

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


			StackLayout info = new StackLayout () {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,

				Children = {
					robotWeightLabel,
					robotWeight,
					rampLabel,
					ramp,
					driveTypeLabel,
					driveType,
					toteOrientationLabel,
					toteOrientation,
					canOrientationLabel,
					canOrientation,
					autoStrategyLabel,
					autoStrategy,
					autoToteLabel,
					autoTote,
					teleOpStrategyLabel,
					teleOpStrategy,
					coopertitionTotesLabel,
					coopertitionTotes,
					notesLabel,
					notes
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
			grid.Children.Add (info, 0, 2, 1, 2);
			//grid.Children.Add (viewStatsBtn, 0, 2, 2, 3);
			grid.Children.Add (bottom, 0, 2, 3, 4);

			this.Content = new ScrollView {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,

				Content=grid
			};
		}
	}
}

