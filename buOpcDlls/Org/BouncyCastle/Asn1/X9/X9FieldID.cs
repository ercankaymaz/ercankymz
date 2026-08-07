// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X9.X9FieldID
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X9;

public class X9FieldID : Asn1Encodable
{
  private readonly DerObjectIdentifier id;
  private readonly Asn1Object parameters;

  public X9FieldID(BigInteger primeP)
  {
    this.id = X9ObjectIdentifiers.PrimeField;
    this.parameters = (Asn1Object) new DerInteger(primeP);
  }

  public X9FieldID(int m, int k1)
    : this(m, k1, 0, 0)
  {
  }

  public X9FieldID(int m, int k1, int k2, int k3)
  {
    this.id = X9ObjectIdentifiers.CharacteristicTwoField;
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) new DerInteger(m));
    if (k2 == 0)
    {
      if (k3 != 0)
        throw new ArgumentException("inconsistent k values");
      elementVector.Add((Asn1Encodable) X9ObjectIdentifiers.TPBasis, (Asn1Encodable) new DerInteger(k1));
    }
    else
    {
      if (k2 <= k1 || k3 <= k2)
        throw new ArgumentException("inconsistent k values");
      elementVector.Add((Asn1Encodable) X9ObjectIdentifiers.PPBasis, (Asn1Encodable) new DerSequence(new Asn1Encodable[3]
      {
        (Asn1Encodable) new DerInteger(k1),
        (Asn1Encodable) new DerInteger(k2),
        (Asn1Encodable) new DerInteger(k3)
      }));
    }
    this.parameters = (Asn1Object) new DerSequence(elementVector);
  }

  private X9FieldID(Asn1Sequence seq)
  {
    this.id = DerObjectIdentifier.GetInstance((object) seq[0]);
    this.parameters = seq[1].ToAsn1Object();
  }

  public static X9FieldID GetInstance(object obj)
  {
    if (obj is X9FieldID)
      return (X9FieldID) obj;
    return obj == null ? (X9FieldID) null : new X9FieldID(Asn1Sequence.GetInstance(obj));
  }

  public DerObjectIdentifier Identifier => this.id;

  public Asn1Object Parameters => this.parameters;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.id, (Asn1Encodable) this.parameters);
  }
}
