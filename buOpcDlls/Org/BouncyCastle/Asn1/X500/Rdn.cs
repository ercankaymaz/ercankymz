// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X500.Rdn
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.X500;

public class Rdn : Asn1Encodable
{
  private readonly Asn1Set values;

  private Rdn(Asn1Set values) => this.values = values;

  public static Rdn GetInstance(object obj)
  {
    if (obj is Rdn)
      return (Rdn) obj;
    return obj != null ? new Rdn(Asn1Set.GetInstance(obj)) : (Rdn) null;
  }

  public Rdn(DerObjectIdentifier oid, Asn1Encodable value)
  {
    this.values = (Asn1Set) new DerSet((Asn1Encodable) new DerSequence((Asn1Encodable) oid, value));
  }

  public Rdn(AttributeTypeAndValue attrTAndV)
  {
    this.values = (Asn1Set) new DerSet((Asn1Encodable) attrTAndV);
  }

  public Rdn(AttributeTypeAndValue[] aAndVs)
  {
    this.values = (Asn1Set) new DerSet((Asn1Encodable[]) aAndVs);
  }

  public virtual bool IsMultiValued => this.values.Count > 1;

  public virtual int Count => this.values.Count;

  public virtual AttributeTypeAndValue GetFirst()
  {
    return this.values.Count == 0 ? (AttributeTypeAndValue) null : AttributeTypeAndValue.GetInstance((object) this.values[0]);
  }

  public virtual AttributeTypeAndValue[] GetTypesAndValues()
  {
    AttributeTypeAndValue[] typesAndValues = new AttributeTypeAndValue[this.values.Count];
    for (int index = 0; index < typesAndValues.Length; ++index)
      typesAndValues[index] = AttributeTypeAndValue.GetInstance((object) this.values[index]);
    return typesAndValues;
  }

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.values;
}
