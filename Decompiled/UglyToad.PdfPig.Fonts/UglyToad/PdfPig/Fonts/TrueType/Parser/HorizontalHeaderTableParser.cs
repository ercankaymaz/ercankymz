using System;
using UglyToad.PdfPig.Fonts.TrueType.Tables;

namespace UglyToad.PdfPig.Fonts.TrueType.Parser;

internal class HorizontalHeaderTableParser : ITrueTypeTableParser<HorizontalHeaderTable>
{
	public HorizontalHeaderTable Parse(TrueTypeHeaderTable header, TrueTypeDataBytes data, TableRegister.Builder register)
	{
		data.Seek(header.Offset);
		ushort majorVersion = data.ReadUnsignedShort();
		ushort minorVersion = data.ReadUnsignedShort();
		short ascent = data.ReadSignedShort();
		short descent = data.ReadSignedShort();
		short lineGap = data.ReadSignedShort();
		ushort advanceWidthMaximum = data.ReadUnsignedShort();
		short minimumLeftSideBearing = data.ReadSignedShort();
		short minimumRightSideBearing = data.ReadSignedShort();
		short xMaxExtent = data.ReadSignedShort();
		short caretSlopeRise = data.ReadSignedShort();
		short caretSlopeRun = data.ReadSignedShort();
		short caretOffset = data.ReadSignedShort();
		data.ReadSignedShort();
		data.ReadSignedShort();
		data.ReadSignedShort();
		data.ReadSignedShort();
		short num = data.ReadSignedShort();
		if (num != 0)
		{
			throw new NotSupportedException("The metric data format for a horizontal header table should be 0.");
		}
		ushort numberOfHeaderMetrics = data.ReadUnsignedShort();
		return new HorizontalHeaderTable(header, majorVersion, minorVersion, ascent, descent, lineGap, advanceWidthMaximum, minimumLeftSideBearing, minimumRightSideBearing, xMaxExtent, caretSlopeRise, caretSlopeRun, caretOffset, num, numberOfHeaderMetrics);
	}
}
