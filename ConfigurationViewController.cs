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
		private string _pathToDatabase;		// Path To DB

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
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		void setInitialData() {
			//Set Pickers -
			ConfigPickerViews LangaugeModel = new ConfigPickerViews("English","Spanish");
			ConfigPickerViews WOModel = new ConfigPickerViews ("All","Mine Only");
			WOPicker.Model = WOModel;
			LanguagePicker.Model = LangaugeModel;
			//Set Pickers +

			try {

				var db = new SQLiteConnection (_pathToDatabase);
				if (db.Table<SQL_ConfigTable> ().Count () == 0) {
					ServerTxt.Text = "";
					DomainTxt.Text = "";
					UsernameTxt.Text = "";
					PasswordTxt.Text = "";
					LocationTxt.Text = "";
					//ConfigPickerViews LangaugeModel = new ConfigPickerViews("English","Spanish");
					//ConfigPickerViews WOModel = new ConfigPickerViews ("All","Mine Only");
					WOPicker.Model = WOModel;
					LanguagePicker.Model = LangaugeModel;
				} else {
					var configData = db.Get<SQL_ConfigTable> (1);
					ServerTxt.Text = configData.Server;
					DomainTxt.Text = configData.Domain;
					UsernameTxt.Text = configData.Username;
					PasswordTxt.Text = configData.Password;
					LocationTxt.Text = configData.Location;

					// Custom set of Language/WO Pickers -
					/*if (configData.Language == "Spanish") {
						ConfigPickerViews LangaugeModel = new ConfigPickerViews("Spanish","English");	
					} else {
						ConfigPickerViews LangaugeModel = new ConfigPickerViews("English","Spanish");
					}
					if (configData.WorkOrderPref == "Mine Only") {
						ConfigPickerViews WOModel = new ConfigPickerViews ("Mine Only","All");	
					} else {
						ConfigPickerViews WOModel = new ConfigPickerViews ("All","Mine Only");
					}*/
					// Custom set of Language/WO Pickers +
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

		partial void SaveDbBtn_Activated (UIBarButtonItem sender)
		{
			//throw new NotImplementedException ();
			var data = new SQL_ConfigTable {ID = 1, Server = ServerTxt.Text, Domain = DomainTxt.Text, Username = UsernameTxt.Text, Password = PasswordTxt.Text, Location = LocationTxt.Text, Language = "TEST-LANG1", WorkOrderPref = "TEST-LANG2"};
			var db = new SQLite.SQLiteConnection (_pathToDatabase);
			WebService2009Functions DisplayMessages = new WebService2009Functions();

			try {
				if (db.Table<SQL_ConfigTable> ().Count () == 0) {
					db.Insert (data);
					DisplayMessages.DisplaySuccessMessage("Configuration data saved locally.");
				} else {
					db.Execute ("UPDATE SQL_ConfigTable SET Server='" + ServerTxt.Text + "',Domain='" + DomainTxt.Text + "',Username='" + UsernameTxt.Text + "',Password='" + PasswordTxt.Text + "',Location='" + LocationTxt.Text + "',Language='" + LangaugeModel.SelectedElement + "',WorkOrderPref='" + WOModel.SelectedElement + "' WHERE ID=1;");
					DisplayMessages.DisplaySuccessMessage("Configuration data saved locally.");
				}
			} catch (SQLite.SQLiteException ex) {
				DisplayMessages.DisplayErrorMessage(ex.Message);
			}

			//Testing -
			/*UIAlertView alert = new UIAlertView();
			alert.Title = "TEST!";
			alert.AddButton("OK");
			alert.Message = "Language Selected: " + LangaugeModel.SelectedElement + " \nWO Selected: " + WOModel.SelectedElement;
			alert.Show();*/	
			//Testing +

		}
	}
}


