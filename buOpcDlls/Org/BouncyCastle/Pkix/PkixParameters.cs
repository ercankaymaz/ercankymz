// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pkix.PkixParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.X509;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Pkix;

public class PkixParameters
{
  public const int PkixValidityModel = 0;
  public const int ChainValidityModel = 1;
  private HashSet<TrustAnchor> trustAnchors;
  private DateTime? date;
  private List<PkixCertPathChecker> m_checkers;
  private bool revocationEnabled = true;
  private HashSet<string> initialPolicies;
  private bool explicitPolicyRequired;
  private bool anyPolicyInhibited;
  private bool policyMappingInhibited;
  private bool policyQualifiersRejected = true;
  private List<IStore<X509V2AttributeCertificate>> m_storesAttrCert;
  private List<IStore<X509Certificate>> m_storesCert;
  private List<IStore<X509Crl>> m_storesCrl;
  private ISelector<X509V2AttributeCertificate> m_targetConstraintsAttrCert;
  private ISelector<X509Certificate> m_targetConstraintsCert;
  private bool additionalLocationsEnabled;
  private ISet<TrustAnchor> trustedACIssuers;
  private ISet<string> necessaryACAttributes;
  private ISet<string> prohibitedACAttributes;
  private ISet<PkixAttrCertChecker> attrCertCheckers;
  private int validityModel;
  private bool useDeltas;

  public PkixParameters(ISet<TrustAnchor> trustAnchors)
  {
    this.SetTrustAnchors(trustAnchors);
    this.initialPolicies = new HashSet<string>();
    this.m_checkers = new List<PkixCertPathChecker>();
    this.m_storesAttrCert = new List<IStore<X509V2AttributeCertificate>>();
    this.m_storesCert = new List<IStore<X509Certificate>>();
    this.m_storesCrl = new List<IStore<X509Crl>>();
    this.trustedACIssuers = (ISet<TrustAnchor>) new HashSet<TrustAnchor>();
    this.necessaryACAttributes = (ISet<string>) new HashSet<string>();
    this.prohibitedACAttributes = (ISet<string>) new HashSet<string>();
    this.attrCertCheckers = (ISet<PkixAttrCertChecker>) new HashSet<PkixAttrCertChecker>();
  }

  public virtual bool IsRevocationEnabled
  {
    get => this.revocationEnabled;
    set => this.revocationEnabled = value;
  }

  public virtual bool IsExplicitPolicyRequired
  {
    get => this.explicitPolicyRequired;
    set => this.explicitPolicyRequired = value;
  }

  public virtual bool IsAnyPolicyInhibited
  {
    get => this.anyPolicyInhibited;
    set => this.anyPolicyInhibited = value;
  }

  public virtual bool IsPolicyMappingInhibited
  {
    get => this.policyMappingInhibited;
    set => this.policyMappingInhibited = value;
  }

  public virtual bool IsPolicyQualifiersRejected
  {
    get => this.policyQualifiersRejected;
    set => this.policyQualifiersRejected = value;
  }

  public virtual DateTime? Date
  {
    get => this.date;
    set => this.date = value;
  }

  public virtual ISet<TrustAnchor> GetTrustAnchors()
  {
    return (ISet<TrustAnchor>) new HashSet<TrustAnchor>((IEnumerable<TrustAnchor>) this.trustAnchors);
  }

  public virtual void SetTrustAnchors(ISet<TrustAnchor> tas)
  {
    if (tas == null)
      throw new ArgumentNullException("value");
    if (tas.Count < 1)
      throw new ArgumentException("non-empty set required", "value");
    this.trustAnchors = new HashSet<TrustAnchor>();
    foreach (TrustAnchor ta in (IEnumerable<TrustAnchor>) tas)
    {
      if (ta != null)
        this.trustAnchors.Add(ta);
    }
  }

  public virtual ISelector<X509V2AttributeCertificate> GetTargetConstraintsAttrCert()
  {
    return (ISelector<X509V2AttributeCertificate>) this.m_targetConstraintsAttrCert?.Clone();
  }

  public virtual void SetTargetConstraintsAttrCert(
    ISelector<X509V2AttributeCertificate> targetConstraintsAttrCert)
  {
    this.m_targetConstraintsAttrCert = (ISelector<X509V2AttributeCertificate>) targetConstraintsAttrCert?.Clone();
  }

  public virtual ISelector<X509Certificate> GetTargetConstraintsCert()
  {
    return (ISelector<X509Certificate>) this.m_targetConstraintsCert?.Clone();
  }

  public virtual void SetTargetConstraintsCert(ISelector<X509Certificate> targetConstraintsCert)
  {
    this.m_targetConstraintsCert = (ISelector<X509Certificate>) targetConstraintsCert?.Clone();
  }

  public virtual ISet<string> GetInitialPolicies()
  {
    return this.initialPolicies == null ? (ISet<string>) new HashSet<string>() : (ISet<string>) new HashSet<string>((IEnumerable<string>) this.initialPolicies);
  }

