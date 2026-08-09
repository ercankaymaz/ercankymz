using System.IO;
using System.Text;
using CSUtilities.Converters;

namespace ACadSharp.IO.DWG;

internal class DwgStreamWriterAC18 : DwgStreamWriterAC15
{
	public DwgStreamWriterAC18(Stream stream, Encoding encoding)
		: base(stream, encoding)
	{
	}

	public override void WriteCmColor(Color value)
	{
		WriteBitShort(0);
		byte[] array = new byte[4];
		if (value.IsTrueColor)
		{
			array[2] = value.R;
			array[1] = value.G;
			array[0] = value.B;
			array[3] = 194;
		}
		else if (value.IsByLayer)
		{
			array[3] = 192;
		}
		else
		{
			array[3] = 195;
			array[0] = (byte)value.Index;
		}
		WriteBitLong(LittleEndianConverter.Instance.ToInt32(array));
		WriteByte(0);
	}

	public override void WriteEnColor(Color color, Transparency transparency)
	{
		ushort num = 0;
		if (color.IsByBlock && transparency.IsByLayer)
		{
			WriteBitShort(0);
			return;
		}
		if (!transparency.IsByLayer)
		{
			num |= 0x2000;
		}
		num = ((!color.IsTrueColor) ? ((ushort)(num | (ushort)color.Index)) : ((ushort)(num | 0x8000)));
		WriteBitShort((short)num);
		if (color.IsTrueColor)
		{
			byte[] bytes = new byte[4] { color.B, color.G, color.R, 194 };
			uint value = LittleEndianConverter.Instance.ToUInt32(bytes);
			WriteBitLong((int)value);
		}
		if (!transparency.IsByLayer)
		{
			WriteBitLong(Transparency.ToAlphaValue(transparency));
		}
	}

	public override void WriteEnColor(Color color, Transparency transparency, bool isBookColor)
	{
		ushort num = 0;
		if (color.IsByBlock && transparency.IsByLayer && !isBookColor)
		{
			WriteBitShort(0);
			return;
		}
		if (!transparency.IsByLayer)
		{
			num |= 0x2000;
		}
		if (!isBookColor)
		{
			num = ((!color.IsTrueColor) ? ((ushort)(num | (ushort)color.Index)) : ((ushort)(num | 0x8000)));
		}
		else
		{
			num |= 0x4000;
			num |= 0x8000;
		}
		WriteBitShort((short)num);
		if (color.IsTrueColor)
		{
			byte[] bytes = new byte[4] { color.B, color.G, color.R, 194 };
			uint value = LittleEndianConverter.Instance.ToUInt32(bytes);
			WriteBitLong((int)value);
		}
		if (!transparency.IsByLayer)
		{
			WriteBitLong(Transparency.ToAlphaValue(transparency));
		}
	}
}
