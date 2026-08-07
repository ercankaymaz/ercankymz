// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.ConstructedILEncoding
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1;

internal class ConstructedILEncoding : IAsn1Encoding
{
  private readonly int m_tagClass;
  private readonly int m_tagNo;
  private readonly IAsn1Encoding[] m_contentsElements;

  internal ConstructedILEncoding(int tagClass, int tagNo, IAsn1Encoding[] contentsElements)
  {
    this.m_tagClass = tagClass;
    this.m_tagNo = tagNo;
    this.m_contentsElements = contentsElements;
  }

  void IAsn1Encoding.Encode(Asn1OutputStream asn1Out)
  {
    asn1Out.WriteIdentifier(32 /*0x20*/ | this.m_tagClass, this.m_tagNo);
    asn1Out.WriteByte((byte) 128 /*0x80*/);
    asn1Out.EncodeContents(this.m_contentsElements);
    asn1Out.WriteByte((byte) 0);
    asn1Out.WriteByte((byte) 0);
  }

  int IAsn1Encoding.GetLength()
  {
    return Asn1OutputStream.GetLengthOfEncodingIL(this.m_tagNo, this.m_contentsElements);
  }
}
