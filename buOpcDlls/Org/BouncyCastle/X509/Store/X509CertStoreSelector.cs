// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.X509.Store.X509CertStoreSelector
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.X509.Extension;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.X509.Store;

public class X509CertStoreSelector : ISelector<X509Certificate>, ICloneable
{
  private byte[] authorityKeyIdentifier;
  private int basicConstraints = -1;
  private X509Certificate certificate;
  private DateTime? certificateValid;
  private ISet<DerObjectIdentifier> extendedKeyUsage;
  private bool ignoreX509NameOrdering;
  private X509Name issuer;
  private bool[] keyUsage;
  private ISet<DerObjectIdentifier> policy;
  private DateTime? privateKeyValid;
  private BigInteger serialNumber;
  private X509Name subject;
  private byte[] subjectKeyIdentifier;
  private SubjectPublicKeyInfo subjectPublicKey;
  private DerObjectIdentifier subjectPublicKeyAlgID;

  public X509CertStoreSelector()
  {
  }

  public X509CertStoreSelector(X509CertStoreSelector o)
  {
    this.authorityKeyIdentifier = o.AuthorityKeyIdentifier;
    this.basicConstraints = o.BasicConstraints;
    this.certificate = o.Certificate;
    this.certificateValid = o.CertificateValid;
    this.extendedKeyUsage = o.ExtendedKeyUsage;
    this.ignoreX509NameOrdering = o.IgnoreX509NameOrdering;
    this.issuer = o.Issuer;
    this.keyUsage = o.KeyUsage;
    this.policy = o.Policy;
    this.privateKeyValid = o.PrivateKeyValid;
    this.serialNumber = o.SerialNumber;
    this.subject = o.Subject;
    this.subjectKeyIdentifier = o.SubjectKeyIdentifier;
    this.subjectPublicKey = o.SubjectPublicKey;
    this.subjectPublicKeyAlgID = o.SubjectPublicKeyAlgID;
  }

  public virtual object Clone() => (object) new X509CertStoreSelector(this);

  public byte[] AuthorityKeyIdentifier
  {
    get => Arrays.Clone(this.authorityKeyIdentifier);
    set => this.authorityKeyIdentifier = Arrays.Clone(value);
  }

  public int BasicConstraints
  {
    get => this.basicConstraints;
    set
    {
      this.basicConstraints = value >= -2 ? value : throw new ArgumentException("value can't be less than -2", nameof (value));
    }
  }

  public X509Certificate Certificate
  {
    get => this.certificate;
    set => this.certificate = value;
  }

  public DateTime? CertificateValid
  {
    get => this.certificateValid;
    set => this.certificateValid = value;
  }

  public ISet<DerObjectIdentifier> ExtendedKeyUsage
  {
    get => X509CertStoreSelector.CopySet<DerObjectIdentifier>(this.extendedKeyUsage);
    set => this.extendedKeyUsage = X509CertStoreSelector.CopySet<DerObjectIdentifier>(value);
  }

  public bool IgnoreX509NameOrdering
  {
    get => this.ignoreX509NameOrdering;
    set => this.ignoreX509NameOrdering = value;
  }

  public X509Name Issuer
  {
    get => this.issuer;
    set => this.issuer = value;
  }

  public bool[] KeyUsage
  {
    get => X509CertStoreSelector.CopyBoolArray(this.keyUsage);
    set => this.keyUsage = X509CertStoreSelector.CopyBoolArray(value);
  }

  public ISet<DerObjectIdentifier> Policy
  {
    get => X509CertStoreSelector.CopySet<DerObjectIdentifier>(this.policy);
    set => this.policy = X509CertStoreSelector.CopySet<DerObjectIdentifier>(value);
  }

  public DateTime? PrivateKeyValid
  {
    get => this.privateKeyValid;
    set => this.privateKeyValid = value;
  }

  public BigInteger SerialNumber
  {
    get => this.serialNumber;
    set => this.serialNumber = value;
  }

  public X509Name Subject
  {
    get => this.subject;
    set => this.subject = value;
  }

  public byte[] SubjectKeyIdentifier
  {
    get => Arrays.Clone(this.subjectKeyIdentifier);
    set => this.subjectKeyIdentifier = Arrays.Clone(value);
  }

  public SubjectPublicKeyInfo SubjectPublicKey
  {
    get => this.subjectPublicKey;
    set => this.subjectPublicKey = value;
  }

  public DerObjectIdentifier SubjectPublicKeyAlgID
  {
    get => this.subjectPublicKeyAlgID;
    set => this.subjectPublicKeyAlgID = value;
  }

