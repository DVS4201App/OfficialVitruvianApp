using System;
using Parse;
using Xamarin.Forms;
using Xamarin;

namespace OfficialVitruvianApp
{
	public class Match_Scouting_Auton : ContentPage
	{
		ParseObject data;

		Label TotalPoints = new Label ();

		int SumofPoints = 0; 
		int robotSetPushed = 0;
		int toteSetPushed = 0;
		int containerSetPushed = 0;
		int stackedToteSetPushed = 0;

		public Match_Scouting_Auton (ParseObject MatchData){

			//Robot Set
			Button RobotSet = new Button();
			RobotSet.Text = "Robot Set";
			RobotSet.BackgroundColor = Color.Green;
			RobotSet.Clicked += (object sender, EventArgs e) => {
				if(robotSetPushed==0){
					robotSetPushed=1;
					UpdateValues();
				} else {
					robotSetPushed=0;
					UpdateValues();
				}
			};
				
			//Tote Set
			Button ToteSet = new Button ();
			ToteSet.Text = "Tote Set";
			ToteSet.BackgroundColor = Color.Green;
			ToteSet.Clicked += (object sender, EventArgs e) => {
				if(toteSetPushed==0){
					toteSetPushed=1;
					UpdateValues();
				} else {
					toteSetPushed=0;
					UpdateValues();
				}
			};

			//Container Set
			Button ContainerSet = new Button();
			ContainerSet.Text = "Container Set";
			ContainerSet.BackgroundColor = Color.Green;
			ContainerSet.Clicked += (object sender, EventArgs e) => {
				if(containerSetPushed==0){
					containerSetPushed=1;
					UpdateValues();
				} else {
					containerSetPushed=0;
					UpdateValues();
				}
			};

			//Stacked Tote Set
			Button StackedToteSet = new Button();
			StackedToteSet.Text = "Stacked Tote Set";
			StackedToteSet.BackgroundColor = Color.Green;
			StackedToteSet.Clicked += (object sender, EventArgs e) => {
				if(stackedToteSetPushed==0){
					stackedToteSetPushed=1;
					UpdateValues();
				} else {
					stackedToteSetPushed=0;
					UpdateValues();
				}
			};


			//Pull Can from Step
			Label autoCansLabel = new Label {
				Text = "Step Cans Pulled in Auto:"
			};

			Picker autoCans = new Picker();
			for(int i = 1; i<=5; i++){
				autoCans.Items.Add(Convert.ToString(i));
			}

			autoCans.SelectedIndexChanged += (sender, args) => {
				autoCans.Title = Convert.ToString(autoCans.SelectedIndex+1);
			};

			data = MatchData;

			Button TeleopPage = new Button ();
			TeleopPage.Text = "Teleop";
			TeleopPage.BackgroundColor = Color.Yellow;
			TeleopPage.TextColor = Color.Black;
			TeleopPage.Clicked += (object sender, EventArgs e) => {
				UpdateValues();
				data["autoPoints"] = SumofPoints;
				if(string.IsNullOrEmpty(autoCans.Title)==false){
					data["autoStepCanPulls"] = Convert.ToInt16(autoCans.Title);
				}
				SaveData();
				Navigation.PushModalAsync(new Match_Scouting_Teleop(MatchData)); 
			};

			this.Content = new StackLayout {
				Children = {
					TotalPoints,
					RobotSet,
					ToteSet,
					ContainerSet,
					StackedToteSet,
					autoCansLabel,
					autoCans,
					TeleopPage
				}
			};
		}

		async void SaveData(){
			Console.WriteLine ("Saving...");
			await data.SaveAsync ();
			Console.WriteLine ("Done Saving");
		}

		async void UpdateValues(){
			SumofPoints = (robotSetPushed*4)+(containerSetPushed*8)+(toteSetPushed*6)+(stackedToteSetPushed*14);
			TotalPoints.Text = SumofPoints.ToString();
		}
	}
}

