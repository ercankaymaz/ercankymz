using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.PresentationAppearanceResource;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.MeasureResource;

[ExpressType("IfcNormalisedRatioMeasure", 635)]
[DefinedType(typeof(double))]
public struct IfcNormalisedRatioMeasure : IfcColourOrFactor, IExpressSelectType, IPersist, IfcMeasureValue, IfcValue, IExpressValueType, IfcSizeSelect, IExpressRealType, IEquatable<double>, IExpressValidatable
{
	public enum IfcNormalisedRatioMeasureClause
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

	public IfcNormalisedRatioMeasure(double val)
	{
		_value = val;
	}

	public IfcNormalisedRatioMeasure(string val)
	{
		_value = Convert.ToDouble(val, Culture);
	}

	public static implicit operator IfcNormalisedRatioMeasure(double value)
	{
		return new IfcNormalisedRatioMeasure(value);
	}

	public static implicit operator double(IfcNormalisedRatioMeasure obj)
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
		return ((IfcNormalisedRatioMeasure)obj)._value == _value;
	}

	public bool Equals(double other)
	{
		return this == other;
	}

	public static bool operator ==(IfcNormalisedRatioMeasure obj1, IfcNormalisedRatioMeasure obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcNormalisedRatioMeasure obj1, IfcNormalisedRatioMeasure obj2)
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

	public bool ValidateClause(IfcNormalisedRatioMeasureClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcNormalisedRatioMeasureClause.WR1)
			{
				result = 0.0 <= (double)this && (double)this <= 1.0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcNormalisedRatioMeasure>()?.LogError($"Exception thrown evaluating where-clause 'IfcNormalisedRatioMeasure.{clause}'.", ex);
		}
		return result;
	}

	public IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcNormalisedRatioMeasureClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcNormalisedRatioMeasure.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}

	static IfcNormalisedRatioMeasure()
	{
		Culture = new CultureInfo("en-US");
	}
}
