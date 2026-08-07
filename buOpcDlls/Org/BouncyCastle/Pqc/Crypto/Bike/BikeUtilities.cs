// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Bike.BikeUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Utilities;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Bike;

internal class BikeUtilities
{
  internal static int GetHammingWeight(byte[] bytes)
  {
    int hammingWeight = 0;
    for (int index = 0; index < bytes.Length; ++index)
      hammingWeight += (int) bytes[index];
    return hammingWeight;
  }

  internal static void FromBitsToUlongs(ulong[] output, byte[] input, int inputOff, int inputLen)
  {
    for (int index = 0; index < inputLen; ++index)
    {
      ulong num = (ulong) input[inputOff + index] & 1UL;
      output[index >> 6] |= num << index;
    }
  }

  internal static void GenerateRandomUlongs(ulong[] res, int size, int weight, IXof digest)
  {
    byte[] numArray = new byte[4];
    for (int index = weight - 1; index >= 0; --index)
    {
      digest.Output(numArray, 0, 4);
      ulong num = (ulong) Pack.LE_To_UInt32(numArray, 0) * (ulong) (uint) (size - index);
      uint position = (uint) index + (uint) (num >> 32 /*0x20*/);
      if (BikeUtilities.CheckBit(res, position))
        position = (uint) index;
      BikeUtilities.SetBit(res, position);
    }
  }

  private static bool CheckBit(ulong[] tmp, uint position)
  {
    uint index = position >> 6;
    uint num = position & 63U /*0x3F*/;
    return (tmp[(int) index] >> (int) num & 1UL) > 0UL;
  }

  private static void SetBit(ulong[] tmp, uint position)
  {
    uint index = position >> 6;
    uint num = position & 63U /*0x3F*/;
    tmp[(int) index] |= (ulong) (1L << (int) num);
  }
}
