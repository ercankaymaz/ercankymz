// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.KekRecipientInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class KekRecipientInfo : Asn1Encodable
{
  private DerInteger version;
  private KekIdentifier kekID;
  private AlgorithmIdentifier keyEncryptionAlgorithm;
  private Asn1OctetString encryptedKey;

  public KekRecipientInfo(
    KekIdentifier kekID,
    AlgorithmIdentifier keyEncryptionAlgorithm,
    Asn1OctetString encryptedKey)
  {
    this.version = new DerInteger(4);
    this.kekID = kekID;
    this.keyEncryptionAlgorithm = keyEncryptionAlgorithm;
    this.encryptedKey = encryptedKey;
  }

  public KekRecipientInfo(Asn1Sequence seq)
  {
    this.version = (DerInteger) seq[0];
    this.kekID = KekIdentifier.GetInstance((object) seq[1]);
    this.keyEncryptionAlgorithm = AlgorithmIdentifier.GetInstance((object) seq[2]);
    this.encryptedKey = (Asn1OctetString) seq[3];
  }

  public static KekRecipientInfo GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return KekRecipientInfo.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static KekRecipientInfo GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case KekRecipientInfo _:
        return (KekRecipientInfo) obj;
      case Asn1Sequence _:
        return new KekRecipientInfo((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Invalid KekRecipientInfo: " + Platform.GetTypeName(obj));
    }
  }

  public DerInteger Version => this.version;

  public KekIdentifier KekID => this.kekID;

  public AlgorithmIdentifier KeyEncryptionAlgorithm => this.keyEncryptionAlgorithm;

  public Asn1OctetString EncryptedKey => this.encryptedKey;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence(new Asn1Encodable[4]
    {
      (Asn1Encodable) this.version,
      (Asn1Encodable) this.kekID,
      (Asn1Encodable) this.keyEncryptionAlgorithm,
      (Asn1Encodable) this.encryptedKey
    });
  }
}
