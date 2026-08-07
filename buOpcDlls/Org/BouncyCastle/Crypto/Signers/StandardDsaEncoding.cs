// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Signers.StandardDsaEncoding
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Signers;

public class StandardDsaEncoding : IDsaEncoding
{
  public static readonly StandardDsaEncoding Instance = new StandardDsaEncoding();

  public virtual BigInteger[] Decode(BigInteger n, byte[] encoding)
  {
    Asn1Sequence s1 = (Asn1Sequence) Asn1Object.FromByteArray(encoding);
    if (s1.Count == 2)
    {
      BigInteger r = this.DecodeValue(n, s1, 0);
      BigInteger s2 = this.DecodeValue(n, s1, 1);
      if (Arrays.AreEqual(this.Encode(n, r, s2), encoding))
        return new BigInteger[2]{ r, s2 };
    }
    throw new ArgumentException("Malformed signature", nameof (encoding));
  }

  public virtual byte[] Encode(BigInteger n, BigInteger r, BigInteger s)
  {
    return new DerSequence((Asn1Encodable) this.EncodeValue(n, r), (Asn1Encodable) this.EncodeValue(n, s)).GetEncoded("DER");
  }

  public virtual int GetMaxEncodingSize(BigInteger n)
  {
    return DerSequence.GetEncodingLength(DerInteger.GetEncodingLength(n) * 2);
  }

  protected virtual BigInteger CheckValue(BigInteger n, BigInteger x)
  {
    if (x.SignValue < 0 || n != null && x.CompareTo(n) >= 0)
      throw new ArgumentException("Value out of range", nameof (x));
    return x;
  }

  protected virtual BigInteger DecodeValue(BigInteger n, Asn1Sequence s, int pos)
  {
    return this.CheckValue(n, ((DerInteger) s[pos]).Value);
  }

  protected virtual DerInteger EncodeValue(BigInteger n, BigInteger x)
  {
    return new DerInteger(this.CheckValue(n, x));
  }
}
