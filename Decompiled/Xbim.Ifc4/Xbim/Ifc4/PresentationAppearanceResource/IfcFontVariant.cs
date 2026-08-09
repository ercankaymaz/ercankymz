using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.PresentationAppearanceResource;

[ExpressType("IfcFontVariant", 403)]
[DefinedType(typeof(string))]
public struct IfcFontVariant : IExpressValueType, IPersist, IExpressStringType, IEquatable<string>, IExpressValidatable
{
	public enum IfcFontVariantClause
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

	public IfcFontVariant(string val)
	{
		_value = val;
	}

	public static implicit operator IfcFontVariant(string value)
	{
		return new IfcFontVariant(value);
	}

	public static implicit operator string(IfcFontVariant obj)
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
		return ((IfcFontVariant)obj)._value == _value;
	}

	public bool Equals(string other)
	{
		return this == (IfcFontVariant)other;
	}

	public static bool operator ==(IfcFontVariant obj1, IfcFontVariant obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcFontVariant obj1, IfcFontVariant obj2)
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

	public bool ValidateClause(IfcFontVariantClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcFontVariantClause.WR1)
			{
				result = Functions.NewTypesArray("normal", "small-caps").Contains(this);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcFontVariant>()?.LogError($"Exception thrown evaluating where-clause 'IfcFontVariant.{clause}'.", ex);
		}
		return result;
	}

	public IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcFontVariantClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcFontVariant.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
