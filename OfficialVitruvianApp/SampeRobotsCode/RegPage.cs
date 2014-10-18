using System;
using Xamarin.Forms;
using Parse; // Remeber to also add it to the Components folder under BOTH iOS and Andriod
using System.Threading.Tasks;

namespace Robots
{
	public class RegPage : ContentPage
	{
		public RegPage ()
		{
			//TODO: Add Entry for Username, Password, Email

			//TODO: Add button to call Register Fuction
			// Be sure to add RegButtonHandler to the CLICKED variable of the button, see example on WelcomePage

			//TODO: Create and new StackLayout

			//TODO: Add childern to StackLayout

			//TODO: Add Stack to Content
		}

		//Sample Button Function
		async void RegButtonHandler (string un, string ps, string em) {
			await RegUser (un, ps, em);
		}

		//Sample Parse Function 
		public async Task RegUser (string un, string ps, string em)
		{

			ParseUser user = new ParseUser ();
			user.Username = un;
			user.Password = ps;
			user.Email = em;

			// other fields can be set just like with ParseObject
			//user ["phone"] = "415-392-0202";

			try
			{
				await user.SignUpAsync ();
				Console.WriteLine ("Account Creation Success");
				// Login was successful.
				//TODO: Open up a new page
				//await Navigation.PushModalAsync (new NEWPAGENAME () );
			}
			catch (Exception e)
			{
				// The login failed. Check the error to see why.
				Console.WriteLine("Signup error: " + e.Message);
				DisplayAlert ("Error", e.Message, "OK", "Cancel");
			}


		}
	}
}

