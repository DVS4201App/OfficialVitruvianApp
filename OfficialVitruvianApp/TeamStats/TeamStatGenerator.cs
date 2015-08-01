using System;
using System.Threading.Tasks;
using Parse;
using Xamarin.Forms;

namespace OfficialVitruvianApp
{
	public class TeamStatGenerator:ContentPage
	{
		ParseObject teamStats = new ParseObject("TeamStats");

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
		double postitiveAutoAvg = 0;
		int goodStackCount = 0;
		int autoStepCanPulls=0;
		int teleopStepCanPulls=0;
		double[] litterThrowMatchRate = new double[10];
		double tLitterPercentage = 0;
		double avgHumanSuccessRate = 0;
		int canUprightcount = 0;
		int interferenceCount=0;
		int landfillTotes=0;
		int stationTotes=0;

		public TeamStatGenerator (int teamNo)
		{
			GenerateStats (teamNo);
			//Navigation.PushModalAsync(new TeamStatsDisplay(teamStats));
			Label loading = new Label {
				Text = "Loading..."
			};

			Button test = new Button {
				Text = "test"
			};
			test.Clicked += (object sender, EventArgs e) => {
				GenerateStats(teamNo);
			};
			this.Content = new StackLayout {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,

				Children = {
					loading,
					test
				}
			};
		}

		async void GenerateStats(int teamNo){
			ParseQuery<ParseObject> query = ParseObject.GetQuery ("MatchData");
			query.Include ("teamNo");
			ParseQuery<ParseObject> filter = query.WhereEqualTo ("teamNo", teamNo);

			var selectedTeam = await filter.FindAsync();

			Console.WriteLine ("Team Number: " + teamNo);

			foreach (ParseObject obj in selectedTeam) {
				await obj.FetchAsync ();

				Console.WriteLine (obj ["objectId"].ToString ());
				//Merge column data into a single value/average
				tScore += Convert.ToInt32(obj ["TotalScore"].ToString());
				tCycle += Convert.ToInt32(obj ["CycleAmount"].ToString());
				tAuto += Convert.ToInt32 (obj ["autoPoints"].ToString ());
				autoStepCanPulls += Convert.ToInt32 (obj ["autoStepCanPulls"].ToString ());
				teleopStepCanPulls += Convert.ToInt32 (obj ["teleopStepCanPulls"].ToString ());

				if (Convert.ToInt32(obj ["TotalScore"].ToString()) < lowestScore) {
					lowestScore = Convert.ToInt32(obj ["TotalScore"].ToString());
				}
				if (Convert.ToInt32(obj ["TotalScore"].ToString()) > highestScore) {
					highestScore = Convert.ToInt32(obj ["TotalScore"].ToString());
				}

				if (Convert.ToInt32(obj ["autoPoints"].ToString()) != 0) {
					positiveAutoCount++;
				}

				if (Convert.ToBoolean(obj ["goodStack"].ToString())==true) {
					goodStackCount++;
				}

				interferenceCount += Convert.ToInt16 (obj ["interferenceCount"]);
				landfillTotes += Convert.ToInt16 (obj ["landfillTotes"]);
				stationTotes += Convert.ToInt16 (obj ["stationTotes"]);

				canUprightcount += Convert.ToInt32(obj ["canUprightCount"].ToString());

				litterThrowMatchRate [Z] = Convert.ToDouble (obj ["litterSuccess"].ToString ()) / Convert.ToInt16 (obj ["litterThrows"]);
				tLitterPercentage += litterThrowMatchRate [Z];

				//Attempt at merging arrays/pulling arrays from Parse
				/*
				ParseQuery<ParseObject> array = ParseObject.GetQuery ("CycleData");
				var arrayQuery = await array.FindAsync();

				int j=0;
				foreach(ParseObject arrayObj in arrayQuery){

					if (Convert.ToInt16(arrayObj) == 0) {
						break;
					} else {
						cyclebreakdown [Z, j] = Convert.ToInt16 (arrayObj);
						j++;
					}
				}
				*/

				Z++;
			}

			//Save vaules into Parse
			avgScore = tScore / Z;
			avgCycle = tCycle / Z;
			autoAvg = tAuto / Z;
			postitiveAutoAvg = tAuto / positiveAutoCount;
			avgHumanSuccessRate = tLitterPercentage / Z;

			teamStats.Add ("teamNo", teamNo);
			teamStats.Add ("matchesCounted", Z);
			teamStats.Add ("avgScore", Math.Round(avgScore,2));
			teamStats.Add ("avgCycle", Math.Round(avgCycle,2));
			teamStats.Add ("lowestScore", lowestScore);
			teamStats.Add ("highestScore", highestScore);
			teamStats.Add ("totalAutoAvg", Math.Round(autoAvg,2));
			teamStats.Add ("postitiveAutoAvg", Math.Round(postitiveAutoAvg,2));
			teamStats.Add ("landfillTotesStacked", landfillTotes);
			teamStats.Add ("stationTotesStacked", stationTotes);
			teamStats.Add ("goodStackCount", goodStackCount);
			teamStats.Add ("autoStepCanPulls", autoStepCanPulls);
			teamStats.Add ("teleopStepCanPulls", teleopStepCanPulls);
			teamStats.Add ("totalStepCanPulls", autoStepCanPulls+teleopStepCanPulls);
			teamStats.Add ("totalCansUprighed", canUprightcount);
			teamStats.Add ("interferenceCount", interferenceCount);
			teamStats.Add ("litterSuccessByMatch", litterThrowMatchRate);
			teamStats.Add ("avgHumanSuccessRate", avgHumanSuccessRate);
			//teamStats.Add ("AllCycleData", cyclebreakdown);
			//teamStats ["teamNo"] = teamNo;
			//teamStats ["avgScore"] = Math.Round(avgScore,2);
			//teamStats ["avgCycle"] = Math.Round(avgCycle,2);

			Console.WriteLine ("Presave...");

			SaveData();
			//???
			await Navigation.PushModalAsync(new TeamStatsDisplay(teamStats));
		}

		async void SaveData(){
			Console.WriteLine ("Saving...");
			await teamStats.SaveAsync ();
			Console.WriteLine ("Done Saving");
			//Navigation.PushAsync(new TeamStatsDisplay(teamStats));
		}
	}
}

