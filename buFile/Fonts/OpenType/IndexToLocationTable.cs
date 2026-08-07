// Decompiled with JetBrains decompiler
// Type: PdfSharp.Fonts.OpenType.IndexToLocationTable
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Fonts.OpenType;

internal class IndexToLocationTable : OpenTypeFontTable
{
  public const string Tag = "loca";
  internal int[] LocaTable;
  public bool ShortIndex;
  private byte[] _bytes;

  public IndexToLocationTable()
    : base((OpenTypeFontface) null, "loca")
  {
    this.DirectoryEntry.Tag = "loca";
  }

  public IndexToLocationTable(OpenTypeFontface fontData)
    : base(fontData, "loca")
  {
    this.DirectoryEntry = this._fontData.TableDictionary["loca"];
    this.Read();
  }

  public void Read()
  {
    try
    {
      this.ShortIndex = this._fontData.head.indexToLocFormat == (short) 0;
      this._fontData.Position = this.DirectoryEntry.Offset;
      if (this.ShortIndex)
      {
        int length = this.DirectoryEntry.Length / 2;
        Debug.Assert((int) this._fontData.maxp.numGlyphs + 1 == length, "For your information only: Number of glyphs mismatch in font. You can ignore this assertion.");
        this.LocaTable = new int[length];
        for (int index = 0; index < length; ++index)
          this.LocaTable[index] = 2 * (int) this._fontData.ReadUFWord();
      }
      else
      {
        int length = this.DirectoryEntry.Length / 4;
        Debug.Assert((int) this._fontData.maxp.numGlyphs + 1 == length, "For your information only: Number of glyphs mismatch in font. You can ignore this assertion.");
        this.LocaTable = new int[length];
        for (int index = 0; index < length; ++index)
          this.LocaTable[index] = this._fontData.ReadLong();
      }
    }
    catch (Exception ex)
    {
      this.GetType();
      throw;
    }
  }

  public override void PrepareForCompilation()
  {
    this.DirectoryEntry.Offset = 0;
    if (this.ShortIndex)
      this.DirectoryEntry.Length = this.LocaTable.Length * 2;
    else
      this.DirectoryEntry.Length = this.LocaTable.Length * 4;
    this._bytes = new byte[this.DirectoryEntry.PaddedLength];
    int length = this.LocaTable.Length;
    int num1 = 0;
    if (this.ShortIndex)
    {
      for (int index1 = 0; index1 < length; ++index1)
      {
        int num2 = this.LocaTable[index1] / 2;
        byte[] bytes1 = this._bytes;
        int index2 = num1;
        int num3 = index2 + 1;
        int num4 = (int) (byte) (num2 >> 8);
        bytes1[index2] = (byte) num4;
        byte[] bytes2 = this._bytes;
        int index3 = num3;
        num1 = index3 + 1;
        int num5 = (int) (byte) num2;
        bytes2[index3] = (byte) num5;
      }
    }
    else
    {
      for (int index4 = 0; index4 < length; ++index4)
      {
        int num6 = this.LocaTable[index4];
        byte[] bytes3 = this._bytes;
        int index5 = num1;
        int num7 = index5 + 1;
        int num8 = (int) (byte) (num6 >> 24);
        bytes3[index5] = (byte) num8;
        byte[] bytes4 = this._bytes;
        int index6 = num7;
        int num9 = index6 + 1;
        int num10 = (int) (byte) (num6 >> 16 /*0x10*/);
        bytes4[index6] = (byte) num10;
        byte[] bytes5 = this._bytes;
        int index7 = num9;
        int num11 = index7 + 1;
        int num12 = (int) (byte) (num6 >> 8);
        bytes5[index7] = (byte) num12;
        byte[] bytes6 = this._bytes;
        int index8 = num11;
        num1 = index8 + 1;
        int num13 = (int) (byte) num6;
        bytes6[index8] = (byte) num13;
      }
    }
    this.DirectoryEntry.CheckSum = OpenTypeFontTable.CalcChecksum(this._bytes);
  }

  public override void Write(OpenTypeFontWriter writer)
  {
    writer.Write(this._bytes, 0, this.DirectoryEntry.PaddedLength);
  }
}
