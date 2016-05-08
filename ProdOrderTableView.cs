using System;
using System.Collections.Generic;
using System.Collections;
using System.CodeDom.Compiler;
using System.Linq;

using UIKit;
using Foundation;
using CoreGraphics;

namespace OZ_WINE_APP
{
	partial class ProdOrderTableView : UITableViewController			//Issue here
	{
		//OZ-JCL -
		List<ProdOrderObject> prodOrderList = new List<ProdOrderObject>();
		ProdOrderListObject prodOrderListObject = new ProdOrderListObject ();
		//OZ-JCL +

		public ProdOrderDetailsView ProdOrderDetailsView { get; set; }
		TableSource tableSource;											//New table view source

		public ProdOrderTableView (IntPtr handle) : base (handle)
		{
			Title = NSBundle.MainBundle.LocalizedString ("Bottling Orders", "Bottling Orders");
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				PreferredContentSize = new CGSize (320f, 600f);
				ClearsSelectionOnViewWillAppear = false;
			}
		}

		public void SetPOTable (List <ProdOrderObject> POO)
		{
			//Console.WriteLine ("SetPOTable!!!");
			/*foreach (var p in POO) {
				Console.WriteLine("Lot No 2: {0} and NoOfCasesOutput 2: {1}", p.LotNo, p.NoOfCasesOutput);
			}*/
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			prodOrderList = SetInitialData();
			ProdOrderListObject prodOrderListObject = new ProdOrderListObject ();

			List <ProdOrderObject> POO22 = new List<ProdOrderObject> ();
			POO22 = prodOrderListObject.ProductionOrderList;

			Console.WriteLine ("View Did Load --> Prod Order Table View");

			WriteToConsole (POO22);

			tableSource = new TableSource(this);
			tableSource.loadPOData (prodOrderList);
			TableView.Source = tableSource;
		}

