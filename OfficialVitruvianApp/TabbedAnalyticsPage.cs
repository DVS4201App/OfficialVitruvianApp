using System;
using Xamarin.Forms;
using Parse;
using System.Threading.Tasks;

namespace OfficialVitruvianApp
{
	public class TabbedAnalyticsPage:TabbedPage
	{
		public TabbedAnalyticsPage (ParseObject teamData)
		{
			this.Title = "Analytics Page";

			this.ItemsSource = new SortedData[]{
				/*
				new SortedData = ("Preferred First Pick", teamData["firstSort"]),
				new SortedData = ("Preferred Second Pick", teamData["secondSort"]),
				new SortedData = ("Highest Average Score", teamData["averageScore"]),
				*/
			};

			this.ItemTemplate = new DataTemplate (() => {
				return new SortedDataPage ();
			});
		}
	}

	class SortedData
	{
		public string Title { private set; get;}
		public ParseObject Data { private set; get; }

		public SortedData(string title, ParseObject data){
			this.Title = title;
			this.Data = data;
		}
	}

	class SortedDataPage:ContentPage
	{
		Grid dataStack = new Grid(){
			RowDefinitions = {
				new RowDefinition{Height = new GridLength(160, GridUnitType.Auto)},
				new RowDefinition{Height = new GridLength(160, GridUnitType.Auto)},
			},	
			ColumnDefinitions = {
				new ColumnDefinition{Width = new GridLength(160, GridUnitType.Auto)},
				new ColumnDefinition{Width = new GridLength(160, GridUnitType.Star)},
			}
		};

		StackLayout stack = new StackLayout(){
			HorizontalOptions = LayoutOptions.CenterAndExpand,
			VerticalOptions = LayoutOptions.FillAndExpand,

			Children = {
				dataStack
			}
		};

		public SortedDataPage(){
			this.SetBinding (ContentPage.TitleProperty, "Name");

			ScrollView dataScroll = new ScrollView {
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Content = stack
			};

			this.Appearing += (object sender, EventArgs e) => {
				UpdateDataList ();
			};

			this.Content = dataScroll;
		}

		async Task UpdateDataList(){
			ParseQuery<ParseObject> query = ParseObject.GetQuery("TeamData");
			//Orderby(Descending) dependent on data
			ParseQuery<ParseObject> sorted = query.OrderBy(string key); //change parseobj based on tab

			var allTeams = await sorted.FindAsync();
			dataStack.Children.Clear();
			int i = 0;
			foreach (ParseObject obj in allTeams) {
				await obj.FetchAsync ();
				TeamListCell cell = new TeamListCell ();
				cell.teamName.Text = "Team " + obj["teamNumber"];
				dataStack.Children.Add (cell,0, i);
				cell.dataCall.Text = obj [ParseObject]; //change parseobj based on tab
				dataStack.Children.Add (cell,1, i);
				i++;
			}
		}
	}
}

