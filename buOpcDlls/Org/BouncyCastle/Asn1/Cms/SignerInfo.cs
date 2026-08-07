// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.SignerInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class SignerInfo : Asn1Encodable
{
  private DerInteger version;
  private SignerIdentifier sid;
  private AlgorithmIdentifier digAlgorithm;
  private Asn1Set authenticatedAttributes;
  private AlgorithmIdentifier digEncryptionAlgorithm;
  private Asn1OctetString encryptedDigest;
  private Asn1Set unauthenticatedAttributes;

  public static SignerInfo GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case SignerInfo _:
        return (SignerInfo) obj;
      case Asn1Sequence _:
        return new SignerInfo((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public SignerInfo(
    SignerIdentifier sid,
    AlgorithmIdentifier digAlgorithm,
    Asn1Set authenticatedAttributes,
    AlgorithmIdentifier digEncryptionAlgorithm,
    Asn1OctetString encryptedDigest,
    Asn1Set unauthenticatedAttributes)
  {
    this.version = new DerInteger(sid.IsTagged ? 3 : 1);
    this.sid = sid;
    this.digAlgorithm = digAlgorithm;
    this.authenticatedAttributes = authenticatedAttributes;
    this.digEncryptionAlgorithm = digEncryptionAlgorithm;
    this.encryptedDigest = encryptedDigest;
    this.unauthenticatedAttributes = unauthenticatedAttributes;
  }

  public SignerInfo(
    SignerIdentifier sid,
    AlgorithmIdentifier digAlgorithm,
    Attributes authenticatedAttributes,
    AlgorithmIdentifier digEncryptionAlgorithm,
    Asn1OctetString encryptedDigest,
    Attributes unauthenticatedAttributes)
  {
    this.version = new DerInteger(sid.IsTagged ? 3 : 1);
    this.sid = sid;
    this.digAlgorithm = digAlgorithm;
    this.authenticatedAttributes = Asn1Set.GetInstance((object) authenticatedAttributes);
    this.digEncryptionAlgorithm = digEncryptionAlgorithm;
    this.encryptedDigest = encryptedDigest;
    this.unauthenticatedAttributes = Asn1Set.GetInstance((object) unauthenticatedAttributes);
  }

  private SignerInfo(Asn1Sequence seq)
  {
    IEnumerator<Asn1Encodable> enumerator = seq.GetEnumerator();
    enumerator.MoveNext();
    this.version = (DerInteger) enumerator.Current;
    enumerator.MoveNext();
    this.sid = SignerIdentifier.GetInstance((object) enumerator.Current.ToAsn1Object());
    enumerator.MoveNext();
    this.digAlgorithm = AlgorithmIdentifier.GetInstance((object) enumerator.Current.ToAsn1Object());
    enumerator.MoveNext();
    Asn1Object asn1Object = enumerator.Current.ToAsn1Object();
    if (asn1Object is Asn1TaggedObject taggedObject)
    {
      this.authenticatedAttributes = Asn1Set.GetInstance(taggedObject, false);
      enumerator.MoveNext();
      this.digEncryptionAlgorithm = AlgorithmIdentifier.GetInstance((object) enumerator.Current.ToAsn1Object());
    }
    else
    {
      this.authenticatedAttributes = (Asn1Set) null;
      this.digEncryptionAlgorithm = AlgorithmIdentifier.GetInstance((object) asn1Object);
    }
    enumerator.MoveNext();
    this.encryptedDigest = Asn1OctetString.GetInstance((object) enumerator.Current.ToAsn1Object());
    if (enumerator.MoveNext())
      this.unauthenticatedAttributes = Asn1Set.GetInstance((Asn1TaggedObject) enumerator.Current.ToAsn1Object(), false);
    else
      this.unauthenticatedAttributes = (Asn1Set) null;
  }

  public DerInteger Version => this.version;

  public SignerIdentifier SignerID => this.sid;

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
      (Asn1Encodable) this.sid,
      (Asn1Encodable) this.digAlgorithm
    });
    elementVector.AddOptionalTagged(false, 0, (Asn1Encodable) this.authenticatedAttributes);
    elementVector.Add((Asn1Encodable) this.digEncryptionAlgorithm, (Asn1Encodable) this.encryptedDigest);
    elementVector.AddOptionalTagged(false, 1, (Asn1Encodable) this.unauthenticatedAttributes);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
