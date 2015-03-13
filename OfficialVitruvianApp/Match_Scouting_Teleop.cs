using System;
//using Xamarin;
using Xamarin.Forms; 
using Parse; 

namespace OfficialVitruvianApp
{ 

	public class Match_Scouting_Teleop : ContentPage
	{
		ParseObject data;

		public Match_Scouting_Teleop (ParseObject MatchData)
		{
			int N = 99, Z = 0; //N is the maximum number of points, Z is which cycle the user is currently on.
			int ToteButtonPushes = 0;	//Max. of 6
			int CanButtonPushes = 0;  //Max of 1
			int LitterButtonPushes = 0;
			int[] CyclePoints = new int[N]; 
			int currentCyclePoints = 0; //label is Totestackpoints
			int totalScore = 0;
			int CoopertitionSetPushes = 0;
			int CoopertitionStackPushes = 0;
		    bool CoopertitionStackButtonClicked = false;
			bool CoopertitionSetButtonClicked = false;
		
			Label ToteStack = new Label ();
			ToteStack.Text = "Stacking Totes";
			ToteStack.BackgroundColor = Color.Black;
			ToteStack.TextColor = Color.Green;

			Label ToteCount = new Label (); //Tote Counter
			ToteCount.BackgroundColor = Color.White;
			ToteCount.TextColor = Color.Black; 

			
			Label ToteStackPoints = new Label (); //displays points just from the Totestack



			Button ToteButton = new Button ();						//A +Tote Button for the "Stacking" cluster
			ToteButton.Text = "+ Tote";
			ToteButton.Clicked += (object sender, EventArgs e) => {
				if (ToteButtonPushes < 6) { 
					ToteButtonPushes++; 
					currentCyclePoints = (ToteButtonPushes * 2) + (CanButtonPushes * ((ToteButtonPushes * 4) + (LitterButtonPushes * 6))) + (CoopertitionSetPushes*20) 
						+ (CoopertitionStackPushes*40); 
					ToteCount.Text = Convert.ToString (ToteButtonPushes.ToString ());  
					ToteStackPoints.Text = Convert.ToString (currentCyclePoints.ToString ()); 
				} 
				else {

				}
			};

			Label CanCount = new Label (); //Can Counter 
			CanCount.BackgroundColor = Color.White;
			CanCount.TextColor = Color.Black;

			Button CanButton = new Button ();  //A +Can Button for the "Stacking" cluster - need a way to make it limited to one can per cycle
			CanButton.Text = "+ Can";
			CanButton.Clicked += (object sender, EventArgs e) => {
				if (CanButtonPushes==0) {
					CanButtonPushes++;
					currentCyclePoints = (ToteButtonPushes * 2) + (CanButtonPushes * ((ToteButtonPushes * 4) + (LitterButtonPushes * 6))) + (CoopertitionSetPushes*20) 
						+ (CoopertitionStackPushes*40); 
					ToteStackPoints.Text = Convert.ToString (currentCyclePoints.ToString ()); 
					CanCount.Text = Convert.ToString (CanButtonPushes.ToString ()); 
				} else {
					CanButtonPushes--;
					currentCyclePoints = (ToteButtonPushes * 2) + (CanButtonPushes * ((ToteButtonPushes * 4) + (LitterButtonPushes * 6))) + (CoopertitionSetPushes*20) 
						+ (CoopertitionStackPushes*40); 
					ToteStackPoints.Text = Convert.ToString (currentCyclePoints.ToString ()); 
					CanCount.Text = Convert.ToString (CanButtonPushes.ToString ()); 
				}
			};

		
			Label LitterCount = new Label ();		
			LitterCount.BackgroundColor = Color.White;
			LitterCount.TextColor = Color.Black;

			Button LitterButton = new Button ();
			LitterButton.Text = "+ Litter";
			LitterButton.Clicked += (object sender, EventArgs e) => {
				if (LitterButtonPushes == 0 && CanButtonPushes == 1) {
					LitterButtonPushes++;
					currentCyclePoints = (ToteButtonPushes * 2) + (CanButtonPushes * ((ToteButtonPushes * 4) + (LitterButtonPushes * 6))) + (CoopertitionSetPushes*20) 
						+ (CoopertitionStackPushes*40); 
					ToteStackPoints.Text = Convert.ToString (currentCyclePoints.ToString ()); 
					LitterCount.Text = LitterButtonPushes.ToString ();
				} else if(LitterButtonPushes == 1 && CanButtonPushes == 1){
					LitterButtonPushes--;
					currentCyclePoints = (ToteButtonPushes * 2) + (CanButtonPushes * ((ToteButtonPushes * 4) + (LitterButtonPushes * 6))) + (CoopertitionSetPushes*20) 
						+ (CoopertitionStackPushes*40); 
					ToteStackPoints.Text = Convert.ToString (currentCyclePoints.ToString ()); 
					LitterCount.Text = LitterButtonPushes.ToString ();
				}
			};



			Label CoopertitionSetCount = new Label ();
			CoopertitionSetCount.BackgroundColor = Color.White;
			CoopertitionSetCount.TextColor = Color.Black;



			Button CoopertitionSet = new Button();
			CoopertitionSet.Text = "Coopertition Set";
			CoopertitionSet.Clicked +=(object sender, EventArgs e) =>{
				CoopertitionStackButtonClicked = true; 
				if (CoopertitionSetPushes == 0) 
				{		
					//CyclePoints[Z]+=20;                                           
					CoopertitionSetPushes++;                                        
					CoopertitionSetCount.Text = CoopertitionSetPushes.ToString(); 
					currentCyclePoints = (ToteButtonPushes * 2) + (CanButtonPushes * ((ToteButtonPushes * 4) + (LitterButtonPushes * 6))) + (CoopertitionSetPushes*20) 
						+ (CoopertitionStackPushes*40); 
					ToteStackPoints.Text = Convert.ToString (currentCyclePoints.ToString ()); 
				} else {
					CoopertitionSetPushes--;                                        
					CoopertitionSetCount.Text = CoopertitionSetPushes.ToString(); 
					currentCyclePoints = (ToteButtonPushes * 2) + (CanButtonPushes * ((ToteButtonPushes * 4) + (LitterButtonPushes * 6))) + (CoopertitionSetPushes*20) 
						+ (CoopertitionStackPushes*40); 
					ToteStackPoints.Text = Convert.ToString (currentCyclePoints.ToString ()); 
				}
			};


			Label CoopertitionStackCount = new Label();
			CoopertitionStackCount.BackgroundColor = Color.White;
			CoopertitionStackCount.TextColor = Color.Black;


			Button CoopertitionStack = new Button();
			CoopertitionStack.Text = "Coopertition Stack";

			CoopertitionStack.Clicked +=(object sender, EventArgs e) =>{
				if (CoopertitionStackPushes== 0)
				{
					CoopertitionStackButtonClicked = true;
					//CyclePoints[Z]+=40;
					currentCyclePoints.ToString();
					CoopertitionStackPushes++;
					CoopertitionStackCount.Text = CoopertitionStackPushes.ToString();
					currentCyclePoints = (ToteButtonPushes * 2) + (CanButtonPushes * ((ToteButtonPushes * 4) + (LitterButtonPushes * 6))) + (CoopertitionSetPushes*20) 
						+ (CoopertitionStackPushes*40); 
					ToteStackPoints.Text = Convert.ToString (currentCyclePoints.ToString ());
				} else {
					CoopertitionStackPushes--;
					CoopertitionStackCount.Text = CoopertitionStackPushes.ToString();
					currentCyclePoints = (ToteButtonPushes * 2) + (CanButtonPushes * ((ToteButtonPushes * 4) + (LitterButtonPushes * 6))) + (CoopertitionSetPushes*20) 
						+ (CoopertitionStackPushes*40); 
					ToteStackPoints.Text = Convert.ToString (currentCyclePoints.ToString ());
				}
			};

	



			Label scoreCount = new Label () {
				Text = totalScore.ToString ()
			};

			Label TotalScoreCount = new Label();
			Button ScoreResetToteStack = new Button();
			ScoreResetToteStack.Text = "Score";
			ScoreResetToteStack.Clicked += (object sender, EventArgs e)=>
			{
				CyclePoints[Z]+=(ToteButtonPushes*2)+(CanButtonPushes*((ToteButtonPushes*4)+(LitterButtonPushes*6)))+(CoopertitionSetPushes*20)+(CoopertitionStackPushes*20);
				//ToteStackPoints.Text = CyclePoints[Z].ToString(); 
				totalScore+=CyclePoints[Z];
				scoreCount.Text = totalScore.ToString();
				TotalScoreCount.Text = totalScore.ToString(); 
				Z++;


				//Reset Tote, Can, Litter Counters (of the individual totestack cluster)
				ToteButtonPushes = 0;	//Max. of 6
				ToteCount.Text=ToteButtonPushes.ToString();
				CanButtonPushes = 0;  //Max of 1
				CanCount.Text=CanButtonPushes.ToString();
				LitterButtonPushes = 0;
				LitterCount.Text = LitterButtonPushes.ToString();
				currentCyclePoints = (ToteButtonPushes * 2) + (CanButtonPushes * ((ToteButtonPushes * 4) + (LitterButtonPushes * 6))) + (CoopertitionSetPushes*20) 
					+ (CoopertitionStackPushes*40); 
				ToteStackPoints.Text = Convert.ToString (currentCyclePoints.ToString ()); 
			};

			Button ResetStack = new Button { 
				Text = "Reset Count",
				BackgroundColor = Color.Green,
			};

			ResetStack.Clicked += (object sender, EventArgs e) => {

				ToteButtonPushes = 0;	//Max. of 6
				ToteCount.Text=ToteButtonPushes.ToString();
				CanButtonPushes = 0;  //Max of 1
				CanCount.Text=CanButtonPushes.ToString();
				LitterButtonPushes = 0;
				LitterCount.Text = LitterButtonPushes.ToString();
				currentCyclePoints = (ToteButtonPushes * 2) + (CanButtonPushes * ((ToteButtonPushes * 4) + (LitterButtonPushes * 6))) + (CoopertitionSetPushes*20) 
					+ (CoopertitionStackPushes*40); 
				ToteStackPoints.Text = Convert.ToString (currentCyclePoints.ToString ()); 
			};

		
			bool disableToggle = false;
			Button Disable = new Button();
			Disable.Text= "Robot Disabled";
			Disable.BackgroundColor = Color.Gray;
			Disable.Clicked += (object sender, EventArgs e) =>  {
				if(disableToggle==false){
					disableToggle=true;
					Disable.BackgroundColor = Color.Yellow;
				} else{
					disableToggle=false;
					Disable.BackgroundColor = Color.Gray;
				}
			};

			data = MatchData;

			Button finishTeleop = new Button();
			finishTeleop.Text = "End Teleop";
			finishTeleop.BackgroundColor = Color.Red;
			finishTeleop.TextColor = Color.Black;



			finishTeleop.Clicked += (object sender, EventArgs e)=>
			{
//				for(int i=0; i<Z; i++){
//					totalScore+=CyclePoints[i];
//				}

				data ["CycleAmount"] = Z;
				data ["TotalScore"] = Convert.ToInt32(totalScore.ToString());
				data ["CycleData"] = CyclePoints;
				data ["disabled"] = disableToggle;
				SaveData();
				Navigation.PushModalAsync(new PreMatchDataPage());
				//Navigation.PushModalAsync(new PostMatch_Scouting(data));
			};

			Grid TeleopLayout = new Grid () {
				VerticalOptions = LayoutOptions.FillAndExpand,
				ColumnDefinitions = {
					new ColumnDefinition{ Width = GridLength.Auto },
					new ColumnDefinition{ Width = GridLength.Auto },
					//new ColumnDefinition{ Width = GridLength.Auto } 
				},
				RowDefinitions = {
					new RowDefinition{ Height = GridLength.Auto},
					new RowDefinition{ Height = GridLength.Auto},
					new RowDefinition{ Height = GridLength.Auto},
					new RowDefinition{ Height = GridLength.Auto},
					new RowDefinition{ Height = GridLength.Auto},
					new RowDefinition{ Height = GridLength.Auto},
				},
				//with two integers: int left, int top
				//with four integers: int left, int right, int top, int bottom
			};

			TeleopLayout.Children.Add (ToteStack, 0, 0); //label - "Stacking Totes"
			TeleopLayout.Children.Add (ToteButton, 0, 1);
			TeleopLayout.Children.Add (CanButton, 0, 2);
			TeleopLayout.Children.Add (LitterButton, 0, 3);
			TeleopLayout.Children.Add (ScoreResetToteStack, 0, 4);
			TeleopLayout.Children.Add (ResetStack, 0, 5);


			TeleopLayout.Children.Add (ToteStackPoints, 1, 2, 0, 1); //Shows points gained from the Totestack
			TeleopLayout.Children.Add (scoreCount, 2, 3, 0, 1);
			TeleopLayout.Children.Add (ToteCount, 1, 3, 1, 2); //label showing number of totes
			TeleopLayout.Children.Add (CanCount, 1, 3, 2, 3);
			TeleopLayout.Children.Add (LitterCount, 1, 3, 3, 4);
			//TeleopLayout.Children.Add (TotalScoreCount, 1, 1, 0, 1); //needs debugging - argument has been thrown
					
			TeleopLayout.Children.Add (CoopertitionStack, 0, 7);
			TeleopLayout.Children.Add (CoopertitionSet, 0, 8);
			TeleopLayout.Children.Add (Disable, 0, 9);
			TeleopLayout.Children.Add (finishTeleop, 0, 1, 10, 11);

			TeleopLayout.Children.Add (CoopertitionStackCount, 1, 3, 7, 8);
			TeleopLayout.Children.Add (CoopertitionSetCount, 1,3, 8,9);
		
			this.Content = TeleopLayout;
		}

		async void SaveData(){
			Console.WriteLine ("Saving...");
			await data.SaveAsync ();
			Console.WriteLine ("Done Saving");
		}

	}  
}