  public virtual void SetInitialPolicies(ISet<string> initialPolicies)
  {
    this.initialPolicies = new HashSet<string>();
    if (initialPolicies == null)
      return;
    foreach (string initialPolicy in (IEnumerable<string>) initialPolicies)
    {
      if (initialPolicy != null)
        this.initialPolicies.Add(initialPolicy);
    }
  }

  public virtual void SetCertPathCheckers(IList<PkixCertPathChecker> checkers)
  {
    this.m_checkers = new List<PkixCertPathChecker>();
    if (checkers == null)
      return;
    foreach (PkixCertPathChecker checker in (IEnumerable<PkixCertPathChecker>) checkers)
      this.m_checkers.Add((PkixCertPathChecker) checker.Clone());
  }

  public virtual IList<PkixCertPathChecker> GetCertPathCheckers()
  {
    List<PkixCertPathChecker> certPathCheckers = new List<PkixCertPathChecker>(this.m_checkers.Count);
    foreach (PkixCertPathChecker checker in this.m_checkers)
      certPathCheckers.Add((PkixCertPathChecker) checker.Clone());
    return (IList<PkixCertPathChecker>) certPathCheckers;
  }

  public virtual void AddCertPathChecker(PkixCertPathChecker checker)
  {
    if (checker == null)
      return;
    this.m_checkers.Add((PkixCertPathChecker) checker.Clone());
  }

  public virtual object Clone()
  {
    PkixParameters pkixParameters = new PkixParameters(this.GetTrustAnchors());
    pkixParameters.SetParams(this);
    return (object) pkixParameters;
  }

  protected virtual void SetParams(PkixParameters parameters)
  {
    this.Date = parameters.Date;
    this.SetCertPathCheckers(parameters.GetCertPathCheckers());
    this.IsAnyPolicyInhibited = parameters.IsAnyPolicyInhibited;
    this.IsExplicitPolicyRequired = parameters.IsExplicitPolicyRequired;
    this.IsPolicyMappingInhibited = parameters.IsPolicyMappingInhibited;
    this.IsRevocationEnabled = parameters.IsRevocationEnabled;
    this.SetInitialPolicies(parameters.GetInitialPolicies());
    this.IsPolicyQualifiersRejected = parameters.IsPolicyQualifiersRejected;
    this.SetTrustAnchors(parameters.GetTrustAnchors());
    this.m_storesAttrCert = new List<IStore<X509V2AttributeCertificate>>((IEnumerable<IStore<X509V2AttributeCertificate>>) parameters.m_storesAttrCert);
    this.m_storesCert = new List<IStore<X509Certificate>>((IEnumerable<IStore<X509Certificate>>) parameters.m_storesCert);
    this.m_storesCrl = new List<IStore<X509Crl>>((IEnumerable<IStore<X509Crl>>) parameters.m_storesCrl);
    this.SetTargetConstraintsAttrCert(parameters.GetTargetConstraintsAttrCert());
    this.SetTargetConstraintsCert(parameters.GetTargetConstraintsCert());
    this.validityModel = parameters.validityModel;
    this.useDeltas = parameters.useDeltas;
    this.additionalLocationsEnabled = parameters.additionalLocationsEnabled;
    this.trustedACIssuers = (ISet<TrustAnchor>) new HashSet<TrustAnchor>((IEnumerable<TrustAnchor>) parameters.trustedACIssuers);
    this.prohibitedACAttributes = (ISet<string>) new HashSet<string>((IEnumerable<string>) parameters.prohibitedACAttributes);
    this.necessaryACAttributes = (ISet<string>) new HashSet<string>((IEnumerable<string>) parameters.necessaryACAttributes);
    this.attrCertCheckers = (ISet<PkixAttrCertChecker>) new HashSet<PkixAttrCertChecker>((IEnumerable<PkixAttrCertChecker>) parameters.attrCertCheckers);
  }

  public virtual bool IsUseDeltasEnabled
  {
    get => this.useDeltas;
    set => this.useDeltas = value;
  }

  public virtual int ValidityModel
  {
    get => this.validityModel;
    set => this.validityModel = value;
  }

  public virtual IList<IStore<X509V2AttributeCertificate>> GetStoresAttrCert()
  {
    return (IList<IStore<X509V2AttributeCertificate>>) new List<IStore<X509V2AttributeCertificate>>((IEnumerable<IStore<X509V2AttributeCertificate>>) this.m_storesAttrCert);
  }

  public virtual IList<IStore<X509Certificate>> GetStoresCert()
  {
    return (IList<IStore<X509Certificate>>) new List<IStore<X509Certificate>>((IEnumerable<IStore<X509Certificate>>) this.m_storesCert);
  }

