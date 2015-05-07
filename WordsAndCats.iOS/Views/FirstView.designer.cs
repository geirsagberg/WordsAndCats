// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace WordsAndCats.iOS.Views
{
	[Register ("FirstView")]
	partial class FirstView
	{
		[Outlet]
		UIKit.UIWebView WebView { get; set; }

		[Outlet]
		UIKit.UILabel WordsLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (WordsLabel != null) {
				WordsLabel.Dispose ();
				WordsLabel = null;
			}

			if (WebView != null) {
				WebView.Dispose ();
				WebView = null;
			}
		}
	}
}
