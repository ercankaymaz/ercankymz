using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.MaterialResource;

[ExpressType("IfcCardinalPointReference", 987)]
[DefinedType(typeof(long))]
public struct IfcCardinalPointReference : IExpressValueType, IPersist, IExpressIntegerType, IEquatable<long>, IExpressValidatable
{
	public enum IfcCardinalPointReferenceClause
	{
		GreaterThanZero
	}

	private long _value;

	public object Value => _value;

	long IExpressIntegerType.Value => _value;

	Type IExpressValueType.UnderlyingSystemType => typeof(long);

	public override string ToString()
	{
		return _value.ToString();
	}

	public IfcCardinalPointReference(long val)
	{
		_value = val;
	}

	public IfcCardinalPointReference(string val)
	{
		_value = Convert.ToInt64(val);
	}

	public static implicit operator IfcCardinalPointReference(long value)
	{
		return new IfcCardinalPointReference(value);
	}

	public static implicit operator long(IfcCardinalPointReference obj)
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
		return ((IfcCardinalPointReference)obj)._value == _value;
	}

	public bool Equals(long other)
	{
		return this == other;
	}

	public static bool operator ==(IfcCardinalPointReference obj1, IfcCardinalPointReference obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcCardinalPointReference obj1, IfcCardinalPointReference obj2)
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

	public bool ValidateClause(IfcCardinalPointReferenceClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcCardinalPointReferenceClause.GreaterThanZero)
			{
				result = (long)this > 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcCardinalPointReference>()?.LogError($"Exception thrown evaluating where-clause 'IfcCardinalPointReference.{clause}'.", ex);
		}
		return result;
	}

	public IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcCardinalPointReferenceClause.GreaterThanZero))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcCardinalPointReference.GreaterThanZero",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
