using System;
using ACadSharp.Attributes;
using CSMath;

namespace ACadSharp.Entities;

[DxfName("DIMENSION")]
[DxfSubClass("AcDbAlignedDimension")]
public class DimensionAligned : Dimension
{
	[DxfCodeValue(DxfReferenceType.Optional, new int[] { 52 })]
	public double ExtLineRotation { get; set; }

	[DxfCodeValue(new int[] { 13, 23, 33 })]
	public XYZ FirstPoint { get; set; }

	public override double Measurement => FirstPoint.DistanceFrom(SecondPoint);

	public override string ObjectName => "DIMENSION";

	public override ObjectType ObjectType => ObjectType.DIMENSION_ALIGNED;

	public virtual double Offset
	{
		get
		{
			return SecondPoint.DistanceFrom(base.DefinitionPoint);
		}
		set
		{
			XYZ xyz = SecondPoint - FirstPoint;
			XYZ xYZ = XYZ.Cross(base.Normal, xyz).Normalize();
			base.DefinitionPoint = SecondPoint + xYZ * value;
		}
	}

	[DxfCodeValue(new int[] { 14, 24, 34 })]
	public XYZ SecondPoint { get; set; }

	public override string SubclassMarker => "AcDbAlignedDimension";

	public DimensionAligned()
		: base(DimensionType.Aligned)
	{
	}

	public DimensionAligned(XYZ firstPoint, XYZ secondPoint)
		: this()
	{
		FirstPoint = firstPoint;
		SecondPoint = secondPoint;
	}

	protected DimensionAligned(DimensionType type)
		: base(type)
	{
		base.DefinitionPoint = SecondPoint;
	}

	public override void ApplyTransform(Transform transform)
	{
		XYZ newNormal = transformNormal(transform, base.Normal);
		getWorldMatrix(transform, base.Normal, newNormal, out var transOW, out var transWO);
		base.ApplyTransform(transform);
		FirstPoint = applyWorldMatrix(FirstPoint, transform, transOW, transWO);
		SecondPoint = applyWorldMatrix(SecondPoint, transform, transOW, transWO);
	}

	public override BoundingBox GetBoundingBox()
	{
		return new BoundingBox(FirstPoint, SecondPoint);
	}

	public override void UpdateBlock()
	{
		base.UpdateBlock();
		XYZ xYZ = (SecondPoint - FirstPoint).Normalize();
		XYZ xYZ2 = XYZ.Cross(base.Normal, xYZ).Normalize();
		XYZ xYZ3 = FirstPoint + xYZ2 * Offset;
		XYZ definitionPoint = base.DefinitionPoint;
		_block.Entities.Add(createDefinitionPoint(FirstPoint));
		_block.Entities.Add(createDefinitionPoint(SecondPoint));
		_block.Entities.Add(createDefinitionPoint(xYZ3));
		_block.Entities.Add(createDefinitionPoint(definitionPoint));
		if (!base.Style.SuppressFirstDimensionLine && !base.Style.SuppressSecondDimensionLine)
		{
			_block.Entities.Add(Dimension.dimensionLine(xYZ3, definitionPoint, base.Style));
			_block.Entities.Add(dimensionArrow(xYZ3, -xYZ, base.Style, base.Style.DimArrow1));
			_block.Entities.Add(dimensionArrow(xYZ3, xYZ, base.Style, base.Style.DimArrow2));
		}
		double num = (double)Math.Sign(Offset) * base.Style.ExtensionLineOffset * base.Style.ScaleFactor;
		double num2 = (double)Math.Sign(Offset) * base.Style.ExtensionLineExtension * base.Style.ScaleFactor;
		if (!base.Style.SuppressFirstExtensionLine)
		{
			_block.Entities.Add(Dimension.extensionLine(FirstPoint + num * xYZ2, xYZ3 + num2 * xYZ2, base.Style, base.Style.LineTypeExt1));
		}
		if (!base.Style.SuppressSecondExtensionLine)
		{
			_block.Entities.Add(Dimension.extensionLine(SecondPoint + num * xYZ2, definitionPoint + num2 * xYZ2, base.Style, base.Style.LineTypeExt2));
		}
		XYZ xYZ4 = xYZ3.Mid(definitionPoint);
		double num3 = base.Style.DimensionLineGap * base.Style.ScaleFactor;
		double num4 = ExtLineRotation;
		if (num4 > Math.PI / 2.0 && num4 <= 4.71238898038469)
		{
			num3 = 0.0 - num3;
			num4 += Math.PI;
		}
		string measurementText = GetMeasurementText();
		if (!base.IsTextUserDefinedLocation)
		{
			base.TextMiddlePoint = xYZ4 + num3 * xYZ2;
		}
		MText item = createTextEntity(base.TextMiddlePoint, measurementText);
		_block.Entities.Add(item);
	}
}
