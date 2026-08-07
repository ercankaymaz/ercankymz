// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.PrimitiveDerEncodingSuffixed
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1;

internal class PrimitiveDerEncodingSuffixed : DerEncoding
{
  private readonly byte[] m_contentsOctets;
  private readonly byte m_contentsSuffix;

  internal PrimitiveDerEncodingSuffixed(
    int tagClass,
    int tagNo,
    byte[] contentsOctets,
    byte contentsSuffix)
    : base(tagClass, tagNo)
  {
    this.m_contentsOctets = contentsOctets;
    this.m_contentsSuffix = contentsSuffix;
  }

  protected internal override int CompareLengthAndContents(DerEncoding other)
  {
    switch (other)
    {
      case PrimitiveDerEncodingSuffixed encodingSuffixed:
        return PrimitiveDerEncodingSuffixed.CompareSuffixed(this.m_contentsOctets, this.m_contentsSuffix, encodingSuffixed.m_contentsOctets, encodingSuffixed.m_contentsSuffix);
      case PrimitiveDerEncoding primitiveDerEncoding:
        int length = primitiveDerEncoding.m_contentsOctets.Length;
        return length == 0 ? this.m_contentsOctets.Length : PrimitiveDerEncodingSuffixed.CompareSuffixed(this.m_contentsOctets, this.m_contentsSuffix, primitiveDerEncoding.m_contentsOctets, primitiveDerEncoding.m_contentsOctets[length - 1]);
      default:
        throw new InvalidOperationException();
    }
  }

  public override void Encode(Asn1OutputStream asn1Out)
  {
    asn1Out.WriteIdentifier(this.m_tagClass, this.m_tagNo);
    asn1Out.WriteDL(this.m_contentsOctets.Length);
    asn1Out.Write(this.m_contentsOctets, 0, this.m_contentsOctets.Length - 1);
    asn1Out.WriteByte(this.m_contentsSuffix);
  }

  public override int GetLength()
  {
    return Asn1OutputStream.GetLengthOfEncodingDL(this.m_tagNo, this.m_contentsOctets.Length);
  }

  private static int CompareSuffixed(byte[] octetsA, byte suffixA, byte[] octetsB, byte suffixB)
  {
    int length = octetsA.Length;
    if (length != octetsB.Length)
      return length - octetsB.Length;
    int num1 = length - 1;
    for (int index = 0; index < num1; ++index)
    {
      byte num2 = octetsA[index];
      byte num3 = octetsB[index];
      if ((int) num2 != (int) num3)
        return (int) num2 - (int) num3;
    }
    return (int) suffixA - (int) suffixB;
  }
}
