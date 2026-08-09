#define DEBUG
using System;
using System.Diagnostics;

namespace PdfSharp.Fonts.OpenType;

internal class CMap4 : OpenTypeFontTable
{
	public WinEncodingId encodingId;

	public ushort format;

	public ushort length;

	public ushort language;

	public ushort segCountX2;

	public ushort searchRange;

	public ushort entrySelector;

	public ushort rangeShift;

	public ushort[] endCount;

	public ushort[] startCount;

	public short[] idDelta;

	public ushort[] idRangeOffs;

	public int glyphCount;

	public ushort[] glyphIdArray;

	public CMap4(OpenTypeFontface fontData, WinEncodingId encodingId)
		: base(fontData, "----")
	{
		this.encodingId = encodingId;
		Read();
	}

	internal void Read()
	{
		try
		{
			format = _fontData.ReadUShort();
			Debug.Assert(format == 4, "Only format 4 expected.");
			length = _fontData.ReadUShort();
			language = _fontData.ReadUShort();
			segCountX2 = _fontData.ReadUShort();
			searchRange = _fontData.ReadUShort();
			entrySelector = _fontData.ReadUShort();
			rangeShift = _fontData.ReadUShort();
			int num = segCountX2 / 2;
			glyphCount = (length - (16 + 8 * num)) / 2;
			endCount = new ushort[num];
			startCount = new ushort[num];
			idDelta = new short[num];
			idRangeOffs = new ushort[num];
			glyphIdArray = new ushort[glyphCount];
			for (int i = 0; i < num; i++)
			{
				endCount[i] = _fontData.ReadUShort();
			}
			_fontData.ReadUShort();
			for (int j = 0; j < num; j++)
			{
				startCount[j] = _fontData.ReadUShort();
			}
			for (int k = 0; k < num; k++)
			{
				idDelta[k] = _fontData.ReadShort();
			}
			for (int l = 0; l < num; l++)
			{
				idRangeOffs[l] = _fontData.ReadUShort();
			}
			for (int m = 0; m < glyphCount; m++)
			{
				glyphIdArray[m] = _fontData.ReadUShort();
			}
		}
		catch (Exception innerException)
		{
			throw new InvalidOperationException(PSSR.ErrorReadingFontData, innerException);
		}
	}
}
