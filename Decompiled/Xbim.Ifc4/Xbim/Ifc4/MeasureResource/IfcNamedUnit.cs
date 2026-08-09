using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.MeasureResource;

[ExpressType("IfcNamedUnit", 93)]
public abstract class IfcNamedUnit : PersistEntity, IIfcNamedUnit, IPersistEntity, IPersist, IfcUnit, IIfcUnit, IExpressSelectType, IEquatable<IfcNamedUnit>, IExpressValidatable
{
	public enum IfcNamedUnitClause
	{
		WR1
	}

	private IfcDimensionalExponents _dimensions;

	private IfcUnitEnum _unitType;

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

	IfcUnitEnum IIfcNamedUnit.UnitType
	{
		get
		{
			return UnitType;
		}
		set
		{
			UnitType = value;
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

	public virtual string FullName
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
