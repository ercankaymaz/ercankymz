using System;
using System.Drawing;
using System.Runtime.Serialization;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot;

[Serializable]
public class AttributeReference : IDisposable, ICloneable, IEntity
{
	internal bool needsSynchronization;

	internal AttributeReferenceData Data { get; set; }

	public bool Invisible
	{
		get
		{
			return Data.Invisible;
		}
		set
		{
			Data.Invisible = value;
		}
	}

	public bool Constant
	{
		get
		{
			return Data.Constant;
		}
		set
		{
			Data.Constant = value;
		}
	}

	public bool Verify
	{
		get
		{
			return Data.Verify;
		}
		set
		{
			Data.Verify = value;
		}
	}

	public bool Preset
	{
		get
		{
			return Data.Preset;
		}
		set
		{
			Data.Preset = value;
		}
	}

	public bool NormalMode => Data.NormalMode;

	public string Value
	{
		get
		{
			return Data.TextString;
		}
		set
		{
			Data.TextString = value;
		}
	}

	public double Height
	{
		get
		{
			return Data.Height;
		}
		set
		{
			Data.Height = value;
		}
	}

	public virtual bool Backward
	{
		get
		{
			return Data.Backward;
		}
		set
		{
			Data.Backward = value;
		}
	}

	public virtual bool UpsideDown
	{
		get
		{
			return Data.UpsideDown;
		}
		set
		{
			Data.UpsideDown = value;
		}
	}

	public virtual double WidthFactor
	{
		get
		{
			return Data.WidthFactor;
		}
		set
		{
			Data.WidthFactor = value;
		}
	}

	public Text.alignmentType Alignment
	{
		get
		{
			return Data.Alignment;
		}
		set
		{
			Data.Alignment = value;
		}
	}

	public string StyleName
	{
		get
		{
			return Data.StyleName;
		}
		set
		{
			Data.StyleName = value;
		}
	}

	public Plane Plane
	{
		get
		{
			return Data.Plane;
		}
		set
		{
			Data.Plane = value;
		}
	}

	public Point3D InsertionPoint
	{
		get
		{
			return Data.InsertionPoint;
		}
		set
		{
			Data.InsertionPoint = value;
		}
	}

	public string LayerName
	{
		get
		{
			return Data.LayerName;
		}
		set
		{
			Data.LayerName = value;
		}
	}

	public Color Color
	{
		get
		{
			return Data.Color;
		}
		set
		{
			Data.Color = value;
		}
	}

	public colorMethodType ColorMethod
	{
		get
		{
			return Data.ColorMethod;
		}
		set
		{
			Data.ColorMethod = value;
		}
	}

	public bool Visible
	{
		get
		{
			return Data.Visible;
		}
		set
		{
			Data.Visible = value;
		}
	}

	public colorMethodType LineTypeMethod
	{
		get
		{
			return Data.LineTypeMethod;
		}
		set
		{
			Data.LineTypeMethod = value;
		}
	}

	public string LineTypeName
	{
		get
		{
			return Data.LineTypeName;
		}
		set
		{
			Data.LineTypeName = value;
		}
	}

	public float LineTypeScale
	{
		get
		{
			return Data.LineTypeScale;
		}
		set
		{
			Data.LineTypeScale = value;
		}
	}

	public colorMethodType LineWeightMethod
	{
		get
		{
			return Data.LineWeightMethod;
		}
		set
		{
			Data.LineWeightMethod = value;
		}
	}

	public float LineWeight
	{
		get
		{
			return Data.LineWeight;
		}
		set
		{
			Data.LineWeight = value;
		}
	}

	public AutodeskProperties AutodeskProperties
	{
		get
		{
			return Data.AutodeskProperties;
		}
		set
		{
			Data.AutodeskProperties = value;
		}
	}

	public AttributeReference(double x, double y, double z, string value = "", double height = 0.0)
	{
		Data = new AttributeReferenceData(x, y, z, value, height);
	}

	public AttributeReference(Point3D insPoint, string value, double height)
	{
		Data = new AttributeReferenceData(insPoint, value, height);
	}

	public AttributeReference(Plane pln, Point3D insPoint, string value, double height)
	{
		Data = new AttributeReferenceData(pln, insPoint, value, height);
	}

	public AttributeReference(string value)
	{
		Data = new AttributeReferenceData(Point3D.Origin, value, 10.0);
		needsSynchronization = true;
	}

	public AttributeReference(AttributeReference another)
	{
		Data = (AttributeReferenceData)another.Data.Clone();
		needsSynchronization = another.needsSynchronization;
	}

	internal AttributeReference(AttributeReferenceData _0023_003DzELu0Pss_003D)
	{
		Data = _0023_003DzELu0Pss_003D;
	}

	protected AttributeReference(SerializationInfo info, StreamingContext context)
	{
		Data = new AttributeReferenceData(info, context);
	}

	public void SynchronizeAttributes(devDept.Eyeshot.Entities.Attribute attribute)
	{
		Data._0023_003DzsQAoLomWIpW0(attribute);
		needsSynchronization = false;
	}

	public virtual object Clone()
	{
		return new AttributeReference(this);
	}

	public void Dispose()
	{
		Data.Dispose();
	}

	public virtual AttributeReferenceSurrogate ConvertToSurrogate()
	{
		return new AttributeReferenceSurrogate(this);
	}

	public override string ToString()
	{
		return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937471), Data.TextString);
	}
}
