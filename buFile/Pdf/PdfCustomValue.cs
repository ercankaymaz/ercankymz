// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.PdfCustomValue
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.Pdf;

public class PdfCustomValue : PdfDictionary
{
  public PdfCustomValueCompressionMode CompressionMode;

  public PdfCustomValue() => this.CreateStream(new byte[0]);

  public PdfCustomValue(byte[] bytes) => this.CreateStream(bytes);

  internal PdfCustomValue(PdfDocument document)
    : base(document)
  {
    this.CreateStream(new byte[0]);
  }

  internal PdfCustomValue(PdfDictionary dict)
    : base(dict)
  {
  }

  public byte[] Value
  {
    get => this.Stream.Value;
    set => this.Stream.Value = value;
  }
}
