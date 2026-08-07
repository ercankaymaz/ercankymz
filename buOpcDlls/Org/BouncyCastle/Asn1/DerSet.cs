// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DerSet
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class DerSet : Asn1Set
{
  public static readonly DerSet Empty = new DerSet();

  public static DerSet FromVector(Asn1EncodableVector elementVector)
  {
    return elementVector.Count >= 1 ? new DerSet(elementVector) : DerSet.Empty;
  }

  public DerSet()
  {
  }

  public DerSet(Asn1Encodable element)
    : base(element)
  {
  }

  public DerSet(params Asn1Encodable[] elements)
    : base(elements, true)
  {
  }

  internal DerSet(Asn1Encodable[] elements, bool doSort)
    : base(elements, doSort)
  {
  }

  public DerSet(Asn1EncodableVector elementVector)
    : base(elementVector, true)
  {
  }

  internal DerSet(Asn1EncodableVector elementVector, bool doSort)
    : base(elementVector, doSort)
  {
  }

  internal DerSet(bool isSorted, Asn1Encodable[] elements)
    : base(isSorted, elements)
  {
  }

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    return (IAsn1Encoding) new ConstructedDLEncoding(0, 17, (IAsn1Encoding[]) this.GetSortedDerEncodings());
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    return (IAsn1Encoding) new ConstructedDLEncoding(tagClass, tagNo, (IAsn1Encoding[]) this.GetSortedDerEncodings());
  }

  internal sealed override DerEncoding GetEncodingDer()
  {
    return (DerEncoding) new ConstructedDerEncoding(0, 17, this.GetSortedDerEncodings());
  }

  internal sealed override DerEncoding GetEncodingDerImplicit(int tagClass, int tagNo)
  {
    return (DerEncoding) new ConstructedDerEncoding(tagClass, tagNo, this.GetSortedDerEncodings());
  }

  private DerEncoding[] GetSortedDerEncodings()
  {
    return Objects.EnsureSingletonInitialized<DerEncoding[], Asn1Encodable[]>(ref this.m_sortedDerEncodings, this.m_elements, new Func<Asn1Encodable[], DerEncoding[]>(DerSet.CreateSortedDerEncodings));
  }

  private static DerEncoding[] CreateSortedDerEncodings(Asn1Encodable[] elements)
  {
    DerEncoding[] contentsEncodingsDer = Asn1OutputStream.GetContentsEncodingsDer(elements);
    if (contentsEncodingsDer.Length > 1)
      Array.Sort<DerEncoding>(contentsEncodingsDer);
    return contentsEncodingsDer;
  }
}
