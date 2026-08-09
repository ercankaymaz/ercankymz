using System;
using System.Collections.Generic;
using System.Linq;
using ACadSharp.Attributes;
using ACadSharp.Extensions;
using ACadSharp.Objects;
using ACadSharp.Tables;
using CSMath;

namespace ACadSharp.Entities;

[DxfName("INSERT")]
[DxfSubClass("AcDbBlockReference")]
public class Insert : Entity
{
	private double _xscale = 1.0;

	private double _yscale = 1.0;

	private double _zscale = 1.0;

	public SeqendCollection<AttributeEntity> Attributes { get; private set; }

	[DxfCodeValue(DxfReferenceType.Name, new int[] { 2 })]
	public BlockRecord Block { get; internal set; }

	[DxfCodeValue(DxfReferenceType.Optional, new int[] { 70 })]
	public ushort ColumnCount { get; set; } = 1;

	[DxfCodeValue(DxfReferenceType.Optional, new int[] { 44 })]
	public double ColumnSpacing { get; set; }

	[DxfCodeValue(DxfReferenceType.Ignored, new int[] { 66 })]
	public bool HasAttributes => Attributes.Any();

	public override bool HasDynamicSubclass => true;

	[DxfCodeValue(new int[] { 10, 20, 30 })]
	public XYZ InsertPoint { get; set; } = XYZ.Zero;

	public bool IsMultiple
	{
		get
		{
			if (RowCount <= 1)
			{
				return ColumnCount > 1;
			}
			return true;
		}
	}

	[DxfCodeValue(new int[] { 210, 220, 230 })]
	public XYZ Normal { get; set; } = XYZ.AxisZ;

	public override string ObjectName => "INSERT";

	public override ObjectType ObjectType
	{
		get
		{
			if (RowCount > 1 || ColumnCount > 1)
			{
				return ObjectType.MINSERT;
			}
			return ObjectType.INSERT;
		}
	}

	[DxfCodeValue(DxfReferenceType.IsAngle, new int[] { 50 })]
	public double Rotation { get; set; }

	[DxfCodeValue(DxfReferenceType.Optional, new int[] { 71 })]
	public ushort RowCount { get; set; } = 1;

	[DxfCodeValue(DxfReferenceType.Optional, new int[] { 45 })]
	public double RowSpacing { get; set; }

	public SpatialFilter SpatialFilter
	{
		get
		{
			if (base.XDictionary != null && base.XDictionary.TryGetEntry<CadDictionary>("ACAD_FILTER", out var value))
			{
				return value.GetEntry<SpatialFilter>("SPATIAL");
			}
			return null;
		}
		set
		{
			if (base.XDictionary == null)
			{
				CreateExtendedDictionary();
			}
			if (!base.XDictionary.TryGetEntry<CadDictionary>("ACAD_FILTER", out var value2))
			{
				value2 = new CadDictionary("ACAD_FILTER");
				base.XDictionary.Add(value2);
			}
			value2.Remove("SPATIAL");
			value2.Add("SPATIAL", value);
		}
	}

	public override string SubclassMarker
	{
		get
		{
			if (!IsMultiple)
			{
				return "AcDbBlockReference";
			}
			return "AcDbMInsertBlock";
		}
	}

	[DxfCodeValue(new int[] { 41 })]
	public double XScale
	{
		get
		{
			return _xscale;
		}
		set
		{
			if (value.Equals(0.0))
			{
				string text = "XScale";
				throw new ArgumentOutOfRangeException(text, value, text + " value must be none zero.");
			}
			_xscale = value;
		}
	}

	[DxfCodeValue(new int[] { 42 })]
	public double YScale
	{
		get
		{
			return _yscale;
		}
		set
		{
			if (value.Equals(0.0))
			{
				string text = "YScale";
				throw new ArgumentOutOfRangeException(text, value, text + " value must be none zero.");
			}
			_yscale = value;
		}
	}

	[DxfCodeValue(new int[] { 43 })]
	public double ZScale
	{
		get
		{
			return _zscale;
		}
		set
		{
			if (value.Equals(0.0))
			{
				string text = "ZScale";
				throw new ArgumentOutOfRangeException(text, value, text + " value must be none zero.");
			}
			_zscale = value;
		}
	}

	public Insert(BlockRecord block)
		: this()
	{
		if (block == null)
		{
			throw new ArgumentNullException("block");
		}
		if (block.Document != null)
		{
			Block = (BlockRecord)block.Clone();
		}
		else
		{
			Block = block;
		}
		foreach (AttributeDefinition attributeDefinition in block.AttributeDefinitions)
		{
			Attributes.Add(new AttributeEntity(attributeDefinition));
		}
	}

	internal Insert()
	{
		Attributes = new SeqendCollection<AttributeEntity>(this);
	}

