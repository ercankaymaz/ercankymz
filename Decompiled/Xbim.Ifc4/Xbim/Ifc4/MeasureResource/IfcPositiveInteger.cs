using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.ConstraintResource;
using Xbim.Ifc4.CostResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.MeasureResource;

[ExpressType("IfcPositiveInteger", 995)]
[DefinedType(typeof(long))]
public struct IfcPositiveInteger : IfcSimpleValue, IfcValue, IfcAppliedValueSelect, IIfcAppliedValueSelect, IExpressSelectType, IPersist, IfcMetricValueSelect, IIfcMetricValueSelect, IIfcValue, IExpressValueType, IIfcSimpleValue, IExpressIntegerType, IEquatable<long>, IExpressValidatable
{
	public enum IfcPositiveIntegerClause
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

	public IfcPositiveInteger(long val)
	{
		_value = val;
	}

	public IfcPositiveInteger(string val)
	{
		_value = Convert.ToInt64(val);
	}

	public static implicit operator IfcPositiveInteger(long value)
	{
		return new IfcPositiveInteger(value);
	}

	public static implicit operator long(IfcPositiveInteger obj)
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
		return ((IfcPositiveInteger)obj)._value == _value;
	}

	public bool Equals(long other)
	{
		return this == other;
	}

	public static bool operator ==(IfcPositiveInteger obj1, IfcPositiveInteger obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcPositiveInteger obj1, IfcPositiveInteger obj2)
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

	public bool ValidateClause(IfcPositiveIntegerClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcPositiveIntegerClause.WR1)
			{
				result = (long)this > 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcPositiveInteger>()?.LogError($"Exception thrown evaluating where-clause 'IfcPositiveInteger.{clause}'.", ex);
		}
		return result;
	}

	public IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcPositiveIntegerClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPositiveInteger.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
