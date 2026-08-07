// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Ess.EssCertID
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Ess;

public class EssCertID : Asn1Encodable
{
  private Asn1OctetString certHash;
  private IssuerSerial issuerSerial;

  public static EssCertID GetInstance(object o)
  {
    switch (o)
    {
      case null:
      case EssCertID _:
        return (EssCertID) o;
      case Asn1Sequence _:
        return new EssCertID((Asn1Sequence) o);
      default:
        throw new ArgumentException($"unknown object in 'EssCertID' factory : {Platform.GetTypeName(o)}.");
    }
  }

  public EssCertID(Asn1Sequence seq)
  {
    this.certHash = seq.Count >= 1 && seq.Count <= 2 ? Asn1OctetString.GetInstance((object) seq[0]) : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString());
    if (seq.Count <= 1)
      return;
    this.issuerSerial = IssuerSerial.GetInstance((object) seq[1]);
  }

  public EssCertID(byte[] hash) => this.certHash = (Asn1OctetString) new DerOctetString(hash);

  public EssCertID(byte[] hash, IssuerSerial issuerSerial)
  {
    this.certHash = (Asn1OctetString) new DerOctetString(hash);
    this.issuerSerial = issuerSerial;
  }

  public byte[] GetCertHash() => this.certHash.GetOctets();

  public IssuerSerial IssuerSerial => this.issuerSerial;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.certHash);
    elementVector.AddOptional((Asn1Encodable) this.issuerSerial);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
