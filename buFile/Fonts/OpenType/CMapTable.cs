// Decompiled with JetBrains decompiler
// Type: PdfSharp.Fonts.OpenType.CMapTable
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Fonts.OpenType;

internal class CMapTable : OpenTypeFontTable
{
  public const string Tag = "cmap";
  public ushort version;
  public ushort numTables;
  public bool symbol;
  public CMap4 cmap4;

  public CMapTable(OpenTypeFontface fontData)
    : base(fontData, "cmap")
  {
    this.Read();
  }

  internal void Read()
  {
    try
    {
      int position1 = this._fontData.Position;
      this.version = this._fontData.ReadUShort();
      this.numTables = this._fontData.ReadUShort();
      bool flag = false;
      for (int index = 0; index < (int) this.numTables; ++index)
      {
        PlatformId platformId = (PlatformId) this._fontData.ReadUShort();
        WinEncodingId encodingId = (WinEncodingId) this._fontData.ReadUShort();
        int num = this._fontData.ReadLong();
        int position2 = this._fontData.Position;
        if ((platformId != PlatformId.Win ? 0 : (encodingId == WinEncodingId.Symbol ? 1 : (encodingId == WinEncodingId.Unicode ? 1 : 0))) != 0)
        {
          this.symbol = encodingId == WinEncodingId.Symbol;
          this._fontData.Position = position1 + num;
          this.cmap4 = new CMap4(this._fontData, encodingId);
          this._fontData.Position = position2;
          flag = true;
          break;
        }
      }
      if (!flag)
        throw new InvalidOperationException("Font has no usable platform or encoding ID. It cannot be used with PDFsharp.");
    }
    catch (Exception ex)
    {
      throw new InvalidOperationException(PSSR.ErrorReadingFontData, ex);
    }
  }
}
