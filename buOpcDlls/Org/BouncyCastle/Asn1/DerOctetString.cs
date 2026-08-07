// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DerOctetString
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class DerOctetString : Asn1OctetString
{
  public DerOctetString(byte[] contents)
    : base(contents)
  {
  }

  public DerOctetString(IAsn1Convertible obj)
    : this((Asn1Encodable) obj.ToAsn1Object())
  {
  }

  public DerOctetString(Asn1Encodable obj)
    : base(obj.GetEncoded("DER"))
  {
  }

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(0, 4, this.contents);
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(tagClass, tagNo, this.contents);
  }

  internal sealed override DerEncoding GetEncodingDer()
  {
    return (DerEncoding) new PrimitiveDerEncoding(0, 4, this.contents);
  }

  internal sealed override DerEncoding GetEncodingDerImplicit(int tagClass, int tagNo)
  {
    return (DerEncoding) new PrimitiveDerEncoding(tagClass, tagNo, this.contents);
  }

  internal static void Encode(Asn1OutputStream asn1Out, byte[] buf, int off, int len)
  {
    asn1Out.WriteIdentifier(0, 4);
    asn1Out.WriteDL(len);
    asn1Out.Write(buf, off, len);
  }
}
