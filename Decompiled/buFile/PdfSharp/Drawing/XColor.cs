using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;

namespace PdfSharp.Drawing;

[DebuggerDisplay("clr=(A={A}, R={R}, G={G}, B={B} C={C}, M={M}, Y={Y}, K={K})")]
public struct XColor
{
	public static XColor Empty;

	private XColorSpace _cs;

	private float _a;

	private byte _r;

	private byte _g;

	private byte _b;

	private float _c;

	private float _m;

	private float _y;

	private float _k;

	private float _gs;

	public XColorSpace ColorSpace
	{
		get
		{
			return _cs;
		}
		set
		{
			if (!Enum.IsDefined(typeof(XColorSpace), value))
			{
				throw new InvalidEnumArgumentException("value", (int)value, typeof(XColorSpace));
			}
			_cs = value;
		}
	}

	public bool IsEmpty => this == Empty;

	public bool IsKnownColor => XKnownColorTable.IsKnownColor(Argb);

	public double A
	{
		get
		{
			return _a;
		}
		set
		{
			if (value < 0.0)
			{
				_a = 0f;
			}
			else if (value > 1.0)
			{
				_a = 1f;
			}
			else
			{
				_a = (float)value;
			}
		}
	}

	public byte R
	{
		get
		{
			return _r;
		}
		set
		{
			_r = value;
			RgbChanged();
		}
	}

	public byte G
	{
		get
		{
			return _g;
		}
		set
		{
			_g = value;
			RgbChanged();
		}
	}

	public byte B
	{
		get
		{
			return _b;
		}
		set
		{
			_b = value;
			RgbChanged();
		}
	}

	internal uint Rgb => (uint)((_r << 16) | (_g << 8) | _b);

	internal uint Argb => ((uint)(_a * 255f) << 24) | (uint)(_r << 16) | (uint)(_g << 8) | _b;

	public double C
	{
		get
		{
			return _c;
		}
		set
		{
			if (value < 0.0)
			{
				_c = 0f;
			}
			else if (value > 1.0)
			{
				_c = 1f;
			}
			else
			{
				_c = (float)value;
			}
			CmykChanged();
		}
	}

	public double M
	{
		get
		{
			return _m;
		}
		set
		{
			if (value < 0.0)
			{
				_m = 0f;
			}
			else if (value > 1.0)
			{
				_m = 1f;
			}
			else
			{
				_m = (float)value;
			}
			CmykChanged();
		}
	}

	public double Y
	{
		get
		{
			return _y;
		}
		set
		{
			if (value < 0.0)
			{
				_y = 0f;
			}
			else if (value > 1.0)
			{
				_y = 1f;
			}
			else
			{
				_y = (float)value;
			}
			CmykChanged();
		}
	}

	public double K
	{
		get
		{
			return _k;
		}
		set
		{
			if (value < 0.0)
			{
				_k = 0f;
			}
			else if (value > 1.0)
			{
				_k = 1f;
			}
			else
			{
				_k = (float)value;
			}
			CmykChanged();
		}
	}

	public double GS
	{
		get
		{
			return _gs;
		}
		set
		{
			if (value < 0.0)
			{
				_gs = 0f;
			}
			else if (value > 1.0)
			{
				_gs = 1f;
			}
			else
			{
				_gs = (float)value;
			}
			GrayChanged();
		}
	}

	public string RgbCmykG
	{
		get
		{
			return string.Format(CultureInfo.InvariantCulture, "{0};{1};{2};{3};{4};{5};{6};{7};{8}", _r, _g, _b, _c, _m, _y, _k, _gs, _a);
		}
		set
		{
			string[] array = value.Split(';');
			_r = byte.Parse(array[0], CultureInfo.InvariantCulture);
			_g = byte.Parse(array[1], CultureInfo.InvariantCulture);
			_b = byte.Parse(array[2], CultureInfo.InvariantCulture);
			_c = float.Parse(array[3], CultureInfo.InvariantCulture);
			_m = float.Parse(array[4], CultureInfo.InvariantCulture);
			_y = float.Parse(array[5], CultureInfo.InvariantCulture);
			_k = float.Parse(array[6], CultureInfo.InvariantCulture);
			_gs = float.Parse(array[7], CultureInfo.InvariantCulture);
			_a = float.Parse(array[8], CultureInfo.InvariantCulture);
		}
	}

