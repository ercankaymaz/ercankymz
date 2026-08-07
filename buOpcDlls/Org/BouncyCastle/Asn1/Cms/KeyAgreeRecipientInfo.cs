// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.KeyAgreeRecipientInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class KeyAgreeRecipientInfo : Asn1Encodable
{
  private DerInteger version;
  private OriginatorIdentifierOrKey originator;
  private Asn1OctetString ukm;
  private AlgorithmIdentifier keyEncryptionAlgorithm;
  private Asn1Sequence recipientEncryptedKeys;

  public KeyAgreeRecipientInfo(
    OriginatorIdentifierOrKey originator,
    Asn1OctetString ukm,
    AlgorithmIdentifier keyEncryptionAlgorithm,
    Asn1Sequence recipientEncryptedKeys)
  {
    this.version = new DerInteger(3);
    this.originator = originator;
    this.ukm = ukm;
    this.keyEncryptionAlgorithm = keyEncryptionAlgorithm;
    this.recipientEncryptedKeys = recipientEncryptedKeys;
  }

  public KeyAgreeRecipientInfo(Asn1Sequence seq)
  {
    int num1 = 0;
    Asn1Sequence asn1Sequence1 = seq;
    num1 = 1;
    this.version = (DerInteger) asn1Sequence1[0];
    Asn1Sequence asn1Sequence2 = seq;
    int num2 = 2;
    this.originator = OriginatorIdentifierOrKey.GetInstance((Asn1TaggedObject) asn1Sequence2[1], true);
    if (seq[2] is Asn1TaggedObject taggedObject)
    {
      this.ukm = Asn1OctetString.GetInstance(taggedObject, true);
      ++num2;
    }
    Asn1Sequence asn1Sequence3 = seq;
    int index1 = num2;
    int num3 = index1 + 1;
    this.keyEncryptionAlgorithm = AlgorithmIdentifier.GetInstance((object) asn1Sequence3[index1]);
    Asn1Sequence asn1Sequence4 = seq;
    int index2 = num3;
    num1 = index2 + 1;
    this.recipientEncryptedKeys = (Asn1Sequence) asn1Sequence4[index2];
  }

  public static KeyAgreeRecipientInfo GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return KeyAgreeRecipientInfo.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static KeyAgreeRecipientInfo GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case KeyAgreeRecipientInfo _:
        return (KeyAgreeRecipientInfo) obj;
      case Asn1Sequence _:
        return new KeyAgreeRecipientInfo((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Illegal object in KeyAgreeRecipientInfo: " + Platform.GetTypeName(obj));
    }
  }

  public DerInteger Version => this.version;

  public OriginatorIdentifierOrKey Originator => this.originator;

  public Asn1OctetString UserKeyingMaterial => this.ukm;

  public AlgorithmIdentifier KeyEncryptionAlgorithm => this.keyEncryptionAlgorithm;

  public Asn1Sequence RecipientEncryptedKeys => this.recipientEncryptedKeys;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.version, (Asn1Encodable) new DerTaggedObject(true, 0, (Asn1Encodable) this.originator));
    elementVector.AddOptionalTagged(true, 1, (Asn1Encodable) this.ukm);
    elementVector.Add((Asn1Encodable) this.keyEncryptionAlgorithm, (Asn1Encodable) this.recipientEncryptedKeys);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
