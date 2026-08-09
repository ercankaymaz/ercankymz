using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.PresentationAppearanceResource;

[ExpressType("IfcSpecularRoughness", 772)]
[DefinedType(typeof(double))]
public struct IfcSpecularRoughness : IfcSpecularHighlightSelect, IExpressSelectType, IPersist, IExpressValueType, IExpressRealType, IEquatable<double>, IExpressValidatable
{
	public enum IfcSpecularRoughnessClause
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

	public IfcSpecularRoughness(double val)
	{
		_value = val;
	}

	public IfcSpecularRoughness(string val)
	{
		_value = Convert.ToDouble(val, Culture);
	}

	public static implicit operator IfcSpecularRoughness(double value)
	{
		return new IfcSpecularRoughness(value);
	}

	public static implicit operator double(IfcSpecularRoughness obj)
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
		return ((IfcSpecularRoughness)obj)._value == _value;
	}

	public bool Equals(double other)
	{
		return this == other;
	}

	public static bool operator ==(IfcSpecularRoughness obj1, IfcSpecularRoughness obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcSpecularRoughness obj1, IfcSpecularRoughness obj2)
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

	public bool ValidateClause(IfcSpecularRoughnessClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcSpecularRoughnessClause.WR1)
			{
				result = 0.0 <= (double)this && (double)this <= 1.0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcSpecularRoughness>()?.LogError($"Exception thrown evaluating where-clause 'IfcSpecularRoughness.{clause}'.", ex);
		}
		return result;
	}

	public IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcSpecularRoughnessClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcSpecularRoughness.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}

	static IfcSpecularRoughness()
	{
		Culture = new CultureInfo("en-US");
	}
}
