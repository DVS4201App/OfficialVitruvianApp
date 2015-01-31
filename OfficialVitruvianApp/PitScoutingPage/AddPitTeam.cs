using System;
using Xamarin.Forms;
using Parse;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OfficialVitruvianApp
{
	public class AddPitTeam:ContentPage
	{
		ParseObject data;

		enum DriveType{None, Tank, Mechanum, Swerve, Omni, Slide, Holonomic, Other};
		enum ToteOrientation{None, Horizontal, Vertical, Both};

		public AddPitTeam (ParseObject teamData)
		{
			Grid grid = new Grid () {
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,

				RowDefinitions = {
					new RowDefinition{ Height = GridLength.Auto },
					new RowDefinition{ Height = GridLength.Auto }
				},
				ColumnDefinitions = {
					new ColumnDefinition{ Width = GridLength.Auto },
					new ColumnDefinition{ Width = GridLength.Auto }
				}
			};

			Label teamImage = new Label {
				Text = "[Upload Image]",
				TextColor = Color.Black,
				BackgroundColor = Color.Green,
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center
			};

			//Test code (Not working):
			/*
			Button teamImage = new Button ();
			teamImage.BackgroundColor = Color.Transparent;
			teamImage.Image = "Placeholder_image_placeholder.png";			
			teamImage.ScaleTo (scale, 1, null);
			/*
			try {
				if (teamImage ["teamImage"] != null) {
					teamImage.Image = teamData ["teamImage"];
				} else {}
			}
			catch {
				teamImage.Source = ImageSource.FromResource("placeholder_image_placeholder.png");
			}
			teamImage.Clicked += (object sender, EventArgs e) => {
				//Upload an image or take a picture
			};

			};*/

			Label teamNumberLabel = new Label(){
				Text = "Team Number:"
			};
	
			Entry teamNumber = new Entry (){
				Keyboard = Keyboard.Numeric
			};
			try {
				if (teamData ["teamNumber"] != null) {
					teamNumber.Text = teamData ["teamNumber"].ToString();
				} else {}
			}
			catch {
				teamNumber.Placeholder = "[Enter Team Number]";
			}

			Label teamNameLabel = new Label () {
				Text = "Team Name:"
			};

			Entry teamName = new Entry ();
			try {
				if (teamData ["teamName"] != null) {
					teamName.Text = teamData ["teamName"].ToString();
				} else {} 
			} catch {
				teamName.Placeholder = "[Enter Team Name]";
			}

			Label driveTypeLabel = new Label () {
				Text = "Drive Type:"
			};

			Picker drivePicker = new Picker ();
			try {
				if (teamData ["driveType"] != null) {
					drivePicker.Title = teamData ["driveType"].ToString();
				} else {} 
			} catch {
				drivePicker.Title = "[Select Drive Type]";
			}

			for(DriveType type=DriveType.None; type<=DriveType.Other; type++){
				string stringValue = type.ToString();
				drivePicker.Items.Add(stringValue);
			}

			drivePicker.SelectedIndexChanged += (sender, args) => {
				DriveType type = (DriveType)drivePicker.SelectedIndex;
				string stringValue = type.ToString();
				drivePicker.Title = stringValue;
			};
					
			Label pickupOrientationLabel = new Label () {
				Text = "Tote Pickup Orentation:"
			};

			Picker orientationPicker = new Picker ();
			try {
				if (teamData ["toteOrientation"] != null) {
					orientationPicker.Title = teamData ["toteOrientation"].ToString();
				} else {} 
			} catch {
				drivePicker.Title = "[Select Tote Pickup Orientation]";
			}

			for(ToteOrientation type=ToteOrientation.None; type<=ToteOrientation.Both; type++){
				string stringValue = type.ToString();
				orientationPicker.Items.Add(stringValue);
			}

			orientationPicker.SelectedIndexChanged += (sender, args) => {
				ToteOrientation type = (ToteOrientation)orientationPicker.SelectedIndex;
				string stringValue = type.ToString();
				orientationPicker.Title = stringValue;
			};

			data = teamData;

			Button backBtn = new Button (){
				Text = "Back"
			};
			backBtn.Clicked += (object sender, EventArgs e) => {
				Navigation.PushModalAsync(new PitScoutingPage());
			};

			Button updateBtn = new Button(){Text = "Update"};
			updateBtn.Clicked += (object sender, EventArgs e) => {
				//data ["teamImage"] = ???
				data ["teamNumber"] = int.Parse(teamNumber.Text);
				data ["teamName"] = teamName.Text;
				data ["driveType"] = drivePicker.Title;
				data ["toteOrientation"] = orientationPicker.Title;
				SaveData ();
			};

			StackLayout side = new StackLayout () {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,

				Children = {
					teamNumberLabel,
					teamNumber,
					teamNameLabel,
					teamName
				}
			};

			StackLayout bottom = new StackLayout () {
				HorizontalOptions = LayoutOptions.FillAndExpand,

				Children = {
					driveTypeLabel,
					drivePicker,
					pickupOrientationLabel,
					orientationPicker,
					backBtn,
					updateBtn
				}
			};
			grid.Children.Add (teamImage, 0, 0);
			grid.Children.Add (side, 1, 0);
			grid.Children.Add (bottom, 0, 2, 1, 2);

			this.Content = grid;
		}
		async void SaveData(){
			Console.WriteLine ("Saving...");
			await data.SaveAsync ();
			Console.WriteLine ("Done Saving");
			Navigation.PopModalAsync ();
		}
	}
}