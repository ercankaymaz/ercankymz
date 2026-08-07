// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.PdfName
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf;

[DebuggerDisplay("({Value})")]
public sealed class PdfName : PdfItem
{
  private readonly string _value;
  public static readonly PdfName Empty = new PdfName("/");

  public PdfName() => this._value = "/";

  public PdfName(string value)
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

  public string Value => this._value;

  public override string ToString() => this._value;

  public static bool operator ==(PdfName name, string str)
  {
    return (object) name != null ? name._value == str : str == null;
  }

  public static bool operator !=(PdfName name, string str)
  {
    return (object) name != null ? name._value != str : str != null;
  }

  internal override void WriteObject(PdfWriter writer) => writer.Write(this);

  public static PdfName.PdfXNameComparer Comparer => new PdfName.PdfXNameComparer();

  public class PdfXNameComparer : IComparer<PdfName>
  {
    public int Compare(PdfName l, PdfName r)
    {
      return !(l != (string) null) ? (!(r != (string) null) ? 0 : 1) : (!(r != (string) null) ? -1 : string.Compare(l._value, r._value, StringComparison.Ordinal));
    }
  }
}
