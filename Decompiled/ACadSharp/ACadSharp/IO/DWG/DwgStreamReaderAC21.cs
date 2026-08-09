using System.IO;
using System.Text;
using CSUtilities.Converters;

namespace ACadSharp.IO.DWG;

internal class DwgStreamReaderAC21 : DwgStreamReaderAC18
{
	public DwgStreamReaderAC21(Stream stream, bool resetPosition)
		: base(stream, resetPosition)
	{
	}

	public override string ReadTextUnicode()
	{
		short num = ReadShort<LittleEndianConverter>();
		if (num == 0)
		{
			return string.Empty;
		}
		short length = (short)(num << 1);
		return ReadString(length, Encoding.Unicode).Replace("\0", "");
	}

	public override string ReadVariableText()
	{
		int num = ReadBitShort();
		if (num == 0)
		{
			return string.Empty;
		}
		short length = (short)(num << 1);
		return ReadString(length, Encoding.Unicode).Replace("\0", "");
	}
}
