using System;
using Xamarin.Forms;
using Parse; 

namespace OfficialVitruvianApp
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			ParseClient.Initialize("df6eih4fo22hNaYhb5IB6jo5AUqE5XykXkezyAtk", "5mk9AEUsOfW8bjtNUu6fmxxvXpOgoHBifY6k8uBz");
			return new NavigationPage (new LoginPage());

			//ParseObject newTeam = new ParseObject("TeamData");
			//return new NavigationPage(new AddPitTeam(newTeam));
		}
	}
}

