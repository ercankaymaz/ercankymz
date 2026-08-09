using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.MeasureResource;

[ExpressType("IfcNamedUnit", 93)]
public abstract class IfcNamedUnit : PersistEntity, IIfcNamedUnit, IPersistEntity, IPersist, Xbim.Ifc4.MeasureResource.IfcUnit, IIfcUnit, IExpressSelectType, IfcUnit, IEquatable<IfcNamedUnit>, IExpressValidatable
{
	public enum IfcNamedUnitClause
	{
		WR1
	}

	private IfcDimensionalExponents _dimensions;

	private IfcUnitEnum _unitType;

	[CrossSchemaAttribute(typeof(IIfcNamedUnit), 1)]
	IIfcDimensionalExponents IIfcNamedUnit.Dimensions
	{
		get
		{
			return Dimensions;
		}
		set
		{
			Dimensions = value as IfcDimensionalExponents;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcNamedUnit), 2)]
	Xbim.Ifc4.Interfaces.IfcUnitEnum IIfcNamedUnit.UnitType
	{
		get
		{
			return UnitType switch
			{
				IfcUnitEnum.ABSORBEDDOSEUNIT => Xbim.Ifc4.Interfaces.IfcUnitEnum.ABSORBEDDOSEUNIT, 
				IfcUnitEnum.AMOUNTOFSUBSTANCEUNIT => Xbim.Ifc4.Interfaces.IfcUnitEnum.AMOUNTOFSUBSTANCEUNIT, 
				IfcUnitEnum.AREAUNIT => Xbim.Ifc4.Interfaces.IfcUnitEnum.AREAUNIT, 
				IfcUnitEnum.DOSEEQUIVALENTUNIT => Xbim.Ifc4.Interfaces.IfcUnitEnum.DOSEEQUIVALENTUNIT, 
				IfcUnitEnum.ELECTRICCAPACITANCEUNIT => Xbim.Ifc4.Interfaces.IfcUnitEnum.ELECTRICCAPACITANCEUNIT, 
				IfcUnitEnum.ELECTRICCHARGEUNIT => Xbim.Ifc4.Interfaces.IfcUnitEnum.ELECTRICCHARGEUNIT, 
				IfcUnitEnum.ELECTRICCONDUCTANCEUNIT => Xbim.Ifc4.Interfaces.IfcUnitEnum.ELECTRICCONDUCTANCEUNIT, 
				IfcUnitEnum.ELECTRICCURRENTUNIT => Xbim.Ifc4.Interfaces.IfcUnitEnum.ELECTRICCURRENTUNIT, 
				IfcUnitEnum.ELECTRICRESISTANCEUNIT => Xbim.Ifc4.Interfaces.IfcUnitEnum.ELECTRICRESISTANCEUNIT, 
				IfcUnitEnum.ELECTRICVOLTAGEUNIT => Xbim.Ifc4.Interfaces.IfcUnitEnum.ELECTRICVOLTAGEUNIT, 
				IfcUnitEnum.ENERGYUNIT => Xbim.Ifc4.Interfaces.IfcUnitEnum.ENERGYUNIT, 
				IfcUnitEnum.FORCEUNIT => Xbim.Ifc4.Interfaces.IfcUnitEnum.FORCEUNIT, 
				IfcUnitEnum.FREQUENCYUNIT => Xbim.Ifc4.Interfaces.IfcUnitEnum.FREQUENCYUNIT, 
				IfcUnitEnum.ILLUMINANCEUNIT => Xbim.Ifc4.Interfaces.IfcUnitEnum.ILLUMINANCEUNIT, 
				IfcUnitEnum.INDUCTANCEUNIT => Xbim.Ifc4.Interfaces.IfcUnitEnum.INDUCTANCEUNIT, 
				IfcUnitEnum.LENGTHUNIT => Xbim.Ifc4.Interfaces.IfcUnitEnum.LENGTHUNIT, 
				IfcUnitEnum.LUMINOUSFLUXUNIT => Xbim.Ifc4.Interfaces.IfcUnitEnum.LUMINOUSFLUXUNIT, 
				IfcUnitEnum.LUMINOUSINTENSITYUNIT => Xbim.Ifc4.Interfaces.IfcUnitEnum.LUMINOUSINTENSITYUNIT, 
				IfcUnitEnum.MAGNETICFLUXDENSITYUNIT => Xbim.Ifc4.Interfaces.IfcUnitEnum.MAGNETICFLUXDENSITYUNIT, 
				IfcUnitEnum.MAGNETICFLUXUNIT => Xbim.Ifc4.Interfaces.IfcUnitEnum.MAGNETICFLUXUNIT, 
				IfcUnitEnum.MASSUNIT => Xbim.Ifc4.Interfaces.IfcUnitEnum.MASSUNIT, 
				IfcUnitEnum.PLANEANGLEUNIT => Xbim.Ifc4.Interfaces.IfcUnitEnum.PLANEANGLEUNIT, 
				IfcUnitEnum.POWERUNIT => Xbim.Ifc4.Interfaces.IfcUnitEnum.POWERUNIT, 
				IfcUnitEnum.PRESSUREUNIT => Xbim.Ifc4.Interfaces.IfcUnitEnum.PRESSUREUNIT, 
				IfcUnitEnum.RADIOACTIVITYUNIT => Xbim.Ifc4.Interfaces.IfcUnitEnum.RADIOACTIVITYUNIT, 
				IfcUnitEnum.SOLIDANGLEUNIT => Xbim.Ifc4.Interfaces.IfcUnitEnum.SOLIDANGLEUNIT, 
				IfcUnitEnum.THERMODYNAMICTEMPERATUREUNIT => Xbim.Ifc4.Interfaces.IfcUnitEnum.THERMODYNAMICTEMPERATUREUNIT, 
				IfcUnitEnum.TIMEUNIT => Xbim.Ifc4.Interfaces.IfcUnitEnum.TIMEUNIT, 
				IfcUnitEnum.VOLUMEUNIT => Xbim.Ifc4.Interfaces.IfcUnitEnum.VOLUMEUNIT, 
				IfcUnitEnum.USERDEFINED => Xbim.Ifc4.Interfaces.IfcUnitEnum.USERDEFINED, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
		set
		{
			switch (value)
			{
			case Xbim.Ifc4.Interfaces.IfcUnitEnum.ABSORBEDDOSEUNIT:
				UnitType = IfcUnitEnum.ABSORBEDDOSEUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitEnum.AMOUNTOFSUBSTANCEUNIT:
				UnitType = IfcUnitEnum.AMOUNTOFSUBSTANCEUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitEnum.AREAUNIT:
				UnitType = IfcUnitEnum.AREAUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitEnum.DOSEEQUIVALENTUNIT:
				UnitType = IfcUnitEnum.DOSEEQUIVALENTUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitEnum.ELECTRICCAPACITANCEUNIT:
				UnitType = IfcUnitEnum.ELECTRICCAPACITANCEUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitEnum.ELECTRICCHARGEUNIT:
				UnitType = IfcUnitEnum.ELECTRICCHARGEUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitEnum.ELECTRICCONDUCTANCEUNIT:
				UnitType = IfcUnitEnum.ELECTRICCONDUCTANCEUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitEnum.ELECTRICCURRENTUNIT:
				UnitType = IfcUnitEnum.ELECTRICCURRENTUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitEnum.ELECTRICRESISTANCEUNIT:
				UnitType = IfcUnitEnum.ELECTRICRESISTANCEUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitEnum.ELECTRICVOLTAGEUNIT:
				UnitType = IfcUnitEnum.ELECTRICVOLTAGEUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitEnum.ENERGYUNIT:
				UnitType = IfcUnitEnum.ENERGYUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitEnum.FORCEUNIT:
				UnitType = IfcUnitEnum.FORCEUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitEnum.FREQUENCYUNIT:
				UnitType = IfcUnitEnum.FREQUENCYUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitEnum.ILLUMINANCEUNIT:
				UnitType = IfcUnitEnum.ILLUMINANCEUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitEnum.INDUCTANCEUNIT:
				UnitType = IfcUnitEnum.INDUCTANCEUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitEnum.LENGTHUNIT:
				UnitType = IfcUnitEnum.LENGTHUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitEnum.LUMINOUSFLUXUNIT:
				UnitType = IfcUnitEnum.LUMINOUSFLUXUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitEnum.LUMINOUSINTENSITYUNIT:
				UnitType = IfcUnitEnum.LUMINOUSINTENSITYUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitEnum.MAGNETICFLUXDENSITYUNIT:
				UnitType = IfcUnitEnum.MAGNETICFLUXDENSITYUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitEnum.MAGNETICFLUXUNIT:
				UnitType = IfcUnitEnum.MAGNETICFLUXUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitEnum.MASSUNIT:
				UnitType = IfcUnitEnum.MASSUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitEnum.PLANEANGLEUNIT:
				UnitType = IfcUnitEnum.PLANEANGLEUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitEnum.POWERUNIT:
				UnitType = IfcUnitEnum.POWERUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitEnum.PRESSUREUNIT:
				UnitType = IfcUnitEnum.PRESSUREUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitEnum.RADIOACTIVITYUNIT:
				UnitType = IfcUnitEnum.RADIOACTIVITYUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitEnum.SOLIDANGLEUNIT:
				UnitType = IfcUnitEnum.SOLIDANGLEUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitEnum.THERMODYNAMICTEMPERATUREUNIT:
				UnitType = IfcUnitEnum.THERMODYNAMICTEMPERATUREUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitEnum.TIMEUNIT:
				UnitType = IfcUnitEnum.TIMEUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitEnum.VOLUMEUNIT:
				UnitType = IfcUnitEnum.VOLUMEUNIT;
				break;
			case Xbim.Ifc4.Interfaces.IfcUnitEnum.USERDEFINED:
				UnitType = IfcUnitEnum.USERDEFINED;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public virtual IfcDimensionalExponents Dimensions
	{
		get
		{
			if (_activated)
			{
				return _dimensions;
			}
			Activate();
			return _dimensions;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcDimensionalExponents v)
			{
				_dimensions = v;
			}, _dimensions, value, "Dimensions", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Enum, EntityAttributeType.None, null, null, 2)]
	public IfcUnitEnum UnitType
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
			SetValue(delegate(IfcUnitEnum v)
			{
				_unitType = v;
			}, _unitType, value, "UnitType", 2);
		}
	}

	public string FullName
	{
		get
		{
			IfcSIUnit ifcSIUnit = this as IfcSIUnit;
			if (ifcSIUnit != null)
			{
				return ifcSIUnit.FullName;
			}
			IfcConversionBasedUnit ifcConversionBasedUnit = this as IfcConversionBasedUnit;
			if (ifcConversionBasedUnit != null)
			{
				return ifcConversionBasedUnit.Name;
			}
			IfcContextDependentUnit ifcContextDependentUnit = this as IfcContextDependentUnit;
			if (ifcContextDependentUnit != null)
			{
				return ifcContextDependentUnit.Name;
			}
			return string.Empty;
		}
	}

	public string Symbol
	{
		get
		{
			IfcSIUnit ifcSIUnit = this as IfcSIUnit;
			if (ifcSIUnit != null)
			{
				return ifcSIUnit.Symbol;
			}
			IfcConversionBasedUnit ifcConversionBasedUnit = this as IfcConversionBasedUnit;
			if (ifcConversionBasedUnit != null)
			{
				return ifcConversionBasedUnit.Name;
			}
			IfcContextDependentUnit ifcContextDependentUnit = this as IfcContextDependentUnit;
			if (ifcContextDependentUnit != null)
			{
				return ifcContextDependentUnit.Name;
			}
			return string.Empty;
		}
	}

	internal IfcNamedUnit(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_dimensions = (IfcDimensionalExponents)value.EntityVal;
			break;
		case 1:
			_unitType = (IfcUnitEnum)Enum.Parse(typeof(IfcUnitEnum), value.EnumVal, ignoreCase: true);
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcNamedUnit other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcNamedUnitClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcNamedUnitClause.WR1)
			{
				result = Functions.IfcCorrectDimensions(UnitType, Dimensions);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcNamedUnit>()?.LogError($"Exception thrown evaluating where-clause 'IfcNamedUnit.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcNamedUnitClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcNamedUnit.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
