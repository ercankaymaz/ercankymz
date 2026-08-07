// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Ocsp.ResponderID
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Ocsp;

public class ResponderID : Asn1Encodable, IAsn1Choice
{
  private readonly Asn1Encodable id;

  public static ResponderID GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case ResponderID _:
        return (ResponderID) obj;
      case Asn1OctetString id:
        return new ResponderID(id);
      case Asn1TaggedObject taggedObject:
        return taggedObject.TagNo == 1 ? new ResponderID(X509Name.GetInstance(taggedObject, true)) : new ResponderID(Asn1OctetString.GetInstance(taggedObject, true));
      default:
        return new ResponderID(X509Name.GetInstance(obj));
    }
  }

  public ResponderID(Asn1OctetString id)
  {
    this.id = id != null ? (Asn1Encodable) id : throw new ArgumentNullException(nameof (id));
  }

  public ResponderID(X509Name id)
  {
    this.id = id != null ? (Asn1Encodable) id : throw new ArgumentNullException(nameof (id));
  }

  public static ResponderID GetInstance(Asn1TaggedObject obj, bool isExplicit)
  {
    return ResponderID.GetInstance((object) obj.GetObject());
  }

  public virtual byte[] GetKeyHash()
  {
    return this.id is Asn1OctetString ? ((Asn1OctetString) this.id).GetOctets() : (byte[]) null;
  }

  public virtual X509Name Name
  {
    get => this.id is Asn1OctetString ? (X509Name) null : X509Name.GetInstance((object) this.id);
  }

  public override Asn1Object ToAsn1Object()
  {
    return this.id is Asn1OctetString ? (Asn1Object) new DerTaggedObject(true, 2, this.id) : (Asn1Object) new DerTaggedObject(true, 1, this.id);
  }
}
