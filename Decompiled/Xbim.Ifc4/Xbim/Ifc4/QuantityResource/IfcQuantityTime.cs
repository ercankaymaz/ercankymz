using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.QuantityResource;

[ExpressType("IfcQuantityTime", 254)]
public class IfcQuantityTime : IfcPhysicalSimpleQuantity, IInstantiableEntity, IPersistEntity, IPersist, IIfcQuantityTime, IIfcPhysicalSimpleQuantity, IIfcPhysicalQuantity, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcQuantityTime>, IExpressValidatable
{
	public enum IfcQuantityTimeClause
	{
		WR21,
		WR22
	}

	private IfcTimeMeasure _timeValue;

	private IfcLabel? _formula;

	IfcTimeMeasure IIfcQuantityTime.TimeValue
	{
		get
		{
			return TimeValue;
		}
		set
		{
			TimeValue = value;
		}
	}

	IfcLabel? IIfcQuantityTime.Formula
	{
		get
		{
			return Formula;
		}
		set
		{
			Formula = value;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcTimeMeasure TimeValue
	{
		get
		{
			if (_activated)
			{
				return _timeValue;
			}
			Activate();
			return _timeValue;
		}
		set
		{
			SetValue(delegate(IfcTimeMeasure v)
			{
				_timeValue = v;
			}, _timeValue, value, "TimeValue", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcLabel? Formula
	{
		get
		{
			if (_activated)
			{
				return _formula;
			}
			Activate();
			return _formula;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_formula = v;
			}, _formula, value, "Formula", 5);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Unit != null)
			{
				yield return base.Unit;
			}
		}
	}

	internal IfcQuantityTime(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 3:
			_timeValue = value.RealVal;
			break;
		case 4:
			_formula = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcQuantityTime other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcQuantityTimeClause clause)
	{
		bool result = false;
		try
		{
			switch (clause)
			{
			case IfcQuantityTimeClause.WR21:
				result = !Functions.EXISTS(base.Unit) || base.Unit.UnitType == IfcUnitEnum.TIMEUNIT;
				break;
			case IfcQuantityTimeClause.WR22:
				result = (double)TimeValue >= 0.0;
				break;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcQuantityTime>()?.LogError($"Exception thrown evaluating where-clause 'IfcQuantityTime.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcQuantityTimeClause.WR21))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcQuantityTime.WR21",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
		if (!ValidateClause(IfcQuantityTimeClause.WR22))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcQuantityTime.WR22",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
