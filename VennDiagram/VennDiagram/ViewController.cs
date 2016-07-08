using System;
using Foundation;
using UIKit;

namespace VennDiagram
{
	public partial class ViewController : UIViewController
	{
		[Outlet("vennDiagram")]
		public VennDiagram VennDiagram { get; set; }

		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			VennDiagram.Weight = VennWeight.Left;
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void ViewWillLayoutSubviews()
		{
			base.ViewWillLayoutSubviews();
			System.Diagnostics.Debug.WriteLine("Will layout subviews");
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		[Action("leftTapped:")]
		public void LeftTapped(UIButton sender)
		{
			VennDiagram.Weight = VennWeight.Left;
			System.Diagnostics.Debug.WriteLine("Tapped " + nameof(LeftTapped));
		}

		[Action("balancedTapped:")]
		public void BalancedTapped(UIButton sender)
		{
			VennDiagram.Weight = VennWeight.Balanced;
			System.Diagnostics.Debug.WriteLine("Tapped " + nameof(BalancedTapped));
		}

		[Action("rightTapped:")]
		public void RightTapped(UIButton sender)
		{
			VennDiagram.Weight = VennWeight.Right;
			System.Diagnostics.Debug.WriteLine("Tapped " + nameof(RightTapped));
		}
	}
}

