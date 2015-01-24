using System;
using Xamarin.Forms;
using Parse;
using System.Threading.Tasks;

namespace OfficialVitruvianApp
{
	public class AddPitTeam:ContentPage
	{
		ParseObject data;

		public AddPitTeam (ParseObject teamData)
		{
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

			//How to make a drop-down list?
			//driveType

			Label pickupOrientationLabel = new Label () {
				Text = "Tote Pickup Orentation:"
			};

			//How to make a drop-down list?
			//pickupOrientation

			data = teamData;

			Button backBtn = new Button (){
				Text = "Back"
			};
			backBtn.Clicked += (object sender, EventArgs e) => {
				Navigation.PushModalAsync(new PitScoutingPage());
			};

			Button updateBtn = new Button(){Text = "Update"};
			updateBtn.Clicked += (object sender, EventArgs e) => {
				data ["teamNumber"] = int.Parse(teamNumber.Text);
				data ["teamName"] = teamName.Text;
				//data ["driveType"] = driveType.Text;
				//data ["toteOrientation"] = pickupOrientation.Text;
				SaveData ();
			};

			ScrollView scrollView = new ScrollView ();
			scrollView.HorizontalOptions = LayoutOptions.FillAndExpand;
			scrollView.VerticalOptions = LayoutOptions.FillAndExpand;
			scrollView.Content = new StackLayout () {

				Children = {
					teamNumberLabel,
					teamNumber,
					teamNameLabel,
					teamName,
					driveTypeLabel,
					//driveType,
					pickupOrientationLabel,
					//pickupOrientation,
					backBtn,
					updateBtn
				}
			};

			Content = scrollView;
		}
		async void SaveData(){
			Console.WriteLine ("Saving...");
			await data.SaveAsync ();
			Console.WriteLine ("Done Saving");
			Navigation.PopModalAsync ();
		}
	}
}

