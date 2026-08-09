using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.PresentationResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.PresentationOrganizationResource;

[ExpressType("IfcLightSource", 755)]
public abstract class IfcLightSource : IfcGeometricRepresentationItem, IIfcLightSource, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, Xbim.Ifc4.PresentationOrganizationResource.IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IEquatable<IfcLightSource>
{
	private Xbim.Ifc2x3.MeasureResource.IfcLabel? _name;

	private IfcColourRgb _lightColour;

	private Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure? _ambientIntensity;

	private Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure? _intensity;

	[CrossSchemaAttribute(typeof(IIfcLightSource), 1)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcLightSource.Name
	{
		get
		{
			if (!Name.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Name.Value);
		}
		set
		{
			Name = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcLabel?(new Xbim.Ifc2x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLightSource), 2)]
	IIfcColourRgb IIfcLightSource.LightColour
	{
		get
		{
			return LightColour;
		}
		set
		{
			LightColour = value as IfcColourRgb;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLightSource), 3)]
	Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure? IIfcLightSource.AmbientIntensity
	{
		get
		{
			if (!AmbientIntensity.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure(AmbientIntensity.Value);
		}
		set
		{
			AmbientIntensity = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLightSource), 4)]
	Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure? IIfcLightSource.Intensity
	{
		get
		{
			if (!Intensity.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure(Intensity.Value);
		}
		set
		{
			Intensity = (value.HasValue ? new Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure?(new Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure(value.Value)) : ((Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure?)null));
		}
	}

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc2x3.MeasureResource.IfcLabel? Name
	{
		get
		{
			if (_activated)
			{
				return _name;
			}
			Activate();
			return _name;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLabel? v)
			{
				_name = v;
			}, _name, value, "Name", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcColourRgb LightColour
	{
		get
		{
			if (_activated)
			{
				return _lightColour;
			}
			Activate();
			return _lightColour;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcColourRgb v)
			{
				_lightColour = v;
			}, _lightColour, value, "LightColour", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure? AmbientIntensity
	{
		get
		{
			if (_activated)
			{
				return _ambientIntensity;
			}
			Activate();
			return _ambientIntensity;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure? v)
			{
				_ambientIntensity = v;
			}, _ambientIntensity, value, "AmbientIntensity", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure? Intensity
	{
		get
		{
			if (_activated)
			{
				return _intensity;
			}
			Activate();
			return _intensity;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure? v)
			{
				_intensity = v;
			}, _intensity, value, "Intensity", 4);
		}
	}

	internal IfcLightSource(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_name = value.StringVal;
			break;
		case 1:
			_lightColour = (IfcColourRgb)value.EntityVal;
			break;
		case 2:
			_ambientIntensity = value.RealVal;
			break;
		case 3:
			_intensity = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcLightSource other)
	{
		return this == other;
	}
}
