// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X9.DHValidationParms
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X9;

public class DHValidationParms : Asn1Encodable
{
  private readonly DerBitString seed;
  private readonly DerInteger pgenCounter;

  public static DHValidationParms GetInstance(Asn1TaggedObject obj, bool isExplicit)
  {
    return DHValidationParms.GetInstance((object) Asn1Sequence.GetInstance(obj, isExplicit));
  }

  public static DHValidationParms GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case DHValidationParms _:
        return (DHValidationParms) obj;
      case Asn1Sequence _:
        return new DHValidationParms((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Invalid DHValidationParms: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public DHValidationParms(DerBitString seed, DerInteger pgenCounter)
  {
    if (seed == null)
      throw new ArgumentNullException(nameof (seed));
    if (pgenCounter == null)
      throw new ArgumentNullException(nameof (pgenCounter));
    this.seed = seed;
    this.pgenCounter = pgenCounter;
  }

  private DHValidationParms(Asn1Sequence seq)
  {
    this.seed = seq.Count == 2 ? DerBitString.GetInstance((object) seq[0]) : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString(), nameof (seq));
    this.pgenCounter = DerInteger.GetInstance((object) seq[1]);
  }

  public DerBitString Seed => this.seed;

  public DerInteger PgenCounter => this.pgenCounter;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.seed, (Asn1Encodable) this.pgenCounter);
  }
}
