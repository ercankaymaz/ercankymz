using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationAppearanceResource;

namespace Xbim.Ifc4.PresentationOrganizationResource;

[ExpressType("IfcLightSourceGoniometric", 758)]
public class IfcLightSourceGoniometric : IfcLightSource, IInstantiableEntity, IPersistEntity, IPersist, IIfcLightSourceGoniometric, IIfcLightSource, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcLightSourceGoniometric>
{
	private IfcAxis2Placement3D _position;

	private IfcColourRgb _colourAppearance;

	private IfcThermodynamicTemperatureMeasure _colourTemperature;

	private IfcLuminousFluxMeasure _luminousFlux;

	private IfcLightEmissionSourceEnum _lightEmissionSource;

	private IfcLightDistributionDataSourceSelect _lightDistributionDataSource;

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

	IfcThermodynamicTemperatureMeasure IIfcLightSourceGoniometric.ColourTemperature
	{
		get
		{
			return ColourTemperature;
		}
		set
		{
			ColourTemperature = value;
		}
	}

	IfcLuminousFluxMeasure IIfcLightSourceGoniometric.LuminousFlux
	{
		get
		{
			return LuminousFlux;
		}
		set
		{
			LuminousFlux = value;
		}
	}

	IfcLightEmissionSourceEnum IIfcLightSourceGoniometric.LightEmissionSource
	{
		get
		{
			return LightEmissionSource;
		}
		set
		{
			LightEmissionSource = value;
		}
	}

	IIfcLightDistributionDataSourceSelect IIfcLightSourceGoniometric.LightDistributionDataSource
	{
		get
		{
			return LightDistributionDataSource;
		}
		set
		{
			LightDistributionDataSource = value as IfcLightDistributionDataSourceSelect;
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
	public IfcThermodynamicTemperatureMeasure ColourTemperature
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
			SetValue(delegate(IfcThermodynamicTemperatureMeasure v)
			{
				_colourTemperature = v;
			}, _colourTemperature, value, "ColourTemperature", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public IfcLuminousFluxMeasure LuminousFlux
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
			SetValue(delegate(IfcLuminousFluxMeasure v)
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
