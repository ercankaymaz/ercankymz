// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.PdfReal
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.IO;
using System;
using System.Diagnostics;
using System.Globalization;

#nullable disable
namespace PdfSharp.Pdf;

[DebuggerDisplay("({Value})")]
public sealed class PdfReal : PdfNumber
{
  private readonly double _value;

  public PdfReal()
  {
  }

  public PdfReal(double value) => this._value = value;

  public double Value => this._value;

  public override string ToString()
  {
    return this._value.ToString("0.###", (IFormatProvider) CultureInfo.InvariantCulture);
  }

  internal override void WriteObject(PdfWriter writer) => writer.Write(this);
}
