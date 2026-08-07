// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Pkcs.Pkcs12PbeParams
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Pkcs;

public class Pkcs12PbeParams : Asn1Encodable
{
  private readonly DerInteger iterations;
  private readonly Asn1OctetString iv;

  public Pkcs12PbeParams(byte[] salt, int iterations)
  {
    this.iv = (Asn1OctetString) new DerOctetString(salt);
    this.iterations = new DerInteger(iterations);
  }

  private Pkcs12PbeParams(Asn1Sequence seq)
  {
    this.iv = seq.Count == 2 ? Asn1OctetString.GetInstance((object) seq[0]) : throw new ArgumentException("Wrong number of elements in sequence", nameof (seq));
    this.iterations = DerInteger.GetInstance((object) seq[1]);
  }

  public static Pkcs12PbeParams GetInstance(object obj)
  {
    switch (obj)
    {
      case Pkcs12PbeParams _:
        return (Pkcs12PbeParams) obj;
      case Asn1Sequence _:
        return new Pkcs12PbeParams((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public BigInteger Iterations => this.iterations.Value;

  public byte[] GetIV() => this.iv.GetOctets();

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.iv, (Asn1Encodable) this.iterations);
  }
}
