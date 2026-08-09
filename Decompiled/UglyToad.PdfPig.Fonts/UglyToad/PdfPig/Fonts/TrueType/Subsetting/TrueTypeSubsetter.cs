using System;
using System.Collections.Generic;
using System.IO;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts.TrueType.Parser;
using UglyToad.PdfPig.Fonts.TrueType.Tables;
using UglyToad.PdfPig.Fonts.TrueType.Tables.CMapSubTables;

namespace UglyToad.PdfPig.Fonts.TrueType.Subsetting;

public static class TrueTypeSubsetter
{
	private class DirectoryEntry
	{
		public string Tag { get; }

		public long OutputEntryOffset { get; }

		public TrueTypeHeaderTable InputHeader { get; }

		public TrueTypeHeaderTable DummyHeader { get; }

		public long OutputTableOffset { get; set; }

		public uint Length { get; set; }

		public DirectoryEntry(string tag, long outputEntryOffset, TrueTypeHeaderTable inputHeader)
		{
			Tag = tag;
			OutputEntryOffset = outputEntryOffset;
			InputHeader = inputHeader;
			DummyHeader = TrueTypeHeaderTable.GetEmptyHeaderTable(tag);
		}
	}

	public readonly struct OldToNewGlyphIndex
	{
		public ushort OldIndex { get; }

		public byte NewIndex { get; }

		public char Represents { get; }

		public OldToNewGlyphIndex(ushort oldIndex, ushort newIndex, char represents)
		{
			OldIndex = oldIndex;
			NewIndex = (byte)newIndex;
			Represents = represents;
		}

		public override string ToString()
		{
			return $"{Represents}: From {OldIndex} To {NewIndex}.";
		}
	}

	private const ushort IndexToLocLong = 1;

	private static readonly IReadOnlyList<string> RequiredTags = new string[7] { "cmap", "glyf", "head", "hhea", "hmtx", "loca", "maxp" };

	private static readonly IReadOnlyList<string> OptionalTags = new string[4] { "cvt ", "fpgm", "prep", "name" };

	private static readonly byte[] PaddingBytes = new byte[4];

	public static byte[] Subset(byte[] fontBytes, TrueTypeSubsetEncoding newEncoding)
	{
		if (fontBytes == null)
		{
			throw new ArgumentNullException("fontBytes");
		}
		if (newEncoding == null)
		{
			throw new ArgumentNullException("newEncoding");
		}
		TrueTypeFont trueTypeFont = TrueTypeFontParser.Parse(new TrueTypeDataBytes(fontBytes));
		OldToNewGlyphIndex[] indexMapping = GetIndexMapping(trueTypeFont, newEncoding);
		using MemoryStream memoryStream = new MemoryStream();
		SortedSet<string> sortedSet = new SortedSet<string>(StringComparer.Ordinal);
		for (int i = 0; i < RequiredTags.Count; i++)
		{
			string text = RequiredTags[i];
			if (!trueTypeFont.TableHeaders.ContainsKey(text))
			{
				throw new InvalidFontFormatException("Font does not contain table required for subsetting: " + text + ".");
			}
			sortedSet.Add(text);
		}
		for (int j = 0; j < OptionalTags.Count; j++)
		{
			string text2 = OptionalTags[j];
			if (trueTypeFont.TableHeaders.ContainsKey(text2))
			{
				sortedSet.Add(text2);
			}
		}
		new TrueTypeOffsetSubtable((byte)sortedSet.Count).Write(memoryStream);
		DirectoryEntry[] array = new DirectoryEntry[sortedSet.Count];
		int num = 0;
		foreach (string item in sortedSet)
		{
			DirectoryEntry directoryEntry = new DirectoryEntry(item, memoryStream.Position, trueTypeFont.TableHeaders[item]);
			directoryEntry.DummyHeader.Write(memoryStream);
			array[num++] = directoryEntry;
		}
		TrueTypeSubsetGlyphTable trueTypeSubsetGlyphTable = TrueTypeGlyphTableSubsetter.SubsetGlyphTable(trueTypeFont, fontBytes, indexMapping);
		foreach (DirectoryEntry directoryEntry2 in array)
		{
			directoryEntry2.OutputTableOffset = memoryStream.Position;
			if (directoryEntry2.Tag == "cmap")
			{
				GetCMapTable(trueTypeFont, directoryEntry2, indexMapping).Write(memoryStream);
			}
			else if (directoryEntry2.Tag == "glyf")
			{
				memoryStream.Write(trueTypeSubsetGlyphTable.Bytes, 0, trueTypeSubsetGlyphTable.Bytes.Length);
			}
			else if (directoryEntry2.Tag == "hmtx")
			{
				GetHorizontalMetricsTable(directoryEntry2, trueTypeSubsetGlyphTable).Write(memoryStream);
			}
			else if (directoryEntry2.Tag == "loca")
			{
				new IndexToLocationTable(directoryEntry2.DummyHeader, IndexToLocationTable.EntryFormat.Long, trueTypeSubsetGlyphTable.GlyphOffsets).Write(memoryStream);
			}
			else if (directoryEntry2.Tag == "head")
			{
				byte[] rawInputTableBytes = GetRawInputTableBytes(fontBytes, directoryEntry2);
				WriteUShort(rawInputTableBytes, rawInputTableBytes.Length - 4, 1);
				memoryStream.Write(rawInputTableBytes, 0, rawInputTableBytes.Length);
			}
			else if (directoryEntry2.Tag == "hhea")
			{
				byte[] rawInputTableBytes2 = GetRawInputTableBytes(fontBytes, directoryEntry2);
				WriteUShort(rawInputTableBytes2, rawInputTableBytes2.Length - 2, (ushort)trueTypeSubsetGlyphTable.HorizontalMetrics.Length);
				memoryStream.Write(rawInputTableBytes2, 0, rawInputTableBytes2.Length);
			}
			else if (directoryEntry2.Tag == "maxp")
			{
				byte[] rawInputTableBytes3 = GetRawInputTableBytes(fontBytes, directoryEntry2);
				WriteUShort(rawInputTableBytes3, 4, trueTypeSubsetGlyphTable.GlyphCount);
				memoryStream.Write(rawInputTableBytes3, 0, rawInputTableBytes3.Length);
			}
			else
			{
				byte[] rawInputTableBytes4 = GetRawInputTableBytes(fontBytes, directoryEntry2);
				memoryStream.Write(rawInputTableBytes4, 0, rawInputTableBytes4.Length);
			}
			directoryEntry2.Length = (uint)(memoryStream.Position - directoryEntry2.OutputTableOffset);
			long num2 = memoryStream.Position % 4;
			if (num2 > 0)
			{
				long num3 = 4 - num2;
				memoryStream.Write(PaddingBytes, 0, (int)num3);
			}
		}
		using (StreamInputBytes bytes = new StreamInputBytes(memoryStream, shouldDispose: false))
		{
			foreach (DirectoryEntry directoryEntry3 in array)
			{
				TrueTypeHeaderTable table = new TrueTypeHeaderTable(directoryEntry3.Tag, 0u, (uint)directoryEntry3.OutputTableOffset, directoryEntry3.Length);
				uint checkSum = TrueTypeChecksumCalculator.Calculate(bytes, table);
				TrueTypeHeaderTable trueTypeHeaderTable = new TrueTypeHeaderTable(directoryEntry3.Tag, checkSum, (uint)directoryEntry3.OutputTableOffset, directoryEntry3.Length);
				memoryStream.Seek(directoryEntry3.OutputEntryOffset, SeekOrigin.Begin);
				trueTypeHeaderTable.Write(memoryStream);
			}
		}
		return memoryStream.ToArray();
	}

