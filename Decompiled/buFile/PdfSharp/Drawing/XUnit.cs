using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;

namespace PdfSharp.Drawing;

[DebuggerDisplay("{DebuggerDisplay}")]
public struct XUnit : IFormattable
{
	internal const double PointFactor = 1.0;

	internal const double InchFactor = 72.0;

	internal const double MillimeterFactor = 2.834645669291339;

	internal const double CentimeterFactor = 28.346456692913385;

	internal const double PresentationFactor = 0.75;

	internal const double PointFactorWpf = 1.3333333333333333;

	internal const double InchFactorWpf = 96.0;

	internal const double MillimeterFactorWpf = 3.7795275590551185;

	internal const double CentimeterFactorWpf = 37.79527559055118;

	internal const double PresentationFactorWpf = 1.0;

	public static readonly XUnit Zero;

	private double _value;

	private XGraphicsUnit _type;

	public double Value => _value;

	public XGraphicsUnit Type => _type;

	public double Point
	{
		get
		{
			return _type switch
			{
				XGraphicsUnit.Point => _value, 
				XGraphicsUnit.Inch => _value * 72.0, 
				XGraphicsUnit.Millimeter => _value * 72.0 / 25.4, 
				XGraphicsUnit.Centimeter => _value * 72.0 / 2.54, 
				XGraphicsUnit.Presentation => _value * 72.0 / 96.0, 
				_ => throw new InvalidCastException(), 
			};
		}
		set
		{
			_value = value;
			_type = XGraphicsUnit.Point;
		}
	}

	public double Inch
	{
		get
		{
			return _type switch
			{
				XGraphicsUnit.Point => _value / 72.0, 
				XGraphicsUnit.Inch => _value, 
				XGraphicsUnit.Millimeter => _value / 25.4, 
				XGraphicsUnit.Centimeter => _value / 2.54, 
				XGraphicsUnit.Presentation => _value / 96.0, 
				_ => throw new InvalidCastException(), 
			};
		}
		set
		{
			_value = value;
			_type = XGraphicsUnit.Inch;
		}
	}

	public double Millimeter
	{
		get
		{
			return _type switch
			{
				XGraphicsUnit.Point => _value * 25.4 / 72.0, 
				XGraphicsUnit.Inch => _value * 25.4, 
				XGraphicsUnit.Millimeter => _value, 
				XGraphicsUnit.Centimeter => _value * 10.0, 
				XGraphicsUnit.Presentation => _value * 25.4 / 96.0, 
				_ => throw new InvalidCastException(), 
			};
		}
		set
		{
			_value = value;
			_type = XGraphicsUnit.Millimeter;
		}
	}

	public double Centimeter
	{
		get
		{
			return _type switch
			{
				XGraphicsUnit.Point => _value * 2.54 / 72.0, 
				XGraphicsUnit.Inch => _value * 2.54, 
				XGraphicsUnit.Millimeter => _value / 10.0, 
				XGraphicsUnit.Centimeter => _value, 
				XGraphicsUnit.Presentation => _value * 2.54 / 96.0, 
				_ => throw new InvalidCastException(), 
			};
		}
		set
		{
			_value = value;
			_type = XGraphicsUnit.Centimeter;
		}
	}

	public double Presentation
	{
		get
		{
			return _type switch
			{
				XGraphicsUnit.Point => _value * 96.0 / 72.0, 
				XGraphicsUnit.Inch => _value * 96.0, 
				XGraphicsUnit.Millimeter => _value * 96.0 / 25.4, 
				XGraphicsUnit.Centimeter => _value * 96.0 / 2.54, 
				XGraphicsUnit.Presentation => _value, 
				_ => throw new InvalidCastException(), 
			};
		}
		set
		{
			_value = value;
			_type = XGraphicsUnit.Point;
		}
	}

	private string DebuggerDisplay => string.Format(CultureInfo.InvariantCulture, "unit=({0:0.##########} {1})", _value, GetSuffix());

	public XUnit(double point)
	{
		_value = point;
		_type = XGraphicsUnit.Point;
	}

	public XUnit(double value, XGraphicsUnit type)
	{
		if (!Enum.IsDefined(typeof(XGraphicsUnit), type))
		{
			throw new InvalidEnumArgumentException("type", (int)type, typeof(XGraphicsUnit));
		}
		_value = value;
		_type = type;
	}

	public string ToString(IFormatProvider formatProvider)
	{
		return _value.ToString(formatProvider) + GetSuffix();
	}

	string IFormattable.ToString(string format, IFormatProvider formatProvider)
	{
		return _value.ToString(format, formatProvider) + GetSuffix();
	}

	public override string ToString()
	{
		return _value.ToString(CultureInfo.InvariantCulture) + GetSuffix();
	}

