#define DEBUG
using System;
using System.Diagnostics;
using System.Text;

namespace PdfSharp.Fonts.OpenType;

internal class NameTable : OpenTypeFontTable
{
	private class NameRecord
	{
		public ushort platformID;

		public ushort encodingID;

		public ushort languageID;

		public ushort nameID;

		public ushort length;

		public ushort offset;
	}

	public const string Tag = "name";

	public string Name = string.Empty;

	public string Style = string.Empty;

	public string FullFontName = string.Empty;

	public ushort format;

	public ushort count;

	public ushort stringOffset;

	private byte[] bytes;

	public NameTable(OpenTypeFontface fontData)
		: base(fontData, "name")
	{
		Read();
	}

	public void Read()
	{
		try
		{
			_fontData.Position = DirectoryEntry.Offset;
			bytes = new byte[DirectoryEntry.PaddedLength];
			Buffer.BlockCopy(_fontData.FontSource.Bytes, DirectoryEntry.Offset, bytes, 0, DirectoryEntry.Length);
			format = _fontData.ReadUShort();
			count = _fontData.ReadUShort();
			stringOffset = _fontData.ReadUShort();
			for (int i = 0; i < count; i++)
			{
				NameRecord nameRecord = ReadNameRecord();
				byte[] array = new byte[nameRecord.length];
				Buffer.BlockCopy(_fontData.FontSource.Bytes, DirectoryEntry.Offset + stringOffset + nameRecord.offset, array, 0, nameRecord.length);
				if (nameRecord.platformID == 0 || nameRecord.platformID == 3)
				{
					if (nameRecord.nameID == 1 && nameRecord.languageID == 1033 && string.IsNullOrEmpty(Name))
					{
						Name = Encoding.BigEndianUnicode.GetString(array, 0, array.Length);
					}
					if (nameRecord.nameID == 2 && nameRecord.languageID == 1033 && string.IsNullOrEmpty(Style))
					{
						Style = Encoding.BigEndianUnicode.GetString(array, 0, array.Length);
					}
					if (nameRecord.nameID == 4 && nameRecord.languageID == 1033 && string.IsNullOrEmpty(FullFontName))
					{
						FullFontName = Encoding.BigEndianUnicode.GetString(array, 0, array.Length);
					}
				}
			}
			Debug.Assert(!string.IsNullOrEmpty(Name));
		}
		catch (Exception innerException)
		{
			throw new InvalidOperationException(PSSR.ErrorReadingFontData, innerException);
		}
	}

	private NameRecord ReadNameRecord()
	{
		NameRecord nameRecord = new NameRecord();
		nameRecord.platformID = _fontData.ReadUShort();
		nameRecord.encodingID = _fontData.ReadUShort();
		nameRecord.languageID = _fontData.ReadUShort();
		nameRecord.nameID = _fontData.ReadUShort();
		nameRecord.length = _fontData.ReadUShort();
		nameRecord.offset = _fontData.ReadUShort();
		return nameRecord;
	}
}
