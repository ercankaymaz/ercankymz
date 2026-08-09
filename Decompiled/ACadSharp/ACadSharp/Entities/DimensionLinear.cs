using System;
using ACadSharp.Attributes;
using ACadSharp.Tables;
using CSMath;
using CSMath.Geometry;

namespace ACadSharp.Entities;

[DxfName("DIMENSION")]
[DxfSubClass("AcDbRotatedDimension")]
public class DimensionLinear : DimensionAligned
{
	public override double Measurement
	{
		get
		{
			double num = Math.Abs(new XYZ(Math.Cos(Rotation), Math.Sin(Rotation), 0.0).Dot((base.SecondPoint - base.FirstPoint).Normalize()));
			return base.Measurement * num;
		}
	}

	public override string ObjectName => "DIMENSION";

	public override ObjectType ObjectType => ObjectType.DIMENSION_LINEAR;

	public override double Offset
	{
		get
		{
			return base.Offset;
		}
		set
		{
			XYZ xYZ = Transform.CreateRotation(base.Normal, Rotation).ApplyTransform(XYZ.AxisY).Normalize();
			base.DefinitionPoint = base.SecondPoint + xYZ * value;
		}
	}

	[DxfCodeValue(DxfReferenceType.IsAngle, new int[] { 50 })]
	public double Rotation { get; set; }

	public override string SubclassMarker => "AcDbRotatedDimension";

	public DimensionLinear()
		: base(DimensionType.Linear)
	{
	}

	public override void UpdateBlock()
	{
		createBlock();
		Transform transform = Transform.CreateRotation(base.Normal, Rotation);
		XYZ xYZ = transform.ApplyTransform(XYZ.AxisY).Normalize();
		XYZ direction = transform.ApplyTransform(XYZ.AxisX).Normalize();
		Line3D line3D = new Line3D(base.FirstPoint, xYZ);
		Line3D line3D2 = new Line3D(base.DefinitionPoint, direction);
		XYZ xYZ2 = line3D.FindIntersection(line3D2);
		XYZ definitionPoint = base.DefinitionPoint;
		XYZ xYZ3 = (definitionPoint - xYZ2).Normalize();
		_block.Entities.Add(new Point(base.FirstPoint)
		{
			Layer = Layer.Defpoints
		});
		_block.Entities.Add(new Point(base.SecondPoint)
		{
			Layer = Layer.Defpoints
		});
		_block.Entities.Add(new Point(xYZ2)
		{
			Layer = Layer.Defpoints
		});
		_block.Entities.Add(new Point(definitionPoint)
		{
			Layer = Layer.Defpoints
		});
		if (!base.Style.SuppressFirstDimensionLine && !base.Style.SuppressSecondDimensionLine)
		{
			_block.Entities.Add(Dimension.dimensionLine(xYZ2, definitionPoint, base.Style));
			_block.Entities.Add(dimensionArrow(xYZ2, -xYZ3, base.Style, base.Style.DimArrow1));
			_block.Entities.Add(dimensionArrow(definitionPoint, xYZ3, base.Style, base.Style.DimArrow2));
		}
		XYZ xYZ4 = (xYZ2 - base.FirstPoint).Normalize();
		XYZ xYZ5 = (definitionPoint - base.SecondPoint).Normalize();
		double num = base.Style.ExtensionLineOffset * base.Style.ScaleFactor;
		double num2 = base.Style.ExtensionLineExtension * base.Style.ScaleFactor;
		if (!base.Style.SuppressFirstExtensionLine)
		{
			_block.Entities.Add(Dimension.extensionLine(base.FirstPoint + num * xYZ4, xYZ2 + num2 * xYZ4, base.Style, base.Style.LineTypeExt1));
		}
		if (!base.Style.SuppressSecondExtensionLine)
		{
			_block.Entities.Add(Dimension.extensionLine(base.SecondPoint + num * xYZ5, definitionPoint + num2 * xYZ5, base.Style, base.Style.LineTypeExt2));
		}
		XYZ xYZ6 = xYZ2.Mid(definitionPoint);
		double num3 = base.Style.DimensionLineGap * base.Style.ScaleFactor;
		double num4 = Rotation;
		if (num4 > Math.PI / 2.0 && num4 <= 4.71238898038469)
		{
			num3 = 0.0 - num3;
			num4 += Math.PI;
		}
		string measurementText = GetMeasurementText();
		if (!base.IsTextUserDefinedLocation)
		{
			base.TextMiddlePoint = (xYZ6 + num3 * xYZ).Convert<XYZ>();
		}
		MText item = createTextEntity(base.TextMiddlePoint, measurementText);
		_block.Entities.Add(item);
	}
}
