// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.PdfDate
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.IO;
using System;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf;

[DebuggerDisplay("({Value})")]
public sealed class PdfDate : PdfItem
{
  private DateTime _value;

  public PdfDate()
  {
  }

  public PdfDate(string value) => this._value = Parser.ParseDateTime(value, DateTime.MinValue);

  public PdfDate(DateTime value) => this._value = value;

  public DateTime Value => this._value;

  public override string ToString()
  {
    return $"D:{this._value:yyyyMMddHHmmss}{this._value.ToString("zzz").Replace(':', '\'')}'";
  }

  internal override void WriteObject(PdfWriter writer) => writer.WriteDocString(this.ToString());
}
