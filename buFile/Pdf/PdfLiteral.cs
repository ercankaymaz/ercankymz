// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.PdfLiteral
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Drawing;
using PdfSharp.Pdf.Internal;
using PdfSharp.Pdf.IO;

#nullable disable
namespace PdfSharp.Pdf;

public sealed class PdfLiteral : PdfItem
{
  private readonly string _value = string.Empty;

  public PdfLiteral()
  {
  }

  public PdfLiteral(string value) => this._value = value;

  public PdfLiteral(string format, params object[] args)
  {
    this._value = PdfEncoders.Format(format, args);
  }

  public static PdfLiteral FromMatrix(XMatrix matrix)
  {
    return new PdfLiteral($"[{PdfEncoders.ToString(matrix)}]");
  }

  public string Value => this._value;

  public override string ToString() => this._value;

  internal override void WriteObject(PdfWriter writer) => writer.Write(this);
}
