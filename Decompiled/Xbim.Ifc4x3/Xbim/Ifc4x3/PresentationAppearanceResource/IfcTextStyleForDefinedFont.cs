using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.PresentationDefinitionResource;

namespace Xbim.Ifc4x3.PresentationAppearanceResource;

[ExpressType("IfcTextStyleForDefinedFont", 611)]
public class IfcTextStyleForDefinedFont : IfcPresentationItem, IIfcTextStyleForDefinedFont, IIfcPresentationItem, IPersistEntity, IPersist, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcTextStyleForDefinedFont>
{
	private IfcColour _colour;

	private IfcColour _backgroundColour;

	[CrossSchemaAttribute(typeof(IIfcTextStyleForDefinedFont), 1)]
	IIfcColour IIfcTextStyleForDefinedFont.Colour
	{
		get
		{
			if (Colour == null)
			{
				return null;
			}
			IfcColourSpecification ifcColourSpecification = Colour as IfcColourSpecification;
			if (ifcColourSpecification != null)
			{
				return ifcColourSpecification;
			}
			IfcPreDefinedColour ifcPreDefinedColour = Colour as IfcPreDefinedColour;
			if (ifcPreDefinedColour != null)
			{
				return ifcPreDefinedColour;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				Colour = null;
				return;
			}
			IfcColourSpecification ifcColourSpecification = value as IfcColourSpecification;
			if (ifcColourSpecification != null)
			{
				Colour = ifcColourSpecification;
				return;
			}
			IfcPreDefinedColour ifcPreDefinedColour = value as IfcPreDefinedColour;
			if (ifcPreDefinedColour != null)
			{
				Colour = ifcPreDefinedColour;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcTextStyleForDefinedFont), 2)]
	IIfcColour IIfcTextStyleForDefinedFont.BackgroundColour
	{
		get
		{
			if (BackgroundColour == null)
			{
				return null;
			}
			IfcColourSpecification ifcColourSpecification = BackgroundColour as IfcColourSpecification;
			if (ifcColourSpecification != null)
			{
				return ifcColourSpecification;
			}
			IfcPreDefinedColour ifcPreDefinedColour = BackgroundColour as IfcPreDefinedColour;
			if (ifcPreDefinedColour != null)
			{
				return ifcPreDefinedColour;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				BackgroundColour = null;
				return;
			}
			IfcColourSpecification ifcColourSpecification = value as IfcColourSpecification;
			if (ifcColourSpecification != null)
			{
				BackgroundColour = ifcColourSpecification;
				return;
			}
			IfcPreDefinedColour ifcPreDefinedColour = value as IfcPreDefinedColour;
			if (ifcPreDefinedColour != null)
			{
				BackgroundColour = ifcPreDefinedColour;
			}
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
