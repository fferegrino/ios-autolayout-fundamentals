//
//  CircleView.swift
//  VennDiagram
//
//  Created by James Wilson on 12/16/15.
//  Copyright © 2015 Pluralsight. All rights reserved.
//

using System;
using System.ComponentModel;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace VennDiagram
{
	[Register("CircleView"), DesignTimeVisible(true)]
	public class CircleView : UIView
	{
		private UIColor _fillColor;

		[Export("FillColor"), Browsable(true)]
		public UIColor FillColor
		{
			get { return _fillColor; }
			set
			{
				_fillColor = value;
				LayoutSubviews();
				LayoutIfNeeded();
			}
		}

		public CircleView(IntPtr p) : base(p)
		{
			//Initialize();
		}

		public void Initialize()
		{
			FillColor = UIColor.LightTextColor;
			BackgroundColor = UIColor.Clear;
		}

		public CircleView(NSCoder aDecoder) : base(aDecoder)
		{
			Initialize();
		}

		public CircleView(CGRect frame) : base(frame)
		{
			Initialize();
		}

		public CAShapeLayer ShapeLayer => Layer as CAShapeLayer;

		[Export("layerClass")]
		public static Class LayerClass()
		{
			return new Class(typeof(CAShapeLayer));
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			var beizerPath = UIBezierPath.FromOval(Bounds);
			ShapeLayer.FillColor = FillColor.CGColor;
			ShapeLayer.Path = beizerPath.CGPath;
		}
	}
}
