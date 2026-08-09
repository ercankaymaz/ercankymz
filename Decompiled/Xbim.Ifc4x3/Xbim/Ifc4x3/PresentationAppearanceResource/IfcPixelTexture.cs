using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.PresentationAppearanceResource;

[ExpressType("IfcPixelTexture", 728)]
public class IfcPixelTexture : IfcSurfaceTexture, IIfcPixelTexture, IIfcSurfaceTexture, IIfcPresentationItem, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcPixelTexture>
{
	private Xbim.Ifc4x3.MeasureResource.IfcInteger _width;

	private Xbim.Ifc4x3.MeasureResource.IfcInteger _height;

	private Xbim.Ifc4x3.MeasureResource.IfcInteger _colourComponents;

	private readonly ItemSet<Xbim.Ifc4x3.MeasureResource.IfcBinary> _pixel;

	[CrossSchemaAttribute(typeof(IIfcPixelTexture), 6)]
	Xbim.Ifc4.MeasureResource.IfcInteger IIfcPixelTexture.Width
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcInteger(Width);
		}
		set
		{
			Width = new Xbim.Ifc4x3.MeasureResource.IfcInteger(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPixelTexture), 7)]
	Xbim.Ifc4.MeasureResource.IfcInteger IIfcPixelTexture.Height
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcInteger(Height);
		}
		set
		{
			Height = new Xbim.Ifc4x3.MeasureResource.IfcInteger(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPixelTexture), 8)]
	Xbim.Ifc4.MeasureResource.IfcInteger IIfcPixelTexture.ColourComponents
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcInteger(ColourComponents);
		}
		set
		{
			ColourComponents = new Xbim.Ifc4x3.MeasureResource.IfcInteger(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPixelTexture), 9)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcBinary> IIfcPixelTexture.Pixel => new ProxyValueSet<Xbim.Ifc4x3.MeasureResource.IfcBinary, Xbim.Ifc4.MeasureResource.IfcBinary>(Pixel, (Xbim.Ifc4x3.MeasureResource.IfcBinary s) => new Xbim.Ifc4.MeasureResource.IfcBinary(s), (Xbim.Ifc4.MeasureResource.IfcBinary t) => new Xbim.Ifc4x3.MeasureResource.IfcBinary(t));

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public Xbim.Ifc4x3.MeasureResource.IfcInteger Width
	{
		get
		{
			if (_activated)
			{
				return _width;
			}
			Activate();
			return _width;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcInteger v)
			{
				_width = v;
			}, _width, value, "Width", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public Xbim.Ifc4x3.MeasureResource.IfcInteger Height
	{
		get
		{
			if (_activated)
			{
				return _height;
			}
			Activate();
			return _height;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcInteger v)
			{
				_height = v;
			}, _height, value, "Height", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public Xbim.Ifc4x3.MeasureResource.IfcInteger ColourComponents
	{
		get
		{
			if (_activated)
			{
				return _colourComponents;
			}
			Activate();
			return _colourComponents;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcInteger v)
			{
				_colourComponents = v;
			}, _colourComponents, value, "ColourComponents", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 11)]
	public IItemSet<Xbim.Ifc4x3.MeasureResource.IfcBinary> Pixel
	{
		get
		{
			if (_activated)
			{
				return _pixel;
			}
			Activate();
			return _pixel;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.TextureTransform != null)
			{
				yield return base.TextureTransform;
			}
		}
	}

	internal IfcPixelTexture(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_pixel = new ItemSet<Xbim.Ifc4x3.MeasureResource.IfcBinary>(this, 0, 9);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 5:
			_width = value.IntegerVal;
			break;
		case 6:
			_height = value.IntegerVal;
			break;
		case 7:
			_colourComponents = value.IntegerVal;
			break;
		case 8:
			_pixel.InternalAdd(value.HexadecimalVal);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPixelTexture other)
	{
		return this == other;
	}
}
