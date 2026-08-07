// Decompiled with JetBrains decompiler
// Type: System.Buffers.StandardFormat
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices.System.Memory;
using System.Runtime.InteropServices;

#nullable disable
namespace System.Buffers;

[IsReadOnly]
[ComVisible(true)]
public struct StandardFormat : IEquatable<StandardFormat>
{
  public const byte NoPrecision = 255 /*0xFF*/;
  public const byte MaxPrecision = 99;
  private readonly byte _format;
  private readonly byte _precision;

  public char Symbol => (char) this._format;

  public byte Precision => this._precision;

  public bool HasPrecision => this._precision != byte.MaxValue;

  public bool IsDefault => this._format == (byte) 0 && this._precision == (byte) 0;

  public StandardFormat(char symbol, byte precision = 255 /*0xFF*/)
  {
    if (precision != byte.MaxValue && precision > (byte) 99)
      ThrowHelper.ThrowArgumentOutOfRangeException_PrecisionTooLarge();
    if ((int) symbol != (int) (byte) symbol)
      ThrowHelper.ThrowArgumentOutOfRangeException_SymbolDoesNotFit();
    this._format = (byte) symbol;
    this._precision = precision;
  }

  public static implicit operator StandardFormat(char symbol) => new StandardFormat(symbol);

  public static StandardFormat Parse(ReadOnlySpan<char> format)
  {
    if (format.Length == 0)
      return new StandardFormat();
    char symbol = format[0];
    byte precision;
    if (format.Length == 1)
    {
      precision = byte.MaxValue;
    }
    else
    {
      uint num1 = 0;
      for (int index = 1; index < format.Length; ++index)
      {
        uint num2 = (uint) format[index] - 48U /*0x30*/;
        if (num2 > 9U)
          throw new FormatException(System.System.Memory3568249.SR.Format(System.System.Memory3568249.SR.Argument_CannotParsePrecision, (object) (byte) 99));
        num1 = num1 * 10U + num2;
        if (num1 > 99U)
          throw new FormatException(System.System.Memory3568249.SR.Format(System.System.Memory3568249.SR.Argument_PrecisionTooLarge, (object) (byte) 99));
      }
      precision = (byte) num1;
    }
    return new StandardFormat(symbol, precision);
  }

  public static StandardFormat Parse(string format)
  {
    return format != null ? StandardFormat.Parse(format.AsSpan()) : new StandardFormat();
  }

  public override bool Equals(object obj) => obj is StandardFormat other && this.Equals(other);

  public override int GetHashCode()
  {
    byte num = this._format;
    int hashCode1 = num.GetHashCode();
    num = this._precision;
    int hashCode2 = num.GetHashCode();
    return hashCode1 ^ hashCode2;
  }

  public bool Equals(StandardFormat other)
  {
    return (int) this._format == (int) other._format && (int) this._precision == (int) other._precision;
  }

  public override unsafe string ToString()
  {
    char* chPtr = stackalloc char[4];
    int length = 0;
    char symbol = this.Symbol;
    if (symbol != char.MinValue)
    {
      chPtr[length++] = symbol;
      byte precision = this.Precision;
      if (precision != byte.MaxValue)
      {
        if (precision >= (byte) 100)
        {
          chPtr[length++] = (char) (48 /*0x30*/ + (int) precision / 100 % 10);
          precision %= (byte) 100;
        }
        if (precision >= (byte) 10)
        {
          chPtr[length++] = (char) (48 /*0x30*/ + (int) precision / 10 % 10);
          precision %= (byte) 10;
        }
        chPtr[length++] = (char) (48U /*0x30*/ + (uint) precision);
      }
    }
    return new string(chPtr, 0, length);
  }

  public static bool operator ==(StandardFormat left, StandardFormat right) => left.Equals(right);

  public static bool operator !=(StandardFormat left, StandardFormat right) => !left.Equals(right);
}
