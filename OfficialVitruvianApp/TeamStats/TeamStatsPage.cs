using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Parse;

namespace OfficialVitruvianApp
{
	public class TeamStatsPage:ContentPage
	{
		ParseObject teamStats = new ParseObject("teamStats");

		public TeamStatsPage ()
		{
			Title = "Team Stats";

			Label teamNoLabel = new Label {
				Text = "Enter Team Number:"
			};

			Entry teamNo = new Entry{
				Placeholder = "[Enter Team Number]",
				Keyboard = Keyboard.Numeric
			};

			Button updateBtn = new Button {
				Text = "Retrieve Stats",
				TextColor = Color.Green,
				BackgroundColor = Color.Black
			};
			updateBtn.Clicked += (object sender, EventArgs e) => {
				try{
					GenerateStats(Convert.ToInt16(teamNo.Text));
				} catch{
					DisplayAlert("Error", "Team Number not recognized" , "OK");
				}
			};

			Label note = new Label () {
				Text = "Warning: May Crash. Use at your own risk"
			};

			//Back Button
			Button backBtn = new Button ();
			backBtn.Text = "Back";
			backBtn.TextColor = Color.Green;
			backBtn.BackgroundColor = Color.Black;

			backBtn.Clicked += (object sender, EventArgs e) => {
				Navigation.PushModalAsync(new MainMenuPage());
			};

			this.Content = new StackLayout {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,

				Children = {
					teamNoLabel,
					teamNo,
					updateBtn,
					backBtn,
					note
				}
			};
		}
			
		async void GenerateStats(int teamNo){
			ParseQuery<ParseObject> query = ParseObject.GetQuery ("MatchData");
			query.Include ("teamNo");
			ParseQuery<ParseObject> filter = query.WhereEqualTo ("teamNo", teamNo);
			int test = await filter.CountAsync ();
			if (test == 0) {
				DisplayAlert ("Error", "No matches found for queried team", "OK");
				return;
			}
			
			int Z=0;
			double avgScore = 0;
			double avgCycle = 0;
			double tScore = 0;
			double tCycle = 0;
			int lowestScore = 999;
			int highestScore = 0;
			//int[,] cyclebreakdown = new int[10,N]; 

			double tAuto = 0;
			int positiveAutoCount = 0;
			double autoAvg = 0;
			double positiveAutoAvg = 0;
			int goodStackCount = 0;
			int autoStepCanPulls=0;
			int teleopStepCanPulls=0;
			double[] litterThrowMatchRate = new double[10];
			double tLitterPercentage = 0;
			double avgHumanSuccessRate = 0;
			int canUprightCount = 0;
			int interferenceCount=0;
			int landfillTotes=0;
			int stationTotes=0;

			var selectedTeam = await filter.FindAsync();

			foreach (ParseObject obj in selectedTeam) {
				await obj.FetchIfNeededAsync ();

				//Merge column data into a single value/average
				tScore += Convert.ToInt16(obj ["TotalScore"].ToString());
				tCycle += Convert.ToInt16(obj ["CycleAmount"].ToString());
				tAuto += Convert.ToInt16(obj ["autoPoints"].ToString ());
				//autoStepCanPulls += Convert.ToInt32 (obj ["autoStepCanPulls"].ToString ());
				//teleopStepCanPulls += Convert.ToInt32 (obj ["teleopStepCanPulls"].ToString ());

				if (Convert.ToInt16(obj ["TotalScore"].ToString()) < lowestScore) {
					lowestScore = Convert.ToInt16(obj ["TotalScore"].ToString());
				}
				if (Convert.ToInt16(obj ["TotalScore"].ToString()) > highestScore) {
					highestScore = Convert.ToInt16(obj ["TotalScore"].ToString());
				}
				if (Convert.ToInt16(obj ["autoPoints"].ToString()) != 0) {
					positiveAutoCount++;
				}
				if (Convert.ToBoolean (obj ["goodStack"].ToString ()) == true) {
					goodStackCount++;
				}

				interferenceCount += Convert.ToInt16 (obj ["interferenceCount"]);
				landfillTotes += Convert.ToInt16 (obj ["landfillTotes"]);
				stationTotes += Convert.ToInt16 (obj ["stationTotes"]);


				autoStepCanPulls += Convert.ToInt16(obj ["autoStepCanPulls"].ToString());
				teleopStepCanPulls += Convert.ToInt16(obj ["teleopStepCanPulls"].ToString());

				canUprightCount+= Convert.ToInt16(obj ["canUprightCount"].ToString());


				//litterThrowMatchRate [Z] = Convert.ToDouble (obj ["litterSuccess"].ToString ()) / Convert.ToInt16 (obj ["litterThrows"]);
				//tLitterPercentage += litterThrowMatchRate [Z];

				Z++;
			}

			//Save vaules into Parse
			avgScore = tScore / Z;              
			avgCycle = tCycle / Z;
			autoAvg = tAuto / Z;
			//Cannot divide by 0
			if (positiveAutoCount != 0) {
				positiveAutoAvg = tAuto / positiveAutoCount;
			} else if (positiveAutoCount == 0) {
				positiveAutoAvg = 0;
			}
			teamStats ["teamNo"] = teamNo;
			teamStats ["matchesCounted"] = Z;
			teamStats ["avgScore"] = Math.Round(avgScore,2);
			teamStats ["avgCycle"] = Math.Round(avgCycle,2);
			teamStats ["lowestScore"] = lowestScore;
			teamStats ["highestScore"] = highestScore;
			teamStats ["totalAutoAvg"] = Math.Round(autoAvg,2);
			teamStats ["positiveAutoAvg"] = Math.Round(positiveAutoAvg,2);
			teamStats.Add ("landfillTotesStacked", landfillTotes);
			teamStats.Add ("stationTotesStacked", stationTotes);
			teamStats ["goodStackCount"] = goodStackCount;
			teamStats ["autoStepCanPulls"] = autoStepCanPulls;
			teamStats ["teleopStepCanPulls"] = teleopStepCanPulls;
			teamStats ["totalStepCanPulls"] = autoStepCanPulls + teleopStepCanPulls;
			teamStats ["totalCansUprighted"] = canUprightCount;
			teamStats.Add ("interferenceCount", interferenceCount);
			teamStats.Add ("litterSuccessByMatch", litterThrowMatchRate);
			teamStats.Add ("avgHumanSuccessRate", avgHumanSuccessRate);
			//teamStats.Add ("AllCycleData", cyclebreakdown);
			//avgHumanSuccessRate = tLitterPercentage / Z;

			SaveData();
			Navigation.PushModalAsync(new TeamStatsDisplay(teamStats));
		}

		async void SaveData(){
			Console.WriteLine ("Saving...");
			await teamStats.SaveAsync ();
			Console.WriteLine ("Done Saving");
		}
	}
}

