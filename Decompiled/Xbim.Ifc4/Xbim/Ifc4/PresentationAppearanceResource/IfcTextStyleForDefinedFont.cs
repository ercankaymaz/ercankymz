using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationDefinitionResource;

namespace Xbim.Ifc4.PresentationAppearanceResource;

[ExpressType("IfcTextStyleForDefinedFont", 611)]
public class IfcTextStyleForDefinedFont : IfcPresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IIfcTextStyleForDefinedFont, IIfcPresentationItem, IContainsEntityReferences, IEquatable<IfcTextStyleForDefinedFont>
{
	private IfcColour _colour;

	private IfcColour _backgroundColour;

	IIfcColour IIfcTextStyleForDefinedFont.Colour
	{
		get
		{
			return Colour;
		}
		set
		{
			Colour = value as IfcColour;
		}
	}

	IIfcColour IIfcTextStyleForDefinedFont.BackgroundColour
	{
		get
		{
			return BackgroundColour;
		}
		set
		{
			BackgroundColour = value as IfcColour;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public IfcColour Colour
	{
		get
		{
			if (_activated)
			{
				return _colour;
			}
			Activate();
			return _colour;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcColour v)
			{
				_colour = v;
			}, _colour, value, "Colour", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcColour BackgroundColour
	{
		get
		{
			if (_activated)
			{
				return _backgroundColour;
			}
			Activate();
			return _backgroundColour;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcColour v)
			{
				_backgroundColour = v;
			}, _backgroundColour, value, "BackgroundColour", 2);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Colour != null)
			{
				yield return Colour;
			}
			if (BackgroundColour != null)
			{
				yield return BackgroundColour;
			}
		}
	}

	internal IfcTextStyleForDefinedFont(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_colour = (IfcColour)value.EntityVal;
			break;
		case 1:
			_backgroundColour = (IfcColour)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcTextStyleForDefinedFont other)
	{
		return this == other;
	}
}
