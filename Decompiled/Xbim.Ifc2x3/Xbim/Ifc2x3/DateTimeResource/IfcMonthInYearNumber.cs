using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.DateTimeResource;

[ExpressType("IfcMonthInYearNumber", 193)]
[DefinedType(typeof(long))]
public struct IfcMonthInYearNumber : IExpressValueType, IPersist, IExpressIntegerType, IEquatable<long>, IExpressValidatable
{
	public enum IfcMonthInYearNumberClause
	{
		WR1
	}

	private long _value;

	public object Value => _value;

	long IExpressIntegerType.Value => _value;

	Type IExpressValueType.UnderlyingSystemType => typeof(long);

	public override string ToString()
	{
		return _value.ToString();
	}

	public IfcMonthInYearNumber(long val)
	{
		_value = val;
	}

	public IfcMonthInYearNumber(string val)
	{
		_value = Convert.ToInt64(val);
	}

	public static implicit operator IfcMonthInYearNumber(long value)
	{
		return new IfcMonthInYearNumber(value);
	}

	public static implicit operator long(IfcMonthInYearNumber obj)
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
		return ((IfcMonthInYearNumber)obj)._value == _value;
	}

	public bool Equals(long other)
	{
		return this == other;
	}

	public static bool operator ==(IfcMonthInYearNumber obj1, IfcMonthInYearNumber obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcMonthInYearNumber obj1, IfcMonthInYearNumber obj2)
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

	public bool ValidateClause(IfcMonthInYearNumberClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcMonthInYearNumberClause.WR1)
			{
				result = 1 <= (long)this && (long)this <= 12;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcMonthInYearNumber>()?.LogError($"Exception thrown evaluating where-clause 'IfcMonthInYearNumber.{clause}'.", ex);
		}
		return result;
	}

	public IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcMonthInYearNumberClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcMonthInYearNumber.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
