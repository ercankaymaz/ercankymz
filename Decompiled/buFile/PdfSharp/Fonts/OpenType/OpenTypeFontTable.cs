#define DEBUG
using System;
using System.Diagnostics;

namespace PdfSharp.Fonts.OpenType;

internal class OpenTypeFontTable : ICloneable
{
	internal OpenTypeFontface _fontData;

	public TableDirectoryEntry DirectoryEntry;

	public OpenTypeFontface FontData => _fontData;

	public OpenTypeFontTable(OpenTypeFontface fontData, string tag)
	{
		_fontData = fontData;
		if (fontData != null && fontData.TableDictionary.ContainsKey(tag))
		{
			DirectoryEntry = fontData.TableDictionary[tag];
		}
		else
		{
			DirectoryEntry = new TableDirectoryEntry(tag);
		}
		DirectoryEntry.FontTable = this;
	}

	public object Clone()
	{
		return DeepCopy();
	}

	protected virtual OpenTypeFontTable DeepCopy()
	{
		OpenTypeFontTable openTypeFontTable = (OpenTypeFontTable)MemberwiseClone();
		openTypeFontTable.DirectoryEntry.Offset = 0;
		openTypeFontTable.DirectoryEntry.FontTable = openTypeFontTable;
		return openTypeFontTable;
	}

	public virtual void PrepareForCompilation()
	{
	}

	public virtual void Write(OpenTypeFontWriter writer)
	{
	}

	public static uint CalcChecksum(byte[] bytes)
	{
		Debug.Assert((bytes.Length & 3) == 0);
		uint num2;
		uint num3;
		uint num4;
		uint num = (num2 = (num3 = (num4 = 0u)));
		int num5 = bytes.Length;
		int num6 = 0;
		while (num6 < num5)
		{
			num += bytes[num6++];
			num2 += bytes[num6++];
			num3 += bytes[num6++];
			num4 += bytes[num6++];
		}
		return (num << 24) + (num2 << 16) + (num3 << 8) + num4;
	}
}
