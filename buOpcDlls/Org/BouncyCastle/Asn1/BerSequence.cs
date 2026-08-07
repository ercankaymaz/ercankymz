// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.BerSequence
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class BerSequence : DerSequence
{
  public static readonly BerSequence Empty = new BerSequence();

  public static BerSequence FromVector(Asn1EncodableVector elementVector)
  {
    return elementVector.Count >= 1 ? new BerSequence(elementVector) : BerSequence.Empty;
  }

  public BerSequence()
  {
  }

  public BerSequence(Asn1Encodable element)
    : base(element)
  {
  }

  public BerSequence(Asn1Encodable element1, Asn1Encodable element2)
    : base(element1, element2)
  {
  }

  public BerSequence(params Asn1Encodable[] elements)
    : base(elements)
  {
  }

  public BerSequence(Asn1EncodableVector elementVector)
    : base(elementVector)
  {
  }

  internal BerSequence(Asn1Encodable[] elements, bool clone)
    : base(elements, clone)
  {
  }

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    return 1 != encoding ? base.GetEncoding(encoding) : (IAsn1Encoding) new ConstructedILEncoding(0, 16 /*0x10*/, Asn1OutputStream.GetContentsEncodings(encoding, this.elements));
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    return 1 != encoding ? base.GetEncodingImplicit(encoding, tagClass, tagNo) : (IAsn1Encoding) new ConstructedILEncoding(tagClass, tagNo, Asn1OutputStream.GetContentsEncodings(encoding, this.elements));
  }

  internal override DerBitString ToAsn1BitString()
  {
    return (DerBitString) new BerBitString(this.GetConstructedBitStrings());
  }

  internal override DerExternal ToAsn1External()
  {
    return (DerExternal) new DLExternal((Asn1Sequence) this);
  }

  internal override Asn1OctetString ToAsn1OctetString()
  {
    return (Asn1OctetString) new BerOctetString(this.GetConstructedOctetStrings());
  }

  internal override Asn1Set ToAsn1Set() => (Asn1Set) new BerSet(false, this.elements);
}
