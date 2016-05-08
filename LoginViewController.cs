using System;

using UIKit;

namespace OZ_WINE_APP
{
	public partial class LoginViewController : UIViewController
	{
		//public LoginViewController () : base ("LoginViewController", null)
		public LoginViewController (IntPtr p) : base(p)			//API Changed for iOS 9
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			checkLogin ();
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		void checkLogin() {
			
			LoginButton.TouchUpInside += (object sender, EventArgs e) => {
				String username = UserTextBox.Text;
				String password = PasswordTextBox.Text;

				if (username == "admin" && password == "password") 
				{
					PerformSegue("GoToApp", this);
					//Initialize Segue and go to tab
				} else 
				{
					UIAlertView alert = new UIAlertView();
					alert.Title = "ERROR";
					alert.AddButton("OK");
					alert.Message = "Please enter valid credential.";
					alert.Show();
				}
			};
		
		}
	}
}


