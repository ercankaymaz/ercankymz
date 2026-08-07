// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.PdfStringObject
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.Internal;
using PdfSharp.Pdf.IO;
using System.Diagnostics;

#nullable disable
namespace PdfSharp.Pdf;

[DebuggerDisplay("({Value})")]
public sealed class PdfStringObject : PdfObject
{
  private PdfStringFlags _flags;
  private string _value;

  public PdfStringObject() => this._flags = PdfStringFlags.RawEncoding;

  public PdfStringObject(PdfDocument document, string value)
    : base(document)
  {
    this._value = value;
    this._flags = PdfStringFlags.RawEncoding;
  }

  public PdfStringObject(string value, PdfStringEncoding encoding)
  {
    this._value = value;
    this._flags = (PdfStringFlags) encoding;
  }

  internal PdfStringObject(string value, PdfStringFlags flags)
  {
    this._value = value;
    this._flags = flags;
  }

  public int Length => this._value == null ? 0 : this._value.Length;

  public PdfStringEncoding Encoding
  {
    get => (PdfStringEncoding) (this._flags & PdfStringFlags.EncodingMask);
    set
    {
      this._flags = this._flags & ~PdfStringFlags.EncodingMask | (PdfStringFlags) (value & (PdfStringEncoding) 15);
    }
  }

  public bool HexLiteral
  {
    get => (this._flags & PdfStringFlags.HexLiteral) != 0;
    set
    {
      this._flags = value ? this._flags | PdfStringFlags.HexLiteral : this._flags & ~PdfStringFlags.HexLiteral;
    }
  }

  public string Value
  {
    get => this._value ?? "";
    set => this._value = value ?? "";
  }

  internal byte[] EncryptionValue
  {
    get => this._value == null ? new byte[0] : PdfEncoders.RawEncoding.GetBytes(this._value);
    set => this._value = PdfEncoders.RawEncoding.GetString(value, 0, value.Length);
  }

  public override string ToString() => this._value;

  internal override void WriteObject(PdfWriter writer)
  {
    writer.WriteBeginObject((PdfObject) this);
    writer.Write(new PdfString(this._value, this._flags));
    writer.WriteEndObject();
  }
}
