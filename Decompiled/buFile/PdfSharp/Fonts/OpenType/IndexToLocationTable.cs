#define DEBUG
using System;
using System.Diagnostics;

namespace PdfSharp.Fonts.OpenType;

internal class IndexToLocationTable : OpenTypeFontTable
{
	public const string Tag = "loca";

	internal int[] LocaTable;

	public bool ShortIndex;

	private byte[] _bytes;

	public IndexToLocationTable()
		: base(null, "loca")
	{
		DirectoryEntry.Tag = "loca";
	}

	public IndexToLocationTable(OpenTypeFontface fontData)
		: base(fontData, "loca")
	{
		DirectoryEntry = _fontData.TableDictionary["loca"];
		Read();
	}

	public void Read()
	{
		try
		{
			ShortIndex = _fontData.head.indexToLocFormat == 0;
			_fontData.Position = DirectoryEntry.Offset;
			if (ShortIndex)
			{
				int num = DirectoryEntry.Length / 2;
				Debug.Assert(_fontData.maxp.numGlyphs + 1 == num, "For your information only: Number of glyphs mismatch in font. You can ignore this assertion.");
				LocaTable = new int[num];
				for (int i = 0; i < num; i++)
				{
					LocaTable[i] = 2 * _fontData.ReadUFWord();
				}
			}
			else
			{
				int num2 = DirectoryEntry.Length / 4;
				Debug.Assert(_fontData.maxp.numGlyphs + 1 == num2, "For your information only: Number of glyphs mismatch in font. You can ignore this assertion.");
				LocaTable = new int[num2];
				for (int j = 0; j < num2; j++)
				{
					LocaTable[j] = _fontData.ReadLong();
				}
			}
		}
		catch (Exception)
		{
			GetType();
			throw;
		}
	}

	public override void PrepareForCompilation()
	{
		DirectoryEntry.Offset = 0;
		if (ShortIndex)
		{
			DirectoryEntry.Length = LocaTable.Length * 2;
		}
		else
		{
			DirectoryEntry.Length = LocaTable.Length * 4;
		}
		_bytes = new byte[DirectoryEntry.PaddedLength];
		int num = LocaTable.Length;
		int num2 = 0;
		if (ShortIndex)
		{
			for (int i = 0; i < num; i++)
			{
				int num3 = LocaTable[i] / 2;
				_bytes[num2++] = (byte)(num3 >> 8);
				_bytes[num2++] = (byte)num3;
			}
		}
		else
		{
			for (int j = 0; j < num; j++)
			{
				int num4 = LocaTable[j];
				_bytes[num2++] = (byte)(num4 >> 24);
				_bytes[num2++] = (byte)(num4 >> 16);
				_bytes[num2++] = (byte)(num4 >> 8);
				_bytes[num2++] = (byte)num4;
			}
		}
		DirectoryEntry.CheckSum = OpenTypeFontTable.CalcChecksum(_bytes);
	}

	public override void Write(OpenTypeFontWriter writer)
	{
		writer.Write(_bytes, 0, DirectoryEntry.PaddedLength);
	}
}
