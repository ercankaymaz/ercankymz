using System.IO;
using System.Text;
using CSMath;

namespace ACadSharp.IO.DWG;

internal class DwgStreamWriterAC15 : DwgStreamWriterAC12
{
	public DwgStreamWriterAC15(Stream stream, Encoding encoding)
		: base(stream, encoding)
	{
	}

	public override void WriteBitExtrusion(XYZ normal)
	{
		if (normal == XYZ.AxisZ)
		{
			WriteBit(value: true);
			return;
		}
		WriteBit(value: false);
		Write3BitDouble(normal);
	}

	public override void WriteBitThickness(double thickness)
	{
		if (thickness == 0.0)
		{
			WriteBit(value: true);
			return;
		}
		WriteBit(value: false);
		WriteBitDouble(thickness);
	}
}
