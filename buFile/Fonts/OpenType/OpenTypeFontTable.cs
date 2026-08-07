// Decompiled with JetBrains decompiler
// Type: PdfSharp.Fonts.OpenType.OpenTypeFontTable
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Fonts.OpenType;

internal class OpenTypeFontTable : ICloneable
{
  internal OpenTypeFontface _fontData;
  public TableDirectoryEntry DirectoryEntry;

  public OpenTypeFontTable(OpenTypeFontface fontData, string tag)
  {
    this._fontData = fontData;
    this.DirectoryEntry = (fontData == null ? 0 : (fontData.TableDictionary.ContainsKey(tag) ? 1 : 0)) == 0 ? new TableDirectoryEntry(tag) : fontData.TableDictionary[tag];
    this.DirectoryEntry.FontTable = this;
  }

  public object Clone() => (object) this.DeepCopy();

  protected virtual OpenTypeFontTable DeepCopy()
  {
    OpenTypeFontTable openTypeFontTable = (OpenTypeFontTable) this.MemberwiseClone();
    openTypeFontTable.DirectoryEntry.Offset = 0;
    openTypeFontTable.DirectoryEntry.FontTable = openTypeFontTable;
    return openTypeFontTable;
  }

  public OpenTypeFontface FontData => this._fontData;

  public virtual void PrepareForCompilation()
  {
  }

  public virtual void Write(OpenTypeFontWriter writer)
  {
  }

  public static uint CalcChecksum(byte[] bytes)
  {
    Debug.Assert((bytes.Length & 3) == 0);
    uint num1 = 0;
    uint num2 = 0;
    uint num3 = 0;
    uint num4 = 0;
    int length = bytes.Length;
    int num5 = 0;
    while (num5 < length)
    {
      int num6 = (int) num4;
      byte[] numArray1 = bytes;
      int index1 = num5;
      int num7 = index1 + 1;
      int num8 = (int) numArray1[index1];
      num4 = (uint) (num6 + num8);
      int num9 = (int) num3;
      byte[] numArray2 = bytes;
      int index2 = num7;
      int num10 = index2 + 1;
      int num11 = (int) numArray2[index2];
      num3 = (uint) (num9 + num11);
      int num12 = (int) num2;
      byte[] numArray3 = bytes;
      int index3 = num10;
      int num13 = index3 + 1;
      int num14 = (int) numArray3[index3];
      num2 = (uint) (num12 + num14);
      int num15 = (int) num1;
      byte[] numArray4 = bytes;
      int index4 = num13;
      num5 = index4 + 1;
      int num16 = (int) numArray4[index4];
      num1 = (uint) (num15 + num16);
    }
    return (uint) (((int) num4 << 24) + ((int) num3 << 16 /*0x10*/) + ((int) num2 << 8)) + num1;
  }
}
