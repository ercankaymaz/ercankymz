// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X9.X9Curve
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X9;

public class X9Curve : Asn1Encodable
{
  private readonly ECCurve curve;
  private readonly byte[] seed;
  private readonly DerObjectIdentifier fieldIdentifier;

  public X9Curve(ECCurve curve)
    : this(curve, (byte[]) null)
  {
  }

  public X9Curve(ECCurve curve, byte[] seed)
  {
    this.curve = curve != null ? curve : throw new ArgumentNullException(nameof (curve));
    this.seed = Arrays.Clone(seed);
    if (ECAlgorithms.IsFpCurve(curve))
    {
      this.fieldIdentifier = X9ObjectIdentifiers.PrimeField;
    }
    else
    {
      if (!ECAlgorithms.IsF2mCurve(curve))
        throw new ArgumentException("This type of ECCurve is not implemented");
      this.fieldIdentifier = X9ObjectIdentifiers.CharacteristicTwoField;
    }
  }

  public X9Curve(X9FieldID fieldID, BigInteger order, BigInteger cofactor, Asn1Sequence seq)
  {
    if (fieldID == null)
      throw new ArgumentNullException(nameof (fieldID));
    if (seq == null)
      throw new ArgumentNullException(nameof (seq));
    this.fieldIdentifier = fieldID.Identifier;
    if (this.fieldIdentifier.Equals((Asn1Object) X9ObjectIdentifiers.PrimeField))
    {
      this.curve = (ECCurve) new FpCurve(((DerInteger) fieldID.Parameters).Value, new BigInteger(1, Asn1OctetString.GetInstance((object) seq[0]).GetOctets()), new BigInteger(1, Asn1OctetString.GetInstance((object) seq[1]).GetOctets()), order, cofactor);
    }
    else
    {
      if (!this.fieldIdentifier.Equals((Asn1Object) X9ObjectIdentifiers.CharacteristicTwoField))
        throw new ArgumentException("This type of ECCurve is not implemented");
      DerSequence parameters = (DerSequence) fieldID.Parameters;
      int intValueExact1 = ((DerInteger) parameters[0]).IntValueExact;
      DerObjectIdentifier objectIdentifier = (DerObjectIdentifier) parameters[1];
      int k2 = 0;
      int k3 = 0;
      DerObjectIdentifier tpBasis = X9ObjectIdentifiers.TPBasis;
      int intValueExact2;
      if (objectIdentifier.Equals((Asn1Object) tpBasis))
      {
        intValueExact2 = ((DerInteger) parameters[2]).IntValueExact;
      }
      else
      {
        DerSequence derSequence = (DerSequence) parameters[2];
        intValueExact2 = ((DerInteger) derSequence[0]).IntValueExact;
        k2 = ((DerInteger) derSequence[1]).IntValueExact;
        k3 = ((DerInteger) derSequence[2]).IntValueExact;
      }
      BigInteger a = new BigInteger(1, Asn1OctetString.GetInstance((object) seq[0]).GetOctets());
      BigInteger b = new BigInteger(1, Asn1OctetString.GetInstance((object) seq[1]).GetOctets());
      this.curve = (ECCurve) new F2mCurve(intValueExact1, intValueExact2, k2, k3, a, b, order, cofactor);
    }
    if (seq.Count != 3)
      return;
    this.seed = ((DerBitString) seq[2]).GetBytes();
  }

  public ECCurve Curve => this.curve;

  public byte[] GetSeed() => Arrays.Clone(this.seed);

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(3);
    if (this.fieldIdentifier.Equals((Asn1Object) X9ObjectIdentifiers.PrimeField) || this.fieldIdentifier.Equals((Asn1Object) X9ObjectIdentifiers.CharacteristicTwoField))
    {
      elementVector.Add((Asn1Encodable) new X9FieldElement(this.curve.A).ToAsn1Object());
      elementVector.Add((Asn1Encodable) new X9FieldElement(this.curve.B).ToAsn1Object());
    }
    if (this.seed != null)
      elementVector.Add((Asn1Encodable) new DerBitString(this.seed));
    return (Asn1Object) new DerSequence(elementVector);
  }
}
