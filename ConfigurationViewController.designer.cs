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
	[Register ("ConfigurationViewController")]
	partial class ConfigurationViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton SaveConfigBtn { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton TestConnectionBtn { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (SaveConfigBtn != null) {
				SaveConfigBtn.Dispose ();
				SaveConfigBtn = null;
			}
			if (TestConnectionBtn != null) {
				TestConnectionBtn.Dispose ();
				TestConnectionBtn = null;
			}
		}
	}
}
