// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.OriginatorInformation
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.X509;

#nullable disable
namespace Org.BouncyCastle.Cms;

public class OriginatorInformation
{
  private readonly OriginatorInfo originatorInfo;

  public OriginatorInformation(OriginatorInfo originatorInfo)
  {
    this.originatorInfo = originatorInfo;
  }

  public virtual IStore<X509Certificate> GetCertificates()
  {
    return CmsSignedHelper.Instance.GetCertificates(this.originatorInfo.Certificates);
  }

  public virtual IStore<X509Crl> GetCrls()
  {
    return CmsSignedHelper.Instance.GetCrls(this.originatorInfo.Crls);
  }

  public virtual OriginatorInfo ToAsn1Structure() => this.originatorInfo;
}
