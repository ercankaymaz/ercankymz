// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.IsisMtt.X509.MonetaryLimit
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.IsisMtt.X509;

public class MonetaryLimit : Asn1Encodable
{
  private readonly DerPrintableString currency;
  private readonly DerInteger amount;
  private readonly DerInteger exponent;

  public static MonetaryLimit GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case MonetaryLimit _:
        return (MonetaryLimit) obj;
      case Asn1Sequence _:
        return new MonetaryLimit(Asn1Sequence.GetInstance(obj));
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private MonetaryLimit(Asn1Sequence seq)
  {
    this.currency = seq.Count == 3 ? DerPrintableString.GetInstance((object) seq[0]) : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString());
    this.amount = DerInteger.GetInstance((object) seq[1]);
    this.exponent = DerInteger.GetInstance((object) seq[2]);
  }

  public MonetaryLimit(string currency, int amount, int exponent)
  {
    this.currency = new DerPrintableString(currency, true);
    this.amount = new DerInteger(amount);
    this.exponent = new DerInteger(exponent);
  }

  public virtual string Currency => this.currency.GetString();

  public virtual BigInteger Amount => this.amount.Value;

  public virtual BigInteger Exponent => this.exponent.Value;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence(new Asn1Encodable[3]
    {
      (Asn1Encodable) this.currency,
      (Asn1Encodable) this.amount,
      (Asn1Encodable) this.exponent
    });
  }
}
