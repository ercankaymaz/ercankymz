// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.PdfNameObject
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.IO;
using System;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf;

[DebuggerDisplay("({Value})")]
public sealed class PdfNameObject : PdfObject
{
  private string _value;

  public PdfNameObject() => this._value = "/";

  public PdfNameObject(PdfDocument document, string value)
    : base(document)
  {
    int num;
    switch (value)
    {
      case null:
        throw new ArgumentNullException(nameof (value));
      case "":
        num = 1;
        break;
      default:
        num = value[0] != '/' ? 1 : 0;
        break;
    }
    if (num != 0)
      throw new ArgumentException(PSSR.NameMustStartWithSlash);
    this._value = value;
  }

  public override bool Equals(object obj) => this._value.Equals(obj);

  public override int GetHashCode() => this._value.GetHashCode();

  public string Value
  {
    get => this._value;
    set => this._value = value;
  }

  public override string ToString() => this._value;

  public static bool operator ==(PdfNameObject name, string str) => name._value == str;

  public static bool operator !=(PdfNameObject name, string str) => name._value != str;

  internal override void WriteObject(PdfWriter writer)
  {
    writer.WriteBeginObject((PdfObject) this);
    writer.Write(new PdfName(this._value));
    writer.WriteEndObject();
  }
}
