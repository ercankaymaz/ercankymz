// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X9.X9ECPoint
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Asn1.X9;

public class X9ECPoint : Asn1Encodable
{
  private readonly Asn1OctetString encoding;
  private ECCurve c;
  private ECPoint p;

  public X9ECPoint(ECPoint p, bool compressed)
  {
    this.p = p.Normalize();
    this.encoding = (Asn1OctetString) new DerOctetString(p.GetEncoded(compressed));
  }

  public X9ECPoint(ECCurve c, byte[] encoding)
  {
    this.c = c;
    this.encoding = (Asn1OctetString) new DerOctetString(Arrays.Clone(encoding));
  }

  public X9ECPoint(ECCurve c, Asn1OctetString s)
    : this(c, s.GetOctets())
  {
  }

  public byte[] GetPointEncoding() => Arrays.Clone(this.encoding.GetOctets());

  public ECPoint Point
  {
    get
    {
      if (this.p == null)
        this.p = this.c.DecodePoint(this.encoding.GetOctets()).Normalize();
      return this.p;
    }
  }

  public bool IsPointCompressed
  {
    get
    {
      byte[] octets = this.encoding.GetOctets();
      if (octets == null || octets.Length == 0)
        return false;
      return octets[0] == (byte) 2 || octets[0] == (byte) 3;
    }
  }

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.encoding;
}
