using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.DateTimeResource;

[ExpressType("IfcDaylightSavingHour", 624)]
[DefinedType(typeof(long))]
public struct IfcDaylightSavingHour : IExpressValueType, IPersist, IExpressIntegerType, IEquatable<long>, IExpressValidatable
{
	public enum IfcDaylightSavingHourClause
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

	public IfcDaylightSavingHour(long val)
	{
		_value = val;
	}

	public IfcDaylightSavingHour(string val)
	{
		_value = Convert.ToInt64(val);
	}

	public static implicit operator IfcDaylightSavingHour(long value)
	{
		return new IfcDaylightSavingHour(value);
	}

	public static implicit operator long(IfcDaylightSavingHour obj)
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
		return ((IfcDaylightSavingHour)obj)._value == _value;
	}

	public bool Equals(long other)
	{
		return this == other;
	}

	public static bool operator ==(IfcDaylightSavingHour obj1, IfcDaylightSavingHour obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcDaylightSavingHour obj1, IfcDaylightSavingHour obj2)
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

	public bool ValidateClause(IfcDaylightSavingHourClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcDaylightSavingHourClause.WR1)
			{
				result = 0 <= (long)this && (long)this <= 2;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcDaylightSavingHour>()?.LogError($"Exception thrown evaluating where-clause 'IfcDaylightSavingHour.{clause}'.", ex);
		}
		return result;
	}

	public IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcDaylightSavingHourClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcDaylightSavingHour.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
