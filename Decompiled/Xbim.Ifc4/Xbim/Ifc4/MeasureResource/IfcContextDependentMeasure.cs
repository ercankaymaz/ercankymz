using System;
using System.Globalization;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ConstraintResource;
using Xbim.Ifc4.CostResource;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.MeasureResource;

[ExpressType("IfcContextDependentMeasure", 617)]
[DefinedType(typeof(double))]
public struct IfcContextDependentMeasure : IfcMeasureValue, IfcValue, IfcAppliedValueSelect, IIfcAppliedValueSelect, IExpressSelectType, IPersist, IfcMetricValueSelect, IIfcMetricValueSelect, IIfcValue, IExpressValueType, IIfcMeasureValue, IExpressRealType, IEquatable<double>
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

	public IfcContextDependentMeasure(double val)
	{
		_value = val;
	}

	public IfcContextDependentMeasure(string val)
	{
		_value = Convert.ToDouble(val, Culture);
	}

	public static implicit operator IfcContextDependentMeasure(double value)
	{
		return new IfcContextDependentMeasure(value);
	}

	public static implicit operator double(IfcContextDependentMeasure obj)
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
		return ((IfcContextDependentMeasure)obj)._value == _value;
	}

	public bool Equals(double other)
	{
		return this == other;
	}

	public static bool operator ==(IfcContextDependentMeasure obj1, IfcContextDependentMeasure obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcContextDependentMeasure obj1, IfcContextDependentMeasure obj2)
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

	static IfcContextDependentMeasure()
	{
		Culture = new CultureInfo("en-US");
	}
}
