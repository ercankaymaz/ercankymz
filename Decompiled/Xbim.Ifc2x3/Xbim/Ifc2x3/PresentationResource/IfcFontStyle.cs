using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.PresentationResource;

[ExpressType("IfcFontStyle", 434)]
[DefinedType(typeof(string))]
public struct IfcFontStyle : IExpressValueType, IPersist, IExpressStringType, IEquatable<string>, IExpressValidatable
{
	public enum IfcFontStyleClause
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

	public IfcFontStyle(string val)
	{
		_value = val;
	}

	public static implicit operator IfcFontStyle(string value)
	{
		return new IfcFontStyle(value);
	}

	public static implicit operator string(IfcFontStyle obj)
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
		return ((IfcFontStyle)obj)._value == _value;
	}

	public bool Equals(string other)
	{
		return this == (IfcFontStyle)other;
	}

	public static bool operator ==(IfcFontStyle obj1, IfcFontStyle obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcFontStyle obj1, IfcFontStyle obj2)
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

	public bool ValidateClause(IfcFontStyleClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcFontStyleClause.WR1)
			{
				result = Functions.NewArray<string>("normal", "italic", "oblique").Contains(this);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcFontStyle>()?.LogError($"Exception thrown evaluating where-clause 'IfcFontStyle.{clause}'.", ex);
		}
		return result;
	}

	public IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcFontStyleClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcFontStyle.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
