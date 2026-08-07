// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Saber.SaberEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Saber;

internal sealed class SaberEngine
{
  internal const int SABER_EP = 10;
  internal const int SABER_N = 256 /*0x0100*/;
  private const int SABER_SEEDBYTES = 32 /*0x20*/;
  private const int SABER_NOISE_SEEDBYTES = 32 /*0x20*/;
  private const int SABER_KEYBYTES = 32 /*0x20*/;
  private const int SABER_HASHBYTES = 32 /*0x20*/;
  private readonly int SABER_L;
  private readonly int SABER_MU;
  private readonly int SABER_ET;
  private readonly int SABER_POLYCOINBYTES;
  private readonly int SABER_EQ;
  private readonly int SABER_POLYBYTES;
  private readonly int SABER_POLYVECBYTES;
  private readonly int SABER_POLYCOMPRESSEDBYTES;
  private readonly int SABER_POLYVECCOMPRESSEDBYTES;
  private readonly int SABER_SCALEBYTES_KEM;
  private readonly int SABER_INDCPA_PUBLICKEYBYTES;
  private readonly int SABER_INDCPA_SECRETKEYBYTES;
  private readonly int SABER_PUBLICKEYBYTES;
  private readonly int SABER_SECRETKEYBYTES;
  private readonly int SABER_BYTES_CCA_DEC;
  private readonly int defaultKeySize;
  private int h1;
  private int h2;
  private Symmetric symmetric;
  private SaberUtilities utils;
  private Poly poly;
  private readonly bool usingAes;
  private readonly bool usingEffectiveMasking;

  public bool UsingAes => this.usingAes;

  public bool UsingEffectiveMasking => this.usingEffectiveMasking;

  public Symmetric Symmetric => this.symmetric;

  public int EQ => this.SABER_EQ;

  public int N => 256 /*0x0100*/;

  public int EP => 10;

  public int KeyBytes => 32 /*0x20*/;

  public int L => this.SABER_L;

  public int ET => this.SABER_ET;

  public int PolyBytes => this.SABER_POLYBYTES;

  public int PolyVecBytes => this.SABER_POLYVECBYTES;

  public int SeedBytes => 32 /*0x20*/;

  public int PolyCoinBytes => this.SABER_POLYCOINBYTES;

  public int NoiseSeedBytes => 32 /*0x20*/;

  public int MU => this.SABER_MU;

  public SaberUtilities Utilities => this.utils;

  public int GetSessionKeySize() => this.defaultKeySize / 8;

  public int GetCipherTextSize() => this.SABER_BYTES_CCA_DEC;

  public int GetPublicKeySize() => this.SABER_PUBLICKEYBYTES;

  public int GetPrivateKeySize() => this.SABER_SECRETKEYBYTES;

