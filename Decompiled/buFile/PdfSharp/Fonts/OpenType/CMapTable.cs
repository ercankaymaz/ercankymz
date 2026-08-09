using System;

namespace PdfSharp.Fonts.OpenType;

internal class CMapTable : OpenTypeFontTable
{
	public const string Tag = "cmap";

	public ushort version;

	public ushort numTables;

	public bool symbol;

	public CMap4 cmap4;

	public CMapTable(OpenTypeFontface fontData)
		: base(fontData, "cmap")
	{
		Read();
	}

	internal void Read()
	{
		try
		{
			int position = _fontData.Position;
			version = _fontData.ReadUShort();
			numTables = _fontData.ReadUShort();
			bool flag = false;
			for (int i = 0; i < numTables; i++)
			{
				PlatformId platformId = (PlatformId)_fontData.ReadUShort();
				WinEncodingId winEncodingId = (WinEncodingId)_fontData.ReadUShort();
				int num = _fontData.ReadLong();
				int position2 = _fontData.Position;
				if (platformId == PlatformId.Win && (winEncodingId == WinEncodingId.Symbol || winEncodingId == WinEncodingId.Unicode))
				{
					symbol = winEncodingId == WinEncodingId.Symbol;
					_fontData.Position = position + num;
					cmap4 = new CMap4(_fontData, winEncodingId);
					_fontData.Position = position2;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				throw new InvalidOperationException("Font has no usable platform or encoding ID. It cannot be used with PDFsharp.");
			}
		}
		catch (Exception innerException)
		{
			throw new InvalidOperationException(PSSR.ErrorReadingFontData, innerException);
		}
	}
}
