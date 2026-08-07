// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.Qualified.MonetaryValue
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509.Qualified;

public class MonetaryValue : Asn1Encodable
{
  internal Iso4217CurrencyCode currency;
  internal DerInteger amount;
  internal DerInteger exponent;

  public static MonetaryValue GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case MonetaryValue _:
        return (MonetaryValue) obj;
      case Asn1Sequence _:
        return new MonetaryValue(Asn1Sequence.GetInstance(obj));
      default:
        throw new ArgumentException("unknown object in GetInstance: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private MonetaryValue(Asn1Sequence seq)
  {
    this.currency = seq.Count == 3 ? Iso4217CurrencyCode.GetInstance((object) seq[0]) : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString(), nameof (seq));
    this.amount = DerInteger.GetInstance((object) seq[1]);
    this.exponent = DerInteger.GetInstance((object) seq[2]);
  }

  public MonetaryValue(Iso4217CurrencyCode currency, int amount, int exponent)
  {
    this.currency = currency;
    this.amount = new DerInteger(amount);
    this.exponent = new DerInteger(exponent);
  }

  public Iso4217CurrencyCode Currency => this.currency;

  public BigInteger Amount => this.amount.Value;

  public BigInteger Exponent => this.exponent.Value;

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
