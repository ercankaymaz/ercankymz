using System;
using System.Collections.Generic;
using ACadSharp.Attributes;
using ACadSharp.Tables;
using CSMath;

namespace ACadSharp.Entities;

[DxfName("LEADER")]
[DxfSubClass("AcDbLeader")]
public class Leader : Entity
{
	private DimensionStyle _style = DimensionStyle.Default;

	[DxfCodeValue(new int[] { 213, 223, 233 })]
	public XYZ AnnotationOffset { get; set; } = XYZ.Zero;

	[DxfCodeValue(new int[] { 71 })]
	public bool ArrowHeadEnabled { get; set; }

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 340 })]
	public Entity AssociatedAnnotation { get; internal set; }

	[DxfCodeValue(new int[] { 212, 222, 232 })]
	public XYZ BlockOffset { get; set; } = XYZ.Zero;

	[DxfCodeValue(new int[] { 73 })]
	public LeaderCreationType CreationType { get; set; } = LeaderCreationType.CreatedWithoutAnnotation;

	[DxfCodeValue(new int[] { 75 })]
	public bool HasHookline
	{
		get
		{
			bool result = false;
			if (Vertices.Count <= 1)
			{
				return result;
			}
			return MathHelper.IsZero((Vertices[Vertices.Count - 2] - Vertices[Vertices.Count - 1]).AngleBetweenVectors(HorizontalDirection));
		}
	}

	[DxfCodeValue(new int[] { 74 })]
	public HookLineDirection HookLineDirection { get; set; }

	[DxfCodeValue(new int[] { 211, 221, 231 })]
	public XYZ HorizontalDirection { get; set; } = XYZ.AxisX;

	[DxfCodeValue(new int[] { 210, 220, 230 })]
	public XYZ Normal { get; set; } = XYZ.AxisZ;

	public override string ObjectName => "LEADER";

	public override ObjectType ObjectType => ObjectType.LEADER;

	[DxfCodeValue(new int[] { 72 })]
	public LeaderPathType PathType { get; set; }

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

	public override string SubclassMarker => "AcDbLeader";

	[DxfCodeValue(new int[] { 40 })]
	public double TextHeight { get; set; }

	[DxfCodeValue(new int[] { 41 })]
	public double TextWidth { get; set; }

	[DxfCodeValue(DxfReferenceType.Count, new int[] { 76 })]
	[DxfCollectionCodeValue(new int[] { 10, 20, 30 })]
	public List<XYZ> Vertices { get; set; } = new List<XYZ>();

	public override void ApplyTransform(Transform transform)
	{
		Normal = transformNormal(transform, Normal);
		for (int i = 0; i < Vertices.Count; i++)
		{
			Vertices[i] = transform.ApplyTransform(Vertices[i]);
		}
		HorizontalDirection = transform.ApplyRotation(HorizontalDirection).Normalize();
	}

	public override CadObject Clone()
	{
		Leader obj = (Leader)base.Clone();
		obj.Style = (DimensionStyle)(Style?.Clone());
		return obj;
	}

	public override BoundingBox GetBoundingBox()
	{
		return BoundingBox.FromPoints(Vertices);
	}

	internal override void AssignDocument(CadDocument doc)
	{
		base.AssignDocument(doc);
		_style = CadObject.updateCollection(Style, doc.DimensionStyles);
		doc.DimensionStyles.OnRemove += tableOnRemove;
	}

	internal override void UnassignDocument()
	{
		base.Document.DimensionStyles.OnRemove -= tableOnRemove;
		base.UnassignDocument();
		Style = (DimensionStyle)Style.Clone();
	}

	protected override void tableOnRemove(object sender, CollectionChangedEventArgs e)
	{
		base.tableOnRemove(sender, e);
		if (e.Item.Equals(Style))
		{
			Style = base.Document.DimensionStyles["Standard"];
		}
	}
}
