using System;
using System.Globalization;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4x3.ConstraintResource;
using Xbim.Ifc4x3.CostResource;

namespace Xbim.Ifc4x3.MeasureResource;

[ExpressType("IfcDoseEquivalentMeasure", 401)]
[DefinedType(typeof(double))]
public struct IfcDoseEquivalentMeasure : IfcDerivedMeasureValue, IfcValue, IfcAppliedValueSelect, IExpressSelectType, IPersist, IfcMetricValueSelect, IExpressValueType, IExpressRealType, IEquatable<double>
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

	public IfcDoseEquivalentMeasure(double val)
	{
		_value = val;
	}

	public IfcDoseEquivalentMeasure(string val)
	{
		_value = Convert.ToDouble(val, Culture);
	}

	public static implicit operator IfcDoseEquivalentMeasure(double value)
	{
		return new IfcDoseEquivalentMeasure(value);
	}

	public static implicit operator double(IfcDoseEquivalentMeasure obj)
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
		return ((IfcDoseEquivalentMeasure)obj)._value == _value;
	}

	public bool Equals(double other)
	{
		return this == other;
	}

	public static bool operator ==(IfcDoseEquivalentMeasure obj1, IfcDoseEquivalentMeasure obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcDoseEquivalentMeasure obj1, IfcDoseEquivalentMeasure obj2)
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

	static IfcDoseEquivalentMeasure()
	{
		Culture = new CultureInfo("en-US");
	}
}