  public virtual bool Match(X509Certificate c)
  {
    if (c == null || !X509CertStoreSelector.MatchExtension(this.authorityKeyIdentifier, c, X509Extensions.AuthorityKeyIdentifier))
      return false;
    if (this.basicConstraints != -1)
    {
      int basicConstraints = c.GetBasicConstraints();
      if (this.basicConstraints == -2)
      {
        if (basicConstraints != -1)
          return false;
      }
      else if (basicConstraints < this.basicConstraints)
        return false;
    }
    if (this.certificate != null && !this.certificate.Equals((object) c) || this.certificateValid.HasValue && !c.IsValid(this.certificateValid.Value))
      return false;
    if (this.extendedKeyUsage != null)
    {
      IList<DerObjectIdentifier> extendedKeyUsage = c.GetExtendedKeyUsage();
      if (extendedKeyUsage != null)
      {
        foreach (DerObjectIdentifier objectIdentifier in (IEnumerable<DerObjectIdentifier>) this.extendedKeyUsage)
        {
          if (!extendedKeyUsage.Contains(objectIdentifier))
            return false;
        }
      }
    }
    if (this.issuer != null && !this.issuer.Equivalent(c.IssuerDN, !this.ignoreX509NameOrdering))
      return false;
    if (this.keyUsage != null)
    {
      bool[] keyUsage = c.GetKeyUsage();
      if (keyUsage != null)
      {
        for (int index = 0; index < 9; ++index)
        {
          if (this.keyUsage[index] && !keyUsage[index])
            return false;
        }
      }
    }
    if (this.policy != null)
    {
      Asn1OctetString extensionValue = c.GetExtensionValue(X509Extensions.CertificatePolicies);
      if (extensionValue == null)
        return false;
      Asn1Sequence instance = Asn1Sequence.GetInstance((object) X509ExtensionUtilities.FromExtensionValue(extensionValue));
      if (this.policy.Count < 1 && instance.Count < 1)
        return false;
      bool flag = false;
      foreach (PolicyInformation policyInformation in instance)
      {
        if (this.policy.Contains(policyInformation.PolicyIdentifier))
        {
          flag = true;
          break;
        }
      }
      if (!flag)
        return false;
    }
    if (this.privateKeyValid.HasValue)
    {
      Asn1OctetString extensionValue = c.GetExtensionValue(X509Extensions.PrivateKeyUsagePeriod);
      if (extensionValue == null)
        return false;
      PrivateKeyUsagePeriod instance = PrivateKeyUsagePeriod.GetInstance((object) X509ExtensionUtilities.FromExtensionValue(extensionValue));
      DateTime dateTime1 = this.privateKeyValid.Value;
      DateTime dateTime2 = instance.NotAfter.ToDateTime();
      DateTime dateTime3 = instance.NotBefore.ToDateTime();
      if (dateTime1.CompareTo(dateTime2) > 0 || dateTime1.CompareTo(dateTime3) < 0)
        return false;
    }
    return (this.serialNumber == null || this.serialNumber.Equals(c.SerialNumber)) && (this.subject == null || this.subject.Equivalent(c.SubjectDN, !this.ignoreX509NameOrdering)) && X509CertStoreSelector.MatchExtension(this.subjectKeyIdentifier, c, X509Extensions.SubjectKeyIdentifier) && (this.subjectPublicKey == null || this.subjectPublicKey.Equals((object) X509CertStoreSelector.GetSubjectPublicKey(c))) && (this.subjectPublicKeyAlgID == null || this.subjectPublicKeyAlgID.Equals((object) X509CertStoreSelector.GetSubjectPublicKey(c).AlgorithmID));
  }

  internal static bool IssuersMatch(X509Name a, X509Name b)
  {
    return a != null ? a.Equivalent(b, true) : b == null;
  }

  private static bool[] CopyBoolArray(bool[] b) => b != null ? (bool[]) b.Clone() : (bool[]) null;

  private static ISet<T> CopySet<T>(ISet<T> s)
  {
    return s != null ? (ISet<T>) new HashSet<T>((IEnumerable<T>) s) : (ISet<T>) null;
  }

  private static SubjectPublicKeyInfo GetSubjectPublicKey(X509Certificate c)
  {
    return SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(c.GetPublicKey());
  }

  private static bool MatchExtension(byte[] b, X509Certificate c, DerObjectIdentifier oid)
  {
    if (b == null)
      return true;
    Asn1OctetString extensionValue = c.GetExtensionValue(oid);
    return extensionValue != null && Arrays.AreEqual(b, extensionValue.GetOctets());
  }
}
