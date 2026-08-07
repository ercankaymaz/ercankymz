// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.BerOctetString
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class BerOctetString : DerOctetString
{
  private readonly Asn1OctetString[] elements;

  public static BerOctetString FromSequence(Asn1Sequence seq)
  {
    return new BerOctetString(seq.MapElements<Asn1OctetString>(new Func<Asn1Encodable, Asn1OctetString>(Asn1OctetString.GetInstance)));
  }

  internal static byte[] FlattenOctetStrings(Asn1OctetString[] octetStrings)
  {
    int length1 = octetStrings.Length;
    switch (length1)
    {
      case 0:
        return Asn1OctetString.EmptyOctets;
      case 1:
        return octetStrings[0].contents;
      default:
        int length2 = 0;
        for (int index = 0; index < length1; ++index)
          length2 += octetStrings[index].contents.Length;
        byte[] destinationArray = new byte[length2];
        int destinationIndex = 0;
        for (int index = 0; index < length1; ++index)
        {
          byte[] contents = octetStrings[index].contents;
          Array.Copy((Array) contents, 0, (Array) destinationArray, destinationIndex, contents.Length);
          destinationIndex += contents.Length;
        }
        return destinationArray;
    }
  }

  public BerOctetString(byte[] contents)
    : this(contents, (Asn1OctetString[]) null)
  {
  }

  public BerOctetString(Asn1OctetString[] elements)
    : this(BerOctetString.FlattenOctetStrings(elements), elements)
  {
  }

  [Obsolete("Use version without segmentLimit (which is ignored anyway)")]
  public BerOctetString(byte[] contents, int segmentLimit)
    : this(contents)
  {
  }

  [Obsolete("Use version without segmentLimit (which is ignored anyway)")]
  public BerOctetString(Asn1OctetString[] elements, int segmentLimit)
    : this(elements)
  {
  }

  private BerOctetString(byte[] contents, Asn1OctetString[] elements)
    : base(contents)
  {
    this.elements = elements;
  }

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    if (1 != encoding)
      return base.GetEncoding(encoding);
    return this.elements == null ? (IAsn1Encoding) new PrimitiveEncoding(0, 4, this.contents) : (IAsn1Encoding) new ConstructedILEncoding(0, 4, Asn1OutputStream.GetContentsEncodings(encoding, (Asn1Encodable[]) this.elements));
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    if (1 != encoding)
      return base.GetEncodingImplicit(encoding, tagClass, tagNo);
    return this.elements == null ? (IAsn1Encoding) new PrimitiveEncoding(tagClass, tagNo, this.contents) : (IAsn1Encoding) new ConstructedILEncoding(tagClass, tagNo, Asn1OutputStream.GetContentsEncodings(encoding, (Asn1Encodable[]) this.elements));
  }
}
