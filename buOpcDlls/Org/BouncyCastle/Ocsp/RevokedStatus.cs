// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Ocsp.RevokedStatus
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Asn1.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Ocsp;

public class RevokedStatus : CertificateStatus
{
  private readonly RevokedInfo m_revokedInfo;

  public RevokedStatus(RevokedInfo revokedInfo) => this.m_revokedInfo = revokedInfo;

  public RevokedStatus(DateTime revocationDate)
  {
    this.m_revokedInfo = new RevokedInfo(new Asn1GeneralizedTime(revocationDate));
  }

  public RevokedStatus(DateTime revocationDate, int reason)
  {
    this.m_revokedInfo = new RevokedInfo(new Asn1GeneralizedTime(revocationDate), new CrlReason(reason));
  }

  public DateTime RevocationTime => this.m_revokedInfo.RevocationTime.ToDateTime();

  public bool HasRevocationReason => this.m_revokedInfo.RevocationReason != null;

  public int RevocationReason
  {
    get
    {
      if (this.m_revokedInfo.RevocationReason == null)
        throw new InvalidOperationException("attempt to get a reason where none is available");
      return this.m_revokedInfo.RevocationReason.IntValueExact;
    }
  }
}
