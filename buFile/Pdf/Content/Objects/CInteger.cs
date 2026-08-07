// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Content.Objects.CInteger
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;
using System.Diagnostics;
using System.Globalization;

#nullable disable
namespace PdfSharp.Pdf.Content.Objects;

[DebuggerDisplay("({Value})")]
public class CInteger : CNumber
{
  private int _value;

  public CInteger Clone() => (CInteger) this.Copy();

  protected override CObject Copy() => base.Copy();

  public int Value
  {
    get => this._value;
    set => this._value = value;
  }

  public override string ToString()
  {
    return this._value.ToString((IFormatProvider) CultureInfo.InvariantCulture);
  }

  internal override void WriteObject(ContentWriter writer)
  {
    writer.WriteRaw(this.ToString() + " ");
  }
}
