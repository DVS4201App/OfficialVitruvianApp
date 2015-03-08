using System;
using Xamarin;
using Xamarin.Forms; 
using Parse; 

namespace OfficialVitruvianApp
{ 

	public class Match_Scouting : ContentPage

	{
		//Teleop Match Scouting
		public Match_Scouting (ParseObject MatchData)
		{
			int N=999, Z=0;
			int ToteButtonPushes = 0;	//Max. of 6
			int CanButtonPushes = 0;  //Max of 1
			int LitterButtonPushes = 0;
			int[] CyclePoints = new int[N]; 
			CyclePoints = new ParseObject();
			int totalScore = 0;
		

			//var myList = new ListView (); 
			//To do: Look into using Gridviews or RelativeLayout

			Label ToteCount = new Label(); //Tote Counter
			ToteCount.BackgroundColor = Color.White;
			ToteCount.TextColor = Color.Black;


			Button ToteButton = new Button();						//A +Tote Button for the "Stacking" cluster
			ToteButton.Text = "+ Tote";
			ToteButton.Clicked += (object sender, EventArgs e) => {
				if(ToteButtonPushes>=6){

				}
				else{
					ToteButtonPushes++;	//update number of pushes
					ToteCount.Text = ToteButtonPushes;   //Update ToteCounter Label
				}
			};




			Button CanButton = new Button ();  //A +Can Button for the "Stacking" cluster - need a way to make it limited to one can per cycle
			CanButton.Text = "+ Can";
			CanButton.Clicked +=(object sender, EventArgs e) =>{
				if (CanButtonPushes<=1)
				{
					CanButtonPushes++;
				}		

			};

			Label CanCount = new Label(); //Can Counter
			CanCount.Text = CanButtonPushes;
			CanCount.BackgroundColor = Color.White;
			CanCount.TextColor = Color.Black;


			Button LitterButton = new Button();
			LitterButton.Text = "+ Litter";
			LitterButton.Clicked += (object sender, EventArgs e) =>{
				if (LitterButtonPushes=0 && CanButtonPushes=1)
				LitterButtonPushes++;
			};

			Label LitterCount = new Label();
			LitterCount.Text = LitterButtonPushes;
			LitterCount.BackgroundColor = Color.White;
			LitterCount.TextColor = Color.Black;

			Label ToteStackPoints = new Label(); //displays points just from the Totestack
			ToteStackPoints.Text = CyclePoints; 

			Button ScoreResetToteStack = new Button();
			ScoreResetToteStack.Text = "Score and Reset";
			ScoreResetToteStack.Clicked += (object sender, EventArgs e)=>
			{
				CyclePoints[Z]+=(ToteButtonPushes*2)+(CanButtonPushes*((ToteButtonPushes*4)+(LitterButton*6)));
				Z++;

				//Reset Tote, Can, Litter Counters (of the individual totestack cluster)
				ToteCount = 0;
				CanCount = 0;
				LitterCount = 0;

			};


			Button CoopertitionSet = new Button();
			CoopertitionSet.Text = "Coopertition";
			CoopertitionSet.Clicked +=(object sender, EventArgs e) =>{
				CyclePoints+=20
			};
			Button CoopertitionStack = new Button();
			CoopertitionStack.Text = "Coopertition Stack";
			CoopertitionStack.Clicked +=(object sender, EventArgs e) =>{
				CyclePoints+=40
			};

			Button Disable = new Button();
			Disable.Text= "Robot Disabled";

			Button finishTeleop = new Button();
			finishTeleop.Text = "End Teleop";
			finishTeleop.BackgroundColor = Color.Red;
			finishTeleop.TextColor = Color.Black;

			finishTeleop.Clicked += (object sender, EventArgs e)=>
			{
				for(int i=0; i<Z; i++){
					totalScore+=CyclePoints[i];
				}
				MatchData ["CycleAmount"] = Z;
				MatchData ["TotalScore"] = totalScore;
				MatchData ["CycleData"] = CyclePoints;

			};


		}
//		StackLayout ToteStackBtns = new StackLayout{
	Padding = new Thickness(20,10,5,40); //left, top, right, bottom
//		StackOrientation ToteStackBtns = StackOrientation.Vertical;
//		Children = 
//			{   			
//			ToteButton, 
//			CanButton,
//			LitterButton		
//			}    
//		}

		Grid TeleopLayout = new Grid{
			VerticalOptions = LayoutOptions.FillAndExpand;
			ColumnDefinitions = {
				new ColumnDefinition{Height = 30},
				new ColumnDefinition{Height = 35},
				new ColumnDefinition{1, GridUnitType.Star},

			},
			RowDefinitions = {
			
			},

			Children{
				ToteButton,
				CanButton,
				LitterButton,
			}
		}	

	//
	}  
}



