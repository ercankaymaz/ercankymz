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
using Xbim.Ifc4.PresentationAppearanceResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.MeasureResource;

[ExpressType("IfcPositiveRatioMeasure", 387)]
[DefinedType(typeof(double))]
public struct IfcPositiveRatioMeasure : IfcMeasureValue, IfcValue, IfcAppliedValueSelect, IIfcAppliedValueSelect, IExpressSelectType, IPersist, IfcMetricValueSelect, IIfcMetricValueSelect, IIfcValue, IExpressValueType, IIfcMeasureValue, IfcSizeSelect, IIfcSizeSelect, IExpressRealType, IEquatable<double>, IExpressValidatable
{
	public enum IfcPositiveRatioMeasureClause
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

	public IfcPositiveRatioMeasure(double val)
	{
		_value = val;
	}

	public IfcPositiveRatioMeasure(string val)
	{
		_value = Convert.ToDouble(val, Culture);
	}

	public static implicit operator IfcPositiveRatioMeasure(double value)
	{
		return new IfcPositiveRatioMeasure(value);
	}

	public static implicit operator double(IfcPositiveRatioMeasure obj)
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
		return ((IfcPositiveRatioMeasure)obj)._value == _value;
	}

	public bool Equals(double other)
	{
		return this == other;
	}

	public static bool operator ==(IfcPositiveRatioMeasure obj1, IfcPositiveRatioMeasure obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcPositiveRatioMeasure obj1, IfcPositiveRatioMeasure obj2)
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

	public bool ValidateClause(IfcPositiveRatioMeasureClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcPositiveRatioMeasureClause.WR1)
			{
				result = (double)this > 0.0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcPositiveRatioMeasure>()?.LogError($"Exception thrown evaluating where-clause 'IfcPositiveRatioMeasure.{clause}'.", ex);
		}
		return result;
	}

	public IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcPositiveRatioMeasureClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPositiveRatioMeasure.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}

	static IfcPositiveRatioMeasure()
	{
		Culture = new CultureInfo("en-US");
	}
}
