using System;
using ACadSharp.Attributes;
using ACadSharp.Tables;
using CSMath;

namespace ACadSharp.Entities;

[DxfName("TOLERANCE")]
[DxfSubClass("AcDbFcf")]
public class Tolerance : Entity
{
	private DimensionStyle _style = DimensionStyle.Default;

	[DxfCodeValue(new int[] { 11, 21, 31 })]
	public XYZ Direction { get; set; }

	[DxfCodeValue(new int[] { 10, 20, 30 })]
	public XYZ InsertionPoint { get; set; }

	[DxfCodeValue(new int[] { 210, 220, 230 })]
	public XYZ Normal { get; set; } = XYZ.AxisZ;

	public override string ObjectName => "TOLERANCE";

	public override ObjectType ObjectType => ObjectType.TOLERANCE;

	[DxfCodeValue(DxfReferenceType.Name, new int[] { 3 })]
	public DimensionStyle Style
	{
		get
		{
			return _style;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (base.Document != null)
			{
				_style = CadObject.updateCollection(value, base.Document.DimensionStyles);
			}
			else
			{
				_style = value;
			}
		}
	}

	public override string SubclassMarker => "AcDbFcf";

	[DxfCodeValue(new int[] { 1 })]
	public string Text { get; set; }

	public override void ApplyTransform(Transform transform)
	{
		Normal = transformNormal(transform, Normal);
		Direction = transform.ApplyRotation(Direction);
		InsertionPoint = transform.ApplyTransform(InsertionPoint);
	}

	public override BoundingBox GetBoundingBox()
	{
		return new BoundingBox(InsertionPoint);
	}
}
