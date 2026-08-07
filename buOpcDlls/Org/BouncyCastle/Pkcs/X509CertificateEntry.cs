// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pkcs.X509CertificateEntry
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.X509;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Pkcs;

public class X509CertificateEntry : Pkcs12Entry
{
  private readonly X509Certificate cert;

  public X509CertificateEntry(X509Certificate cert)
    : base((IDictionary<DerObjectIdentifier, Asn1Encodable>) new Dictionary<DerObjectIdentifier, Asn1Encodable>())
  {
    this.cert = cert;
  }

  public X509CertificateEntry(
    X509Certificate cert,
    IDictionary<DerObjectIdentifier, Asn1Encodable> attributes)
    : base(attributes)
  {
    this.cert = cert;
  }

  public X509Certificate Certificate => this.cert;

  public override bool Equals(object obj)
  {
    return obj is X509CertificateEntry certificateEntry && this.cert.Equals((object) certificateEntry.cert);
  }

  public override int GetHashCode() => ~this.cert.GetHashCode();
}
