using System;

namespace UglyToad.PdfPig.Util;

public static class Adler32Checksum
{
	private const int AdlerModulus = 65521;

	public static int Calculate(ReadOnlySpan<byte> data)
	{
		int num = 1;
		int num2 = 0;
		ReadOnlySpan<byte> readOnlySpan = data;
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			byte b = readOnlySpan[i];
			num = (num + b) % 65521;
			num2 = (num + num2) % 65521;
		}
		return num2 * 65536 + num;
	}
}
