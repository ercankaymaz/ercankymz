using System;
using ACadSharp.Attributes;
using ACadSharp.Tables;
using CSMath;
using CSUtilities.Extensions;

namespace ACadSharp.Entities;

[DxfName("DIMENSION")]
[DxfSubClass("AcDbOrdinateDimension")]
public class DimensionOrdinate : Dimension
{
	[DxfCodeValue(new int[] { 13, 23, 33 })]
	public XYZ FeatureLocation { get; set; }

	public bool IsOrdinateTypeX
	{
		get
		{
			return _flags.HasFlag(DimensionType.OrdinateTypeX);
		}
		set
		{
			if (value)
			{
				_flags.AddFlag(DimensionType.OrdinateTypeX);
			}
			else
			{
				_flags.RemoveFlag(DimensionType.OrdinateTypeX);
			}
		}
	}

	[DxfCodeValue(new int[] { 14, 24, 34 })]
	public XYZ LeaderEndpoint { get; set; }

	public override double Measurement
	{
		get
		{
			XY xY = (IsOrdinateTypeX ? XY.AxisY : XY.AxisX);
			double num = Math.Sin(base.HorizontalDirection);
			double num2 = Math.Cos(base.HorizontalDirection);
			xY = new XY(xY.X * num2 - xY.Y * num, xY.X * num + xY.Y * num2);
			double num3 = xY.Dot(base.DefinitionPoint.Convert<XY>() - FeatureLocation.Convert<XY>());
			XY xY2 = FeatureLocation.Convert<XY>() + num3 * xY;
			XY xY3 = base.DefinitionPoint.Convert<XY>() - xY2;
			return Math.Sqrt(xY3.Dot(xY3));
		}
	}

	public override string ObjectName => "DIMENSION";

	public override ObjectType ObjectType => ObjectType.DIMENSION_ORDINATE;

	public override string SubclassMarker => "AcDbOrdinateDimension";

	public DimensionOrdinate()
		: base(DimensionType.Ordinate)
	{
	}

	public override void ApplyTransform(Transform transform)
	{
		base.ApplyTransform(transform);
		FeatureLocation = transform.ApplyTransform(FeatureLocation);
		LeaderEndpoint = transform.ApplyTransform(LeaderEndpoint);
	}

	public override BoundingBox GetBoundingBox()
	{
		return new BoundingBox(FeatureLocation, LeaderEndpoint);
	}

	public override void UpdateBlock()
	{
		base.UpdateBlock();
		DimensionStyle style = base.Style;
		_ = Measurement;
		double num = 2.0 * Style.ArrowSize;
		XY xY = FeatureLocation.Convert<XY>();
		XY xY2 = LeaderEndpoint.Convert<XY>();
		XY value = xY2 - xY;
		double num2 = HorizontalDirection;
		int num3 = 1;
		if (IsOrdinateTypeX)
		{
			num2 += Math.PI / 2.0;
		}
		XY xY3 = XY.Rotate(value, 0.0 - num2);
		XY value2;
		XY value3;
		if (xY3.X >= 0.0)
		{
			if (xY3.X >= 2.0 * num)
			{
				value2 = new XY(xY3.X - num, 0.0);
				value3 = new XY(xY3.X - num, xY3.Y);
			}
			else
			{
				value2 = new XY(num, 0.0);
				value3 = new XY(xY3.X - num, xY3.Y);
			}
		}
		else
		{
			if (xY3.X <= -2.0 * num)
			{
				value2 = new XY(xY3.X + num, 0.0);
				value3 = new XY(xY3.X + num, xY3.Y);
			}
			else
			{
				value2 = new XY(0.0 - num, 0.0);
				value3 = new XY(xY3.X + num, xY3.Y);
			}
			num3 = -1;
		}
		value2 = xY + XY.Rotate(value2, num2);
		value3 = xY + XY.Rotate(value3, num2);
		_block.Entities.Add(new Point(DefinitionPoint)
		{
			Layer = Layer.Defpoints
		});
		_block.Entities.Add(new Point(FeatureLocation)
		{
			Layer = Layer.Defpoints
		});
		_block.Entities.Add(new Line(XY.Polar(xY, style.ExtensionLineOffset * style.ScaleFactor, num2), value2));
		_block.Entities.Add(new Line(value2, value3));
		_block.Entities.Add(new Line(value3, xY2));
		XY xY4 = XY.Polar(xY2, (double)num3 * style.DimensionLineGap * style.ScaleFactor, num2);
		string measurementText = GetMeasurementText();
		if (!base.IsTextUserDefinedLocation)
		{
			TextMiddlePoint = xY4.Convert<XYZ>();
		}
		AttachmentPointType attachmentPoint = ((num3 < 0) ? AttachmentPointType.MiddleRight : AttachmentPointType.MiddleLeft);
		MText mText = createTextEntity(base.TextMiddlePoint, measurementText);
		mText.AttachmentPoint = attachmentPoint;
		_block.Entities.Add(mText);
	}
}
