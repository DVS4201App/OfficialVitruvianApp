using System;
using Parse;
using Xamarin.Forms;
using Xamarin;

namespace OfficialVitruvianApp
{
	public class Match_Scouting_Auton : ContentPage
	{
		public Match_Scouting_Auton (ParseObject MatchData){
			int SumofPoints = 0; 

			Label TotalPoints = new Label ();
				
			//Robot Set

			Button RobotSet = new Button();
			RobotSet.Text = "Robot Set";
			RobotSet.BackgroundColor = Color.Green;
			RobotSet.Clicked += (object sender, EventArgs e) => {
				SumofPoints+=4;
				TotalPoints.Text = SumofPoints.ToString();
			};


			//Tote Set
			Button ToteSet = new Button ();
			ToteSet.Text = "Tote Set";
			ToteSet.BackgroundColor = Color.Green;
			ToteSet.Clicked += (object sender, EventArgs e) => {
				SumofPoints+=6;
				TotalPoints.Text = SumofPoints.ToString();
			};

			//Container Set
			Button ContainerSet = new Button();
			ContainerSet.Text = "Container Set";
			ContainerSet.BackgroundColor = Color.Green;
			ContainerSet.Clicked += (object sender, EventArgs e) => {
				SumofPoints+=8;
				TotalPoints.Text = SumofPoints.ToString();
			};

			//Stacked Tote Set
			Button StackedToteSet = new Button();
			StackedToteSet.Text = "Stacked Tote Set";
			StackedToteSet.BackgroundColor = Color.Green;
			StackedToteSet.Clicked += (object sender, EventArgs e) => {
				SumofPoints+=20;
				TotalPoints.Text = SumofPoints.ToString();
			};

//		
//			Button Undo = new Button();
//			Undo.Text = "Undo";

//			Undo.Clicked += (object sender, EventArgs e) => {
//
//			};




			Button TeleopPage = new Button ();
			TeleopPage.Text = "Teleop";
			TeleopPage.BackgroundColor = Color.Yellow;
			TeleopPage.TextColor = Color.Black;
			TeleopPage.Clicked += (object sender, EventArgs e) => {
				Navigation.PushModalAsync(new Match_Scouting_Teleop(MatchData)); 
			};

			this.Content = new StackLayout {
				Children = {
					TotalPoints,
					RobotSet,
					ToteSet,
					ContainerSet,
					StackedToteSet, 
					TeleopPage
				}
			};
		}
	}
}

