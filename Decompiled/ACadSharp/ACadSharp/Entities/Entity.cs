using System;
using System.Collections.Generic;
using ACadSharp.Attributes;
using ACadSharp.Objects;
using ACadSharp.Tables;
using CSMath;

namespace ACadSharp.Entities;

[DxfSubClass("AcDbEntity")]
public abstract class Entity : CadObject, IEntity, IHandledCadObject, IGeometricEntity
{
	private BookColor _bookColor;

	private Layer _layer = Layer.Default;

	private LineType _lineType = LineType.ByLayer;

	[DxfCodeValue(DxfReferenceType.Name, new int[] { 430 })]
	public BookColor BookColor
	{
		get
		{
			return _bookColor;
		}
		set
		{
			if (base.Document != null)
			{
				_bookColor = CadObject.updateCollection(value, base.Document.Colors);
			}
			else
			{
				_bookColor = value;
			}
		}
	}

	[DxfCodeValue(new int[] { 62, 420 })]
	public Color Color { get; set; } = Color.ByLayer;

	[DxfCodeValue(new int[] { 60 })]
	public bool IsInvisible { get; set; }

	[DxfCodeValue(DxfReferenceType.Name, new int[] { 8 })]
	public Layer Layer
	{
		get
		{
			return _layer;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			_layer = CadObject.updateCollection(value, base.Document?.Layers);
		}
	}

	[DxfCodeValue(DxfReferenceType.Name, new int[] { 6 })]
	public LineType LineType
	{
		get
		{
			return _lineType;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			_lineType = CadObject.updateCollection(value, base.Document?.LineTypes);
		}
	}

	[DxfCodeValue(new int[] { 48 })]
	public double LineTypeScale { get; set; } = 1.0;

	[DxfCodeValue(new int[] { 370 })]
	public LineWeightType LineWeight { get; set; } = LineWeightType.ByLayer;

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 347 })]
	public Material Material { get; set; }

	public override string SubclassMarker => "AcDbEntity";

	[DxfCodeValue(new int[] { 440 })]
	public Transparency Transparency { get; set; } = Transparency.ByLayer;

	public Entity()
	{
	}

	public void ApplyRotation(XYZ axis, double rotation)
	{
		Transform transform = Transform.CreateRotation(axis, rotation);
		ApplyTransform(transform);
	}

	public void ApplyScaling(XYZ scale)
	{
		Transform transform = Transform.CreateScaling(scale);
		ApplyTransform(transform);
	}

	public void ApplyScaling(XYZ scale, XYZ origin)
	{
		Transform transform = Transform.CreateScaling(scale, origin);
		ApplyTransform(transform);
	}

	public abstract void ApplyTransform(Transform transform);

	public void ApplyTranslation(XYZ translation)
	{
		Transform transform = Transform.CreateTranslation(translation);
		ApplyTransform(transform);
	}

	public override CadObject Clone()
	{
		Entity obj = (Entity)base.Clone();
		obj.Layer = (Layer)Layer.Clone();
		obj.LineType = (LineType)LineType.Clone();
		obj.Material = (Material)(Material?.Clone());
		return obj;
	}

	public Color GetActiveColor()
	{
		if (Color.IsByLayer)
		{
			return Layer.Color;
		}
		if (Color.IsByBlock && base.Owner is BlockRecord blockRecord)
		{
			return blockRecord.BlockEntity.Color;
		}
		return Color;
	}

	public LineType GetActiveLineType()
	{
		if (LineType.Name.Equals("ByLayer", StringComparison.InvariantCultureIgnoreCase))
		{
			return Layer.LineType;
		}
		if (LineType.Name.Equals("ByBlock", StringComparison.InvariantCultureIgnoreCase) && base.Owner is BlockRecord blockRecord)
		{
			return blockRecord.BlockEntity.LineType;
		}
		return LineType;
	}

	public LineWeightType GetActiveLineWeightType()
	{
		switch (LineWeight)
		{
		case LineWeightType.ByLayer:
			return Layer.LineWeight;
		case LineWeightType.ByBlock:
			if (base.Owner is BlockRecord blockRecord)
			{
				return blockRecord.BlockEntity.LineWeight;
			}
			return LineWeight;
		default:
			return LineWeight;
		}
	}

	public abstract BoundingBox GetBoundingBox();

	public void MatchProperties(IEntity entity)
	{
		if (entity == null)
		{
			throw new ArgumentNullException("entity");
		}
		if (entity.Handle == 0L)
		{
			entity.Layer = (Layer)Layer.Clone();
			entity.LineType = (LineType)LineType.Clone();
		}
		else
		{
			entity.Layer = Layer;
			entity.LineType = LineType;
		}
		entity.Color = Color;
		entity.LineWeight = LineWeight;
		entity.LineTypeScale = LineTypeScale;
		entity.IsInvisible = IsInvisible;
		entity.Transparency = Transparency;
	}

	internal override void AssignDocument(CadDocument doc)
	{
		base.AssignDocument(doc);
		_layer = CadObject.updateCollection(Layer, doc.Layers);
		_lineType = CadObject.updateCollection(LineType, doc.LineTypes);
		doc.Layers.OnRemove += tableOnRemove;
		doc.LineTypes.OnRemove += tableOnRemove;
	}

	internal override void UnassignDocument()
	{
		base.Document.Layers.OnRemove -= tableOnRemove;
		base.Document.LineTypes.OnRemove -= tableOnRemove;
		base.UnassignDocument();
		Layer = (Layer)Layer.Clone();
		LineType = (LineType)LineType.Clone();
	}

	protected List<XY> applyRotation(IEnumerable<XY> points, double rotation)
	{
		if (points == null)
		{
			throw new ArgumentNullException("points");
		}
		if (MathHelper.IsZero(rotation))
		{
			return new List<XY>(points);
		}
		double num = Math.Sin(rotation);
		double num2 = Math.Cos(rotation);
		List<XY> list = new List<XY>();
		foreach (XY point in points)
		{
			list.Add(new XY(point.X * num2 - point.Y * num, point.X * num + point.Y * num2));
		}
		return list;
	}

	protected XYZ applyWorldMatrix(XYZ xyz, Transform transform, Matrix3 transOW, Matrix3 transWO)
	{
		XYZ xyz2 = transOW * xyz;
		xyz2 = transform.ApplyTransform(xyz2);
		return transWO * xyz2;
	}

	protected Matrix3 getWorldMatrix(Transform transform, XYZ normal, XYZ newNormal, out Matrix3 transOW, out Matrix3 transWO)
	{
		transOW = Matrix3.ArbitraryAxis(normal);
		transWO = Matrix3.ArbitraryAxis(newNormal).Transpose();
		return new Matrix3(transform.Matrix);
	}

	protected virtual void tableOnRemove(object sender, CollectionChangedEventArgs e)
	{
		if (e.Item.Equals(Layer))
		{
			Layer = base.Document.Layers["0"];
		}
		if (e.Item.Equals(LineType))
		{
			LineType = base.Document.LineTypes["ByLayer"];
		}
	}

	protected XYZ transformNormal(Transform transform, XYZ normal)
	{
		return transform.ApplyRotation(normal).Normalize();
	}
}
