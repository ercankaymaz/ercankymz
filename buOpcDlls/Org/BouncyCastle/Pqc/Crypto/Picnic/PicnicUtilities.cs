// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Picnic.PicnicUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Picnic;

internal static class PicnicUtilities
{
  internal static void Fill(uint[] buf, int from, int to, uint b)
  {
    for (int index = from; index < to; ++index)
      buf[index] = b;
  }

  internal static int NumBytes(int numBits) => numBits + 7 >> 3;

  internal static uint ceil_log2(uint x)
  {
    return x != 0U ? (uint) (32 /*0x20*/ - Integers.NumberOfLeadingZeros((int) x - 1)) : 0U;
  }

  internal static int Parity(byte[] data, int len)
  {
    byte i = data[0];
    for (int index = 1; index < len; ++index)
      i ^= data[index];
    return Integers.PopCount((int) i) & 1;
  }

  internal static uint Parity16(uint x)
  {
    return (uint) (Integers.PopCount(x & (uint) ushort.MaxValue) & 1);
  }

  internal static uint Parity32(uint x) => (uint) (Integers.PopCount(x) & 1);

  internal static void SetBitInWordArray(uint[] array, int bitNumber, uint val)
  {
    PicnicUtilities.SetBit(array, bitNumber, val);
  }

  internal static uint GetBitFromWordArray(uint[] array, int bitNumber)
  {
    return PicnicUtilities.GetBit(array, bitNumber);
  }

  internal static byte GetBit(byte[] array, int bitNumber)
  {
    int index = bitNumber >> 3;
    int num = bitNumber & 7 ^ 7;
    return (byte) ((int) array[index] >> num & 1);
  }

  internal static uint GetBit(uint word, int bitNumber)
  {
    int num = bitNumber ^ 7;
    return word >> num & 1U;
  }

  internal static uint GetBit(uint[] array, int bitNumber)
  {
    int index = bitNumber >> 5;
    int num = bitNumber & 31 /*0x1F*/ ^ 7;
    return array[index] >> num & 1U;
  }

  internal static void SetBit(byte[] array, int bitNumber, byte val)
  {
    int index = bitNumber >> 3;
    int num1 = bitNumber & 7 ^ 7;
    uint num2 = (uint) array[index] & (uint) ~(1 << num1) | (uint) val << num1;
    array[index] = (byte) num2;
  }

  internal static uint SetBit(uint word, int bitNumber, uint bit)
  {
    int num = bitNumber ^ 7;
    word &= (uint) ~(1 << num);
    word |= bit << num;
    return word;
  }

  internal static void SetBit(uint[] array, int bitNumber, uint val)
  {
    int index = bitNumber >> 5;
    int num1 = bitNumber & 31 /*0x1F*/ ^ 7;
    uint num2 = array[index] & (uint) ~(1 << num1) | val << num1;
    array[index] = num2;
  }

  internal static void ZeroTrailingBits(byte[] data, int bitLength)
  {
    int num = bitLength & 7;
    if (num == 0)
      return;
    data[bitLength >> 3] &= (byte) (65280 >> num);
  }
}
