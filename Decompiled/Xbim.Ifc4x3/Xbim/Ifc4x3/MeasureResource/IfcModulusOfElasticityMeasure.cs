using System;
using System.Globalization;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4x3.ConstraintResource;
using Xbim.Ifc4x3.CostResource;

namespace Xbim.Ifc4x3.MeasureResource;

[ExpressType("IfcModulusOfElasticityMeasure", 329)]
[DefinedType(typeof(double))]
public struct IfcModulusOfElasticityMeasure : IfcDerivedMeasureValue, IfcValue, IfcAppliedValueSelect, IExpressSelectType, IPersist, IfcMetricValueSelect, IExpressValueType, IExpressRealType, IEquatable<double>
{
	private double _value;

	private static readonly CultureInfo Culture;

	public object Value => _value;

	double IExpressRealType.Value => _value;

	Type IExpressValueType.UnderlyingSystemType => typeof(double);

	public override string ToString()
	{
		return _value.ToString("R", Culture);
	}

	public IfcModulusOfElasticityMeasure(double val)
	{
		_value = val;
	}

	public IfcModulusOfElasticityMeasure(string val)
	{
		_value = Convert.ToDouble(val, Culture);
	}

	public static implicit operator IfcModulusOfElasticityMeasure(double value)
	{
		return new IfcModulusOfElasticityMeasure(value);
	}

	public static implicit operator double(IfcModulusOfElasticityMeasure obj)
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
		return ((IfcModulusOfElasticityMeasure)obj)._value == _value;
	}

	public bool Equals(double other)
	{
		return this == other;
	}

	public static bool operator ==(IfcModulusOfElasticityMeasure obj1, IfcModulusOfElasticityMeasure obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcModulusOfElasticityMeasure obj1, IfcModulusOfElasticityMeasure obj2)
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

	static IfcModulusOfElasticityMeasure()
	{
		Culture = new CultureInfo("en-US");
	}
}