	public override void ApplyTransform(Transform transform)
	{
		XYZ insertPoint = transform.ApplyTransform(InsertPoint);
		XYZ xYZ = transformNormal(transform, Normal);
		Matrix3 matrix = Matrix3.ArbitraryAxis(Normal);
		matrix *= Matrix3.RotationZ(Rotation);
		Matrix3 matrix2 = Matrix3.ArbitraryAxis(xYZ).Transpose();
		Matrix3 matrix3 = new Matrix3(transform.Matrix);
		XYZ xYZ2 = matrix * XYZ.AxisX;
		xYZ2 = matrix3 * xYZ2;
		xYZ2 = matrix2 * xYZ2;
		double angle = new XY(xYZ2.X, xYZ2.Y).GetAngle();
		matrix2 = Matrix3.RotationZ(angle).Transpose() * matrix2;
		XYZ xYZ3 = matrix * new XYZ(XScale, YScale, ZScale);
		xYZ3 = matrix3 * xYZ3;
		xYZ3 = matrix2 * xYZ3;
		XYZ xYZ4 = new XYZ(MathHelper.IsZero(xYZ3.X) ? 1E-12 : xYZ3.X, MathHelper.IsZero(xYZ3.Y) ? 1E-12 : xYZ3.Y, MathHelper.IsZero(xYZ3.Z) ? 1E-12 : xYZ3.Z);
		Normal = xYZ;
		InsertPoint = insertPoint;
		XScale = xYZ4.X;
		YScale = xYZ4.Y;
		ZScale = xYZ4.Z;
		Rotation = angle;
		foreach (AttributeEntity attribute in Attributes)
		{
			attribute.ApplyTransform(transform);
		}
	}

	public override CadObject Clone()
	{
		Insert insert = (Insert)base.Clone();
		insert.Block = (BlockRecord)(Block?.Clone());
		insert.Attributes = new SeqendCollection<AttributeEntity>(insert);
		foreach (AttributeEntity attribute in Attributes)
		{
			insert.Attributes.Add((AttributeEntity)attribute.Clone());
		}
		return insert;
	}

	public IEnumerable<Entity> Explode()
	{
		Transform transform = GetTransform();
		foreach (Entity entity2 in Block.Entities)
		{
			if (!(entity2 is Arc arc))
			{
				Entity entity;
				if (entity2 is Circle circle)
				{
					entity = new Ellipse
					{
						MajorAxisEndPoint = XYZ.AxisX * circle.Radius,
						RadiusRatio = 1.0,
						Center = circle.Center,
						Normal = circle.Normal
					};
					entity.MatchProperties(entity2);
				}
				else
				{
					entity = entity2.CloneTyped();
				}
				entity.ApplyTransform(transform);
				yield return entity;
			}
			else
			{
				arc.GetEndVertices(out var start, out var end);
				Arc arc2 = new Arc(transform.ApplyTransform(arc.Center), transform.ApplyTransform(start), transform.ApplyTransform(end), arc.Normal);
				arc2.MatchProperties(entity2);
				yield return arc2;
			}
		}
	}

	public override BoundingBox GetBoundingBox()
	{
		BoundingBox boundingBox = Block.GetBoundingBox();
		XYZ xYZ = new XYZ(XScale, YScale, ZScale);
		XYZ min = boundingBox.Min * xYZ + InsertPoint;
		XYZ max = boundingBox.Max * xYZ + InsertPoint;
		return new BoundingBox(min, max);
	}

	public Transform GetTransform()
	{
		Matrix4 arbitraryAxis = Matrix4.GetArbitraryAxis(Normal);
		Transform transform = Transform.CreateTranslation(InsertPoint);
		Transform transform2 = Transform.CreateRotation(XYZ.AxisZ, Rotation);
		Transform transform3 = Transform.CreateScaling(new XYZ(XScale, YScale, ZScale));
		return new Transform(arbitraryAxis * transform.Matrix * transform2.Matrix * transform3.Matrix);
	}

	public void UpdateAttributes()
	{
		AttributeEntity[] array = Attributes.ToArray();
		foreach (AttributeEntity attributeEntity in array)
		{
			if (!Block.AttributeDefinitions.Select((AttributeDefinition d) => d.Tag).Contains(attributeEntity.Tag))
			{
				Attributes.Remove(attributeEntity);
			}
		}
		foreach (AttributeDefinition attributeDefinition in Block.AttributeDefinitions)
		{
			if (!Attributes.Select((AttributeEntity d) => d.Tag).Contains(attributeDefinition.Tag))
			{
				AttributeEntity item = new AttributeEntity(attributeDefinition);
				Attributes.Add(item);
			}
		}
	}

	internal override void AssignDocument(CadDocument doc)
	{
		base.AssignDocument(doc);
		doc.RegisterCollection(Attributes);
		if (Block != null)
		{
			if (doc.BlockRecords.TryGetValue(Block.Name, out var item))
			{
				Block = item;
			}
			else
			{
				doc.BlockRecords.Add(Block);
			}
		}
	}

	internal override void UnassignDocument()
	{
		Block = (BlockRecord)Block.Clone();
		base.Document.UnregisterCollection(Attributes);
		base.UnassignDocument();
	}
}
