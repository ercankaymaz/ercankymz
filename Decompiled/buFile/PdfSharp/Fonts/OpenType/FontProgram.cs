using System;

namespace PdfSharp.Fonts.OpenType;

internal class FontProgram : OpenTypeFontTable
{
	public const string Tag = "fpgm";

	private byte[] bytes;

	public FontProgram(OpenTypeFontface fontData)
		: base(fontData, "fpgm")
	{
		DirectoryEntry.Tag = "fpgm";
		DirectoryEntry = fontData.TableDictionary["fpgm"];
		Read();
	}

	public void Read()
	{
		try
		{
			int length = DirectoryEntry.Length;
			bytes = new byte[length];
			for (int i = 0; i < length; i++)
			{
				bytes[i] = _fontData.ReadByte();
			}
		}
		catch (Exception innerException)
		{
			throw new InvalidOperationException(PSSR.ErrorReadingFontData, innerException);
		}
	}
}
