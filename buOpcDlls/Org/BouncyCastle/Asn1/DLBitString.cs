// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DLBitString
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class DLBitString : DerBitString
{
  public DLBitString(byte data, int padBits)
    : base(data, padBits)
  {
  }

  public DLBitString(byte[] data)
    : this(data, 0)
  {
  }

  public DLBitString(byte[] data, int padBits)
    : base(data, padBits)
  {
  }

  public DLBitString(int namedBits)
    : base(namedBits)
  {
  }

  public DLBitString(Asn1Encodable obj)
    : this(obj.GetDerEncoded(), 0)
  {
  }

  internal DLBitString(byte[] contents, bool check)
    : base(contents, check)
  {
  }

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    return 2 == encoding ? base.GetEncoding(encoding) : (IAsn1Encoding) new PrimitiveEncoding(0, 3, this.contents);
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    return 2 == encoding ? base.GetEncodingImplicit(encoding, tagClass, tagNo) : (IAsn1Encoding) new PrimitiveEncoding(tagClass, tagNo, this.contents);
  }
}
