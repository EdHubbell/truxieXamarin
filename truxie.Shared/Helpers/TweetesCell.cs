using System;
using Xamarin.Forms;

namespace truxie.Shared
{
	public class TweetesCell:ViewCell
	{
		public TweetesCell ()
		{
			Label labelUserName = new Label {
				TextColor = Color.Black,
				BackgroundColor = Color.Transparent,
				Font = Font.SystemFontOfSize (12, FontAttributes.Bold)
			};
			labelUserName.SetBinding (Label.TextProperty, "ScreenName");
			Label labelTweet = new Label {
				TextColor = Color.Black,
				BackgroundColor = Color.Transparent,
				Font = Font.SystemFontOfSize (10, FontAttributes.None),
				VerticalOptions = LayoutOptions.Start,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			labelTweet.SetBinding (Label.TextProperty, "Text");

			Image imageUser = new Image () {VerticalOptions = LayoutOptions.Start,
				WidthRequest = 40, HeightRequest = 40
			};
			imageUser.SetBinding (Image.SourceProperty, "UserImage");
			imageUser.BackgroundColor = Color.Transparent;

			View = new StackLayout { 
				Padding = new Thickness (5, 1, 5, 1),
				Orientation = StackOrientation.Horizontal,
				Children = {
					imageUser,
					new StackLayout {
						//BackgroundColor=Color.Green,
						Spacing = 0,
						VerticalOptions = LayoutOptions.StartAndExpand,
						HorizontalOptions = LayoutOptions.FillAndExpand,
						Orientation = StackOrientation.Vertical,
						Children = { labelUserName, labelTweet }
					}
				}
			};	

			this.Tapped += HandleTapped;
		}

		void HandleTapped (object sender, EventArgs e)
		{

		}

		protected override void OnBindingContextChanged ()
		{
			base.OnBindingContextChanged ();
			var session = (truxie.Shared.TruckTweet)BindingContext;

			if ((session.Text.Length / 50) > 1)
				this.Height = 30 + (session.Text.Length / 50) * 20;
			else
				this.Height = 40;
		}
	}
}
