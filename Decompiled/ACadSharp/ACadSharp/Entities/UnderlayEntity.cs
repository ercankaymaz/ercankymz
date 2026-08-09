using System;
using System.Collections.Generic;
using ACadSharp.Attributes;
using ACadSharp.Extensions;
using ACadSharp.Objects;
using ACadSharp.Objects.Collections;
using CSMath;

namespace ACadSharp.Entities;

[DxfSubClass(null, true)]
public abstract class UnderlayEntity<T> : Entity where T : UnderlayDefinition
{
	private byte _contrast = 100;

	private T _definition;

	private byte _fade;

	private double _xscale = 1.0;

	private double _yscale = 1.0;

	private double _zscale = 1.0;

	[DxfCollectionCodeValue(new int[] { 11, 21 })]
	public List<XY> ClipBoundaryVertices { get; set; } = new List<XY>();

	[DxfCodeValue(new int[] { 281 })]
	public byte Contrast
	{
		get
		{
			return _contrast;
		}
		set
		{
			if (value < 0 || value > 100)
			{
				throw new ArgumentException($"Invalid Brightness value: {value}, must be in range 0-100");
			}
			_contrast = value;
		}
	}

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 340 })]
	public T Definition
	{
		get
		{
			return _definition;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (base.Document != null)
			{
				_definition = CadObject.updateCollection(value, getDocumentCollection(base.Document));
			}
			else
			{
				_definition = value;
			}
		}
	}

	[DxfCodeValue(new int[] { 282 })]
	public byte Fade
	{
		get
		{
			return _fade;
		}
		set
		{
			if (value < 0 || value > 100)
			{
				throw new ArgumentException($"Invalid Brightness value: {value}, must be in range 0-100");
			}
			_fade = value;
		}
	}

	[DxfCodeValue(new int[] { 280 })]
	public UnderlayDisplayFlags Flags { get; set; } = UnderlayDisplayFlags.Default;

	[DxfCodeValue(new int[] { 10, 20, 30 })]
	public XYZ InsertPoint { get; set; }

	[DxfCodeValue(new int[] { 210, 220, 230 })]
	public XYZ Normal { get; set; } = XYZ.AxisZ;

	[DxfCodeValue(DxfReferenceType.IsAngle, new int[] { 50 })]
	public double Rotation { get; set; }

	public override string SubclassMarker => "AcDbUnderlayReference";

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

	public UnderlayEntity(T definition)
	{
		Definition = definition;
	}

	internal UnderlayEntity()
	{
	}

	public override void ApplyTransform(Transform transform)
	{
		XYZ insertPoint = transform.ApplyTransform(InsertPoint);
		XYZ normal = transformNormal(transform, Normal);
		Matrix3 transOW;
		Matrix3 transWO;
		Matrix3 worldMatrix = getWorldMatrix(transform, normal, Normal, out transOW, out transWO);
		List<XY> list = applyRotation(new XY[2]
		{
			XY.AxisX,
			XY.AxisY
		}, Rotation);
		XYZ xYZ = transOW * new XYZ(list[0].X, list[0].Y, 0.0);
		xYZ = worldMatrix * xYZ;
		xYZ = transWO * xYZ;
		XY xY = new XY(xYZ.X, xYZ.Y);
		xYZ = transOW * new XYZ(list[1].X, list[1].Y, 0.0);
		xYZ = worldMatrix * xYZ;
		xYZ = transWO * xYZ;
		new XY(xYZ.X, xYZ.Y);
		double angle = (((Math.Sign(worldMatrix.M00 * worldMatrix.M11 * worldMatrix.M22) >= 0) ? 1 : (-1)) * xY).GetAngle();
		InsertPoint = insertPoint;
		Normal = normal;
		Rotation = angle;
		XScale = transform.Scale.X * XScale;
		YScale = transform.Scale.Y * YScale;
		ZScale = transform.Scale.Z * ZScale;
	}

	public override CadObject Clone()
	{
		UnderlayEntity<T> obj = (UnderlayEntity<T>)base.Clone();
		T definition = Definition;
		obj.Definition = ((definition != null) ? definition.CloneTyped() : null);
		obj.ClipBoundaryVertices = new List<XY>(ClipBoundaryVertices);
		return obj;
	}

	public override BoundingBox GetBoundingBox()
	{
		return BoundingBox.Null;
	}

	internal override void AssignDocument(CadDocument doc)
	{
		base.AssignDocument(doc);
		_definition = CadObject.updateCollection(Definition, getDocumentCollection(doc));
		base.Document.PdfDefinitions.OnRemove += imageDefinitionsOnRemove;
	}

	internal override void UnassignDocument()
	{
		base.Document.ImageDefinitions.OnRemove -= imageDefinitionsOnRemove;
		base.UnassignDocument();
		Definition = (T)(Definition?.Clone());
	}

	protected abstract ObjectDictionaryCollection<T> getDocumentCollection(CadDocument document);

	private void imageDefinitionsOnRemove(object sender, CollectionChangedEventArgs e)
	{
		if (e.Item.Equals(Definition))
		{
			Definition = null;
		}
	}
}
