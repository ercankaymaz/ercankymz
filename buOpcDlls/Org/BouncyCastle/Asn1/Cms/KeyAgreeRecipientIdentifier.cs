// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.KeyAgreeRecipientIdentifier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class KeyAgreeRecipientIdentifier : Asn1Encodable, IAsn1Choice
{
  private readonly IssuerAndSerialNumber issuerSerial;
  private readonly RecipientKeyIdentifier rKeyID;

  public static KeyAgreeRecipientIdentifier GetInstance(Asn1TaggedObject obj, bool isExplicit)
  {
    return KeyAgreeRecipientIdentifier.GetInstance((object) Asn1Sequence.GetInstance(obj, isExplicit));
  }

  public static KeyAgreeRecipientIdentifier GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case KeyAgreeRecipientIdentifier _:
        return (KeyAgreeRecipientIdentifier) obj;
      case Asn1Sequence _:
        return new KeyAgreeRecipientIdentifier(IssuerAndSerialNumber.GetInstance(obj));
      case Asn1TaggedObject _:
        if (((Asn1TaggedObject) obj).TagNo == 0)
          return new KeyAgreeRecipientIdentifier(RecipientKeyIdentifier.GetInstance((Asn1TaggedObject) obj, false));
        break;
    }
    throw new ArgumentException("Invalid KeyAgreeRecipientIdentifier: " + Platform.GetTypeName(obj), nameof (obj));
  }

  public KeyAgreeRecipientIdentifier(IssuerAndSerialNumber issuerSerial)
  {
    this.issuerSerial = issuerSerial;
  }

  public KeyAgreeRecipientIdentifier(RecipientKeyIdentifier rKeyID) => this.rKeyID = rKeyID;

  public IssuerAndSerialNumber IssuerAndSerialNumber => this.issuerSerial;

  public RecipientKeyIdentifier RKeyID => this.rKeyID;

  public override Asn1Object ToAsn1Object()
  {
    return this.issuerSerial != null ? this.issuerSerial.ToAsn1Object() : (Asn1Object) new DerTaggedObject(false, 0, (Asn1Encodable) this.rKeyID);
  }
}
