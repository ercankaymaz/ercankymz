using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationAppearanceResource;

namespace Xbim.Ifc4.PresentationOrganizationResource;

[ExpressType("IfcLightSource", 755)]
public abstract class IfcLightSource : IfcGeometricRepresentationItem, IIfcLightSource, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IEquatable<IfcLightSource>
{
	private IfcLabel? _name;

	private IfcColourRgb _lightColour;

	private IfcNormalisedRatioMeasure? _ambientIntensity;

	private IfcNormalisedRatioMeasure? _intensity;

	IfcLabel? IIfcLightSource.Name
	{
		get
		{
			return Name;
		}
		set
		{
			Name = value;
		}
	}

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

	IfcNormalisedRatioMeasure? IIfcLightSource.AmbientIntensity
	{
		get
		{
			return AmbientIntensity;
		}
		set
		{
			AmbientIntensity = value;
		}
	}

	IfcNormalisedRatioMeasure? IIfcLightSource.Intensity
	{
		get
		{
			return Intensity;
		}
		set
		{
			Intensity = value;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcLabel? Name
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
			SetValue(delegate(IfcLabel? v)
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
	public IfcNormalisedRatioMeasure? AmbientIntensity
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
			SetValue(delegate(IfcNormalisedRatioMeasure? v)
			{
				_ambientIntensity = v;
			}, _ambientIntensity, value, "AmbientIntensity", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcNormalisedRatioMeasure? Intensity
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
			SetValue(delegate(IfcNormalisedRatioMeasure? v)
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
