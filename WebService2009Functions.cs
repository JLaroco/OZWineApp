using System;
using System.IO;
using CoreGraphics;
using Mono.Data.Sqlite;
using System.Data;
using Foundation;
using UIKit;
using SQLite;
using OZ_WINE_APP.TeraVina2009_MobileCellarMgt_WS;

namespace OZ_WINE_APP
{
	public class WebService2009Functions
	{
		public WebService2009Functions ()
		{
		}

		public string GetTeraVinaVersion(string ServerAddress,string username, string password) {
			MobileCellarMgt TV = new MobileCellarMgt(ServerAddress);

			System.Net.ICredentials Cred = new System.Net.NetworkCredential (username, password);
			TV.Credentials = Cred;

			string Version = TV.GetTeraVinaVersion ();

			return Version;
		}

		//Common Alert Functions -
		public void DisplayErrorMessage(string ErrorMessage) {
			UIAlertView alert = new UIAlertView();
			alert.Title = "ERROR!";
			alert.AddButton("OK");
			alert.Message = ErrorMessage;
			alert.Show();
		}
		public void DisplaySuccessMessage(string SuccessMessage) {
			UIAlertView alert = new UIAlertView();
			alert.Title = "SUCCESS!";
			alert.AddButton("OK");
			alert.Message = SuccessMessage;
			alert.Show();
		}
		//Common Alert Functions +
	}
}

