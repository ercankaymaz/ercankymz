// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.RecipientIdentifier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class RecipientIdentifier : Asn1Encodable, IAsn1Choice
{
  private Asn1Encodable id;

  public RecipientIdentifier(IssuerAndSerialNumber id) => this.id = (Asn1Encodable) id;

  public RecipientIdentifier(Asn1OctetString id)
  {
    this.id = (Asn1Encodable) new DerTaggedObject(false, 0, (Asn1Encodable) id);
  }

  public RecipientIdentifier(Asn1Object id) => this.id = (Asn1Encodable) id;

  public static RecipientIdentifier GetInstance(object o)
  {
    switch (o)
    {
      case null:
      case RecipientIdentifier _:
        return (RecipientIdentifier) o;
      case IssuerAndSerialNumber _:
        return new RecipientIdentifier((IssuerAndSerialNumber) o);
      case Asn1OctetString _:
        return new RecipientIdentifier((Asn1OctetString) o);
      case Asn1Object _:
        return new RecipientIdentifier((Asn1Object) o);
      default:
        throw new ArgumentException("Illegal object in RecipientIdentifier: " + Platform.GetTypeName(o));
    }
  }

  public bool IsTagged => this.id is Asn1TaggedObject;

  public Asn1Encodable ID
  {
    get
    {
      return this.id is Asn1TaggedObject ? (Asn1Encodable) Asn1OctetString.GetInstance((Asn1TaggedObject) this.id, false) : (Asn1Encodable) IssuerAndSerialNumber.GetInstance((object) this.id);
    }
  }

  public override Asn1Object ToAsn1Object() => this.id.ToAsn1Object();
}
