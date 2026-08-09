using System;
using System.Collections.Generic;
using System.IO;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts.TrueType.Parser;

namespace UglyToad.PdfPig.Fonts.TrueType.Tables;

public class IndexToLocationTable : ITrueTypeTable, IWriteable
{
	public enum EntryFormat : short
	{
		Short,
		Long
	}

	public string Tag => "loca";

	public TrueTypeHeaderTable DirectoryTable { get; }

	public EntryFormat Format { get; }

	public IReadOnlyList<uint> GlyphOffsets { get; }

	public IndexToLocationTable(TrueTypeHeaderTable directoryTable, EntryFormat format, IReadOnlyList<uint> glyphOffsets)
	{
		DirectoryTable = directoryTable;
		Format = format;
		GlyphOffsets = glyphOffsets ?? throw new ArgumentNullException("glyphOffsets");
	}

	internal static IndexToLocationTable Load(TrueTypeDataBytes data, TrueTypeHeaderTable table, TableRegister.Builder tableRegister)
	{
		if (data == null)
		{
			throw new ArgumentNullException("data");
		}
		if (tableRegister == null)
		{
			throw new ArgumentNullException("tableRegister");
		}
		data.Seek(table.Offset);
		HeaderTable headerTable = tableRegister.HeaderTable;
		BasicMaximumProfileTable maximumProfileTable = tableRegister.MaximumProfileTable;
		if (headerTable == null)
		{
			throw new InvalidFontFormatException("No header (head) table was defined in this font.");
		}
		if (maximumProfileTable == null)
		{
			throw new InvalidFontFormatException("No maximum profile (maxp) table was defined in this font.");
		}
		EntryFormat indexToLocFormat = headerTable.IndexToLocFormat;
		int num = maximumProfileTable.NumberOfGlyphs + 1;
		uint[] array;
		switch (indexToLocFormat)
		{
		case EntryFormat.Short:
		{
			array = new uint[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = (uint)(data.ReadUnsignedShort() * 2);
			}
			break;
		}
		case EntryFormat.Long:
			array = data.ReadUnsignedIntArray(num);
			break;
		default:
			throw new InvalidOperationException($"The format {indexToLocFormat} was invalid for the index to location (loca) table.");
		}
		return new IndexToLocationTable(table, indexToLocFormat, array);
	}

	public void Write(Stream stream)
	{
		for (int i = 0; i < GlyphOffsets.Count; i++)
		{
			uint num = GlyphOffsets[i];
			switch (Format)
			{
			case EntryFormat.Short:
				stream.WriteUShort((ushort)num / 2);
				break;
			case EntryFormat.Long:
				stream.WriteUInt(num);
				break;
			default:
				throw new InvalidOperationException($"The format {Format} was invalid for the index to location (loca) table.");
			}
		}
	}
}
