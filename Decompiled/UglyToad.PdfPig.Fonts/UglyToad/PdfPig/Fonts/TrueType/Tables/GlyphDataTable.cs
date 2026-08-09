using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Fonts.TrueType.Glyphs;
using UglyToad.PdfPig.Fonts.TrueType.Parser;

namespace UglyToad.PdfPig.Fonts.TrueType.Tables;

internal sealed class GlyphDataTable : ITrueTypeTable
{
	private readonly struct TemporaryCompositeLocation
	{
		public long Position { get; }

		public PdfRectangle Bounds { get; }

		public TemporaryCompositeLocation(long position, PdfRectangle bounds, short contourCount)
		{
			if (contourCount >= 0)
			{
				throw new ArgumentException($"A composite glyph should not have a positive contour count. Got: {contourCount}.", "contourCount");
			}
			Position = position;
			Bounds = bounds;
		}
	}

	private sealed class CompositeComponent
	{
		public int Index { get; }

		public CompositeTransformMatrix3By2 Transformation { get; }

		public CompositeComponent(int index, CompositeTransformMatrix3By2 transformation)
		{
			Index = index;
			Transformation = transformation;
		}
	}

	private readonly IReadOnlyList<uint> glyphOffsets;

	private readonly PdfRectangle maxGlyphBounds;

	private TrueTypeDataBytes tableBytes;

	private readonly Lazy<IReadOnlyList<IGlyphDescription>> glyphs;

	public string Tag => "glyf";

	public TrueTypeHeaderTable DirectoryTable { get; }

	public IReadOnlyList<IGlyphDescription> Glyphs => glyphs.Value;

	public GlyphDataTable(TrueTypeHeaderTable directoryTable, IReadOnlyList<uint> glyphOffsets, PdfRectangle maxGlyphBounds, TrueTypeDataBytes tableBytes)
	{
		this.glyphOffsets = glyphOffsets;
		this.maxGlyphBounds = maxGlyphBounds;
		this.tableBytes = tableBytes;
		DirectoryTable = directoryTable;
		if (tableBytes == null)
		{
			throw new ArgumentNullException("tableBytes");
		}
		if (glyphOffsets == null)
		{
			throw new ArgumentNullException("glyphOffsets");
		}
		if (tableBytes.Length != directoryTable.Length)
		{
			throw new ArgumentException($"glyf table data should match length of directory entry. Expected: {directoryTable.Length}. Actual: {tableBytes.Length}.");
		}
		glyphs = new Lazy<IReadOnlyList<IGlyphDescription>>(ReadGlyphs);
	}

	public bool TryGetGlyphBounds(int glyphIndex, out PdfRectangle bounds)
	{
		bounds = default(PdfRectangle);
		if (glyphIndex < 0 || glyphIndex >= glyphOffsets.Count - 1)
		{
			return false;
		}
		uint num = glyphOffsets[glyphIndex];
		if (glyphOffsets[glyphIndex + 1] <= num)
		{
			bounds = new PdfRectangle(0, 0, 0, 0);
			return true;
		}
		bounds = Glyphs[glyphIndex].Bounds;
		return true;
	}

	public bool TryGetGlyphPath(int glyphIndex, out IReadOnlyList<PdfSubpath> subpaths)
	{
		subpaths = null;
		if (glyphIndex < 0 || glyphIndex > Glyphs.Count - 1)
		{
			return false;
		}
		return Glyphs[glyphIndex].TryGetGlyphPath(out subpaths);
	}

	public static GlyphDataTable Load(TrueTypeDataBytes data, TrueTypeHeaderTable table, TableRegister.Builder tableRegister)
	{
		data.Seek(table.Offset);
		byte[] bytes = data.ReadByteArray((int)table.Length);
		return new GlyphDataTable(table, tableRegister.IndexToLocationTable.GlyphOffsets, tableRegister.HeaderTable.Bounds, new TrueTypeDataBytes(bytes));
	}

