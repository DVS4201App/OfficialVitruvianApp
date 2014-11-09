using System;
using Xamarin.Forms;

namespace OfficialVitruvianApp
{
	public class TeamListCell:ContentView
	{
		public Label teamName;

		public TeamListCell ()
		{
			teamName = new Label ();
			WidthRequest = 100;
			HeightRequest = 50;

			Content = teamName;
		}
	}
}

