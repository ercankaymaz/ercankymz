// Decompiled with JetBrains decompiler
// Type: System.Buffers.Text.Utf8Constants
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace System.Buffers.Text;

internal static class Utf8Constants
{
  public const byte Colon = 58;
  public const byte Comma = 44;
  public const byte Minus = 45;
  public const byte Period = 46;
  public const byte Plus = 43;
  public const byte Slash = 47;
  public const byte Space = 32 /*0x20*/;
  public const byte Hyphen = 45;
  public const byte Separator = 44;
  public const int GroupSize = 3;
  public static readonly TimeSpan s_nullUtcOffset = TimeSpan.MinValue;
  public const int DateTimeMaxUtcOffsetHours = 14;
  public const int DateTimeNumFractionDigits = 7;
  public const int MaxDateTimeFraction = 9999999;
  public const ulong BillionMaxUIntValue = 4294967295000000000;
  public const uint Billion = 1000000000;
}
