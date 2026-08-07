// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.PrimitiveEncoding
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1;

internal class PrimitiveEncoding : IAsn1Encoding
{
  private readonly int m_tagClass;
  private readonly int m_tagNo;
  private readonly byte[] m_contentsOctets;

  internal PrimitiveEncoding(int tagClass, int tagNo, byte[] contentsOctets)
  {
    this.m_tagClass = tagClass;
    this.m_tagNo = tagNo;
    this.m_contentsOctets = contentsOctets;
  }

  void IAsn1Encoding.Encode(Asn1OutputStream asn1Out)
  {
    asn1Out.WriteIdentifier(this.m_tagClass, this.m_tagNo);
    asn1Out.WriteDL(this.m_contentsOctets.Length);
    asn1Out.Write(this.m_contentsOctets, 0, this.m_contentsOctets.Length);
  }

  int IAsn1Encoding.GetLength()
  {
    return Asn1OutputStream.GetLengthOfEncodingDL(this.m_tagNo, this.m_contentsOctets.Length);
  }
}
