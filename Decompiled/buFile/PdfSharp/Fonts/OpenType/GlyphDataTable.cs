using System;
using System.Collections.Generic;

namespace PdfSharp.Fonts.OpenType;

internal class GlyphDataTable : OpenTypeFontTable
{
	public const string Tag = "glyf";

	internal byte[] GlyphTable;

	private const int ARG_1_AND_2_ARE_WORDS = 1;

	private const int WE_HAVE_A_SCALE = 8;

	private const int MORE_COMPONENTS = 32;

	private const int WE_HAVE_AN_X_AND_Y_SCALE = 64;

	private const int WE_HAVE_A_TWO_BY_TWO = 128;

	public GlyphDataTable()
		: base(null, "glyf")
	{
		DirectoryEntry.Tag = "glyf";
	}

	public GlyphDataTable(OpenTypeFontface fontData)
		: base(fontData, "glyf")
	{
		DirectoryEntry.Tag = "glyf";
		Read();
	}

	public void Read()
	{
		try
		{
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}

	public byte[] GetGlyphData(int glyph)
	{
		IndexToLocationTable loca = _fontData.loca;
		int offset = GetOffset(glyph);
		int offset2 = GetOffset(glyph + 1);
		int num = offset2 - offset;
		byte[] array = new byte[num];
		Buffer.BlockCopy(_fontData.FontSource.Bytes, offset, array, 0, num);
		return array;
	}

	public int GetGlyphSize(int glyph)
	{
		IndexToLocationTable loca = _fontData.loca;
		return GetOffset(glyph + 1) - GetOffset(glyph);
	}

	public int GetOffset(int glyph)
	{
		return DirectoryEntry.Offset + _fontData.loca.LocaTable[glyph];
	}

	public void CompleteGlyphClosure(Dictionary<int, object> glyphs)
	{
		int count = glyphs.Count;
		int[] array = new int[glyphs.Count];
		glyphs.Keys.CopyTo(array, 0);
		if (!glyphs.ContainsKey(0))
		{
			glyphs.Add(0, null);
		}
		for (int i = 0; i < count; i++)
		{
			AddCompositeGlyphs(glyphs, array[i]);
		}
	}

	private void AddCompositeGlyphs(Dictionary<int, object> glyphs, int glyph)
	{
		int offset = GetOffset(glyph);
		if (offset == GetOffset(glyph + 1))
		{
			return;
		}
		_fontData.Position = offset;
		int num = _fontData.ReadShort();
		if (num >= 0)
		{
			return;
		}
		_fontData.SeekOffset(8);
		while (true)
		{
			int num2 = _fontData.ReadUFWord();
			int key = _fontData.ReadUFWord();
			if (!glyphs.ContainsKey(key))
			{
				glyphs.Add(key, null);
			}
			if ((num2 & 0x20) == 0)
			{
				break;
			}
			int num3 = (((num2 & 1) == 0) ? 2 : 4);
			if ((num2 & 8) != 0)
			{
				num3 += 2;
			}
			else if ((num2 & 0x40) != 0)
			{
				num3 += 4;
			}
			if ((num2 & 0x80) != 0)
			{
				num3 += 8;
			}
			_fontData.SeekOffset(num3);
		}
	}

	public override void PrepareForCompilation()
	{
		base.PrepareForCompilation();
		if (DirectoryEntry.Length == 0)
		{
			DirectoryEntry.Length = GlyphTable.Length;
		}
		DirectoryEntry.CheckSum = OpenTypeFontTable.CalcChecksum(GlyphTable);
	}

	public override void Write(OpenTypeFontWriter writer)
	{
		writer.Write(GlyphTable, 0, DirectoryEntry.PaddedLength);
	}
}
