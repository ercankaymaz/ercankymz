using System;
using System.Globalization;
using Xbim.Common;
using Xbim.Common.Exceptions;

namespace Xbim.Ifc2x3.MeasureResource;

[ExpressType("IfcReal", 538)]
[DefinedType(typeof(double))]
public struct IfcReal : IfcSimpleValue, IfcValue, IExpressSelectType, IPersist, IExpressValueType, IExpressRealType, IEquatable<double>
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

	public IfcReal(double val)
	{
		_value = val;
	}

	public IfcReal(string val)
	{
		_value = Convert.ToDouble(val, Culture);
	}

	public static implicit operator IfcReal(double value)
	{
		return new IfcReal(value);
	}

	public static implicit operator double(IfcReal obj)
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
		return ((IfcReal)obj)._value == _value;
	}

	public bool Equals(double other)
	{
		return this == other;
	}

	public static bool operator ==(IfcReal obj1, IfcReal obj2)
	{
		return object.Equals(obj1, obj2);
	}

	public static bool operator !=(IfcReal obj1, IfcReal obj2)
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

	public static string AsPart21(double real)
	{
		double num = real;
		CultureInfo cultureInfo = new CultureInfo("en-US");
		string text = num.ToString("R", cultureInfo);
		text = double.Parse(num.ToString("R", cultureInfo), cultureInfo).ToString("R", cultureInfo);
		if (!text.Contains("."))
		{
			text = ((!text.Contains("E")) ? (text + ".") : text.Replace("E", ".E"));
		}
		return text;
	}

	public static double ToDouble(string val)
	{
		return Convert.ToDouble(val, new CultureInfo("en-US"));
	}

	static IfcReal()
	{
		Culture = new CultureInfo("en-US");
	}
}