	private XColor(uint argb)
	{
		_cs = XColorSpace.Rgb;
		_a = (float)(int)(byte)((argb >> 24) & 0xFF) / 255f;
		_r = (byte)((argb >> 16) & 0xFF);
		_g = (byte)((argb >> 8) & 0xFF);
		_b = (byte)(argb & 0xFF);
		_c = 0f;
		_m = 0f;
		_y = 0f;
		_k = 0f;
		_gs = 0f;
		RgbChanged();
	}

	private XColor(byte alpha, byte red, byte green, byte blue)
	{
		_cs = XColorSpace.Rgb;
		_a = (float)(int)alpha / 255f;
		_r = red;
		_g = green;
		_b = blue;
		_c = 0f;
		_m = 0f;
		_y = 0f;
		_k = 0f;
		_gs = 0f;
		RgbChanged();
	}

	private XColor(double alpha, double cyan, double magenta, double yellow, double black)
	{
		_cs = XColorSpace.Cmyk;
		_a = (float)((alpha > 1.0) ? 1.0 : ((alpha < 0.0) ? 0.0 : alpha));
		_c = (float)((cyan > 1.0) ? 1.0 : ((cyan < 0.0) ? 0.0 : cyan));
		_m = (float)((magenta > 1.0) ? 1.0 : ((magenta < 0.0) ? 0.0 : magenta));
		_y = (float)((yellow > 1.0) ? 1.0 : ((yellow < 0.0) ? 0.0 : yellow));
		_k = (float)((black > 1.0) ? 1.0 : ((black < 0.0) ? 0.0 : black));
		_r = 0;
		_g = 0;
		_b = 0;
		_gs = 0f;
		CmykChanged();
	}

	private XColor(double cyan, double magenta, double yellow, double black)
	{
		this = new XColor(1.0, cyan, magenta, yellow, black);
	}

	private XColor(double gray)
	{
		_cs = XColorSpace.GrayScale;
		if (gray < 0.0)
		{
			_gs = 0f;
		}
		else if (gray > 1.0)
		{
			_gs = 1f;
		}
		else
		{
			_gs = (float)gray;
		}
		_a = 1f;
		_r = 0;
		_g = 0;
		_b = 0;
		_c = 0f;
		_m = 0f;
		_y = 0f;
		_k = 0f;
		GrayChanged();
	}

	internal XColor(XKnownColor knownColor)
	{
		this = new XColor(XKnownColorTable.KnownColorToArgb(knownColor));
	}

	public static XColor FromArgb(int argb)
	{
		return new XColor((byte)(argb >> 24), (byte)(argb >> 16), (byte)(argb >> 8), (byte)argb);
	}

	public static XColor FromArgb(uint argb)
	{
		return new XColor((byte)(argb >> 24), (byte)(argb >> 16), (byte)(argb >> 8), (byte)argb);
	}

	public static XColor FromArgb(int red, int green, int blue)
	{
		CheckByte(red, "red");
		CheckByte(green, "green");
		CheckByte(blue, "blue");
		return new XColor(byte.MaxValue, (byte)red, (byte)green, (byte)blue);
	}

	public static XColor FromArgb(int alpha, int red, int green, int blue)
	{
		CheckByte(alpha, "alpha");
		CheckByte(red, "red");
		CheckByte(green, "green");
		CheckByte(blue, "blue");
		return new XColor((byte)alpha, (byte)red, (byte)green, (byte)blue);
	}

	public static XColor FromArgb(int alpha, XColor color)
	{
		color.A = (double)(int)(byte)alpha / 255.0;
		return color;
	}

	public static XColor FromCmyk(double cyan, double magenta, double yellow, double black)
	{
		return new XColor(cyan, magenta, yellow, black);
	}

	public static XColor FromCmyk(double alpha, double cyan, double magenta, double yellow, double black)
	{
		return new XColor(alpha, cyan, magenta, yellow, black);
	}

	public static XColor FromGrayScale(double grayScale)
	{
		return new XColor(grayScale);
	}

	public static XColor FromKnownColor(XKnownColor color)
	{
		return new XColor(color);
	}

	public static XColor FromName(string name)
	{
		return Empty;
	}

