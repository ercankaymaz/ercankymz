using System;
using UglyToad.PdfPig.Fonts.TrueType.Tables;

namespace UglyToad.PdfPig.Fonts.TrueType.Parser;

public class TableRegister
{
	internal class Builder
	{
		public GlyphDataTable GlyphDataTable { get; set; }

		public HeaderTable HeaderTable { get; set; }

		public HorizontalHeaderTable HorizontalHeaderTable { get; set; }

		public HorizontalMetricsTable HorizontalMetricsTable { get; set; }

		public IndexToLocationTable IndexToLocationTable { get; set; }

		public BasicMaximumProfileTable MaximumProfileTable { get; set; }

		public PostScriptTable PostScriptTable { get; set; }

		public CMapTable CMapTable { get; set; }

		public KerningTable KerningTable { get; set; }

		public NameTable NameTable { get; set; }

		public Os2Table Os2Table { get; set; }

		public TableRegister Build()
		{
			return new TableRegister(this);
		}
	}

	public HeaderTable HeaderTable { get; }

	internal GlyphDataTable GlyphTable { get; }

	public HorizontalHeaderTable HorizontalHeaderTable { get; }

	public HorizontalMetricsTable HorizontalMetricsTable { get; }

	public IndexToLocationTable IndexToLocationTable { get; }

	internal BasicMaximumProfileTable MaximumProfileTable { get; }

	public NameTable NameTable { get; }

	public PostScriptTable PostScriptTable { get; }

	public CMapTable CMapTable { get; }

	internal KerningTable KerningTable { get; }

	public Os2Table Os2Table { get; }

	internal TableRegister(Builder builder)
	{
		if (builder == null)
		{
			throw new ArgumentNullException("builder");
		}
		HeaderTable = builder.HeaderTable ?? throw new ArgumentException("The builder did not contain the header table");
		GlyphTable = builder.GlyphDataTable;
		HorizontalHeaderTable = builder.HorizontalHeaderTable ?? throw new ArgumentException("The builder did not contain the horizontal header table.");
		HorizontalMetricsTable = builder.HorizontalMetricsTable;
		IndexToLocationTable = builder.IndexToLocationTable;
		MaximumProfileTable = builder.MaximumProfileTable ?? throw new ArgumentException("The builder did not contain the maximum profile table.");
		NameTable = builder.NameTable;
		PostScriptTable = builder.PostScriptTable;
		CMapTable = builder.CMapTable;
		KerningTable = builder.KerningTable;
		Os2Table = builder.Os2Table;
	}
}
