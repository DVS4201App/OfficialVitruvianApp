using System;
using Xamarin.Forms;
using Parse;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Media;
using System.IO;
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
				//Padding = new Thickness(0,20,0,0), 
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,

				RowDefinitions = {
					new RowDefinition{ Height = new GridLength(160, GridUnitType.Absolute) },
					new RowDefinition{ Height = GridLength.Auto }
				},
				ColumnDefinitions = {
					new ColumnDefinition{ Width = new GridLength(160, GridUnitType.Absolute) },
					new ColumnDefinition{ Width = GridLength.Auto }
				}
			};
					
			//ParseObject picObj = new ParseObject("Teams");
			//picObj.Add ("name", "robotImage");
			//ParseFile.imageFile = new ParseFile("robotImage.jpg");
			//picObj.Add ("imageFile", imageFile);
			//picObj.SaveAsync();


			var imageTap = new TapGestureRecognizer ();
			imageTap.Tapped += (s, e) => {
				Console.WriteLine("Tapped");
				OpenPicker();
				/*
				if(teamData["robotImage"] != null) {
					//Navigation.PushModalAsync(new RobotImagePage(teamData));
				} else {
					OpenPicker();
				}*/
			};


			Image robotImage = new Image ();
			try {
				if (teamData ["robotImage"] != null) {
					ParseFile robotImageURL = (ParseFile)teamData ["robotImage"]; //Gets the image from parse and converts it to ParseFile

					//How to write this so caching actually works?
					robotImage.Source = new UriImageSource{
						Uri = robotImageURL.Url,
						CachingEnabled = true,
						CacheValidity = new TimeSpan(4,0,0,0) //Caches Images onto your decvice for 4 days
					};
				} else {}
			}
			catch {
				robotImage.Source = "Placeholder_image_placeholder.png";
			}
			robotImage.Aspect = Aspect.AspectFit; //Need better way to scale an image while keeping aspect ratio, but not overflowing everything else
			robotImage.GestureRecognizers.Add (imageTap);

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
				orientationPicker.Title = "[Select Tote Pickup Orientation]";
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
				//data ["robotImage"] = new ParseFile(data["teamNumber"].ToString()+"1.jpg", ImageToBinary(test)); //???
				data ["teamNumber"] = int.Parse(teamNumber.Text);
				data ["teamName"] = teamName.Text;
				data ["driveType"] = drivePicker.Title;
				data ["toteOrientation"] = orientationPicker.Title;
				SaveData ();
			};

			StackLayout side = new StackLayout () {
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,

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

			grid.Children.Add (robotImage, 0, 0);
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

		public byte[] ImageToBinary(string imagePath)
		{
			FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
			byte[] buffer = new byte[fileStream.Length];
			fileStream.Read(buffer, 0, (int)fileStream.Length);
			fileStream.Close();
			return buffer;
		}

		async void OpenPicker(){
			MediaPicker imagePicker = new MediaPicker(Forms.Context);
			try{
				Console.WriteLine(".25: ");
				MediaFile robotImagePath = await imagePicker.PickPhotoAsync();
				Console.WriteLine(".5: ");
				ParseFile temp = new ParseFile(data["teamNumber"].ToString()+"1.jpg", ImageToBinary(robotImagePath.Path));
				data.Add("robotImage", temp);

				data.SaveAsync();
			}
			catch{
				Console.WriteLine ("Error");
			}
		}
	}
}