using System;

namespace PdfSharp.Fonts.OpenType;

internal class ControlValueProgram : OpenTypeFontTable
{
	public const string Tag = "prep";

	private byte[] bytes;

	public ControlValueProgram(OpenTypeFontface fontData)
		: base(fontData, "prep")
	{
		DirectoryEntry.Tag = "prep";
		DirectoryEntry = fontData.TableDictionary["prep"];
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
