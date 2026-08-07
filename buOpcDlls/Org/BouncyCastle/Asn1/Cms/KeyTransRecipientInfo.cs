// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.KeyTransRecipientInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class KeyTransRecipientInfo : Asn1Encodable
{
  private DerInteger version;
  private RecipientIdentifier rid;
  private AlgorithmIdentifier keyEncryptionAlgorithm;
  private Asn1OctetString encryptedKey;

  public KeyTransRecipientInfo(
    RecipientIdentifier rid,
    AlgorithmIdentifier keyEncryptionAlgorithm,
    Asn1OctetString encryptedKey)
  {
    this.version = !(rid.ToAsn1Object() is Asn1TaggedObject) ? new DerInteger(0) : new DerInteger(2);
    this.rid = rid;
    this.keyEncryptionAlgorithm = keyEncryptionAlgorithm;
    this.encryptedKey = encryptedKey;
  }

  public KeyTransRecipientInfo(Asn1Sequence seq)
  {
    this.version = (DerInteger) seq[0];
    this.rid = RecipientIdentifier.GetInstance((object) seq[1]);
    this.keyEncryptionAlgorithm = AlgorithmIdentifier.GetInstance((object) seq[2]);
    this.encryptedKey = (Asn1OctetString) seq[3];
  }

  public static KeyTransRecipientInfo GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case KeyTransRecipientInfo _:
        return (KeyTransRecipientInfo) obj;
      case Asn1Sequence _:
        return new KeyTransRecipientInfo((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Illegal object in KeyTransRecipientInfo: " + Platform.GetTypeName(obj));
    }
  }

  public DerInteger Version => this.version;

  public RecipientIdentifier RecipientIdentifier => this.rid;

  public AlgorithmIdentifier KeyEncryptionAlgorithm => this.keyEncryptionAlgorithm;

  public Asn1OctetString EncryptedKey => this.encryptedKey;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence(new Asn1Encodable[4]
    {
      (Asn1Encodable) this.version,
      (Asn1Encodable) this.rid,
      (Asn1Encodable) this.keyEncryptionAlgorithm,
      (Asn1Encodable) this.encryptedKey
    });
  }
}