  internal SaberEngine(int l, int defaultKeySize, bool usingAes, bool usingEffectiveMasking)
  {
    this.defaultKeySize = defaultKeySize;
    this.usingAes = usingAes;
    this.usingEffectiveMasking = usingEffectiveMasking;
    this.SABER_L = l;
    switch (l)
    {
      case 2:
        this.SABER_MU = 10;
        this.SABER_ET = 3;
        break;
      case 3:
        this.SABER_MU = 8;
        this.SABER_ET = 4;
        break;
      default:
        this.SABER_MU = 6;
        this.SABER_ET = 6;
        break;
    }
    this.symmetric = !usingAes ? (Symmetric) new Symmetric.ShakeSymmetric() : (Symmetric) new Symmetric.AesSymmetric();
    if (usingEffectiveMasking)
    {
      this.SABER_EQ = 12;
      this.SABER_POLYCOINBYTES = 64 /*0x40*/;
    }
    else
    {
      this.SABER_EQ = 13;
      this.SABER_POLYCOINBYTES = this.SABER_MU * 256 /*0x0100*/ / 8;
    }
    this.SABER_POLYBYTES = this.SABER_EQ * 256 /*0x0100*/ / 8;
    this.SABER_POLYVECBYTES = this.SABER_L * this.SABER_POLYBYTES;
    this.SABER_POLYCOMPRESSEDBYTES = 320;
    this.SABER_POLYVECCOMPRESSEDBYTES = this.SABER_L * this.SABER_POLYCOMPRESSEDBYTES;
    this.SABER_SCALEBYTES_KEM = this.SABER_ET * 256 /*0x0100*/ / 8;
    this.SABER_INDCPA_PUBLICKEYBYTES = this.SABER_POLYVECCOMPRESSEDBYTES + 32 /*0x20*/;
    this.SABER_INDCPA_SECRETKEYBYTES = this.SABER_POLYVECBYTES;
    this.SABER_PUBLICKEYBYTES = this.SABER_INDCPA_PUBLICKEYBYTES;
    this.SABER_SECRETKEYBYTES = this.SABER_INDCPA_SECRETKEYBYTES + this.SABER_INDCPA_PUBLICKEYBYTES + 32 /*0x20*/ + 32 /*0x20*/;
    this.SABER_BYTES_CCA_DEC = this.SABER_POLYVECCOMPRESSEDBYTES + this.SABER_SCALEBYTES_KEM;
    this.h1 = 1 << this.SABER_EQ - 10 - 1;
    this.h2 = 256 /*0x0100*/ - (1 << 10 - this.SABER_ET - 1) + (1 << this.SABER_EQ - 10 - 1);
    this.utils = new SaberUtilities(this);
    this.poly = new Poly(this);
  }

  private void indcpa_kem_keypair(byte[] pk, byte[] sk, SecureRandom random)
  {
    short[][][] A = new short[this.SABER_L][][];
    for (int index1 = 0; index1 < this.SABER_L; ++index1)
    {
      short[][] numArray1 = new short[this.SABER_L][];
      for (int index2 = 0; index2 < this.SABER_L; ++index2)
      {
        short[] numArray2 = new short[256 /*0x0100*/];
        numArray1[index2] = numArray2;
      }
      A[index1] = numArray1;
    }
    short[][] numArray3 = new short[this.SABER_L][];
    for (int index = 0; index < this.SABER_L; ++index)
    {
      short[] numArray4 = new short[256 /*0x0100*/];
      numArray3[index] = numArray4;
    }
    short[][] numArray5 = new short[this.SABER_L][];
    for (int index = 0; index < this.SABER_L; ++index)
    {
      short[] numArray6 = new short[256 /*0x0100*/];
      numArray5[index] = numArray6;
    }
    byte[] numArray7 = new byte[32 /*0x20*/];
    byte[] numArray8 = new byte[32 /*0x20*/];
    random.NextBytes(numArray7);
    this.symmetric.Prf(numArray7, numArray7, 32 /*0x20*/, 32 /*0x20*/);
    random.NextBytes(numArray8);
    this.poly.GenMatrix(A, numArray7);
    this.poly.GenSecret(numArray3, numArray8);
    this.poly.MatrixVectorMul(A, numArray3, numArray5, 1);
    for (int index3 = 0; index3 < this.SABER_L; ++index3)
    {
      for (int index4 = 0; index4 < 256 /*0x0100*/; ++index4)
        numArray5[index3][index4] = (short) (((int) numArray5[index3][index4] + this.h1 & (int) ushort.MaxValue) >> this.SABER_EQ - 10);
    }
    this.utils.POLVECq2BS(sk, numArray3);
    this.utils.POLVECp2BS(pk, numArray5);
    Array.Copy((Array) numArray7, 0, (Array) pk, this.SABER_POLYVECCOMPRESSEDBYTES, numArray7.Length);
  }

