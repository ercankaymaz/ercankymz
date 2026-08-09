using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.PresentationAppearanceResource;

[ExpressType("IfcColourRgb", 27)]
public class IfcColourRgb : IfcColourSpecification, IInstantiableEntity, IPersistEntity, IPersist, IIfcColourRgb, IIfcColourSpecification, IIfcPresentationItem, IfcColour, IfcFillStyleSelect, IIfcFillStyleSelect, IExpressSelectType, IIfcColour, IfcColourOrFactor, IIfcColourOrFactor, IEquatable<IfcColourRgb>
{
	private IfcNormalisedRatioMeasure _red;

	private IfcNormalisedRatioMeasure _green;

	private IfcNormalisedRatioMeasure _blue;

	IfcNormalisedRatioMeasure IIfcColourRgb.Red
	{
		get
		{
			return Red;
		}
		set
		{
			Red = value;
		}
	}

	IfcNormalisedRatioMeasure IIfcColourRgb.Green
	{
		get
		{
			return Green;
		}
		set
		{
			Green = value;
		}
	}

	IfcNormalisedRatioMeasure IIfcColourRgb.Blue
	{
		get
		{
			return Blue;
		}
		set
		{
			Blue = value;
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcNormalisedRatioMeasure Red
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
			SetValue(delegate(IfcNormalisedRatioMeasure v)
			{
				_red = v;
			}, _red, value, "Red", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcNormalisedRatioMeasure Green
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
			SetValue(delegate(IfcNormalisedRatioMeasure v)
			{
				_green = v;
			}, _green, value, "Green", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcNormalisedRatioMeasure Blue
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
			SetValue(delegate(IfcNormalisedRatioMeasure v)
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
