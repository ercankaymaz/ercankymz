using System.IO;
using CSMath;

namespace ACadSharp.IO.DWG;

internal class DwgStreamReaderAC15 : DwgStreamReaderAC12
{
	public DwgStreamReaderAC15(Stream stream, bool resetPosition)
		: base(stream, resetPosition)
	{
	}

	public override XYZ ReadBitExtrusion()
	{
		if (!ReadBit())
		{
			return Read3BitDouble();
		}
		return XYZ.AxisZ;
	}

	public override double ReadBitThickness()
	{
		if (!ReadBit())
		{
			return ReadBitDouble();
		}
		return 0.0;
	}
}
