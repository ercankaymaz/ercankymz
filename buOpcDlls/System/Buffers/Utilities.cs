// Decompiled with JetBrains decompiler
// Type: System.Buffers.Utilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.CompilerServices;

#nullable disable
namespace System.Buffers;

internal static class Utilities
{
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal static int SelectBucketIndex(int bufferSize)
  {
    uint num1 = (uint) (bufferSize - 1 >>> 4);
    int num2 = 0;
    if (num1 > (uint) ushort.MaxValue)
    {
      num1 >>= 16 /*0x10*/;
      num2 = 16 /*0x10*/;
    }
    if (num1 > (uint) byte.MaxValue)
    {
      num1 >>= 8;
      num2 += 8;
    }
    if (num1 > 15U)
    {
      num1 >>= 4;
      num2 += 4;
    }
    if (num1 > 3U)
    {
      num1 >>= 2;
      num2 += 2;
    }
    if (num1 > 1U)
    {
      num1 >>= 1;
      ++num2;
    }
    return num2 + (int) num1;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal static int GetMaxSizeForBucket(int binIndex) => 16 /*0x10*/ << binIndex;
}
