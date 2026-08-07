// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.PdfRealObject
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.IO;
using System;
using System.Globalization;

#nullable disable
namespace PdfSharp.Pdf;

public sealed class PdfRealObject : PdfNumberObject
{
  private double _value;

  public PdfRealObject()
  {
  }

  public PdfRealObject(double value) => this._value = value;

  public PdfRealObject(PdfDocument document, double value)
    : base(document)
  {
    this._value = value;
  }

  public double Value
  {
    get => this._value;
    set => this._value = value;
  }

  public override string ToString()
  {
    return this._value.ToString((IFormatProvider) CultureInfo.InvariantCulture);
  }

  internal override void WriteObject(PdfWriter writer)
  {
    writer.WriteBeginObject((PdfObject) this);
    writer.Write(this._value);
    writer.WriteEndObject();
  }
}
