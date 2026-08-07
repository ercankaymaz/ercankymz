// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.Sig.SignatureExpirationTime
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;

#nullable disable
namespace Org.BouncyCastle.Bcpg.Sig;

public class SignatureExpirationTime : SignatureSubpacket
{
  protected static byte[] TimeToBytes(long t) => Pack.UInt32_To_BE((uint) t);

  public SignatureExpirationTime(bool critical, bool isLongLength, byte[] data)
    : base(SignatureSubpacketTag.ExpireTime, critical, isLongLength, data)
  {
  }

  public SignatureExpirationTime(bool critical, long seconds)
    : base(SignatureSubpacketTag.ExpireTime, critical, false, SignatureExpirationTime.TimeToBytes(seconds))
  {
  }

  public long Time => (long) Pack.BE_To_UInt32(this.data, 0);
}
