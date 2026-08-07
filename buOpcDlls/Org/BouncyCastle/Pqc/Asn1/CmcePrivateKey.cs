// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Asn1.CmcePrivateKey
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Asn1;

public class CmcePrivateKey : Asn1Object
{
  private int version;
  private byte[] delta;
  private byte[] c;
  private byte[] g;
  private byte[] alpha;
  private byte[] s;
  private CmcePublicKey publicKey;

  public static CmcePrivateKey GetInstance(object o)
  {
    if (o == null)
      return (CmcePrivateKey) null;
    return o is CmcePrivateKey cmcePrivateKey ? cmcePrivateKey : new CmcePrivateKey(Asn1Sequence.GetInstance(o));
  }

  public CmcePrivateKey(
    int version,
    byte[] delta,
    byte[] c,
    byte[] g,
    byte[] alpha,
    byte[] s,
    CmcePublicKey pubKey = null)
  {
    this.version = version;
    if (version != 0)
      throw new Exception("unrecognized version");
    this.delta = Arrays.Clone(delta);
    this.c = Arrays.Clone(c);
    this.g = Arrays.Clone(g);
    this.alpha = Arrays.Clone(alpha);
    this.s = Arrays.Clone(s);
    this.publicKey = pubKey;
  }

  private CmcePrivateKey(Asn1Sequence seq)
  {
    this.version = DerInteger.GetInstance((object) seq[0]).Value.IntValue;
    if (this.version != 0)
      throw new Exception("unrecognized version");
    this.delta = Arrays.Clone(Asn1OctetString.GetInstance((object) seq[1]).GetOctets());
    this.c = Arrays.Clone(Asn1OctetString.GetInstance((object) seq[2]).GetOctets());
    this.g = Arrays.Clone(Asn1OctetString.GetInstance((object) seq[3]).GetOctets());
    this.alpha = Arrays.Clone(Asn1OctetString.GetInstance((object) seq[4]).GetOctets());
    this.s = Arrays.Clone(Asn1OctetString.GetInstance((object) seq[5]).GetOctets());
    if (seq.Count != 7)
      return;
    this.publicKey = CmcePublicKey.GetInstance((object) seq[6]);
  }

  public int Version => this.version;

  public byte[] Delta => Arrays.Clone(this.delta);

  public byte[] C => Arrays.Clone(this.c);

  public byte[] G => Arrays.Clone(this.g);

  public byte[] Alpha => Arrays.Clone(this.alpha);

  public byte[] S => Arrays.Clone(this.s);

  public CmcePublicKey PublicKey => this.publicKey;

  public Asn1Object ToAsn1Primitive()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(7);
    elementVector.Add((Asn1Encodable) new DerInteger(this.version));
    elementVector.Add((Asn1Encodable) new DerOctetString(this.delta));
    elementVector.Add((Asn1Encodable) new DerOctetString(this.c));
    elementVector.Add((Asn1Encodable) new DerOctetString(this.g));
    elementVector.Add((Asn1Encodable) new DerOctetString(this.alpha));
    elementVector.Add((Asn1Encodable) new DerOctetString(this.s));
    if (this.publicKey != null)
      elementVector.Add((Asn1Encodable) new CmcePublicKey(this.publicKey.T));
    return (Asn1Object) new DerSequence(elementVector);
  }

  internal override IAsn1Encoding GetEncoding(int encoding)
  {
    return this.ToAsn1Primitive().GetEncoding(encoding);
  }

  internal override IAsn1Encoding GetEncodingImplicit(int encoding, int tagClass, int tagNo)
  {
    return this.ToAsn1Primitive().GetEncodingImplicit(encoding, tagClass, tagNo);
  }

  internal sealed override DerEncoding GetEncodingDer() => this.ToAsn1Primitive().GetEncodingDer();

  internal sealed override DerEncoding GetEncodingDerImplicit(int tagClass, int tagNo)
  {
    return this.ToAsn1Primitive().GetEncodingDerImplicit(tagClass, tagNo);
  }

  protected override bool Asn1Equals(Asn1Object asn1Object)
  {
    return this.ToAsn1Primitive().CallAsn1Equals(asn1Object);
  }

  protected override int Asn1GetHashCode() => this.ToAsn1Primitive().CallAsn1GetHashCode();
}
