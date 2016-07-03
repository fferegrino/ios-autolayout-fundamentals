// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using UIKit;

namespace Collaborate
{
	public partial class LaunchViewController : UIViewController
	{
		public LaunchViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			var logoImage = UIImage.FromBundle("Logo");
				var logo = new UIImageView(logoImage);
			logo.TranslatesAutoresizingMaskIntoConstraints = false;

			View.AddSubview(logo);

			var centerX = NSLayoutConstraint.Create(
				logo,
				NSLayoutAttribute.CenterX,
				NSLayoutRelation.Equal,
				View,
				NSLayoutAttribute.CenterX,
				1,
				0);

			var centerY = NSLayoutConstraint.Create(
				view1: logo,
				attribute1: NSLayoutAttribute.CenterY,
				relation: NSLayoutRelation.Equal,
				view2: View,
				attribute2: NSLayoutAttribute.CenterY,
				multiplier: 1,
				constant: 0);

			var imageSize = logo.Image.Size;

			var aspectRatio = NSLayoutConstraint.Create(
				logo,
				NSLayoutAttribute.Width,
				NSLayoutRelation.Equal,
				logo,
				NSLayoutAttribute.Height,
				imageSize.Width / imageSize.Height,
				1);


			var top = NSLayoutConstraint.Create(
				 logo,
				attribute1: NSLayoutAttribute.Top,
				relation: NSLayoutRelation.GreaterThanOrEqual,
				view2: this.View,
				attribute2: NSLayoutAttribute.TopMargin,
				multiplier: 1,
				constant: 20
			);


			var bottom = NSLayoutConstraint.Create(
				view1: logo,
				attribute1: NSLayoutAttribute.Bottom,
				relation: NSLayoutRelation.GreaterThanOrEqual,
				view2: this.View,
				attribute2: NSLayoutAttribute.BottomMargin,
				multiplier: 1,
				constant: 20
			);


			var leading = NSLayoutConstraint.Create(
				view1: logo,
				attribute1: NSLayoutAttribute.Leading,
				relation: NSLayoutRelation.GreaterThanOrEqual,
				view2: this.View,
				attribute2: NSLayoutAttribute.LeadingMargin,
				multiplier: 1,
				constant: 0
			);


			var trailing = NSLayoutConstraint.Create(
				view1: logo,
				attribute1: NSLayoutAttribute.Trailing,
				relation: NSLayoutRelation.GreaterThanOrEqual,
				view2: this.View,
				attribute2: NSLayoutAttribute.TrailingMargin,
				multiplier: 1,
				constant: 0
			);


			logo.AddConstraint(aspectRatio);

			View.AddConstraints(new NSLayoutConstraint[] { centerX, centerY, top, bottom, leading, trailing });


		}
	}
}
