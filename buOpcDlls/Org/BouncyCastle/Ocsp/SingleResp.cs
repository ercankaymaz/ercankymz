// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Ocsp.SingleResp
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Ocsp;

public class SingleResp : X509ExtensionBase
{
  internal readonly SingleResponse resp;

  public SingleResp(SingleResponse resp) => this.resp = resp;

  public CertificateID GetCertID() => new CertificateID(this.resp.CertId);

  public object GetCertStatus()
  {
    CertStatus certStatus = this.resp.CertStatus;
    if (certStatus.TagNo == 0)
      return (object) null;
    return certStatus.TagNo == 1 ? (object) new RevokedStatus(RevokedInfo.GetInstance((object) certStatus.Status)) : (object) new UnknownStatus();
  }

  public DateTime ThisUpdate => this.resp.ThisUpdate.ToDateTime();

  public DateTime? NextUpdate => this.resp.NextUpdate?.ToDateTime();

  public X509Extensions SingleExtensions => this.resp.SingleExtensions;

  protected override X509Extensions GetX509Extensions() => this.SingleExtensions;
}
