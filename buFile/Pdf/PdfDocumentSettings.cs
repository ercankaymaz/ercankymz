// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.PdfDocumentSettings
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;

#nullable disable
namespace PdfSharp.Pdf;

public sealed class PdfDocumentSettings
{
  private TrimMargins _trimMargins = new TrimMargins();

  internal PdfDocumentSettings(PdfDocument document)
  {
  }

  public TrimMargins TrimMargins
  {
    get
    {
      if (this._trimMargins == null)
        this._trimMargins = new TrimMargins();
      return this._trimMargins;
    }
    set
    {
      if (this._trimMargins == null)
        this._trimMargins = new TrimMargins();
      if (value != null)
      {
        this._trimMargins.Left = value.Left;
        this._trimMargins.Right = value.Right;
        this._trimMargins.Top = value.Top;
        this._trimMargins.Bottom = value.Bottom;
      }
      else
        this._trimMargins.All = (XUnit) 0;
    }
  }
}
