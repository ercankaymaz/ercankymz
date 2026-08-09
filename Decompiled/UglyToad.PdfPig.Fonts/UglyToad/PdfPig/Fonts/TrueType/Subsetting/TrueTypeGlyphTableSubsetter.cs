using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts.TrueType.Glyphs;
using UglyToad.PdfPig.Fonts.TrueType.Tables;

namespace UglyToad.PdfPig.Fonts.TrueType.Subsetting;

internal static class TrueTypeGlyphTableSubsetter
{
	private class GlyphRecord
	{
		public int Offset { get; }

		public GlyphType Type { get; }

		public int DataLength { get; }

		public IReadOnlyList<CompositeGlyphIndexReference> DependencyIndices { get; }

		public GlyphRecord(int offset, GlyphType type, int dataLength, IReadOnlyList<CompositeGlyphIndexReference> dependentIndices = null)
		{
			Offset = offset;
			Type = type;
			DataLength = dataLength;
			DependencyIndices = dependentIndices ?? Array.Empty<CompositeGlyphIndexReference>();
		}

		public GlyphRecord(int offset)
		{
			Offset = offset;
			Type = GlyphType.Empty;
			DataLength = 0;
			DependencyIndices = Array.Empty<CompositeGlyphIndexReference>();
		}
	}

	private enum GlyphType
	{
		Empty,
		Simple,
		Composite
	}

	private readonly struct CompositeGlyphIndexReference
	{
		public uint Index { get; }

		public uint OffsetOfIndexWithinData { get; }

		public CompositeGlyphIndexReference(uint index, uint offsetOfIndexWithinData)
		{
			Index = index;
			OffsetOfIndexWithinData = offsetOfIndexWithinData;
		}
	}

	public static TrueTypeSubsetGlyphTable SubsetGlyphTable(TrueTypeFont font, byte[] fontBytes, TrueTypeSubsetter.OldToNewGlyphIndex[] mapping)
	{
		if (font == null)
		{
			throw new ArgumentNullException("font");
		}
		if (fontBytes == null)
		{
			throw new ArgumentNullException("fontBytes");
		}
		if (mapping == null)
		{
			throw new ArgumentNullException("mapping");
		}
		TrueTypeDataBytes trueTypeDataBytes = new TrueTypeDataBytes(fontBytes);
		HorizontalMetricsTable horizontalMetricsTable = font.TableRegister.HorizontalMetricsTable;
		if (horizontalMetricsTable == null)
		{
			throw new InvalidFontFormatException($"Font: {font} did not contain a horizontal metrics table, cannot subset.");
		}
		GlyphRecord[] glyphRecordsInFont = GetGlyphRecordsInFont(font, trueTypeDataBytes);
		List<GlyphRecord> list = new List<GlyphRecord>(mapping.Length);
		List<int> list2 = new List<int>(mapping.Length);
		for (int i = 0; i < mapping.Length; i++)
		{
			TrueTypeSubsetter.OldToNewGlyphIndex oldToNewGlyphIndex = mapping[i];
			GlyphRecord item = glyphRecordsInFont[oldToNewGlyphIndex.OldIndex];
			list.Add(item);
			list2.Add(oldToNewGlyphIndex.OldIndex);
		}
		List<uint> list3 = new List<uint>();
		List<HorizontalMetric> list4 = new List<HorizontalMetric>();
		List<(uint, ushort)> list5 = new List<(uint, ushort)>();
		using ArrayPoolBufferWriter<byte> arrayPoolBufferWriter = new ArrayPoolBufferWriter<byte>();
		for (int j = 0; j < list.Count; j++)
		{
			list5.Clear();
			GlyphRecord glyphRecord = list[j];
			if (glyphRecord.Type == GlyphType.Composite)
			{
				for (int k = 0; k < glyphRecord.DependencyIndices.Count; k++)
				{
					CompositeGlyphIndexReference dependency = glyphRecord.DependencyIndices[k];
					int? num = GetAlreadyCopiedDependencyIndex(dependency, list2);
					if (!num.HasValue)
					{
						GlyphRecord item2 = glyphRecordsInFont[dependency.Index];
						num = list.Count;
						list.Add(item2);
						list2.Add((int)dependency.Index);
					}
					long num2 = dependency.OffsetOfIndexWithinData - glyphRecord.Offset;
					list5.Add(((uint)num2, (ushort)num.Value));
				}
			}
			list3.Add((uint)arrayPoolBufferWriter.WrittenCount);
			HorizontalMetric item3 = horizontalMetricsTable.HorizontalMetrics[list2[j]];
			list4.Add(item3);
			if (glyphRecord.Type == GlyphType.Empty)
			{
				continue;
			}
			trueTypeDataBytes.Seek(glyphRecord.Offset);
			byte[] array = trueTypeDataBytes.ReadByteArray(glyphRecord.DataLength);
			foreach (var (num3, num4) in list5)
			{
				array[num3] = (byte)(num4 >> 8);
				array[num3 + 1] = (byte)num4;
			}
			arrayPoolBufferWriter.Write(array);
			int num5 = array.Length % 4;
			int num6 = ((num5 != 0) ? (4 - num5) : 0);
			for (int l = 0; l < num6; l++)
			{
				arrayPoolBufferWriter.Write(0);
			}
		}
		byte[] array2 = arrayPoolBufferWriter.WrittenSpan.ToArray();
		list3.Add((uint)array2.Length);
		uint[] glyphOffsets = list3.ToArray();
		return new TrueTypeSubsetGlyphTable(array2, glyphOffsets, list4.ToArray());
	}

