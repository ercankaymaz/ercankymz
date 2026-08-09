using System;

namespace UglyToad.PdfPig.Core;

public static class OctalHelpers
{
	public static short CharacterToShort(this char c)
	{
		return c switch
		{
			'0' => 0, 
			'1' => 1, 
			'2' => 2, 
			'3' => 3, 
			'4' => 4, 
			'5' => 5, 
			'6' => 6, 
			'7' => 7, 
			'8' => 8, 
			'9' => 9, 
			_ => throw new InvalidOperationException($"Could not convert the character {c} to a short."), 
		};
	}

	public static int FromOctalDigits(ReadOnlySpan<short> octal)
	{
		int num = 0;
		for (int num2 = octal.Length - 1; num2 >= 0; num2--)
		{
			int pow = num2;
			num += octal[num2] * QuickPower(8, pow);
		}
		return num;
	}

	private static int QuickPower(int x, int pow)
	{
		int num = 1;
		while (pow != 0)
		{
			if ((pow & 1) == 1)
			{
				num *= x;
			}
			x *= x;
			pow >>= 1;
		}
		return num;
	}
}
