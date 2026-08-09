using System;
using System.Text;

namespace Xbim.IO.Step21;

public static class StepGuidHelper
{
	private const string CConversionTable = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz_$";

	public static string ToPart21(this Guid guid)
	{
		return $"{ConvertToBase64(guid)}";
	}

	public static string ConvertToBase64(Guid guid)
	{
		byte[] array = guid.ToByteArray();
		uint num = BitConverter.ToUInt32(array, 0);
		ushort num2 = BitConverter.ToUInt16(array, 4);
		ushort num3 = BitConverter.ToUInt16(array, 6);
		uint[] array2 = new uint[6]
		{
			num / 16777216,
			num % 16777216,
			(uint)(num2 * 256 + num3 / 256),
			(uint)(num3 % 256 * 65536 + array[8] * 256 + array[9]),
			(uint)(array[10] * 65536 + array[11] * 256 + array[12]),
			(uint)(array[13] * 65536 + array[14] * 256 + array[15])
		};
		int nDigits = 2;
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < 6; i++)
		{
			stringBuilder.Append(To64String(array2[i], nDigits));
			nDigits = 4;
		}
		return stringBuilder.ToString();
	}

	private static string To64String(uint num, int nDigits)
	{
		char[] array = new char[nDigits];
		uint num2 = num;
		for (int i = 0; i < nDigits; i++)
		{
			array[nDigits - i - 1] = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz_$"[(int)(num2 % 64)];
			num2 /= 64;
		}
		return new string(array);
	}
}