	private IReadOnlyList<IGlyphDescription> ReadGlyphs()
	{
		if (tableBytes == null)
		{
			throw new InvalidOperationException("Bytes cache was discarded before lazy value evaluated.");
		}
		TrueTypeDataBytes trueTypeDataBytes = tableBytes;
		IReadOnlyList<uint> readOnlyList = glyphOffsets;
		int num = readOnlyList.Count - 1;
		IGlyphDescription[] array = new IGlyphDescription[num];
		IGlyphDescription glyphDescription = Glyph.Empty(maxGlyphBounds);
		Dictionary<int, TemporaryCompositeLocation> dictionary = new Dictionary<int, TemporaryCompositeLocation>();
		for (int i = 0; i < num; i++)
		{
			uint num2 = readOnlyList[i];
			if (readOnlyList[i + 1] <= num2)
			{
				array[i] = glyphDescription;
				continue;
			}
			if (num2 >= trueTypeDataBytes.Length)
			{
				array[i] = glyphDescription;
				continue;
			}
			trueTypeDataBytes.Seek(num2);
			short num3 = trueTypeDataBytes.ReadSignedShort();
			short x = trueTypeDataBytes.ReadSignedShort();
			short y = trueTypeDataBytes.ReadSignedShort();
			short x2 = trueTypeDataBytes.ReadSignedShort();
			short y2 = trueTypeDataBytes.ReadSignedShort();
			PdfRectangle bounds = new PdfRectangle(x, y, x2, y2);
			if (num3 >= 0)
			{
				array[i] = ReadSimpleGlyph(trueTypeDataBytes, num3, bounds);
			}
			else
			{
				dictionary.Add(i, new TemporaryCompositeLocation(trueTypeDataBytes.Position, bounds, num3));
			}
		}
		foreach (KeyValuePair<int, TemporaryCompositeLocation> item in dictionary)
		{
			array[item.Key] = ReadCompositeGlyph(trueTypeDataBytes, item.Value, dictionary, array, glyphDescription);
		}
		tableBytes = null;
		return array;
	}

	private static Glyph ReadSimpleGlyph(TrueTypeDataBytes data, short contourCount, PdfRectangle bounds)
	{
		if (contourCount == 0)
		{
			return new Glyph(isSimple: true, Array.Empty<byte>(), Array.Empty<ushort>(), Array.Empty<GlyphPoint>(), new PdfRectangle(0, 0, 0, 0));
		}
		ushort[] array = data.ReadUnsignedShortArray(contourCount);
		ushort length = data.ReadUnsignedShort();
		byte[] instructions = data.ReadByteArray(length);
		int pointCount = 0;
		if (contourCount > 0)
		{
			pointCount = array[contourCount - 1] + 1;
		}
		SimpleGlyphFlags[] array2 = ReadFlags(data, pointCount);
		short[] array3 = ReadCoordinates(data, pointCount, array2, SimpleGlyphFlags.XSingleByte, SimpleGlyphFlags.ThisXIsTheSame);
		short[] array4 = ReadCoordinates(data, pointCount, array2, SimpleGlyphFlags.YSingleByte, SimpleGlyphFlags.ThisYIsTheSame);
		int num = array.Length - 1;
		int num2 = -1;
		GlyphPoint[] array5 = new GlyphPoint[array3.Length];
		for (int num3 = array3.Length - 1; num3 >= 0; num3--)
		{
			if (num2 == -1)
			{
				num2 = array[num];
			}
			bool flag = num2 == num3;
			if (flag && num > 0)
			{
				num--;
				num2 = -1;
			}
			bool isOnCurve = (array2[num3] & SimpleGlyphFlags.OnCurve) == SimpleGlyphFlags.OnCurve;
			array5[num3] = new GlyphPoint(array3[num3], array4[num3], isOnCurve, flag);
		}
		return new Glyph(isSimple: true, instructions, array, array5, bounds);
	}

