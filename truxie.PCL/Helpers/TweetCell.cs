using System;
using Xamarin.Forms;

namespace truxie.PCL
{
	public class TweetCell:ViewCell
	{
		Label labelUserName;
		Label labelTweet;
		Label labelTime;
		Image imageUser;
		double paddingOffset = 5;

		public TweetCell ()
		{
			labelUserName = new Label {
				TextColor = Color.Black,
				YAlign = TextAlignment.Center,
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				BackgroundColor = Color.Transparent,
				Font = Font.SystemFontOfSize (14, FontAttributes.Bold)
			};
			labelUserName.SetBinding (Label.TextProperty, "User.ScreenName");

			labelTweet = new Label {
				TextColor = Color.Black,
				BackgroundColor = Color.Transparent,
				Font = Font.SystemFontOfSize (12, FontAttributes.None),
				VerticalOptions = LayoutOptions.Start,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			labelTweet.SetBinding (Label.TextProperty, "Text");
			labelTweet.SizeChanged += labelTweet_HandleSizeChanged;

			imageUser = new Image () {VerticalOptions = LayoutOptions.Start,
				WidthRequest = 40, HeightRequest = 40
			};
			imageUser.SetBinding (Image.SourceProperty, "User.ProfileImageUrl");
			imageUser.BackgroundColor = Color.Transparent;

			labelTime = new Label {
				MinimumWidthRequest = 40,
				HorizontalOptions = LayoutOptions.End,
				XAlign = TextAlignment.End,
				TextColor = Color.Black,
				BackgroundColor = Color.Transparent,
				Font = Font.SystemFontOfSize (12, FontAttributes.Bold)
			};
			labelTime.SetBinding (Label.TextProperty, "DateAgo");

			View = new StackLayout { 
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
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
			this.View.HeightRequest = this.Height - paddingOffset;

		}

		void HandleTapped (object sender, EventArgs e)
		{

		}

		protected override void OnBindingContextChanged ()
		{
			base.OnBindingContextChanged ();
			var tweet = (TruckTweet)BindingContext;

			this.Height = MeasurementManager.Measurement.MesureString (labelTweet.Text,12f,(float)(imageUser.WidthRequest+paddingOffset*3))+ paddingOffset*2+24;
		}

	}
}
