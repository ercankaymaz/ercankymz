// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X9.X9ECParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.Math.Field;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X9;

public class X9ECParameters : Asn1Encodable
{
  private X9FieldID fieldID;
  private ECCurve curve;
  private X9ECPoint g;
  private BigInteger n;
  private BigInteger h;
  private byte[] seed;

  public static X9ECParameters GetInstance(object obj)
  {
    if (obj is X9ECParameters)
      return (X9ECParameters) obj;
    return obj != null ? new X9ECParameters(Asn1Sequence.GetInstance(obj)) : (X9ECParameters) null;
  }

  public X9ECParameters(Asn1Sequence seq)
  {
    this.n = seq[0] is DerInteger && ((DerInteger) seq[0]).HasValue(1) ? ((DerInteger) seq[4]).Value : throw new ArgumentException("bad version in X9ECParameters");
    if (seq.Count == 6)
      this.h = ((DerInteger) seq[5]).Value;
    X9Curve x9Curve = new X9Curve(X9FieldID.GetInstance((object) seq[1]), this.n, this.h, Asn1Sequence.GetInstance((object) seq[2]));
    this.curve = x9Curve.Curve;
    object s = (object) seq[3];
    this.g = !(s is X9ECPoint x9EcPoint) ? new X9ECPoint(this.curve, (Asn1OctetString) s) : x9EcPoint;
    this.seed = x9Curve.GetSeed();
  }

  public X9ECParameters(ECCurve curve, X9ECPoint g, BigInteger n)
    : this(curve, g, n, (BigInteger) null, (byte[]) null)
  {
  }

  public X9ECParameters(ECCurve curve, X9ECPoint g, BigInteger n, BigInteger h)
    : this(curve, g, n, h, (byte[]) null)
  {
  }

  public X9ECParameters(ECCurve curve, X9ECPoint g, BigInteger n, BigInteger h, byte[] seed)
  {
    this.curve = curve;
    this.g = g;
    this.n = n;
    this.h = h;
    this.seed = seed;
    if (ECAlgorithms.IsFpCurve(curve))
    {
      this.fieldID = new X9FieldID(curve.Field.Characteristic);
    }
    else
    {
      if (!ECAlgorithms.IsF2mCurve(curve))
        throw new ArgumentException("'curve' is of an unsupported type");
      int[] exponentsPresent = ((IPolynomialExtensionField) curve.Field).MinimalPolynomial.GetExponentsPresent();
      if (exponentsPresent.Length == 3)
        this.fieldID = new X9FieldID(exponentsPresent[2], exponentsPresent[1]);
      else
        this.fieldID = exponentsPresent.Length == 5 ? new X9FieldID(exponentsPresent[4], exponentsPresent[1], exponentsPresent[2], exponentsPresent[3]) : throw new ArgumentException("Only trinomial and pentomial curves are supported");
    }
  }

  public ECCurve Curve => this.curve;

  public ECPoint G => this.g.Point;

  public BigInteger N => this.n;

  public BigInteger H => this.h;

  public byte[] GetSeed() => this.seed;

  public X9Curve CurveEntry => new X9Curve(this.curve, this.seed);

  public X9FieldID FieldIDEntry => this.fieldID;

  public X9ECPoint BaseEntry => this.g;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(new Asn1Encodable[5]
    {
      (Asn1Encodable) new DerInteger(BigInteger.One),
      (Asn1Encodable) this.fieldID,
      (Asn1Encodable) new X9Curve(this.curve, this.seed),
      (Asn1Encodable) this.g,
      (Asn1Encodable) new DerInteger(this.n)
    });
    if (this.h != null)
      elementVector.Add((Asn1Encodable) new DerInteger(this.h));
    return (Asn1Object) new DerSequence(elementVector);
  }
}
