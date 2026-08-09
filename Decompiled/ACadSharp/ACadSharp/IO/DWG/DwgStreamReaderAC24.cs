using System.IO;

namespace ACadSharp.IO.DWG;

internal class DwgStreamReaderAC24 : DwgStreamReaderAC21
{
	public DwgStreamReaderAC24(Stream stream, bool resetPosition)
		: base(stream, resetPosition)
	{
	}

	public override ObjectType ReadObjectType()
	{
		byte b = Read2Bits();
		short result = 0;
		switch (b)
		{
		case 0:
			result = ReadByte();
			break;
		case 1:
			result = (short)(496 + ReadByte());
			break;
		case 2:
			result = ReadShort();
			break;
		case 3:
			result = ReadShort();
			break;
		}
		return (ObjectType)result;
	}
}
