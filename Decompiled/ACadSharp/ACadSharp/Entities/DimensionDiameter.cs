using System;
using ACadSharp.Attributes;
using ACadSharp.Tables;
using CSMath;

namespace ACadSharp.Entities;

[DxfName("DIMENSION")]
[DxfSubClass("AcDbDiametricDimension")]
public class DimensionDiameter : Dimension
{
	[DxfCodeValue(new int[] { 15, 25, 35 })]
	public XYZ AngleVertex { get; set; }

	public XYZ Center => AngleVertex.Mid(base.DefinitionPoint);

	[DxfCodeValue(new int[] { 40 })]
	public double LeaderLength { get; set; }

	public override double Measurement => base.DefinitionPoint.DistanceFrom(AngleVertex);

	public override string ObjectName => "DIMENSION";

	public override ObjectType ObjectType => ObjectType.DIMENSION_DIAMETER;

	public override string SubclassMarker => "AcDbDiametricDimension";

	public DimensionDiameter()
		: base(DimensionType.Diameter)
	{
	}

	public override void ApplyTransform(Transform transform)
	{
		base.ApplyTransform(transform);
		AngleVertex = transform.ApplyTransform(AngleVertex);
	}

	public override BoundingBox GetBoundingBox()
	{
		return new BoundingBox(base.InsertionPoint - AngleVertex, base.InsertionPoint + AngleVertex);
	}

	public override void UpdateBlock()
	{
		base.UpdateBlock();
		double num = base.DefinitionPoint.DistanceFrom(base.TextMiddlePoint);
		double num2 = Measurement * 0.5;
		Center.Convert<XY>();
		XY xY = AngleVertex.Convert<XY>();
		XY u = base.DefinitionPoint.Convert<XY>();
		double num3 = (2.0 * base.Style.ArrowSize + base.Style.DimensionLineGap) * base.Style.ScaleFactor;
		double angle = u.GetAngle(xY);
		short num4;
		if (num >= num2 && num <= num2 + num3)
		{
			num = num2 + num3;
			num4 = -1;
		}
		else if (!(num >= num2 - num3) || !(num <= num2))
		{
			num4 = (short)((!(num > num2)) ? 1 : (-1));
		}
		else
		{
			num = num2 - num3;
			num4 = 1;
		}
		XY start = XY.Polar(u, num - base.Style.DimensionLineGap * base.Style.ScaleFactor, angle);
		Layer defpoints = Layer.Defpoints;
		_block.Entities.Add(new Point(xY.Convert<XYZ>())
		{
			Layer = defpoints
		});
		if (!base.Style.SuppressFirstDimensionLine && !base.Style.SuppressSecondDimensionLine)
		{
			if (num4 > 0)
			{
				_block.Entities.Add(dimensionRadialLine(start, xY, angle, num4));
			}
			else
			{
				_block.Entities.Add(dimensionRadialLine(start, xY, angle, num4));
			}
		}
		if (!MathHelper.IsZero(base.Style.CenterMarkSize))
		{
			_block.Entities.AddRange(centerCross(Center, num2, base.Style));
		}
		string text = Measurement.ToString("#.##");
		double num5 = angle;
		short num6 = 1;
		if (num5 > Math.PI / 2.0 && num5 <= 4.71238898038469)
		{
			num5 += Math.PI;
			num6 = -1;
		}
		if (!base.IsTextUserDefinedLocation)
		{
			XY xY2 = XY.Polar(xY, (double)(-num6 * num4) * base.Style.DimensionLineGap * base.Style.ScaleFactor, num5);
			base.TextMiddlePoint = xY2.Convert<XYZ>();
		}
		AttachmentPointType attachmentPoint = ((num6 * num4 < 0) ? AttachmentPointType.MiddleLeft : AttachmentPointType.MiddleRight);
		MText mText = createTextEntity(base.TextMiddlePoint, text);
		mText.AttachmentPoint = attachmentPoint;
		_block.Entities.Add(mText);
	}
}
