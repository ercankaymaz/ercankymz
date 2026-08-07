// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Pkcs.SignerInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.Pkcs;

public class SignerInfo : Asn1Encodable
{
  private DerInteger version;
  private IssuerAndSerialNumber issuerAndSerialNumber;
  private AlgorithmIdentifier digAlgorithm;
  private Asn1Set authenticatedAttributes;
  private AlgorithmIdentifier digEncryptionAlgorithm;
  private Asn1OctetString encryptedDigest;
  private Asn1Set unauthenticatedAttributes;

  public static SignerInfo GetInstance(object obj)
  {
    if (obj == null)
      return (SignerInfo) null;
    return obj is SignerInfo signerInfo ? signerInfo : new SignerInfo(Asn1Sequence.GetInstance(obj));
  }

  public SignerInfo(
    DerInteger version,
    IssuerAndSerialNumber issuerAndSerialNumber,
    AlgorithmIdentifier digAlgorithm,
    Asn1Set authenticatedAttributes,
    AlgorithmIdentifier digEncryptionAlgorithm,
    Asn1OctetString encryptedDigest,
    Asn1Set unauthenticatedAttributes)
  {
    this.version = version;
    this.issuerAndSerialNumber = issuerAndSerialNumber;
    this.digAlgorithm = digAlgorithm;
    this.authenticatedAttributes = authenticatedAttributes;
    this.digEncryptionAlgorithm = digEncryptionAlgorithm;
    this.encryptedDigest = encryptedDigest;
    this.unauthenticatedAttributes = unauthenticatedAttributes;
  }

  public SignerInfo(Asn1Sequence seq)
  {
    IEnumerator<Asn1Encodable> enumerator = seq.GetEnumerator();
    enumerator.MoveNext();
    this.version = (DerInteger) enumerator.Current;
    enumerator.MoveNext();
    this.issuerAndSerialNumber = IssuerAndSerialNumber.GetInstance((object) enumerator.Current);
    enumerator.MoveNext();
    this.digAlgorithm = AlgorithmIdentifier.GetInstance((object) enumerator.Current);
    enumerator.MoveNext();
    Asn1Encodable current = enumerator.Current;
    if (current is Asn1TaggedObject taggedObject)
    {
      this.authenticatedAttributes = Asn1Set.GetInstance(taggedObject, false);
      enumerator.MoveNext();
      this.digEncryptionAlgorithm = AlgorithmIdentifier.GetInstance((object) enumerator.Current);
    }
    else
    {
      this.authenticatedAttributes = (Asn1Set) null;
      this.digEncryptionAlgorithm = AlgorithmIdentifier.GetInstance((object) current);
    }
    enumerator.MoveNext();
    this.encryptedDigest = Asn1OctetString.GetInstance((object) enumerator.Current);
    if (enumerator.MoveNext())
      this.unauthenticatedAttributes = Asn1Set.GetInstance((Asn1TaggedObject) enumerator.Current, false);
    else
      this.unauthenticatedAttributes = (Asn1Set) null;
  }

  public DerInteger Version => this.version;

  public IssuerAndSerialNumber IssuerAndSerialNumber => this.issuerAndSerialNumber;

  public Asn1Set AuthenticatedAttributes => this.authenticatedAttributes;

  public AlgorithmIdentifier DigestAlgorithm => this.digAlgorithm;

  public Asn1OctetString EncryptedDigest => this.encryptedDigest;

  public AlgorithmIdentifier DigestEncryptionAlgorithm => this.digEncryptionAlgorithm;

  public Asn1Set UnauthenticatedAttributes => this.unauthenticatedAttributes;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(new Asn1Encodable[3]
    {
      (Asn1Encodable) this.version,
      (Asn1Encodable) this.issuerAndSerialNumber,
      (Asn1Encodable) this.digAlgorithm
    });
    elementVector.AddOptionalTagged(false, 0, (Asn1Encodable) this.authenticatedAttributes);
    elementVector.Add((Asn1Encodable) this.digEncryptionAlgorithm, (Asn1Encodable) this.encryptedDigest);
    elementVector.AddOptionalTagged(false, 1, (Asn1Encodable) this.unauthenticatedAttributes);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
