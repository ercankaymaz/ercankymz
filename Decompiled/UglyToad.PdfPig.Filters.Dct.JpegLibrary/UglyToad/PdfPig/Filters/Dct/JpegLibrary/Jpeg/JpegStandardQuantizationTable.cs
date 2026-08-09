using System;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg;

internal static class JpegStandardQuantizationTable
{
	private static readonly ushort[] s_luminanceTable = new ushort[64]
	{
		16, 11, 12, 14, 12, 10, 16, 14, 13, 14,
		18, 17, 16, 19, 24, 40, 26, 24, 22, 22,
		24, 49, 35, 37, 29, 40, 58, 51, 61, 60,
		57, 51, 56, 55, 64, 72, 92, 78, 64, 68,
		87, 69, 55, 56, 80, 109, 81, 87, 95, 98,
		103, 104, 103, 62, 77, 113, 121, 112, 100, 120,
		92, 101, 103, 99
	};

	private static readonly ushort[] s_chrominanceTable = new ushort[64]
	{
		17, 18, 18, 24, 21, 24, 47, 26, 26, 47,
		99, 66, 56, 66, 99, 99, 99, 99, 99, 99,
		99, 99, 99, 99, 99, 99, 99, 99, 99, 99,
		99, 99, 99, 99, 99, 99, 99, 99, 99, 99,
		99, 99, 99, 99, 99, 99, 99, 99, 99, 99,
		99, 99, 99, 99, 99, 99, 99, 99, 99, 99,
		99, 99, 99, 99
	};

	public static JpegQuantizationTable GetLuminanceTable(JpegElementPrecision elementPrecision, byte identifier)
	{
		return new JpegQuantizationTable((byte)elementPrecision, identifier, s_luminanceTable);
	}

	public static JpegQuantizationTable GetChrominanceTable(JpegElementPrecision elementPrecision, byte identifier)
	{
		return new JpegQuantizationTable((byte)elementPrecision, identifier, s_chrominanceTable);
	}

	public static JpegQuantizationTable ScaleByQuality(JpegQuantizationTable quantizationTable, int quality)
	{
		if (quantizationTable.IsEmpty)
		{
			throw new ArgumentException("Quantization table is not initialized.", "quantizationTable");
		}
		int num;
		switch (quality)
		{
		default:
			throw new ArgumentOutOfRangeException("quality");
		case 50:
		case 51:
		case 52:
		case 53:
		case 54:
		case 55:
		case 56:
		case 57:
		case 58:
		case 59:
		case 60:
		case 61:
		case 62:
		case 63:
		case 64:
		case 65:
		case 66:
		case 67:
		case 68:
		case 69:
		case 70:
		case 71:
		case 72:
		case 73:
		case 74:
		case 75:
		case 76:
		case 77:
		case 78:
		case 79:
		case 80:
		case 81:
		case 82:
		case 83:
		case 84:
		case 85:
		case 86:
		case 87:
		case 88:
		case 89:
		case 90:
		case 91:
		case 92:
		case 93:
		case 94:
		case 95:
		case 96:
		case 97:
		case 98:
		case 99:
		case 100:
			num = 200 - quality * 2;
			break;
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
		case 9:
		case 10:
		case 11:
		case 12:
		case 13:
		case 14:
		case 15:
		case 16:
		case 17:
		case 18:
		case 19:
		case 20:
		case 21:
		case 22:
		case 23:
		case 24:
		case 25:
		case 26:
		case 27:
		case 28:
		case 29:
		case 30:
		case 31:
		case 32:
		case 33:
		case 34:
		case 35:
		case 36:
		case 37:
		case 38:
		case 39:
		case 40:
		case 41:
		case 42:
		case 43:
		case 44:
		case 45:
		case 46:
		case 47:
		case 48:
		case 49:
			num = 5000 / quality;
			break;
		}
		int num2 = num;
		ReadOnlySpan<ushort> elements = quantizationTable.Elements;
		ushort[] array = new ushort[64];
		for (int i = 0; i < array.Length; i++)
		{
			int num3 = elements[i];
			num3 = (num3 * num2 + 50) / 100;
			array[i] = (ushort)JpegMathHelper.Clamp(num3, 1, 255);
		}
		return new JpegQuantizationTable(quantizationTable.ElementPrecision, quantizationTable.Identifier, array);
	}
}
