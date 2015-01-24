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
			Grid grid = new Grid () {
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,

				RowDefinitions = {
					new RowDefinition{ Height = GridLength.Auto },
					new RowDefinition{ Height = GridLength.Auto },
					new RowDefinition{ Height = GridLength.Auto },
					new RowDefinition{ Height = GridLength.Auto }
				},
				ColumnDefinitions = {
					new ColumnDefinition{ Width = GridLength.Auto },
					new ColumnDefinition{ Width = GridLength.Auto }
				}
			};

			Label imageTest = new Label {
				Text = "[Upload Image]",
				TextColor = Color.Black,
				BackgroundColor = Color.Green,
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center
			};

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

			StackLayout side = new StackLayout () {
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,

				Children = {
					teamNumberLabel,
					teamNumber,
					teamNameLabel,
					teamName
				}
			};

			StackLayout bottom = new StackLayout () {
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,

				Children = {
					driveTypeLabel,
					//driveType,
					pickupOrientationLabel,
					//pickupOrientaiton,
					backBtn,
					updateBtn
				}
			};
			grid.Children.Add (imageTest, 0, 0);
			grid.Children.Add (side, 1, 0);
			grid.Children.Add (bottom, 0, 2, 1, 2);

			this.Content = new StackLayout(){
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,

				Children = {
					grid
				}
			};
		}
		async void SaveData(){
			Console.WriteLine ("Saving...");
			await data.SaveAsync ();
			Console.WriteLine ("Done Saving");
			Navigation.PopModalAsync ();
		}
	}
}

