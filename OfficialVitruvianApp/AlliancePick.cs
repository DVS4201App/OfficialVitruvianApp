using System;
using Parse;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace OfficialVitruvianApp
{
	public class AlliancePick:ContentPage
	{
		ParseObject data;

		StackLayout favoredList = new StackLayout (){
			VerticalOptions = LayoutOptions.FillAndExpand,
			HorizontalOptions = LayoutOptions.FillAndExpand
		};

		public AlliancePick ()
		{
			Label title = new Label () {
				Text = "Alliance Select",
				TextColor = Color.Green,
				BackgroundColor = Color.Black
			};
			title.FontSize = 18;

			//Team List
			ScrollView teamList = new ScrollView ();
			teamList.HorizontalOptions = LayoutOptions.CenterAndExpand;
			teamList.Content = favoredList;
			this.Appearing += (object sender, EventArgs e) => {
				UpdateTeamList(0);
			};

			Button backBtn = new Button ();
			backBtn.Text = "Back";
			backBtn.TextColor = Color.Green;
			backBtn.BackgroundColor = Color.Black;

			backBtn.Clicked += (object sender, EventArgs e) => {
				Navigation.PushModalAsync(new MainMenuPage());
			};

			//First Pick
			Button firstPickBtn = new Button () {
				Text = "First Pick",
				TextColor = Color.Green,
				BackgroundColor = Color.Black
			};
			firstPickBtn.Clicked += (object sender, EventArgs e) => {
				UpdateTeamList(1);
			};

			//Second Pick
			Button secondPickBtn = new Button () {
				Text = "Second Pick",
				TextColor = Color.Green,
				BackgroundColor = Color.Black
			};
			secondPickBtn.Clicked += (object sender, EventArgs e) => {
				UpdateTeamList(2);
			};

			StackLayout navigationBtns = new StackLayout () {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Horizontal,
				BackgroundColor = Color.Green,

				Children = {
					backBtn,
					firstPickBtn,
					secondPickBtn
				}
			};

			this.Content = new StackLayout(){
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,

				Children = {
					title,
					teamList,
					navigationBtns
				}
			};
		}

		async Task UpdateTeamList(int select){
			ParseQuery<ParseObject> query = ParseObject.GetQuery("TeamData");
			ParseQuery<ParseObject> sorted = query.OrderBy ("teamNumber");
			if (select == 1) {
				sorted = query.OrderBy ("firstPick");
			} else if (select == 2) {
				sorted = query.OrderBy ("secondPick");
			} else {
				sorted = query.OrderBy ("teamNumber");
			}

			var allTeams = await sorted.FindAsync();
			favoredList.Children.Clear();
			foreach (ParseObject obj in allTeams) {
				await obj.FetchAsync ();
				TeamListCell cell = new TeamListCell ();
				cell.teamName.Text = "Team " + obj["teamNumber"] + ": " + obj["firstPick"] + " - " + obj["secondPick"];
				if(Convert.ToBoolean(obj["pickSelect"]) == true){
					cell.teamName.TextColor = Color.Red;
				} else{
					cell.teamName.TextColor = Color.White;
				}

				data = obj;

				TapGestureRecognizer tap = new TapGestureRecognizer ();
				tap.Tapped += (object sender, EventArgs e) => {
					if(Convert.ToBoolean(obj["pickSelect"]) == false){
						cell.teamName.TextColor = Color.Red;
						obj["pickSelect"] = false;
						SaveData();
					} else{
						cell.teamName.TextColor = Color.White;
						obj["pickSelect"] = true;
						SaveData();
					}
				};

				favoredList.Children.Add (cell);

				cell.GestureRecognizers.Add (tap);
			}
		}
		async void SaveData(){
			Console.WriteLine ("Saving...");
			await data.SaveAsync ();
			Console.WriteLine ("Done Saving");
		}
	}
}

