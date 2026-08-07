// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.BerSet
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class BerSet : DerSet
{
  public static readonly BerSet Empty = new BerSet();

  public static BerSet FromVector(Asn1EncodableVector elementVector)
  {
    return elementVector.Count >= 1 ? new BerSet(elementVector) : BerSet.Empty;
  }

  public BerSet()
  {
  }

  public BerSet(Asn1Encodable element)
    : base(element)
  {
  }

  public BerSet(params Asn1Encodable[] elements)
    : base(elements, false)
  {
  }

  public BerSet(Asn1EncodableVector elementVector)
    : base(elementVector, false)
  {
  }

  internal BerSet(bool isSorted, Asn1Encodable[] elements)
    : base(isSorted, elements)
  {
  }

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    return 1 != encoding ? base.GetEncoding(encoding) : (IAsn1Encoding) new ConstructedILEncoding(0, 17, Asn1OutputStream.GetContentsEncodings(encoding, this.m_elements));
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    return 1 != encoding ? base.GetEncodingImplicit(encoding, tagClass, tagNo) : (IAsn1Encoding) new ConstructedILEncoding(tagClass, tagNo, Asn1OutputStream.GetContentsEncodings(encoding, this.m_elements));
  }
}
