// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Ocsp.Signature
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Ocsp;

public class Signature : Asn1Encodable
{
  internal AlgorithmIdentifier signatureAlgorithm;
  internal DerBitString signatureValue;
  internal Asn1Sequence certs;

  public static Signature GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return Signature.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static Signature GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case Signature _:
        return (Signature) obj;
      case Asn1Sequence _:
        return new Signature((Asn1Sequence) obj);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public Signature(AlgorithmIdentifier signatureAlgorithm, DerBitString signatureValue)
    : this(signatureAlgorithm, signatureValue, (Asn1Sequence) null)
  {
  }

  public Signature(
    AlgorithmIdentifier signatureAlgorithm,
    DerBitString signatureValue,
    Asn1Sequence certs)
  {
    if (signatureAlgorithm == null)
      throw new ArgumentException(nameof (signatureAlgorithm));
    if (signatureValue == null)
      throw new ArgumentException(nameof (signatureValue));
    this.signatureAlgorithm = signatureAlgorithm;
    this.signatureValue = signatureValue;
    this.certs = certs;
  }

  private Signature(Asn1Sequence seq)
  {
    this.signatureAlgorithm = AlgorithmIdentifier.GetInstance((object) seq[0]);
    this.signatureValue = (DerBitString) seq[1];
    if (seq.Count != 3)
      return;
    this.certs = Asn1Sequence.GetInstance((Asn1TaggedObject) seq[2], true);
  }

  public AlgorithmIdentifier SignatureAlgorithm => this.signatureAlgorithm;

  public DerBitString SignatureValue => this.signatureValue;

  public byte[] GetSignatureOctets() => this.signatureValue.GetOctets();

  public Asn1Sequence Certs => this.certs;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.signatureAlgorithm, (Asn1Encodable) this.signatureValue);
    elementVector.AddOptionalTagged(true, 0, (Asn1Encodable) this.certs);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
