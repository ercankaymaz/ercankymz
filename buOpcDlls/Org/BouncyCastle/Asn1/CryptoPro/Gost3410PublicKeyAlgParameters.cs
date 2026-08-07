// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.CryptoPro.Gost3410PublicKeyAlgParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.CryptoPro;

public class Gost3410PublicKeyAlgParameters : Asn1Encodable
{
  private DerObjectIdentifier publicKeyParamSet;
  private DerObjectIdentifier digestParamSet;
  private DerObjectIdentifier encryptionParamSet;

  public static Gost3410PublicKeyAlgParameters GetInstance(
    Asn1TaggedObject taggedObject,
    bool declaredExplicit)
  {
    return Gost3410PublicKeyAlgParameters.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  public static Gost3410PublicKeyAlgParameters GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case Gost3410PublicKeyAlgParameters _:
        return (Gost3410PublicKeyAlgParameters) obj;
      default:
        return new Gost3410PublicKeyAlgParameters(Asn1Sequence.GetInstance(obj));
    }
  }

  public Gost3410PublicKeyAlgParameters(
    DerObjectIdentifier publicKeyParamSet,
    DerObjectIdentifier digestParamSet)
    : this(publicKeyParamSet, digestParamSet, (DerObjectIdentifier) null)
  {
  }

  public Gost3410PublicKeyAlgParameters(
    DerObjectIdentifier publicKeyParamSet,
    DerObjectIdentifier digestParamSet,
    DerObjectIdentifier encryptionParamSet)
  {
    if (publicKeyParamSet == null)
      throw new ArgumentNullException(nameof (publicKeyParamSet));
    if (digestParamSet == null)
      throw new ArgumentNullException(nameof (digestParamSet));
    this.publicKeyParamSet = publicKeyParamSet;
    this.digestParamSet = digestParamSet;
    this.encryptionParamSet = encryptionParamSet;
  }

  private Gost3410PublicKeyAlgParameters(Asn1Sequence seq)
  {
    this.publicKeyParamSet = (DerObjectIdentifier) seq[0];
    this.digestParamSet = (DerObjectIdentifier) seq[1];
    if (seq.Count <= 2)
      return;
    this.encryptionParamSet = (DerObjectIdentifier) seq[2];
  }

  public DerObjectIdentifier PublicKeyParamSet => this.publicKeyParamSet;

  public DerObjectIdentifier DigestParamSet => this.digestParamSet;

  public DerObjectIdentifier EncryptionParamSet => this.encryptionParamSet;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.publicKeyParamSet, (Asn1Encodable) this.digestParamSet);
    elementVector.AddOptional((Asn1Encodable) this.encryptionParamSet);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
