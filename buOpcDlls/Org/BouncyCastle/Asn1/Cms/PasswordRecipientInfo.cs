// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.PasswordRecipientInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class PasswordRecipientInfo : Asn1Encodable
{
  private readonly DerInteger version;
  private readonly AlgorithmIdentifier keyDerivationAlgorithm;
  private readonly AlgorithmIdentifier keyEncryptionAlgorithm;
  private readonly Asn1OctetString encryptedKey;

  public PasswordRecipientInfo(
    AlgorithmIdentifier keyEncryptionAlgorithm,
    Asn1OctetString encryptedKey)
  {
    this.version = new DerInteger(0);
    this.keyEncryptionAlgorithm = keyEncryptionAlgorithm;
    this.encryptedKey = encryptedKey;
  }

  public PasswordRecipientInfo(
    AlgorithmIdentifier keyDerivationAlgorithm,
    AlgorithmIdentifier keyEncryptionAlgorithm,
    Asn1OctetString encryptedKey)
  {
    this.version = new DerInteger(0);
    this.keyDerivationAlgorithm = keyDerivationAlgorithm;
    this.keyEncryptionAlgorithm = keyEncryptionAlgorithm;
    this.encryptedKey = encryptedKey;
  }

  public PasswordRecipientInfo(Asn1Sequence seq)
  {
    this.version = (DerInteger) seq[0];
    if (seq[1] is Asn1TaggedObject asn1TaggedObject)
    {
      this.keyDerivationAlgorithm = AlgorithmIdentifier.GetInstance(asn1TaggedObject, false);
      this.keyEncryptionAlgorithm = AlgorithmIdentifier.GetInstance((object) seq[2]);
      this.encryptedKey = (Asn1OctetString) seq[3];
    }
    else
    {
      this.keyEncryptionAlgorithm = AlgorithmIdentifier.GetInstance((object) seq[1]);
      this.encryptedKey = (Asn1OctetString) seq[2];
    }
  }

  public static PasswordRecipientInfo GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return PasswordRecipientInfo.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static PasswordRecipientInfo GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case PasswordRecipientInfo _:
        return (PasswordRecipientInfo) obj;
      case Asn1Sequence _:
        return new PasswordRecipientInfo((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Invalid PasswordRecipientInfo: " + Platform.GetTypeName(obj));
    }
  }

  public DerInteger Version => this.version;

  public AlgorithmIdentifier KeyDerivationAlgorithm => this.keyDerivationAlgorithm;

  public AlgorithmIdentifier KeyEncryptionAlgorithm => this.keyEncryptionAlgorithm;

  public Asn1OctetString EncryptedKey => this.encryptedKey;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.version);
    elementVector.AddOptionalTagged(false, 0, (Asn1Encodable) this.keyDerivationAlgorithm);
    elementVector.Add((Asn1Encodable) this.keyEncryptionAlgorithm, (Asn1Encodable) this.encryptedKey);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