  public int crypto_kem_keypair(byte[] pk, byte[] sk, SecureRandom random)
  {
    this.indcpa_kem_keypair(pk, sk, random);
    for (int index = 0; index < this.SABER_INDCPA_PUBLICKEYBYTES; ++index)
      sk[index + this.SABER_INDCPA_SECRETKEYBYTES] = pk[index];
    this.symmetric.Hash_h(sk, pk, this.SABER_SECRETKEYBYTES - 64 /*0x40*/);
    byte[] numArray = new byte[32 /*0x20*/];
    random.NextBytes(numArray);
    Array.Copy((Array) numArray, 0, (Array) sk, this.SABER_SECRETKEYBYTES - 32 /*0x20*/, numArray.Length);
    return 0;
  }

  private void indcpa_kem_enc(byte[] m, byte[] seed_sp, byte[] pk, byte[] ciphertext)
  {
    short[][][] A = new short[this.SABER_L][][];
    for (int index1 = 0; index1 < this.SABER_L; ++index1)
    {
      short[][] numArray1 = new short[this.SABER_L][];
      for (int index2 = 0; index2 < this.SABER_L; ++index2)
      {
        short[] numArray2 = new short[256 /*0x0100*/];
        numArray1[index2] = numArray2;
      }
      A[index1] = numArray1;
    }
    short[][] s = new short[this.SABER_L][];
    for (int index = 0; index < this.SABER_L; ++index)
    {
      short[] numArray = new short[256 /*0x0100*/];
      s[index] = numArray;
    }
    short[][] numArray3 = new short[this.SABER_L][];
    for (int index = 0; index < this.SABER_L; ++index)
    {
      short[] numArray4 = new short[256 /*0x0100*/];
      numArray3[index] = numArray4;
    }
    short[][] numArray5 = new short[this.SABER_L][];
    for (int index = 0; index < this.SABER_L; ++index)
    {
      short[] numArray6 = new short[256 /*0x0100*/];
      numArray5[index] = numArray6;
    }
    short[] data = new short[256 /*0x0100*/];
    short[] numArray7 = new short[256 /*0x0100*/];
    byte[] seed = Arrays.CopyOfRange(pk, this.SABER_POLYVECCOMPRESSEDBYTES, pk.Length);
    this.poly.GenMatrix(A, seed);
    this.poly.GenSecret(s, seed_sp);
    this.poly.MatrixVectorMul(A, s, numArray3, 0);
    for (int index3 = 0; index3 < this.SABER_L; ++index3)
    {
      for (int index4 = 0; index4 < 256 /*0x0100*/; ++index4)
        numArray3[index3][index4] = (short) (((int) numArray3[index3][index4] + this.h1 & (int) ushort.MaxValue) >> this.SABER_EQ - 10);
    }
    this.utils.POLVECp2BS(ciphertext, numArray3);
    this.utils.BS2POLVECp(pk, numArray5);
    this.poly.InnerProd(numArray5, s, numArray7);
    this.utils.BS2POLmsg(m, data);
    for (int index = 0; index < 256 /*0x0100*/; ++index)
      numArray7[index] = (short) (((int) numArray7[index] - ((int) data[index] << 9) + this.h1 & (int) ushort.MaxValue) >> 10 - this.SABER_ET);
    this.utils.POLT2BS(ciphertext, this.SABER_POLYVECCOMPRESSEDBYTES, numArray7);
  }

  public int crypto_kem_enc(byte[] c, byte[] k, byte[] pk, SecureRandom random)
  {
    byte[] numArray1 = new byte[64 /*0x40*/];
    byte[] numArray2 = new byte[64 /*0x40*/];
    byte[] numArray3 = new byte[32 /*0x20*/];
    random.NextBytes(numArray3);
    this.symmetric.Hash_h(numArray3, numArray3, 0);
    Array.Copy((Array) numArray3, 0, (Array) numArray2, 0, 32 /*0x20*/);
    this.symmetric.Hash_h(numArray2, pk, 32 /*0x20*/);
    this.symmetric.Hash_g(numArray1, numArray2);
    this.indcpa_kem_enc(numArray2, Arrays.CopyOfRange(numArray1, 32 /*0x20*/, numArray1.Length), pk, c);
    this.symmetric.Hash_h(numArray1, c, 32 /*0x20*/);
    byte[] numArray4 = new byte[32 /*0x20*/];
    this.symmetric.Hash_h(numArray4, numArray1, 0);
    Array.Copy((Array) numArray4, 0, (Array) k, 0, this.defaultKeySize / 8);
    return 0;
  }

