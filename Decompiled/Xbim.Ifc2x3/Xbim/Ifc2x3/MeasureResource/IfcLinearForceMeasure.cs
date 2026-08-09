using System;
using System.Globalization;
using Xbim.Common;
using Xbim.Common.Exceptions;

namespace Xbim.Ifc2x3.MeasureResource;

[ExpressType("IfcLinearForceMeasure", 361)]
[DefinedType(typeof(double))]
public struct IfcLinearForceMeasure : IfcDerivedMeasureValue, IfcValue, IExpressSelectType, IPersist, IExpressValueType, IExpressRealType, IEquatable<double>
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

	public IfcLinearForceMeasure(double val)
	{
		_value = val;
	}

	public IfcLinearForceMeasure(string val)
	{
		_value = Convert.ToDouble(val, Culture);
	}

	public static implicit operator IfcLinearForceMeasure(double value)
	{
		return new IfcLinearForceMeasure(value);
	}

	public static implicit operator double(IfcLinearForceMeasure obj)
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
		return ((IfcLinearForceMeasure)obj)._value == _value;
	}

	public bool Equals(double other)
	{
		return this == other;
	}

	public static bool operator ==(IfcLinearForceMeasure obj1, IfcLinearForceMeasure obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcLinearForceMeasure obj1, IfcLinearForceMeasure obj2)
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

	static IfcLinearForceMeasure()
	{
		Culture = new CultureInfo("en-US");
	}
}
