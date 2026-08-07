// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.ConstructedDerEncoding
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1;

internal class ConstructedDerEncoding : DerEncoding
{
  private readonly DerEncoding[] m_contentsElements;
  private readonly int m_contentsLength;

  internal ConstructedDerEncoding(int tagClass, int tagNo, DerEncoding[] contentsElements)
    : base(tagClass, tagNo)
  {
    this.m_contentsElements = contentsElements;
    this.m_contentsLength = Asn1OutputStream.GetLengthOfContents((IAsn1Encoding[]) contentsElements);
  }

  protected internal override int CompareLengthAndContents(DerEncoding other)
  {
    if (!(other is ConstructedDerEncoding constructedDerEncoding))
      throw new InvalidOperationException();
    if (this.m_contentsLength != constructedDerEncoding.m_contentsLength)
      return this.m_contentsLength - constructedDerEncoding.m_contentsLength;
    int num1 = Math.Min(this.m_contentsElements.Length, constructedDerEncoding.m_contentsElements.Length);
    for (int index = 0; index < num1; ++index)
    {
      int num2 = this.m_contentsElements[index].CompareTo(constructedDerEncoding.m_contentsElements[index]);
      if (num2 != 0)
        return num2;
    }
    return this.m_contentsElements.Length - constructedDerEncoding.m_contentsElements.Length;
  }

  public override void Encode(Asn1OutputStream asn1Out)
  {
    asn1Out.WriteIdentifier(32 /*0x20*/ | this.m_tagClass, this.m_tagNo);
    asn1Out.WriteDL(this.m_contentsLength);
    asn1Out.EncodeContents((IAsn1Encoding[]) this.m_contentsElements);
  }

  public override int GetLength()
  {
    return Asn1OutputStream.GetLengthOfEncodingDL(this.m_tagNo, this.m_contentsLength);
  }
}
