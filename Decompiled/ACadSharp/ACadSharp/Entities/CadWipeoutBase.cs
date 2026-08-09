using System;
using System.Collections.Generic;
using System.Linq;
using ACadSharp.Attributes;
using ACadSharp.Objects;
using CSMath;
using CSUtilities.Extensions;

namespace ACadSharp.Entities;

[DxfSubClass(null, true)]
public abstract class CadWipeoutBase : Entity
{
	private byte _brightness = 50;

	private byte _contrast = 50;

	private ImageDefinition _definition;

	private ImageDefinitionReactor _definitionReactor;

	private byte _fade;

	private ImageDisplayFlags _flags;

	[DxfCodeValue(new int[] { 281 })]
	public byte Brightness
	{
		get
		{
			return _brightness;
		}
		set
		{
			if (value < 0 || value > 100)
			{
				throw new ArgumentException($"Invalid Brightness value: {value}, must be in range 0-100");
			}
			_brightness = value;
		}
	}

	[DxfCodeValue(new int[] { 90 })]
	public int ClassVersion { get; set; }

	[DxfCodeValue(DxfReferenceType.Count, new int[] { 91 })]
	[DxfCollectionCodeValue(new int[] { 14, 24 })]
	public List<XY> ClipBoundaryVertices { get; set; } = new List<XY>();

	[DxfCodeValue(new int[] { 290 })]
	public ClipMode ClipMode { get; set; }

	[DxfCodeValue(new int[] { 280 })]
	public bool ClippingState { get; set; }

	[DxfCodeValue(new int[] { 71 })]
	public ClipType ClipType { get; set; } = ClipType.Rectangular;

	[DxfCodeValue(new int[] { 282 })]
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
	public virtual ImageDefinition Definition
	{
		get
		{
			return _definition;
		}
		set
		{
			if (base.Document != null)
			{
				_definition = CadObject.updateCollection(value, base.Document.ImageDefinitions);
			}
			else
			{
				_definition = value;
			}
		}
	}

	[DxfCodeValue(new int[] { 283 })]
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

	[DxfCodeValue(new int[] { 70 })]
	public ImageDisplayFlags Flags
	{
		get
		{
			return _flags;
		}
		set
		{
			_flags = value;
		}
	}

	[DxfCodeValue(new int[] { 10, 20, 30 })]
	public XYZ InsertPoint { get; set; }

	public bool ShowImage
	{
		get
		{
			return Flags.HasFlag(ImageDisplayFlags.ShowImage);
		}
		set
		{
			if (value)
			{
				_flags.AddFlag(ImageDisplayFlags.ShowImage);
			}
			else
			{
				_flags.RemoveFlag(ImageDisplayFlags.ShowImage);
			}
		}
	}

	[DxfCodeValue(new int[] { 13, 23 })]
	public XY Size { get; set; }

	[DxfCodeValue(new int[] { 11, 21, 31 })]
	public XYZ UVector { get; set; } = XYZ.AxisX;

	[DxfCodeValue(new int[] { 12, 22, 32 })]
	public XYZ VVector { get; set; } = XYZ.AxisY;

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 360 })]
	internal ImageDefinitionReactor DefinitionReactor
	{
		get
		{
			return _definitionReactor;
		}
		set
		{
			_definitionReactor = value;
			_definitionReactor.Owner = this;
		}
	}

	public override void ApplyTransform(Transform transform)
	{
		InsertPoint = transform.ApplyTransform(InsertPoint);
		UVector = transform.ApplyTransform(UVector);
		VVector = transform.ApplyTransform(VVector);
	}

	public override CadObject Clone()
	{
		CadWipeoutBase obj = (CadWipeoutBase)base.Clone();
		obj.Definition = (ImageDefinition)(Definition?.Clone());
		return obj;
	}

	public override BoundingBox GetBoundingBox()
	{
		if (!ClipBoundaryVertices.Any())
		{
			return BoundingBox.Null;
		}
		double x = ClipBoundaryVertices.Select((XY v) => v.X).Min();
		double y = ClipBoundaryVertices.Select((XY v) => v.Y).Min();
		XYZ min = new XYZ(x, y, 0.0) + InsertPoint;
		double x2 = ClipBoundaryVertices.Select((XY v) => v.X).Max();
		double y2 = ClipBoundaryVertices.Select((XY v) => v.Y).Max();
		XYZ max = new XYZ(x2, y2, 0.0) + InsertPoint;
		return new BoundingBox(min, max);
	}

	internal override void AssignDocument(CadDocument doc)
	{
		base.AssignDocument(doc);
		_definition = CadObject.updateCollection(Definition, doc.ImageDefinitions);
		base.Document.ImageDefinitions.OnRemove += imageDefinitionsOnRemove;
	}

	internal override void UnassignDocument()
	{
		base.Document.ImageDefinitions.OnRemove -= imageDefinitionsOnRemove;
		base.UnassignDocument();
		_definition = (ImageDefinition)(Definition?.Clone());
	}

	private void imageDefinitionsOnRemove(object sender, CollectionChangedEventArgs e)
	{
		if (e.Item.Equals(Definition))
		{
			_definition = null;
		}
	}
}
