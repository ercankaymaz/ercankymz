using System;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Common.Geometry;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4x3.MeasureResource;

[ExpressType("IfcDerivedUnit", 630)]
public class IfcDerivedUnit : PersistEntity, IIfcDerivedUnit, IPersistEntity, IPersist, Xbim.Ifc4.MeasureResource.IfcUnit, IIfcUnit, IExpressSelectType, IInstantiableEntity, IfcUnit, IContainsEntityReferences, IEquatable<IfcDerivedUnit>
{
	private readonly ItemSet<IfcDerivedUnitElement> _elements;

	private IfcDerivedUnitEnum _unitType;

	private IfcLabel? _userDefinedType;

	private IfcLabel? _name;

	[CrossSchemaAttribute(typeof(IIfcDerivedUnit), 1)]
	IItemSet<IIfcDerivedUnitElement> IIfcDerivedUnit.Elements => new ProxyItemSet<IfcDerivedUnitElement, IIfcDerivedUnitElement>(Elements);

	[CrossSchemaAttribute(typeof(IIfcDerivedUnit), 2)]
	Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum IIfcDerivedUnit.UnitType
	{
		get
		{
			return UnitType switch
			{
				IfcDerivedUnitEnum.ACCELERATIONUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.ACCELERATIONUNIT, 
				IfcDerivedUnitEnum.ANGULARVELOCITYUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.ANGULARVELOCITYUNIT, 
				IfcDerivedUnitEnum.AREADENSITYUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.AREADENSITYUNIT, 
				IfcDerivedUnitEnum.COMPOUNDPLANEANGLEUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.COMPOUNDPLANEANGLEUNIT, 
				IfcDerivedUnitEnum.CURVATUREUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.CURVATUREUNIT, 
				IfcDerivedUnitEnum.DYNAMICVISCOSITYUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.DYNAMICVISCOSITYUNIT, 
				IfcDerivedUnitEnum.HEATFLUXDENSITYUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.HEATFLUXDENSITYUNIT, 
				IfcDerivedUnitEnum.HEATINGVALUEUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.HEATINGVALUEUNIT, 
				IfcDerivedUnitEnum.INTEGERCOUNTRATEUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.INTEGERCOUNTRATEUNIT, 
				IfcDerivedUnitEnum.IONCONCENTRATIONUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.IONCONCENTRATIONUNIT, 
				IfcDerivedUnitEnum.ISOTHERMALMOISTURECAPACITYUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.ISOTHERMALMOISTURECAPACITYUNIT, 
				IfcDerivedUnitEnum.KINEMATICVISCOSITYUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.KINEMATICVISCOSITYUNIT, 
				IfcDerivedUnitEnum.LINEARFORCEUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.LINEARFORCEUNIT, 
				IfcDerivedUnitEnum.LINEARMOMENTUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.LINEARMOMENTUNIT, 
				IfcDerivedUnitEnum.LINEARSTIFFNESSUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.LINEARSTIFFNESSUNIT, 
				IfcDerivedUnitEnum.LINEARVELOCITYUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.LINEARVELOCITYUNIT, 
				IfcDerivedUnitEnum.LUMINOUSINTENSITYDISTRIBUTIONUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.LUMINOUSINTENSITYDISTRIBUTIONUNIT, 
				IfcDerivedUnitEnum.MASSDENSITYUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.MASSDENSITYUNIT, 
				IfcDerivedUnitEnum.MASSFLOWRATEUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.MASSFLOWRATEUNIT, 
				IfcDerivedUnitEnum.MASSPERLENGTHUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.MASSPERLENGTHUNIT, 
				IfcDerivedUnitEnum.MODULUSOFELASTICITYUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.MODULUSOFELASTICITYUNIT, 
				IfcDerivedUnitEnum.MODULUSOFLINEARSUBGRADEREACTIONUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.MODULUSOFLINEARSUBGRADEREACTIONUNIT, 
				IfcDerivedUnitEnum.MODULUSOFROTATIONALSUBGRADEREACTIONUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.MODULUSOFROTATIONALSUBGRADEREACTIONUNIT, 
				IfcDerivedUnitEnum.MODULUSOFSUBGRADEREACTIONUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.MODULUSOFSUBGRADEREACTIONUNIT, 
				IfcDerivedUnitEnum.MOISTUREDIFFUSIVITYUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.MOISTUREDIFFUSIVITYUNIT, 
				IfcDerivedUnitEnum.MOLECULARWEIGHTUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.MOLECULARWEIGHTUNIT, 
				IfcDerivedUnitEnum.MOMENTOFINERTIAUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.MOMENTOFINERTIAUNIT, 
				IfcDerivedUnitEnum.PHUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.PHUNIT, 
				IfcDerivedUnitEnum.PLANARFORCEUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.PLANARFORCEUNIT, 
				IfcDerivedUnitEnum.ROTATIONALFREQUENCYUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.ROTATIONALFREQUENCYUNIT, 
				IfcDerivedUnitEnum.ROTATIONALMASSUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.ROTATIONALMASSUNIT, 
				IfcDerivedUnitEnum.ROTATIONALSTIFFNESSUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.ROTATIONALSTIFFNESSUNIT, 
				IfcDerivedUnitEnum.SECTIONAREAINTEGRALUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.SECTIONAREAINTEGRALUNIT, 
				IfcDerivedUnitEnum.SECTIONMODULUSUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.SECTIONMODULUSUNIT, 
				IfcDerivedUnitEnum.SHEARMODULUSUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.SHEARMODULUSUNIT, 
				IfcDerivedUnitEnum.SOUNDPOWERLEVELUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.SOUNDPOWERLEVELUNIT, 
				IfcDerivedUnitEnum.SOUNDPOWERUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.SOUNDPOWERUNIT, 
				IfcDerivedUnitEnum.SOUNDPRESSURELEVELUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.SOUNDPRESSURELEVELUNIT, 
				IfcDerivedUnitEnum.SOUNDPRESSUREUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.SOUNDPRESSUREUNIT, 
				IfcDerivedUnitEnum.SPECIFICHEATCAPACITYUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.SPECIFICHEATCAPACITYUNIT, 
				IfcDerivedUnitEnum.TEMPERATUREGRADIENTUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.TEMPERATUREGRADIENTUNIT, 
				IfcDerivedUnitEnum.TEMPERATURERATEOFCHANGEUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.TEMPERATURERATEOFCHANGEUNIT, 
				IfcDerivedUnitEnum.THERMALADMITTANCEUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.THERMALADMITTANCEUNIT, 
				IfcDerivedUnitEnum.THERMALCONDUCTANCEUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.THERMALCONDUCTANCEUNIT, 
				IfcDerivedUnitEnum.THERMALEXPANSIONCOEFFICIENTUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.THERMALEXPANSIONCOEFFICIENTUNIT, 
				IfcDerivedUnitEnum.THERMALRESISTANCEUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.THERMALRESISTANCEUNIT, 
				IfcDerivedUnitEnum.THERMALTRANSMITTANCEUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.THERMALTRANSMITTANCEUNIT, 
				IfcDerivedUnitEnum.TORQUEUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.TORQUEUNIT, 
				IfcDerivedUnitEnum.VAPORPERMEABILITYUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.VAPORPERMEABILITYUNIT, 
				IfcDerivedUnitEnum.VOLUMETRICFLOWRATEUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.VOLUMETRICFLOWRATEUNIT, 
				IfcDerivedUnitEnum.WARPINGCONSTANTUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.WARPINGCONSTANTUNIT, 
				IfcDerivedUnitEnum.WARPINGMOMENTUNIT => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.WARPINGMOMENTUNIT, 
				IfcDerivedUnitEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.USERDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.ANGULARVELOCITYUNIT:
				UnitType = IfcDerivedUnitEnum.ANGULARVELOCITYUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.AREADENSITYUNIT:
				UnitType = IfcDerivedUnitEnum.AREADENSITYUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.COMPOUNDPLANEANGLEUNIT:
				UnitType = IfcDerivedUnitEnum.COMPOUNDPLANEANGLEUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.DYNAMICVISCOSITYUNIT:
				UnitType = IfcDerivedUnitEnum.DYNAMICVISCOSITYUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.HEATFLUXDENSITYUNIT:
				UnitType = IfcDerivedUnitEnum.HEATFLUXDENSITYUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.INTEGERCOUNTRATEUNIT:
				UnitType = IfcDerivedUnitEnum.INTEGERCOUNTRATEUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.ISOTHERMALMOISTURECAPACITYUNIT:
				UnitType = IfcDerivedUnitEnum.ISOTHERMALMOISTURECAPACITYUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.KINEMATICVISCOSITYUNIT:
				UnitType = IfcDerivedUnitEnum.KINEMATICVISCOSITYUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.LINEARVELOCITYUNIT:
				UnitType = IfcDerivedUnitEnum.LINEARVELOCITYUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.MASSDENSITYUNIT:
				UnitType = IfcDerivedUnitEnum.MASSDENSITYUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.MASSFLOWRATEUNIT:
				UnitType = IfcDerivedUnitEnum.MASSFLOWRATEUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.MOISTUREDIFFUSIVITYUNIT:
				UnitType = IfcDerivedUnitEnum.MOISTUREDIFFUSIVITYUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.MOLECULARWEIGHTUNIT:
				UnitType = IfcDerivedUnitEnum.MOLECULARWEIGHTUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.SPECIFICHEATCAPACITYUNIT:
				UnitType = IfcDerivedUnitEnum.SPECIFICHEATCAPACITYUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.THERMALADMITTANCEUNIT:
				UnitType = IfcDerivedUnitEnum.THERMALADMITTANCEUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.THERMALCONDUCTANCEUNIT:
				UnitType = IfcDerivedUnitEnum.THERMALCONDUCTANCEUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.THERMALRESISTANCEUNIT:
				UnitType = IfcDerivedUnitEnum.THERMALRESISTANCEUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.THERMALTRANSMITTANCEUNIT:
				UnitType = IfcDerivedUnitEnum.THERMALTRANSMITTANCEUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.VAPORPERMEABILITYUNIT:
				UnitType = IfcDerivedUnitEnum.VAPORPERMEABILITYUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.VOLUMETRICFLOWRATEUNIT:
				UnitType = IfcDerivedUnitEnum.VOLUMETRICFLOWRATEUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.ROTATIONALFREQUENCYUNIT:
				UnitType = IfcDerivedUnitEnum.ROTATIONALFREQUENCYUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.TORQUEUNIT:
				UnitType = IfcDerivedUnitEnum.TORQUEUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.MOMENTOFINERTIAUNIT:
				UnitType = IfcDerivedUnitEnum.MOMENTOFINERTIAUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.LINEARMOMENTUNIT:
				UnitType = IfcDerivedUnitEnum.LINEARMOMENTUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.LINEARFORCEUNIT:
				UnitType = IfcDerivedUnitEnum.LINEARFORCEUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.PLANARFORCEUNIT:
				UnitType = IfcDerivedUnitEnum.PLANARFORCEUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.MODULUSOFELASTICITYUNIT:
				UnitType = IfcDerivedUnitEnum.MODULUSOFELASTICITYUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.SHEARMODULUSUNIT:
				UnitType = IfcDerivedUnitEnum.SHEARMODULUSUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.LINEARSTIFFNESSUNIT:
				UnitType = IfcDerivedUnitEnum.LINEARSTIFFNESSUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.ROTATIONALSTIFFNESSUNIT:
				UnitType = IfcDerivedUnitEnum.ROTATIONALSTIFFNESSUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.MODULUSOFSUBGRADEREACTIONUNIT:
				UnitType = IfcDerivedUnitEnum.MODULUSOFSUBGRADEREACTIONUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.ACCELERATIONUNIT:
				UnitType = IfcDerivedUnitEnum.ACCELERATIONUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.CURVATUREUNIT:
				UnitType = IfcDerivedUnitEnum.CURVATUREUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.HEATINGVALUEUNIT:
				UnitType = IfcDerivedUnitEnum.HEATINGVALUEUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.IONCONCENTRATIONUNIT:
				UnitType = IfcDerivedUnitEnum.IONCONCENTRATIONUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.LUMINOUSINTENSITYDISTRIBUTIONUNIT:
				UnitType = IfcDerivedUnitEnum.LUMINOUSINTENSITYDISTRIBUTIONUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.MASSPERLENGTHUNIT:
				UnitType = IfcDerivedUnitEnum.MASSPERLENGTHUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.MODULUSOFLINEARSUBGRADEREACTIONUNIT:
				UnitType = IfcDerivedUnitEnum.MODULUSOFLINEARSUBGRADEREACTIONUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.MODULUSOFROTATIONALSUBGRADEREACTIONUNIT:
				UnitType = IfcDerivedUnitEnum.MODULUSOFROTATIONALSUBGRADEREACTIONUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.PHUNIT:
				UnitType = IfcDerivedUnitEnum.PHUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.ROTATIONALMASSUNIT:
				UnitType = IfcDerivedUnitEnum.ROTATIONALMASSUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.SECTIONAREAINTEGRALUNIT:
				UnitType = IfcDerivedUnitEnum.SECTIONAREAINTEGRALUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.SECTIONMODULUSUNIT:
				UnitType = IfcDerivedUnitEnum.SECTIONMODULUSUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.SOUNDPOWERLEVELUNIT:
				UnitType = IfcDerivedUnitEnum.SOUNDPOWERLEVELUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.SOUNDPOWERUNIT:
				UnitType = IfcDerivedUnitEnum.SOUNDPOWERUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.SOUNDPRESSURELEVELUNIT:
				UnitType = IfcDerivedUnitEnum.SOUNDPRESSURELEVELUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.SOUNDPRESSUREUNIT:
				UnitType = IfcDerivedUnitEnum.SOUNDPRESSUREUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.TEMPERATUREGRADIENTUNIT:
				UnitType = IfcDerivedUnitEnum.TEMPERATUREGRADIENTUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.TEMPERATURERATEOFCHANGEUNIT:
				UnitType = IfcDerivedUnitEnum.TEMPERATURERATEOFCHANGEUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.THERMALEXPANSIONCOEFFICIENTUNIT:
				UnitType = IfcDerivedUnitEnum.THERMALEXPANSIONCOEFFICIENTUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.WARPINGCONSTANTUNIT:
				UnitType = IfcDerivedUnitEnum.WARPINGCONSTANTUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.WARPINGMOMENTUNIT:
				UnitType = IfcDerivedUnitEnum.WARPINGMOMENTUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.USERDEFINED:
				UnitType = IfcDerivedUnitEnum.USERDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcDerivedUnit), 3)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcDerivedUnit.UserDefinedType
	{
		get
		{
			if (!UserDefinedType.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(UserDefinedType.Value);
		}
		set
		{
			UserDefinedType = (value.HasValue ? new IfcLabel?(new IfcLabel(value.Value)) : ((IfcLabel?)null));
		}
	}

	Xbim.Common.Geometry.XbimDimensionalExponents IIfcDerivedUnit.Dimensions => Dimensions;

	public string FullName
	{
		get
		{
			if (UserDefinedType.HasValue)
			{
				IfcLabel? userDefinedType = UserDefinedType;
				if (!userDefinedType.HasValue)
				{
					return null;
				}
				return userDefinedType.GetValueOrDefault();
			}
			List<string> list = new List<string>();
			foreach (IfcDerivedUnitElement element in Elements)
			{
				string text = GetName(element.Unit);
				if (element.Exponent > 0)
				{
					text = ((element.Exponent == 2) ? (text + "²") : ((element.Exponent != 3) ? (text + "Pow:" + element.Exponent) : (text + "³")));
				}
				if (!string.IsNullOrWhiteSpace(text))
				{
					list.Add(text);
				}
			}
			if (list.Count <= 1)
			{
				return string.Empty;
			}
			return string.Join("/", list);
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 1)]
	public IItemSet<IfcDerivedUnitElement> Elements
	{
		get
		{
			if (_activated)
			{
				return _elements;
			}
			Activate();
			return _elements;
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 2)]
	public IfcDerivedUnitEnum UnitType
	{
		get
		{
			if (_activated)
			{
				return _unitType;
			}
			Activate();
			return _unitType;
		}
		set
		{
			SetValue(delegate(IfcDerivedUnitEnum v)
			{
				_unitType = v;
			}, _unitType, value, "UnitType", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcLabel? UserDefinedType
	{
		get
		{
			if (_activated)
			{
				return _userDefinedType;
			}
			Activate();
			return _userDefinedType;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_userDefinedType = v;
			}, _userDefinedType, value, "UserDefinedType", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
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
			}, _name, value, "Name", 4);
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.Class, EntityAttributeType.None, null, null, 0)]
	public Xbim.Common.Geometry.XbimDimensionalExponents Dimensions
	{
		get
		{
			if (this == null)
			{
				throw new NotSupportedException();
			}
			IList<IfcDerivedUnitElement> elements = Elements;
			IList<IfcDerivedUnitElement> obj = elements ?? Elements.ToList();
			if (!obj.Any())
			{
				throw new ArgumentNullException();
			}
			Xbim.Common.Geometry.XbimDimensionalExponents xbimDimensionalExponents = new Xbim.Common.Geometry.XbimDimensionalExponents(0, 0, 0, 0, 0, 0, 0);
			foreach (IfcDerivedUnitElement item in obj)
			{
				IfcDimensionalExponents dimensions = item.Unit.Dimensions;
				if (dimensions == null && item.Unit is IfcConversionBasedUnit)
				{
					IfcNamedUnit ifcNamedUnit = (item.Unit as IfcConversionBasedUnit).ConversionFactor.UnitComponent as IfcNamedUnit;
					if (ifcNamedUnit != null)
					{
						dimensions = ifcNamedUnit.Dimensions;
					}
				}
				if (!(dimensions == null))
				{
					xbimDimensionalExponents.LengthExponent += item.Exponent * dimensions.LengthExponent;
					xbimDimensionalExponents.MassExponent += item.Exponent * dimensions.MassExponent;
					xbimDimensionalExponents.TimeExponent += item.Exponent * dimensions.TimeExponent;
					xbimDimensionalExponents.ElectricCurrentExponent += item.Exponent * dimensions.ElectricCurrentExponent;
					xbimDimensionalExponents.ThermodynamicTemperatureExponent += item.Exponent * dimensions.ThermodynamicTemperatureExponent;
					xbimDimensionalExponents.AmountOfSubstanceExponent += item.Exponent * dimensions.AmountOfSubstanceExponent;
					xbimDimensionalExponents.LuminousIntensityExponent += item.Exponent * dimensions.LuminousIntensityExponent;
				}
			}
			return xbimDimensionalExponents;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcDerivedUnitElement element in Elements)
			{
				yield return element;
			}
		}
	}

	private static string GetName(IfcUnit ifcUnit)
	{
		IfcDerivedUnit ifcDerivedUnit = ifcUnit as IfcDerivedUnit;
		if (ifcDerivedUnit != null)
		{
			return ifcDerivedUnit.FullName;
		}
		IfcNamedUnit ifcNamedUnit = ifcUnit as IfcNamedUnit;
		if (ifcNamedUnit != null)
		{
			return ifcNamedUnit.FullName;
		}
		IfcMonetaryUnit ifcMonetaryUnit = ifcUnit as IfcMonetaryUnit;
		if (!(ifcMonetaryUnit != null))
		{
			return string.Empty;
		}
		return ifcMonetaryUnit.Currency.ToString();
	}

	internal IfcDerivedUnit(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_elements = new ItemSet<IfcDerivedUnitElement>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_elements.InternalAdd((IfcDerivedUnitElement)value.EntityVal);
			break;
		case 1:
			_unitType = (IfcDerivedUnitEnum)Enum.Parse(typeof(IfcDerivedUnitEnum), value.EnumVal, ignoreCase: true);
			break;
		case 2:
			_userDefinedType = value.StringVal;
			break;
		case 3:
			_name = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDerivedUnit other)
	{
		return this == other;
	}
}
