// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pkix.PkixBuilderParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.X509;
using System.Collections.Generic;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Pkix;

public class PkixBuilderParameters : PkixParameters
{
  private int maxPathLength = 5;
  private HashSet<X509Certificate> excludedCerts = new HashSet<X509Certificate>();

  public static PkixBuilderParameters GetInstance(PkixParameters pkixParams)
  {
    PkixBuilderParameters instance = new PkixBuilderParameters(pkixParams.GetTrustAnchors(), pkixParams.GetTargetConstraintsCert(), pkixParams.GetTargetConstraintsAttrCert());
    instance.SetParams(pkixParams);
    return instance;
  }

  public PkixBuilderParameters(
    ISet<TrustAnchor> trustAnchors,
    ISelector<X509Certificate> targetConstraintsCert)
    : this(trustAnchors, targetConstraintsCert, (ISelector<X509V2AttributeCertificate>) null)
  {
  }

  public PkixBuilderParameters(
    ISet<TrustAnchor> trustAnchors,
    ISelector<X509Certificate> targetConstraintsCert,
    ISelector<X509V2AttributeCertificate> targetConstraintsAttrCert)
    : base(trustAnchors)
  {
    this.SetTargetConstraintsCert(targetConstraintsCert);
    this.SetTargetConstraintsAttrCert(targetConstraintsAttrCert);
  }

  public virtual int MaxPathLength
  {
    get => this.maxPathLength;
    set
    {
      this.maxPathLength = value >= -1 ? value : throw new InvalidParameterException("The maximum path length parameter can not be less than -1.");
    }
  }

  public virtual ISet<X509Certificate> GetExcludedCerts()
  {
    return (ISet<X509Certificate>) new HashSet<X509Certificate>((IEnumerable<X509Certificate>) this.excludedCerts);
  }

  public virtual void SetExcludedCerts(ISet<X509Certificate> excludedCerts)
  {
    if (excludedCerts == null)
      this.excludedCerts = new HashSet<X509Certificate>();
    else
      this.excludedCerts = new HashSet<X509Certificate>((IEnumerable<X509Certificate>) excludedCerts);
  }

  protected override void SetParams(PkixParameters parameters)
  {
    base.SetParams(parameters);
    if (!(parameters is PkixBuilderParameters builderParameters))
      return;
    this.maxPathLength = builderParameters.maxPathLength;
    this.excludedCerts = new HashSet<X509Certificate>((IEnumerable<X509Certificate>) builderParameters.excludedCerts);
  }

  public override object Clone()
  {
    PkixBuilderParameters builderParameters = new PkixBuilderParameters(this.GetTrustAnchors(), this.GetTargetConstraintsCert(), this.GetTargetConstraintsAttrCert());
    builderParameters.SetParams((PkixParameters) this);
    return (object) builderParameters;
  }

  public override string ToString()
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.AppendLine("PkixBuilderParameters [");
    stringBuilder.Append(base.ToString());
    stringBuilder.Append("  Maximum Path Length: ");
    stringBuilder.Append(this.MaxPathLength);
    stringBuilder.AppendLine();
    stringBuilder.AppendLine("]");
    return stringBuilder.ToString();
  }
}
