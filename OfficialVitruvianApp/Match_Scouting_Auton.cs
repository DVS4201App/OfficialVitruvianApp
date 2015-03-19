using System;
using Parse;
using Xamarin.Forms;
using Xamarin;

namespace OfficialVitruvianApp
{
	public class Match_Scouting_Auton : ContentPage
	{
		ParseObject data;

		public Match_Scouting_Auton (ParseObject MatchData){
			int SumofPoints = 0; 

			Label TotalPoints = new Label ();
				
			int robotSetPushed = 0;
			int toteSetPushed = 0;
			int containerSetPushed = 0;
			int stackedToteSetPushed = 0;

			//Robot Set
			Button RobotSet = new Button();
			RobotSet.Text = "Robot Set";
			RobotSet.BackgroundColor = Color.Green;
			RobotSet.Clicked += (object sender, EventArgs e) => {
				if(robotSetPushed==0){
					robotSetPushed=1;
					//Like Teleop, these two lines can be put into a function and then brought out since they are repeated, so everytime you need to update, you can just call the funciton after changing the values, and it will update teh displayed values.
					//Also, consider having the button colors change if they are pressed for user feedback.
					//Note: I assume that both the toteSet and stackedToteSet are required to make a complete tote stack (as a tote stack is essentially a tote set in a stack), so the user must press both buttons in order to make a totestack.
					//		This is for easier math/programming on our end.
					SumofPoints = (robotSetPushed*4)+(containerSetPushed*8)+(toteSetPushed*6)+(stackedToteSetPushed*14);
					TotalPoints.Text = SumofPoints.ToString();
				} else {
					robotSetPushed=0;
					SumofPoints = (robotSetPushed*4)+(containerSetPushed*8)+(toteSetPushed*6)+(stackedToteSetPushed*14);
					TotalPoints.Text = SumofPoints.ToString();
				}
			};
				
			//Tote Set
			Button ToteSet = new Button ();
			ToteSet.Text = "Tote Set";
			ToteSet.BackgroundColor = Color.Green;
			ToteSet.Clicked += (object sender, EventArgs e) => {
				if(toteSetPushed==0){
					toteSetPushed=1;
					SumofPoints = (robotSetPushed*4)+(containerSetPushed*8)+(toteSetPushed*6)+(stackedToteSetPushed*14);
					TotalPoints.Text = SumofPoints.ToString();
				} else {
					toteSetPushed=0;
					SumofPoints = (robotSetPushed*4)+(containerSetPushed*8)+(toteSetPushed*6)+(stackedToteSetPushed*14);
					TotalPoints.Text = SumofPoints.ToString();
				}
			};

			//Container Set
			Button ContainerSet = new Button();
			ContainerSet.Text = "Container Set";
			ContainerSet.BackgroundColor = Color.Green;
			ContainerSet.Clicked += (object sender, EventArgs e) => {
				if(containerSetPushed==0){
					containerSetPushed=1;
					SumofPoints = (robotSetPushed*4)+(containerSetPushed*8)+(toteSetPushed*6)+(stackedToteSetPushed*14);
					TotalPoints.Text = SumofPoints.ToString();
				} else {
					containerSetPushed=0;
					SumofPoints = (robotSetPushed*4)+(containerSetPushed*8)+(toteSetPushed*6)+(stackedToteSetPushed*14);
					TotalPoints.Text = SumofPoints.ToString();
				}
			};

			//Stacked Tote Set
			Button StackedToteSet = new Button();
			StackedToteSet.Text = "Stacked Tote Set";
			StackedToteSet.BackgroundColor = Color.Green;
			StackedToteSet.Clicked += (object sender, EventArgs e) => {
				if(stackedToteSetPushed==0){
					stackedToteSetPushed=1;
					SumofPoints = (robotSetPushed*4)+(containerSetPushed*8)+(toteSetPushed*6)+(stackedToteSetPushed*14);
					TotalPoints.Text = SumofPoints.ToString();
				} else {
					stackedToteSetPushed=0;
					SumofPoints = (robotSetPushed*4)+(containerSetPushed*8)+(toteSetPushed*6)+(stackedToteSetPushed*14);
					TotalPoints.Text = SumofPoints.ToString();
				}
			};

//		
//			Button Undo = new Button();
//			Undo.Text = "Undo";

//			Undo.Clicked += (object sender, EventArgs e) => {
//
//			};
			data = MatchData;

			Button TeleopPage = new Button ();
			TeleopPage.Text = "Teleop";
			TeleopPage.BackgroundColor = Color.Yellow;
			TeleopPage.TextColor = Color.Black;
			TeleopPage.Clicked += (object sender, EventArgs e) => {
				SumofPoints = (robotSetPushed*4)+(containerSetPushed*8)+(toteSetPushed*6)+(stackedToteSetPushed*14);
				data["autoPoints"] = SumofPoints;
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
					TeleopPage
				}
			};
		}

		async void SaveData(){
			Console.WriteLine ("Saving...");
			await data.SaveAsync ();
			Console.WriteLine ("Done Saving");
		}
	}
}