	private static OldToNewGlyphIndex[] GetIndexMapping(TrueTypeFont font, TrueTypeSubsetEncoding newEncoding)
	{
		OldToNewGlyphIndex[] array = new OldToNewGlyphIndex[newEncoding.Characters.Count + 1];
		array[0] = new OldToNewGlyphIndex(0, 0, '\0');
		ICMapSubTable iCMapSubTable = font.WindowsUnicodeCMap ?? font.WindowsSymbolCMap ?? font.MacRomanCMap;
		if (iCMapSubTable == null)
		{
			throw new InvalidOperationException("Cannot subset font due to missing cmap subtables.");
		}
		for (int i = 0; i < newEncoding.Characters.Count; i++)
		{
			char c = newEncoding.Characters[i];
			ushort oldIndex = (ushort)iCMapSubTable.CharacterCodeToGlyphIndex(c);
			array[i + 1] = new OldToNewGlyphIndex(oldIndex, (ushort)(i + 1), c);
		}
		return array;
	}

	private static CMapTable GetCMapTable(TrueTypeFont font, DirectoryEntry entry, OldToNewGlyphIndex[] encoding)
	{
		byte[] array = new byte[256];
		for (int i = 0; i < array.Length && i < encoding.Length; i++)
		{
			array[i] = encoding[i].NewIndex;
		}
		return new CMapTable(font.TableRegister.CMapTable.Version, entry.DummyHeader, new ByteEncodingCMapTable[1]
		{
			new ByteEncodingCMapTable(TrueTypeCMapPlatform.Macintosh, 0, 0, array)
		});
	}

	private static HorizontalMetricsTable GetHorizontalMetricsTable(DirectoryEntry entry, TrueTypeSubsetGlyphTable glyphTable)
	{
		return new HorizontalMetricsTable(entry.DummyHeader, glyphTable.HorizontalMetrics, Array.Empty<short>());
	}

	private static byte[] GetRawInputTableBytes(byte[] font, DirectoryEntry entry)
	{
		byte[] array = new byte[entry.InputHeader.Length];
		Array.Copy(font, entry.InputHeader.Offset, array, 0L, array.Length);
		return array;
	}

	private static void WriteUShort(byte[] array, int offset, ushort value)
	{
		array[offset] = (byte)(value >> 8);
		array[offset + 1] = (byte)value;
	}
}
