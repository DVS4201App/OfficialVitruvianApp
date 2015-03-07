	using System;
using Xamarin.Forms;
using Parse;
using System.Threading.Tasks;

namespace OfficialVitruvianApp
{
	public class AnalyticsPage:ContentPage
	{
		public AnalyticsPage ()
		{
			Grid dataGrid = new Grid(){
				RowDefinitions = {
					new RowDefinition{Height = new GridLength(160, GridUnitType.Absolute)},
					new RowDefinition{Height = new GridLength(160, GridUnitType.Absolute)},
					new RowDefinition{Height = new GridLength(160, GridUnitType.Absolute)},
					new RowDefinition{Height = new GridLength(160, GridUnitType.Absolute)},
					new RowDefinition{Height = new GridLength(160, GridUnitType.Absolute)},
					new RowDefinition{Height = new GridLength(160, GridUnitType.Absolute)},
					new RowDefinition{Height = new GridLength(160, GridUnitType.Absolute)},
					new RowDefinition{Height = new GridLength(160, GridUnitType.Absolute)},
				},

				ColumnDefinitions = {
					new ColumnDefinition{Width = new GridLength(160, GridUnitType.Absolute)},
					new ColumnDefinition{Width = new GridLength(160, GridUnitType.Absolute)},
					new ColumnDefinition{Width = new GridLength(160, GridUnitType.Absolute)},
					new ColumnDefinition{Width = new GridLength(160, GridUnitType.Absolute)},
					new ColumnDefinition{Width = new GridLength(160, GridUnitType.Absolute)},
					new ColumnDefinition{Width = new GridLength(160, GridUnitType.Absolute)},
					new ColumnDefinition{Width = new GridLength(160, GridUnitType.Absolute)},
					new ColumnDefinition{Width = new GridLength(160, GridUnitType.Absolute)},
				}
			};

			Label[] black = new Label[32];
			Label[] white = new Label[32];

			for (int n = 0; n < 32; n++) {
				black[n] = new Label ();
				black[n].BackgroundColor = Color.Black;
				black[n].Text = "Black";
				black[n].TextColor = Color.White;
				white[n] = new Label ();
				white[n].BackgroundColor = Color.White;
				white[n].Text = "White";
				white[n].TextColor = Color.Black;
			}



			for (int i = 0; i < 4; i++) {
				for (int j = 0; j < 4; j++) {
					dataGrid.Children.Add (black[8*i+2*j], 2 * i, 2 * j);
					dataGrid.Children.Add (white[8*i+2*j], 2 * i+1, 2 * j);
					dataGrid.Children.Add (black[8*i+2*j+1], 2 * i+1, 2 * j+1);
					dataGrid.Children.Add (white[8*i+2*j+1], 2 * i, 2 * j+1);
				}
			}
				
			Grid layoutGrid = new Grid (){
				RowDefinitions={
					new RowDefinition{Height = new GridLength(1,GridUnitType.Auto)},
					new RowDefinition{Height = new GridLength(1,GridUnitType.Auto)},
				},
				ColumnDefinitions={
					new ColumnDefinition{Width = new GridLength(1,GridUnitType.Auto)},
					new ColumnDefinition{Width = new GridLength(1,GridUnitType.Auto)},
				}
			};

			Label[] green = new Label[7];
			Label[] blue = new Label[7];
			Label[] red = new Label[7];
			Label[] yellow = new Label[7];

			for (int n = 0; n < 7; n++) {
				green[n] = new Label ();
				green[n].BackgroundColor = Color.Green;
				green[n].Text = "Green";
				green[n].TextColor = Color.Blue;
				blue[n] = new Label ();
				blue[n].BackgroundColor = Color.Blue;
				blue[n].Text = "Blue";
				blue[n].TextColor = Color.Green;
				red[n] = new Label ();
				red[n].BackgroundColor = Color.Red;
				red[n].Text = "Red";
				red[n].TextColor = Color.Yellow;
				yellow[n] = new Label ();
				yellow[n].BackgroundColor = Color.Yellow;
				yellow[n].Text = "Yellow";
				yellow[n].TextColor = Color.Red;
			}

			StackLayout horizontalBar = new StackLayout (){
				Orientation = StackOrientation.Horizontal,

				Children = {
					green[0],blue[0],green[1],blue[1],green[2],blue[2],green[3],blue[3],green[4],blue[4],green[5],blue[5],green[6],blue[6],
				}
			};

			StackLayout verticalBar = new StackLayout () {
				Orientation = StackOrientation.Vertical,

				Children = {
					red[0],yellow[0],red[1],yellow[1],red[2],yellow[2],red[3],yellow[3],red[4],yellow[4],red[5],yellow[5],red[6],yellow[6],
				}
			};

			Label corner = new Label {
				Text = "Team No.",
				TextColor = Color.Green,
				BackgroundColor = Color.Black
			};

			ScrollView verticalScroll = new ScrollView () {
				Orientation = ScrollOrientation.Vertical,

				Content = layoutGrid
			};

			ScrollView horizontalScroll = new ScrollView (){
				Orientation = ScrollOrientation.Horizontal,

				Content = verticalScroll
			};

			ScrollView verticalIndex = new ScrollView () {
				Orientation = ScrollOrientation.Vertical,

				Content = dataGrid
			};

			ScrollView horizontalIndex = new ScrollView () {
				Orientation = ScrollOrientation.Horizontal,

				Content = verticalIndex
			};

			ContentView dataContent = new ContentView () {
				Content = horizontalIndex
			};

			layoutGrid.Children.Add (corner, 0, 0);
			layoutGrid.Children.Add (horizontalBar, 1, 0);
			layoutGrid.Children.Add (verticalBar, 0, 1);
			layoutGrid.Children.Add (dataContent, 1, 1);

			this.Content = horizontalScroll;
		}
	}
}

