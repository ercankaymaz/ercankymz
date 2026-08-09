using System;

namespace PdfSharp.Pdf.Filters;

public class Ascii85Decode : Filter
{
	public override byte[] Encode(byte[] data)
	{
		if (data == null)
		{
			throw new ArgumentNullException("data");
		}
		int num = data.Length;
		int num2 = num / 4;
		int num3 = num - num2 * 4;
		byte[] array = new byte[num2 * 5 + ((num3 != 0) ? (num3 + 1) : 0) + 2];
		int num4 = 0;
		int num5 = 0;
		for (int i = 0; i < num2; i++)
		{
			uint num6 = (uint)((data[num4++] << 24) + (data[num4++] << 16) + (data[num4++] << 8) + data[num4++]);
			if (num6 == 0)
			{
				array[num5++] = 122;
				continue;
			}
			byte b = (byte)(num6 % 85 + 33);
			num6 /= 85;
			byte b2 = (byte)(num6 % 85 + 33);
			num6 /= 85;
			byte b3 = (byte)(num6 % 85 + 33);
			num6 /= 85;
			byte b4 = (byte)(num6 % 85 + 33);
			num6 /= 85;
			byte b5 = (byte)(num6 + 33);
			array[num5++] = b5;
			array[num5++] = b4;
			array[num5++] = b3;
			array[num5++] = b2;
			array[num5++] = b;
		}
		switch (num3)
		{
		case 1:
		{
			uint num9 = (uint)(data[num4] << 24);
			num9 /= 614125;
			byte b13 = (byte)(num9 % 85 + 33);
			num9 /= 85;
			byte b14 = (byte)(num9 + 33);
			array[num5++] = b14;
			array[num5++] = b13;
			break;
		}
		case 2:
		{
			uint num8 = (uint)((data[num4++] << 24) + (data[num4] << 16));
			num8 /= 7225;
			byte b10 = (byte)(num8 % 85 + 33);
			num8 /= 85;
			byte b11 = (byte)(num8 % 85 + 33);
			num8 /= 85;
			byte b12 = (byte)(num8 + 33);
			array[num5++] = b12;
			array[num5++] = b11;
			array[num5++] = b10;
			break;
		}
		case 3:
		{
			uint num7 = (uint)((data[num4++] << 24) + (data[num4++] << 16) + (data[num4] << 8));
			num7 /= 85;
			byte b6 = (byte)(num7 % 85 + 33);
			num7 /= 85;
			byte b7 = (byte)(num7 % 85 + 33);
			num7 /= 85;
			byte b8 = (byte)(num7 % 85 + 33);
			num7 /= 85;
			byte b9 = (byte)(num7 + 33);
			array[num5++] = b9;
			array[num5++] = b8;
			array[num5++] = b7;
			array[num5++] = b6;
			break;
		}
		}
		array[num5++] = 126;
		array[num5++] = 62;
		if (num5 < array.Length)
		{
			Array.Resize(ref array, num5);
		}
		return array;
	}

	public override byte[] Decode(byte[] data, FilterParms parms)
	{
		if (data == null)
		{
			throw new ArgumentNullException("data");
		}
		int num = data.Length;
		int num2 = 0;
		int num3 = 0;
		int i;
		for (i = 0; i < num; i++)
		{
			char c = (char)data[i];
			if (c >= '!' && c <= 'u')
			{
				data[num3++] = (byte)c;
				continue;
			}
			switch (c)
			{
			case 'z':
				data[num3++] = (byte)c;
				num2++;
				continue;
			case '~':
				break;
			default:
				continue;
			}
			if (data[i + 1] != 62)
			{
				throw new ArgumentException("Illegal character.", "data");
			}
			break;
		}
		if (i == num)
		{
			throw new ArgumentException("Illegal character.", "data");
		}
		num = num3;
		int num4 = num - num2;
		int num5 = 4 * (num2 + num4 / 5);
		int num6 = num4 % 5;
		switch (num6)
		{
		case 1:
			throw new InvalidOperationException("Illegal character.");
		default:
			num5 += num6 - 1;
			break;
		case 0:
			break;
		}
		byte[] array = new byte[num5];
		num3 = 0;
		i = 0;
		while (i + 4 < num)
		{
			char c2 = (char)data[i];
			if (c2 == 'z')
			{
				i++;
				num3 += 4;
				continue;
			}
			long num7 = (long)(data[i++] - 33) * 52200625L + (uint)((data[i++] - 33) * 614125) + (uint)((data[i++] - 33) * 7225) + (uint)((data[i++] - 33) * 85) + (uint)(data[i++] - 33);
			if (num7 > uint.MaxValue)
			{
				throw new InvalidOperationException("Value of group greater than 2 power 32 - 1.");
			}
			array[num3++] = (byte)(num7 >> 24);
			array[num3++] = (byte)(num7 >> 16);
			array[num3++] = (byte)(num7 >> 8);
			array[num3++] = (byte)num7;
		}
		switch (num6)
		{
		case 2:
		{
			uint num11 = (uint)((data[i++] - 33) * 52200625 + (data[i] - 33) * 614125);
			if (num11 != 0)
			{
				num11 += 16777216;
			}
			array[num3] = (byte)(num11 >> 24);
			break;
		}
		case 3:
		{
			int num12 = i;
			uint num13 = (uint)((data[i++] - 33) * 52200625 + (data[i++] - 33) * 614125 + (data[i] - 33) * 7225);
			if (num13 != 0)
			{
				num13 &= 0xFFFF0000u;
				uint num14 = num13 / 7225;
				byte b5 = (byte)(num14 % 85 + 33);
				num14 /= 85;
				byte b6 = (byte)(num14 % 85 + 33);
				num14 /= 85;
				byte b7 = (byte)(num14 + 33);
				if (b7 != data[num12] || b6 != data[num12 + 1] || b5 != data[num12 + 2])
				{
					num13 += 65536;
				}
			}
			array[num3++] = (byte)(num13 >> 24);
			array[num3] = (byte)(num13 >> 16);
			break;
		}
		case 4:
		{
			int num8 = i;
			uint num9 = (uint)((data[i++] - 33) * 52200625 + (data[i++] - 33) * 614125 + (data[i++] - 33) * 7225 + (data[i] - 33) * 85);
			if (num9 != 0)
			{
				num9 &= 0xFFFFFF00u;
				uint num10 = num9 / 85;
				byte b = (byte)(num10 % 85 + 33);
				num10 /= 85;
				byte b2 = (byte)(num10 % 85 + 33);
				num10 /= 85;
				byte b3 = (byte)(num10 % 85 + 33);
				num10 /= 85;
				byte b4 = (byte)(num10 + 33);
				if (b4 != data[num8] || b3 != data[num8 + 1] || b2 != data[num8 + 2] || b != data[num8 + 3])
				{
					num9 += 256;
				}
			}
			array[num3++] = (byte)(num9 >> 24);
			array[num3++] = (byte)(num9 >> 16);
			array[num3] = (byte)(num9 >> 8);
			break;
		}
		}
		return array;
	}
}
