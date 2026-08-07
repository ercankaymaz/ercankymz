// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.OtherName
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class OtherName : Asn1Encodable
{
  private readonly DerObjectIdentifier typeID;
  private readonly Asn1Encodable value;

  public static OtherName GetInstance(object obj)
  {
    if (obj == null)
      return (OtherName) null;
    return obj is OtherName otherName ? otherName : new OtherName(Asn1Sequence.GetInstance(obj));
  }

  public static OtherName GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return OtherName.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  public OtherName(DerObjectIdentifier typeID, Asn1Encodable value)
  {
    this.typeID = typeID;
    this.value = value;
  }

  private OtherName(Asn1Sequence seq)
  {
    this.typeID = DerObjectIdentifier.GetInstance((object) seq[0]);
    this.value = Asn1Utilities.GetExplicitContextBaseObject(Asn1TaggedObject.GetInstance((object) seq[1]), 0);
  }

  public virtual DerObjectIdentifier TypeID => this.typeID;

  public Asn1Encodable Value => this.value;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.typeID, (Asn1Encodable) new DerTaggedObject(true, 0, this.value));
  }
}
