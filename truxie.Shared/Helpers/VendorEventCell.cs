using System;
using Xamarin.Forms;

namespace truxie.Shared
{
	public class VendorEventCell:ViewCell
	{
		Label labelUserName;
		Label labelTime;
		double paddingOffset = 5;

		public VendorEventCell ()
		{
			labelUserName = new Label {
				TextColor = Color.Black,
				YAlign = TextAlignment.Center,
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				BackgroundColor = Color.Transparent,
				Font = Font.SystemFontOfSize (14, FontAttributes.Bold)
			};
			labelUserName.SetBinding (Label.TextProperty, "VendorName");

			Image imageUser = new Image () {VerticalOptions = LayoutOptions.Start,
				WidthRequest = 40, HeightRequest = 40
			};
			imageUser.SetBinding (Image.SourceProperty, "ImageUrl");
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
							}
						}
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
			var tweet = (VendorEvent)BindingContext;
		}

	}
}
