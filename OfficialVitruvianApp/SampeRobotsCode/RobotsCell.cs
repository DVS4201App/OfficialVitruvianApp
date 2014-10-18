using System;
using Xamarin.Forms;
using Parse;

namespace Robots
{
	public class RobotsCell : TextCell
	{

		public RobotsCell ()
		{
		}


		public ParseObject CellParseData;

//		public ParseObject CellParseData
//		{
//			get { return CellParseData;}
//			set { CellParseData = value;}
//		}

		public static readonly BindableProperty CellParseDataProperty =
			BindableProperty.Create ("CellParseData", typeof (ParseObject),
				typeof (RobotsCell),
				default(ParseObject));
				
	}
}

