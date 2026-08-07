// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.OriginatorIdentifierOrKey
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class OriginatorIdentifierOrKey : Asn1Encodable, IAsn1Choice
{
  private readonly Asn1Encodable id;

  public OriginatorIdentifierOrKey(IssuerAndSerialNumber id) => this.id = (Asn1Encodable) id;

  public OriginatorIdentifierOrKey(SubjectKeyIdentifier id)
  {
    this.id = (Asn1Encodable) new DerTaggedObject(false, 0, (Asn1Encodable) id);
  }

  public OriginatorIdentifierOrKey(OriginatorPublicKey id)
  {
    this.id = (Asn1Encodable) new DerTaggedObject(false, 1, (Asn1Encodable) id);
  }

  private OriginatorIdentifierOrKey(Asn1TaggedObject id) => this.id = (Asn1Encodable) id;

  public static OriginatorIdentifierOrKey GetInstance(Asn1TaggedObject o, bool explicitly)
  {
    if (!explicitly)
      throw new ArgumentException("Can't implicitly tag OriginatorIdentifierOrKey");
    return OriginatorIdentifierOrKey.GetInstance((object) o.GetObject());
  }

  public static OriginatorIdentifierOrKey GetInstance(object o)
  {
    switch (o)
    {
      case null:
      case OriginatorIdentifierOrKey _:
        return (OriginatorIdentifierOrKey) o;
      case IssuerAndSerialNumber _:
        return new OriginatorIdentifierOrKey((IssuerAndSerialNumber) o);
      case SubjectKeyIdentifier _:
        return new OriginatorIdentifierOrKey((SubjectKeyIdentifier) o);
      case OriginatorPublicKey _:
        return new OriginatorIdentifierOrKey((OriginatorPublicKey) o);
      case Asn1TaggedObject _:
        return new OriginatorIdentifierOrKey((Asn1TaggedObject) o);
      default:
        throw new ArgumentException("Invalid OriginatorIdentifierOrKey: " + Platform.GetTypeName(o));
    }
  }

  public Asn1Encodable ID => this.id;

  public IssuerAndSerialNumber IssuerAndSerialNumber
  {
    get
    {
      return this.id is IssuerAndSerialNumber ? (IssuerAndSerialNumber) this.id : (IssuerAndSerialNumber) null;
    }
  }

  public SubjectKeyIdentifier SubjectKeyIdentifier
  {
    get
    {
      return this.id is Asn1TaggedObject && ((Asn1TaggedObject) this.id).TagNo == 0 ? SubjectKeyIdentifier.GetInstance((Asn1TaggedObject) this.id, false) : (SubjectKeyIdentifier) null;
    }
  }

  public OriginatorPublicKey OriginatorPublicKey
  {
    get
    {
      return this.id is Asn1TaggedObject && ((Asn1TaggedObject) this.id).TagNo == 1 ? OriginatorPublicKey.GetInstance((Asn1TaggedObject) this.id, false) : (OriginatorPublicKey) null;
    }
  }

  public override Asn1Object ToAsn1Object() => this.id.ToAsn1Object();
}
