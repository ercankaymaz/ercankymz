using System;
using System.Globalization;
using Xbim.Common;
using Xbim.Common.Exceptions;

namespace Xbim.Ifc2x3.MeasureResource;

[ExpressType("IfcRotationalStiffnessMeasure", 679)]
[DefinedType(typeof(double))]
public struct IfcRotationalStiffnessMeasure : IfcDerivedMeasureValue, IfcValue, IExpressSelectType, IPersist, IExpressValueType, IExpressRealType, IEquatable<double>
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

	public IfcRotationalStiffnessMeasure(double val)
	{
		_value = val;
	}

	public IfcRotationalStiffnessMeasure(string val)
	{
		_value = Convert.ToDouble(val, Culture);
	}

	public static implicit operator IfcRotationalStiffnessMeasure(double value)
	{
		return new IfcRotationalStiffnessMeasure(value);
	}

	public static implicit operator double(IfcRotationalStiffnessMeasure obj)
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
		return ((IfcRotationalStiffnessMeasure)obj)._value == _value;
	}

	public bool Equals(double other)
	{
		return this == other;
	}

	public static bool operator ==(IfcRotationalStiffnessMeasure obj1, IfcRotationalStiffnessMeasure obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcRotationalStiffnessMeasure obj1, IfcRotationalStiffnessMeasure obj2)
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

	static IfcRotationalStiffnessMeasure()
	{
		Culture = new CultureInfo("en-US");
	}
}
