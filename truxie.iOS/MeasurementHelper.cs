using System;
using truxie.Shared;
using System.Drawing;
using MonoTouch.UIKit;

namespace truxie.iOS
{
	public class MeasurementHelper:IMeasurement
	{
		#region IMeasurement implementation

		public double MesureString (string text,float fontSize,float left)
		{
			SizeF sizeToDisplay = new UILabel().StringSize(text, UIFont.SystemFontOfSize(fontSize), new SizeF(UIScreen.MainScreen.Bounds.Width-left, float.MaxValue), UILineBreakMode.WordWrap);

			return sizeToDisplay.Height;
		}

		#endregion
	}
}