	private static IGlyphDescription ReadCompositeGlyph(TrueTypeDataBytes data, TemporaryCompositeLocation compositeLocation, Dictionary<int, TemporaryCompositeLocation> compositeLocations, IGlyphDescription[] glyphs, IGlyphDescription emptyGlyph)
	{
		data.Seek(compositeLocation.Position);
		List<CompositeComponent> list = new List<CompositeComponent>();
		CompositeGlyphFlags value;
		do
		{
			value = (CompositeGlyphFlags)data.ReadUnsignedShort();
			ushort num = data.ReadUnsignedShort();
			if (num >= glyphs.Length)
			{
				continue;
			}
			IGlyphDescription glyphDescription = glyphs[num];
			if (glyphDescription == null)
			{
				if (!compositeLocations.TryGetValue(num, out var value2))
				{
					throw new InvalidOperationException($"The composite glyph required a contour at index {num} but there was no simple or composite glyph at this location.");
				}
				long position = data.Position;
				glyphDescription = ReadCompositeGlyph(data, value2, compositeLocations, glyphs, emptyGlyph);
				data.Seek(position);
				glyphs[num] = glyphDescription;
			}
			short num2;
			short num3;
			if (HasFlag(value, CompositeGlyphFlags.Args1And2AreWords))
			{
				num2 = data.ReadSignedShort();
				num3 = data.ReadSignedShort();
			}
			else
			{
				num2 = data.ReadByte();
				num3 = data.ReadByte();
			}
			double num4 = 1.0;
			double r0C = 0.0;
			double r1C = 0.0;
			double r1C2 = 1.0;
			if (HasFlag(value, CompositeGlyphFlags.WeHaveAScale))
			{
				num4 = ReadTwoFourteenFormat(data);
				r1C2 = num4;
			}
			else if (HasFlag(value, CompositeGlyphFlags.WeHaveAnXAndYScale))
			{
				num4 = ReadTwoFourteenFormat(data);
				r1C2 = ReadTwoFourteenFormat(data);
			}
			else if (HasFlag(value, CompositeGlyphFlags.WeHaveATwoByTwo))
			{
				num4 = ReadTwoFourteenFormat(data);
				r0C = ReadTwoFourteenFormat(data);
				r1C = ReadTwoFourteenFormat(data);
				r1C2 = ReadTwoFourteenFormat(data);
			}
			if (HasFlag(value, CompositeGlyphFlags.ArgsAreXAndYValues))
			{
				list.Add(new CompositeComponent(num, new CompositeTransformMatrix3By2(num4, r0C, r1C, r1C2, num2, num3)));
			}
		}
		while (HasFlag(value, CompositeGlyphFlags.MoreComponents));
		IGlyphDescription glyphDescription2 = null;
		foreach (CompositeComponent item in list)
		{
			IGlyphDescription glyphDescription3 = glyphs[item.Index].Transform(item.Transformation);
			glyphDescription2 = ((glyphDescription2 != null) ? glyphDescription2.Merge(glyphDescription3) : glyphDescription3);
		}
		if (glyphDescription2 == null)
		{
			glyphDescription2 = emptyGlyph;
		}
		return new Glyph(isSimple: false, glyphDescription2.Instructions, glyphDescription2.EndPointsOfContours, glyphDescription2.Points, compositeLocation.Bounds);
		static bool HasFlag(CompositeGlyphFlags compositeGlyphFlags, CompositeGlyphFlags target)
		{
			return (compositeGlyphFlags & target) == target;
		}
	}

	private static SimpleGlyphFlags[] ReadFlags(TrueTypeDataBytes data, int pointCount)
	{
		SimpleGlyphFlags[] array = new SimpleGlyphFlags[pointCount];
		for (int i = 0; i < pointCount; i++)
		{
			array[i] = (SimpleGlyphFlags)data.ReadByte();
			if (!array[i].HasFlag(SimpleGlyphFlags.Repeat))
			{
				continue;
			}
			byte b = data.ReadByte();
			for (int j = 0; j < b; j++)
			{
				int num = i + j + 1;
				if (num >= array.Length)
				{
					break;
				}
				array[num] = array[i];
			}
			i += b;
		}
		return array;
	}

	private static short[] ReadCoordinates(TrueTypeDataBytes data, int pointCount, SimpleGlyphFlags[] flags, SimpleGlyphFlags isByte, SimpleGlyphFlags signOrSame)
	{
		short[] array = new short[pointCount];
		int num = 0;
		for (int i = 0; i < pointCount; i++)
		{
			SimpleGlyphFlags value = flags[i];
			int num2;
			if (HasFlag(value, isByte))
			{
				byte b = data.ReadByte();
				num2 = (HasFlag(value, signOrSame) ? b : (-b));
			}
			else
			{
				num2 = ((!HasFlag(value, signOrSame)) ? data.ReadSignedShort() : 0);
			}
			num += num2;
			array[i] = (short)num;
		}
		return array;
		static bool HasFlag(SimpleGlyphFlags simpleGlyphFlags, SimpleGlyphFlags target)
		{
			return (simpleGlyphFlags & target) == target;
		}
	}

	private static double ReadTwoFourteenFormat(TrueTypeDataBytes data)
	{
		return (double)data.ReadSignedShort() / 16384.0;
	}
}
