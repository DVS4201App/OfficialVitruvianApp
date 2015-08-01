using System;
using System.Threading.Tasks;
using Parse;
using Xamarin.Forms;

namespace OfficialVitruvianApp
{
	public class PostMatch_Scouting: ContentPage 
	{
		ParseObject data;

		enum Choice{No, Yes};
		
		public PostMatch_Scouting (ParseObject matchData)
		{
			int choiceValue = 0;

			Label interferenceLabel = new Label {
				Text = "Did the team interferece with their alliance members/stacks?",
				TextColor = Color.Green
			};

			Picker interferencePicker = new Picker();
			for(Choice type=Choice.No; type<=Choice.Yes; type++){
				string stringValue = type.ToString();
				interferencePicker.Items.Add(stringValue);
			}

			interferencePicker.SelectedIndexChanged += (sender, args) => {
				Choice type = (Choice)interferencePicker.SelectedIndex;
				choiceValue = interferencePicker.SelectedIndex;
				string stringValue = type.ToString();
				interferencePicker.Title = stringValue;
			};

			Label fieldLabel = new Label {
				Text = "Match comments/notes:",
				TextColor = Color.Green
			};

			Editor notes = new Editor{
				HeightRequest = 100,
				Text = "[notes]"
			};

			data = matchData;

			Button submit = new Button {
				Text = "Submit",
				TextColor = Color.Green,
				BackgroundColor = Color.Black
			};
			submit.Clicked += (object sender, EventArgs e) => {
				data["interferenceCount"]= choiceValue;
				data["matchNotes"] = notes.Text;
				SaveData();
				Navigation.PushModalAsync(new PreMatchDataPage());
			};

			Label keyboardPadding = new Label ();
			keyboardPadding.HeightRequest = 300;

			StackLayout stack = new StackLayout {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,

				Children = {
					interferenceLabel,
					interferencePicker,
					fieldLabel,
					notes,
					submit,
					keyboardPadding
				}
			};

			this.Content = new ScrollView {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,

				Content = stack
			};
		}

		async void SaveData(){
			Console.WriteLine ("Saving...");
			await data.SaveAsync ();
			Console.WriteLine ("Done Saving");
		}
	}
}

