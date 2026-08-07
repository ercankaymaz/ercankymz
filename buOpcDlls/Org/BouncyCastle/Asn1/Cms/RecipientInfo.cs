// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.RecipientInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class RecipientInfo : Asn1Encodable, IAsn1Choice
{
  internal Asn1Encodable info;

  public RecipientInfo(KeyTransRecipientInfo info) => this.info = (Asn1Encodable) info;

  public RecipientInfo(KeyAgreeRecipientInfo info)
  {
    this.info = (Asn1Encodable) new DerTaggedObject(false, 1, (Asn1Encodable) info);
  }

  public RecipientInfo(KekRecipientInfo info)
  {
    this.info = (Asn1Encodable) new DerTaggedObject(false, 2, (Asn1Encodable) info);
  }

  public RecipientInfo(PasswordRecipientInfo info)
  {
    this.info = (Asn1Encodable) new DerTaggedObject(false, 3, (Asn1Encodable) info);
  }

  public RecipientInfo(OtherRecipientInfo info)
  {
    this.info = (Asn1Encodable) new DerTaggedObject(false, 4, (Asn1Encodable) info);
  }

  public RecipientInfo(Asn1Object info) => this.info = (Asn1Encodable) info;

  public static RecipientInfo GetInstance(object o)
  {
    switch (o)
    {
      case null:
      case RecipientInfo _:
        return (RecipientInfo) o;
      case Asn1Sequence _:
        return new RecipientInfo((Asn1Object) o);
      case Asn1TaggedObject _:
        return new RecipientInfo((Asn1Object) o);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(o));
    }
  }

  public DerInteger Version
  {
    get
    {
      if (!(this.info is Asn1TaggedObject))
        return KeyTransRecipientInfo.GetInstance((object) this.info).Version;
      Asn1TaggedObject info = (Asn1TaggedObject) this.info;
      switch (info.TagNo)
      {
        case 1:
          return KeyAgreeRecipientInfo.GetInstance(info, false).Version;
        case 2:
          return this.GetKekInfo(info).Version;
        case 3:
          return PasswordRecipientInfo.GetInstance(info, false).Version;
        case 4:
          return new DerInteger(0);
        default:
          throw new InvalidOperationException("unknown tag");
      }
    }
  }

  public bool IsTagged => this.info is Asn1TaggedObject;

  public Asn1Encodable Info
  {
    get
    {
      if (!(this.info is Asn1TaggedObject))
        return (Asn1Encodable) KeyTransRecipientInfo.GetInstance((object) this.info);
      Asn1TaggedObject info = (Asn1TaggedObject) this.info;
      switch (info.TagNo)
      {
        case 1:
          return (Asn1Encodable) KeyAgreeRecipientInfo.GetInstance(info, false);
        case 2:
          return (Asn1Encodable) this.GetKekInfo(info);
        case 3:
          return (Asn1Encodable) PasswordRecipientInfo.GetInstance(info, false);
        case 4:
          return (Asn1Encodable) OtherRecipientInfo.GetInstance(info, false);
        default:
          throw new InvalidOperationException("unknown tag");
      }
    }
  }

  private KekRecipientInfo GetKekInfo(Asn1TaggedObject o)
  {
    return KekRecipientInfo.GetInstance(o, o.IsExplicit());
  }

  public override Asn1Object ToAsn1Object() => this.info.ToAsn1Object();
}
