// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.DesParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class DesParameters : KeyParameter
{
  public const int DesKeyLength = 8;
  private const int N_DES_WEAK_KEYS = 16 /*0x10*/;
  private static readonly byte[] DES_weak_keys = new byte[128 /*0x80*/]
  {
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 1,
    (byte) 31 /*0x1F*/,
    (byte) 31 /*0x1F*/,
    (byte) 31 /*0x1F*/,
    (byte) 31 /*0x1F*/,
    (byte) 14,
    (byte) 14,
    (byte) 14,
    (byte) 14,
    (byte) 224 /*0xE0*/,
    (byte) 224 /*0xE0*/,
    (byte) 224 /*0xE0*/,
    (byte) 224 /*0xE0*/,
    (byte) 241,
    (byte) 241,
    (byte) 241,
    (byte) 241,
    (byte) 254,
    (byte) 254,
    (byte) 254,
    (byte) 254,
    (byte) 254,
    (byte) 254,
    (byte) 254,
    (byte) 254,
    (byte) 1,
    (byte) 254,
    (byte) 1,
    (byte) 254,
    (byte) 1,
    (byte) 254,
    (byte) 1,
    (byte) 254,
    (byte) 31 /*0x1F*/,
    (byte) 224 /*0xE0*/,
    (byte) 31 /*0x1F*/,
    (byte) 224 /*0xE0*/,
    (byte) 14,
    (byte) 241,
    (byte) 14,
    (byte) 241,
    (byte) 1,
    (byte) 224 /*0xE0*/,
    (byte) 1,
    (byte) 224 /*0xE0*/,
    (byte) 1,
    (byte) 241,
    (byte) 1,
    (byte) 241,
    (byte) 31 /*0x1F*/,
    (byte) 254,
    (byte) 31 /*0x1F*/,
    (byte) 254,
    (byte) 14,
    (byte) 254,
    (byte) 14,
    (byte) 254,
    (byte) 1,
    (byte) 31 /*0x1F*/,
    (byte) 1,
    (byte) 31 /*0x1F*/,
    (byte) 1,
    (byte) 14,
    (byte) 1,
    (byte) 14,
    (byte) 224 /*0xE0*/,
    (byte) 254,
    (byte) 224 /*0xE0*/,
    (byte) 254,
    (byte) 241,
    (byte) 254,
    (byte) 241,
    (byte) 254,
    (byte) 254,
    (byte) 1,
    (byte) 254,
    (byte) 1,
    (byte) 254,
    (byte) 1,
    (byte) 254,
    (byte) 1,
    (byte) 224 /*0xE0*/,
    (byte) 31 /*0x1F*/,
    (byte) 224 /*0xE0*/,
    (byte) 31 /*0x1F*/,
    (byte) 241,
    (byte) 14,
    (byte) 241,
    (byte) 14,
    (byte) 224 /*0xE0*/,
    (byte) 1,
    (byte) 224 /*0xE0*/,
    (byte) 1,
    (byte) 241,
    (byte) 1,
    (byte) 241,
    (byte) 1,
    (byte) 254,
    (byte) 31 /*0x1F*/,
    (byte) 254,
    (byte) 31 /*0x1F*/,
    (byte) 254,
    (byte) 14,
    (byte) 254,
    (byte) 14,
    (byte) 31 /*0x1F*/,
    (byte) 1,
    (byte) 31 /*0x1F*/,
    (byte) 1,
    (byte) 14,
    (byte) 1,
    (byte) 14,
    (byte) 1,
    (byte) 254,
    (byte) 224 /*0xE0*/,
    (byte) 254,
    (byte) 224 /*0xE0*/,
    (byte) 254,
    (byte) 241,
    (byte) 254,
    (byte) 241
  };

  public DesParameters(byte[] key)
    : base(key)
  {
    if (DesParameters.IsWeakKey(key))
      throw new ArgumentException("attempt to create weak DES key");
  }

  public DesParameters(byte[] key, int keyOff, int keyLen)
    : base(key, keyOff, keyLen)
  {
    if (DesParameters.IsWeakKey(key, keyOff))
      throw new ArgumentException("attempt to create weak DES key");
  }

  public static bool IsWeakKey(byte[] key, int offset)
  {
    if (key.Length - offset < 8)
      throw new ArgumentException("key material too short.");
    for (int index1 = 0; index1 < 16 /*0x10*/; ++index1)
    {
      bool flag = false;
      for (int index2 = 0; index2 < 8; ++index2)
      {
        if ((int) key[index2 + offset] != (int) DesParameters.DES_weak_keys[index1 * 8 + index2])
        {
          flag = true;
          break;
        }
      }
      if (!flag)
        return true;
    }
    return false;
  }

  public static bool IsWeakKey(byte[] key) => DesParameters.IsWeakKey(key, 0);

  public static byte SetOddParity(byte b)
  {
    uint num1 = (uint) b ^ 1U;
    uint num2 = num1 ^ num1 >> 4;
    uint num3 = num2 ^ num2 >> 2;
    uint num4 = (num3 ^ num3 >> 1) & 1U;
    return (byte) ((uint) b ^ num4);
  }

  public static void SetOddParity(byte[] bytes)
  {
    for (int index = 0; index < bytes.Length; ++index)
      bytes[index] = DesParameters.SetOddParity(bytes[index]);
  }

  public static void SetOddParity(byte[] bytes, int off, int len)
  {
    for (int index = 0; index < len; ++index)
      bytes[off + index] = DesParameters.SetOddParity(bytes[off + index]);
  }
}
