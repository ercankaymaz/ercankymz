namespace UglyToad.PdfPig.Fonts.TrueType.Tables;

public class HorizontalHeaderTable : ITrueTypeTable
{
	public string Tag => "hhea";

	public TrueTypeHeaderTable DirectoryTable { get; }

	public int MajorVersion { get; }

	public int MinorVersion { get; }

	public short Ascent { get; }

	public short Descent { get; }

	public short LineGap { get; }

	public ushort AdvanceWidthMaximum { get; }

	public short MinimumLeftSideBearing { get; }

	public short MinimumRightSideBearing { get; }

	public short XMaxExtent { get; }

	public short CaretSlopeRise { get; }

	public short CaretSlopeRun { get; }

	public short CaretOffset { get; }

	public short MetricDataFormat { get; }

	public ushort NumberOfHeaderMetrics { get; }

	public HorizontalHeaderTable(TrueTypeHeaderTable directoryTable, int majorVersion, int minorVersion, short ascent, short descent, short lineGap, ushort advanceWidthMaximum, short minimumLeftSideBearing, short minimumRightSideBearing, short xMaxExtent, short caretSlopeRise, short caretSlopeRun, short caretOffset, short metricDataFormat, ushort numberOfHeaderMetrics)
	{
		DirectoryTable = directoryTable;
		MajorVersion = majorVersion;
		MinorVersion = minorVersion;
		Ascent = ascent;
		Descent = descent;
		LineGap = lineGap;
		AdvanceWidthMaximum = advanceWidthMaximum;
		MinimumLeftSideBearing = minimumLeftSideBearing;
		MinimumRightSideBearing = minimumRightSideBearing;
		XMaxExtent = xMaxExtent;
		CaretSlopeRise = caretSlopeRise;
		CaretSlopeRun = caretSlopeRun;
		CaretOffset = caretOffset;
		MetricDataFormat = metricDataFormat;
		NumberOfHeaderMetrics = numberOfHeaderMetrics;
	}
}
