// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Misc.Cast5CbcParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Misc;

public class Cast5CbcParameters : Asn1Encodable
{
  private readonly DerInteger keyLength;
  private readonly Asn1OctetString iv;

  public static Cast5CbcParameters GetInstance(object o)
  {
    switch (o)
    {
      case Cast5CbcParameters _:
        return (Cast5CbcParameters) o;
      case Asn1Sequence _:
        return new Cast5CbcParameters((Asn1Sequence) o);
      default:
        throw new ArgumentException("unknown object in Cast5CbcParameters factory");
    }
  }

  public Cast5CbcParameters(byte[] iv, int keyLength)
  {
    this.iv = (Asn1OctetString) new DerOctetString(iv);
    this.keyLength = new DerInteger(keyLength);
  }

  private Cast5CbcParameters(Asn1Sequence seq)
  {
    this.iv = seq.Count == 2 ? (Asn1OctetString) seq[0] : throw new ArgumentException("Wrong number of elements in sequence", nameof (seq));
    this.keyLength = (DerInteger) seq[1];
  }

  public byte[] GetIV() => Arrays.Clone(this.iv.GetOctets());

  public int KeyLength => this.keyLength.IntValueExact;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.iv, (Asn1Encodable) this.keyLength);
  }
}
