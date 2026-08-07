// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.OtherKeyAttribute
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class OtherKeyAttribute : Asn1Encodable
{
  private DerObjectIdentifier keyAttrId;
  private Asn1Encodable keyAttr;

  public static OtherKeyAttribute GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case OtherKeyAttribute _:
        return (OtherKeyAttribute) obj;
      case Asn1Sequence _:
        return new OtherKeyAttribute((Asn1Sequence) obj);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public OtherKeyAttribute(Asn1Sequence seq)
  {
    this.keyAttrId = (DerObjectIdentifier) seq[0];
    this.keyAttr = seq[1];
  }

  public OtherKeyAttribute(DerObjectIdentifier keyAttrId, Asn1Encodable keyAttr)
  {
    this.keyAttrId = keyAttrId;
    this.keyAttr = keyAttr;
  }

  public DerObjectIdentifier KeyAttrId => this.keyAttrId;

  public Asn1Encodable KeyAttr => this.keyAttr;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.keyAttrId, this.keyAttr);
  }
}
