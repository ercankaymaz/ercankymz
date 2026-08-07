// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DLSequence
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1;

internal class DLSequence : DerSequence
{
  internal static readonly DLSequence Empty = new DLSequence();

  internal static DLSequence FromVector(Asn1EncodableVector elementVector)
  {
    return elementVector.Count >= 1 ? new DLSequence(elementVector) : DLSequence.Empty;
  }

  internal DLSequence()
  {
  }

  internal DLSequence(Asn1Encodable element)
    : base(element)
  {
  }

  public DLSequence(Asn1Encodable element1, Asn1Encodable element2)
    : base(element1, element2)
  {
  }

  internal DLSequence(params Asn1Encodable[] elements)
    : base(elements)
  {
  }

  internal DLSequence(Asn1EncodableVector elementVector)
    : base(elementVector)
  {
  }

  internal DLSequence(Asn1Encodable[] elements, bool clone)
    : base(elements, clone)
  {
  }

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    return 2 == encoding ? base.GetEncoding(encoding) : (IAsn1Encoding) new ConstructedDLEncoding(0, 16 /*0x10*/, Asn1OutputStream.GetContentsEncodings(encoding, this.elements));
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    return 2 == encoding ? base.GetEncodingImplicit(encoding, tagClass, tagNo) : (IAsn1Encoding) new ConstructedDLEncoding(tagClass, tagNo, Asn1OutputStream.GetContentsEncodings(encoding, this.elements));
  }

  internal override DerBitString ToAsn1BitString()
  {
    return (DerBitString) new DLBitString(BerBitString.FlattenBitStrings(this.GetConstructedBitStrings()), false);
  }

  internal override DerExternal ToAsn1External()
  {
    return (DerExternal) new DLExternal((Asn1Sequence) this);
  }

  internal override Asn1Set ToAsn1Set() => (Asn1Set) new DLSet(false, this.elements);
}
