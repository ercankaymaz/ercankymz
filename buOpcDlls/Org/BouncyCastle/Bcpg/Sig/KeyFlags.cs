// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.Sig.KeyFlags
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Bcpg.Sig;

public class KeyFlags : SignatureSubpacket
{
  public const int CertifyOther = 1;
  public const int SignData = 2;
  public const int EncryptComms = 4;
  public const int EncryptStorage = 8;
  public const int Split = 16 /*0x10*/;
  public const int Authentication = 32 /*0x20*/;
  public const int Shared = 128 /*0x80*/;

  private static byte[] IntToByteArray(int v)
  {
    byte[] sourceArray = new byte[4];
    int num = 0;
    for (int index = 0; index != 4; ++index)
    {
      sourceArray[index] = (byte) (v >> index * 8);
      if (sourceArray[index] != (byte) 0)
        num = index;
    }
    byte[] destinationArray = new byte[num + 1];
    Array.Copy((Array) sourceArray, 0, (Array) destinationArray, 0, destinationArray.Length);
    return destinationArray;
  }

  public KeyFlags(bool critical, bool isLongLength, byte[] data)
    : base(SignatureSubpacketTag.KeyFlags, critical, isLongLength, data)
  {
  }

  public KeyFlags(bool critical, int flags)
    : base(SignatureSubpacketTag.KeyFlags, critical, false, KeyFlags.IntToByteArray(flags))
  {
  }

  public int Flags
  {
    get
    {
      int flags = 0;
      for (int index = 0; index != this.data.Length; ++index)
        flags |= ((int) this.data[index] & (int) byte.MaxValue) << index * 8;
      return flags;
    }
  }
}
