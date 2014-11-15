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
			ListView teamInfo = new ListView ();

			Label teamNumber = new Label ();
				try {
					if (teamData ["teamNumber"] != null) {
						teamNumber.Text = "Team Number: " + teamData ["teamNumber"].ToString();
					} else {}
				}
				catch {
					teamNumber.Text = "Team Number: <No Team Number>";
				}

			Label teamName = new Label ();
			try {
				if (teamData ["teamName"] != null) {
					teamName.Text = "Team Name: " + teamData ["teamName"].ToString();
				} else {} 
			} catch {
				teamName.Text = "Team Name: <No Team Name>";
			}

			Label teamType = new Label ();
			try {
				if (teamData ["teamType"] != null) {
					teamType.Text = "Type: " + teamData ["teamType"].ToString();
				} else {}
			}
			catch {
				teamType.Text = "Type: <No Team Type>";
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
				Navigation.PushModalAsync(new RobotInfoViewPage());
			};

			ScrollView scrollView = new ScrollView ();
			scrollView.HorizontalOptions = LayoutOptions.FillAndExpand;
			scrollView.VerticalOptions = LayoutOptions.FillAndExpand;
			scrollView.Content = new StackLayout () {

				Children = {
					teamNumber,
					teamName,
					teamType,
					refreshBtn,
					backBtn
				}
			};

			Content = scrollView;
		}
	}
}