	private static GlyphRecord[] GetGlyphRecordsInFont(TrueTypeFont font, TrueTypeDataBytes data)
	{
		IndexToLocationTable indexToLocationTable = font.TableRegister.IndexToLocationTable;
		int num = indexToLocationTable.GlyphOffsets.Count - 1;
		TrueTypeHeaderTable directoryTable = font.TableRegister.GlyphTable.DirectoryTable;
		data.Seek(directoryTable.Offset);
		GlyphRecord[] array = new GlyphRecord[num];
		for (int i = 0; i < num; i++)
		{
			int num2 = (int)(directoryTable.Offset + indexToLocationTable.GlyphOffsets[i]);
			if (indexToLocationTable.GlyphOffsets[i + 1] <= indexToLocationTable.GlyphOffsets[i])
			{
				array[i] = new GlyphRecord(num2);
				continue;
			}
			data.Seek(num2);
			if (num2 >= directoryTable.Offset + directoryTable.Length)
			{
				throw new InvalidOperationException($"Failed to read expected number of glyphs {num}, only got to index {i} before reaching end of input.");
			}
			short num3 = data.ReadSignedShort();
			GlyphType glyphType = ((num3 >= 0) ? GlyphType.Simple : GlyphType.Composite);
			data.ReadSignedShort();
			data.ReadSignedShort();
			data.ReadSignedShort();
			data.ReadSignedShort();
			if (glyphType == GlyphType.Simple)
			{
				ReadSimpleGlyph(data, num3);
				array[i] = new GlyphRecord(num2, glyphType, (int)(data.Position - num2));
				continue;
			}
			IReadOnlyList<CompositeGlyphIndexReference> dependentIndices = ReadCompositeGlyph(data);
			uint num4 = indexToLocationTable.GlyphOffsets[i + 1];
			data.Seek(directoryTable.Offset + num4 - 1);
			array[i] = new GlyphRecord(num2, glyphType, (int)(data.Position - num2), dependentIndices);
		}
		return array;
	}

	private static int? GetAlreadyCopiedDependencyIndex(CompositeGlyphIndexReference dependency, IReadOnlyList<int> copiedGlyphOriginalIndices)
	{
		for (int i = 0; i < copiedGlyphOriginalIndices.Count; i++)
		{
			if (copiedGlyphOriginalIndices[i] == dependency.Index)
			{
				return i;
			}
		}
		return null;
	}

