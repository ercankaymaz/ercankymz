// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DerTaggedObject
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class DerTaggedObject : Asn1TaggedObject
{
  public DerTaggedObject(int tagNo, Asn1Encodable obj)
    : base(true, tagNo, obj)
  {
  }

  public DerTaggedObject(int tagClass, int tagNo, Asn1Encodable obj)
    : base(true, tagClass, tagNo, obj)
  {
  }

  public DerTaggedObject(bool isExplicit, int tagNo, Asn1Encodable obj)
    : base(isExplicit, tagNo, obj)
  {
  }

  public DerTaggedObject(bool isExplicit, int tagClass, int tagNo, Asn1Encodable obj)
    : base(isExplicit, tagClass, tagNo, obj)
  {
  }

  internal DerTaggedObject(int explicitness, int tagClass, int tagNo, Asn1Encodable obj)
    : base(explicitness, tagClass, tagNo, obj)
  {
  }

  internal override string Asn1Encoding => "DER";

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    encoding = 2;
    Asn1Object asn1Object = this.GetBaseObject().ToAsn1Object();
    if (!this.IsExplicit())
      return asn1Object.GetEncodingImplicit(encoding, this.TagClass, this.TagNo);
    return (IAsn1Encoding) new ConstructedDLEncoding(this.TagClass, this.TagNo, new IAsn1Encoding[1]
    {
      asn1Object.GetEncoding(encoding)
    });
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    encoding = 2;
    Asn1Object asn1Object = this.GetBaseObject().ToAsn1Object();
    if (!this.IsExplicit())
      return asn1Object.GetEncodingImplicit(encoding, tagClass, tagNo);
    return (IAsn1Encoding) new ConstructedDLEncoding(tagClass, tagNo, new IAsn1Encoding[1]
    {
      asn1Object.GetEncoding(encoding)
    });
  }

  internal sealed override DerEncoding GetEncodingDer()
  {
    Asn1Object asn1Object = this.GetBaseObject().ToAsn1Object();
    if (!this.IsExplicit())
      return asn1Object.GetEncodingDerImplicit(this.TagClass, this.TagNo);
    return (DerEncoding) new ConstructedDerEncoding(this.TagClass, this.TagNo, new DerEncoding[1]
    {
      asn1Object.GetEncodingDer()
    });
  }

  internal sealed override DerEncoding GetEncodingDerImplicit(int tagClass, int tagNo)
  {
    Asn1Object asn1Object = this.GetBaseObject().ToAsn1Object();
    if (!this.IsExplicit())
      return asn1Object.GetEncodingDerImplicit(tagClass, tagNo);
    return (DerEncoding) new ConstructedDerEncoding(tagClass, tagNo, new DerEncoding[1]
    {
      asn1Object.GetEncodingDer()
    });
  }

  internal override Asn1Sequence RebuildConstructed(Asn1Object asn1Object)
  {
    return (Asn1Sequence) new DerSequence((Asn1Encodable) asn1Object);
  }

  internal override Asn1TaggedObject ReplaceTag(int tagClass, int tagNo)
  {
    return (Asn1TaggedObject) new DerTaggedObject(this.m_explicitness, tagClass, tagNo, this.m_object);
  }
}
