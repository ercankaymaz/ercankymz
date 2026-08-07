// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.PrimitiveDerEncoding
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1;

internal class PrimitiveDerEncoding : DerEncoding
{
  internal readonly byte[] m_contentsOctets;

  internal PrimitiveDerEncoding(int tagClass, int tagNo, byte[] contentsOctets)
    : base(tagClass, tagNo)
  {
    this.m_contentsOctets = contentsOctets;
  }

  protected internal override int CompareLengthAndContents(DerEncoding other)
  {
    switch (other)
    {
      case PrimitiveDerEncodingSuffixed encodingSuffixed:
        return -encodingSuffixed.CompareLengthAndContents((DerEncoding) this);
      case PrimitiveDerEncoding primitiveDerEncoding:
        int length = this.m_contentsOctets.Length;
        if (length != primitiveDerEncoding.m_contentsOctets.Length)
          return length - primitiveDerEncoding.m_contentsOctets.Length;
        for (int index = 0; index < length; ++index)
        {
          byte contentsOctet1 = this.m_contentsOctets[index];
          byte contentsOctet2 = primitiveDerEncoding.m_contentsOctets[index];
          if ((int) contentsOctet1 != (int) contentsOctet2)
            return (int) contentsOctet1 - (int) contentsOctet2;
        }
        return 0;
      default:
        throw new InvalidOperationException();
    }
  }

  public override void Encode(Asn1OutputStream asn1Out)
  {
    asn1Out.WriteIdentifier(this.m_tagClass, this.m_tagNo);
    asn1Out.WriteDL(this.m_contentsOctets.Length);
    asn1Out.Write(this.m_contentsOctets, 0, this.m_contentsOctets.Length);
  }

  public override int GetLength()
  {
    return Asn1OutputStream.GetLengthOfEncodingDL(this.m_tagNo, this.m_contentsOctets.Length);
  }
}