	private static void ReadSimpleGlyph(TrueTypeDataBytes data, int numberOfContours)
	{
		if (numberOfContours == 0)
		{
			return;
		}
		ushort[] array = new ushort[numberOfContours];
		for (int i = 0; i < numberOfContours; i++)
		{
			array[i] = data.ReadUnsignedShort();
		}
		ushort num = data.ReadUnsignedShort();
		byte[] array2 = new byte[num];
		for (int j = 0; j < num; j++)
		{
			array2[j] = data.ReadByte();
		}
		int num2 = array[numberOfContours - 1] + 1;
		SimpleGlyphFlags[] array3 = new SimpleGlyphFlags[num2];
		for (int k = 0; k < num2; k++)
		{
			SimpleGlyphFlags simpleGlyphFlags = (array3[k] = (SimpleGlyphFlags)data.ReadByte());
			if (HasFlag(simpleGlyphFlags, SimpleGlyphFlags.Repeat))
			{
				byte b = data.ReadByte();
				for (int l = 0; l < b; l++)
				{
					k++;
					array3[k] = simpleGlyphFlags;
				}
			}
		}
		ReadCoordinates(array3, data, SimpleGlyphFlags.XSingleByte, SimpleGlyphFlags.ThisXIsTheSame);
		ReadCoordinates(array3, data, SimpleGlyphFlags.YSingleByte, SimpleGlyphFlags.ThisYIsTheSame);
		static bool HasFlag(SimpleGlyphFlags flags, SimpleGlyphFlags value)
		{
			return (flags & value) != 0;
		}
	}

	private static short[] ReadCoordinates(SimpleGlyphFlags[] flags, TrueTypeDataBytes data, SimpleGlyphFlags isSingleByte, SimpleGlyphFlags isTheSameAsPrevious)
	{
		short[] array = new short[flags.Length];
		int num = 0;
		for (int i = 0; i < flags.Length; i++)
		{
			SimpleGlyphFlags set = flags[i];
			if (HasFlag(set, isSingleByte))
			{
				byte b = data.ReadByte();
				num = ((!HasFlag(set, isTheSameAsPrevious)) ? (num - b) : (num + b));
			}
			else
			{
				short num2 = (short)((!HasFlag(set, isTheSameAsPrevious)) ? data.ReadSignedShort() : 0);
				num += num2;
			}
			array[i] = (short)num;
		}
		return array;
		static bool HasFlag(SimpleGlyphFlags simpleGlyphFlags, SimpleGlyphFlags f)
		{
			return (simpleGlyphFlags & f) != 0;
		}
	}

	private static IReadOnlyList<CompositeGlyphIndexReference> ReadCompositeGlyph(TrueTypeDataBytes data)
	{
		List<CompositeGlyphIndexReference> list = new List<CompositeGlyphIndexReference>();
		CompositeGlyphFlags actual;
		do
		{
			actual = (CompositeGlyphFlags)data.ReadUnsignedShort();
			long position = data.Position;
			ushort index = data.ReadUnsignedShort();
			list.Add(new CompositeGlyphIndexReference(index, (uint)position));
			if (HasFlag(actual, CompositeGlyphFlags.Args1And2AreWords))
			{
				data.ReadSignedShort();
				data.ReadSignedShort();
			}
			else
			{
				data.ReadByte();
				data.ReadByte();
			}
			if (HasFlag(actual, CompositeGlyphFlags.WeHaveAScale))
			{
				data.ReadSignedShort();
			}
			else if (HasFlag(actual, CompositeGlyphFlags.WeHaveAnXAndYScale))
			{
				data.ReadSignedShort();
				data.ReadSignedShort();
			}
			else if (HasFlag(actual, CompositeGlyphFlags.WeHaveATwoByTwo))
			{
				data.ReadSignedShort();
				data.ReadSignedShort();
				data.ReadSignedShort();
				data.ReadSignedShort();
			}
		}
		while (HasFlag(actual, CompositeGlyphFlags.MoreComponents));
		return list;
		static bool HasFlag(CompositeGlyphFlags compositeGlyphFlags, CompositeGlyphFlags value)
		{
			return (compositeGlyphFlags & value) != 0;
		}
	}
}
