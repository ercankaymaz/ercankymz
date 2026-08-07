// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cmp.CertificateStatus
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Cms;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.X509;

#nullable disable
namespace Org.BouncyCastle.Cmp;

public class CertificateStatus
{
  private static readonly DefaultSignatureAlgorithmIdentifierFinder sigAlgFinder = new DefaultSignatureAlgorithmIdentifierFinder();
  private readonly DefaultDigestAlgorithmIdentifierFinder digestAlgFinder;
  private readonly CertStatus certStatus;

  public CertificateStatus(
    DefaultDigestAlgorithmIdentifierFinder digestAlgFinder,
    CertStatus certStatus)
  {
    this.digestAlgFinder = digestAlgFinder;
    this.certStatus = certStatus;
  }

  public virtual PkiStatusInfo StatusInfo => this.certStatus.StatusInfo;

  public virtual BigInteger CertRequestID => this.certStatus.CertReqID.Value;

  public virtual bool IsVerified(X509Certificate cert)
  {
    byte[] digest = DigestUtilities.CalculateDigest((this.digestAlgFinder.Find(CertificateStatus.sigAlgFinder.Find(cert.SigAlgName)) ?? throw new CmpException("cannot find algorithm for digest from signature " + cert.SigAlgName)).Algorithm, cert.GetEncoded());
    return Arrays.FixedTimeEquals(this.certStatus.CertHash.GetOctets(), digest);
  }
}
