// Decompiled with JetBrains decompiler
// Type: System.Buffers.ReadOnlySequence
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices;

#nullable disable
namespace System.Buffers;

internal static class ReadOnlySequence
{
  public const int FlagBitMask = -2147483648 /*0x80000000*/;
  public const int IndexBitMask = 2147483647 /*0x7FFFFFFF*/;
  public const int SegmentStartMask = 0;
  public const int SegmentEndMask = 0;
  public const int ArrayStartMask = 0;
  public const int ArrayEndMask = -2147483648 /*0x80000000*/;
  public const int MemoryManagerStartMask = -2147483648 /*0x80000000*/;
  public const int MemoryManagerEndMask = 0;
  public const int StringStartMask = -2147483648 /*0x80000000*/;
  public const int StringEndMask = -2147483648 /*0x80000000*/;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static int SegmentToSequenceStart(int startIndex) => startIndex | 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static int SegmentToSequenceEnd(int endIndex) => endIndex | 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static int ArrayToSequenceStart(int startIndex) => startIndex | 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static int ArrayToSequenceEnd(int endIndex) => endIndex | int.MinValue;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static int MemoryManagerToSequenceStart(int startIndex) => startIndex | int.MinValue;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static int MemoryManagerToSequenceEnd(int endIndex) => endIndex | 0;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static int StringToSequenceStart(int startIndex) => startIndex | int.MinValue;

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static int StringToSequenceEnd(int endIndex) => endIndex | int.MinValue;
}
