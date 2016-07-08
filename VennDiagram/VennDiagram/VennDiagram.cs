using System;
using UIKit;
using System.ComponentModel;

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
		public NSLayoutConstraint LeftCircleTopConstraint { get; set; }
		public NSLayoutConstraint LeftCircleLeadingConstraint { get; set; }
		public NSLayoutConstraint LeftCircleBottomConstraint { get; set; }

		public NSLayoutConstraint RightCircleTopConstraint { get; set; }
		public NSLayoutConstraint RightCircleTrailingConstraint { get; set; }
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
			if (LeftCircleBottomConstraint == null)
			{
				base.UpdateConstraints();
				return;
			}
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
