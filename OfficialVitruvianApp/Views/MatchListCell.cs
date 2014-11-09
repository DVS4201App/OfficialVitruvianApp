using System;
using Xamarin.Forms;

namespace OfficialVitruvianApp
{
	public class MatchListCell:ContentView
	{
		public Label matchName;

		public MatchListCell ()
		{
			matchName = new Label ();
			WidthRequest = 100;
			HeightRequest = 50;

			Content = matchName;
		}
	}
}

