using System;

namespace PdfSharp.Pdf.Filters;

public class AsciiHexDecode : Filter
{
	public override byte[] Encode(byte[] data)
	{
		if (data == null)
		{
			throw new ArgumentNullException("data");
		}
		int num = data.Length;
		byte[] array = new byte[2 * num];
		int i = 0;
		int num2 = 0;
		for (; i < num; i++)
		{
			byte b = data[i];
			array[num2++] = (byte)((b >> 4) + ((b >> 4 < 10) ? 48 : 55));
			array[num2++] = (byte)((b & 0xF) + (((b & 0xF) < 10) ? 48 : 55));
		}
		return array;
	}

	public override byte[] Decode(byte[] data, FilterParms parms)
	{
		if (data == null)
		{
			throw new ArgumentNullException("data");
		}
		data = RemoveWhiteSpace(data);
		int num = data.Length;
		if (num > 0 && data[num - 1] == 62)
		{
			num--;
		}
		if (num % 2 == 1)
		{
			num++;
			byte[] array = data;
			data = new byte[num];
			array.CopyTo(data, 0);
		}
		num >>= 1;
		byte[] array2 = new byte[num];
		int i = 0;
		int num2 = 0;
		for (; i < num; i++)
		{
			byte b = data[num2++];
			byte b2 = data[num2++];
			if (b >= 97 && b <= 102)
			{
				b -= 32;
			}
			if (b2 >= 97 && b2 <= 102)
			{
				b2 -= 32;
			}
			array2[i] = (byte)(((b > 57) ? (b - 55) : (b - 48)) * 16 + ((b2 > 57) ? (b2 - 55) : (b2 - 48)));
		}
		return array2;
	}
}
