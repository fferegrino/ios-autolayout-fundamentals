using System;
using UIKit;
using System.ComponentModel;
using Foundation;

namespace VennDiagram
{
	public enum VennWeight
	{
		Left,
		Balanced,
		Right
	}

	[Foundation.Register("VennDiagram"), DesignTimeVisible(true)]
	public class VennDiagram : UIView
	{
		[Outlet("leftCircleTopConstraint")]
		public NSLayoutConstraint LeftCircleTopConstraint { get; set; }
		[Outlet("leftCircleLeadingConstraint")]
		public NSLayoutConstraint LeftCircleLeadingConstraint { get; set; }
		[Outlet("leftCircleBottomConstraint")]
		public NSLayoutConstraint LeftCircleBottomConstraint { get; set; }

		[Outlet("rightCircleTopConstraint")]
		public NSLayoutConstraint RightCircleTopConstraint { get; set; }
		[Outlet("rightCircleTrailingConstraint")]
		public NSLayoutConstraint RightCircleTrailingConstraint { get; set; }
		[Outlet("rightCircleBottomConstraint")]
		public NSLayoutConstraint RightCircleBottomConstraint { get; set; }



		public VennDiagram(IntPtr p) : base(p)
        {
		}

		private VennWeight _Weight = VennWeight.Balanced;
		public VennWeight Weight
		{
			get { return _Weight; }
			set { _Weight = value; SetNeedsUpdateConstraints(); }
		}

		public override void AwakeFromNib()
		{
			var view = new UIView();
			view.Frame = Bounds;
			view.BackgroundColor = UIColor.FromRGBA((nfloat)0.9, (nfloat)0.9, (nfloat)0.9, (nfloat)1.0);
			view.Layer.CornerRadius = (nfloat)12.0;
			view.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;

			view.TranslatesAutoresizingMaskIntoConstraints = false;

			InsertSubview(view, 0);
		}

		public override void UpdateConstraints()
		{
			//if (LeftCircleBottomConstraint == null)
			//{
			//	base.UpdateConstraints();
			//	return;
			//}
			switch (Weight)
			{
				case VennWeight.Left:
					this.LeftCircleBottomConstraint.Constant = 20;
					this.LeftCircleLeadingConstraint.Constant = 20;
					this.LeftCircleTopConstraint.Constant = 20;

					this.RightCircleBottomConstraint.Constant = 40;
					this.RightCircleTrailingConstraint.Constant = 40;
					this.RightCircleTopConstraint.Constant = 40;
					break;
				case VennWeight.Balanced:
					this.LeftCircleBottomConstraint.Constant = 20;
					this.LeftCircleLeadingConstraint.Constant = 20;
					this.LeftCircleTopConstraint.Constant = 20;

					this.RightCircleBottomConstraint.Constant = 20;
					this.RightCircleTrailingConstraint.Constant = 20;
					this.RightCircleTopConstraint.Constant = 20;
					break;
				case VennWeight.Right:
					this.LeftCircleBottomConstraint.Constant = 40;
					this.LeftCircleLeadingConstraint.Constant = 40;
					this.LeftCircleTopConstraint.Constant = 40;

					this.RightCircleBottomConstraint.Constant = 20;
					this.RightCircleTrailingConstraint.Constant = 20;
					this.RightCircleTopConstraint.Constant = 20;
					break;
			}
			base.UpdateConstraints();
		}
	}
}
