// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pkix.PkixPolicyNode
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities.Collections;
using System.Collections.Generic;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Pkix;

public class PkixPolicyNode
{
  protected IList<PkixPolicyNode> mChildren;
  protected int mDepth;
  protected ISet<string> mExpectedPolicies;
  protected PkixPolicyNode mParent;
  protected ISet<PolicyQualifierInfo> mPolicyQualifiers;
  protected string mValidPolicy;
  protected bool mCritical;

  public virtual int Depth => this.mDepth;

  public virtual IEnumerable<PkixPolicyNode> Children
  {
    get => CollectionUtilities.Proxy<PkixPolicyNode>((IEnumerable<PkixPolicyNode>) this.mChildren);
  }

  public virtual bool IsCritical
  {
    get => this.mCritical;
    set => this.mCritical = value;
  }

  public virtual ISet<PolicyQualifierInfo> PolicyQualifiers
  {
    get
    {
      return (ISet<PolicyQualifierInfo>) new HashSet<PolicyQualifierInfo>((IEnumerable<PolicyQualifierInfo>) this.mPolicyQualifiers);
    }
  }

  public virtual string ValidPolicy => this.mValidPolicy;

  public virtual bool HasChildren => this.mChildren.Count != 0;

  public virtual ISet<string> ExpectedPolicies
  {
    get => (ISet<string>) new HashSet<string>((IEnumerable<string>) this.mExpectedPolicies);
    set => this.mExpectedPolicies = (ISet<string>) new HashSet<string>((IEnumerable<string>) value);
  }

  public virtual PkixPolicyNode Parent
  {
    get => this.mParent;
    set => this.mParent = value;
  }

  public PkixPolicyNode(
    IEnumerable<PkixPolicyNode> children,
    int depth,
    ISet<string> expectedPolicies,
    PkixPolicyNode parent,
    ISet<PolicyQualifierInfo> policyQualifiers,
    string validPolicy,
    bool critical)
  {
    this.mChildren = children != null ? (IList<PkixPolicyNode>) new List<PkixPolicyNode>(children) : (IList<PkixPolicyNode>) new List<PkixPolicyNode>();
    this.mDepth = depth;
    this.mExpectedPolicies = expectedPolicies;
    this.mParent = parent;
    this.mPolicyQualifiers = policyQualifiers;
    this.mValidPolicy = validPolicy;
    this.mCritical = critical;
  }

  public virtual void AddChild(PkixPolicyNode child)
  {
    child.Parent = this;
    this.mChildren.Add(child);
  }

  public virtual void RemoveChild(PkixPolicyNode child) => this.mChildren.Remove(child);

  public override string ToString() => this.ToString("");

  public virtual string ToString(string indent)
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append(indent);
    stringBuilder.Append(this.mValidPolicy);
    stringBuilder.AppendLine(" {");
    foreach (PkixPolicyNode mChild in (IEnumerable<PkixPolicyNode>) this.mChildren)
      stringBuilder.Append(mChild.ToString(indent + "    "));
    stringBuilder.Append(indent);
    stringBuilder.AppendLine("}");
    return stringBuilder.ToString();
  }

  public virtual object Clone() => (object) this.Copy();

  public virtual PkixPolicyNode Copy()
  {
    PkixPolicyNode pkixPolicyNode = new PkixPolicyNode((IEnumerable<PkixPolicyNode>) new List<PkixPolicyNode>(), this.mDepth, (ISet<string>) new HashSet<string>((IEnumerable<string>) this.mExpectedPolicies), (PkixPolicyNode) null, (ISet<PolicyQualifierInfo>) new HashSet<PolicyQualifierInfo>((IEnumerable<PolicyQualifierInfo>) this.mPolicyQualifiers), this.mValidPolicy, this.mCritical);
    foreach (PkixPolicyNode mChild in (IEnumerable<PkixPolicyNode>) this.mChildren)
    {
      PkixPolicyNode child = mChild.Copy();
      child.Parent = pkixPolicyNode;
      pkixPolicyNode.AddChild(child);
    }
    return pkixPolicyNode;
  }
}
