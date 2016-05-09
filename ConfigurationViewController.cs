using System;

using UIKit;

namespace OZ_WINE_APP
{
	public partial class ConfigurationViewController : UIViewController
	{
		SQL_DatabaseFunctions DBFunctions = new SQL_DatabaseFunctions();
		//public ConfigurationViewController () : base ("ConfigurationViewController", null)
		public ConfigurationViewController (IntPtr p) : base(p)	
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			DBFunctions.CreateTable();
			ServerTxt.Text = DBFunctions.ReturnConfigServer ();
			DomainTxt.Text = DBFunctions.ReturnConfigDomain ();
			UsernameTxt.Text = DBFunctions.ReturnConfigUsername ();
			PasswordTxt.Text = DBFunctions.ReturnConfigPassword ();
			LocationTxt.Text = DBFunctions.ReturnConfigLocation ();

			TestConnectionBtn.TouchUpInside += testConnection;
			SaveConfigBtn.TouchUpInside += saveConfigData;
			//testConnection ();
			//saveConfigData ();


			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		void testConnection (object sender, EventArgs e) {	
			DBFunctions.TestDB();
			UIAlertView alert = new UIAlertView();
			alert.Title = "SUCCESS/ERROR";
			alert.AddButton("OK");
			alert.Message = "Test Connection here.";
			alert.Show();

		}
		void saveConfigData(object sender, EventArgs e) {
			DBFunctions.InsertUpdateTable(1,ServerTxt.Text,DomainTxt.Text,UsernameTxt.Text,PasswordTxt.Text,LocationTxt.Text,"English","ALL");
		}
	}
}


