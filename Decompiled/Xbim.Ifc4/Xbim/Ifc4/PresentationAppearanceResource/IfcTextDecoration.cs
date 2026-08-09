using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.PresentationAppearanceResource;

[ExpressType("IfcTextDecoration", 582)]
[DefinedType(typeof(string))]
public struct IfcTextDecoration : IExpressValueType, IPersist, IExpressStringType, IEquatable<string>, IExpressValidatable
{
	public enum IfcTextDecorationClause
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

	public IfcTextDecoration(string val)
	{
		_value = val;
	}

	public static implicit operator IfcTextDecoration(string value)
	{
		return new IfcTextDecoration(value);
	}

	public static implicit operator string(IfcTextDecoration obj)
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
		return ((IfcTextDecoration)obj)._value == _value;
	}

	public bool Equals(string other)
	{
		return this == (IfcTextDecoration)other;
	}

	public static bool operator ==(IfcTextDecoration obj1, IfcTextDecoration obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcTextDecoration obj1, IfcTextDecoration obj2)
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

	public bool ValidateClause(IfcTextDecorationClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcTextDecorationClause.WR1)
			{
				result = Functions.NewTypesArray("none", "underline", "overline", "line-through", "blink").Contains(this);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcTextDecoration>()?.LogError($"Exception thrown evaluating where-clause 'IfcTextDecoration.{clause}'.", ex);
		}
		return result;
	}

	public IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcTextDecorationClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcTextDecoration.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
