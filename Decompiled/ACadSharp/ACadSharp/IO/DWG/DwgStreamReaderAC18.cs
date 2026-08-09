using System.IO;
using CSUtilities.Converters;

namespace ACadSharp.IO.DWG;

internal class DwgStreamReaderAC18 : DwgStreamReaderAC15
{
	public DwgStreamReaderAC18(Stream stream, bool resetPosition)
		: base(stream, resetPosition)
	{
	}

	public override Color ReadCmColor(bool useTextStream = false)
	{
		Color color = default(Color);
		ReadBitShort();
		uint num = (uint)ReadBitLong();
		byte[] bytes = LittleEndianConverter.Instance.GetBytes(num);
		color = ((num == 3221225472u) ? Color.ByLayer : (((num & 0x1000000) == 0) ? new Color(bytes[2], bytes[1], bytes[0]) : new Color(bytes[0])));
		byte num2 = ReadByte();
		_ = string.Empty;
		if ((num2 & 1) == 1)
		{
			ReadVariableText();
		}
		_ = string.Empty;
		if ((num2 & 2) == 2)
		{
			ReadVariableText();
		}
		return color;
	}

	public override Color ReadEnColor(out Transparency transparency, out bool isBookColor)
	{
		Color color = default(Color);
		transparency = Transparency.ByLayer;
		isBookColor = false;
		short num = ReadBitShort();
		if (num != 0)
		{
			ushort num2 = (ushort)((ushort)num & 0xFF00);
			if ((num2 & 0x4000) > 0)
			{
				color = Color.ByBlock;
				isBookColor = true;
			}
			else if ((num2 & 0x8000) > 0)
			{
				uint value = (uint)ReadBitLong();
				byte[] bytes = LittleEndianConverter.Instance.GetBytes(value);
				color = new Color(bytes[2], bytes[1], bytes[0]);
			}
			else
			{
				color = new Color((short)(num & 0xFFF));
			}
			if ((long)(num2 & 0x2000) > 0L)
			{
				int value2 = ReadBitLong();
				transparency = Transparency.FromAlphaValue(value2);
			}
			else
			{
				transparency = Transparency.ByLayer;
			}
		}
		else
		{
			color = Color.ByBlock;
			transparency = Transparency.Opaque;
		}
		return color;
	}
}
