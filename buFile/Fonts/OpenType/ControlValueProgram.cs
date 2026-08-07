// Decompiled with JetBrains decompiler
// Type: PdfSharp.Fonts.OpenType.ControlValueProgram
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Fonts.OpenType;

internal class ControlValueProgram : OpenTypeFontTable
{
  public const string Tag = "prep";
  private byte[] bytes;

  public ControlValueProgram(OpenTypeFontface fontData)
    : base(fontData, "prep")
  {
    this.DirectoryEntry.Tag = "prep";
    this.DirectoryEntry = fontData.TableDictionary["prep"];
    this.Read();
  }

  public void Read()
  {
    try
    {
      int length = this.DirectoryEntry.Length;
      this.bytes = new byte[length];
      for (int index = 0; index < length; ++index)
        this.bytes[index] = this._fontData.ReadByte();
    }
    catch (Exception ex)
    {
      throw new InvalidOperationException(PSSR.ErrorReadingFontData, ex);
    }
  }
}
