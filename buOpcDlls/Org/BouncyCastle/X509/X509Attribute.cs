// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.X509.X509Attribute
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;

#nullable disable
namespace Org.BouncyCastle.X509;

public class X509Attribute : Asn1Encodable
{
  private readonly AttributeX509 attr;

  internal X509Attribute(Asn1Encodable at) => this.attr = AttributeX509.GetInstance((object) at);

  public X509Attribute(string oid, Asn1Encodable value)
  {
    this.attr = new AttributeX509(new DerObjectIdentifier(oid), (Asn1Set) new DerSet(value));
  }

  public X509Attribute(string oid, Asn1EncodableVector value)
  {
    this.attr = new AttributeX509(new DerObjectIdentifier(oid), (Asn1Set) new DerSet(value));
  }

  public string Oid => this.attr.AttrType.Id;

  public Asn1Encodable[] GetValues()
  {
    Asn1Set attrValues = this.attr.AttrValues;
    Asn1Encodable[] values = new Asn1Encodable[attrValues.Count];
    for (int index = 0; index != attrValues.Count; ++index)
      values[index] = attrValues[index];
    return values;
  }

  public override Asn1Object ToAsn1Object() => this.attr.ToAsn1Object();
}
