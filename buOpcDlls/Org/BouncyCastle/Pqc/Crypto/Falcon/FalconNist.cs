// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Falcon.FalconNist
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Falcon;

internal class FalconNist
{
  private FalconCodec codec;
  private FalconVrfy vrfy;
  private FalconCommon common;
  private SecureRandom random;
  private uint logn;
  private uint noncelen;
  private int CRYPTO_BYTES;
  private int CRYPTO_PUBLICKEYBYTES;
  private int CRYPTO_SECRETKEYBYTES;

  internal uint NonceLength => this.noncelen;

  internal uint LogN => this.logn;

  internal int CryptoBytes => this.CRYPTO_BYTES;

  internal FalconNist(SecureRandom random, uint logn, uint noncelen)
  {
    this.logn = logn;
    this.codec = new FalconCodec();
    this.common = new FalconCommon();
    this.vrfy = new FalconVrfy(this.common);
    this.random = random;
    this.noncelen = noncelen;
    int num = 1 << (int) logn;
    this.CRYPTO_PUBLICKEYBYTES = 1 + 14 * num / 8;
    switch (logn)
    {
      case 6:
      case 7:
        this.CRYPTO_SECRETKEYBYTES = 1 + 7 * num * 2 / 8 + num;
        this.CRYPTO_BYTES = 690;
        break;
      case 8:
      case 9:
        this.CRYPTO_SECRETKEYBYTES = 1 + 6 * num * 2 / 8 + num;
        this.CRYPTO_BYTES = 690;
        break;
      case 10:
        this.CRYPTO_SECRETKEYBYTES = 2305;
        this.CRYPTO_BYTES = 1330;
        break;
      default:
        this.CRYPTO_SECRETKEYBYTES = 1 + num * 2 + num;
        this.CRYPTO_BYTES = 690;
        break;
    }
  }

  internal int crypto_sign_keypair(
    out byte[] pk,
    out byte[] fEnc,
    out byte[] gEnc,
    out byte[] FEnc)
  {
    byte[] numArray1 = new byte[this.CRYPTO_SECRETKEYBYTES];
    pk = new byte[this.CRYPTO_PUBLICKEYBYTES];
    int length = 1 << (int) this.logn;
    SHAKE256 shakE256 = new SHAKE256();
    sbyte[] xsrc1 = new sbyte[length];
    sbyte[] xsrc2 = new sbyte[length];
    sbyte[] xsrc3 = new sbyte[length];
    ushort[] xsrc4 = new ushort[length];
    byte[] numArray2 = new byte[48 /*0x30*/];
    FalconKeygen falconKeygen = new FalconKeygen(this.codec, this.vrfy);
    this.random.NextBytes(numArray2);
    shakE256.i_shake256_init();
    shakE256.i_shake256_inject(numArray2, 0, numArray2.Length);
    shakE256.i_shake256_flip();
    SHAKE256 rng = shakE256;
    sbyte[] fsrc = xsrc1;
    sbyte[] gsrc = xsrc2;
    sbyte[] Fsrc = xsrc3;
    ushort[] hsrc = xsrc4;
    int logn = (int) this.logn;
    falconKeygen.keygen(rng, fsrc, 0, gsrc, 0, Fsrc, 0, (sbyte[]) null, 0, hsrc, 0, (uint) logn);
    numArray1[0] = (byte) (80U /*0x50*/ + this.logn);
    int from = 1;
    int num1 = this.codec.trim_i8_encode(numArray1, 1, this.CRYPTO_SECRETKEYBYTES - 1, xsrc1, 0, this.logn, (uint) this.codec.max_fg_bits[(int) this.logn]);
    if (num1 == 0)
      throw new InvalidOperationException("f encode failed");
    fEnc = Arrays.CopyOfRange(numArray1, from, from + num1);
    int num2 = from + num1;
    int num3 = this.codec.trim_i8_encode(numArray1, num2, this.CRYPTO_SECRETKEYBYTES - num2, xsrc2, 0, this.logn, (uint) this.codec.max_fg_bits[(int) this.logn]);
    if (num3 == 0)
      throw new InvalidOperationException("g encode failed");
    gEnc = Arrays.CopyOfRange(numArray1, num2, num2 + num3);
    int num4 = num2 + num3;
    int num5 = this.codec.trim_i8_encode(numArray1, num4, this.CRYPTO_SECRETKEYBYTES - num4, xsrc3, 0, this.logn, (uint) this.codec.max_FG_bits[(int) this.logn]);
    if (num5 == 0)
      throw new InvalidOperationException("F encode failed");
    FEnc = Arrays.CopyOfRange(numArray1, num4, num4 + num5);
    if (num4 + num5 != this.CRYPTO_SECRETKEYBYTES)
      throw new InvalidOperationException("secret key encoding failed");
    pk[0] = (byte) this.logn;
    if (this.codec.modq_encode(pk, 1, this.CRYPTO_PUBLICKEYBYTES - 1, xsrc4, 0, this.logn) != this.CRYPTO_PUBLICKEYBYTES - 1)
      throw new InvalidOperationException("public key encoding failed");
    pk = Arrays.CopyOfRange(pk, 1, pk.Length);
    return 0;
  }

