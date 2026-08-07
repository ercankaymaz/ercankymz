// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.RecipientEncryptedKey
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class RecipientEncryptedKey : Asn1Encodable
{
  private readonly KeyAgreeRecipientIdentifier identifier;
  private readonly Asn1OctetString encryptedKey;

  private RecipientEncryptedKey(Asn1Sequence seq)
  {
    this.identifier = KeyAgreeRecipientIdentifier.GetInstance((object) seq[0]);
    this.encryptedKey = (Asn1OctetString) seq[1];
  }

  public static RecipientEncryptedKey GetInstance(Asn1TaggedObject obj, bool isExplicit)
  {
    return RecipientEncryptedKey.GetInstance((object) Asn1Sequence.GetInstance(obj, isExplicit));
  }

  public static RecipientEncryptedKey GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case RecipientEncryptedKey _:
        return (RecipientEncryptedKey) obj;
      case Asn1Sequence _:
        return new RecipientEncryptedKey((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Invalid RecipientEncryptedKey: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public RecipientEncryptedKey(KeyAgreeRecipientIdentifier id, Asn1OctetString encryptedKey)
  {
    this.identifier = id;
    this.encryptedKey = encryptedKey;
  }

  public KeyAgreeRecipientIdentifier Identifier => this.identifier;

  public Asn1OctetString EncryptedKey => this.encryptedKey;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.identifier, (Asn1Encodable) this.encryptedKey);
  }
}
