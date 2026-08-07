// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.DesEdeParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class DesEdeParameters : DesParameters
{
  public const int DesEdeKeyLength = 24;

  private static byte[] FixKey(byte[] key, int keyOff, int keyLen)
  {
    byte[] numArray = new byte[24];
    if (keyLen != 16 /*0x10*/)
    {
      if (keyLen != 24)
        throw new ArgumentException("Bad length for DESede key: " + keyLen.ToString(), nameof (keyLen));
      Array.Copy((Array) key, keyOff, (Array) numArray, 0, 24);
    }
    else
    {
      Array.Copy((Array) key, keyOff, (Array) numArray, 0, 16 /*0x10*/);
      Array.Copy((Array) key, keyOff, (Array) numArray, 16 /*0x10*/, 8);
    }
    return !DesEdeParameters.IsWeakKey(numArray) ? numArray : throw new ArgumentException("attempt to create weak DESede key");
  }

  public DesEdeParameters(byte[] key)
    : base(DesEdeParameters.FixKey(key, 0, key.Length))
  {
  }

  public DesEdeParameters(byte[] key, int keyOff, int keyLen)
    : base(DesEdeParameters.FixKey(key, keyOff, keyLen))
  {
  }

  public static bool IsWeakKey(byte[] key, int offset, int length)
  {
    for (int offset1 = offset; offset1 < length; offset1 += 8)
    {
      if (DesParameters.IsWeakKey(key, offset1))
        return true;
    }
    return false;
  }

  public new static bool IsWeakKey(byte[] key, int offset)
  {
    return DesEdeParameters.IsWeakKey(key, offset, key.Length - offset);
  }

  public new static bool IsWeakKey(byte[] key) => DesEdeParameters.IsWeakKey(key, 0, key.Length);

  public static bool IsRealEdeKey(byte[] key, int offset)
  {
    return key.Length != 16 /*0x10*/ ? DesEdeParameters.IsReal3Key(key, offset) : DesEdeParameters.IsReal2Key(key, offset);
  }

  public static bool IsReal2Key(byte[] key, int offset)
  {
    bool flag = false;
    for (int index = offset; index != offset + 8; ++index)
      flag |= (int) key[index] != (int) key[index + 8];
    return flag;
  }

  public static bool IsReal3Key(byte[] key, int offset)
  {
    bool flag1 = false;
    bool flag2 = false;
    bool flag3 = false;
    for (int index = offset; index != offset + 8; ++index)
    {
      flag1 |= (int) key[index] != (int) key[index + 8];
      flag2 |= (int) key[index] != (int) key[index + 16 /*0x10*/];
      flag3 |= (int) key[index + 8] != (int) key[index + 16 /*0x10*/];
    }
    return flag1 & flag2 & flag3;
  }
}
