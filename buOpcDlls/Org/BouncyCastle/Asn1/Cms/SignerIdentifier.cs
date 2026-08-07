// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.SignerIdentifier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class SignerIdentifier : Asn1Encodable, IAsn1Choice
{
  private Asn1Encodable id;

  public SignerIdentifier(IssuerAndSerialNumber id) => this.id = (Asn1Encodable) id;

  public SignerIdentifier(Asn1OctetString id)
  {
    this.id = (Asn1Encodable) new DerTaggedObject(false, 0, (Asn1Encodable) id);
  }

  public SignerIdentifier(Asn1Object id) => this.id = (Asn1Encodable) id;

  public static SignerIdentifier GetInstance(object o)
  {
    switch (o)
    {
      case null:
      case SignerIdentifier _:
        return (SignerIdentifier) o;
      case IssuerAndSerialNumber _:
        return new SignerIdentifier((IssuerAndSerialNumber) o);
      case Asn1OctetString _:
        return new SignerIdentifier((Asn1OctetString) o);
      case Asn1Object _:
        return new SignerIdentifier((Asn1Object) o);
      default:
        throw new ArgumentException("Illegal object in SignerIdentifier: " + Platform.GetTypeName(o));
    }
  }

  public bool IsTagged => this.id is Asn1TaggedObject;

  public Asn1Encodable ID
  {
    get
    {
      return this.id is Asn1TaggedObject ? (Asn1Encodable) Asn1OctetString.GetInstance((Asn1TaggedObject) this.id, false) : this.id;
    }
  }

  public override Asn1Object ToAsn1Object() => this.id.ToAsn1Object();
}