	private string GetSuffix()
	{
		return _type switch
		{
			XGraphicsUnit.Point => "pt", 
			XGraphicsUnit.Inch => "in", 
			XGraphicsUnit.Millimeter => "mm", 
			XGraphicsUnit.Centimeter => "cm", 
			XGraphicsUnit.Presentation => "pu", 
			_ => throw new InvalidCastException(), 
		};
	}

	public static XUnit FromPoint(double value)
	{
		XUnit result = default(XUnit);
		result._value = value;
		result._type = XGraphicsUnit.Point;
		return result;
	}

	public static XUnit FromInch(double value)
	{
		XUnit result = default(XUnit);
		result._value = value;
		result._type = XGraphicsUnit.Inch;
		return result;
	}

	public static XUnit FromMillimeter(double value)
	{
		XUnit result = default(XUnit);
		result._value = value;
		result._type = XGraphicsUnit.Millimeter;
		return result;
	}

	public static XUnit FromCentimeter(double value)
	{
		XUnit result = default(XUnit);
		result._value = value;
		result._type = XGraphicsUnit.Centimeter;
		return result;
	}

	public static XUnit FromPresentation(double value)
	{
		XUnit result = default(XUnit);
		result._value = value;
		result._type = XGraphicsUnit.Presentation;
		return result;
	}

	public static implicit operator XUnit(string value)
	{
		value = value.Trim();
		value = value.Replace(',', '.');
		int length = value.Length;
		int i;
		for (i = 0; i < length; i++)
		{
			char c = value[i];
			if (c != '.' && c != '-' && c != '+' && !char.IsNumber(c))
			{
				break;
			}
		}
		XUnit result = default(XUnit);
		try
		{
			result._value = double.Parse(value.Substring(0, i).Trim(), CultureInfo.InvariantCulture);
		}
		catch (Exception innerException)
		{
			result._value = 1.0;
			string message = $"String '{value}' is not a valid value for structure 'XUnit'.";
			throw new ArgumentException(message, innerException);
		}
		string text = value.Substring(i).Trim().ToLower();
		result._type = XGraphicsUnit.Point;
		string text2 = text;
		string text3 = text2;
		switch (text3)
		{
		default:
			if (text3.Length != 0)
			{
				goto case null;
			}
			goto IL_0140;
		case null:
			if (!(text3 == "pt"))
			{
				if (text3 == "pu")
				{
					result._type = XGraphicsUnit.Presentation;
					break;
				}
				throw new ArgumentException("Unknown unit type: '" + text + "'");
			}
			goto IL_0140;
		case "cm":
			result._type = XGraphicsUnit.Centimeter;
			break;
		case "in":
			result._type = XGraphicsUnit.Inch;
			break;
		case "mm":
			{
				result._type = XGraphicsUnit.Millimeter;
				break;
			}
			IL_0140:
			result._type = XGraphicsUnit.Point;
			break;
		}
		return result;
	}

	public static implicit operator XUnit(int value)
	{
		XUnit result = default(XUnit);
		result._value = value;
		result._type = XGraphicsUnit.Point;
		return result;
	}

	public static implicit operator XUnit(double value)
	{
		XUnit result = default(XUnit);
		result._value = value;
		result._type = XGraphicsUnit.Point;
		return result;
	}

	public static implicit operator double(XUnit value)
	{
		return value.Point;
	}

	public static bool operator ==(XUnit value1, XUnit value2)
	{
		return value1._type == value2._type && value1._value == value2._value;
	}

	public static bool operator !=(XUnit value1, XUnit value2)
	{
		return !(value1 == value2);
	}

	public override bool Equals(object obj)
	{
		if (obj is XUnit)
		{
			return this == (XUnit)obj;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return _value.GetHashCode() ^ _type.GetHashCode();
	}

	public static XUnit Parse(string value)
	{
		return value;
	}

	public void ConvertType(XGraphicsUnit type)
	{
		if (_type != type)
		{
			switch (type)
			{
			case XGraphicsUnit.Point:
				_value = Point;
				_type = XGraphicsUnit.Point;
				break;
			case XGraphicsUnit.Inch:
				_value = Inch;
				_type = XGraphicsUnit.Inch;
				break;
			case XGraphicsUnit.Centimeter:
				_value = Centimeter;
				_type = XGraphicsUnit.Centimeter;
				break;
			case XGraphicsUnit.Millimeter:
				_value = Millimeter;
				_type = XGraphicsUnit.Millimeter;
				break;
			case XGraphicsUnit.Presentation:
				_value = Presentation;
				_type = XGraphicsUnit.Presentation;
				break;
			default:
				throw new ArgumentException("Unknown unit type: '" + type.ToString() + "'");
			}
		}
	}

	static XUnit()
	{
		Zero = default(XUnit);
	}
}
