using System.IO;
using System.Text;
using CSUtilities.Converters;

namespace ACadSharp.IO.DWG;

internal class DwgStreamWriterAC24 : DwgStreamWriterAC21
{
	public DwgStreamWriterAC24(Stream stream, Encoding encoding)
		: base(stream, encoding)
	{
	}

	public override void WriteObjectType(short value)
	{
		if (value <= 255)
		{
			Write2Bits(0);
			WriteByte((byte)value);
		}
		else if (value >= 496 && value <= 751)
		{
			Write2Bits(1);
			WriteByte((byte)(value - 496));
		}
		else
		{
			Write2Bits(2);
			WriteBytes(LittleEndianConverter.Instance.GetBytes(value));
		}
	}
}
