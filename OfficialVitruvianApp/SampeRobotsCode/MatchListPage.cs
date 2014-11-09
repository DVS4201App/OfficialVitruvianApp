using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Parse; // Remeber to also add it to the Components folder under BOTH iOS and Andriod
using System.Threading.Tasks;

namespace Robots
{
	public class MatchListPage : ContentPage
	{
		ListView listView;
		ObservableCollection<RobotMatch> matchData;

		ActivityIndicator busyIcon;

		class RobotMatch
		{
			public RobotMatch(int matchNumber, ParseObject data)
			{
				this.MatchNumber = matchNumber;
				this.MatchName = "Match #" + matchNumber.ToString();
				if(data != null) {
					this.CreatedDate = data.CreatedAt.ToString();
					this.Data = data;
				}
			}

			public int MatchNumber { private set; get; }

			public string MatchName { private set; get; }

			public string CreatedDate { private set; get; }

			public ParseObject Data { private set; get; }
		};


		public MatchListPage ()
		{
			Title = "Match List";
			busyIcon = new ActivityIndicator ();
			matchData = new ObservableCollection<RobotMatch> ();
			matchData.Add (new RobotMatch (1, null));
			matchData.Add (new RobotMatch (2, null));
			//This provides space between the iOS status bar and the rest of the page
			this.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);

			StackLayout stack = new StackLayout ();
			stack.Spacing = 5;

			listView = new ListView ();


			listView.ItemTapped += (sender, e) => {
				// do something with e.Item
				((ListView)sender).SelectedItem = null; // de-select the row
			};

			listView.ItemSelected += (sender, e) => {
				if (e.SelectedItem == null) {
					return; // don't do anything if we just de-selected the row
				}
				// do something with e.SelectedItem
				ParseObject ob = ((RobotMatch)e.SelectedItem).Data;
				Navigation.PushAsync (new InterfacePage (ob));
				((ListView)sender).SelectedItem = null; // de-select the row
			};


			DataTemplate template = new DataTemplate (typeof (RobotsCell));
			template.SetBinding (RobotsCell.TextProperty, "MatchName");
			template.SetBinding (RobotsCell.DetailProperty, "CreatedDate");
			//Dont need since SelectedItem == MatchData
			template.SetBinding (RobotsCell.CellParseDataProperty , "Data");

			listView.ItemTemplate = template;

			Button addMatchBtn = new Button ();
			addMatchBtn.Text = "New Match";
			addMatchBtn.TextColor = Color.White;
			addMatchBtn.BackgroundColor = Color.Fuschia;
			addMatchBtn.Clicked += (object sender, EventArgs e) => {
				busyIcon.IsVisible = true;
				busyIcon.IsRunning = true;
				AddNewMatch();
			};

			listView.ItemsSource = matchData;
			stack.Children.Add (busyIcon);
			stack.Children.Add (addMatchBtn);
			stack.Children.Add (listView);
			this.Content = stack;

		}

		async void AddNewMatch () {
			ParseQuery<ParseObject> query = ParseObject.GetQuery("RobotMatches");
			int matchesCount = await query.CountAsync();
			matchesCount++;
			ParseObject newMatch = new ParseObject("RobotMatches");
			newMatch["matchNumber"] = matchesCount;
			await newMatch.SaveAsync();
			await UpdateMatches ();
		}

		async Task UpdateMatches() {
			busyIcon.IsVisible = true;
			busyIcon.IsRunning = true;
			ParseQuery<ParseObject> query = ParseObject.GetQuery("RobotMatches");
			var allMatches = await query.FindAsync();
			matchData.Clear ();
			foreach (ParseObject obj in allMatches) {
				await obj.FetchAsync ();
				matchData.Add(new RobotMatch(obj.Get<int>("matchNumber"), obj));
			}
			busyIcon.IsVisible = false;
			busyIcon.IsRunning = false;
			//listView.ItemsSource = matchData;
		}
	}
}

