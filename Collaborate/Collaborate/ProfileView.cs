//
//  ProfileView.swift
//  Collaborate
//
//  Created by Pluralsight on 10/21/15.
//  Copyright © 2015 Pluralsight. All rights reserved.
//

using System;
using System.ComponentModel;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Collaborate
{
	[Register("ProfileView"), DesignTimeVisible(true)]
	public class ProfileView : UIView
	{
		public ProfileView(IntPtr p) : base(p)
		{
			InitializeViews();
		}

		private UIImageView _profileImageView;

		[Export("ProfileImage"), Browsable(true)]
		public UIImage ProfileImage
		{
			get { return _profileImageView?.Image; }
			set
			{
				if (_profileImageView != null)
					_profileImageView.Image = value;
			}
		}

		private UIImageView _networkImageView;

		[Export("NetworkImage"), Browsable(true)]
		public UIImage NetworkImage
		{
			get { return _networkImageView?.Image; }
			set
			{
				if (_networkImageView != null)
					_networkImageView.Image = value;
			}
		}

		private NSLayoutConstraint _profileTopConstraint;

		private NSLayoutConstraint _networkLeadingConstraint;
		private NSLayoutConstraint _networkBottomConstraint;
		private NSLayoutConstraint _networkTrailingConstraint;

		public ProfileView(CGRect frame) : base(frame)
		{
			InitializeViews();
		}

		public ProfileView(NSCoder aDecoder) : base(aDecoder)
		{
			InitializeViews();
		}

		[Export("requiresConstraintBasedLayout")]
		public static new bool RequiresConstraintBasedLayout()
		{
			return true;
		}

		void InitializeViews()
		{
			this.BackgroundColor = UIColor.LightGray;

			_profileImageView = new UIImageView(CGRect.Empty);
			_profileImageView.TranslatesAutoresizingMaskIntoConstraints = false;

			AddSubview(_profileImageView);

			_profileTopConstraint = NSLayoutConstraint.Create(
				view1: _profileImageView,
				attribute1: NSLayoutAttribute.Top,
				relation: NSLayoutRelation.Equal,
				view2: this,
				attribute2: NSLayoutAttribute.Top,
				multiplier: 1,
				constant: 0);
			
			var profileLeading = NSLayoutConstraint.Create(
				view1: _profileImageView,
				attribute1: NSLayoutAttribute.Leading,
				relation: NSLayoutRelation.Equal,
				view2: this,
				attribute2: NSLayoutAttribute.Leading,
				multiplier: 1,
				constant: 0);

			AddConstraints(new NSLayoutConstraint[] { _profileTopConstraint, profileLeading });

			_networkImageView = new UIImageView(CGRect.Empty);
			_networkImageView.ContentMode = UIViewContentMode.ScaleAspectFit;

			_networkImageView.TranslatesAutoresizingMaskIntoConstraints = false;

			AddSubview(_networkImageView);

			var networkTop = NSLayoutConstraint.Create(
				view1: _networkImageView,
				attribute1: NSLayoutAttribute.Top,
				relation: NSLayoutRelation.Equal,
				view2: this,
				attribute2: NSLayoutAttribute.Top,
				multiplier: 1,
				constant: 0);

			_networkTrailingConstraint = NSLayoutConstraint.Create(
				view1: _networkImageView,
				attribute1: NSLayoutAttribute.Trailing,
				relation: NSLayoutRelation.Equal,
				view2: _profileImageView,
				attribute2: NSLayoutAttribute.Trailing,
				multiplier: 1,
				constant: 0);

			_networkBottomConstraint = NSLayoutConstraint.Create(
				view1: _networkImageView,
				attribute1: NSLayoutAttribute.Bottom,
				relation: NSLayoutRelation.Equal,
				view2: this,
				attribute2: NSLayoutAttribute.Top,
				multiplier: 1,
				constant: 0);

			_networkLeadingConstraint = NSLayoutConstraint.Create(
				view1: _networkImageView,
				attribute1: NSLayoutAttribute.Leading,
				relation: NSLayoutRelation.Equal,
				view2: this,
				attribute2: NSLayoutAttribute.Leading,
				multiplier: 1,
				constant: 0);

			//var ratio = NSLayoutConstraint.Create(
			//	view1: _networkImageView,
			//	attribute1: NSLayoutAttribute.Width,
			//	relation: NSLayoutRelation.Equal,
			//	view2: _networkImageView,
			//	attribute2: NSLayoutAttribute.Height,
			//	multiplier: _networkImageView.Frame.Size.Height / _networkImageView.Frame.Size.Width,
			//	constant: 0);

			AddConstraints(new NSLayoutConstraint[] { networkTop, _networkBottomConstraint, _networkLeadingConstraint,_networkTrailingConstraint });

		}

		public override void UpdateConstraints()
		{
			if (ProfileImage != null && NetworkImage != null)
			{
				var leadingDistance =  ProfileImage.Size.Width * ((nfloat)0.65);
				_networkLeadingConstraint.Constant = leadingDistance;
				_networkBottomConstraint.Constant = ProfileImage.Size.Height * ((nfloat)0.35);

				_profileTopConstraint.Constant = NetworkImage.Size.Height * ((nfloat)0.25);

				var maxDistance = (leadingDistance + NetworkImage.Size.Width) - ProfileImage.Size.Width;

				_networkTrailingConstraint.Constant = maxDistance;
			}
			base.UpdateConstraints();
		}

		public override CGSize IntrinsicContentSize
		{
			get
			{
				if (ProfileImage != null )
				{
					return ProfileImage.Size;
				}
				return new CGSize(width: UIView.NoIntrinsicMetric, height: UIView.NoIntrinsicMetric);
			}
		}

		public override UIEdgeInsets AlignmentRectInsets
		{
			get
			{

				var maxX = _networkTrailingConstraint.Constant > 0 ? _networkTrailingConstraint.Constant : 0;
				return new UIEdgeInsets(top: 0, left: 0, bottom: _profileTopConstraint.Constant, right: maxX);

			}
		}
	}
}