using System;
using UIKit;

namespace OZ_WINE_APP
{
	public class ConfigPickerViews : UIPickerViewModel
	{
		private string[] _selections;
		public string SelectedElement { get; set; }
		public event EventHandler ElementSelected;

		public ConfigPickerViews (params string[] selections) {
			_selections = selections;
		}

		private void OnElementSelected() {
			if (ElementSelected != null) {
				ElementSelected (this, EventArgs.Empty);
			}
		}

		public override void Selected(UIPickerView picker, nint row, nint component) {
			SelectedElement = _selections[row];
			OnElementSelected ();
		}

		public override nint GetComponentCount(UIPickerView picker) {
			return 1;
		}

		public override nint GetRowsInComponent(UIPickerView picker, nint component) {
			return _selections.Length;
		}

		public override string GetTitle(UIPickerView picker, nint row, nint component) {
			return _selections [row];
		}
	}
}

