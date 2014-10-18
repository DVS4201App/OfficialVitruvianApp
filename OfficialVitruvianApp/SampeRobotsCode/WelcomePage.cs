using System;
using Xamarin.Forms;
using Parse; // Remeber to also add it to the Components folder under BOTH iOS and Andriod
using System.Threading.Tasks;

namespace Robots
{
	public class WelcomePage : ContentPage
	{
		public WelcomePage ()
		{
			Title = "Welcome Page";

			//Sample Label
			Label loginLabel = new Label();
			loginLabel.HorizontalOptions = LayoutOptions.Center;
			loginLabel.Text = "Login Page";

			//Sample Entry Cell
			Entry loginEntry = new Entry ();
			loginEntry.Placeholder = "Username";

			//TODO: Add Password Entry
			Entry passwordEntry = new Entry ();
			passwordEntry.Placeholder = "Password";
			passwordEntry.IsPassword = true;

			//Sample button
			Button loginBtn = new Button ();
			loginBtn.Text = "Login";
			loginBtn.TextColor = Color.White;
			loginBtn.BackgroundColor = Color.Blue;
			loginBtn.Clicked += (object sender, EventArgs e) => {
				LoginButtonHandler(loginEntry.Text, /* need Password Entry here */ loginEntry.Text);
			};

			//TODO: Create Registration button
			//How to change scenes on btn press
//			regBtn.Clicked += (object sender, EventArgs e) => {
//				Navigation.PushModalAsync (new RegPage ());
//			};

			//Sample Layout Stack, Style Stack & Add to Stack
			StackLayout stack = new StackLayout ();
			stack.Padding = 20; //new Thickness (5, 10, 5, 10); Use this to control padding or spacing on the Left, Right, Top, Bottom
			stack.Spacing = 20;
			stack.Children.Add (loginLabel);
			stack.Children.Add (loginEntry);
			stack.Children.Add (passwordEntry);
			stack.Children.Add (loginBtn);
			//TODO: Add Password Field to stack

			//Sample Set Content
			Content = stack;
		}


		//Sample Button Function
		async void LoginButtonHandler (string un, string ps) {
			await LoginUser (un, ps);
		}

		//Sample Parse Function 
		public async Task LoginUser (string un, string ps)
		{

			try
			{
				await ParseUser.LogInAsync(un, ps);
				// Login was successful.
				DisplayAlert ("Login Successfull", "Lets get going", "OK");
				//TODO: Open up a new page
				await Navigation.PushModalAsync (new NavigationPage(new MatchListPage ()));
			}
			catch (Exception e)
			{
				Console.WriteLine ("Full Error: " + e.ToString());
				DisplayAlert ("Login Failed", e.Message.ToString(),"OK");
				// The login failed. Check the error to see why.
			}
				
		}

		public async Task RegUser (string un, string ps)
		{

			ParseUser user = new ParseUser ();
			user.Username = un;
			user.Password = ps;
			user.Email = "fazri@222fazri.com";

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

