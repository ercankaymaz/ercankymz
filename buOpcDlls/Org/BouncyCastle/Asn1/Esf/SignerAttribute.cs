// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Esf.SignerAttribute
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Esf;

public class SignerAttribute : Asn1Encodable
{
  private Asn1Sequence claimedAttributes;
  private AttributeCertificate certifiedAttributes;

  public static SignerAttribute GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case SignerAttribute _:
        return (SignerAttribute) obj;
      case Asn1Sequence _:
        return new SignerAttribute(obj);
      default:
        throw new ArgumentException("Unknown object in 'SignerAttribute' factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private SignerAttribute(object obj)
  {
    Asn1TaggedObject taggedObject = (Asn1TaggedObject) ((Asn1Sequence) obj)[0];
    if (taggedObject.TagNo == 0)
      this.claimedAttributes = Asn1Sequence.GetInstance(taggedObject, true);
    else
      this.certifiedAttributes = taggedObject.TagNo == 1 ? AttributeCertificate.GetInstance((object) taggedObject) : throw new ArgumentException("illegal tag.", nameof (obj));
  }

  public SignerAttribute(Asn1Sequence claimedAttributes)
  {
    this.claimedAttributes = claimedAttributes;
  }

  public SignerAttribute(AttributeCertificate certifiedAttributes)
  {
    this.certifiedAttributes = certifiedAttributes;
  }

  public virtual Asn1Sequence ClaimedAttributes => this.claimedAttributes;

  public virtual AttributeCertificate CertifiedAttributes => this.certifiedAttributes;

  public override Asn1Object ToAsn1Object()
  {
    return this.claimedAttributes == null ? (Asn1Object) new DerSequence((Asn1Encodable) new DerTaggedObject(1, (Asn1Encodable) this.certifiedAttributes)) : (Asn1Object) new DerSequence((Asn1Encodable) new DerTaggedObject(0, (Asn1Encodable) this.claimedAttributes));
  }
}
