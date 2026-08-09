using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.PresentationResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationAppearanceResource;

namespace Xbim.Ifc2x3.PresentationAppearanceResource;

[ExpressType("IfcSurfaceStyleShading", 316)]
public class IfcSurfaceStyleShading : PersistEntity, IIfcSurfaceStyleShading, IIfcPresentationItem, IPersistEntity, IPersist, Xbim.Ifc4.PresentationAppearanceResource.IfcSurfaceStyleElementSelect, IIfcSurfaceStyleElementSelect, IExpressSelectType, IInstantiableEntity, IfcSurfaceStyleElementSelect, IContainsEntityReferences, IEquatable<IfcSurfaceStyleShading>
{
	private Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure? _transparency;

	private Xbim.Ifc2x3.PresentationResource.IfcColourRgb _surfaceColour;

	[CrossSchemaAttribute(typeof(IIfcSurfaceStyleShading), 1)]
	IIfcColourRgb IIfcSurfaceStyleShading.SurfaceColour
	{
		get
		{
			return SurfaceColour;
		}
		set
		{
			SurfaceColour = value as Xbim.Ifc2x3.PresentationResource.IfcColourRgb;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSurfaceStyleShading), 2)]
	Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure? IIfcSurfaceStyleShading.Transparency
	{
		get
		{
			IfcSurfaceStyleRendering ifcSurfaceStyleRendering = this as IfcSurfaceStyleRendering;
			if (ifcSurfaceStyleRendering == null)
			{
				return _transparency;
			}
			if (ifcSurfaceStyleRendering.Transparency.HasValue)
			{
				return new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure(ifcSurfaceStyleRendering.Transparency.Value);
			}
			return null;
		}
		set
		{
			IfcSurfaceStyleRendering ifcSurfaceStyleRendering = this as IfcSurfaceStyleRendering;
			if (ifcSurfaceStyleRendering == null)
			{
				SetValue(delegate(Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure? v)
				{
					_transparency = v;
				}, _transparency, value, "Transparency", -2);
				return;
			}
			if (value.HasValue)
			{
				ifcSurfaceStyleRendering.Transparency = new Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure(value.Value);
			}
			else
			{
				ifcSurfaceStyleRendering.Transparency = null;
			}
			NotifyPropertyChanged("Transparency");
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc2x3.PresentationResource.IfcColourRgb SurfaceColour
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
			SetValue(delegate(Xbim.Ifc2x3.PresentationResource.IfcColourRgb v)
			{
				_surfaceColour = v;
			}, _surfaceColour, value, "SurfaceColour", 1);
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
		if (propIndex == 0)
		{
			_surfaceColour = (Xbim.Ifc2x3.PresentationResource.IfcColourRgb)value.EntityVal;
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcSurfaceStyleShading other)
	{
		return this == other;
	}
}
