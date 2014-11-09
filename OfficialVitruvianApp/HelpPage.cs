using System;
using Xamarin.Forms;

namespace OfficialVitruvianApp{
	public class HelpPage:ContentPage{
		public HelpPage (){
			Label title = new Label {
				Text="Welcome",
				HorizontalOptions=LayoutOptions.Center
			};

			TableView tableView = new TableView {
				Intent = TableIntent.Form,
				Root = new TableRoot{
					new TableSection{
						new TextCell {
							//Text = "Welcome",
							Detail = "Welcome to Team 4201's Scouting App. To start, please register an account on the main login page and login to view data. Be aware that edits to robot data are restricted to specific accounts. Please contact one of the App developers for access."
						}
					}
				}
			};

			this.Content = new StackLayout{
				Children = {
					title,
					tableView
				}
			};
		}
	}
}

