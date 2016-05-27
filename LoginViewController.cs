using System;
using UIKit;
using OZ_WINE_APP.TeraVina2009_MobileCellarMgt_WS;

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
			LoginButton.TouchUpInside += checkLogin;
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		void checkLogin(object sender, EventArgs e) {
			WebService2009Functions WSFunctions = new WebService2009Functions();
			SQL_DatabaseFunctions DBFunctions = new SQL_DatabaseFunctions ();
			try {
				String username = UserTextBox.Text;
				String password = PasswordTextBox.Text;

				Boolean isSuccess = WSFunctions.isLoginSuccessful (username,password,DBFunctions.GetConfigLocation());

				if (isSuccess) 
				{
					PerformSegue("GoToApp", this);
					//Initialize Segue and go to tab
				} else 
				{
					WSFunctions.DisplayErrorMessage ("Please enter valid NAV credentials.");
				}
			} catch(Exception e2){
				WSFunctions.DisplayErrorMessage (e2.Message);
			}
		}
	}
}


