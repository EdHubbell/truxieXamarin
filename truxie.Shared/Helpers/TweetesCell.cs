using System;
using Xamarin.Forms;

namespace truxie.Shared
{
	public class TweetesCell:ViewCell
	{
		Label labelUserName;
		Label labelTweet;
		Label labelTime;
		double paddingOffset = 5;

		public TweetesCell ()
		{
			labelUserName = new Label {
				TextColor = Color.Black,
				YAlign = TextAlignment.Center,
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				BackgroundColor = Color.Transparent,
				Font = Font.SystemFontOfSize (14, FontAttributes.Bold)
			};
			labelUserName.SetBinding (Label.TextProperty, "ScreenName");

			labelTweet = new Label {
				TextColor = Color.Black,
				BackgroundColor = Color.Transparent,
				Font = Font.SystemFontOfSize (12, FontAttributes.None),
				VerticalOptions = LayoutOptions.Start,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			labelTweet.SetBinding (Label.TextProperty, "Text");
			labelTweet.SizeChanged += labelTweet_HandleSizeChanged;

			Image imageUser = new Image () {VerticalOptions = LayoutOptions.Start,
				WidthRequest = 40, HeightRequest = 40
			};
			imageUser.SetBinding (Image.SourceProperty, "UserImage");
			imageUser.BackgroundColor = Color.Transparent;

			labelTime = new Label {
				MinimumWidthRequest = 40,
				HorizontalOptions = LayoutOptions.End,
				XAlign = TextAlignment.End,
				TextColor = Color.Black,
				BackgroundColor = Color.Transparent,
				Font = Font.SystemFontOfSize (12, FontAttributes.Bold)
			};
			labelTime.SetBinding (Label.TextProperty, "DateString");

			View = new StackLayout { 
				Padding = new Thickness (paddingOffset),
				Orientation = StackOrientation.Horizontal,
				Children = {
					imageUser,
					new StackLayout {
						//BackgroundColor=Color.Green,
						//Spacing = 0,
						VerticalOptions = LayoutOptions.StartAndExpand,
						HorizontalOptions = LayoutOptions.FillAndExpand,
						Orientation = StackOrientation.Vertical,
						Children = { 
							new StackLayout { 
								MinimumHeightRequest=30,
								VerticalOptions = LayoutOptions.StartAndExpand,
								HorizontalOptions = LayoutOptions.FillAndExpand,
								Orientation = StackOrientation.Horizontal,
								Children = { labelUserName, labelTime }
							},
							labelTweet
						}
					}
				}
			};	

			this.Tapped += HandleTapped;
		}

		void labelTweet_HandleSizeChanged (object sender, EventArgs e)
		{
			this.Height = labelTweet.Bounds.Top + labelTweet.Bounds.Height + paddingOffset*2;
		}

		void HandleTapped (object sender, EventArgs e)
		{

		}

		protected override void OnBindingContextChanged ()
		{
			base.OnBindingContextChanged ();
			var tweet = (truxie.Shared.TruckTweet)BindingContext;
		}

	}
}
