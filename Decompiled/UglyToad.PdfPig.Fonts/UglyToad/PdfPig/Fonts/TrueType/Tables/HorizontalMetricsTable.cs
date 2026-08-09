using System;
using System.Collections.Generic;
using System.IO;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts.TrueType.Glyphs;

namespace UglyToad.PdfPig.Fonts.TrueType.Tables;

public class HorizontalMetricsTable : ITrueTypeTable, IWriteable
{
	public string Tag => "hmtx";

	public TrueTypeHeaderTable DirectoryTable { get; }

	public IReadOnlyList<HorizontalMetric> HorizontalMetrics { get; }

	public IReadOnlyList<short> AdditionalLeftSideBearings { get; }

	public HorizontalMetricsTable(TrueTypeHeaderTable directoryTable, IReadOnlyList<HorizontalMetric> horizontalMetrics, IReadOnlyList<short> additionalLeftSideBearings)
	{
		DirectoryTable = directoryTable;
		HorizontalMetrics = horizontalMetrics ?? throw new ArgumentNullException("horizontalMetrics");
		AdditionalLeftSideBearings = additionalLeftSideBearings ?? throw new ArgumentNullException("additionalLeftSideBearings");
	}

	public ushort GetAdvanceWidth(int index)
	{
		if (index < 0)
		{
			throw new ArgumentOutOfRangeException("index", "Index cannot be less than zero.");
		}
		if (index < HorizontalMetrics.Count)
		{
			return HorizontalMetrics[index].AdvanceWidth;
		}
		return HorizontalMetrics[HorizontalMetrics.Count - 1].AdvanceWidth;
	}

	public void Write(Stream stream)
	{
		for (int i = 0; i < HorizontalMetrics.Count; i++)
		{
			HorizontalMetric horizontalMetric = HorizontalMetrics[i];
			stream.WriteUShort(horizontalMetric.AdvanceWidth);
			stream.WriteShort(horizontalMetric.LeftSideBearing);
		}
		for (int j = 0; j < AdditionalLeftSideBearings.Count; j++)
		{
			short value = AdditionalLeftSideBearings[j];
			stream.WriteShort(value);
		}
	}
}
