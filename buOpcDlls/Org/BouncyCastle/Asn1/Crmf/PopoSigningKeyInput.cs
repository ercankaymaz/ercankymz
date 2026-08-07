// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Crmf.PopoSigningKeyInput
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Crmf;

public class PopoSigningKeyInput : Asn1Encodable
{
  private readonly GeneralName sender;
  private readonly PKMacValue publicKeyMac;
  private readonly SubjectPublicKeyInfo publicKey;

  private PopoSigningKeyInput(Asn1Sequence seq)
  {
    Asn1Encodable asn1Encodable = seq[0];
    if (asn1Encodable is Asn1TaggedObject)
    {
      Asn1TaggedObject asn1TaggedObject = (Asn1TaggedObject) asn1Encodable;
      this.sender = asn1TaggedObject.TagNo == 0 ? GeneralName.GetInstance((object) asn1TaggedObject.GetObject()) : throw new ArgumentException("Unknown authInfo tag: " + asn1TaggedObject.TagNo.ToString(), nameof (seq));
    }
    else
      this.publicKeyMac = PKMacValue.GetInstance((object) asn1Encodable);
    this.publicKey = SubjectPublicKeyInfo.GetInstance((object) seq[1]);
  }

  public static PopoSigningKeyInput GetInstance(object obj)
  {
    switch (obj)
    {
      case PopoSigningKeyInput _:
        return (PopoSigningKeyInput) obj;
      case Asn1Sequence _:
        return new PopoSigningKeyInput((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Invalid object: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public PopoSigningKeyInput(GeneralName sender, SubjectPublicKeyInfo spki)
  {
    this.sender = sender;
    this.publicKey = spki;
  }

  public PopoSigningKeyInput(PKMacValue pkmac, SubjectPublicKeyInfo spki)
  {
    this.publicKeyMac = pkmac;
    this.publicKey = spki;
  }

  public virtual GeneralName Sender => this.sender;

  public virtual PKMacValue PublicKeyMac => this.publicKeyMac;

  public virtual SubjectPublicKeyInfo PublicKey => this.publicKey;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(2);
    if (this.sender != null)
      elementVector.Add((Asn1Encodable) new DerTaggedObject(false, 0, (Asn1Encodable) this.sender));
    else
      elementVector.Add((Asn1Encodable) this.publicKeyMac);
    elementVector.Add((Asn1Encodable) this.publicKey);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
