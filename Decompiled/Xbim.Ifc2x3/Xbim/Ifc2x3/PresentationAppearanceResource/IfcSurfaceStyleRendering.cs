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

[ExpressType("IfcSurfaceStyleRendering", 317)]
public class IfcSurfaceStyleRendering : IfcSurfaceStyleShading, IIfcSurfaceStyleRendering, IIfcSurfaceStyleShading, IIfcPresentationItem, IPersistEntity, IPersist, Xbim.Ifc4.PresentationAppearanceResource.IfcSurfaceStyleElementSelect, IIfcSurfaceStyleElementSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcSurfaceStyleRendering>
{
	private Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure? _transparency;

	private IfcColourOrFactor _diffuseColour;

	private IfcColourOrFactor _transmissionColour;

	private IfcColourOrFactor _diffuseTransmissionColour;

	private IfcColourOrFactor _reflectionColour;

	private IfcColourOrFactor _specularColour;

	private IfcSpecularHighlightSelect _specularHighlight;

	private IfcReflectanceMethodEnum _reflectanceMethod;

	[CrossSchemaAttribute(typeof(IIfcSurfaceStyleRendering), 3)]
	IIfcColourOrFactor IIfcSurfaceStyleRendering.DiffuseColour
	{
		get
		{
			if (DiffuseColour == null)
			{
				return null;
			}
			Xbim.Ifc2x3.PresentationResource.IfcColourRgb ifcColourRgb = DiffuseColour as Xbim.Ifc2x3.PresentationResource.IfcColourRgb;
			if (ifcColourRgb != null)
			{
				return ifcColourRgb;
			}
			if (DiffuseColour is Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure)(object)DiffuseColour);
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				DiffuseColour = null;
				return;
			}
			Xbim.Ifc2x3.PresentationResource.IfcColourRgb ifcColourRgb = value as Xbim.Ifc2x3.PresentationResource.IfcColourRgb;
			if (ifcColourRgb != null)
			{
				DiffuseColour = ifcColourRgb;
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)
			{
				DiffuseColour = new Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)(object)value);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSurfaceStyleRendering), 4)]
	IIfcColourOrFactor IIfcSurfaceStyleRendering.TransmissionColour
	{
		get
		{
			if (TransmissionColour == null)
			{
				return null;
			}
			Xbim.Ifc2x3.PresentationResource.IfcColourRgb ifcColourRgb = TransmissionColour as Xbim.Ifc2x3.PresentationResource.IfcColourRgb;
			if (ifcColourRgb != null)
			{
				return ifcColourRgb;
			}
			if (TransmissionColour is Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure)(object)TransmissionColour);
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				TransmissionColour = null;
				return;
			}
			Xbim.Ifc2x3.PresentationResource.IfcColourRgb ifcColourRgb = value as Xbim.Ifc2x3.PresentationResource.IfcColourRgb;
			if (ifcColourRgb != null)
			{
				TransmissionColour = ifcColourRgb;
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)
			{
				TransmissionColour = new Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)(object)value);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSurfaceStyleRendering), 5)]
	IIfcColourOrFactor IIfcSurfaceStyleRendering.DiffuseTransmissionColour
	{
		get
		{
			if (DiffuseTransmissionColour == null)
			{
				return null;
			}
			Xbim.Ifc2x3.PresentationResource.IfcColourRgb ifcColourRgb = DiffuseTransmissionColour as Xbim.Ifc2x3.PresentationResource.IfcColourRgb;
			if (ifcColourRgb != null)
			{
				return ifcColourRgb;
			}
			if (DiffuseTransmissionColour is Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure)(object)DiffuseTransmissionColour);
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				DiffuseTransmissionColour = null;
				return;
			}
			Xbim.Ifc2x3.PresentationResource.IfcColourRgb ifcColourRgb = value as Xbim.Ifc2x3.PresentationResource.IfcColourRgb;
			if (ifcColourRgb != null)
			{
				DiffuseTransmissionColour = ifcColourRgb;
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)
			{
				DiffuseTransmissionColour = new Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)(object)value);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSurfaceStyleRendering), 6)]
	IIfcColourOrFactor IIfcSurfaceStyleRendering.ReflectionColour
	{
		get
		{
			if (ReflectionColour == null)
			{
				return null;
			}
			Xbim.Ifc2x3.PresentationResource.IfcColourRgb ifcColourRgb = ReflectionColour as Xbim.Ifc2x3.PresentationResource.IfcColourRgb;
			if (ifcColourRgb != null)
			{
				return ifcColourRgb;
			}
			if (ReflectionColour is Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure)(object)ReflectionColour);
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				ReflectionColour = null;
				return;
			}
			Xbim.Ifc2x3.PresentationResource.IfcColourRgb ifcColourRgb = value as Xbim.Ifc2x3.PresentationResource.IfcColourRgb;
			if (ifcColourRgb != null)
			{
				ReflectionColour = ifcColourRgb;
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)
			{
				ReflectionColour = new Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)(object)value);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSurfaceStyleRendering), 7)]
	IIfcColourOrFactor IIfcSurfaceStyleRendering.SpecularColour
	{
		get
		{
			if (SpecularColour == null)
			{
				return null;
			}
			Xbim.Ifc2x3.PresentationResource.IfcColourRgb ifcColourRgb = SpecularColour as Xbim.Ifc2x3.PresentationResource.IfcColourRgb;
			if (ifcColourRgb != null)
			{
				return ifcColourRgb;
			}
			if (SpecularColour is Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure)
			{
				return new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure)(object)SpecularColour);
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				SpecularColour = null;
				return;
			}
			Xbim.Ifc2x3.PresentationResource.IfcColourRgb ifcColourRgb = value as Xbim.Ifc2x3.PresentationResource.IfcColourRgb;
			if (ifcColourRgb != null)
			{
				SpecularColour = ifcColourRgb;
			}
			else if (value is Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)
			{
				SpecularColour = new Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure((Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure)(object)value);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSurfaceStyleRendering), 8)]
	IIfcSpecularHighlightSelect IIfcSurfaceStyleRendering.SpecularHighlight
	{
		get
		{
			if (SpecularHighlight == null)
			{
				return null;
			}
			if (SpecularHighlight is IfcSpecularExponent)
			{
				return new Xbim.Ifc4.PresentationAppearanceResource.IfcSpecularExponent((IfcSpecularExponent)(object)SpecularHighlight);
			}
			if (SpecularHighlight is IfcSpecularRoughness)
			{
				return new Xbim.Ifc4.PresentationAppearanceResource.IfcSpecularRoughness((IfcSpecularRoughness)(object)SpecularHighlight);
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				SpecularHighlight = null;
			}
			else if (value is Xbim.Ifc4.PresentationAppearanceResource.IfcSpecularExponent)
			{
				SpecularHighlight = new IfcSpecularExponent((Xbim.Ifc4.PresentationAppearanceResource.IfcSpecularExponent)(object)value);
			}
			else if (value is Xbim.Ifc4.PresentationAppearanceResource.IfcSpecularRoughness)
			{
				SpecularHighlight = new IfcSpecularRoughness((Xbim.Ifc4.PresentationAppearanceResource.IfcSpecularRoughness)(object)value);
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcSurfaceStyleRendering), 9)]
	Xbim.Ifc4.Interfaces.IfcReflectanceMethodEnum IIfcSurfaceStyleRendering.ReflectanceMethod
	{
		get
		{
			return ReflectanceMethod switch
			{
				IfcReflectanceMethodEnum.BLINN => Xbim.Ifc4.Interfaces.IfcReflectanceMethodEnum.BLINN, 
				IfcReflectanceMethodEnum.FLAT => Xbim.Ifc4.Interfaces.IfcReflectanceMethodEnum.FLAT, 
				IfcReflectanceMethodEnum.GLASS => Xbim.Ifc4.Interfaces.IfcReflectanceMethodEnum.GLASS, 
				IfcReflectanceMethodEnum.MATT => Xbim.Ifc4.Interfaces.IfcReflectanceMethodEnum.MATT, 
				IfcReflectanceMethodEnum.METAL => Xbim.Ifc4.Interfaces.IfcReflectanceMethodEnum.METAL, 
				IfcReflectanceMethodEnum.MIRROR => Xbim.Ifc4.Interfaces.IfcReflectanceMethodEnum.MIRROR, 
				IfcReflectanceMethodEnum.PHONG => Xbim.Ifc4.Interfaces.IfcReflectanceMethodEnum.PHONG, 
				IfcReflectanceMethodEnum.PLASTIC => Xbim.Ifc4.Interfaces.IfcReflectanceMethodEnum.PLASTIC, 
				IfcReflectanceMethodEnum.STRAUSS => Xbim.Ifc4.Interfaces.IfcReflectanceMethodEnum.STRAUSS, 
				IfcReflectanceMethodEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcReflectanceMethodEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcReflectanceMethodEnum.BLINN:
				ReflectanceMethod = IfcReflectanceMethodEnum.BLINN;
				break;
			case Xbim.Ifc4.Interfaces.IfcReflectanceMethodEnum.FLAT:
				ReflectanceMethod = IfcReflectanceMethodEnum.FLAT;
				break;
			case Xbim.Ifc4.Interfaces.IfcReflectanceMethodEnum.GLASS:
				ReflectanceMethod = IfcReflectanceMethodEnum.GLASS;
				break;
			case Xbim.Ifc4.Interfaces.IfcReflectanceMethodEnum.MATT:
				ReflectanceMethod = IfcReflectanceMethodEnum.MATT;
				break;
			case Xbim.Ifc4.Interfaces.IfcReflectanceMethodEnum.METAL:
				ReflectanceMethod = IfcReflectanceMethodEnum.METAL;
				break;
			case Xbim.Ifc4.Interfaces.IfcReflectanceMethodEnum.MIRROR:
				ReflectanceMethod = IfcReflectanceMethodEnum.MIRROR;
				break;
			case Xbim.Ifc4.Interfaces.IfcReflectanceMethodEnum.PHONG:
				ReflectanceMethod = IfcReflectanceMethodEnum.PHONG;
				break;
			case Xbim.Ifc4.Interfaces.IfcReflectanceMethodEnum.PLASTIC:
				ReflectanceMethod = IfcReflectanceMethodEnum.PLASTIC;
				break;
			case Xbim.Ifc4.Interfaces.IfcReflectanceMethodEnum.STRAUSS:
				ReflectanceMethod = IfcReflectanceMethodEnum.STRAUSS;
				break;
			case Xbim.Ifc4.Interfaces.IfcReflectanceMethodEnum.NOTDEFINED:
				ReflectanceMethod = IfcReflectanceMethodEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure? Transparency
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
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcNormalisedRatioMeasure? v)
			{
				_transparency = v;
			}, _transparency, value, "Transparency", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 3)]
	public IfcColourOrFactor DiffuseColour
	{
		get
		{
			if (_activated)
			{
				return _diffuseColour;
			}
			Activate();
			return _diffuseColour;
		}
		set
		{
			if (value is IPersistEntity persistEntity && base.Model != persistEntity.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcColourOrFactor v)
			{
				_diffuseColour = v;
			}, _diffuseColour, value, "DiffuseColour", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 4)]
	public IfcColourOrFactor TransmissionColour
	{
		get
		{
			if (_activated)
			{
				return _transmissionColour;
			}
			Activate();
			return _transmissionColour;
		}
		set
		{
			if (value is IPersistEntity persistEntity && base.Model != persistEntity.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcColourOrFactor v)
			{
				_transmissionColour = v;
			}, _transmissionColour, value, "TransmissionColour", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcColourOrFactor DiffuseTransmissionColour
	{
		get
		{
			if (_activated)
			{
				return _diffuseTransmissionColour;
			}
			Activate();
			return _diffuseTransmissionColour;
		}
		set
		{
			if (value is IPersistEntity persistEntity && base.Model != persistEntity.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcColourOrFactor v)
			{
				_diffuseTransmissionColour = v;
			}, _diffuseTransmissionColour, value, "DiffuseTransmissionColour", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcColourOrFactor ReflectionColour
	{
		get
		{
			if (_activated)
			{
				return _reflectionColour;
			}
			Activate();
			return _reflectionColour;
		}
		set
		{
			if (value is IPersistEntity persistEntity && base.Model != persistEntity.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcColourOrFactor v)
			{
				_reflectionColour = v;
			}, _reflectionColour, value, "ReflectionColour", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcColourOrFactor SpecularColour
	{
		get
		{
			if (_activated)
			{
				return _specularColour;
			}
			Activate();
			return _specularColour;
		}
		set
		{
			if (value is IPersistEntity persistEntity && base.Model != persistEntity.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcColourOrFactor v)
			{
				_specularColour = v;
			}, _specularColour, value, "SpecularColour", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 8)]
	public IfcSpecularHighlightSelect SpecularHighlight
	{
		get
		{
			if (_activated)
			{
				return _specularHighlight;
			}
			Activate();
			return _specularHighlight;
		}
		set
		{
			SetValue(delegate(IfcSpecularHighlightSelect v)
			{
				_specularHighlight = v;
			}, _specularHighlight, value, "SpecularHighlight", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 9)]
	public IfcReflectanceMethodEnum ReflectanceMethod
	{
		get
		{
			if (_activated)
			{
				return _reflectanceMethod;
			}
			Activate();
			return _reflectanceMethod;
		}
		set
		{
			SetValue(delegate(IfcReflectanceMethodEnum v)
			{
				_reflectanceMethod = v;
			}, _reflectanceMethod, value, "ReflectanceMethod", 9);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.SurfaceColour != null)
			{
				yield return base.SurfaceColour;
			}
		}
	}

	internal IfcSurfaceStyleRendering(IModel model, int label, bool activated)
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
			_transparency = value.RealVal;
			break;
		case 2:
			_diffuseColour = (IfcColourOrFactor)value.EntityVal;
			break;
		case 3:
			_transmissionColour = (IfcColourOrFactor)value.EntityVal;
			break;
		case 4:
			_diffuseTransmissionColour = (IfcColourOrFactor)value.EntityVal;
			break;
		case 5:
			_reflectionColour = (IfcColourOrFactor)value.EntityVal;
			break;
		case 6:
			_specularColour = (IfcColourOrFactor)value.EntityVal;
			break;
		case 7:
			_specularHighlight = (IfcSpecularHighlightSelect)value.EntityVal;
			break;
		case 8:
			_reflectanceMethod = (IfcReflectanceMethodEnum)Enum.Parse(typeof(IfcReflectanceMethodEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcSurfaceStyleRendering other)
	{
		return this == other;
	}
}
