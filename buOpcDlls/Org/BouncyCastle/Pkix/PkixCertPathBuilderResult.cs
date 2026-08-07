// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pkix.PkixCertPathBuilderResult
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using System;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Pkix;

public class PkixCertPathBuilderResult : PkixCertPathValidatorResult
{
  private PkixCertPath certPath;

  public PkixCertPathBuilderResult(
    PkixCertPath certPath,
    TrustAnchor trustAnchor,
    PkixPolicyNode policyTree,
    AsymmetricKeyParameter subjectPublicKey)
    : base(trustAnchor, policyTree, subjectPublicKey)
  {
    this.certPath = certPath ?? throw new ArgumentNullException(nameof (certPath));
  }

  public PkixCertPath CertPath => this.certPath;

  public override string ToString()
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.AppendLine("SimplePKIXCertPathBuilderResult: [");
    stringBuilder.Append("  Certification Path: ").Append((object) this.CertPath).AppendLine();
    stringBuilder.Append("  Trust Anchor: ").Append((object) this.TrustAnchor.TrustedCert.IssuerDN).AppendLine();
    stringBuilder.Append("  Subject Public Key: ").Append((object) this.SubjectPublicKey).AppendLine();
    return stringBuilder.ToString();
  }
}
