// Decompiled with JetBrains decompiler
// Type: System.HexConverter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Diagnostics.DiagnosticSource;
using System.Runtime.CompilerServices;
using System.Security;

#nullable disable
namespace System;

internal static class HexConverter
{
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void ToBytesBuffer(
    byte value,
    Span<byte> buffer,
    int startingIndex = 0,
    HexConverter.Casing casing = HexConverter.Casing.Upper)
  {
    uint num1 = (uint) ((((int) value & 240 /*0xF0*/) << 4) + ((int) value & 15) - 35209);
    uint num2 = (uint) ((HexConverter.Casing) (((-(int) num1 & 28784) >>> 4) + (int) num1 + 47545) | casing);
    buffer[startingIndex + 1] = (byte) num2;
    buffer[startingIndex] = (byte) (num2 >> 8);
  }

  [SecuritySafeCritical]
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static void ToCharsBuffer(
    byte value,
    Span<char> buffer,
    int startingIndex = 0,
    HexConverter.Casing casing = HexConverter.Casing.Upper)
  {
    uint num1 = (uint) ((((int) value & 240 /*0xF0*/) << 4) + ((int) value & 15) - 35209);
    uint num2 = (uint) ((HexConverter.Casing) (((-(int) num1 & 28784) >>> 4) + (int) num1 + 47545) | casing);
    buffer[startingIndex + 1] = (char) (num2 & (uint) byte.MaxValue);
    buffer[startingIndex] = (char) (num2 >> 8);
  }

  public static void EncodeToUtf16(
    ReadOnlySpan<byte> bytes,
    Span<char> chars,
    HexConverter.Casing casing = HexConverter.Casing.Upper)
  {
    for (int index = 0; index < bytes.Length; ++index)
      HexConverter.ToCharsBuffer(bytes[index], chars, index * 2, casing);
  }

  [SecuritySafeCritical]
  public static string ToString(ReadOnlySpan<byte> bytes, HexConverter.Casing casing = HexConverter.Casing.Upper)
  {
    Span<char> span = new Span<char>();
    Span<char> buffer = bytes.Length <= 16 /*0x10*/ ? stackalloc char[bytes.Length * 2] : new char[bytes.Length * 2].AsSpan<char>();
    int startingIndex = 0;
    ReadOnlySpan<byte> readOnlySpan = bytes;
    for (int index = 0; index < readOnlySpan.Length; ++index)
    {
      HexConverter.ToCharsBuffer(readOnlySpan[index], buffer, startingIndex, casing);
      startingIndex += 2;
    }
    return buffer.ToString();
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static char ToCharUpper(int value)
  {
    value &= 15;
    value += 48 /*0x30*/;
    if (value > 57)
      value += 7;
    return (char) value;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static char ToCharLower(int value)
  {
    value &= 15;
    value += 48 /*0x30*/;
    if (value > 57)
      value += 39;
    return (char) value;
  }

  public static bool TryDecodeFromUtf16(ReadOnlySpan<char> chars, Span<byte> bytes)
  {
    return HexConverter.TryDecodeFromUtf16(chars, bytes, out int _);
  }

  public static bool TryDecodeFromUtf16(
    ReadOnlySpan<char> chars,
    Span<byte> bytes,
    out int charsProcessed)
  {
    int index = 0;
    int num1 = 0;
    int num2 = 0;
    int num3 = 0;
    while (num1 < bytes.Length)
    {
      num2 = HexConverter.FromChar((int) chars[index + 1]);
      num3 = HexConverter.FromChar((int) chars[index]);
      if ((num2 | num3) != (int) byte.MaxValue)
      {
        bytes[num1++] = (byte) (num3 << 4 | num2);
        index += 2;
      }
      else
        break;
    }
    if (num2 == (int) byte.MaxValue)
      ++index;
    charsProcessed = index;
    return (num2 | num3) != (int) byte.MaxValue;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static int FromChar(int c)
  {
    return c < HexConverter.CharToHexLookup.Length ? (int) HexConverter.CharToHexLookup[c] : (int) byte.MaxValue;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static int FromUpperChar(int c)
  {
    return c <= 71 ? (int) HexConverter.CharToHexLookup[c] : (int) byte.MaxValue;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static int FromLowerChar(int c)
  {
    switch (c)
    {
      case 48 /*0x30*/:
      case 49:
      case 50:
      case 51:
      case 52:
      case 53:
      case 54:
      case 55:
      case 56:
      case 57:
        return c - 48 /*0x30*/;
      case 97:
      case 98:
      case 99:
      case 100:
      case 101:
      case 102:
        return c - 97 + 10;
      default:
        return (int) byte.MaxValue;
    }
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool IsHexChar(int c)
  {
    if (IntPtr.Size != 8)
      return HexConverter.FromChar(c) != (int) byte.MaxValue;
    ulong num = (ulong) (uint) (c - 48 /*0x30*/);
    return (-17875860044349952L /*0xFFC07E0000007E00*/ << (int) num & (long) (num - 64UL /*0x40*/)) < 0L;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool IsHexUpperChar(int c)
  {
    switch (c)
    {
      case 48 /*0x30*/:
      case 49:
      case 50:
      case 51:
      case 52:
      case 53:
      case 54:
      case 55:
      case 56:
      case 57:
        return true;
      default:
        return (uint) (c - 65) <= 5U;
    }
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static bool IsHexLowerChar(int c)
  {
    switch (c)
    {
      case 48 /*0x30*/:
      case 49:
      case 50:
      case 51:
      case 52:
      case 53:
      case 54:
      case 55:
      case 56:
      case 57:
        return true;
      default:
        return (uint) (c - 97) <= 5U;
    }
  }

  public static unsafe ReadOnlySpan<byte> CharToHexLookup
  {
    get
    {
      return new ReadOnlySpan<byte>((void*) &\u003CPrivateImplementationDetails\u003E.\u00321244F82B210125632917591768F6BF22EB6861F80C6C25A25BD26DFB580EA7B, 256 /*0x0100*/);
    }
  }

  public enum Casing : uint
  {
    Upper = 0,
    Lower = 8224, // 0x00002020
  }
}
