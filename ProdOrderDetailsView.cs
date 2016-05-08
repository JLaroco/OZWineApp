using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using CoreGraphics;

namespace OZ_WINE_APP
{
	partial class ProdOrderDetailsView : UIViewController
	{
		public ProdOrderTableView ProdOrderTableView { get; set; }

		ProdOrderListObject POListObject = new ProdOrderListObject();

		public object DetailItem { get; set; }
		ProdOrderObject CurrOrderObject = new ProdOrderObject();
		public List <ProdOrderObject> CurrList = new List<ProdOrderObject> ();

		public ProdOrderDetailsView (IntPtr handle) : base (handle)
		{
		}

		public void SetDetailItem (object newDetailItem, ProdOrderObject POO, List <ProdOrderObject> ProdOrderList)
		{
			if (DetailItem != newDetailItem) {
				DetailItem = newDetailItem;

				// Update the view
				CurrList = ProdOrderList;
				CurrOrderObject = POO;

				ConfigureView ();

			}
		}

		void ConfigureView ()
		{
			// Update the user interface for the detail item
			if (IsViewLoaded && DetailItem != null)
				ProdOrder.Text = DetailItem.ToString ();

			try {

				//Need to set any old data from the Production Order -
				NoOfCasesOutput.Text = System.Convert.ToString(CurrOrderObject.NoOfCasesOutput);
				GallonsConsumed.Text = System.Convert.ToString(CurrOrderObject.GallonsConsumed);
				LotNo.Text = System.Convert.ToString(CurrOrderObject.LotNo);
				FromTankNo.Text = System.Convert.ToString(CurrOrderObject.FromTank);
				Loss.Text = System.Convert.ToString(CurrOrderObject.CalcLoss);
				HoursWorked.Text = System.Convert.ToString(CurrOrderObject.HoursWorked);
				//Need to set any old data from the Production Order +

				//Save or Cancel the data -
				SaveButton.TouchUpInside += (object sender, EventArgs e) => {
					
					//Create new ProdOrder Object -
					ProdOrderObject ProdOrderObject2 = new ProdOrderObject();
					ProdOrderObject2.ProductionNo = CurrOrderObject.ProductionNo;
					ProdOrderObject2.ProductionNoQty = CurrOrderObject.ProductionNoQty;
					ProdOrderObject2.ItemNo = CurrOrderObject.ItemNo;
					ProdOrderObject2.PackagingMaterialConsumption = CurrOrderObject.PackagingMaterialConsumption;
					ProdOrderObject2.ItemDescription = CurrOrderObject.ItemDescription;
					ProdOrderObject2.NoOfCasesOutput = System.Convert.ToDouble(NoOfCasesOutput.Text);
					ProdOrderObject2.GallonsConsumed = System.Convert.ToDouble(GallonsConsumed.Text);
					ProdOrderObject2.LotNo = LotNo.Text;
					ProdOrderObject2.FromTank = FromTankNo.Text;
					ProdOrderObject2.CalcLoss = System.Convert.ToDouble(Loss.Text);
					ProdOrderObject2.HoursWorked = System.Convert.ToDouble(HoursWorked.Text);
					//Create new ProdOrder Object +


					replaceProdOrderObject(CurrList,CurrOrderObject,ProdOrderObject2);
					//currentpolist.setPO(CurrList);
					POListObject.setProdList(CurrList);			//Maybe???

					/*foreach (var p in CurrList) {
						Console.WriteLine("Lot No: {0} and NoOfCasesOutput: {1}", p.LotNo, p.NoOfCasesOutput);
					}*/


		
					displayAlert("Save");
				};

				CancelButton.TouchUpInside += (object sender, EventArgs e) => {
					displayAlert("Cancel");
				};
				//Save or Cancel the data +
			}catch(Exception e){
				Console.WriteLine (e.Message);
			}
		}

		void replaceProdOrderObject(List<ProdOrderObject> CurrList,ProdOrderObject OldObject, ProdOrderObject NewObject) {
			List<ProdOrderObject> CL = CurrList;
			int index = CL.IndexOf (OldObject);
			if (index != -1) {
				CL [index] = NewObject;
				CurrList = CL;
			}
		}

		void displayAlert(string answer) {
			UIAlertView alert = new UIAlertView();
			alert.Title = "TeraVina Production Orders";
			alert.AddButton("OK");
			if (answer == "Save") {
				alert.Message = "Data has been saved to the Production Order.";
			} else if (answer == "Cancel") {
				alert.Message = "Operation has been canceled.";
			}
			alert.Show();
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
			ConfigureView ();
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.

		}

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			if (segue.Identifier == "BackToPODetails") {
				var controller = (ProdOrderTableView)((UITableViewController)segue.DestinationViewController);
				//List <ProdOrderObject> ProdOrderObj = currentpolist.ProdOrder_TS;
				//controller.SetPOTable (ProdOrderObj);
				controller.NavigationItem.LeftBarButtonItem = SplitViewController.DisplayModeButtonItem;
				controller.NavigationItem.LeftItemsSupplementBackButton = false;
			}
		}
	}
}
