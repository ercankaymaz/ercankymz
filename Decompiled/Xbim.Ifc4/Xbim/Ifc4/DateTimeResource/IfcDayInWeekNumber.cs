using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.DateTimeResource;

[ExpressType("IfcDayInWeekNumber", 990)]
[DefinedType(typeof(long))]
public struct IfcDayInWeekNumber : IExpressValueType, IPersist, IExpressIntegerType, IEquatable<long>, IExpressValidatable
{
	public enum IfcDayInWeekNumberClause
	{
		ValidRange
	}

	private long _value;

	public object Value => _value;

	long IExpressIntegerType.Value => _value;

	Type IExpressValueType.UnderlyingSystemType => typeof(long);

	public override string ToString()
	{
		return _value.ToString();
	}

	public IfcDayInWeekNumber(long val)
	{
		_value = val;
	}

	public IfcDayInWeekNumber(string val)
	{
		_value = Convert.ToInt64(val);
	}

	public static implicit operator IfcDayInWeekNumber(long value)
	{
		return new IfcDayInWeekNumber(value);
	}

	public static implicit operator long(IfcDayInWeekNumber obj)
	{
		return obj._value;
	}

	public override bool Equals(object obj)
	{
		if (obj == null && Value == null)
		{
			return true;
		}
		if (obj == null)
		{
			return false;
		}
		if (GetType() != obj.GetType())
		{
			return false;
		}
		return ((IfcDayInWeekNumber)obj)._value == _value;
	}

	public bool Equals(long other)
	{
		return this == other;
	}

	public static bool operator ==(IfcDayInWeekNumber obj1, IfcDayInWeekNumber obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcDayInWeekNumber obj1, IfcDayInWeekNumber obj2)
	{
		return !object.Equals(obj1, obj2);
	}

	public override int GetHashCode()
	{
		if (Value == null)
		{
			return base.GetHashCode();
		}
		return _value.GetHashCode();
	}

	void IPersist.Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex != 0)
		{
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
		_value = value.IntegerVal;
	}

	public bool ValidateClause(IfcDayInWeekNumberClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcDayInWeekNumberClause.ValidRange)
			{
				result = 1 <= (long)this && (long)this <= 7;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcDayInWeekNumber>()?.LogError($"Exception thrown evaluating where-clause 'IfcDayInWeekNumber.{clause}'.", ex);
		}
		return result;
	}

	public IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcDayInWeekNumberClause.ValidRange))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDayInWeekNumber.ValidRange",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
