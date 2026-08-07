// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DLTaggedObject
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1;

internal class DLTaggedObject : DerTaggedObject
{
  internal DLTaggedObject(int tagNo, Asn1Encodable obj)
    : base(tagNo, obj)
  {
  }

  internal DLTaggedObject(int tagClass, int tagNo, Asn1Encodable obj)
    : base(tagClass, tagNo, obj)
  {
  }

  internal DLTaggedObject(bool isExplicit, int tagNo, Asn1Encodable obj)
    : base(isExplicit, tagNo, obj)
  {
  }

  internal DLTaggedObject(bool isExplicit, int tagClass, int tagNo, Asn1Encodable obj)
    : base(isExplicit, tagClass, tagNo, obj)
  {
  }

  internal DLTaggedObject(int explicitness, int tagClass, int tagNo, Asn1Encodable obj)
    : base(explicitness, tagClass, tagNo, obj)
  {
  }

  internal override string Asn1Encoding => "BER";

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    if (2 == encoding)
      return base.GetEncoding(encoding);
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
    if (2 == encoding)
      return base.GetEncodingImplicit(encoding, tagClass, tagNo);
    Asn1Object asn1Object = this.GetBaseObject().ToAsn1Object();
    if (!this.IsExplicit())
      return asn1Object.GetEncodingImplicit(encoding, tagClass, tagNo);
    return (IAsn1Encoding) new ConstructedDLEncoding(tagClass, tagNo, new IAsn1Encoding[1]
    {
      asn1Object.GetEncoding(encoding)
    });
  }

  internal override Asn1Sequence RebuildConstructed(Asn1Object asn1Object)
  {
    return (Asn1Sequence) new DLSequence((Asn1Encodable) asn1Object);
  }

  internal override Asn1TaggedObject ReplaceTag(int tagClass, int tagNo)
  {
    return (Asn1TaggedObject) new DLTaggedObject(this.m_explicitness, tagClass, tagNo, this.m_object);
  }
}
