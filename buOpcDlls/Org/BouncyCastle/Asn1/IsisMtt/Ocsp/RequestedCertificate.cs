// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.IsisMtt.Ocsp.RequestedCertificate
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1.IsisMtt.Ocsp;

public class RequestedCertificate : Asn1Encodable, IAsn1Choice
{
  private readonly X509CertificateStructure cert;
  private readonly byte[] publicKeyCert;
  private readonly byte[] attributeCert;

  public static RequestedCertificate GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case RequestedCertificate _:
        return (RequestedCertificate) obj;
      case Asn1Sequence _:
        return new RequestedCertificate(X509CertificateStructure.GetInstance(obj));
      case Asn1TaggedObject _:
        return new RequestedCertificate((Asn1TaggedObject) obj);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public static RequestedCertificate GetInstance(Asn1TaggedObject obj, bool isExplicit)
  {
    if (!isExplicit)
      throw new ArgumentException("choice item must be explicitly tagged");
    return RequestedCertificate.GetInstance((object) obj.GetObject());
  }

  private RequestedCertificate(Asn1TaggedObject tagged)
  {
    switch ((RequestedCertificate.Choice) tagged.TagNo)
    {
      case RequestedCertificate.Choice.PublicKeyCertificate:
        this.publicKeyCert = Asn1OctetString.GetInstance(tagged, true).GetOctets();
        break;
      case RequestedCertificate.Choice.AttributeCertificate:
        this.attributeCert = Asn1OctetString.GetInstance(tagged, true).GetOctets();
        break;
      default:
        throw new ArgumentException("unknown tag number: " + tagged.TagNo.ToString());
    }
  }

  public RequestedCertificate(X509CertificateStructure certificate) => this.cert = certificate;

  public RequestedCertificate(RequestedCertificate.Choice type, byte[] certificateOctets)
    : this((Asn1TaggedObject) new DerTaggedObject((int) type, (Asn1Encodable) new DerOctetString(certificateOctets)))
  {
  }

  public RequestedCertificate.Choice Type
  {
    get
    {
      if (this.cert != null)
        return RequestedCertificate.Choice.Certificate;
      return this.publicKeyCert != null ? RequestedCertificate.Choice.PublicKeyCertificate : RequestedCertificate.Choice.AttributeCertificate;
    }
  }

  public byte[] GetCertificateBytes()
  {
    if (this.cert != null)
    {
      try
      {
        return this.cert.GetEncoded();
      }
      catch (IOException ex)
      {
        throw new InvalidOperationException("can't decode certificate: " + ex?.ToString());
      }
    }
    else
      return this.publicKeyCert != null ? this.publicKeyCert : this.attributeCert;
  }

  public override Asn1Object ToAsn1Object()
  {
    if (this.publicKeyCert != null)
      return (Asn1Object) new DerTaggedObject(0, (Asn1Encodable) new DerOctetString(this.publicKeyCert));
    return this.attributeCert != null ? (Asn1Object) new DerTaggedObject(1, (Asn1Encodable) new DerOctetString(this.attributeCert)) : this.cert.ToAsn1Object();
  }

  public enum Choice
  {
    Certificate = -1, // 0xFFFFFFFF
    PublicKeyCertificate = 0,
    AttributeCertificate = 1,
  }
}
