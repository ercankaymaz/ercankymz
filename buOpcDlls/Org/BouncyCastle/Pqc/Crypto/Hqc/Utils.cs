// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Hqc.Utils
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Hqc;

internal class Utils
{
  internal static void ResizeArray(
    long[] output,
    int sizeOutBits,
    long[] input,
    int sizeInBits,
    int n1n2ByteSize,
    int n1n2Byte64Size)
  {
    long maxValue = long.MaxValue;
    int num = 0;
    if (sizeOutBits < sizeInBits)
    {
      if (sizeOutBits % 64 /*0x40*/ != 0)
        num = 64 /*0x40*/ - sizeOutBits % 64 /*0x40*/;
      Array.Copy((Array) input, 0, (Array) output, 0, n1n2ByteSize);
      for (int index = 0; index < num; ++index)
        output[n1n2Byte64Size - 1] &= maxValue >> index;
    }
    else
      Array.Copy((Array) input, 0, (Array) output, 0, (sizeInBits + 7) / 8);
  }

  internal static void FromLongArrayToByteArray(byte[] output, long[] input)
  {
    int index1 = output.Length / 8;
    for (int index2 = 0; index2 != index1; ++index2)
      Pack.UInt64_To_LE((ulong) input[index2], output, index2 * 8);
    if (output.Length % 8 == 0)
      return;
    int num1 = index1 * 8;
    int num2 = 0;
    while (num1 < output.Length)
      output[num1++] = (byte) (input[index1] >> num2++ * 8);
  }

  internal static long BitMask(ulong a, ulong b) => (1L << (int) (uint) (a % b)) - 1L;

  internal static void FromByteArrayToLongArray(long[] output, byte[] input)
  {
    byte[] numArray = input;
    if (input.Length % 8 != 0)
    {
      numArray = new byte[(input.Length + 7) / 8 * 8];
      Array.Copy((Array) input, 0, (Array) numArray, 0, input.Length);
    }
    int off = 0;
    for (int index = 0; index < output.Length; ++index)
    {
      output[index] = (long) Pack.LE_To_UInt64(numArray, off);
      off += 8;
    }
  }

  internal static void FromByteArrayToByte16Array(int[] output, byte[] input)
  {
    byte[] numArray = input;
    if (input.Length % 2 != 0)
    {
      numArray = new byte[(input.Length + 1) / 2 * 2];
      Array.Copy((Array) input, 0, (Array) numArray, 0, input.Length);
    }
    int off = 0;
    for (int index = 0; index < output.Length; ++index)
    {
      output[index] = (int) Pack.LE_To_UInt16(numArray, off);
      off += 2;
    }
  }

  internal static void FromByte32ArrayToLongArray(long[] output, int[] input)
  {
    for (int index = 0; index != input.Length; index += 2)
    {
      output[index / 2] = (long) (uint) input[index];
      output[index / 2] |= (long) input[index + 1] << 32 /*0x20*/;
    }
  }

  internal static void FromByte16ArrayToULongArray(ulong[] output, ushort[] input)
  {
    for (int index = 0; index != input.Length; index += 4)
    {
      output[index / 4] = (ulong) input[index];
      output[index / 4] |= (ulong) input[index + 1] << 16 /*0x10*/;
      output[index / 4] |= (ulong) input[index + 2] << 32 /*0x20*/;
      output[index / 4] |= (ulong) input[index + 3] << 48 /*0x30*/;
    }
  }

  internal static void FromLongArrayToByte32Array(int[] output, long[] input)
  {
    for (int index = 0; index != input.Length; ++index)
    {
      output[2 * index] = (int) input[index];
      output[2 * index + 1] = (int) (input[index] >> 32 /*0x20*/);
    }
  }

  internal static void CopyBytes(
    int[] src,
    int offsetSrc,
    int[] dst,
    int offsetDst,
    int lengthBytes)
  {
    Array.Copy((Array) src, offsetSrc, (Array) dst, offsetDst, lengthBytes / 2);
  }

  internal static int GetByteSizeFromBitSize(int size) => (size + 7) / 8;

  internal static int GetByte64SizeFromBitSize(int size) => (size + 63 /*0x3F*/) / 64 /*0x40*/;

  internal static int ToUnsigned8bits(int a) => a & (int) byte.MaxValue;

  internal static int ToUnsigned16Bits(int a) => a & (int) ushort.MaxValue;

  internal static void XorULongToByte16Array(ushort[] output, int outOff, ulong input)
  {
    output[outOff] ^= (ushort) input;
    output[outOff + 1] ^= (ushort) (input >> 16 /*0x10*/);
    output[outOff + 2] ^= (ushort) (input >> 32 /*0x20*/);
    output[outOff + 3] ^= (ushort) (input >> 48 /*0x30*/);
  }
}