  internal byte[] crypto_sign(
    bool attached,
    byte[] sm,
    byte[] msrc,
    int m,
    uint mlen,
    byte[] sksrc,
    int sk)
  {
    int length1 = 1 << (int) this.logn;
    sbyte[] numArray1 = new sbyte[length1];
    sbyte[] numArray2 = new sbyte[length1];
    sbyte[] numArray3 = new sbyte[length1];
    sbyte[] Gsrc1 = new sbyte[length1];
    short[] xsrc1 = new short[length1];
    ushort[] xsrc2 = new ushort[length1];
    byte[] numArray4 = new byte[48 /*0x30*/];
    byte[] numArray5 = new byte[(int) this.noncelen];
    byte[] numArray6 = new byte[(long) (this.CRYPTO_BYTES - 2) - (long) this.noncelen];
    SHAKE256 sc = new SHAKE256();
    FalconSign falconSign = new FalconSign(this.common);
    int num1 = 0;
    int num2 = this.codec.trim_i8_decode(numArray1, 0, this.logn, (uint) this.codec.max_fg_bits[(int) this.logn], sksrc, sk + 0, this.CRYPTO_SECRETKEYBYTES - 0);
    if (num2 == 0)
      throw new InvalidOperationException("f decode failed");
    int num3 = num1 + num2;
    int num4 = this.codec.trim_i8_decode(numArray2, 0, this.logn, (uint) this.codec.max_fg_bits[(int) this.logn], sksrc, sk + num3, this.CRYPTO_SECRETKEYBYTES - num3);
    if (num4 == 0)
      throw new InvalidOperationException("g decode failed");
    int num5 = num3 + num4;
    int num6 = this.codec.trim_i8_decode(numArray3, 0, this.logn, (uint) this.codec.max_FG_bits[(int) this.logn], sksrc, sk + num5, this.CRYPTO_SECRETKEYBYTES - num5);
    if (num6 == 0)
      throw new InvalidOperationException("F decode failed");
    if (num5 + num6 != this.CRYPTO_SECRETKEYBYTES - 1)
      throw new InvalidOperationException("full Key not used");
    if (this.vrfy.complete_private(Gsrc1, 0, numArray1, 0, numArray2, 0, numArray3, 0, this.logn, new ushort[2 * length1], 0) == 0)
      throw new InvalidOperationException("complete private failed");
    this.random.NextBytes(numArray5);
    sc.i_shake256_init();
    sc.i_shake256_inject(numArray5, 0, numArray5.Length);
    sc.i_shake256_inject(msrc, m, (int) mlen);
    sc.i_shake256_flip();
    this.common.hash_to_point_vartime(sc, xsrc2, 0, this.logn);
    this.random.NextBytes(numArray4);
    sc.i_shake256_init();
    sc.i_shake256_inject(numArray4, 0, numArray4.Length);
    sc.i_shake256_flip();
    short[] sigsrc = xsrc1;
    SHAKE256 rng = sc;
    sbyte[] fsrc = numArray1;
    sbyte[] gsrc = numArray2;
    sbyte[] Fsrc = numArray3;
    sbyte[] Gsrc2 = Gsrc1;
    ushort[] hmsrc = xsrc2;
    int logn = (int) this.logn;
    FalconFPR[] tmpsrc = new FalconFPR[10 * length1];
    falconSign.sign_dyn(sigsrc, 0, rng, fsrc, 0, gsrc, 0, Fsrc, 0, Gsrc2, 0, hmsrc, 0, (uint) logn, tmpsrc, 0);
    int length2;
    if (attached)
    {
      numArray6[0] = (byte) (32U /*0x20*/ + this.logn);
      int num7 = this.codec.comp_encode(numArray6, 1, numArray6.Length - 1, xsrc1, 0, this.logn);
      if (num7 == 0)
        throw new InvalidOperationException("signature failed to generate");
      length2 = num7 + 1;
    }
    else
    {
      length2 = this.codec.comp_encode(numArray6, 0, numArray6.Length, xsrc1, 0, this.logn);
      if (length2 == 0)
        throw new InvalidOperationException("signature failed to generate");
    }
    sm[0] = (byte) (48U /*0x30*/ + this.logn);
    Array.Copy((Array) numArray5, 0L, (Array) sm, 1L, (long) this.noncelen);
    Array.Copy((Array) numArray6, 0L, (Array) sm, (long) (1U + this.noncelen), (long) length2);
    return Arrays.CopyOfRange(sm, 0, 1 + (int) this.noncelen + length2);
  }

  internal int crypto_sign_open(
    bool attached,
    byte[] sig_encoded,
    byte[] nonce,
    byte[] m,
    byte[] pksrc,
    int pk)
  {
    int length1 = 1 << (int) this.logn;
    ushort[] numArray1 = new ushort[length1];
    ushort[] numArray2 = new ushort[length1];
    short[] numArray3 = new short[length1];
    SHAKE256 sc = new SHAKE256();
    if (this.codec.modq_decode(numArray1, 0, this.logn, pksrc, pk, this.CRYPTO_PUBLICKEYBYTES - 1) != this.CRYPTO_PUBLICKEYBYTES - 1)
      return -1;
    this.vrfy.to_ntt_monty(numArray1, 0, this.logn);
    int length2 = sig_encoded.Length;
    if (attached)
    {
      if (length2 < 1 || (int) sig_encoded[0] != (int) (byte) (32U /*0x20*/ + this.logn) || this.codec.comp_decode(numArray3, 0, this.logn, sig_encoded, 1, length2 - 1) != length2 - 1)
        return -1;
    }
    else if (length2 < 1 || this.codec.comp_decode(numArray3, 0, this.logn, sig_encoded, 0, length2) != length2)
      return -1;
    sc.i_shake256_init();
    sc.i_shake256_inject(nonce, 0, (int) this.noncelen);
    sc.i_shake256_inject(m, 0, m.Length);
    sc.i_shake256_flip();
    this.common.hash_to_point_vartime(sc, numArray2, 0, this.logn);
    return !this.vrfy.verify_raw(numArray2, 0, numArray3, 0, numArray1, 0, this.logn, new ushort[length1], 0) ? -1 : 0;
  }
}
