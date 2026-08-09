using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.DateTimeResource;

[ExpressType("IfcSecondInMinute", 656)]
[DefinedType(typeof(double))]
public struct IfcSecondInMinute : IExpressValueType, IPersist, IExpressRealType, IEquatable<double>, IExpressValidatable
{
	public enum IfcSecondInMinuteClause
	{
		WR1
	}

	private double _value;

	private static readonly CultureInfo Culture;

	public object Value => _value;

	double IExpressRealType.Value => _value;

	Type IExpressValueType.UnderlyingSystemType => typeof(double);

	public override string ToString()
	{
		return _value.ToString("R", Culture);
	}

	public IfcSecondInMinute(double val)
	{
		_value = val;
	}

	public IfcSecondInMinute(string val)
	{
		_value = Convert.ToDouble(val, Culture);
	}

	public static implicit operator IfcSecondInMinute(double value)
	{
		return new IfcSecondInMinute(value);
	}

	public static implicit operator double(IfcSecondInMinute obj)
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
		return ((IfcSecondInMinute)obj)._value == _value;
	}

	public bool Equals(double other)
	{
		return this == other;
	}

	public static bool operator ==(IfcSecondInMinute obj1, IfcSecondInMinute obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcSecondInMinute obj1, IfcSecondInMinute obj2)
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
		_value = value.RealVal;
	}

	public bool ValidateClause(IfcSecondInMinuteClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcSecondInMinuteClause.WR1)
			{
				result = 0.0 <= (double)this && (double)this < 60.0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcSecondInMinute>()?.LogError($"Exception thrown evaluating where-clause 'IfcSecondInMinute.{clause}'.", ex);
		}
		return result;
	}

	public IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcSecondInMinuteClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSecondInMinute.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}

	static IfcSecondInMinute()
	{
		Culture = new CultureInfo("en-US");
	}
}
