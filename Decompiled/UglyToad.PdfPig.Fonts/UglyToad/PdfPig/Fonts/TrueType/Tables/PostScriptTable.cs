using System;
using System.Collections.Generic;
using System.Text;

namespace UglyToad.PdfPig.Fonts.TrueType.Tables;

public class PostScriptTable : ITrueTypeTable
{
	public string Tag => "post";

	public TrueTypeHeaderTable DirectoryTable { get; }

	public float Format { get; }

	public float ItalicAngle { get; }

	public short UnderlinePosition { get; }

	public short UnderlineThickness { get; }

	public uint IsFixedPitch { get; }

	public uint MinimumMemoryType42 { get; }

	public uint MaximumMemoryType42 { get; }

	public uint MinimumMemoryType1 { get; }

	public uint MaximumMemoryType1 { get; }

	public IReadOnlyList<string> GlyphNames { get; }

	public PostScriptTable(TrueTypeHeaderTable directoryTable, float format, float italicAngle, short underlinePosition, short underlineThickness, uint isFixedPitch, uint minimumMemoryType42, uint maximumMemoryType42, uint minimumMemoryType1, uint maximumMemoryType1, string[] glyphNames)
	{
		DirectoryTable = directoryTable;
		Format = format;
		ItalicAngle = italicAngle;
		UnderlinePosition = underlinePosition;
		UnderlineThickness = underlineThickness;
		IsFixedPitch = isFixedPitch;
		MinimumMemoryType42 = minimumMemoryType42;
		MaximumMemoryType42 = maximumMemoryType42;
		MinimumMemoryType1 = minimumMemoryType1;
		MaximumMemoryType1 = maximumMemoryType1;
		GlyphNames = glyphNames ?? throw new ArgumentNullException("glyphNames");
	}

	internal static PostScriptTable Load(TrueTypeDataBytes data, TrueTypeHeaderTable table, BasicMaximumProfileTable maximumProfileTable)
	{
		data.Seek(table.Offset);
		float num = data.Read32Fixed();
		float italicAngle = data.Read32Fixed();
		short underlinePosition = data.ReadSignedShort();
		short underlineThickness = data.ReadSignedShort();
		uint isFixedPitch = data.ReadUnsignedInt();
		uint minimumMemoryType = data.ReadUnsignedInt();
		uint maximumMemoryType = data.ReadUnsignedInt();
		uint minimumMemoryType2 = data.ReadUnsignedInt();
		uint maximumMemoryType2 = data.ReadUnsignedInt();
		string[] glyphNamesByFormat = GetGlyphNamesByFormat(data, maximumProfileTable, num);
		return new PostScriptTable(table, num, italicAngle, underlinePosition, underlineThickness, isFixedPitch, minimumMemoryType, maximumMemoryType, minimumMemoryType2, maximumMemoryType2, glyphNamesByFormat);
	}

	private static string[] GetGlyphNamesByFormat(TrueTypeDataBytes data, BasicMaximumProfileTable maximumProfileTable, float formatType)
	{
		string[] array;
		if (Math.Abs(formatType - 1f) < float.Epsilon)
		{
			array = new string[WindowsGlyphList4.NumberOfMacGlyphs];
			for (int i = 0; i < WindowsGlyphList4.MacGlyphNames.Count; i++)
			{
				array[i] = WindowsGlyphList4.MacGlyphNames[i];
			}
		}
		else if (Math.Abs(formatType - 2f) < float.Epsilon)
		{
			array = GetFormat2GlyphNames(data);
		}
		else if (!(Math.Abs((double)formatType - 2.5) < 1.401298464324817E-45))
		{
			array = ((!(Math.Abs(formatType - 3f) < float.Epsilon)) ? Array.Empty<string>() : Array.Empty<string>());
		}
		else
		{
			int[] array2 = new int[maximumProfileTable?.NumberOfGlyphs ?? 0];
			for (int j = 0; j < array2.Length; j++)
			{
				int num = data.ReadSignedByte();
				array2[j] = j + 1 + num;
			}
			array = new string[array2.Length];
			for (int k = 0; k < array.Length; k++)
			{
				string text = WindowsGlyphList4.MacGlyphNames[array2[k]];
				if (text != null)
				{
					array[k] = text;
				}
			}
		}
		return array;
	}

	private static string[] GetFormat2GlyphNames(TrueTypeDataBytes data)
	{
		ushort num = data.ReadUnsignedShort();
		int[] array = new int[num];
		string[] array2 = new string[num];
		int num2 = int.MinValue;
		for (int i = 0; i < num; i++)
		{
			ushort num3 = (ushort)(array[i] = data.ReadUnsignedShort());
			if (num3 < 32768)
			{
				num2 = Math.Max(num2, num3);
			}
		}
		string[] array3 = null;
		if (num2 >= WindowsGlyphList4.NumberOfMacGlyphs)
		{
			int num4 = num2 - WindowsGlyphList4.NumberOfMacGlyphs + 1;
			array3 = new string[num4];
			for (int j = 0; j < num4; j++)
			{
				byte bytesToRead = data.ReadByte();
				if (data.TryReadString(bytesToRead, Encoding.UTF8, out string result))
				{
					array3[j] = result;
				}
			}
		}
		for (int k = 0; k < num; k++)
		{
			int num5 = array[k];
			if (num5 < WindowsGlyphList4.NumberOfMacGlyphs)
			{
				array2[k] = WindowsGlyphList4.MacGlyphNames[num5];
			}
			else if (num5 >= WindowsGlyphList4.NumberOfMacGlyphs && num5 < 32768)
			{
				if (array3 == null)
				{
					throw new InvalidOperationException("The name array was null despite the number of glyphs exceeding the maximum Mac Glyphs.");
				}
				array2[k] = array3[num5 - WindowsGlyphList4.NumberOfMacGlyphs];
			}
			else
			{
				array2[k] = ".undefined";
			}
		}
		return array2;
	}
}
