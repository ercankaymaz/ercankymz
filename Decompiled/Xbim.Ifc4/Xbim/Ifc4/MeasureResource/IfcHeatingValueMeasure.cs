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

[ExpressType("IfcHeatingValueMeasure", 576)]
[DefinedType(typeof(double))]
public struct IfcHeatingValueMeasure : IfcDerivedMeasureValue, IfcValue, IfcAppliedValueSelect, IIfcAppliedValueSelect, IExpressSelectType, IPersist, IfcMetricValueSelect, IIfcMetricValueSelect, IIfcValue, IExpressValueType, IIfcDerivedMeasureValue, IExpressRealType, IEquatable<double>, IExpressValidatable
{
	public enum IfcHeatingValueMeasureClause
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

	public IfcHeatingValueMeasure(double val)
	{
		_value = val;
	}

	public IfcHeatingValueMeasure(string val)
	{
		_value = Convert.ToDouble(val, Culture);
	}

	public static implicit operator IfcHeatingValueMeasure(double value)
	{
		return new IfcHeatingValueMeasure(value);
	}

	public static implicit operator double(IfcHeatingValueMeasure obj)
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
		return ((IfcHeatingValueMeasure)obj)._value == _value;
	}

	public bool Equals(double other)
	{
		return this == other;
	}

	public static bool operator ==(IfcHeatingValueMeasure obj1, IfcHeatingValueMeasure obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcHeatingValueMeasure obj1, IfcHeatingValueMeasure obj2)
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

	public bool ValidateClause(IfcHeatingValueMeasureClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcHeatingValueMeasureClause.WR1)
			{
				result = (double)this > 0.0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcHeatingValueMeasure>()?.LogError($"Exception thrown evaluating where-clause 'IfcHeatingValueMeasure.{clause}'.", ex);
		}
		return result;
	}

	public IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcHeatingValueMeasureClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcHeatingValueMeasure.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}

	static IfcHeatingValueMeasure()
	{
		Culture = new CultureInfo("en-US");
	}
}
