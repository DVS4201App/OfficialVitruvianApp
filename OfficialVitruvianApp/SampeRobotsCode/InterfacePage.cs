using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Parse; // Remeber to also add it to the Components folder under BOTH iOS and Andriod
using System.Threading.Tasks;

namespace Robots
{
	public class InterfacePage : ContentPage
	{
		ParseObject data;
		Label infoLabel;

		public InterfacePage (ParseObject dataObj)
		{
			Title = "Match Data for #" + dataObj.Get<int>("matchNumber").ToString();
			data = dataObj;
			infoLabel = new Label ();
			StackLayout stack = new StackLayout ();

			Grid masterGrid = new Grid 
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				RowDefinitions = 
				{
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto }
				},
				ColumnDefinitions = 
				{
					//new ColumnDefinition { Width = new GridLength(120, GridUnitType.Absolute) },
					new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = GridLength.Auto }
				}
			};

			Button robotShot = new Button ();
			robotShot.Text = "Robot Shot";
			robotShot.TextColor = Color.White;
			robotShot.BackgroundColor = Color.Green;
			robotShot.WidthRequest = 120;
			robotShot.HeightRequest = 50;
			robotShot.Clicked += (object sender, EventArgs e) => {
				PostRobotShot();
			};
			masterGrid.Children.Add (robotShot, 0, 0);

			Button robotShot2 = new Button ();
			robotShot2.Text = "Robot Shot";
			robotShot2.TextColor = Color.White;
			robotShot2.BackgroundColor = Color.Red;
			robotShot2.WidthRequest = 120;
			robotShot2.HeightRequest = 50;
			robotShot2.Clicked += (object sender, EventArgs e) => {
				PostRobotShot();
			};
			masterGrid.Children.Add (robotShot2, 2, 3);

			stack.Children.Add (infoLabel);
			stack.Children.Add (masterGrid);

			UpdateDisplay ();

			Content = stack;
		}

		async void PostRobotShot () {
			if (data.ContainsKey ("ShotsFired")) {
				data.Increment ("ShotsFired");
				await data.SaveAsync ();
				UpdateDisplay ();
			} else {
				await PostIntData("ShotsFired", 1);
			}
		}

		async Task PostIntData (string key, int dataInput) {
			data[key] = dataInput;
			await data.SaveAsync();
			await DisplayAlert ("Data Inputed", "Posted: " + dataInput.ToString (), "OK");
			UpdateDisplay ();
		}

		void UpdateDisplay () {
			string allData = "|";
			foreach (string s in data.Keys) {
				allData += s + ": " + data.Get<int>(s) + "|";
			}
			infoLabel.Text = allData;
		}
	}
}

