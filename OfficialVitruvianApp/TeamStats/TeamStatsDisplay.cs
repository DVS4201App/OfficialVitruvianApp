using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Parse;

namespace OfficialVitruvianApp
{
	public class TeamStatsDisplay:ContentPage
	{
		//ParseObject imageRetrieve = new ParseObject ("TeamData");
		ParseObject data;

		Image robotImage = new Image();
		int Z = 0;

		Label[] descriptionLabel = new Label[999];
		Label[] dataLabel = new Label[999];

		public TeamStatsDisplay (ParseObject stats)
		{
			string teamNo = stats ["teamNo"].ToString ();
			Label title = new Label {
				Text = teamNo + "'s Stats"
			};

			Title = title.Text;

			Grid grid = new Grid () {
				//Padding = new Thickness(0,20,0,0), 
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,

				RowDefinitions = {
					new RowDefinition{ Height = new GridLength(160, GridUnitType.Absolute) },
					new RowDefinition{ Height = GridLength.Auto },
					//new RowDefinition{ Height = new GridLength(40, GridUnitType.Star) }
				},
				ColumnDefinitions = {
					new ColumnDefinition{ Width = new GridLength(160, GridUnitType.Absolute) },
					new ColumnDefinition{ Width = GridLength.Auto }
				}
			};

			data = stats;

			imageRetrieval(Convert.ToInt16(teamNo));

			robotImage.Aspect = Aspect.AspectFit; //Need better way to scale an image while keeping aspect ratio, but not overflowing everything else

			listedItem ("Matches Counted:", "matchesCounted");
			listedItem ("Average Match Score:", "avgScore");
			listedItem ("Average Number of Cycles:", "avgCycle");
			listedItem ("Lowest Match Score:", "lowestScore");
			listedItem ("Highest Match Score:", "highestScore");
			listedItem ("Station Totes Stacked", "stationTotesStacked");
			listedItem ("Landfill Totes Stacked", "landfillTotesStacked");
			listedItem ("Auto Score Average (Total):", "totalAutoAvg");
			listedItem ("Auto Score Average (Non-Zero):", "positiveAutoAvg");
			listedItem ("Matches with at least 4 totes and a Can:", "goodStackCount");
			listedItem ("Step Can Pulls (Auto)", "autoStepCanPulls");
			listedItem ("Step Can Pulls (Teleop)", "teleopStepCanPulls");
			listedItem ("Cans Uprighted", "totalCansUprighted");
			listedItem ("Interference Count", "interferenceCount");
			//listedItem (

			Button backBtn = new Button (){
				Text = "Return to Main Menu"
			};
			backBtn.Clicked += (object sender, EventArgs e) => {
				Navigation.PushModalAsync(new MainMenuPage());
			};

			StackLayout side = new StackLayout () {
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,

				Children = {
					title
				}
			};

			StackLayout info = new StackLayout () {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
			};

			for(int i=0; i<Z; i++){
				info.Children.Add(descriptionLabel[i]);
				info.Children.Add (dataLabel [i]);
			}
			info.Children.Add (backBtn);

			grid.Children.Add (robotImage, 0, 0);
			grid.Children.Add (side, 1, 0);
			grid.Children.Add (info, 0, 2, 1, 2);

			this.Content = new ScrollView {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Content = grid
			};
		}

		void listedItem(string description, string parseString){
			descriptionLabel[Z] = new Label {
				Text = description,
				FontSize = 14,
				TextColor = Color.Green
			};
			dataLabel[Z] = new Label {
				Text = data [parseString].ToString()
			};

			Z++;
		}

		async void imageRetrieval(int teamNo){
			try{
				ParseQuery<ParseObject> query = ParseObject.GetQuery ("TeamData");
				query.Include ("teamNo");
				ParseQuery<ParseObject> filter = query.WhereEqualTo ("teamNo", teamNo);

				var selectedTeam = await filter.FindAsync();

				foreach (ParseObject obj in selectedTeam) {
					await obj.FetchAsync ();
					if (obj ["robotImage"].ToString () != null) {
						ParseFile robotImageURL = (ParseFile)obj ["robotImage"];

						robotImage.Source = new UriImageSource {
							Uri = robotImageURL.Url,
							CachingEnabled = true,
							CacheValidity = new TimeSpan (7, 0, 0, 0) //Caches Images onto your device for a week
						};
					}
				}
			}
			catch{
				robotImage.Source = "Placeholder_image_placeholder.png";
			}
		}
	}
}