  public virtual IList<IStore<X509Crl>> GetStoresCrl()
  {
    return (IList<IStore<X509Crl>>) new List<IStore<X509Crl>>((IEnumerable<IStore<X509Crl>>) this.m_storesCrl);
  }

  [Obsolete("Use 'SetStoresAttrCert' instead")]
  public virtual void SetAttrStoresCert(
    IList<IStore<X509V2AttributeCertificate>> storesAttrCert)
  {
    this.SetStoresAttrCert(storesAttrCert);
  }

  public virtual void SetStoresAttrCert(
    IList<IStore<X509V2AttributeCertificate>> storesAttrCert)
  {
    if (storesAttrCert == null)
      this.m_storesAttrCert = new List<IStore<X509V2AttributeCertificate>>();
    else
      this.m_storesAttrCert = new List<IStore<X509V2AttributeCertificate>>((IEnumerable<IStore<X509V2AttributeCertificate>>) storesAttrCert);
  }

  public virtual void SetStoresCert(IList<IStore<X509Certificate>> storesCert)
  {
    if (storesCert == null)
      this.m_storesCert = new List<IStore<X509Certificate>>();
    else
      this.m_storesCert = new List<IStore<X509Certificate>>((IEnumerable<IStore<X509Certificate>>) storesCert);
  }

  public virtual void SetStoresCrl(IList<IStore<X509Crl>> storesCrl)
  {
    if (storesCrl == null)
      this.m_storesCrl = new List<IStore<X509Crl>>();
    else
      this.m_storesCrl = new List<IStore<X509Crl>>((IEnumerable<IStore<X509Crl>>) storesCrl);
  }

  public virtual void AddStoreAttrCert(IStore<X509V2AttributeCertificate> storeAttrCert)
  {
    if (storeAttrCert == null)
      return;
    this.m_storesAttrCert.Add(storeAttrCert);
  }

  public virtual void AddStoreCert(IStore<X509Certificate> storeCert)
  {
    if (storeCert == null)
      return;
    this.m_storesCert.Add(storeCert);
  }

  public virtual void AddStoreCrl(IStore<X509Crl> storeCrl)
  {
    if (storeCrl == null)
      return;
    this.m_storesCrl.Add(storeCrl);
  }

  public virtual bool IsAdditionalLocationsEnabled => this.additionalLocationsEnabled;

  public virtual void SetAdditionalLocationsEnabled(bool enabled)
  {
    this.additionalLocationsEnabled = enabled;
  }

  public virtual ISet<TrustAnchor> GetTrustedACIssuers()
  {
    return (ISet<TrustAnchor>) new HashSet<TrustAnchor>((IEnumerable<TrustAnchor>) this.trustedACIssuers);
  }

  public virtual void SetTrustedACIssuers(ISet<TrustAnchor> trustedACIssuers)
  {
    if (trustedACIssuers == null)
      this.trustedACIssuers = (ISet<TrustAnchor>) new HashSet<TrustAnchor>();
    else
      this.trustedACIssuers = (ISet<TrustAnchor>) new HashSet<TrustAnchor>((IEnumerable<TrustAnchor>) trustedACIssuers);
  }

  public virtual ISet<string> GetNecessaryACAttributes()
  {
    return (ISet<string>) new HashSet<string>((IEnumerable<string>) this.necessaryACAttributes);
  }

  public virtual void SetNecessaryACAttributes(ISet<string> necessaryACAttributes)
  {
    if (necessaryACAttributes == null)
      this.necessaryACAttributes = (ISet<string>) new HashSet<string>();
    else
      this.necessaryACAttributes = (ISet<string>) new HashSet<string>((IEnumerable<string>) necessaryACAttributes);
  }

  public virtual ISet<string> GetProhibitedACAttributes()
  {
    return (ISet<string>) new HashSet<string>((IEnumerable<string>) this.prohibitedACAttributes);
  }

  public virtual void SetProhibitedACAttributes(ISet<string> prohibitedACAttributes)
  {
    if (prohibitedACAttributes == null)
      this.prohibitedACAttributes = (ISet<string>) new HashSet<string>();
    else
      this.prohibitedACAttributes = (ISet<string>) new HashSet<string>((IEnumerable<string>) prohibitedACAttributes);
  }

  public virtual ISet<PkixAttrCertChecker> GetAttrCertCheckers()
  {
    return (ISet<PkixAttrCertChecker>) new HashSet<PkixAttrCertChecker>((IEnumerable<PkixAttrCertChecker>) this.attrCertCheckers);
  }

  public virtual void SetAttrCertCheckers(ISet<PkixAttrCertChecker> attrCertCheckers)
  {
    if (attrCertCheckers == null)
      this.attrCertCheckers = (ISet<PkixAttrCertChecker>) new HashSet<PkixAttrCertChecker>();
    else
      this.attrCertCheckers = (ISet<PkixAttrCertChecker>) new HashSet<PkixAttrCertChecker>((IEnumerable<PkixAttrCertChecker>) attrCertCheckers);
  }
}
