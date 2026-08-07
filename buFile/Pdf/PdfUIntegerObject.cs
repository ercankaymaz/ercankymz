// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.PdfUIntegerObject
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
public sealed class PdfUIntegerObject : PdfNumberObject
{
  private readonly uint _value;

  public PdfUIntegerObject()
  {
  }

  public PdfUIntegerObject(uint value) => this._value = value;

  public PdfUIntegerObject(PdfDocument document, uint value)
    : base(document)
  {
    this._value = value;
  }

  public uint Value => this._value;

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
