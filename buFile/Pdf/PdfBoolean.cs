// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.PdfBoolean
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.IO;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf;

[DebuggerDisplay("({Value})")]
public sealed class PdfBoolean : PdfItem
{
  private readonly bool _value;
  public static readonly PdfBoolean True = new PdfBoolean(true);
  public static readonly PdfBoolean False = new PdfBoolean(false);

  public PdfBoolean()
  {
  }

  public PdfBoolean(bool value) => this._value = value;

  public bool Value => this._value;

  public override string ToString() => this._value ? bool.TrueString : bool.FalseString;

  internal override void WriteObject(PdfWriter writer) => writer.Write(this);
}
