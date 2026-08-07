// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.Sig.SignatureCreationTime
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities.Date;
using System;

#nullable disable
namespace Org.BouncyCastle.Bcpg.Sig;

public class SignatureCreationTime : SignatureSubpacket
{
  protected static byte[] TimeToBytes(DateTime time)
  {
    return Pack.UInt32_To_BE((uint) (DateTimeUtilities.DateTimeToUnixMs(time) / 1000L));
  }

  public SignatureCreationTime(bool critical, bool isLongLength, byte[] data)
    : base(SignatureSubpacketTag.CreationTime, critical, isLongLength, data)
  {
  }

  public SignatureCreationTime(bool critical, DateTime date)
    : base(SignatureSubpacketTag.CreationTime, critical, false, SignatureCreationTime.TimeToBytes(date))
  {
  }

  public DateTime GetTime()
  {
    return DateTimeUtilities.UnixMsToDateTime((long) Pack.BE_To_UInt32(this.data, 0) * 1000L);
  }
}
