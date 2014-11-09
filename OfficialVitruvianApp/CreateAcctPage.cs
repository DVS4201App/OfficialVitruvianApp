using System;
using Xamarin.Forms;
using Parse;
using System.Threading.Tasks;

namespace OfficialVitruvianApp
{
	public class CreateAcctPage : ContentPage
	{
		public CreateAcctPage ()
		{
			//Title
			Label acctLabel = new Label();
			acctLabel.TextColor = Color.Green;
			acctLabel.HorizontalOptions = LayoutOptions.Center;
			acctLabel.Text = "Create Account";

			//Title
			Label subLabel = new Label();
			subLabel.TextColor = Color.Green;
			subLabel.HorizontalOptions = LayoutOptions.Center;
			subLabel.Text = "Enter your desired info below.";

			//User Entry
			Entry userEntry = new Entry ();
			userEntry.BackgroundColor = Color.Green;
			userEntry.Placeholder = "Username";

			//Password Entry
			Entry passwordEntry = new Entry ();
			passwordEntry.IsPassword = true;
			passwordEntry.BackgroundColor = Color.Green;
			passwordEntry.Placeholder = "Password";

			//Email Entry
			Entry emailEntry = new Entry ();
			emailEntry.BackgroundColor = Color.Green;
			emailEntry.Placeholder = "Email Address";

			//Register Button
			Button regBtn = new Button ();
			regBtn.Text = "Register";
			regBtn.TextColor = Color.Black;
			regBtn.BackgroundColor = Color.Silver;
			regBtn.Clicked += (object sender, EventArgs e) => {
				RegButtonHandler (userEntry.Text, passwordEntry.Text, emailEntry.Text);
			};

			//Back Button
			Button backBtn = new Button ();
			backBtn.Text = "Back";
			backBtn.TextColor = Color.Black;
			backBtn.BackgroundColor = Color.Silver;
			backBtn.Clicked += (object sender, EventArgs e) => {
				Navigation.PopModalAsync();
			};

			//Page Layout
				StackLayout stack = new StackLayout ();
				stack.Padding = 20; //new Thickness (5, 10, 5, 10); Use this to control padding or spacing on the Left, Right, Top, Bottom
				stack.Spacing = 20;
				stack.Children.Add (acctLabel);
				stack.Children.Add (userEntry);
				stack.Children.Add (passwordEntry);
				stack.Children.Add (emailEntry);
				stack.Children.Add (regBtn);
				stack.Children.Add (backBtn);
				Content = stack;
		}

		//Button Function
		async void RegButtonHandler (string un, string ps, string em) {
			await RegUser (un, ps, em);
		}

		//Parse Function
		public async Task RegUser (string un, string ps, string em)
		{

			ParseUser user = new ParseUser ();
			user.Username = un;
			user.Password = ps;
			user.Email = em;

			try
			{
				await user.SignUpAsync ();
				await DisplayAlert("Signup Successful", "Account Created", "Ok");
				Console.WriteLine ("Account Creation Success");
				Navigation.PopModalAsync ();
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

