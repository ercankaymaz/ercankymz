using System;

namespace UglyToad.PdfPig.Encryption;

internal static class RC4
{
	public static byte[] Encrypt(ReadOnlySpan<byte> key, ReadOnlySpan<byte> data)
	{
		Span<byte> span = stackalloc byte[256];
		for (int i = 0; i < 256; i++)
		{
			span[i] = (byte)i;
		}
		int num = 0;
		for (int j = 0; j < 256; j++)
		{
			num = (num + span[j] + key[j % key.Length]) % 256;
			byte b = span[j];
			span[j] = span[num];
			span[num] = b;
		}
		byte[] array = new byte[data.Length];
		num = 0;
		int num2 = 0;
		for (int k = 0; k < data.Length; k++)
		{
			num2 = (num2 + 1) % 256;
			num = (num + span[num2]) % 256;
			byte b2 = span[num2];
			span[num2] = span[num];
			span[num] = b2;
			byte b3 = span[(span[num2] + span[num]) % 256];
			array[k] = (byte)(data[k] ^ b3);
		}
		return array;
	}
}
