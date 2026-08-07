// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Crmf.Controls
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Crmf;

public class Controls : Asn1Encodable
{
  private readonly Asn1Sequence content;

  private Controls(Asn1Sequence seq) => this.content = seq;

  public static Controls GetInstance(object obj)
  {
    switch (obj)
    {
      case Controls _:
        return (Controls) obj;
      case Asn1Sequence _:
        return new Controls((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Invalid object: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public Controls(params AttributeTypeAndValue[] atvs)
  {
    this.content = (Asn1Sequence) new DerSequence((Asn1Encodable[]) atvs);
  }

  public virtual AttributeTypeAndValue[] ToAttributeTypeAndValueArray()
  {
    AttributeTypeAndValue[] typeAndValueArray = new AttributeTypeAndValue[this.content.Count];
    for (int index = 0; index != typeAndValueArray.Length; ++index)
      typeAndValueArray[index] = AttributeTypeAndValue.GetInstance((object) this.content[index]);
    return typeAndValueArray;
  }

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.content;
}
