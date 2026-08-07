// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Asn1.CmcePublicKey
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Pqc.Asn1;

public class CmcePublicKey : Asn1Object
{
  private byte[] t;

  public static CmcePublicKey GetInstance(object o)
  {
    if (o == null)
      return (CmcePublicKey) null;
    return o is CmcePublicKey cmcePublicKey ? cmcePublicKey : new CmcePublicKey(Asn1Sequence.GetInstance(o));
  }

  public CmcePublicKey(byte[] t) => this.t = t;

  public CmcePublicKey(Asn1Sequence seq)
  {
    this.t = Arrays.Clone(Asn1OctetString.GetInstance((object) seq[0]).GetOctets());
  }

  public byte[] T => Arrays.Clone(this.t);

  public Asn1Object ToAsn1Primitive()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) new DerOctetString(this.t));
  }

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    return this.ToAsn1Primitive().GetEncoding(encoding);
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    return this.ToAsn1Primitive().GetEncodingImplicit(encoding, tagClass, tagNo);
  }

  internal override DerEncoding GetEncodingDer() => this.ToAsn1Primitive().GetEncodingDer();

  internal override DerEncoding GetEncodingDerImplicit(int tagClass, int tagNo)
  {
    return this.ToAsn1Primitive().GetEncodingDerImplicit(tagClass, tagNo);
  }

  protected override bool Asn1Equals(Asn1Object asn1Object)
  {
    return this.ToAsn1Primitive().CallAsn1Equals(asn1Object);
  }

  protected override int Asn1GetHashCode() => this.ToAsn1Primitive().CallAsn1GetHashCode();
}
