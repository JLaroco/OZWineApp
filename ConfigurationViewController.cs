using System;

using UIKit;

namespace OZ_WINE_APP
{
	public partial class ConfigurationViewController : UIViewController
	{
		//public ConfigurationViewController () : base ("ConfigurationViewController", null)
		public ConfigurationViewController (IntPtr p) : base(p)	
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			testConnection ();
			saveConfigData ();


			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		void testConnection() {

			TestConnectionBtn.TouchUpInside += (object sender, EventArgs e) => {
				
					UIAlertView alert = new UIAlertView();
					alert.Title = "SUCCESS/ERROR";
					alert.AddButton("OK");
					alert.Message = "Test Connection here.";
					alert.Show();
			};

		}
		void saveConfigData() {

			SaveConfigBtn.TouchUpInside += (object sender, EventArgs e) => {

				UIAlertView alert = new UIAlertView();
				alert.Title = "SAVED TO DATABASE.";
				alert.AddButton("OK");
				alert.Message = "Save Config Data locally.";
				alert.Show();
			};

		}
	}
}