		public void WriteToConsole (List <ProdOrderObject> Obj) {
			
			if (Obj == null || Obj.Count == 0) {
				Console.WriteLine ("Nothing Within PO LIST");
				return;
			} else {
				foreach (var p in Obj) {
					Console.WriteLine ("Lot No 2: {0} and NoOfCasesOutput 2: {1}", p.LotNo, p.NoOfCasesOutput);
				}
			}
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
		}
			
		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "showBottleOrderDetails") {
				var indexPath = TableView.IndexPathForSelectedRow;
				var item = tableSource.Objects[indexPath.Row];
				ProdOrderObject POO = tableSource.ProdOrder_TS[indexPath.Row];
				var controller = (ProdOrderDetailsView)((UINavigationController)segue.DestinationViewController).TopViewController;
				controller.Title = "Bottling Order Details";
				controller.SetDetailItem (item,POO,prodOrderList);
				controller.NavigationItem.LeftBarButtonItem = SplitViewController.DisplayModeButtonItem;
				controller.NavigationItem.LeftItemsSupplementBackButton = true;
			}
		}

		public List<ProdOrderObject> SetInitialData () {
			
			//Packing Material Consumption Items -
			string [] PackagingMaterialConsumption1 = {"Item 1","Item 2","Item 3"};
			//Packing Material Consumption Items +

			//Add Production Order Objects here -
			ProdOrderObject ProdOrder1 = new ProdOrderObject("PRD-100001",100,"ITM001","Test Item 1",5,500,"Lot1","Tank1",4,PackagingMaterialConsumption1,0,"01/01/15","CS","01/07/15",100,200);
			ProdOrderObject ProdOrder2 = new ProdOrderObject("PRD-100002",200,"ITM002","Test Item 2",10,600,"Lot2","Tank2",6,PackagingMaterialConsumption1,1,"02/01/15","CS","02/07/15",250,300);
			ProdOrderObject ProdOrder3 = new ProdOrderObject("PRD-100003",300,"ITM003","Test Item 3",15,700,"Lot3","Tank3",8,PackagingMaterialConsumption1,2,"03/01/15","CS","03/07/15",240,250);
			ProdOrderObject ProdOrder4 = new ProdOrderObject("PRD-100004",400,"ITM004","Test Item 4",20,800,"Lot4","Tank4",10,PackagingMaterialConsumption1,3,"04/01/15","CS","04/07/15",500,600);
			ProdOrderObject ProdOrder5 = new ProdOrderObject("PRD-100005",500,"ITM005","Test Item 5",25,900,"Lot5","Tank5",12,PackagingMaterialConsumption1,4,"05/01/15","CS","05/07/15",150,200);
			ProdOrderObject ProdOrder6 = new ProdOrderObject("PRD-100006",600,"ITM006","Test Item 6",0,0,"","",0,PackagingMaterialConsumption1,0,"06/01/15","CS","06/07/15",780,800);
			ProdOrderObject ProdOrder7 = new ProdOrderObject("PRD-100007",100,"ITM007","Test Item 7",5,500,"Lot1","Tank1",4,PackagingMaterialConsumption1,0,"01/01/15","CS","01/07/15",100,200);
			ProdOrderObject ProdOrder8 = new ProdOrderObject("PRD-100008",200,"ITM008","Test Item 8",10,600,"Lot2","Tank2",6,PackagingMaterialConsumption1,1,"02/01/15","CS","02/07/15",250,300);
			ProdOrderObject ProdOrder9 = new ProdOrderObject("PRD-100009",300,"ITM009","Test Item 9",15,700,"Lot3","Tank3",8,PackagingMaterialConsumption1,2,"03/01/15","CS","03/07/15",240,250);
			//Add Production Order Objects here +

			List<ProdOrderObject> POL = new List<ProdOrderObject> {ProdOrder1,ProdOrder2,ProdOrder3,ProdOrder4,ProdOrder5,ProdOrder6,ProdOrder7,ProdOrder8,ProdOrder9};

			return POL;
		}

		public class TableSource : UITableViewSource
		{
			static readonly NSString CellIdentifier = new NSString ("BottleCell");
			List<object> objects = new List<object>();
			List<object> detailObjects = new List<object> ();
			List<object> leftSide = new List<object> ();
			List<object> rightSide = new List<object> ();
			List<ProdOrderObject> ProdOrder_TableSource = new List<ProdOrderObject> ();

	
			readonly ProdOrderTableView controller;

			public TableSource (ProdOrderTableView controller)
			{
				this.controller = controller;
			}

			public IList<object> Objects {
				get { return objects; }
			}

			public IList<object> DetailObjects {
				get {  return detailObjects; }
			}

			public IList<object> LeftSide {
				get { return leftSide; }
			}

			public IList<object> RightSide {
				get {  return rightSide; }
			}

			public IList<ProdOrderObject> ProdOrder_TS {
				get { return ProdOrder_TableSource; }
			}

			// Customize the number of sections in the table view.
			public override nint NumberOfSections (UITableView tableView)
			{
				return 1;
			}

			public override nint RowsInSection (UITableView tableview, nint section)
			{
				return objects.Count;
			}

			/*public override UITableViewCell GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
			{
				// In here you could customize how you want to get the height for row. Then   
				// just return it. 

				float someHeight = 60;

				return someHeight;
			}*/

			// Customize the appearance of table view cells.
			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				/*tableView.RowHeight = UITableView.AutomaticDimension;
				tableView.EstimatedRowHeight = 160;
				
				var cell = tableView.DequeueReusableCell (CellIdentifier) as CustomBottlingOrderTableCell;
				if (cell == null)
					cell = new CustomBottlingOrderTableCell (CellIdentifier);

				string leftLbl, rightLbl, bottomRightLbl;

				bottomRightLbl = objects [indexPath.Row].ToString ();
				leftLbl = leftSide [indexPath.Row].ToString ();
				rightLbl = rightSide [indexPath.Row].ToString ();
				cell.UpdateCell (leftLbl,rightLbl,bottomRightLbl);*/

				var cell = tableView.DequeueReusableCell (CellIdentifier, indexPath);

				cell.TextLabel.Text = leftSide[indexPath.Row].ToString () + "                           " + rightSide[indexPath.Row].ToString();
				//cell.TextLabel.Text = objects [indexPath.Row].ToString ();
				cell.DetailTextLabel.Text = objects [indexPath.Row].ToString () + "                  " + detailObjects [indexPath.Row].ToString();
				cell.DetailTextLabel.TextAlignment = UITextAlignment.Right;

				return cell;
			}

			public override bool CanEditRow (UITableView tableView, NSIndexPath indexPath)
			{
				// Return false if you do not want the specified item to be editable.
				return true;
			}

			public override void CommitEditingStyle (UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
			{
				if (editingStyle == UITableViewCellEditingStyle.Delete) {
					// Delete the row from the data source.
					objects.RemoveAt (indexPath.Row);
					controller.TableView.DeleteRows (new [] { indexPath }, UITableViewRowAnimation.Fade);
				} else if (editingStyle == UITableViewCellEditingStyle.Insert) {
					// Create a new instance of the appropriate class, insert it into the array, and add a new row to the table view.
				}
			}

			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
				if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
					controller.ProdOrderDetailsView.SetDetailItem (objects [indexPath.Row], ProdOrder_TableSource [indexPath.Row],controller.prodOrderList);
			}

			public void loadPOData(List<ProdOrderObject> POL) {
				//Go through list -
				foreach (ProdOrderObject PO in POL) {
					string BRS = PO.ProductionNo; //+ " (" + PO.ProductionNoQty + ")";
					string BLS = PO.ItemNo + " - " + PO.ItemDescription;

					string TLS = PO.POStartDate + " - " + PO.POEndDate;
					string TRS = PO.ProducedQty + "/" + PO.PlannedQty;

					leftSide.Add (TLS);
					rightSide.Add (TRS);

					objects.Add (BLS);
					detailObjects.Add (BRS);
					ProdOrder_TableSource.Add (PO);
				}
				//Go through list +
			}
		}
	}
}
