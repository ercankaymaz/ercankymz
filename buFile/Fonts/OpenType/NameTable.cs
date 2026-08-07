// Decompiled with JetBrains decompiler
// Type: PdfSharp.Fonts.OpenType.NameTable
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.Diagnostics;
using System.Text;

#nullable disable
namespace PdfSharp.Fonts.OpenType;

internal class NameTable : OpenTypeFontTable
{
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
    this.Read();
  }

  public void Read()
  {
    try
    {
      this._fontData.Position = this.DirectoryEntry.Offset;
      this.bytes = new byte[this.DirectoryEntry.PaddedLength];
      Buffer.BlockCopy((Array) this._fontData.FontSource.Bytes, this.DirectoryEntry.Offset, (Array) this.bytes, 0, this.DirectoryEntry.Length);
      this.format = this._fontData.ReadUShort();
      this.count = this._fontData.ReadUShort();
      this.stringOffset = this._fontData.ReadUShort();
      for (int index = 0; index < (int) this.count; ++index)
      {
        NameTable.NameRecord nameRecord = this.ReadNameRecord();
        byte[] numArray = new byte[(int) nameRecord.length];
        Buffer.BlockCopy((Array) this._fontData.FontSource.Bytes, this.DirectoryEntry.Offset + (int) this.stringOffset + (int) nameRecord.offset, (Array) numArray, 0, (int) nameRecord.length);
        if ((nameRecord.platformID == (ushort) 0 ? 1 : (nameRecord.platformID == (ushort) 3 ? 1 : 0)) != 0)
        {
          if ((nameRecord.nameID != (ushort) 1 ? 0 : (nameRecord.languageID == (ushort) 1033 ? 1 : 0)) != 0 && string.IsNullOrEmpty(this.Name))
            this.Name = Encoding.BigEndianUnicode.GetString(numArray, 0, numArray.Length);
          if ((nameRecord.nameID != (ushort) 2 ? 0 : (nameRecord.languageID == (ushort) 1033 ? 1 : 0)) != 0 && string.IsNullOrEmpty(this.Style))
            this.Style = Encoding.BigEndianUnicode.GetString(numArray, 0, numArray.Length);
          if ((nameRecord.nameID != (ushort) 4 ? 0 : (nameRecord.languageID == (ushort) 1033 ? 1 : 0)) != 0 && string.IsNullOrEmpty(this.FullFontName))
            this.FullFontName = Encoding.BigEndianUnicode.GetString(numArray, 0, numArray.Length);
        }
      }
      Debug.Assert(!string.IsNullOrEmpty(this.Name));
    }
    catch (Exception ex)
    {
      throw new InvalidOperationException(PSSR.ErrorReadingFontData, ex);
    }
  }

  private NameTable.NameRecord ReadNameRecord()
  {
    return new NameTable.NameRecord()
    {
      platformID = this._fontData.ReadUShort(),
      encodingID = this._fontData.ReadUShort(),
      languageID = this._fontData.ReadUShort(),
      nameID = this._fontData.ReadUShort(),
      length = this._fontData.ReadUShort(),
      offset = this._fontData.ReadUShort()
    };
  }

  private class NameRecord
  {
    public ushort platformID;
    public ushort encodingID;
    public ushort languageID;
    public ushort nameID;
    public ushort length;
    public ushort offset;
  }
}
