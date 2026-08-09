using System;
using System.Globalization;
using Xbim.Common;
using Xbim.Common.Exceptions;

namespace Xbim.Ifc2x3.MeasureResource;

[ExpressType("IfcSoundPressureMeasure", 326)]
[DefinedType(typeof(double))]
public struct IfcSoundPressureMeasure : IfcDerivedMeasureValue, IfcValue, IExpressSelectType, IPersist, IExpressValueType, IExpressRealType, IEquatable<double>
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

	public IfcSoundPressureMeasure(double val)
	{
		_value = val;
	}

	public IfcSoundPressureMeasure(string val)
	{
		_value = Convert.ToDouble(val, Culture);
	}

	public static implicit operator IfcSoundPressureMeasure(double value)
	{
		return new IfcSoundPressureMeasure(value);
	}

	public static implicit operator double(IfcSoundPressureMeasure obj)
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
		return ((IfcSoundPressureMeasure)obj)._value == _value;
	}

	public bool Equals(double other)
	{
		return this == other;
	}

	public static bool operator ==(IfcSoundPressureMeasure obj1, IfcSoundPressureMeasure obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcSoundPressureMeasure obj1, IfcSoundPressureMeasure obj2)
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

	static IfcSoundPressureMeasure()
	{
		Culture = new CultureInfo("en-US");
	}
}
