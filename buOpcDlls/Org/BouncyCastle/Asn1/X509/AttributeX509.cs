// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.AttributeX509
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class AttributeX509 : Asn1Encodable
{
  private readonly DerObjectIdentifier attrType;
  private readonly Asn1Set attrValues;

  public static AttributeX509 GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case AttributeX509 _:
        return (AttributeX509) obj;
      case Asn1Sequence _:
        return new AttributeX509((Asn1Sequence) obj);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private AttributeX509(Asn1Sequence seq)
  {
    this.attrType = seq.Count == 2 ? DerObjectIdentifier.GetInstance((object) seq[0]) : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString());
    this.attrValues = Asn1Set.GetInstance((object) seq[1]);
  }

  public AttributeX509(DerObjectIdentifier attrType, Asn1Set attrValues)
  {
    this.attrType = attrType;
    this.attrValues = attrValues;
  }

  public DerObjectIdentifier AttrType => this.attrType;

  public Asn1Encodable[] GetAttributeValues() => this.attrValues.ToArray();

  public Asn1Set AttrValues => this.attrValues;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.attrType, (Asn1Encodable) this.attrValues);
  }
}
