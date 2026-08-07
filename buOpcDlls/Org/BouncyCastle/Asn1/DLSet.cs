// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DLSet
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1;

internal class DLSet : DerSet
{
  internal static readonly DLSet Empty = new DLSet();

  internal static DLSet FromVector(Asn1EncodableVector elementVector)
  {
    return elementVector.Count >= 1 ? new DLSet(elementVector) : DLSet.Empty;
  }

  internal DLSet()
  {
  }

  internal DLSet(Asn1Encodable element)
    : base(element)
  {
  }

  internal DLSet(params Asn1Encodable[] elements)
    : base(elements, false)
  {
  }

  internal DLSet(Asn1EncodableVector elementVector)
    : base(elementVector, false)
  {
  }

  internal DLSet(bool isSorted, Asn1Encodable[] elements)
    : base(isSorted, elements)
  {
  }

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    return 2 == encoding ? base.GetEncoding(encoding) : (IAsn1Encoding) new ConstructedDLEncoding(0, 17, Asn1OutputStream.GetContentsEncodings(encoding, this.m_elements));
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    return 2 == encoding ? base.GetEncodingImplicit(encoding, tagClass, tagNo) : (IAsn1Encoding) new ConstructedDLEncoding(tagClass, tagNo, Asn1OutputStream.GetContentsEncodings(encoding, this.m_elements));
  }
}
