// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.X509ExtensionsGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class X509ExtensionsGenerator
{
  private Dictionary<DerObjectIdentifier, X509Extension> m_extensions = new Dictionary<DerObjectIdentifier, X509Extension>();
  private List<DerObjectIdentifier> m_ordering = new List<DerObjectIdentifier>();
  private static readonly HashSet<DerObjectIdentifier> m_dupsAllowed = new HashSet<DerObjectIdentifier>()
  {
    X509Extensions.SubjectAlternativeName,
    X509Extensions.IssuerAlternativeName,
    X509Extensions.SubjectDirectoryAttributes,
    X509Extensions.CertificateIssuer
  };

  public void Reset()
  {
    this.m_extensions = new Dictionary<DerObjectIdentifier, X509Extension>();
    this.m_ordering = new List<DerObjectIdentifier>();
  }

  public void AddExtension(DerObjectIdentifier oid, bool critical, Asn1Encodable extValue)
  {
    byte[] derEncoded;
    try
    {
      derEncoded = extValue.GetDerEncoded();
    }
    catch (Exception ex)
    {
      throw new ArgumentException("error encoding value: " + ex?.ToString());
    }
    this.AddExtension(oid, critical, derEncoded);
  }

  public void AddExtension(DerObjectIdentifier oid, bool critical, byte[] extValue)
  {
    X509Extension x509Extension;
    if (this.m_extensions.TryGetValue(oid, out x509Extension))
    {
      if (!X509ExtensionsGenerator.m_dupsAllowed.Contains(oid))
        throw new ArgumentException($"extension {oid?.ToString()} already added");
      Asn1EncodableVector elementVector = Asn1EncodableVector.FromEnumerable((IEnumerable<Asn1Encodable>) Asn1Sequence.GetInstance((object) Asn1OctetString.GetInstance((object) x509Extension.Value).GetOctets()));
      foreach (Asn1Encodable element in Asn1Sequence.GetInstance((object) extValue))
        elementVector.Add(element);
      this.m_extensions[oid] = new X509Extension(x509Extension.IsCritical, (Asn1OctetString) new DerOctetString(new DerSequence(elementVector).GetEncoded()));
    }
    else
    {
      this.m_ordering.Add(oid);
      this.m_extensions.Add(oid, new X509Extension(critical, (Asn1OctetString) new DerOctetString(extValue)));
    }
  }

  public void AddExtensions(X509Extensions extensions)
  {
    foreach (DerObjectIdentifier extensionOid in extensions.ExtensionOids)
    {
      X509Extension extension = extensions.GetExtension(extensionOid);
      this.AddExtension(extensionOid, extension.critical, extension.Value.GetOctets());
    }
  }

  public bool IsEmpty => this.m_ordering.Count < 1;

  public X509Extensions Generate()
  {
    return new X509Extensions((IList<DerObjectIdentifier>) this.m_ordering, (IDictionary<DerObjectIdentifier, X509Extension>) this.m_extensions);
  }

  internal void AddExtension(DerObjectIdentifier oid, X509Extension x509Extension)
  {
    if (this.m_extensions.ContainsKey(oid))
      throw new ArgumentException($"extension {oid?.ToString()} already added");
    this.m_ordering.Add(oid);
    this.m_extensions.Add(oid, x509Extension);
  }
}
