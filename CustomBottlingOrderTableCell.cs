using System;
using Foundation;
using UIKit;
using CoreGraphics;

namespace OZ_WINE_APP
{

	public class CustomBottlingOrderTableCell : UITableViewCell  {
		UILabel leftLabel, rightLabel, bottomRightLabel;
		public CustomBottlingOrderTableCell (NSString cellId) : base (UITableViewCellStyle.Default, cellId)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Gray;
			ContentView.BackgroundColor = UIColor.FromRGB (255, 255, 255);
			leftLabel = new UILabel () {
				Font = UIFont.FromName("Arial", 15f),
				TextColor = UIColor.FromRGB (0, 0, 0),
				TextAlignment = UITextAlignment.Left,
				BackgroundColor = UIColor.Clear
			};
			rightLabel = new UILabel () {
				Font = UIFont.FromName("Arial", 15f),
				TextColor = UIColor.FromRGB (0, 0, 0),
				TextAlignment = UITextAlignment.Left,
				BackgroundColor = UIColor.Clear
			};
			bottomRightLabel = new UILabel () {
				Font = UIFont.FromName("Arial", 15f),
				TextColor = UIColor.FromRGB (0, 0, 0),
				TextAlignment = UITextAlignment.Center,
				BackgroundColor = UIColor.Clear
			};
			ContentView.AddSubviews(new UIView[] {leftLabel,rightLabel,bottomRightLabel});

		}
		public void UpdateCell (string LL, string RL, string BRL)
		{
			leftLabel.Text = LL;
			rightLabel.Text = RL;
			bottomRightLabel.Text = BRL;
		}
		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();

			//CGRect ();
			rightLabel.Frame = new CGRect (ContentView.Bounds.Width - 100, 4, 70, 33);
			//rightLabel.Frame = new CGRect (ContentView.Bounds.Width - 63, 5, 33, 33);
			leftLabel.Frame = new CGRect (5, 4, ContentView.Bounds.Width - 63, 25);
			bottomRightLabel.Frame = new CGRect (100, 18, 100, 20);
		}
	}
}

