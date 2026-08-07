// Decompiled with JetBrains decompiler
// Type: PdfSharp.Fonts.OpenType.TableDirectoryEntry
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System.Diagnostics;

#nullable disable
namespace PdfSharp.Fonts.OpenType;

internal class TableDirectoryEntry
{
  public string Tag;
  public uint CheckSum;
  public int Offset;
  public int Length;
  public OpenTypeFontTable FontTable;

  public TableDirectoryEntry()
  {
  }

  public TableDirectoryEntry(string tag)
  {
    Debug.Assert(tag.Length == 4);
    this.Tag = tag;
  }

  public int PaddedLength => this.Length + 3 & -4;

  public static TableDirectoryEntry ReadFrom(OpenTypeFontface fontData)
  {
    return new TableDirectoryEntry()
    {
      Tag = fontData.ReadTag(),
      CheckSum = fontData.ReadULong(),
      Offset = fontData.ReadLong(),
      Length = (int) fontData.ReadULong()
    };
  }

  public void Read(OpenTypeFontface fontData)
  {
    this.Tag = fontData.ReadTag();
    this.CheckSum = fontData.ReadULong();
    this.Offset = fontData.ReadLong();
    this.Length = (int) fontData.ReadULong();
  }

  public void Write(OpenTypeFontWriter writer)
  {
    Debug.Assert(this.Tag.Length == 4);
    Debug.Assert(this.Offset != 0);
    Debug.Assert(this.Length != 0);
    writer.WriteTag(this.Tag);
    writer.WriteUInt(this.CheckSum);
    writer.WriteInt(this.Offset);
    writer.WriteUInt((uint) this.Length);
  }
}
