using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.PresentationDefinitionResource;

[ExpressType("IfcBoxAlignment", 188)]
[DefinedType(typeof(string))]
public struct IfcBoxAlignment : IExpressValueType, IPersist, IExpressStringType, IEquatable<string>, IExpressValidatable
{
	public enum IfcBoxAlignmentClause
	{
		WR1
	}

	private string _value;

	public object Value => _value;

	string IExpressStringType.Value => _value;

	Type IExpressValueType.UnderlyingSystemType => typeof(string);

	public override string ToString()
	{
		return _value ?? "";
	}

	public IfcBoxAlignment(string val)
	{
		_value = val;
	}

	public static implicit operator IfcBoxAlignment(string value)
	{
		return new IfcBoxAlignment(value);
	}

	public static implicit operator string(IfcBoxAlignment obj)
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
		return ((IfcBoxAlignment)obj)._value == _value;
	}

	public bool Equals(string other)
	{
		return this == (IfcBoxAlignment)other;
	}

	public static bool operator ==(IfcBoxAlignment obj1, IfcBoxAlignment obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcBoxAlignment obj1, IfcBoxAlignment obj2)
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
		_value = value.StringVal;
	}

	public bool ValidateClause(IfcBoxAlignmentClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcBoxAlignmentClause.WR1)
			{
				result = Functions.NewTypesArray("top-left", "top-middle", "top-right", "middle-left", "center", "middle-right", "bottom-left", "bottom-middle", "bottom-right").Contains(this);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcBoxAlignment>()?.LogError($"Exception thrown evaluating where-clause 'IfcBoxAlignment.{clause}'.", ex);
		}
		return result;
	}

	public IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcBoxAlignmentClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcBoxAlignment.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
