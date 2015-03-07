using System;
using Xamarin.Forms;
using Parse;

namespace OfficialVitruvianApp
{
	public class LoginPage:ContentPage
	{
		Entry username, password;

		async void LoginBtn (object sender, EventArgs ea){
			//Bypass
			Navigation.PushModalAsync (new MainMenuPage());

			//Error - Unknown: Argument cannot be null. Parameter name: cancel
			/*
			try{

				await ParseUser.LogInAsync (username.Text, password.Text);
				DisplayAlert("Successful Login", "Let's go", "Ok", "");
				Navigation.PushModalAsync (new MainMenuPage());
			}
			catch (Exception e){
				DisplayAlert ("Error", "Unknown: " + e.Message, "OK");
				Console.WriteLine (e.ToString());
			}
			*/
		}

		async void CreateAccountBtn(object sender, EventArgs ea){
			Navigation.PushModalAsync(new CreateAcctPage());
		}

		async void HelpPageBtn(object sender, EventArgs ea){
			Navigation.PushModalAsync (new HelpPage ());
		}

		public LoginPage(){
			Label usernameLabel = new Label{Text = "Username:"};
			usernameLabel.TextColor = Color.Black;
			usernameLabel.HorizontalOptions = LayoutOptions.CenterAndExpand;

			username = new Entry ();
			username.HorizontalOptions = LayoutOptions.FillAndExpand;
			username.TextColor = Color.Black;
			username.BackgroundColor = Color.Lime;
			username.Placeholder = "Username";

			Label passwordLabel = new Label {Text = "Password:"};
			passwordLabel.TextColor = Color.Black;
			passwordLabel.HorizontalOptions = LayoutOptions.CenterAndExpand;

			password = new Entry ();
			password.HorizontalOptions = LayoutOptions.FillAndExpand;
			password.IsPassword = true;
			password.BackgroundColor = Color.Lime;
			password.WidthRequest = 100;
			password.TextColor = Color.Black;
			password.Placeholder = "Password";


			Button login = new Button {Text = "Login"};
			login.HorizontalOptions = LayoutOptions.CenterAndExpand;
			login.TextColor = Color.Green;
			login.BackgroundColor = Color.Black;
			login.Clicked += LoginBtn;

			Button createAccount = new Button {Text = "Create Account"};
			createAccount.HorizontalOptions = LayoutOptions.CenterAndExpand;
			createAccount.TextColor = Color.Green;
			createAccount.BackgroundColor = Color.Black;
			createAccount.Clicked += CreateAccountBtn;

			Button helpPage = new Button { Text = "Help" };
			helpPage.HorizontalOptions = LayoutOptions.CenterAndExpand;
			helpPage.TextColor = Color.Green;
			helpPage.BackgroundColor = Color.Black;
			helpPage.Clicked +=HelpPageBtn;

			//BackgroundImage = "Background_Logo.png";
			BackgroundColor = Color.Green;

			this.Content = new StackLayout {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Padding = 1, Spacing = 15,

				Children = {
					usernameLabel,
					username,
					passwordLabel,
					password,
					login,
					createAccount,
					helpPage
				}
			};
		}
	}
}

