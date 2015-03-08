using System;
using Parse;
using Xamarin.Forms;
using Xamarin;

namespace OfficialVitruvianApp
{
	public class Match_Scouting_Auton : ContentPage
	{
		public Match_Scouting_Auton (ParseObject MatchData)
		{


			private var int SumofPoints = 0; //This is the "receiver" of the "commands"


			TextCell TotalPoints = new TextCell ();
			TotalPoints.Text = SumofPoints;

			//Robot Set

				Button RobotSet = new Button();
				RobotSet.Text = "Robot Set";
				RobotSet.Clicked += (object sender, EventArgs e) => {
					SumofPoints+=4
				};


			//Tote Set
			Button ToteSet = new Button();
			ToteSet.Text = "Tote Set";
			ToteSet.Clicked += (object sender, EventArgs e) => {
				SumofPoints+=6
			};
			//Container Set
			Button ContainerSet = new Button();
			ContainerSet.Text = "Container Set";
			ContainerSet.Clicked += (object sender, EventArgs e) => {
				SumofPoints+=8
			};

			//Stacked Tote Set
			Button StackedToteSet = new Button();
			StackedToteSet.Text = "Tote Set";
			StackedToteSet.Clicked += (object sender, EventArgs e) => {
				SumofPoints+=20
			};

		
			Button Undo = new Button();
			Undo.Text = "Undo";

//			Undo.Clicked += (object sender, EventArgs e) => {
//
//			};
//
			Button TeleopPage = new Button ();
			TeleopPage.Text = "Teleop";
			TeleopPage.Clicked += (object sender, EventArgs e) => {
				Navigation.PushModalAsync(new Match_Scouting(ParseObject MatchData)); 
			};
		}
	}
}

