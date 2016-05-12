using System;
using System.IO;
using CoreGraphics;
using Mono.Data.Sqlite;
using System.Data;
using Foundation;
using UIKit;

namespace OZ_WINE_APP
{
	public class SQL_DatabaseFunctions
	{
		private string _pathToDatabase;

		public SQL_DatabaseFunctions ()
		{
			// Figure out where the SQLite database will be.
			var documents = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			_pathToDatabase = Path.Combine(documents, "db_sqlite-net.db");
		}

		public void CreateTable() 
		{
			using (var conn= new SQLite.SQLiteConnection(_pathToDatabase))
			{
				conn.CreateTable<SQL_ConfigTable>();
			}
		}

		public void InsertUpdateTable(int id, String ServerT, String DomainT, String UsernameT, String PasswordT, String LocationT, String LanguageT, String PrefT)
		{
			try 
			{
				var data = new SQL_ConfigTable {ID = id, Server = ServerT, Domain = DomainT, Username = UsernameT, Password = PasswordT, Location = LocationT, Language = LanguageT, WorkOrderPref = PrefT};
				var db = new SQLite.SQLiteConnection (_pathToDatabase);
				if (db.Insert (data) != 0)
					db.Update (data);
				UIAlertView alert = new UIAlertView();
				alert.Title = "SUCCESS";
				alert.AddButton("OK");
				alert.Message = "Configuration has been updated.";
				alert.Show();
			} 
			catch (SQLite.SQLiteException ex)
			{
				UIAlertView alert = new UIAlertView();
				alert.Title = "ERROR";
				alert.AddButton("OK");
				alert.Message = ex.Message;
				alert.Show();
			}

			/*public void Update(SqliteConnection conn) {

				// Clear last connection to prevent circular call to update
				_conn = null;

				// Execute query
				conn.Open ();
				using (var command = conn.CreateCommand ()) {
					// Create new command
					command.CommandText = "UPDATE [People] SET Name = @COL2, Occupation = @COL3, isManager = @COL4, ManagerID = @COL5 WHERE ID = @COL1";

					// Populate with data from the record
					command.Parameters.AddWithValue ("@COL1", ID);
					command.Parameters.AddWithValue ("@COL2", Name);
					command.Parameters.AddWithValue ("@COL3", Occupation);
					command.Parameters.AddWithValue ("@COL4", isManager);
					command.Parameters.AddWithValue ("@COL5", ManagerID);

					// Write to database
					command.ExecuteNonQuery ();
				}
				conn.Close ();

				// Save children to database as well
				for (nuint n = 0; n < People.Count; ++n) {
					// Grab person
					var Person = People.GetItem<PersonModel>(n);

					// Update sub record
					Person.Update (conn);
				}

				// Save last connection
				_conn = conn;
			}*/
		}

		public string ReturnConfigServer()
		{
			String config = "";
			var db = new SQLite.SQLiteConnection (_pathToDatabase);
			var stocksStartingWithA = db.Query<SQL_ConfigTable>("SELECT * FROM SQL_ConfigTable WHERE ID = 1");
			foreach (var s in stocksStartingWithA) {
				config = s.Server.ToString();
			}
			return config;
		}

		public string ReturnConfigDomain()
		{
			String config = "";
			var db = new SQLite.SQLiteConnection (_pathToDatabase);
			var stocksStartingWithA = db.Query<SQL_ConfigTable>("SELECT * FROM SQL_ConfigTable WHERE ID = 1");
			foreach (var s in stocksStartingWithA) {
				config = s.Domain.ToString();
			}
			return config;
		}

		public string ReturnConfigUsername()
		{
			String config = "";
			var db = new SQLite.SQLiteConnection (_pathToDatabase);
			var stocksStartingWithA = db.Query<SQL_ConfigTable>("SELECT * FROM SQL_ConfigTable WHERE ID = 1");
			foreach (var s in stocksStartingWithA) {
				config = s.Username.ToString();
			}
			return config;
		}

		public string ReturnConfigPassword()
		{
			String config = "";
			var db = new SQLite.SQLiteConnection (_pathToDatabase);
			var stocksStartingWithA = db.Query<SQL_ConfigTable>("SELECT * FROM SQL_ConfigTable WHERE ID = 1");
			foreach (var s in stocksStartingWithA) {
				config = s.Password.ToString();
			}
			return config;
		}

		public string ReturnConfigLocation()
		{
			String config = "";
			var db = new SQLite.SQLiteConnection (_pathToDatabase);
			var stocksStartingWithA = db.Query<SQL_ConfigTable>("SELECT * FROM SQL_ConfigTable WHERE ID = 1");
			foreach (var s in stocksStartingWithA) {
				config = s.Location.ToString();
			}
			return config;
		}

		public void TestDB() 
		{
			var db = new SQLite.SQLiteConnection (_pathToDatabase);
			var stocksStartingWithA = db.Query<SQL_ConfigTable>("SELECT * FROM SQL_ConfigTable WHERE ID = 1");
			foreach (var s in stocksStartingWithA) {
				Console.WriteLine ("ID: " + s.ID + " Server: " + s.Server + " Domain: " + s.Domain + " Username: " + s.Username + " Password: " + s.Password + " Location: " + s.Location);
			}
		}

	}
}

