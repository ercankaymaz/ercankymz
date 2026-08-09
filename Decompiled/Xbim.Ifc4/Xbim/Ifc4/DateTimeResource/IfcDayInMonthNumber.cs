using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.DateTimeResource;

[ExpressType("IfcDayInMonthNumber", 194)]
[DefinedType(typeof(long))]
public struct IfcDayInMonthNumber : IExpressValueType, IPersist, IExpressIntegerType, IEquatable<long>, IExpressValidatable
{
	public enum IfcDayInMonthNumberClause
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

	public IfcDayInMonthNumber(long val)
	{
		_value = val;
	}

	public IfcDayInMonthNumber(string val)
	{
		_value = Convert.ToInt64(val);
	}

	public static implicit operator IfcDayInMonthNumber(long value)
	{
		return new IfcDayInMonthNumber(value);
	}

	public static implicit operator long(IfcDayInMonthNumber obj)
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
		return ((IfcDayInMonthNumber)obj)._value == _value;
	}

	public bool Equals(long other)
	{
		return this == other;
	}

	public static bool operator ==(IfcDayInMonthNumber obj1, IfcDayInMonthNumber obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcDayInMonthNumber obj1, IfcDayInMonthNumber obj2)
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

	public bool ValidateClause(IfcDayInMonthNumberClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcDayInMonthNumberClause.ValidRange)
			{
				result = 1 <= (long)this && (long)this <= 31;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcDayInMonthNumber>()?.LogError($"Exception thrown evaluating where-clause 'IfcDayInMonthNumber.{clause}'.", ex);
		}
		return result;
	}

	public IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcDayInMonthNumberClause.ValidRange))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDayInMonthNumber.ValidRange",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
