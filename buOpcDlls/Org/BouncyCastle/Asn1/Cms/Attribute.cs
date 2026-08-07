// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.Attribute
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class Attribute : Asn1Encodable
{
  private DerObjectIdentifier attrType;
  private Asn1Set attrValues;

  public static Attribute GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case Attribute _:
        return (Attribute) obj;
      case Asn1Sequence _:
        return new Attribute((Asn1Sequence) obj);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public Attribute(Asn1Sequence seq)
  {
    this.attrType = (DerObjectIdentifier) seq[0];
    this.attrValues = (Asn1Set) seq[1];
  }

  public Attribute(DerObjectIdentifier attrType, Asn1Set attrValues)
  {
    this.attrType = attrType;
    this.attrValues = attrValues;
  }

  public DerObjectIdentifier AttrType => this.attrType;

  public Asn1Set AttrValues => this.attrValues;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.attrType, (Asn1Encodable) this.attrValues);
  }
}
