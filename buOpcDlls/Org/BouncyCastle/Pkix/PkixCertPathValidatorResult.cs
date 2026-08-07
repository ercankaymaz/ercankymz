// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pkix.PkixCertPathValidatorResult
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using System;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Pkix;

public class PkixCertPathValidatorResult
{
  private TrustAnchor trustAnchor;
  private PkixPolicyNode policyTree;
  private AsymmetricKeyParameter subjectPublicKey;

  public PkixPolicyNode PolicyTree => this.policyTree;

  public TrustAnchor TrustAnchor => this.trustAnchor;

  public AsymmetricKeyParameter SubjectPublicKey => this.subjectPublicKey;

  public PkixCertPathValidatorResult(
    TrustAnchor trustAnchor,
    PkixPolicyNode policyTree,
    AsymmetricKeyParameter subjectPublicKey)
  {
    this.trustAnchor = trustAnchor ?? throw new ArgumentNullException(nameof (trustAnchor));
    this.policyTree = policyTree;
    this.subjectPublicKey = subjectPublicKey ?? throw new ArgumentNullException(nameof (subjectPublicKey));
  }

  public object Clone()
  {
    return (object) new PkixCertPathValidatorResult(this.TrustAnchor, this.PolicyTree, this.SubjectPublicKey);
  }

  public override string ToString()
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.AppendLine("PKIXCertPathValidatorResult: [");
    stringBuilder.Append("  Trust Anchor: ").Append((object) this.TrustAnchor).AppendLine();
    stringBuilder.Append("  Policy Tree: ").Append((object) this.PolicyTree).AppendLine();
    stringBuilder.Append("  Subject Public Key: ").Append((object) this.SubjectPublicKey).AppendLine();
    return stringBuilder.ToString();
  }
}
