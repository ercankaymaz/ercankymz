using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Fonts.CompactFontFormat;
using UglyToad.PdfPig.Fonts.TrueType.Tables;

namespace UglyToad.PdfPig.Fonts.TrueType.Parser;

public static class TrueTypeFontParser
{
	public static TrueTypeFont Parse(TrueTypeDataBytes data)
	{
		float version = data.Read32Fixed();
		int num = data.ReadUnsignedShort();
		data.ReadUnsignedShort();
		data.ReadUnsignedShort();
		data.ReadUnsignedShort();
		Dictionary<string, TrueTypeHeaderTable> dictionary = new Dictionary<string, TrueTypeHeaderTable>(StringComparer.OrdinalIgnoreCase);
		for (int i = 0; i < num; i++)
		{
			TrueTypeHeaderTable? trueTypeHeaderTable = ReadTable(data);
			if (trueTypeHeaderTable.HasValue)
			{
				dictionary[trueTypeHeaderTable.Value.Tag] = trueTypeHeaderTable.Value;
			}
		}
		return ParseTables(version, dictionary, data);
	}

	private static TrueTypeHeaderTable? ReadTable(TrueTypeDataBytes data)
	{
		string text = data.ReadTag();
		uint checkSum = data.ReadUnsignedInt();
		uint offset = data.ReadUnsignedInt();
		uint num = data.ReadUnsignedInt();
		if (num == 0 && !string.Equals(text, "glyf", StringComparison.OrdinalIgnoreCase))
		{
			return null;
		}
		return new TrueTypeHeaderTable(text, checkSum, offset, num);
	}

	private static TrueTypeFont ParseTables(float version, IReadOnlyDictionary<string, TrueTypeHeaderTable> tables, TrueTypeDataBytes data)
	{
		bool flag = false;
		CompactFontFormatFontCollection cffFontCollection = null;
		if (tables.TryGetValue("cff ", out var value))
		{
			flag = true;
			try
			{
				data.Seek(value.Offset);
				cffFontCollection = CompactFontFormatParser.Parse(new CompactFontFormatData(data.ReadByteArray((int)value.Length)));
			}
			catch (Exception)
			{
			}
		}
		TableRegister.Builder builder = new TableRegister.Builder();
		if (!tables.TryGetValue("head", out var value2))
		{
			throw new InvalidFontFormatException("The head table is required.");
		}
		builder.HeaderTable = HeaderTable.Load(data, value2);
		if (!tables.TryGetValue("hhea", out var value3))
		{
			throw new InvalidFontFormatException("The horizontal header table is required.");
		}
		builder.HorizontalHeaderTable = TableParser.Parse<HorizontalHeaderTable>(value3, data, builder);
		if (!tables.TryGetValue("maxp", out var value4))
		{
			throw new InvalidFontFormatException("The maximum profile table is required.");
		}
		builder.MaximumProfileTable = BasicMaximumProfileTable.Load(data, value4);
		if (tables.TryGetValue("post", out var value5))
		{
			builder.PostScriptTable = PostScriptTable.Load(data, value5, builder.MaximumProfileTable);
		}
		if (tables.TryGetValue("name", out var value6))
		{
			builder.NameTable = TableParser.Parse<NameTable>(value6, data, builder);
		}
		if (tables.TryGetValue("OS/2", out var value7))
		{
			builder.Os2Table = TableParser.Parse<Os2Table>(value7, data, builder);
		}
		if (!flag)
		{
			if (!tables.TryGetValue("loca", out var value8))
			{
				throw new InvalidFontFormatException("The location to index table is required for non-PostScript fonts.");
			}
			builder.IndexToLocationTable = IndexToLocationTable.Load(data, value8, builder);
			if (!tables.TryGetValue("glyf", out var value9))
			{
				throw new InvalidFontFormatException("The glyph table is required for non-PostScript fonts.");
			}
			builder.GlyphDataTable = GlyphDataTable.Load(data, value9, builder);
		}
		OptionallyParseTables(tables, data, builder);
		return new TrueTypeFont(version, tables, builder.Build(), cffFontCollection);
	}

	internal static NameTable GetNameTable(TrueTypeDataBytes data)
	{
		if (data == null)
		{
			throw new ArgumentNullException("data");
		}
		data.Read32Fixed();
		int num = data.ReadUnsignedShort();
		data.ReadUnsignedShort();
		data.ReadUnsignedShort();
		data.ReadUnsignedShort();
		TrueTypeHeaderTable? trueTypeHeaderTable = null;
		for (int i = 0; i < num; i++)
		{
			TrueTypeHeaderTable? trueTypeHeaderTable2 = ReadTable(data);
			if (trueTypeHeaderTable2.HasValue && trueTypeHeaderTable2.Value.Tag == "name")
			{
				trueTypeHeaderTable = trueTypeHeaderTable2;
				break;
			}
		}
		if (!trueTypeHeaderTable.HasValue)
		{
			return null;
		}
		return TableParser.Parse<NameTable>(trueTypeHeaderTable.Value, data, new TableRegister.Builder());
	}

	private static void OptionallyParseTables(IReadOnlyDictionary<string, TrueTypeHeaderTable> tables, TrueTypeDataBytes data, TableRegister.Builder tableRegister)
	{
		if (tables.TryGetValue("cmap", out var value))
		{
			tableRegister.CMapTable = TableParser.Parse<CMapTable>(value, data, tableRegister);
		}
		if (tables.TryGetValue("hmtx", out var value2))
		{
			tableRegister.HorizontalMetricsTable = TableParser.Parse<HorizontalMetricsTable>(value2, data, tableRegister);
		}
		if (tables.TryGetValue("kern", out var value3))
		{
			tableRegister.KerningTable = KerningTable.Load(data, value3);
		}
	}
}
