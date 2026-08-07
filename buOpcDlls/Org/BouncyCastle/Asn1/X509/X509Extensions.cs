// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.X509Extensions
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class X509Extensions : Asn1Encodable
{
  public static readonly DerObjectIdentifier SubjectDirectoryAttributes = new DerObjectIdentifier("2.5.29.9");
  public static readonly DerObjectIdentifier SubjectKeyIdentifier = new DerObjectIdentifier("2.5.29.14");
  public static readonly DerObjectIdentifier KeyUsage = new DerObjectIdentifier("2.5.29.15");
  public static readonly DerObjectIdentifier PrivateKeyUsagePeriod = new DerObjectIdentifier("2.5.29.16");
  public static readonly DerObjectIdentifier SubjectAlternativeName = new DerObjectIdentifier("2.5.29.17");
  public static readonly DerObjectIdentifier IssuerAlternativeName = new DerObjectIdentifier("2.5.29.18");
  public static readonly DerObjectIdentifier BasicConstraints = new DerObjectIdentifier("2.5.29.19");
  public static readonly DerObjectIdentifier CrlNumber = new DerObjectIdentifier("2.5.29.20");
  public static readonly DerObjectIdentifier ReasonCode = new DerObjectIdentifier("2.5.29.21");
  public static readonly DerObjectIdentifier InstructionCode = new DerObjectIdentifier("2.5.29.23");
  public static readonly DerObjectIdentifier InvalidityDate = new DerObjectIdentifier("2.5.29.24");
  public static readonly DerObjectIdentifier DeltaCrlIndicator = new DerObjectIdentifier("2.5.29.27");
  public static readonly DerObjectIdentifier IssuingDistributionPoint = new DerObjectIdentifier("2.5.29.28");
  public static readonly DerObjectIdentifier CertificateIssuer = new DerObjectIdentifier("2.5.29.29");
  public static readonly DerObjectIdentifier NameConstraints = new DerObjectIdentifier("2.5.29.30");
  public static readonly DerObjectIdentifier CrlDistributionPoints = new DerObjectIdentifier("2.5.29.31");
  public static readonly DerObjectIdentifier CertificatePolicies = new DerObjectIdentifier("2.5.29.32");
  public static readonly DerObjectIdentifier PolicyMappings = new DerObjectIdentifier("2.5.29.33");
  public static readonly DerObjectIdentifier AuthorityKeyIdentifier = new DerObjectIdentifier("2.5.29.35");
  public static readonly DerObjectIdentifier PolicyConstraints = new DerObjectIdentifier("2.5.29.36");
  public static readonly DerObjectIdentifier ExtendedKeyUsage = new DerObjectIdentifier("2.5.29.37");
  public static readonly DerObjectIdentifier FreshestCrl = new DerObjectIdentifier("2.5.29.46");
  public static readonly DerObjectIdentifier InhibitAnyPolicy = new DerObjectIdentifier("2.5.29.54");
  public static readonly DerObjectIdentifier AuthorityInfoAccess = new DerObjectIdentifier("1.3.6.1.5.5.7.1.1");
  public static readonly DerObjectIdentifier SubjectInfoAccess = new DerObjectIdentifier("1.3.6.1.5.5.7.1.11");
  public static readonly DerObjectIdentifier LogoType = new DerObjectIdentifier("1.3.6.1.5.5.7.1.12");
  public static readonly DerObjectIdentifier BiometricInfo = new DerObjectIdentifier("1.3.6.1.5.5.7.1.2");
  public static readonly DerObjectIdentifier QCStatements = new DerObjectIdentifier("1.3.6.1.5.5.7.1.3");
  public static readonly DerObjectIdentifier AuditIdentity = new DerObjectIdentifier("1.3.6.1.5.5.7.1.4");
  public static readonly DerObjectIdentifier NoRevAvail = new DerObjectIdentifier("2.5.29.56");
  public static readonly DerObjectIdentifier TargetInformation = new DerObjectIdentifier("2.5.29.55");
  public static readonly DerObjectIdentifier ExpiredCertsOnCrl = new DerObjectIdentifier("2.5.29.60");
  public static readonly DerObjectIdentifier SubjectAltPublicKeyInfo = new DerObjectIdentifier("2.5.29.72");
  public static readonly DerObjectIdentifier AltSignatureAlgorithm = new DerObjectIdentifier("2.5.29.73");
  public static readonly DerObjectIdentifier AltSignatureValue = new DerObjectIdentifier("2.5.29.74");
  private readonly Dictionary<DerObjectIdentifier, X509Extension> m_extensions = new Dictionary<DerObjectIdentifier, X509Extension>();
  private readonly List<DerObjectIdentifier> m_ordering;

  public static X509Extension GetExtension(X509Extensions extensions, DerObjectIdentifier oid)
  {
    return extensions?.GetExtension(oid);
  }

  public static Asn1Encodable GetExtensionParsedValue(
    X509Extensions extensions,
    DerObjectIdentifier oid)
  {
    return extensions?.GetExtensionParsedValue(oid);
  }

  public static X509Extensions GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return X509Extensions.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  public static X509Extensions GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case X509Extensions _:
        return (X509Extensions) obj;
      case Asn1Sequence _:
        return new X509Extensions((Asn1Sequence) obj);
      case Asn1TaggedObject _:
        return X509Extensions.GetInstance((object) ((Asn1TaggedObject) obj).GetObject());
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private X509Extensions(Asn1Sequence seq)
  {
    this.m_ordering = new List<DerObjectIdentifier>();
    foreach (Asn1Encodable asn1Encodable in seq)
    {
      Asn1Sequence instance1 = Asn1Sequence.GetInstance((object) asn1Encodable.ToAsn1Object());
      DerObjectIdentifier key = instance1.Count >= 2 && instance1.Count <= 3 ? DerObjectIdentifier.GetInstance((object) instance1[0].ToAsn1Object()) : throw new ArgumentException("Bad sequence size: " + instance1.Count.ToString());
      bool critical = instance1.Count == 3 && DerBoolean.GetInstance((object) instance1[1].ToAsn1Object()).IsTrue;
      Asn1OctetString instance2 = Asn1OctetString.GetInstance((object) instance1[instance1.Count - 1].ToAsn1Object());
      if (this.m_extensions.ContainsKey(key))
        throw new ArgumentException("repeated extension found: " + key?.ToString());
      this.m_extensions.Add(key, new X509Extension(critical, instance2));
      this.m_ordering.Add(key);
    }
  }

  public X509Extensions(
    IDictionary<DerObjectIdentifier, X509Extension> extensions)
    : this((IList<DerObjectIdentifier>) null, extensions)
  {
  }

  public X509Extensions(
    IList<DerObjectIdentifier> ordering,
    IDictionary<DerObjectIdentifier, X509Extension> extensions)
  {
    this.m_ordering = ordering != null ? new List<DerObjectIdentifier>((IEnumerable<DerObjectIdentifier>) ordering) : new List<DerObjectIdentifier>((IEnumerable<DerObjectIdentifier>) extensions.Keys);
    foreach (DerObjectIdentifier key in this.m_ordering)
      this.m_extensions.Add(key, extensions[key]);
  }

  public X509Extensions(IList<DerObjectIdentifier> oids, IList<X509Extension> values)
  {
    this.m_ordering = new List<DerObjectIdentifier>((IEnumerable<DerObjectIdentifier>) oids);
    int num = 0;
    foreach (DerObjectIdentifier key in this.m_ordering)
      this.m_extensions.Add(key, values[num++]);
  }

  public IEnumerable<DerObjectIdentifier> ExtensionOids
  {
    get
    {
      return CollectionUtilities.Proxy<DerObjectIdentifier>((IEnumerable<DerObjectIdentifier>) this.m_ordering);
    }
  }

  public X509Extension GetExtension(DerObjectIdentifier oid)
  {
    return CollectionUtilities.GetValueOrNull<DerObjectIdentifier, X509Extension>((IDictionary<DerObjectIdentifier, X509Extension>) this.m_extensions, oid);
  }

  public Asn1Encodable GetExtensionParsedValue(DerObjectIdentifier oid)
  {
    return this.GetExtension(oid)?.GetParsedValue();
  }

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(this.m_ordering.Count);
    foreach (DerObjectIdentifier objectIdentifier in this.m_ordering)
    {
      X509Extension extension = this.m_extensions[objectIdentifier];
      if (extension.IsCritical)
        elementVector.Add((Asn1Encodable) new DerSequence(new Asn1Encodable[3]
        {
          (Asn1Encodable) objectIdentifier,
          (Asn1Encodable) DerBoolean.True,
          (Asn1Encodable) extension.Value
        }));
      else
        elementVector.Add((Asn1Encodable) new DerSequence((Asn1Encodable) objectIdentifier, (Asn1Encodable) extension.Value));
    }
    return (Asn1Object) new DerSequence(elementVector);
  }

  public bool Equivalent(X509Extensions other)
  {
    if (this.m_extensions.Count != other.m_extensions.Count)
      return false;
    foreach (KeyValuePair<DerObjectIdentifier, X509Extension> extension in this.m_extensions)
    {
      if (!extension.Value.Equals((object) other.GetExtension(extension.Key)))
        return false;
    }
    return true;
  }

  public DerObjectIdentifier[] GetExtensionOids() => this.m_ordering.ToArray();

  public DerObjectIdentifier[] GetNonCriticalExtensionOids() => this.GetExtensionOids(false);

  public DerObjectIdentifier[] GetCriticalExtensionOids() => this.GetExtensionOids(true);

  private DerObjectIdentifier[] GetExtensionOids(bool isCritical)
  {
    List<DerObjectIdentifier> objectIdentifierList = new List<DerObjectIdentifier>();
    foreach (DerObjectIdentifier key in this.m_ordering)
    {
      if (this.m_extensions[key].IsCritical == isCritical)
        objectIdentifierList.Add(key);
    }
    return objectIdentifierList.ToArray();
  }
}
