using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationDefinitionResource;

namespace Xbim.Ifc4.PresentationAppearanceResource;

[ExpressType("IfcSurfaceStyleShading", 316)]
public class IfcSurfaceStyleShading : IfcPresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IIfcSurfaceStyleShading, IIfcPresentationItem, IfcSurfaceStyleElementSelect, IIfcSurfaceStyleElementSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcSurfaceStyleShading>
{
	private IfcColourRgb _surfaceColour;

	private IfcNormalisedRatioMeasure? _transparency;

	IIfcColourRgb IIfcSurfaceStyleShading.SurfaceColour
	{
		get
		{
			return SurfaceColour;
		}
		set
		{
			SurfaceColour = value as IfcColourRgb;
		}
	}

	IfcNormalisedRatioMeasure? IIfcSurfaceStyleShading.Transparency
	{
		get
		{
			return Transparency;
		}
		set
		{
			Transparency = value;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public IfcColourRgb SurfaceColour
	{
		get
		{
			if (_activated)
			{
				return _surfaceColour;
			}
			Activate();
			return _surfaceColour;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcColourRgb v)
			{
				_surfaceColour = v;
			}, _surfaceColour, value, "SurfaceColour", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcNormalisedRatioMeasure? Transparency
	{
		get
		{
			if (_activated)
			{
				return _transparency;
			}
			Activate();
			return _transparency;
		}
		set
		{
			SetValue(delegate(IfcNormalisedRatioMeasure? v)
			{
				_transparency = v;
			}, _transparency, value, "Transparency", 2);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (SurfaceColour != null)
			{
				yield return SurfaceColour;
			}
		}
	}

	internal IfcSurfaceStyleShading(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_surfaceColour = (IfcColourRgb)value.EntityVal;
			break;
		case 1:
			_transparency = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSurfaceStyleShading other)
	{
		return this == other;
	}
}
