// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Pkcs.ContentInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.Pkcs;

public class ContentInfo : Asn1Encodable
{
  private readonly DerObjectIdentifier contentType;
  private readonly Asn1Encodable content;

  public static ContentInfo GetInstance(object obj)
  {
    if (obj == null)
      return (ContentInfo) null;
    return obj is ContentInfo contentInfo ? contentInfo : new ContentInfo(Asn1Sequence.GetInstance(obj));
  }

  private ContentInfo(Asn1Sequence seq)
  {
    this.contentType = (DerObjectIdentifier) seq[0];
    if (seq.Count <= 1)
      return;
    this.content = (Asn1Encodable) ((Asn1TaggedObject) seq[1]).GetObject();
  }

  public ContentInfo(DerObjectIdentifier contentType, Asn1Encodable content)
  {
    this.contentType = contentType;
    this.content = content;
  }

  public DerObjectIdentifier ContentType => this.contentType;

  public Asn1Encodable Content => this.content;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.contentType);
    if (this.content != null)
      elementVector.Add((Asn1Encodable) new BerTaggedObject(0, this.content));
    return (Asn1Object) new BerSequence(elementVector);
  }
}
