// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Crmf.SubsequentMessage
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Crmf;

public class SubsequentMessage : DerInteger
{
  public static readonly SubsequentMessage encrCert = new SubsequentMessage(0);
  public static readonly SubsequentMessage challengeResp = new SubsequentMessage(1);

  private SubsequentMessage(int value)
    : base(value)
  {
  }

  public static SubsequentMessage ValueOf(int value)
  {
    if (value == 0)
      return SubsequentMessage.encrCert;
    if (value != 1)
      throw new ArgumentException("unknown value: " + value.ToString(), nameof (value));
    return SubsequentMessage.challengeResp;
  }
}
