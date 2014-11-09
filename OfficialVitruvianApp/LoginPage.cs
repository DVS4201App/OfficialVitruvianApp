using System;
using Xamarin.Forms;
using Parse;

namespace OfficialVitruvianApp
{
	public class LoginPage:ContentPage
	{
		Entry username, password;

		async void LoginBtn (object sender, EventArgs ea){
			try{
				await ParseUser.LogInAsync (username.Text, password.Text);
				DisplayAlert("Successful Login", "Let's go", "Ok", "");
				Navigation.PushModalAsync (new MainMenuPage());
			}
			catch (Exception e){
				DisplayAlert ("Error", "Unknown: " + e.Message, "OK");
				Console.WriteLine (e.ToString());
			}
		}

		async void CreateAccountBtn(object sender, EventArgs ea){
			Navigation.PushModalAsync(new CreateAcctPage());
		}

		async void HelpPageBtn(object sender, EventArgs ea){
			Navigation.PushModalAsync (new HelpPage ());
		}

		public LoginPage(){
			Label usernameLabel = new Label{Text = "Username:"};
			usernameLabel.TextColor = Color.White;
			usernameLabel.BackgroundColor = Color.Green;
			usernameLabel.HorizontalOptions = LayoutOptions.CenterAndExpand;
			usernameLabel.VerticalOptions = LayoutOptions.CenterAndExpand;

			username = new Entry ();
			username.BackgroundColor = Color.Gray;
			username.WidthRequest = 100;
			username.TextColor = Color.White;

			Label passwordLabel = new Label {Text = "Password:"};
			passwordLabel.TextColor = Color.White;
			passwordLabel.BackgroundColor = Color.Green;
			passwordLabel.HorizontalOptions = LayoutOptions.CenterAndExpand;
			passwordLabel.VerticalOptions = LayoutOptions.CenterAndExpand;

			password = new Entry ();
			password.IsPassword = true;
			password.BackgroundColor = Color.Gray;
			password.WidthRequest = 100;
			password.TextColor = Color.White;

			Button login = new Button {Text = "Login"};
			login.BackgroundColor = Color.Gray;
			login.Clicked += LoginBtn;

			Button createAccount = new Button {Text = "Create Account"};
			createAccount.BackgroundColor = Color.Gray;
			createAccount.Clicked += CreateAccountBtn;

			Button helpPage = new Button { Text = "Help" };
			helpPage.BackgroundColor = Color.Red;
			helpPage.Clicked +=HelpPageBtn;

			//BackgroundImage = "Background_Logo.png";

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

