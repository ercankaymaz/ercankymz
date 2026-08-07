// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.BerBitString
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class BerBitString : DerBitString
{
  private readonly DerBitString[] elements;

  public static BerBitString FromSequence(Asn1Sequence seq)
  {
    return new BerBitString(seq.MapElements<DerBitString>(new Func<Asn1Encodable, DerBitString>(DerBitString.GetInstance)));
  }

  internal static byte[] FlattenBitStrings(DerBitString[] bitStrings)
  {
    int length1 = bitStrings.Length;
    switch (length1)
    {
      case 0:
        return new byte[1];
      case 1:
        return bitStrings[0].contents;
      default:
        int index1 = length1 - 1;
        int num1 = 0;
        for (int index2 = 0; index2 < index1; ++index2)
        {
          byte[] contents = bitStrings[index2].contents;
          if (contents[0] != (byte) 0)
            throw new ArgumentException("only the last nested bitstring can have padding", nameof (bitStrings));
          num1 += contents.Length - 1;
        }
        byte[] contents1 = bitStrings[index1].contents;
        byte num2 = contents1[0];
        byte[] destinationArray = new byte[num1 + contents1.Length];
        destinationArray[0] = num2;
        int destinationIndex = 1;
        for (int index3 = 0; index3 < length1; ++index3)
        {
          byte[] contents2 = bitStrings[index3].contents;
          int length2 = contents2.Length - 1;
          Array.Copy((Array) contents2, 1, (Array) destinationArray, destinationIndex, length2);
          destinationIndex += length2;
        }
        return destinationArray;
    }
  }

  public BerBitString(byte data, int padBits)
    : base(data, padBits)
  {
    this.elements = (DerBitString[]) null;
  }

  public BerBitString(byte[] data)
    : this(data, 0)
  {
  }

  public BerBitString(byte[] data, int padBits)
    : base(data, padBits)
  {
    this.elements = (DerBitString[]) null;
  }

  [Obsolete("Use version without segmentLimit (which is ignored anyway)")]
  public BerBitString(byte[] data, int padBits, int segmentLimit)
    : this(data, padBits)
  {
  }

  public BerBitString(int namedBits)
    : base(namedBits)
  {
    this.elements = (DerBitString[]) null;
  }

  public BerBitString(Asn1Encodable obj)
    : this(obj.GetDerEncoded(), 0)
  {
  }

  public BerBitString(DerBitString[] elements)
    : base(BerBitString.FlattenBitStrings(elements), false)
  {
    this.elements = elements;
  }

  [Obsolete("Use version without segmentLimit (which is ignored anyway)")]
  public BerBitString(DerBitString[] elements, int segmentLimit)
    : this(elements)
  {
  }

  internal BerBitString(byte[] contents, bool check)
    : base(contents, check)
  {
    this.elements = (DerBitString[]) null;
  }

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    if (1 != encoding)
      return base.GetEncoding(encoding);
    return this.elements == null ? (IAsn1Encoding) new PrimitiveEncoding(0, 3, this.contents) : (IAsn1Encoding) new ConstructedILEncoding(0, 3, Asn1OutputStream.GetContentsEncodings(encoding, (Asn1Encodable[]) this.elements));
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    if (1 != encoding)
      return base.GetEncodingImplicit(encoding, tagClass, tagNo);
    return this.elements == null ? (IAsn1Encoding) new PrimitiveEncoding(tagClass, tagNo, this.contents) : (IAsn1Encoding) new ConstructedILEncoding(tagClass, tagNo, Asn1OutputStream.GetContentsEncodings(encoding, (Asn1Encodable[]) this.elements));
  }
}
