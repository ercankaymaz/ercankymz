// Decompiled with JetBrains decompiler
// Type: PdfSharp.Fonts.OpenType.IRefFontTable
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Fonts.OpenType;

internal class IRefFontTable : OpenTypeFontTable
{
  private readonly TableDirectoryEntry _irefDirectoryEntry;

  public IRefFontTable(OpenTypeFontface fontData, OpenTypeFontTable fontTable)
    : base((OpenTypeFontface) null, fontTable.DirectoryEntry.Tag)
  {
    this._fontData = fontData;
    this._irefDirectoryEntry = fontTable.DirectoryEntry;
  }

  public override void PrepareForCompilation()
  {
    base.PrepareForCompilation();
    this.DirectoryEntry.Length = this._irefDirectoryEntry.Length;
    this.DirectoryEntry.CheckSum = this._irefDirectoryEntry.CheckSum;
    if (!(this.DirectoryEntry.Tag != "head"))
      return;
    byte[] numArray = new byte[this.DirectoryEntry.PaddedLength];
    Buffer.BlockCopy((Array) this._irefDirectoryEntry.FontTable._fontData.FontSource.Bytes, this._irefDirectoryEntry.Offset, (Array) numArray, 0, this.DirectoryEntry.PaddedLength);
    int num = (int) OpenTypeFontTable.CalcChecksum(numArray);
  }

  public override void Write(OpenTypeFontWriter writer)
  {
    writer.Write(this._irefDirectoryEntry.FontTable._fontData.FontSource.Bytes, this._irefDirectoryEntry.Offset, this._irefDirectoryEntry.PaddedLength);
  }
}
