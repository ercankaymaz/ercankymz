using System;

namespace PdfSharp.Fonts.OpenType;

internal class ControlValueTable : OpenTypeFontTable
{
	public const string Tag = "cvt ";

	private short[] array;

	public ControlValueTable(OpenTypeFontface fontData)
		: base(fontData, "cvt ")
	{
		DirectoryEntry.Tag = "cvt ";
		DirectoryEntry = fontData.TableDictionary["cvt "];
		Read();
	}

	public void Read()
	{
		try
		{
			int num = DirectoryEntry.Length / 2;
			array = new short[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = _fontData.ReadFWord();
			}
		}
		catch (Exception innerException)
		{
			throw new InvalidOperationException(PSSR.ErrorReadingFontData, innerException);
		}
	}
}