  private void indcpa_kem_dec(byte[] sk, byte[] ciphertext, byte[] m)
  {
    short[][] numArray1 = new short[this.SABER_L][];
    for (int index = 0; index < this.SABER_L; ++index)
    {
      short[] numArray2 = new short[256 /*0x0100*/];
      numArray1[index] = numArray2;
    }
    short[][] numArray3 = new short[this.SABER_L][];
    for (int index = 0; index < this.SABER_L; ++index)
    {
      short[] numArray4 = new short[256 /*0x0100*/];
      numArray3[index] = numArray4;
    }
    short[] numArray5 = new short[256 /*0x0100*/];
    short[] data = new short[256 /*0x0100*/];
    this.utils.BS2POLVECq(sk, 0, numArray1);
    this.utils.BS2POLVECp(ciphertext, numArray3);
    this.poly.InnerProd(numArray3, numArray1, numArray5);
    this.utils.BS2POLT(ciphertext, this.SABER_POLYVECCOMPRESSEDBYTES, data);
    for (int index = 0; index < 256 /*0x0100*/; ++index)
      numArray5[index] = (short) (((int) numArray5[index] + this.h2 - ((int) data[index] << 10 - this.SABER_ET) & (int) ushort.MaxValue) >> 9);
    this.utils.POLmsg2BS(m, numArray5);
  }

  public int crypto_kem_dec(byte[] k, byte[] c, byte[] sk)
  {
    byte[] numArray1 = new byte[this.SABER_BYTES_CCA_DEC];
    byte[] numArray2 = new byte[64 /*0x40*/];
    byte[] numArray3 = new byte[64 /*0x40*/];
    byte[] pk = Arrays.CopyOfRange(sk, this.SABER_INDCPA_SECRETKEYBYTES, sk.Length);
    this.indcpa_kem_dec(sk, c, numArray2);
    for (int index = 0; index < 32 /*0x20*/; ++index)
      numArray2[32 /*0x20*/ + index] = sk[this.SABER_SECRETKEYBYTES - 64 /*0x40*/ + index];
    this.symmetric.Hash_g(numArray3, numArray2);
    this.indcpa_kem_enc(numArray2, Arrays.CopyOfRange(numArray3, 32 /*0x20*/, numArray3.Length), pk, numArray1);
    int b = SaberEngine.verify(c, numArray1, this.SABER_BYTES_CCA_DEC);
    this.symmetric.Hash_h(numArray3, c, 32 /*0x20*/);
    SaberEngine.cmov(numArray3, sk, this.SABER_SECRETKEYBYTES - 32 /*0x20*/, 32 /*0x20*/, (byte) b);
    byte[] numArray4 = new byte[32 /*0x20*/];
    this.symmetric.Hash_h(numArray4, numArray3, 0);
    Array.Copy((Array) numArray4, 0, (Array) k, 0, this.defaultKeySize / 8);
    return 0;
  }

  private static int verify(byte[] a, byte[] b, int len)
  {
    int num = 0;
    for (int index = 0; index < len; ++index)
      num |= (int) a[index] ^ (int) b[index];
    return -num >>> 31 /*0x1F*/;
  }

  private static void cmov(byte[] r, byte[] x, int x_offset, int len, byte b)
  {
    b = -b;
    for (int index = 0; index < len; ++index)
      r[index] ^= (byte) ((uint) b & ((uint) x[index + x_offset] ^ (uint) r[index]));
  }
}
