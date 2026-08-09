using System;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Tokenization;

internal sealed class NumericTokenizer : ITokenizer
{
	private const byte Zero = 48;

	private const byte Nine = 57;

	private const byte Negative = 45;

	private const byte Positive = 43;

	private const byte Period = 46;

	private const byte ExponentLower = 101;

	private const byte ExponentUpper = 69;

	public bool ReadsNextByte => true;

	public bool TryTokenize(byte currentByte, IInputBytes inputBytes, out IToken? token)
	{
		token = null;
		int num = 0;
		bool flag = false;
		double num2 = 0.0;
		bool flag2 = false;
		long num3 = 0L;
		int num4 = 0;
		bool flag3 = false;
		bool flag4 = false;
		int num5 = 0;
		do
		{
			byte currentByte2 = inputBytes.CurrentByte;
			if (currentByte2 >= 48 && currentByte2 <= 57)
			{
				if (flag3)
				{
					num5 = num5 * 10 + (currentByte2 - 48);
				}
				else if (flag2)
				{
					num3 = num3 * 10 + (currentByte2 - 48);
					num4++;
				}
				else
				{
					num2 = num2 * 10.0 + (double)(currentByte2 - 48);
				}
				goto IL_00c5;
			}
			switch (currentByte2)
			{
			case 45:
				if (flag3)
				{
					flag4 = true;
				}
				else
				{
					flag = true;
				}
				goto IL_00c5;
			case 46:
				if (flag3 || flag2)
				{
					return false;
				}
				flag2 = true;
				goto IL_00c5;
			case 69:
			case 101:
				if (num == 0)
				{
					return false;
				}
				if (flag3)
				{
					return false;
				}
				flag3 = true;
				goto IL_00c5;
			case 43:
				goto IL_00c5;
			}
			if (num != 0)
			{
				break;
			}
			return false;
			IL_00c5:
			num++;
		}
		while (inputBytes.MoveNext());
		if (flag3 && !flag4)
		{
			double num6 = num2 * Pow10(num4) + (double)num3;
			int num7 = num5 - num4;
			num2 = ((num7 < 0) ? (num6 / Pow10(-num7)) : (num6 * Pow10(num7)));
			flag2 = false;
			flag3 = false;
		}
		if (flag2 && num4 > 0)
		{
			num2 = num4 switch
			{
				1 => num2 + (double)num3 / 10.0, 
				2 => num2 + (double)num3 / 100.0, 
				3 => num2 + (double)num3 / 1000.0, 
				_ => num2 + (double)num3 / Math.Pow(10.0, num4), 
			};
		}
		if (flag3)
		{
			int num8 = (flag4 ? (-num5) : num5);
			num2 *= Math.Pow(10.0, num8);
		}
		if (flag)
		{
			num2 = 0.0 - num2;
		}
		if (num2 == 0.0)
		{
			token = NumericToken.Zero;
		}
		else
		{
			token = new NumericToken(num2);
		}
		return true;
	}

	private static double Pow10(int exp)
	{
		return exp switch
		{
			0 => 1.0, 
			1 => 10.0, 
			2 => 100.0, 
			3 => 1000.0, 
			4 => 10000.0, 
			5 => 100000.0, 
			6 => 1000000.0, 
			7 => 10000000.0, 
			8 => 100000000.0, 
			9 => 1000000000.0, 
			_ => Math.Pow(10.0, exp), 
		};
	}
}
