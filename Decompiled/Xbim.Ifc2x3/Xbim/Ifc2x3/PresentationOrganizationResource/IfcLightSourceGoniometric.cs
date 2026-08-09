using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.ExternalReferenceResource;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.PresentationResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.PresentationOrganizationResource;

[ExpressType("IfcLightSourceGoniometric", 758)]
public class IfcLightSourceGoniometric : IfcLightSource, IIfcLightSourceGoniometric, IIfcLightSource, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, Xbim.Ifc4.PresentationOrganizationResource.IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcLightSourceGoniometric>
{
	private IfcAxis2Placement3D _position;

	private IfcColourRgb _colourAppearance;

	private Xbim.Ifc2x3.MeasureResource.IfcThermodynamicTemperatureMeasure _colourTemperature;

	private Xbim.Ifc2x3.MeasureResource.IfcLuminousFluxMeasure _luminousFlux;

	private IfcLightEmissionSourceEnum _lightEmissionSource;

	private IfcLightDistributionDataSourceSelect _lightDistributionDataSource;

	[CrossSchemaAttribute(typeof(IIfcLightSourceGoniometric), 5)]
	IIfcAxis2Placement3D IIfcLightSourceGoniometric.Position
	{
		get
		{
			return Position;
		}
		set
		{
			Position = value as IfcAxis2Placement3D;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLightSourceGoniometric), 6)]
	IIfcColourRgb IIfcLightSourceGoniometric.ColourAppearance
	{
		get
		{
			return ColourAppearance;
		}
		set
		{
			ColourAppearance = value as IfcColourRgb;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLightSourceGoniometric), 7)]
	Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure IIfcLightSourceGoniometric.ColourTemperature
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcThermodynamicTemperatureMeasure(ColourTemperature);
		}
		set
		{
			ColourTemperature = new Xbim.Ifc2x3.MeasureResource.IfcThermodynamicTemperatureMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLightSourceGoniometric), 8)]
	Xbim.Ifc4.MeasureResource.IfcLuminousFluxMeasure IIfcLightSourceGoniometric.LuminousFlux
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLuminousFluxMeasure(LuminousFlux);
		}
		set
		{
			LuminousFlux = new Xbim.Ifc2x3.MeasureResource.IfcLuminousFluxMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLightSourceGoniometric), 9)]
	Xbim.Ifc4.Interfaces.IfcLightEmissionSourceEnum IIfcLightSourceGoniometric.LightEmissionSource
	{
		get
		{
			return LightEmissionSource switch
			{
				IfcLightEmissionSourceEnum.COMPACTFLUORESCENT => Xbim.Ifc4.Interfaces.IfcLightEmissionSourceEnum.COMPACTFLUORESCENT, 
				IfcLightEmissionSourceEnum.FLUORESCENT => Xbim.Ifc4.Interfaces.IfcLightEmissionSourceEnum.FLUORESCENT, 
				IfcLightEmissionSourceEnum.HIGHPRESSUREMERCURY => Xbim.Ifc4.Interfaces.IfcLightEmissionSourceEnum.HIGHPRESSUREMERCURY, 
				IfcLightEmissionSourceEnum.HIGHPRESSURESODIUM => Xbim.Ifc4.Interfaces.IfcLightEmissionSourceEnum.HIGHPRESSURESODIUM, 
				IfcLightEmissionSourceEnum.LIGHTEMITTINGDIODE => Xbim.Ifc4.Interfaces.IfcLightEmissionSourceEnum.LIGHTEMITTINGDIODE, 
				IfcLightEmissionSourceEnum.LOWPRESSURESODIUM => Xbim.Ifc4.Interfaces.IfcLightEmissionSourceEnum.LOWPRESSURESODIUM, 
				IfcLightEmissionSourceEnum.LOWVOLTAGEHALOGEN => Xbim.Ifc4.Interfaces.IfcLightEmissionSourceEnum.LOWVOLTAGEHALOGEN, 
				IfcLightEmissionSourceEnum.MAINVOLTAGEHALOGEN => Xbim.Ifc4.Interfaces.IfcLightEmissionSourceEnum.MAINVOLTAGEHALOGEN, 
				IfcLightEmissionSourceEnum.METALHALIDE => Xbim.Ifc4.Interfaces.IfcLightEmissionSourceEnum.METALHALIDE, 
				IfcLightEmissionSourceEnum.TUNGSTENFILAMENT => Xbim.Ifc4.Interfaces.IfcLightEmissionSourceEnum.TUNGSTENFILAMENT, 
				IfcLightEmissionSourceEnum.NOTDEFINED => Xbim.Ifc4.Interfaces.IfcLightEmissionSourceEnum.NOTDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcLightEmissionSourceEnum.COMPACTFLUORESCENT:
				LightEmissionSource = IfcLightEmissionSourceEnum.COMPACTFLUORESCENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcLightEmissionSourceEnum.FLUORESCENT:
				LightEmissionSource = IfcLightEmissionSourceEnum.FLUORESCENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcLightEmissionSourceEnum.HIGHPRESSUREMERCURY:
				LightEmissionSource = IfcLightEmissionSourceEnum.HIGHPRESSUREMERCURY;
				break;
			case Xbim.Ifc4.Interfaces.IfcLightEmissionSourceEnum.HIGHPRESSURESODIUM:
				LightEmissionSource = IfcLightEmissionSourceEnum.HIGHPRESSURESODIUM;
				break;
			case Xbim.Ifc4.Interfaces.IfcLightEmissionSourceEnum.LIGHTEMITTINGDIODE:
				LightEmissionSource = IfcLightEmissionSourceEnum.LIGHTEMITTINGDIODE;
				break;
			case Xbim.Ifc4.Interfaces.IfcLightEmissionSourceEnum.LOWPRESSURESODIUM:
				LightEmissionSource = IfcLightEmissionSourceEnum.LOWPRESSURESODIUM;
				break;
			case Xbim.Ifc4.Interfaces.IfcLightEmissionSourceEnum.LOWVOLTAGEHALOGEN:
				LightEmissionSource = IfcLightEmissionSourceEnum.LOWVOLTAGEHALOGEN;
				break;
			case Xbim.Ifc4.Interfaces.IfcLightEmissionSourceEnum.MAINVOLTAGEHALOGEN:
				LightEmissionSource = IfcLightEmissionSourceEnum.MAINVOLTAGEHALOGEN;
				break;
			case Xbim.Ifc4.Interfaces.IfcLightEmissionSourceEnum.METALHALIDE:
				LightEmissionSource = IfcLightEmissionSourceEnum.METALHALIDE;
				break;
			case Xbim.Ifc4.Interfaces.IfcLightEmissionSourceEnum.TUNGSTENFILAMENT:
				LightEmissionSource = IfcLightEmissionSourceEnum.TUNGSTENFILAMENT;
				break;
			case Xbim.Ifc4.Interfaces.IfcLightEmissionSourceEnum.NOTDEFINED:
				LightEmissionSource = IfcLightEmissionSourceEnum.NOTDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcLightSourceGoniometric), 10)]
	IIfcLightDistributionDataSourceSelect IIfcLightSourceGoniometric.LightDistributionDataSource
	{
		get
		{
			if (LightDistributionDataSource == null)
			{
				return null;
			}
			IfcExternalReference ifcExternalReference = LightDistributionDataSource as IfcExternalReference;
			if (ifcExternalReference != null)
			{
				return ifcExternalReference;
			}
			IfcLightIntensityDistribution ifcLightIntensityDistribution = LightDistributionDataSource as IfcLightIntensityDistribution;
			if (ifcLightIntensityDistribution != null)
			{
				return ifcLightIntensityDistribution;
			}
			return null;
		}
		set
		{
			if (value == null)
			{
				LightDistributionDataSource = null;
				return;
			}
			IfcExternalReference ifcExternalReference = value as IfcExternalReference;
			if (ifcExternalReference != null)
			{
				LightDistributionDataSource = ifcExternalReference;
				return;
			}
			IfcLightIntensityDistribution ifcLightIntensityDistribution = value as IfcLightIntensityDistribution;
			if (ifcLightIntensityDistribution != null)
			{
				LightDistributionDataSource = ifcLightIntensityDistribution;
			}
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcAxis2Placement3D Position
	{
		get
		{
			if (_activated)
			{
				return _position;
			}
			Activate();
			return _position;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcAxis2Placement3D v)
			{
				_position = v;
			}, _position, value, "Position", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 8)]
	public IfcColourRgb ColourAppearance
	{
		get
		{
			if (_activated)
			{
				return _colourAppearance;
			}
			Activate();
			return _colourAppearance;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcColourRgb v)
			{
				_colourAppearance = v;
			}, _colourAppearance, value, "ColourAppearance", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public Xbim.Ifc2x3.MeasureResource.IfcThermodynamicTemperatureMeasure ColourTemperature
	{
		get
		{
			if (_activated)
			{
				return _colourTemperature;
			}
			Activate();
			return _colourTemperature;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcThermodynamicTemperatureMeasure v)
			{
				_colourTemperature = v;
			}, _colourTemperature, value, "ColourTemperature", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public Xbim.Ifc2x3.MeasureResource.IfcLuminousFluxMeasure LuminousFlux
	{
		get
		{
			if (_activated)
			{
				return _luminousFlux;
			}
			Activate();
			return _luminousFlux;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc2x3.MeasureResource.IfcLuminousFluxMeasure v)
			{
				_luminousFlux = v;
			}, _luminousFlux, value, "LuminousFlux", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 11)]
	public IfcLightEmissionSourceEnum LightEmissionSource
	{
		get
		{
			if (_activated)
			{
				return _lightEmissionSource;
			}
			Activate();
			return _lightEmissionSource;
		}
		set
		{
			SetValue(delegate(IfcLightEmissionSourceEnum v)
			{
				_lightEmissionSource = v;
			}, _lightEmissionSource, value, "LightEmissionSource", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 12)]
	public IfcLightDistributionDataSourceSelect LightDistributionDataSource
	{
		get
		{
			if (_activated)
			{
				return _lightDistributionDataSource;
			}
			Activate();
			return _lightDistributionDataSource;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcLightDistributionDataSourceSelect v)
			{
				_lightDistributionDataSource = v;
			}, _lightDistributionDataSource, value, "LightDistributionDataSource", 10);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.LightColour != null)
			{
				yield return base.LightColour;
			}
			if (Position != null)
			{
				yield return Position;
			}
			if (ColourAppearance != null)
			{
				yield return ColourAppearance;
			}
			if (LightDistributionDataSource != null)
			{
				yield return LightDistributionDataSource;
			}
		}
	}

	internal IfcLightSourceGoniometric(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 4:
			_position = (IfcAxis2Placement3D)value.EntityVal;
			break;
		case 5:
			_colourAppearance = (IfcColourRgb)value.EntityVal;
			break;
		case 6:
			_colourTemperature = value.RealVal;
			break;
		case 7:
			_luminousFlux = value.RealVal;
			break;
		case 8:
			_lightEmissionSource = (IfcLightEmissionSourceEnum)Enum.Parse(typeof(IfcLightEmissionSourceEnum), value.EnumVal, ignoreCase: true);
			break;
		case 9:
			_lightDistributionDataSource = (IfcLightDistributionDataSourceSelect)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcLightSourceGoniometric other)
	{
		return this == other;
	}
}
