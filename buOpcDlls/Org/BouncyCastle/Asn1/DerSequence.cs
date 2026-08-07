// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DerSequence
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class DerSequence : Asn1Sequence
{
  public static readonly DerSequence Empty = new DerSequence();

  public static DerSequence FromVector(Asn1EncodableVector elementVector)
  {
    return elementVector.Count >= 1 ? new DerSequence(elementVector) : DerSequence.Empty;
  }

  public DerSequence()
  {
  }

  public DerSequence(Asn1Encodable element)
    : base(element)
  {
  }

  public DerSequence(Asn1Encodable element1, Asn1Encodable element2)
    : base(element1, element2)
  {
  }

  public DerSequence(params Asn1Encodable[] elements)
    : base(elements)
  {
  }

  public DerSequence(Asn1EncodableVector elementVector)
    : base(elementVector)
  {
  }

  internal DerSequence(Asn1Encodable[] elements, bool clone)
    : base(elements, clone)
  {
  }

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    return (IAsn1Encoding) new ConstructedDLEncoding(0, 16 /*0x10*/, Asn1OutputStream.GetContentsEncodings(2, this.elements));
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    return (IAsn1Encoding) new ConstructedDLEncoding(tagClass, tagNo, Asn1OutputStream.GetContentsEncodings(2, this.elements));
  }

  internal sealed override DerEncoding GetEncodingDer()
  {
    return (DerEncoding) new ConstructedDerEncoding(0, 16 /*0x10*/, Asn1OutputStream.GetContentsEncodingsDer(this.elements));
  }

  internal sealed override DerEncoding GetEncodingDerImplicit(int tagClass, int tagNo)
  {
    return (DerEncoding) new ConstructedDerEncoding(tagClass, tagNo, Asn1OutputStream.GetContentsEncodingsDer(this.elements));
  }

  internal override DerBitString ToAsn1BitString()
  {
    return new DerBitString(BerBitString.FlattenBitStrings(this.GetConstructedBitStrings()), false);
  }

  internal override DerExternal ToAsn1External() => new DerExternal((Asn1Sequence) this);

  internal override Asn1OctetString ToAsn1OctetString()
  {
    return (Asn1OctetString) new DerOctetString(BerOctetString.FlattenOctetStrings(this.GetConstructedOctetStrings()));
  }

  internal override Asn1Set ToAsn1Set() => (Asn1Set) new DLSet(false, this.elements);

  internal static int GetEncodingLength(int contentsLength)
  {
    return Asn1OutputStream.GetLengthOfEncodingDL(16 /*0x10*/, contentsLength);
  }
}
