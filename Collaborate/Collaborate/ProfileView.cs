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

			_profileTopConstraint = _profileImageView.TopAnchor.ConstraintEqualTo(this.TopAnchor);
			_profileTopConstraint.Active = true;

			_profileImageView.LeadingAnchor.ConstraintEqualTo(this.LeadingAnchor).Active = true;

			_networkImageView = new UIImageView(CGRect.Empty);
			_networkImageView.ContentMode = UIViewContentMode.ScaleAspectFit;

			_networkImageView.TranslatesAutoresizingMaskIntoConstraints = false;

			AddSubview(_networkImageView);


			_networkImageView.TopAnchor.ConstraintEqualTo(this.TopAnchor).Active = true;

			_networkTrailingConstraint = _networkImageView.TrailingAnchor.ConstraintEqualTo(_profileImageView.TrailingAnchor);
			_networkTrailingConstraint.Active = true;

			_networkBottomConstraint = _networkImageView.BottomAnchor.ConstraintEqualTo(this.TopAnchor);
			_networkBottomConstraint.Active = true;

			_networkLeadingConstraint = _networkImageView.LeadingAnchor.ConstraintEqualTo(this.LeadingAnchor);
			_networkLeadingConstraint.Active = true;


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