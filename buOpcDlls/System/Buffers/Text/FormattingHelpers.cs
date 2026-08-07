// Decompiled with JetBrains decompiler
// Type: System.Buffers.Text.FormattingHelpers
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#nullable disable
namespace System.Buffers.Text;

internal static class FormattingHelpers
{
  internal const string HexTableLower = "0123456789abcdef";
  internal const string HexTableUpper = "0123456789ABCDEF";

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static char GetSymbolOrDefault([System.Runtime.CompilerServices.System.Memory.IsReadOnly, In] ref StandardFormat format, char defaultSymbol)
  {
    char symbolOrDefault = format.Symbol;
    if (symbolOrDefault == char.MinValue && format.Precision == (byte) 0)
      symbolOrDefault = defaultSymbol;
    return symbolOrDefault;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void FillWithAsciiZeros(Span<byte> buffer)
  {
    for (int index = 0; index < buffer.Length; ++index)
      buffer[index] = (byte) 48 /*0x30*/;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void WriteHexByte(
    byte value,
    Span<byte> buffer,
    int startingIndex = 0,
    FormattingHelpers.HexCasing casing = FormattingHelpers.HexCasing.Uppercase)
  {
    uint num1 = (uint) ((((int) value & 240 /*0xF0*/) << 4) + ((int) value & 15) - 35209);
    uint num2 = (uint) ((FormattingHelpers.HexCasing) (((-(int) num1 & 28784) >>> 4) + (int) num1 + 47545) | casing);
    buffer[startingIndex + 1] = (byte) num2;
    buffer[startingIndex] = (byte) (num2 >> 8);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void WriteDigits(ulong value, Span<byte> buffer)
  {
    for (int index = buffer.Length - 1; index >= 1; --index)
    {
      ulong num = 48UL /*0x30*/ + value;
      value /= 10UL;
      buffer[index] = (byte) (num - value * 10UL);
    }
    buffer[0] = (byte) (48UL /*0x30*/ + value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void WriteDigitsWithGroupSeparator(ulong value, Span<byte> buffer)
  {
    int num1 = 0;
    for (int index = buffer.Length - 1; index >= 1; --index)
    {
      ulong num2 = 48UL /*0x30*/ + value;
      value /= 10UL;
      buffer[index] = (byte) (num2 - value * 10UL);
      if (num1 == 2)
      {
        buffer[--index] = (byte) 44;
        num1 = 0;
      }
      else
        ++num1;
    }
    buffer[0] = (byte) (48UL /*0x30*/ + value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void WriteDigits(uint value, Span<byte> buffer)
  {
    for (int index = buffer.Length - 1; index >= 1; --index)
    {
      uint num = 48U /*0x30*/ + value;
      value /= 10U;
      buffer[index] = (byte) (num - value * 10U);
    }
    buffer[0] = (byte) (48U /*0x30*/ + value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void WriteFourDecimalDigits(uint value, Span<byte> buffer, int startingIndex = 0)
  {
    uint num1 = 48U /*0x30*/ + value;
    value /= 10U;
    buffer[startingIndex + 3] = (byte) (num1 - value * 10U);
    uint num2 = 48U /*0x30*/ + value;
    value /= 10U;
    buffer[startingIndex + 2] = (byte) (num2 - value * 10U);
    uint num3 = 48U /*0x30*/ + value;
    value /= 10U;
    buffer[startingIndex + 1] = (byte) (num3 - value * 10U);
    buffer[startingIndex] = (byte) (48U /*0x30*/ + value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void WriteTwoDecimalDigits(uint value, Span<byte> buffer, int startingIndex = 0)
  {
    uint num = 48U /*0x30*/ + value;
    value /= 10U;
    buffer[startingIndex + 1] = (byte) (num - value * 10U);
    buffer[startingIndex] = (byte) (48U /*0x30*/ + value);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static ulong DivMod(ulong numerator, ulong denominator, out ulong modulo)
  {
    ulong num = numerator / denominator;
    modulo = numerator - num * denominator;
    return num;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static uint DivMod(uint numerator, uint denominator, out uint modulo)
  {
    uint num = numerator / denominator;
    modulo = numerator - num * denominator;
    return num;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static int CountDecimalTrailingZeros(uint value, out uint valueWithoutTrailingZeros)
  {
    int num1 = 0;
    if (value != 0U)
    {
      while (true)
      {
        uint modulo;
        uint num2 = FormattingHelpers.DivMod(value, 10U, out modulo);
        if (modulo == 0U)
        {
          value = num2;
          ++num1;
        }
        else
          break;
      }
    }
    valueWithoutTrailingZeros = value;
    return num1;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static int CountDigits(ulong value)
  {
    int num1 = 1;
    uint num2;
    if (value >= 10000000UL)
    {
      if (value >= 100000000000000UL)
      {
        num2 = (uint) (value / 100000000000000UL);
        num1 += 14;
      }
      else
      {
        num2 = (uint) (value / 10000000UL);
        num1 += 7;
      }
    }
    else
      num2 = (uint) value;
    if (num2 >= 10U)
    {
      if (num2 < 100U)
        ++num1;
      else if (num2 < 1000U)
        num1 += 2;
      else if (num2 < 10000U)
        num1 += 3;
      else if (num2 < 100000U)
        num1 += 4;
      else if (num2 < 1000000U)
        num1 += 5;
      else
        num1 += 6;
    }
    return num1;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static int CountDigits(uint value)
  {
    int num = 1;
    if (value >= 100000U)
    {
      value /= 100000U;
      num += 5;
    }
    if (value >= 10U)
    {
      if (value < 100U)
        ++num;
      else if (value < 1000U)
        num += 2;
      else if (value < 10000U)
        num += 3;
      else
        num += 4;
    }
    return num;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static int CountHexDigits(ulong value)
  {
    int num = 1;
    if (value > (ulong) uint.MaxValue)
    {
      num += 8;
      value >>= 32 /*0x20*/;
    }
    if (value > (ulong) ushort.MaxValue)
    {
      num += 4;
      value >>= 16 /*0x10*/;
    }
    if (value > (ulong) byte.MaxValue)
    {
      num += 2;
      value >>= 8;
    }
    if (value > 15UL)
      ++num;
    return num;
  }

  public enum HexCasing : uint
  {
    Uppercase = 0,
    Lowercase = 8224, // 0x00002020
  }
}
