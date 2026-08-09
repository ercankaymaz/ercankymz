using System;
using ACadSharp.Attributes;
using ACadSharp.Tables;
using CSMath;

namespace ACadSharp.Entities;

[DxfName("SHAPE")]
[DxfSubClass("AcDbShape")]
public class Shape : Entity
{
	private TextStyle _style;

	public override ObjectType ObjectType => ObjectType.SHAPE;

	public override string ObjectName => "SHAPE";

	public override string SubclassMarker => "AcDbShape";

	[DxfCodeValue(new int[] { 39 })]
	public double Thickness { get; set; }

	[DxfCodeValue(new int[] { 10, 20, 30 })]
	public XYZ InsertionPoint { get; set; }

	[DxfCodeValue(new int[] { 40 })]
	public double Size { get; set; } = 1.0;

	[DxfCodeValue(DxfReferenceType.Name, new int[] { 2 })]
	public TextStyle ShapeStyle
	{
		get
		{
			return _style;
		}
		set
		{
			if (value == null || !value.IsShapeFile)
			{
				throw new ArgumentNullException("value");
			}
			if (base.Document != null)
			{
				_style = CadObject.updateCollection(value, base.Document.TextStyles);
			}
			else
			{
				_style = value;
			}
		}
	}

	[DxfCodeValue(DxfReferenceType.IsAngle, new int[] { 50 })]
	public double Rotation { get; set; }

	[DxfCodeValue(new int[] { 41 })]
	public double RelativeXScale { get; set; } = 1.0;

	[DxfCodeValue(DxfReferenceType.IsAngle, new int[] { 51 })]
	public double ObliqueAngle { get; set; }

	[DxfCodeValue(new int[] { 210, 220, 230 })]
	public XYZ Normal { get; set; } = XYZ.AxisZ;

	internal ushort ShapeIndex { get; set; }

	internal Shape()
	{
	}

	public Shape(TextStyle textStyle)
	{
		ShapeStyle = textStyle;
	}

	public override CadObject Clone()
	{
		Shape obj = (Shape)base.Clone();
		obj.ShapeStyle = (TextStyle)(ShapeStyle?.Clone());
		return obj;
	}

	public override BoundingBox GetBoundingBox()
	{
		return new BoundingBox(InsertionPoint);
	}

	public override void ApplyTransform(Transform transform)
	{
		Normal = transformNormal(transform, Normal);
		InsertionPoint = transform.ApplyTranslation(InsertionPoint);
	}
}
