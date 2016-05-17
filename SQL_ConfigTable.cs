using System;
using System.IO;
using CoreGraphics;
using Mono.Data.Sqlite;
using System.Data;
using Foundation;
using UIKit;
using SQLite;

namespace OZ_WINE_APP
{
	public class SQL_ConfigTable
	{
		[PrimaryKey]
		public int ID { get; set; }
		public string Server { get; set; }
		public string Domain { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Location { get; set; }
		public string Language { get; set; }
		public string WorkOrderPref { get; set; }
		/*public SQL_ConfigTable ()
		{

		}*/
	}
}

