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
		UIBarButtonItem CancelBtn { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField DomainTxt { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIPickerView LanguagePicker { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField LocationTxt { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField PasswordTxt { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIBarButtonItem SaveDbBtn { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField ServerTxt { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton TestConnectionBtn { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField UsernameTxt { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIPickerView WOPicker { get; set; }

		[Action ("SaveDbBtn_Activated:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void SaveDbBtn_Activated (UIBarButtonItem sender);

		void ReleaseDesignerOutlets ()
		{
			if (CancelBtn != null) {
				CancelBtn.Dispose ();
				CancelBtn = null;
			}
			if (DomainTxt != null) {
				DomainTxt.Dispose ();
				DomainTxt = null;
			}
			if (LanguagePicker != null) {
				LanguagePicker.Dispose ();
				LanguagePicker = null;
			}
			if (LocationTxt != null) {
				LocationTxt.Dispose ();
				LocationTxt = null;
			}
			if (PasswordTxt != null) {
				PasswordTxt.Dispose ();
				PasswordTxt = null;
			}
			if (SaveDbBtn != null) {
				SaveDbBtn.Dispose ();
				SaveDbBtn = null;
			}
			if (ServerTxt != null) {
				ServerTxt.Dispose ();
				ServerTxt = null;
			}
			if (TestConnectionBtn != null) {
				TestConnectionBtn.Dispose ();
				TestConnectionBtn = null;
			}
			if (UsernameTxt != null) {
				UsernameTxt.Dispose ();
				UsernameTxt = null;
			}
			if (WOPicker != null) {
				WOPicker.Dispose ();
				WOPicker = null;
			}
		}
	}
}
