#define DEBUG
using System.Diagnostics;

namespace PdfSharp.Fonts.OpenType;

internal class TableDirectoryEntry
{
	public string Tag;

	public uint CheckSum;

	public int Offset;

	public int Length;

	public OpenTypeFontTable FontTable;

	public int PaddedLength => (Length + 3) & -4;

	public TableDirectoryEntry()
	{
	}

	public TableDirectoryEntry(string tag)
	{
		Debug.Assert(tag.Length == 4);
		Tag = tag;
	}

	public static TableDirectoryEntry ReadFrom(OpenTypeFontface fontData)
	{
		TableDirectoryEntry tableDirectoryEntry = new TableDirectoryEntry();
		tableDirectoryEntry.Tag = fontData.ReadTag();
		tableDirectoryEntry.CheckSum = fontData.ReadULong();
		tableDirectoryEntry.Offset = fontData.ReadLong();
		tableDirectoryEntry.Length = (int)fontData.ReadULong();
		return tableDirectoryEntry;
	}

	public void Read(OpenTypeFontface fontData)
	{
		Tag = fontData.ReadTag();
		CheckSum = fontData.ReadULong();
		Offset = fontData.ReadLong();
		Length = (int)fontData.ReadULong();
	}

	public void Write(OpenTypeFontWriter writer)
	{
		Debug.Assert(Tag.Length == 4);
		Debug.Assert(Offset != 0);
		Debug.Assert(Length != 0);
		writer.WriteTag(Tag);
		writer.WriteUInt(CheckSum);
		writer.WriteInt(Offset);
		writer.WriteUInt((uint)Length);
	}
}
