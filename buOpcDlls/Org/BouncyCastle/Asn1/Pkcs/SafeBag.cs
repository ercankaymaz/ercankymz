// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Pkcs.SafeBag
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.Pkcs;

public class SafeBag : Asn1Encodable
{
  private readonly DerObjectIdentifier bagID;
  private readonly Asn1Object bagValue;
  private readonly Asn1Set bagAttributes;

  public static SafeBag GetInstance(object obj)
  {
    if (obj is SafeBag)
      return (SafeBag) obj;
    return obj == null ? (SafeBag) null : new SafeBag(Asn1Sequence.GetInstance(obj));
  }

  public SafeBag(DerObjectIdentifier oid, Asn1Object obj)
  {
    this.bagID = oid;
    this.bagValue = obj;
    this.bagAttributes = (Asn1Set) null;
  }

  public SafeBag(DerObjectIdentifier oid, Asn1Object obj, Asn1Set bagAttributes)
  {
    this.bagID = oid;
    this.bagValue = obj;
    this.bagAttributes = bagAttributes;
  }

  private SafeBag(Asn1Sequence seq)
  {
    this.bagID = (DerObjectIdentifier) seq[0];
    this.bagValue = ((Asn1TaggedObject) seq[1]).GetObject();
    if (seq.Count != 3)
      return;
    this.bagAttributes = (Asn1Set) seq[2];
  }

  public DerObjectIdentifier BagID => this.bagID;

  public Asn1Object BagValue => this.bagValue;

  public Asn1Set BagAttributes => this.bagAttributes;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.bagID, (Asn1Encodable) new DerTaggedObject(0, (Asn1Encodable) this.bagValue));
    elementVector.AddOptional((Asn1Encodable) this.bagAttributes);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
