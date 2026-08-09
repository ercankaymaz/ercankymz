using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4x3.ConstraintResource;
using Xbim.Ifc4x3.CostResource;

namespace Xbim.Ifc4x3.MeasureResource;

[ExpressType("IfcIntegerCountRateMeasure", 129)]
[DefinedType(typeof(long))]
public struct IfcIntegerCountRateMeasure : IfcDerivedMeasureValue, IfcValue, IfcAppliedValueSelect, IExpressSelectType, IPersist, IfcMetricValueSelect, IExpressValueType, IExpressIntegerType, IEquatable<long>
{
	private long _value;

	public object Value => _value;

	long IExpressIntegerType.Value => _value;

	Type IExpressValueType.UnderlyingSystemType => typeof(long);

	public override string ToString()
	{
		return _value.ToString();
	}

	public IfcIntegerCountRateMeasure(long val)
	{
		_value = val;
	}

	public IfcIntegerCountRateMeasure(string val)
	{
		_value = Convert.ToInt64(val);
	}

	public static implicit operator IfcIntegerCountRateMeasure(long value)
	{
		return new IfcIntegerCountRateMeasure(value);
	}

	public static implicit operator long(IfcIntegerCountRateMeasure obj)
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
		return ((IfcIntegerCountRateMeasure)obj)._value == _value;
	}

	public bool Equals(long other)
	{
		return this == other;
	}

	public static bool operator ==(IfcIntegerCountRateMeasure obj1, IfcIntegerCountRateMeasure obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcIntegerCountRateMeasure obj1, IfcIntegerCountRateMeasure obj2)
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
		_value = value.IntegerVal;
	}
}
