// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.Sig.Revocable
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Bcpg.Sig;

public class Revocable : SignatureSubpacket
{
  private static byte[] BooleanToByteArray(bool value)
  {
    return new byte[1]{ Convert.ToByte(value) };
  }

  public Revocable(bool critical, bool isLongLength, byte[] data)
    : base(SignatureSubpacketTag.Revocable, critical, isLongLength, data)
  {
  }

  public Revocable(bool critical, bool isRevocable)
    : base(SignatureSubpacketTag.Revocable, critical, false, Revocable.BooleanToByteArray(isRevocable))
  {
  }

  public bool IsRevocable() => this.data[0] > (byte) 0;
}
