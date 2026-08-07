// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.ContentInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class ContentInfo : Asn1Encodable
{
  private readonly DerObjectIdentifier contentType;
  private readonly Asn1Encodable content;

  public static ContentInfo GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case ContentInfo _:
        return (ContentInfo) obj;
      case Asn1Sequence _:
        return new ContentInfo((Asn1Sequence) obj);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj));
    }
  }

  public static ContentInfo GetInstance(Asn1TaggedObject obj, bool isExplicit)
  {
    return ContentInfo.GetInstance((object) Asn1Sequence.GetInstance(obj, isExplicit));
  }

  private ContentInfo(Asn1Sequence seq)
  {
    this.contentType = seq.Count >= 1 && seq.Count <= 2 ? (DerObjectIdentifier) seq[0] : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString(), nameof (seq));
    if (seq.Count <= 1)
      return;
    Asn1TaggedObject asn1TaggedObject = (Asn1TaggedObject) seq[1];
    this.content = asn1TaggedObject.IsExplicit() && asn1TaggedObject.TagNo == 0 ? (Asn1Encodable) asn1TaggedObject.GetObject() : throw new ArgumentException("Bad tag for 'content'", nameof (seq));
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
