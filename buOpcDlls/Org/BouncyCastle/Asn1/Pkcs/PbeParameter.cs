// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Pkcs.PbeParameter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Pkcs;

public class PbeParameter : Asn1Encodable
{
  private readonly Asn1OctetString salt;
  private readonly DerInteger iterationCount;

  public static PbeParameter GetInstance(object obj)
  {
    if (obj == null)
      return (PbeParameter) null;
    return obj is PbeParameter pbeParameter ? pbeParameter : new PbeParameter(Asn1Sequence.GetInstance(obj));
  }

  private PbeParameter(Asn1Sequence seq)
  {
    this.salt = seq.Count == 2 ? Asn1OctetString.GetInstance((object) seq[0]) : throw new ArgumentException("Wrong number of elements in sequence", nameof (seq));
    this.iterationCount = DerInteger.GetInstance((object) seq[1]);
  }

  public PbeParameter(byte[] salt, int iterationCount)
  {
    this.salt = (Asn1OctetString) new DerOctetString(salt);
    this.iterationCount = new DerInteger(iterationCount);
  }

  public byte[] GetSalt() => this.salt.GetOctets();

  public BigInteger IterationCount => this.iterationCount.Value;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.salt, (Asn1Encodable) this.iterationCount);
  }
}
