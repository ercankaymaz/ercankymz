using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.ConstraintResource;
using Xbim.Ifc2x3.PropertyResource;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.DateTimeResource;

[ExpressType("IfcCalendarDate", 407)]
public class IfcCalendarDate : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IfcDateTimeSelect, IfcMetricValueSelect, IExpressSelectType, IfcObjectReferenceSelect, IEquatable<IfcCalendarDate>, IExpressValidatable
{
	public enum IfcCalendarDateClause
	{
		WR21
	}

	private IfcDayInMonthNumber _dayComponent;

	private IfcMonthInYearNumber _monthComponent;

	private IfcYearNumber _yearComponent;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcDayInMonthNumber DayComponent
	{
		get
		{
			if (_activated)
			{
				return _dayComponent;
			}
			Activate();
			return _dayComponent;
		}
		set
		{
			SetValue(delegate(IfcDayInMonthNumber v)
			{
				_dayComponent = v;
			}, _dayComponent, value, "DayComponent", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcMonthInYearNumber MonthComponent
	{
		get
		{
			if (_activated)
			{
				return _monthComponent;
			}
			Activate();
			return _monthComponent;
		}
		set
		{
			SetValue(delegate(IfcMonthInYearNumber v)
			{
				_monthComponent = v;
			}, _monthComponent, value, "MonthComponent", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcYearNumber YearComponent
	{
		get
		{
			if (_activated)
			{
				return _yearComponent;
			}
			Activate();
			return _yearComponent;
		}
		set
		{
			SetValue(delegate(IfcYearNumber v)
			{
				_yearComponent = v;
			}, _yearComponent, value, "YearComponent", 3);
		}
	}

	internal IfcCalendarDate(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_dayComponent = value.IntegerVal;
			break;
		case 1:
			_monthComponent = value.IntegerVal;
			break;
		case 2:
			_yearComponent = value.IntegerVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCalendarDate other)
	{
		return this == other;
	}

	public override string ToString()
	{
		return $"{YearComponent}-{MonthComponent}-{DayComponent}";
	}

	public bool ValidateClause(IfcCalendarDateClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcCalendarDateClause.WR21)
			{
				result = Functions.IfcValidCalendarDate(this);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcCalendarDate>()?.LogError($"Exception thrown evaluating where-clause 'IfcCalendarDate.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcCalendarDateClause.WR21))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCalendarDate.WR21",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
