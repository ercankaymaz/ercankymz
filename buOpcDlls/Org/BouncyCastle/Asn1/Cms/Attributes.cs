// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.Attributes
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class Attributes : Asn1Encodable
{
  private readonly Asn1Set attributes;

  private Attributes(Asn1Set attributes) => this.attributes = attributes;

  public Attributes(Asn1EncodableVector v) => this.attributes = (Asn1Set) new BerSet(v);

  public static Attributes GetInstance(object obj)
  {
    if (obj is Attributes)
      return (Attributes) obj;
    return obj != null ? new Attributes(Asn1Set.GetInstance(obj)) : (Attributes) null;
  }

  public virtual Attribute[] GetAttributes()
  {
    Attribute[] attributes = new Attribute[this.attributes.Count];
    for (int index = 0; index != attributes.Length; ++index)
      attributes[index] = Attribute.GetInstance((object) this.attributes[index]);
    return attributes;
  }

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.attributes;
}
