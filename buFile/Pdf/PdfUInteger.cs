// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.PdfUInteger
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
public sealed class PdfUInteger : PdfNumber, IConvertible
{
  private readonly uint _value;

  public PdfUInteger()
  {
  }

  public PdfUInteger(uint value) => this._value = value;

  public uint Value => this._value;

  public override string ToString()
  {
    return this._value.ToString((IFormatProvider) CultureInfo.InvariantCulture);
  }

  internal override void WriteObject(PdfWriter writer) => writer.Write(this);

  public ulong ToUInt64(IFormatProvider provider) => Convert.ToUInt64(this._value);

  public sbyte ToSByte(IFormatProvider provider) => throw new InvalidCastException();

  public double ToDouble(IFormatProvider provider) => (double) this._value;

  public DateTime ToDateTime(IFormatProvider provider) => new DateTime();

  public float ToSingle(IFormatProvider provider) => (float) this._value;

  public bool ToBoolean(IFormatProvider provider) => Convert.ToBoolean(this._value);

  public int ToInt32(IFormatProvider provider) => Convert.ToInt32(this._value);

  public ushort ToUInt16(IFormatProvider provider) => Convert.ToUInt16(this._value);

  public short ToInt16(IFormatProvider provider) => Convert.ToInt16(this._value);

  string IConvertible.ToString(IFormatProvider provider) => this._value.ToString(provider);

  public byte ToByte(IFormatProvider provider) => Convert.ToByte(this._value);

  public char ToChar(IFormatProvider provider) => Convert.ToChar(this._value);

  public long ToInt64(IFormatProvider provider) => (long) this._value;

  public TypeCode GetTypeCode() => TypeCode.Int32;

  public Decimal ToDecimal(IFormatProvider provider) => (Decimal) this._value;

  public object ToType(Type conversionType, IFormatProvider provider) => (object) null;

  public uint ToUInt32(IFormatProvider provider) => Convert.ToUInt32(this._value);
}
