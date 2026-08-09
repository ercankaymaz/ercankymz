using System;
using System.Globalization;
using System.Text;
using ACadSharp.Tables;
using CSMath;

namespace ACadSharp.Types.Units;

public class UnitStyleFormat
{
	private short _angularDecimalPlaces;

	private double _fractionHeightScale;

	private short _linearDecimalPlaces;

	public short AngularDecimalPlaces
	{
		get
		{
			return _angularDecimalPlaces;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("value", value, "The number of decimal places must be equals or greater than zero.");
			}
			_angularDecimalPlaces = value;
		}
	}

	public ZeroHandling AngularZeroHandling { get; set; } = ZeroHandling.SuppressDecimalTrailingZeroes;

	public string DecimalSeparator { get; set; }

	public string DegreesSymbol { get; set; }

	public string FeetInchesSeparator { get; set; }

	public string FeetSymbol { get; set; }

	public double FractionHeightScale
	{
		get
		{
			return _fractionHeightScale;
		}
		set
		{
			if (value <= 0.0)
			{
				throw new ArgumentOutOfRangeException("value", value, "The fraction height scale must be greater than zero.");
			}
			_fractionHeightScale = value;
		}
	}

	public FractionFormat FractionType { get; set; }

	public string GradiansSymbol { get; set; }

	public string InchesSymbol { get; set; }

	public short LinearDecimalPlaces
	{
		get
		{
			return _linearDecimalPlaces;
		}
		set
		{
			if (value < 0)
			{
				throw new ArgumentOutOfRangeException("value", value, "The number of decimal places must be equals or greater than zero.");
			}
			_linearDecimalPlaces = value;
		}
	}

	public ZeroHandling LinearZeroHandling { get; set; } = ZeroHandling.SuppressDecimalTrailingZeroes;

	public string MinutesSymbol { get; set; }

	public string RadiansSymbol { get; set; }

	public string SecondsSymbol { get; set; }

	public bool SuppressAngularLeadingZeros
	{
		get
		{
			if (LinearZeroHandling != ZeroHandling.SuppressDecimalLeadingZeroes)
			{
				return LinearZeroHandling == ZeroHandling.SuppressDecimalLeadingAndTrailingZeroes;
			}
			return true;
		}
	}

	public bool SuppressAngularTrailingZeros
	{
		get
		{
			if (LinearZeroHandling != ZeroHandling.SuppressDecimalTrailingZeroes)
			{
				return LinearZeroHandling == ZeroHandling.SuppressDecimalLeadingAndTrailingZeroes;
			}
			return true;
		}
	}

	public bool SuppressLinearLeadingZeros
	{
		get
		{
			if (LinearZeroHandling != ZeroHandling.SuppressDecimalLeadingZeroes)
			{
				return LinearZeroHandling == ZeroHandling.SuppressDecimalLeadingAndTrailingZeroes;
			}
			return true;
		}
	}

	public bool SuppressLinearTrailingZeros
	{
		get
		{
			if (LinearZeroHandling != ZeroHandling.SuppressDecimalTrailingZeroes)
			{
				return LinearZeroHandling == ZeroHandling.SuppressDecimalLeadingAndTrailingZeroes;
			}
			return true;
		}
	}

	public bool SuppressZeroFeet
	{
		get
		{
			if (LinearZeroHandling != ZeroHandling.SuppressZeroFeetAndInches)
			{
				return LinearZeroHandling == ZeroHandling.SuppressZeroFeetShowZeroInches;
			}
			return true;
		}
	}

	public bool SuppressZeroInches
	{
		get
		{
			if (LinearZeroHandling != ZeroHandling.SuppressZeroFeetAndInches)
			{
				return LinearZeroHandling == ZeroHandling.ShowZeroFeetSuppressZeroInches;
			}
			return true;
		}
	}

	public UnitStyleFormat()
	{
		_linearDecimalPlaces = 2;
		_angularDecimalPlaces = 0;
		DecimalSeparator = ".";
		FeetInchesSeparator = "-";
		DegreesSymbol = "°";
		MinutesSymbol = "'";
		SecondsSymbol = "\"";
		RadiansSymbol = "r";
		GradiansSymbol = "g";
		FeetSymbol = "'";
		InchesSymbol = "\"";
		_fractionHeightScale = 1.0;
		FractionType = FractionFormat.Horizontal;
	}

	public string GetZeroHandlingFormat(bool isAngular = false)
	{
		short linearDecimalPlaces = LinearDecimalPlaces;
		ZeroHandling zeroHandling = ((!isAngular) ? LinearZeroHandling : AngularZeroHandling);
		char value = ((zeroHandling == ZeroHandling.SuppressDecimalLeadingZeroes || zeroHandling == ZeroHandling.SuppressDecimalLeadingAndTrailingZeroes) ? '#' : '0');
		char value2 = ((zeroHandling == ZeroHandling.SuppressDecimalTrailingZeroes || zeroHandling == ZeroHandling.SuppressDecimalLeadingAndTrailingZeroes) ? '#' : '0');
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(value);
		stringBuilder.Append(".");
		for (int i = 0; i < linearDecimalPlaces; i++)
		{
			stringBuilder.Append(value2);
		}
		return stringBuilder.ToString();
	}

	public string ToArchitectural(double value)
	{
		int num = (int)(value / 12.0);
		double num2 = value - (double)(12 * num);
		int num3 = (int)num2;
		if (MathHelper.IsZero(num2))
		{
			if (num == 0)
			{
				if (SuppressZeroFeet)
				{
					return $"0{InchesSymbol}";
				}
				if (SuppressZeroInches)
				{
					return $"0{FeetSymbol}";
				}
				return $"0{FeetSymbol}{FeetInchesSeparator}0{InchesSymbol}";
			}
			if (SuppressZeroInches)
			{
				return $"{num}{FeetSymbol}";
			}
			return $"{num}{FeetSymbol}{FeetInchesSeparator}0{InchesSymbol}";
		}
		getFraction(num2, (short)Math.Pow(2.0, LinearDecimalPlaces), out var numerator, out var denominator);
		if (numerator == 0)
		{
			if (num3 == 0)
			{
				if (num == 0)
				{
					if (SuppressZeroFeet)
					{
						return $"0{InchesSymbol}";
					}
					if (SuppressZeroInches)
					{
						return $"0{FeetSymbol}";
					}
					return $"0{FeetSymbol}{FeetInchesSeparator}0{InchesSymbol}";
				}
				if (SuppressZeroInches)
				{
					return $"{num}{FeetSymbol}";
				}
				return $"{num}{FeetSymbol}{FeetInchesSeparator}0{InchesSymbol}";
			}
			if (num == 0)
			{
				if (SuppressZeroFeet)
				{
					return $"{num3}{InchesSymbol}";
				}
				return $"0{FeetSymbol}{FeetInchesSeparator}{num3}{InchesSymbol}";
			}
			return $"{num}{FeetSymbol}{FeetInchesSeparator}{num3}{InchesSymbol}";
		}
		string result = string.Empty;
		string text = ((!SuppressZeroFeet || num != 0) ? (num + FeetSymbol + FeetInchesSeparator) : string.Empty);
		switch (FractionType)
		{
		case FractionFormat.Diagonal:
			result = $"\\A1;{text}{num3}{{\\H{FractionHeightScale}x;\\S{numerator}#{denominator};}}{InchesSymbol}";
			break;
		case FractionFormat.Horizontal:
			result = $"\\A1;{text}{num3}{{\\H{FractionHeightScale}x;\\S{numerator}/{denominator};}}{InchesSymbol}";
			break;
		case FractionFormat.None:
			result = $"{text}{num3} {numerator}/{denominator}{InchesSymbol}";
			break;
		}
		return result;
	}

	public string ToDecimal(double value, bool isAngular = false)
	{
		NumberFormatInfo numberFormatInfo = new NumberFormatInfo
		{
			NumberDecimalSeparator = DecimalSeparator
		};
		return value.ToString(GetZeroHandlingFormat(isAngular), numberFormatInfo);
	}

	public string ToDegreesMinutesSeconds(double angle)
	{
		double num = MathHelper.RadToDeg(angle);
		double num2 = (num - (double)(int)num) * 60.0;
		double value = (num2 - (double)(int)num2) * 60.0;
		NumberFormatInfo numberFormatInfo = new NumberFormatInfo
		{
			NumberDecimalSeparator = DecimalSeparator
		};
		if (AngularDecimalPlaces == 0)
		{
			return string.Format(numberFormatInfo, "{0}" + DegreesSymbol, (int)Math.Round(num, 0));
		}
		if (AngularDecimalPlaces == 1 || AngularDecimalPlaces == 2)
		{
			return string.Format(numberFormatInfo, "{0}" + DegreesSymbol + "{1}" + MinutesSymbol, (int)num, (int)Math.Round(num2, 0));
		}
		if (AngularDecimalPlaces == 3 || AngularDecimalPlaces == 4)
		{
			return string.Format(numberFormatInfo, "{0}" + DegreesSymbol + "{1}" + MinutesSymbol + "{2}" + SecondsSymbol, (int)num, (int)num2, (int)Math.Round(value, 0));
		}
		string text = "0." + new string('0', AngularDecimalPlaces - 4);
		return string.Format(numberFormatInfo, "{0}" + DegreesSymbol + "{1}" + MinutesSymbol + "{2}" + SecondsSymbol, (int)num, (int)num2, value.ToString(text, numberFormatInfo));
	}

	public string ToEngineering(double value)
	{
		NumberFormatInfo numberFormatInfo = new NumberFormatInfo
		{
			NumberDecimalSeparator = DecimalSeparator
		};
		int num = (int)(value / 12.0);
		double num2 = value - (double)(12 * num);
		if (MathHelper.IsZero(num2))
		{
			if (num == 0)
			{
				if (SuppressZeroFeet)
				{
					return $"0{InchesSymbol}";
				}
				if (SuppressZeroInches)
				{
					return $"0{FeetSymbol}";
				}
				return $"0{FeetSymbol}{FeetInchesSeparator}0{InchesSymbol}";
			}
			if (SuppressZeroInches)
			{
				return $"{num}{FeetSymbol}";
			}
			return $"{num}{FeetSymbol}{FeetInchesSeparator}0{InchesSymbol}";
		}
		string text = num2.ToString(GetZeroHandlingFormat(), numberFormatInfo);
		if (num == 0)
		{
			if (SuppressZeroFeet)
			{
				return $"{num2}{InchesSymbol}";
			}
			return $"0{FeetSymbol}{FeetInchesSeparator}{text}{InchesSymbol}";
		}
		return $"{num}{FeetSymbol}{FeetInchesSeparator}{text}{InchesSymbol}";
	}

	public string ToFractional(double value)
	{
		int num = (int)value;
		getFraction(value, (short)Math.Pow(2.0, LinearDecimalPlaces), out var numerator, out var denominator);
		if (numerator == 0)
		{
			return $"{(int)value}";
		}
		string result = string.Empty;
		switch (FractionType)
		{
		case FractionFormat.Diagonal:
			result = $"\\A1;{num}{{\\H{FractionHeightScale}x;\\S{numerator}#{denominator};}}";
			break;
		case FractionFormat.Horizontal:
			result = $"\\A1;{num}{{\\H{FractionHeightScale}x;\\S{numerator}/{denominator};}}";
			break;
		case FractionFormat.None:
		{
			string arg = ((num == 0) ? string.Empty : (num + " "));
			result = $"{arg}{numerator}/{denominator}";
			break;
		}
		}
		return result;
	}

	public string ToGradians(double angle)
	{
		NumberFormatInfo numberFormatInfo = new NumberFormatInfo
		{
			NumberDecimalSeparator = DecimalSeparator
		};
		return MathHelper.RadToGrad(angle).ToString(GetZeroHandlingFormat(isAngular: true), numberFormatInfo) + GradiansSymbol;
	}

	public string ToRadians(double angle)
	{
		NumberFormatInfo numberFormatInfo = new NumberFormatInfo
		{
			NumberDecimalSeparator = DecimalSeparator
		};
		return angle.ToString(GetZeroHandlingFormat(isAngular: true), numberFormatInfo) + RadiansSymbol;
	}

	public string ToScientific(double value)
	{
		return value.ToString(GetZeroHandlingFormat() + "E+00");
	}

	private static void getFraction(double number, int precision, out int numerator, out int denominator)
	{
		numerator = Convert.ToInt32((number - (double)(int)number) * (double)precision);
		int num = getGCD(numerator, precision);
		if (num <= 0)
		{
			num = 1;
		}
		numerator /= num;
		denominator = precision / num;
	}

	private static int getGCD(int number1, int number2)
	{
		int num = number1;
		int num2 = number2;
		while (num2 != 0)
		{
			int num3 = num % num2;
			num = num2;
			num2 = num3;
		}
		return num;
	}
}
