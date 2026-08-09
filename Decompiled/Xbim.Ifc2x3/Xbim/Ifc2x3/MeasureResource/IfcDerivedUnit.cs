using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Common.Geometry;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.MeasureResource;

[ExpressType("IfcDerivedUnit", 630)]
public class IfcDerivedUnit : PersistEntity, IIfcDerivedUnit, IPersistEntity, IPersist, Xbim.Ifc4.MeasureResource.IfcUnit, IIfcUnit, IExpressSelectType, IInstantiableEntity, IfcUnit, IContainsEntityReferences, IEquatable<IfcDerivedUnit>, IExpressValidatable
{
	public enum IfcDerivedUnitClause
	{
		WR1,
		WR2
	}

	private readonly ItemSet<IfcDerivedUnitElement> _elements;

	private IfcDerivedUnitEnum _unitType;

	private IfcLabel? _userDefinedType;

	[CrossSchemaAttribute(typeof(IIfcDerivedUnit), 1)]
	IItemSet<IIfcDerivedUnitElement> IIfcDerivedUnit.Elements => new ProxyItemSet<IfcDerivedUnitElement, IIfcDerivedUnitElement>(Elements);

	[CrossSchemaAttribute(typeof(IIfcDerivedUnit), 2)]
	Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum IIfcDerivedUnit.UnitType
	{
		get
		{
			switch (UnitType)
			{
			case IfcDerivedUnitEnum.ANGULARVELOCITYUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.ANGULARVELOCITYUNIT;
			case IfcDerivedUnitEnum.COMPOUNDPLANEANGLEUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.COMPOUNDPLANEANGLEUNIT;
			case IfcDerivedUnitEnum.DYNAMICVISCOSITYUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.DYNAMICVISCOSITYUNIT;
			case IfcDerivedUnitEnum.HEATFLUXDENSITYUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.HEATFLUXDENSITYUNIT;
			case IfcDerivedUnitEnum.INTEGERCOUNTRATEUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.INTEGERCOUNTRATEUNIT;
			case IfcDerivedUnitEnum.ISOTHERMALMOISTURECAPACITYUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.ISOTHERMALMOISTURECAPACITYUNIT;
			case IfcDerivedUnitEnum.KINEMATICVISCOSITYUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.KINEMATICVISCOSITYUNIT;
			case IfcDerivedUnitEnum.LINEARVELOCITYUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.LINEARVELOCITYUNIT;
			case IfcDerivedUnitEnum.MASSDENSITYUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.MASSDENSITYUNIT;
			case IfcDerivedUnitEnum.MASSFLOWRATEUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.MASSFLOWRATEUNIT;
			case IfcDerivedUnitEnum.MOISTUREDIFFUSIVITYUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.MOISTUREDIFFUSIVITYUNIT;
			case IfcDerivedUnitEnum.MOLECULARWEIGHTUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.MOLECULARWEIGHTUNIT;
			case IfcDerivedUnitEnum.SPECIFICHEATCAPACITYUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.SPECIFICHEATCAPACITYUNIT;
			case IfcDerivedUnitEnum.THERMALADMITTANCEUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.THERMALADMITTANCEUNIT;
			case IfcDerivedUnitEnum.THERMALCONDUCTANCEUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.THERMALCONDUCTANCEUNIT;
			case IfcDerivedUnitEnum.THERMALRESISTANCEUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.THERMALRESISTANCEUNIT;
			case IfcDerivedUnitEnum.THERMALTRANSMITTANCEUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.THERMALTRANSMITTANCEUNIT;
			case IfcDerivedUnitEnum.VAPORPERMEABILITYUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.VAPORPERMEABILITYUNIT;
			case IfcDerivedUnitEnum.VOLUMETRICFLOWRATEUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.VOLUMETRICFLOWRATEUNIT;
			case IfcDerivedUnitEnum.ROTATIONALFREQUENCYUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.ROTATIONALFREQUENCYUNIT;
			case IfcDerivedUnitEnum.TORQUEUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.TORQUEUNIT;
			case IfcDerivedUnitEnum.MOMENTOFINERTIAUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.MOMENTOFINERTIAUNIT;
			case IfcDerivedUnitEnum.LINEARMOMENTUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.LINEARMOMENTUNIT;
			case IfcDerivedUnitEnum.LINEARFORCEUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.LINEARFORCEUNIT;
			case IfcDerivedUnitEnum.PLANARFORCEUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.PLANARFORCEUNIT;
			case IfcDerivedUnitEnum.MODULUSOFELASTICITYUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.MODULUSOFELASTICITYUNIT;
			case IfcDerivedUnitEnum.SHEARMODULUSUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.SHEARMODULUSUNIT;
			case IfcDerivedUnitEnum.LINEARSTIFFNESSUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.LINEARSTIFFNESSUNIT;
			case IfcDerivedUnitEnum.ROTATIONALSTIFFNESSUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.ROTATIONALSTIFFNESSUNIT;
			case IfcDerivedUnitEnum.MODULUSOFSUBGRADEREACTIONUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.MODULUSOFSUBGRADEREACTIONUNIT;
			case IfcDerivedUnitEnum.ACCELERATIONUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.ACCELERATIONUNIT;
			case IfcDerivedUnitEnum.CURVATUREUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.CURVATUREUNIT;
			case IfcDerivedUnitEnum.HEATINGVALUEUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.HEATINGVALUEUNIT;
			case IfcDerivedUnitEnum.IONCONCENTRATIONUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.IONCONCENTRATIONUNIT;
			case IfcDerivedUnitEnum.LUMINOUSINTENSITYDISTRIBUTIONUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.LUMINOUSINTENSITYDISTRIBUTIONUNIT;
			case IfcDerivedUnitEnum.MASSPERLENGTHUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.MASSPERLENGTHUNIT;
			case IfcDerivedUnitEnum.MODULUSOFLINEARSUBGRADEREACTIONUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.MODULUSOFLINEARSUBGRADEREACTIONUNIT;
			case IfcDerivedUnitEnum.MODULUSOFROTATIONALSUBGRADEREACTIONUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.MODULUSOFROTATIONALSUBGRADEREACTIONUNIT;
			case IfcDerivedUnitEnum.PHUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.PHUNIT;
			case IfcDerivedUnitEnum.ROTATIONALMASSUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.ROTATIONALMASSUNIT;
			case IfcDerivedUnitEnum.SECTIONAREAINTEGRALUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.SECTIONAREAINTEGRALUNIT;
			case IfcDerivedUnitEnum.SECTIONMODULUSUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.SECTIONMODULUSUNIT;
			case IfcDerivedUnitEnum.SOUNDPOWERUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.SOUNDPOWERUNIT;
			case IfcDerivedUnitEnum.SOUNDPRESSUREUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.SOUNDPRESSUREUNIT;
			case IfcDerivedUnitEnum.TEMPERATUREGRADIENTUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.TEMPERATUREGRADIENTUNIT;
			case IfcDerivedUnitEnum.THERMALEXPANSIONCOEFFICIENTUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.THERMALEXPANSIONCOEFFICIENTUNIT;
			case IfcDerivedUnitEnum.WARPINGCONSTANTUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.WARPINGCONSTANTUNIT;
			case IfcDerivedUnitEnum.WARPINGMOMENTUNIT:
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.WARPINGMOMENTUNIT;
			case IfcDerivedUnitEnum.USERDEFINED:
				if (UserDefinedType.HasValue)
				{
					switch (UserDefinedType.Value)
					{
					case "AREADENSITYUNIT":
					case "SOUNDPOWERLEVELUNIT":
					case "SOUNDPRESSURELEVELUNIT":
					case "TEMPERATURERATEOFCHANGEUNIT":
						return (Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum)Enum.Parse(typeof(Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum), UserDefinedType.Value);
					}
				}
				return Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.USERDEFINED;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.ANGULARVELOCITYUNIT:
				UnitType = IfcDerivedUnitEnum.ANGULARVELOCITYUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.AREADENSITYUNIT:
				UserDefinedType = Enum.GetName(typeof(Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum), value);
				UnitType = IfcDerivedUnitEnum.USERDEFINED;
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
				UserDefinedType = Enum.GetName(typeof(Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum), value);
				UnitType = IfcDerivedUnitEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.SOUNDPOWERUNIT:
				UnitType = IfcDerivedUnitEnum.SOUNDPOWERUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.SOUNDPRESSURELEVELUNIT:
				UserDefinedType = Enum.GetName(typeof(Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum), value);
				UnitType = IfcDerivedUnitEnum.USERDEFINED;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.SOUNDPRESSUREUNIT:
				UnitType = IfcDerivedUnitEnum.SOUNDPRESSUREUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.TEMPERATUREGRADIENTUNIT:
				UnitType = IfcDerivedUnitEnum.TEMPERATUREGRADIENTUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum.TEMPERATURERATEOFCHANGEUNIT:
				UserDefinedType = Enum.GetName(typeof(Xbim.Ifc4.Interfaces.IfcDerivedUnitEnum), value);
				UnitType = IfcDerivedUnitEnum.USERDEFINED;
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
				xbimDimensionalExponents.LengthExponent += item.Exponent * item.Unit.Dimensions.LengthExponent;
				xbimDimensionalExponents.MassExponent += item.Exponent * item.Unit.Dimensions.MassExponent;
				xbimDimensionalExponents.TimeExponent += item.Exponent * item.Unit.Dimensions.TimeExponent;
				xbimDimensionalExponents.ElectricCurrentExponent += item.Exponent * item.Unit.Dimensions.ElectricCurrentExponent;
				xbimDimensionalExponents.ThermodynamicTemperatureExponent += item.Exponent * item.Unit.Dimensions.ThermodynamicTemperatureExponent;
				xbimDimensionalExponents.AmountOfSubstanceExponent += item.Exponent * item.Unit.Dimensions.AmountOfSubstanceExponent;
				xbimDimensionalExponents.LuminousIntensityExponent += item.Exponent * item.Unit.Dimensions.LuminousIntensityExponent;
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
				string text = element.Unit.Name();
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
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcDerivedUnit other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcDerivedUnitClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcDerivedUnitClause.WR1:
				result = Functions.SIZEOF(Elements) > 1 || (Functions.SIZEOF(Elements) == 1 && Elements.ItemAt(0L).Exponent != 1);
				break;
			case IfcDerivedUnitClause.WR2:
				result = UnitType != IfcDerivedUnitEnum.USERDEFINED || (UnitType == IfcDerivedUnitEnum.USERDEFINED && Functions.EXISTS(UserDefinedType));
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcDerivedUnit>()?.LogError($"Exception thrown evaluating where-clause 'IfcDerivedUnit.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcDerivedUnitClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDerivedUnit.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcDerivedUnitClause.WR2))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDerivedUnit.WR2",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