	public override bool Equals(object obj)
	{
		if (obj is XColor xColor && _r == xColor._r && _g == xColor._g && _b == xColor._b && _c == xColor._c && _m == xColor._m && _y == xColor._y && _k == xColor._k && _gs == xColor._gs)
		{
			return _a == xColor._a;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (byte)(_a * 255f) ^ _r ^ _g ^ _b;
	}

	public static bool operator ==(XColor left, XColor right)
	{
		if (left._r == right._r && left._g == right._g && left._b == right._b && left._c == right._c && left._m == right._m && left._y == right._y && left._k == right._k && left._gs == right._gs)
		{
			return left._a == right._a;
		}
		return false;
	}

	public static bool operator !=(XColor left, XColor right)
	{
		return !(left == right);
	}

	public double GetHue()
	{
		if (_r == _g && _g == _b)
		{
			return 0.0;
		}
		double num = (double)(int)_r / 255.0;
		double num2 = (double)(int)_g / 255.0;
		double num3 = (double)(int)_b / 255.0;
		double num4 = 0.0;
		double num5 = num;
		double num6 = num;
		if (num2 > num5)
		{
			num5 = num2;
		}
		if (num3 > num5)
		{
			num5 = num3;
		}
		if (num2 < num6)
		{
			num6 = num2;
		}
		if (num3 < num6)
		{
			num6 = num3;
		}
		double num7 = num5 - num6;
		if (num == num5)
		{
			num4 = (num2 - num3) / num7;
		}
		else if (num2 == num5)
		{
			num4 = 2.0 + (num3 - num) / num7;
		}
		else if (num3 == num5)
		{
			num4 = 4.0 + (num - num2) / num7;
		}
		num4 *= 60.0;
		if (num4 < 0.0)
		{
			num4 += 360.0;
		}
		return num4;
	}

	public double GetSaturation()
	{
		double num = (double)(int)_r / 255.0;
		double num2 = (double)(int)_g / 255.0;
		double num3 = (double)(int)_b / 255.0;
		double result = 0.0;
		double num4 = num;
		double num5 = num;
		if (num2 > num4)
		{
			num4 = num2;
		}
		if (num3 > num4)
		{
			num4 = num3;
		}
		if (num2 < num5)
		{
			num5 = num2;
		}
		if (num3 < num5)
		{
			num5 = num3;
		}
		if (num4 == num5)
		{
			return result;
		}
		double num6 = (num4 + num5) / 2.0;
		if (num6 <= 0.5)
		{
			return (num4 - num5) / (num4 + num5);
		}
		return (num4 - num5) / (2.0 - num4 - num5);
	}

	public double GetBrightness()
	{
		double num = (double)(int)_r / 255.0;
		double num2 = (double)(int)_g / 255.0;
		double num3 = (double)(int)_b / 255.0;
		double num4 = num;
		double num5 = num;
		if (num2 > num4)
		{
			num4 = num2;
		}
		if (num3 > num4)
		{
			num4 = num3;
		}
		if (num2 < num5)
		{
			num5 = num2;
		}
		if (num3 < num5)
		{
			num5 = num3;
		}
		return (num4 + num5) / 2.0;
	}

	private void RgbChanged()
	{
		_cs = XColorSpace.Rgb;
		int num = 255 - _r;
		int num2 = 255 - _g;
		int num3 = 255 - _b;
		int num4 = Math.Min(num, Math.Min(num2, num3));
		if (num4 == 255)
		{
			_c = (_m = (_y = 0f));
		}
		else
		{
			float num5 = 255f - (float)num4;
			_c = (float)(num - num4) / num5;
			_m = (float)(num2 - num4) / num5;
			_y = (float)(num3 - num4) / num5;
		}
		_k = (_gs = (float)num4 / 255f);
	}

	private void CmykChanged()
	{
		_cs = XColorSpace.Cmyk;
		float num = _k * 255f;
		float num2 = 255f - num;
		_r = (byte)(255f - Math.Min(255f, _c * num2 + num));
		_g = (byte)(255f - Math.Min(255f, _m * num2 + num));
		_b = (byte)(255f - Math.Min(255f, _y * num2 + num));
		_gs = (float)(1.0 - Math.Min(1.0, (double)(0.3f * _c + 0.59f * _m) + 0.11 * (double)_y + (double)_k));
	}

	private void GrayChanged()
	{
		_cs = XColorSpace.GrayScale;
		_r = (byte)(_gs * 255f);
		_g = (byte)(_gs * 255f);
		_b = (byte)(_gs * 255f);
		_c = 0f;
		_m = 0f;
		_y = 0f;
		_k = 1f - _gs;
	}

	private static void CheckByte(int val, string name)
	{
		if (val < 0 || val > 255)
		{
			throw new ArgumentException(PSSR.InvalidValue(val, name, 0, 255));
		}
	}
}
