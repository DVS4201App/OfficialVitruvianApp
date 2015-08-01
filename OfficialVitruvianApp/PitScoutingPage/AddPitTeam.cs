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

		enum DriveType{None, Tank, Mechanum, Swerve, Omni, Slide, Holonomic, West_Coast, Other};
		enum ToteOrientation{None, Horizontal, Vertical, Both};
		enum CanOrientation{None, Upright, Tipped, Both};
		enum Choice{No, Yes};

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

			var imageTap = new TapGestureRecognizer ();
			imageTap.Tapped += (s, e) => {
				Console.WriteLine("Tapped");
				OpenPicker();
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
				robotImage.GestureRecognizers.Add (imageTap);
			}
			//robotImage.Aspect = Aspect.AspectFit; //Need better way to scale an image while keeping aspect ratio, but not overflowing everything else
			//robotImage.GestureRecognizers.Add (imageTap);

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

			Label robotWeightLabel = new Label(){
				Text = "RobotWeight:"
			};

			Entry robotWeight = new Entry (){
				Keyboard = Keyboard.Numeric
			};
			try {
				if (teamData ["robotWeight"] != null) {
					robotWeight.Text = teamData ["robotWeight"].ToString();
				} else {}
			}
			catch {
				robotWeight.Text = "0";
			}

			Label rampLabel = new Label () {
				Text = "Do you need a ramp?:"
			};

			Picker rampPicker = new Picker ();
			try {
				if (teamData ["ramp"] != null) {
					rampPicker.Title = teamData ["ramp"].ToString();
				} else {} 
			} catch {
				rampPicker.Title = "[Select an Option]";
			}
			for(Choice type=Choice.No; type<=Choice.Yes; type++){
				string stringValue = type.ToString();
				rampPicker.Items.Add(stringValue);
			}

			rampPicker.SelectedIndexChanged += (sender, args) => {
				Choice type = (Choice)rampPicker.SelectedIndex;
				string stringValue = type.ToString();
				rampPicker.Title = stringValue;

			};
				
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
					
			Label totePickupOrientationLabel = new Label () {
				Text = "Tote Pickup Orentation:"
			};

			Picker toteOrientationPicker = new Picker ();
			try {
				if (teamData ["toteOrientation"] != null) {
					toteOrientationPicker.Title = teamData ["toteOrientation"].ToString();
				} else {} 
			} catch {
				toteOrientationPicker.Title = "[Select Tote Orientation]";
			}

			for(ToteOrientation type=ToteOrientation.None; type<=ToteOrientation.Both; type++){
				string stringValue = type.ToString();
				toteOrientationPicker.Items.Add(stringValue);
			}

			toteOrientationPicker.SelectedIndexChanged += (sender, args) => {
				ToteOrientation type = (ToteOrientation)toteOrientationPicker.SelectedIndex;
				string stringValue = type.ToString();
				toteOrientationPicker.Title = stringValue;
			};

			Label canPickupOrientationLabel = new Label () {
				Text = "Can Pickup Orentation:"
			};

			Picker canOrientationPicker = new Picker ();
			try {
				if (teamData ["canOrientation"] != null) {
					canOrientationPicker.Title = teamData ["canOrientation"].ToString();
				} else {} 
			} catch {
				canOrientationPicker.Title = "[Select Can Orientation]";
			}

			for(CanOrientation type=CanOrientation.None; type<=CanOrientation.Both; type++){
				string stringValue = type.ToString();
				canOrientationPicker.Items.Add(stringValue);
			}

			canOrientationPicker.SelectedIndexChanged += (sender, args) => {
				CanOrientation type = (CanOrientation)canOrientationPicker.SelectedIndex;
				string stringValue = type.ToString();
				canOrientationPicker.Title = stringValue;
			};

			Label autoStrategyLabel = new Label () {
				Text = "Auto Strategy:"
			};

			Entry autoStrategy = new Entry ();
			try {
				if (teamData ["autoStrategy"] != null) {
					autoStrategy.Text = teamData ["autoStrategy"].ToString();
				} else {} 
			} catch {
				autoStrategy.Placeholder = "[Enter Auto Strategy]";
			}

			Label teleOpStrategyLabel = new Label () {
				Text = "TeleOp Strategy:"
			};

			Entry teleOpStrategy = new Entry ();
			try {
				if (teamData ["teleOpStrategy"] != null) {
					teleOpStrategy.Text = teamData ["teleOpStrategy"].ToString();
				} else {} 
			} catch {
				teleOpStrategy.Placeholder = "[Enter TeleOp Strategy]";
			}
				
			Label autoToteLabel = new Label () {
				Text = "Can you push a tote in Auto?:"
			};

			Picker autoTotePicker = new Picker ();
			try {
				if (teamData ["autoTote"] != null) {
					autoTotePicker.Title = teamData ["autoTote"].ToString();
				} else {} 
			} catch {
				autoTotePicker.Title = "[Select Option]";
			}

			for(Choice type=Choice.No; type<=Choice.Yes; type++){
				string stringValue = type.ToString();
				autoTotePicker.Items.Add(stringValue);
			}

			autoTotePicker.SelectedIndexChanged += (sender, args) => {
				Choice type = (Choice)autoTotePicker.SelectedIndex;
				string stringValue = type.ToString();
				autoTotePicker.Title = stringValue;
			};

			Label coopertitionTotesLabel= new Label () {
				Text = "Possible Co-Op Tote Stack:"
			}; 

			Entry coopertitionTotes = new Entry ();
			try {
				if (teamData ["coopertitionTotes"] != null) {
					coopertitionTotes.Text = teamData ["coopertitionTotes"].ToString();
				} else {} 
			} catch {
				coopertitionTotes.Text = "0";
			}
			coopertitionTotes.Keyboard = Keyboard.Numeric;

			Label notesLabel = new Label () {
				Text = "Additional Notes:"
			};

			//int test = teamData["pitScoutStatus"].ToString();

			Editor notes = new Editor ();
			try {
				if (teamData ["notes"] != null) {
					notes.Text = teamData ["notes"].ToString();
				} else {} 
			} catch {
				//notes.Text = test.ToString();
				notes.Text = "[Add notes]";
			}
			notes.HeightRequest = 100;
			
			data = teamData;

			Button backBtn = new Button (){
				Text = "Back"
			};
			backBtn.Clicked += (object sender, EventArgs e) => {
				Navigation.PushModalAsync(new PitScoutingPage());
			};

			Button updateBtn = new Button(){Text = "Update"};
			updateBtn.Clicked += (object sender, EventArgs e) => {
				//data ["robotImage"] = new ParseFile(robotImage);
				//data ["teamNumber"] = int.Parse(teamNumber.Text);

				data ["teamName"] = teamName.Text;
				data ["robotWeight"] = Convert.ToInt32(robotWeight.Text);

				if(rampPicker.Title != "[Select an Option]"){
					data ["ramp"] = rampPicker.Title;
				}
				if(drivePicker.Title != "[Select Drive Type]"){
					data ["driveType"] = drivePicker.Title;
				}
				if(toteOrientationPicker.Title != "[Select Tote Orientation]"){
					data ["toteOrientation"] = toteOrientationPicker.Title;
				}
				if(canOrientationPicker.Title != "[Select Can Orientation]"){
					data ["canOrientation"] = canOrientationPicker.Title;
				}
				if(autoStrategy.Text != "[Enter Auto Strategy]"){
					data ["autoStrategy"] = autoStrategy.Text;
				}
				if(teleOpStrategy.Text != "[Enter TeleOp Strategy]"){
					data ["teleOpStrategy"] = teleOpStrategy.Text;
				}
				if(autoTotePicker.Title != "[Select Option]"){
					data ["autoTote"] = autoTotePicker.Title;
				}
				data ["coopertitionTotes"] = Convert.ToInt32(coopertitionTotes.Text);
				data ["notes"] = notes.Text;

				SaveData (); 

				if( data.ContainsKey("ramp") == 
					data.ContainsKey("driveType") == 
					data.ContainsKey("toteOrientation") == 
					data.ContainsKey("canOrientation") ==
					data.ContainsKey("autoStrategy") ==
					data.ContainsKey("teleOpStrategy") ==
					data.ContainsKey("autoTote") ==
					true) 
				{
					data["pitScoutStatus"]=0;
				} else {
					data["pitScoutStatus"]=255;
				}
				SaveData();
			};

			Label keyboardPadding = new Label ();
			keyboardPadding.HeightRequest = 300;

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
					robotWeightLabel,
					robotWeight,
					rampLabel,
					rampPicker,
					driveTypeLabel,
					drivePicker,
					totePickupOrientationLabel,
					toteOrientationPicker,
					canPickupOrientationLabel,
					canOrientationPicker,
					autoStrategyLabel,
					autoStrategy,
					autoToteLabel,
					autoTotePicker,
					teleOpStrategyLabel,
					teleOpStrategy,
					coopertitionTotesLabel,
					coopertitionTotes,
					notesLabel,
					notes,
					backBtn,
					updateBtn,
					keyboardPadding
				}
			};

			grid.Children.Add (robotImage, 0, 0);
			grid.Children.Add (side, 1, 0);
			grid.Children.Add (bottom, 0, 2, 1, 2);

			this.Content = new ScrollView {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,

				Content = grid
			};
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
			//It works? Don't use gallery
			MediaPicker imagePicker = new MediaPicker(Forms.Context);
			try{
				Console.WriteLine(".25: ");
				MediaFile robotImagePath = await imagePicker.PickPhotoAsync();
				//Console.WriteLine(robotImagePath.Path);
				ParseFile temp = new ParseFile(data["teamNumber"].ToString()+".jpg", ImageToBinary(robotImagePath.Path));
				data["robotImage"] = temp;

				SaveData();
				await Navigation.PushModalAsync(new AddPitTeam(data));
			}
			catch{
				Console.WriteLine ("Error");
			}
		}

		async void SaveData(){
			Console.WriteLine ("Saving...");
			await data.SaveAsync ();
			Console.WriteLine ("Done Saving");
			await Navigation.PushModalAsync (new PitScoutingPage ());
		}
	}
}