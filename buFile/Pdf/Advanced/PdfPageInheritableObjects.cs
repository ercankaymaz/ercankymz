// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Advanced.PdfPageInheritableObjects
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Pdf.Advanced;

internal class PdfPageInheritableObjects : PdfDictionary
{
  private PdfRectangle _mediaBox;
  private PdfRectangle _cropBox;
  private int _rotate;

  public PdfRectangle MediaBox
  {
    get => this._mediaBox;
    set => this._mediaBox = value;
  }

  public PdfRectangle CropBox
  {
    get => this._cropBox;
    set => this._cropBox = value;
  }

  public int Rotate
  {
    get => this._rotate;
    set
    {
      this._rotate = value % 90 == 0 ? value : throw new ArgumentException("The value must be a multiple of 90.", nameof (value));
    }
  }
}
