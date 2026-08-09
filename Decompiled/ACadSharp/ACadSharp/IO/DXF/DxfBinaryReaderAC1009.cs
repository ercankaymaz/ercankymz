using System.IO;
using System.Text;

namespace ACadSharp.IO.DXF;

internal class DxfBinaryReaderAC1009 : DxfBinaryReader
{
	public DxfBinaryReaderAC1009(Stream stream, Encoding encoding)
		: base(stream, encoding)
	{
	}

	protected override DxfCode readCode()
	{
		int num = _stream.ReadByte();
		if (num == 255)
		{
			num = _stream.ReadInt16();
		}
		return (DxfCode)num;
	}
}
