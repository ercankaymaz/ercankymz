// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.Sig.PrimaryUserId
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Bcpg.Sig;

public class PrimaryUserId : SignatureSubpacket
{
  private static byte[] BooleanToByteArray(bool val)
  {
    return new byte[1]{ Convert.ToByte(val) };
  }

  public PrimaryUserId(bool critical, bool isLongLength, byte[] data)
    : base(SignatureSubpacketTag.PrimaryUserId, critical, isLongLength, data)
  {
  }

  public PrimaryUserId(bool critical, bool isPrimaryUserId)
    : base(SignatureSubpacketTag.PrimaryUserId, critical, false, PrimaryUserId.BooleanToByteArray(isPrimaryUserId))
  {
  }

  public bool IsPrimaryUserId() => this.data[0] > (byte) 0;
}
