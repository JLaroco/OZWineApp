// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace OZ_WINE_APP
{
	[Register ("ProdOrderDetailsView")]
	partial class ProdOrderDetailsView
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton CancelButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField FromTankNo { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField GallonsConsumed { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField HoursWorked { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField Loss { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField LotNo { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField NoOfCasesOutput { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel ProdOrder { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton SaveButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (CancelButton != null) {
				CancelButton.Dispose ();
				CancelButton = null;
			}
			if (FromTankNo != null) {
				FromTankNo.Dispose ();
				FromTankNo = null;
			}
			if (GallonsConsumed != null) {
				GallonsConsumed.Dispose ();
				GallonsConsumed = null;
			}
			if (HoursWorked != null) {
				HoursWorked.Dispose ();
				HoursWorked = null;
			}
			if (Loss != null) {
				Loss.Dispose ();
				Loss = null;
			}
			if (LotNo != null) {
				LotNo.Dispose ();
				LotNo = null;
			}
			if (NoOfCasesOutput != null) {
				NoOfCasesOutput.Dispose ();
				NoOfCasesOutput = null;
			}
			if (ProdOrder != null) {
				ProdOrder.Dispose ();
				ProdOrder = null;
			}
			if (SaveButton != null) {
				SaveButton.Dispose ();
				SaveButton = null;
			}
		}
	}
}
