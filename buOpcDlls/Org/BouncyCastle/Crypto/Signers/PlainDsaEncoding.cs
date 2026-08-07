// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Signers.PlainDsaEncoding
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Signers;

public class PlainDsaEncoding : IDsaEncoding
{
  public static readonly PlainDsaEncoding Instance = new PlainDsaEncoding();

  public virtual BigInteger[] Decode(BigInteger n, byte[] encoding)
  {
    int unsignedByteLength = BigIntegers.GetUnsignedByteLength(n);
    if (encoding.Length != unsignedByteLength * 2)
      throw new ArgumentException("Encoding has incorrect length", nameof (encoding));
    return new BigInteger[2]
    {
      this.DecodeValue(n, encoding, 0, unsignedByteLength),
      this.DecodeValue(n, encoding, unsignedByteLength, unsignedByteLength)
    };
  }

  public virtual byte[] Encode(BigInteger n, BigInteger r, BigInteger s)
  {
    int unsignedByteLength = BigIntegers.GetUnsignedByteLength(n);
    byte[] buf = new byte[unsignedByteLength * 2];
    this.EncodeValue(n, r, buf, 0, unsignedByteLength);
    this.EncodeValue(n, s, buf, unsignedByteLength, unsignedByteLength);
    return buf;
  }

  public virtual int GetMaxEncodingSize(BigInteger n) => BigIntegers.GetUnsignedByteLength(n) * 2;

  protected virtual BigInteger CheckValue(BigInteger n, BigInteger x)
  {
    if (x.SignValue < 0 || x.CompareTo(n) >= 0)
      throw new ArgumentException("Value out of range", nameof (x));
    return x;
  }

  protected virtual BigInteger DecodeValue(BigInteger n, byte[] buf, int off, int len)
  {
    return this.CheckValue(n, new BigInteger(1, buf, off, len));
  }

  protected virtual void EncodeValue(BigInteger n, BigInteger x, byte[] buf, int off, int len)
  {
    byte[] byteArrayUnsigned = this.CheckValue(n, x).ToByteArrayUnsigned();
    int sourceIndex = System.Math.Max(0, byteArrayUnsigned.Length - len);
    int length = byteArrayUnsigned.Length - sourceIndex;
    int num = len - length;
    Arrays.Fill(buf, off, off + num, (byte) 0);
    Array.Copy((Array) byteArrayUnsigned, sourceIndex, (Array) buf, off + num, length);
  }
}
