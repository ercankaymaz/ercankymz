using System;
using System.Globalization;
using Xbim.Common;
using Xbim.Common.Exceptions;

namespace Xbim.Ifc4x3.PresentationAppearanceResource;

[ExpressType("IfcSpecularExponent", 325)]
[DefinedType(typeof(double))]
public struct IfcSpecularExponent : IfcSpecularHighlightSelect, IExpressSelectType, IPersist, IExpressValueType, IExpressRealType, IEquatable<double>
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

	public IfcSpecularExponent(double val)
	{
		_value = val;
	}

	public IfcSpecularExponent(string val)
	{
		_value = Convert.ToDouble(val, Culture);
	}

	public static implicit operator IfcSpecularExponent(double value)
	{
		return new IfcSpecularExponent(value);
	}

	public static implicit operator double(IfcSpecularExponent obj)
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
		return ((IfcSpecularExponent)obj)._value == _value;
	}

	public bool Equals(double other)
	{
		return this == other;
	}

	public static bool operator ==(IfcSpecularExponent obj1, IfcSpecularExponent obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcSpecularExponent obj1, IfcSpecularExponent obj2)
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

	static IfcSpecularExponent()
	{
		Culture = new CultureInfo("en-US");
	}
}
