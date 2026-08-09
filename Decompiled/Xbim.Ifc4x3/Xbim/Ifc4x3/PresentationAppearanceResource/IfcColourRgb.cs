using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationAppearanceResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.PresentationAppearanceResource;

[ExpressType("IfcColourRgb", 27)]
public class IfcColourRgb : IfcColourSpecification, IIfcColourRgb, IIfcColourSpecification, IIfcPresentationItem, IPersistEntity, IPersist, Xbim.Ifc4.PresentationAppearanceResource.IfcColour, Xbim.Ifc4.PresentationAppearanceResource.IfcFillStyleSelect, IIfcFillStyleSelect, IExpressSelectType, IIfcColour, Xbim.Ifc4.PresentationAppearanceResource.IfcColourOrFactor, IIfcColourOrFactor, IInstantiableEntity, IfcColourOrFactor, IEquatable<IfcColourRgb>
{
	private Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure _red;

	private Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure _green;

	private Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure _blue;

	[CrossSchemaAttribute(typeof(IIfcColourRgb), 2)]
	Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure IIfcColourRgb.Red
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure(Red);
		}
		set
		{
			Red = new Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcColourRgb), 3)]
	Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure IIfcColourRgb.Green
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure(Green);
		}
		set
		{
			Green = new Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcColourRgb), 4)]
	Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure IIfcColourRgb.Blue
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure(Blue);
		}
		set
		{
			Blue = new Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure(value);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure Red
	{
		get
		{
			if (_activated)
			{
				return _red;
			}
			Activate();
			return _red;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure v)
			{
				_red = v;
			}, _red, value, "Red", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure Green
	{
		get
		{
			if (_activated)
			{
				return _green;
			}
			Activate();
			return _green;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure v)
			{
				_green = v;
			}, _green, value, "Green", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure Blue
	{
		get
		{
			if (_activated)
			{
				return _blue;
			}
			Activate();
			return _blue;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure v)
			{
				_blue = v;
			}, _blue, value, "Blue", 4);
		}
	}

	internal IfcColourRgb(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_red = value.RealVal;
			break;
		case 2:
			_green = value.RealVal;
			break;
		case 3:
			_blue = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcColourRgb other)
	{
		return this == other;
	}
}
