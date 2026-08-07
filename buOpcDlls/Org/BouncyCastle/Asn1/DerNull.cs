// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DerNull
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class DerNull : Asn1Null
{
  public static readonly DerNull Instance = new DerNull();
  private static readonly byte[] ZeroBytes = new byte[0];

  protected internal DerNull()
  {
  }

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(0, 5, DerNull.ZeroBytes);
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    return (IAsn1Encoding) new PrimitiveEncoding(tagClass, tagNo, DerNull.ZeroBytes);
  }

  internal sealed override DerEncoding GetEncodingDer()
  {
    return (DerEncoding) new PrimitiveDerEncoding(0, 5, DerNull.ZeroBytes);
  }

  internal sealed override DerEncoding GetEncodingDerImplicit(int tagClass, int tagNo)
  {
    return (DerEncoding) new PrimitiveDerEncoding(tagClass, tagNo, DerNull.ZeroBytes);
  }

  protected override bool Asn1Equals(Asn1Object asn1Object) => asn1Object is DerNull;

  protected override int Asn1GetHashCode() => -1;
}
