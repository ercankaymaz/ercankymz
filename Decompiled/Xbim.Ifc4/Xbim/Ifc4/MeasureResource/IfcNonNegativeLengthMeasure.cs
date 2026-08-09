using System;
using System.Collections.Generic;
using System.Globalization;
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

[ExpressType("IfcNonNegativeLengthMeasure", 994)]
[DefinedType(typeof(double))]
public struct IfcNonNegativeLengthMeasure : IIfcLengthMeasure, IExpressRealType, IfcMeasureValue, IfcValue, IfcAppliedValueSelect, IIfcAppliedValueSelect, IExpressSelectType, IPersist, IfcMetricValueSelect, IIfcMetricValueSelect, IIfcValue, IExpressValueType, IIfcMeasureValue, IEquatable<double>, IExpressValidatable
{
	public enum IfcNonNegativeLengthMeasureClause
	{
		NotNegative
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

	public IfcNonNegativeLengthMeasure(double val)
	{
		_value = val;
	}

	public IfcNonNegativeLengthMeasure(string val)
	{
		_value = Convert.ToDouble(val, Culture);
	}

	public static implicit operator IfcNonNegativeLengthMeasure(double value)
	{
		return new IfcNonNegativeLengthMeasure(value);
	}

	public static implicit operator double(IfcNonNegativeLengthMeasure obj)
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
		return ((IfcNonNegativeLengthMeasure)obj)._value == _value;
	}

	public bool Equals(double other)
	{
		return this == other;
	}

	public static bool operator ==(IfcNonNegativeLengthMeasure obj1, IfcNonNegativeLengthMeasure obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcNonNegativeLengthMeasure obj1, IfcNonNegativeLengthMeasure obj2)
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

	public bool ValidateClause(IfcNonNegativeLengthMeasureClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcNonNegativeLengthMeasureClause.NotNegative)
			{
				result = (double)this >= 0.0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcNonNegativeLengthMeasure>()?.LogError($"Exception thrown evaluating where-clause 'IfcNonNegativeLengthMeasure.{clause}'.", ex);
		}
		return result;
	}

	public IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcNonNegativeLengthMeasureClause.NotNegative))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcNonNegativeLengthMeasure.NotNegative",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}

	static IfcNonNegativeLengthMeasure()
	{
		Culture = new CultureInfo("en-US");
	}
}
