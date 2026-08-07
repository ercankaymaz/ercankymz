// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.PdfInteger
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
public sealed class PdfInteger : PdfNumber, IConvertible
{
  private readonly int _value;

  public PdfInteger()
  {
  }

  public PdfInteger(int value) => this._value = value;

  public int Value => this._value;

  public override string ToString()
  {
    return this._value.ToString((IFormatProvider) CultureInfo.InvariantCulture);
  }

  internal override void WriteObject(PdfWriter writer) => writer.Write(this);

  ulong IConvertible.ToUInt64(IFormatProvider provider) => Convert.ToUInt64(this._value);

  sbyte IConvertible.ToSByte(IFormatProvider provider) => throw new InvalidCastException();

  double IConvertible.ToDouble(IFormatProvider provider) => (double) this._value;

  DateTime IConvertible.ToDateTime(IFormatProvider provider) => new DateTime();

  float IConvertible.ToSingle(IFormatProvider provider) => (float) this._value;

  bool IConvertible.ToBoolean(IFormatProvider provider) => Convert.ToBoolean(this._value);

  int IConvertible.ToInt32(IFormatProvider provider) => this._value;

  ushort IConvertible.ToUInt16(IFormatProvider provider) => Convert.ToUInt16(this._value);

  short IConvertible.ToInt16(IFormatProvider provider) => Convert.ToInt16(this._value);

  string IConvertible.ToString(IFormatProvider provider) => this._value.ToString(provider);

  byte IConvertible.ToByte(IFormatProvider provider) => Convert.ToByte(this._value);

  char IConvertible.ToChar(IFormatProvider provider) => Convert.ToChar(this._value);

  long IConvertible.ToInt64(IFormatProvider provider) => (long) this._value;

  public TypeCode GetTypeCode() => TypeCode.Int32;

  Decimal IConvertible.ToDecimal(IFormatProvider provider) => (Decimal) this._value;

  object IConvertible.ToType(Type conversionType, IFormatProvider provider) => (object) null;

  uint IConvertible.ToUInt32(IFormatProvider provider) => Convert.ToUInt32(this._value);
}
