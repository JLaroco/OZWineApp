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
	public partial class ConfigurationViewController : UIViewController
	{
		private string _pathToDatabase;		//Path To DB

		//SQL_DatabaseFunctions DBFunctions = new SQL_DatabaseFunctions();
		public ConfigurationViewController (IntPtr p) : base(p)	
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			//Create Table if not created already -
			var documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			_pathToDatabase = Path.Combine(documents, "db_sqlite-net.db");
			using (var conn= new SQLite.SQLiteConnection(_pathToDatabase))
			{
				conn.CreateTable<SQL_ConfigTable>();
			}
			//Create Table if not created already +
			setInitialData();

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

		void setInitialData() {
			try {
				var db = new SQLiteConnection (_pathToDatabase);
				if (db.Table<SQL_ConfigTable> ().Count () == 0) {
					ServerTxt.Text = "";
					DomainTxt.Text = "";
					UsernameTxt.Text = "";
					PasswordTxt.Text = "";
					LocationTxt.Text = "";
				} else {
					var configData = db.Get<SQL_ConfigTable> (1);
					ServerTxt.Text = configData.Server;
					DomainTxt.Text = configData.Domain;
					UsernameTxt.Text = configData.Username;
					PasswordTxt.Text = configData.Password;
					LocationTxt.Text = configData.Location;
				}
			} catch (SQLite.SQLiteException ex) {
				UIAlertView alert = new UIAlertView();
				alert.Title = "ERROR";
				alert.AddButton("OK");
				alert.Message = ex.Message;
				alert.Show();
			}
		}

		void testConnection (object sender, EventArgs e) {	
			WebService2009Functions WSFunctions = new WebService2009Functions();
			try {
				string DomainUsername = DomainTxt.Text + "\\" + UsernameTxt.Text;
				string TeraVinaVersion = WSFunctions.GetTeraVinaVersion(ServerTxt.Text,DomainUsername,PasswordTxt.Text);
				WSFunctions.DisplaySuccessMessage("TeraVina Version: " + TeraVinaVersion);

			} catch(Exception e2){
				WSFunctions.DisplayErrorMessage (e2.Message);
			}

		}
		void saveConfigData(object sender, EventArgs e) {
			var data = new SQL_ConfigTable {ID = 1, Server = ServerTxt.Text, Domain = DomainTxt.Text, Username = UsernameTxt.Text, Password = PasswordTxt.Text, Location = LocationTxt.Text, Language = "TEST-LANG1", WorkOrderPref = "TEST-LANG2"};
			var db = new SQLite.SQLiteConnection (_pathToDatabase);

			try {
				if (db.Table<SQL_ConfigTable> ().Count () == 0) {
					db.Insert (data);
					UIAlertView alert = new UIAlertView();
					alert.Title = "SUCCESS";
					alert.AddButton("OK");
					alert.Message = "Configuration data saved locally.";
					alert.Show();
				} else {
					db.Execute ("UPDATE SQL_ConfigTable SET Server='" + ServerTxt.Text + "',Domain='" + DomainTxt.Text + "',Username='" + UsernameTxt.Text + "',Password='" + PasswordTxt.Text + "',Location='" + LocationTxt.Text + "' WHERE ID=1;");
					UIAlertView alert = new UIAlertView();
					alert.Title = "SUCCESS";
					alert.AddButton("OK");
					alert.Message = "Configuration data saved locally.";
					alert.Show();
				}
			} catch (SQLite.SQLiteException ex) {
				UIAlertView alert = new UIAlertView();
				alert.Title = "ERROR";
				alert.AddButton("OK");
				alert.Message = ex.Message;
				alert.Show();
			}
		}
	}
}


