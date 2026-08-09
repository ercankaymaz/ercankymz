using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.Validation;

namespace Xbim.Ifc2x3.MeasureResource;

[ExpressType("IfcPositivePlaneAngleMeasure", 680)]
[DefinedType(typeof(double))]
public struct IfcPositivePlaneAngleMeasure : IfcMeasureValue, IfcValue, IExpressSelectType, IPersist, IExpressValueType, IExpressRealType, IEquatable<double>, IExpressValidatable
{
	public enum IfcPositivePlaneAngleMeasureClause
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

	public IfcPositivePlaneAngleMeasure(double val)
	{
		_value = val;
	}

	public IfcPositivePlaneAngleMeasure(string val)
	{
		_value = Convert.ToDouble(val, Culture);
	}

	public static implicit operator IfcPositivePlaneAngleMeasure(double value)
	{
		return new IfcPositivePlaneAngleMeasure(value);
	}

	public static implicit operator double(IfcPositivePlaneAngleMeasure obj)
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
		return ((IfcPositivePlaneAngleMeasure)obj)._value == _value;
	}

	public bool Equals(double other)
	{
		return this == other;
	}

	public static bool operator ==(IfcPositivePlaneAngleMeasure obj1, IfcPositivePlaneAngleMeasure obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcPositivePlaneAngleMeasure obj1, IfcPositivePlaneAngleMeasure obj2)
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

	public bool ValidateClause(IfcPositivePlaneAngleMeasureClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcPositivePlaneAngleMeasureClause.WR1)
			{
				result = (double)this > 0.0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcPositivePlaneAngleMeasure>()?.LogError($"Exception thrown evaluating where-clause 'IfcPositivePlaneAngleMeasure.{clause}'.", ex);
		}
		return result;
	}

	public IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcPositivePlaneAngleMeasureClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcPositivePlaneAngleMeasure.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}

	static IfcPositivePlaneAngleMeasure()
	{
		Culture = new CultureInfo("en-US");
	}
}
