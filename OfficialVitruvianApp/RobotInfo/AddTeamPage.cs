using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Parse; // Remeber to also add it to the Components folder under BOTH iOS and Andriod
using System.Threading.Tasks;

namespace OfficialVitruvianApp
{
	public class AddTeamPage:ContentPage
	{
		ParseObject data;

		public AddTeamPage (ParseObject teamData)
		{
			Entry teamNumber = new Entry ();
			try {
				if (teamData ["teamNumber"] != null) {
					teamNumber.Text = teamData ["teamNumber"].ToString();
				} else {
				}
			}
			catch {
				teamNumber.Placeholder = "Enter Team Number";
			}
		
			Entry teamName = new Entry ();
			try {if (teamData ["teamName"] != null) {
				teamName.Text = teamData ["teamName"].ToString();
					} else {
					} 
			} catch {
				teamName.Placeholder = "Enter Team Name";
			}

			Entry teamType = new Entry ();
			try {if (teamData ["teamType"] != null) {
				teamType.Text = teamData ["teamType"].ToString();
			} else {}
			} catch {
				teamType.Placeholder = "Enter Team Type";
			}

			data = teamData;

			Button updateBtn = new Button(){Text = "Update"};
			updateBtn.Clicked += (object sender, EventArgs e) => {
				data ["teamNumber"] = teamNumber.Text;
				data ["teamName"] = teamName.Text;
				data ["teamType"] = teamType.Text;
				SaveData ();
			};

			ScrollView scrollView = new ScrollView ();
			scrollView.HorizontalOptions = LayoutOptions.FillAndExpand;
			scrollView.VerticalOptions = LayoutOptions.FillAndExpand;

			scrollView.Content = new StackLayout () {

				Children = {
					teamNumber,
					teamName,
					teamType,
					updateBtn
				}
			};

			Content = scrollView;
		}
		async void SaveData(){
			Console.WriteLine ("Saving...");
			await data.SaveAsync ();
			Console.WriteLine ("DOne Saving");
			Navigation.PopModalAsync ();
		}
	}
}

