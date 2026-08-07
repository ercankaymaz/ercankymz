// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Hqc.HqcEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Hqc;

internal class HqcEngine
{
  private int n;
  private int n1;
  private int n2;
  private int k;
  private int delta;
  private int w;
  private int wr;
  private int we;
  private int g;
  private int rejectionThreshold;
  private int fft;
  private int mulParam;
  private int SEED_SIZE = 40;
  private byte G_FCT_DOMAIN = 3;
  private byte H_FCT_DOMAIN = 4;
  private byte K_FCT_DOMAIN = 5;
  private int N_BYTE;
  private int n1n2;
  private int N_BYTE_64;
  private int K_BYTE;
  private int K_BYTE_64;
  private int N1_BYTE_64;
  private int N1N2_BYTE_64;
  private int N1N2_BYTE;
  private int N1_BYTE;
  private int SALT_SIZE_BYTES = 16 /*0x10*/;
  private int[] generatorPoly;
  private int SHA512_BYTES = 64 /*0x40*/;
  private ulong RED_MASK;
  private GF2PolynomialCalculator gfCalculator;

  public HqcEngine(
    int n,
    int n1,
    int n2,
    int k,
    int g,
    int delta,
    int w,
    int wr,
    int we,
    int rejectionThreshold,
    int fft,
    int[] generatorPoly)
  {
    this.n = n;
    this.k = k;
    this.delta = delta;
    this.w = w;
    this.wr = wr;
    this.we = we;
    this.n1 = n1;
    this.n2 = n2;
    this.n1n2 = n1 * n2;
    this.generatorPoly = generatorPoly;
    this.g = g;
    this.rejectionThreshold = rejectionThreshold;
    this.fft = fft;
    this.mulParam = (n2 + (int) sbyte.MaxValue) / 128 /*0x80*/;
    this.N_BYTE = Utils.GetByteSizeFromBitSize(n);
    this.K_BYTE = k;
    this.N_BYTE_64 = Utils.GetByte64SizeFromBitSize(n);
    this.K_BYTE_64 = Utils.GetByteSizeFromBitSize(k);
    this.N1_BYTE_64 = Utils.GetByteSizeFromBitSize(n1);
    this.N1N2_BYTE_64 = Utils.GetByte64SizeFromBitSize(n1 * n2);
    this.N1N2_BYTE = Utils.GetByteSizeFromBitSize(n1 * n2);
    this.N1_BYTE = Utils.GetByteSizeFromBitSize(n1);
    this.RED_MASK = (ulong) ((1L << n % 64 /*0x40*/) - 1L);
    this.gfCalculator = new GF2PolynomialCalculator(this.N_BYTE_64, n, this.RED_MASK);
  }

  public void GenKeyPair(byte[] pk, byte[] sk, byte[] seed)
  {
    byte[] numArray1 = new byte[this.SEED_SIZE];
    HqcKeccakRandomGenerator keccakRandomGenerator = new HqcKeccakRandomGenerator(256 /*0x0100*/);
    keccakRandomGenerator.RandomGeneratorInit(seed, (byte[]) null, seed.Length, 0);
    keccakRandomGenerator.Squeeze(numArray1, 40);
    HqcKeccakRandomGenerator random1 = new HqcKeccakRandomGenerator(256 /*0x0100*/);
    random1.SeedExpanderInit(numArray1, numArray1.Length);
    long[] numArray2 = new long[this.N_BYTE_64];
    long[] numArray3 = new long[this.N_BYTE_64];
    this.GenerateRandomFixedWeight(numArray2, random1, this.w);
    this.GenerateRandomFixedWeight(numArray3, random1, this.w);
    byte[] numArray4 = new byte[this.SEED_SIZE];
    keccakRandomGenerator.Squeeze(numArray4, 40);
    HqcKeccakRandomGenerator random2 = new HqcKeccakRandomGenerator(256 /*0x0100*/);
    random2.SeedExpanderInit(numArray4, numArray4.Length);
    long[] numArray5 = new long[this.N_BYTE_64];
    this.GeneratePublicKeyH(numArray5, random2);
    long[] numArray6 = new long[this.N_BYTE_64];
    this.gfCalculator.MultLongs(numArray6, numArray3, numArray5);
    GF2PolynomialCalculator.AddLongs(numArray6, numArray6, numArray2);
    byte[] numArray7 = new byte[this.N_BYTE];
    Utils.FromLongArrayToByteArray(numArray7, numArray6);
    byte[] numArray8 = Arrays.Concatenate(numArray4, numArray7);
    byte[] sourceArray = Arrays.Concatenate(numArray1, numArray8);
    Array.Copy((Array) numArray8, 0, (Array) pk, 0, numArray8.Length);
    Array.Copy((Array) sourceArray, 0, (Array) sk, 0, sourceArray.Length);
  }

  public void Encaps(
    byte[] u,
    byte[] v,
    byte[] K,
    byte[] d,
    byte[] pk,
    byte[] seed,
    byte[] salt)
  {
    byte[] numArray1 = new byte[this.K_BYTE];
    byte[] output = new byte[this.SEED_SIZE];
    HqcKeccakRandomGenerator keccakRandomGenerator1 = new HqcKeccakRandomGenerator(256 /*0x0100*/);
    keccakRandomGenerator1.RandomGeneratorInit(seed, (byte[]) null, seed.Length, 0);
    keccakRandomGenerator1.Squeeze(output, 40);
    keccakRandomGenerator1.Squeeze(new byte[this.SEED_SIZE], 40);
    keccakRandomGenerator1.Squeeze(numArray1, this.K_BYTE);
    byte[] numArray2 = new byte[this.SHA512_BYTES];
    byte[] numArray3 = new byte[this.K_BYTE + this.SEED_SIZE + this.SALT_SIZE_BYTES];
    keccakRandomGenerator1.Squeeze(salt, this.SALT_SIZE_BYTES);
    Array.Copy((Array) numArray1, 0, (Array) numArray3, 0, numArray1.Length);
    Array.Copy((Array) pk, 0, (Array) numArray3, this.K_BYTE, this.SEED_SIZE);
    Array.Copy((Array) salt, 0, (Array) numArray3, this.K_BYTE + this.SEED_SIZE, this.SALT_SIZE_BYTES);
    HqcKeccakRandomGenerator keccakRandomGenerator2 = new HqcKeccakRandomGenerator(256 /*0x0100*/);
    keccakRandomGenerator2.SHAKE256_512_ds(numArray2, numArray3, numArray3.Length, new byte[1]
    {
      this.G_FCT_DOMAIN
    });
    long[] h = new long[this.N_BYTE_64];
    byte[] s = new byte[this.N_BYTE];
    this.ExtractPublicKeys(h, s, pk);
    long[] numArray4 = new long[this.N1N2_BYTE_64];
    this.Encrypt(u, numArray4, h, s, numArray1, numArray2);
    Utils.FromLongArrayToByteArray(v, numArray4);
    keccakRandomGenerator2.SHAKE256_512_ds(d, numArray1, numArray1.Length, new byte[1]
    {
      this.H_FCT_DOMAIN
    });
    byte[] numArray5 = new byte[this.K_BYTE + this.N_BYTE + this.N1N2_BYTE];
    byte[] input = Arrays.Concatenate(Arrays.Concatenate(numArray1, u), v);
    keccakRandomGenerator2.SHAKE256_512_ds(K, input, input.Length, new byte[1]
    {
      this.K_FCT_DOMAIN
    });
  }

  public void Decaps(byte[] ss, byte[] ct, byte[] sk)
  {
    long[] x = new long[this.N_BYTE_64];
    long[] y = new long[this.N_BYTE_64];
    byte[] numArray1 = new byte[40 + this.N_BYTE];
    this.ExtractKeysFromSecretKeys(x, y, numArray1, sk);
    byte[] numArray2 = new byte[this.N_BYTE];
    byte[] numArray3 = new byte[this.N1N2_BYTE];
    byte[] numArray4 = new byte[this.SHA512_BYTES];
    byte[] numArray5 = new byte[this.SALT_SIZE_BYTES];
    HqcEngine.ExtractCiphertexts(numArray2, numArray3, numArray4, numArray5, ct);
    byte[] numArray6 = new byte[this.k];
    this.Decrypt(numArray6, numArray6, numArray2, numArray3, y);
    byte[] numArray7 = new byte[this.SHA512_BYTES];
    byte[] numArray8 = new byte[this.K_BYTE + this.SALT_SIZE_BYTES + this.SEED_SIZE];
    Array.Copy((Array) numArray6, 0, (Array) numArray8, 0, numArray6.Length);
    Array.Copy((Array) numArray1, 0, (Array) numArray8, this.K_BYTE, this.SEED_SIZE);
    Array.Copy((Array) numArray5, 0, (Array) numArray8, this.K_BYTE + this.SEED_SIZE, this.SALT_SIZE_BYTES);
    HqcKeccakRandomGenerator keccakRandomGenerator = new HqcKeccakRandomGenerator(256 /*0x0100*/);
    keccakRandomGenerator.SHAKE256_512_ds(numArray7, numArray8, numArray8.Length, new byte[1]
    {
      this.G_FCT_DOMAIN
    });
    long[] h = new long[this.N_BYTE_64];
    byte[] s = new byte[this.N_BYTE];
    this.ExtractPublicKeys(h, s, numArray1);
    byte[] numArray9 = new byte[this.N_BYTE];
    byte[] numArray10 = new byte[this.N1N2_BYTE];
    long[] numArray11 = new long[this.N1N2_BYTE_64];
    this.Encrypt(numArray9, numArray11, h, s, numArray6, numArray7);
    Utils.FromLongArrayToByteArray(numArray10, numArray11);
    byte[] numArray12 = new byte[this.SHA512_BYTES];
    keccakRandomGenerator.SHAKE256_512_ds(numArray12, numArray6, numArray6.Length, new byte[1]
    {
      this.H_FCT_DOMAIN
    });
    byte[] numArray13 = new byte[this.K_BYTE + this.N_BYTE + this.N1N2_BYTE];
    byte[] input = Arrays.Concatenate(Arrays.Concatenate(numArray6, numArray2), numArray3);
    keccakRandomGenerator.SHAKE256_512_ds(ss, input, input.Length, new byte[1]
    {
      this.K_FCT_DOMAIN
    });
    int num = 1;
    if (!Arrays.AreEqual(numArray2, numArray9))
      num = 0;
    if (!Arrays.AreEqual(numArray3, numArray10))
      num = 0;
    if (!Arrays.AreEqual(numArray4, numArray12))
      num = 0;
    if (num != 0)
      return;
    for (int index = 0; index < this.GetSessionKeySize(); ++index)
      ss[index] = (byte) 0;
  }

  internal int GetSessionKeySize() => this.SHA512_BYTES;

  private void Encrypt(byte[] u, long[] v, long[] h, byte[] s, byte[] m, byte[] theta)
  {
    HqcKeccakRandomGenerator random = new HqcKeccakRandomGenerator(256 /*0x0100*/);
    random.SeedExpanderInit(theta, this.SEED_SIZE);
    long[] numArray1 = new long[this.N_BYTE_64];
    long[] numArray2 = new long[this.N_BYTE_64];
    long[] numArray3 = new long[this.N_BYTE_64];
    this.GenerateRandomFixedWeight(numArray2, random, this.wr);
    this.GenerateRandomFixedWeight(numArray3, random, this.wr);
    this.GenerateRandomFixedWeight(numArray1, random, this.we);
    long[] numArray4 = new long[this.N_BYTE_64];
    this.gfCalculator.MultLongs(numArray4, numArray3, h);
    GF2PolynomialCalculator.AddLongs(numArray4, numArray4, numArray2);
    Utils.FromLongArrayToByteArray(u, numArray4);
    byte[] numArray5 = new byte[this.n1];
    long[] numArray6 = new long[this.N1N2_BYTE_64];
    long[] numArray7 = new long[this.N_BYTE_64];
    ReedSolomon.Encode(numArray5, m, this.K_BYTE * 8, this.n1, this.k, this.g, this.generatorPoly);
    ReedMuller.Encode(numArray6, numArray5, this.n1, this.mulParam);
    Array.Copy((Array) numArray6, 0, (Array) numArray7, 0, numArray6.Length);
    long[] numArray8 = new long[this.N_BYTE_64];
    Utils.FromByteArrayToLongArray(numArray8, s);
    long[] numArray9 = new long[this.N_BYTE_64];
    this.gfCalculator.MultLongs(numArray9, numArray3, numArray8);
    GF2PolynomialCalculator.AddLongs(numArray9, numArray9, numArray7);
    GF2PolynomialCalculator.AddLongs(numArray9, numArray9, numArray1);
    Utils.ResizeArray(v, this.n1n2, numArray9, this.n, this.N1N2_BYTE_64, this.N1N2_BYTE_64);
  }

  private void Decrypt(byte[] output, byte[] m, byte[] u, byte[] v, long[] y)
  {
    long[] numArray1 = new long[this.N_BYTE_64];
    Utils.FromByteArrayToLongArray(numArray1, u);
    long[] numArray2 = new long[this.N1N2_BYTE_64];
    Utils.FromByteArrayToLongArray(numArray2, v);
    long[] numArray3 = new long[this.N_BYTE_64];
    Array.Copy((Array) numArray2, 0, (Array) numArray3, 0, numArray2.Length);
    long[] numArray4 = new long[this.N_BYTE_64];
    this.gfCalculator.MultLongs(numArray4, y, numArray1);
    GF2PolynomialCalculator.AddLongs(numArray4, numArray4, numArray3);
    byte[] numArray5 = new byte[this.n1];
    ReedMuller.Decode(numArray5, numArray4, this.n1, this.mulParam);
    ReedSolomon.Decode(m, numArray5, this.n1, this.fft, this.delta, this.k, this.g);
    Array.Copy((Array) m, 0, (Array) output, 0, output.Length);
  }

  private void GenerateRandomFixedWeight(
    long[] output,
    HqcKeccakRandomGenerator random,
    int weight)
  {
    uint[] ns = new uint[this.wr];
    byte[] numArray1 = new byte[this.wr * 4];
    int[] numArray2 = new int[this.wr];
    int[] numArray3 = new int[this.wr];
    long[] numArray4 = new long[this.wr];
    random.ExpandSeed(numArray1, 4 * weight);
    Pack.LE_To_UInt32(numArray1, 0, ns, 0, ns.Length);
    for (int index = 0; index < weight; ++index)
      numArray2[index] = (int) ((long) index + ((long) ns[index] & (long) uint.MaxValue) % (long) (this.n - index));
    for (int index1 = weight - 1; index1 >= 0; --index1)
    {
      int num1 = 0;
      for (int index2 = index1 + 1; index2 < weight; ++index2)
      {
        if (numArray2[index2] == numArray2[index1])
          num1 |= 1;
      }
      int num2 = -num1;
      numArray2[index1] = num2 & index1 ^ ~num2 & numArray2[index1];
    }
    for (int index = 0; index < weight; ++index)
    {
      numArray3[index] = numArray2[index] >>> 6;
      int num = numArray2[index] & 63 /*0x3F*/;
      numArray4[index] = 1L << num;
    }
    for (int index3 = 0; index3 < this.N_BYTE_64; ++index3)
    {
      long num3 = 0;
      for (int index4 = 0; index4 < weight; ++index4)
      {
        int num4 = index3 - numArray3[index4];
        long num5 = (long) -(1 ^ (num4 | -num4) >>> 31 /*0x1F*/);
        num3 |= numArray4[index4] & num5;
      }
      output[index3] |= num3;
    }
  }

  private void GeneratePublicKeyH(long[] output, HqcKeccakRandomGenerator random)
  {
    byte[] numArray1 = new byte[this.N_BYTE];
    random.ExpandSeed(numArray1, this.N_BYTE);
    long[] numArray2 = new long[this.N_BYTE_64];
    Utils.FromByteArrayToLongArray(numArray2, numArray1);
    numArray2[this.N_BYTE_64 - 1] &= Utils.BitMask((ulong) this.n, 64UL /*0x40*/);
    Array.Copy((Array) numArray2, 0, (Array) output, 0, output.Length);
  }

  private void ExtractPublicKeys(long[] h, byte[] s, byte[] pk)
  {
    byte[] numArray1 = new byte[this.SEED_SIZE];
    Array.Copy((Array) pk, 0, (Array) numArray1, 0, numArray1.Length);
    HqcKeccakRandomGenerator random = new HqcKeccakRandomGenerator(256 /*0x0100*/);
    random.SeedExpanderInit(numArray1, numArray1.Length);
    long[] numArray2 = new long[this.N_BYTE_64];
    this.GeneratePublicKeyH(numArray2, random);
    Array.Copy((Array) numArray2, 0, (Array) h, 0, h.Length);
    Array.Copy((Array) pk, 40, (Array) s, 0, s.Length);
  }

  private void ExtractKeysFromSecretKeys(long[] x, long[] y, byte[] pk, byte[] sk)
  {
    byte[] numArray = new byte[this.SEED_SIZE];
    Array.Copy((Array) sk, 0, (Array) numArray, 0, numArray.Length);
    HqcKeccakRandomGenerator random = new HqcKeccakRandomGenerator(256 /*0x0100*/);
    random.SeedExpanderInit(numArray, numArray.Length);
    this.GenerateRandomFixedWeight(x, random, this.w);
    this.GenerateRandomFixedWeight(y, random, this.w);
    Array.Copy((Array) sk, this.SEED_SIZE, (Array) pk, 0, pk.Length);
  }

  private static void ExtractCiphertexts(byte[] u, byte[] v, byte[] d, byte[] salt, byte[] ct)
  {
    Array.Copy((Array) ct, 0, (Array) u, 0, u.Length);
    Array.Copy((Array) ct, u.Length, (Array) v, 0, v.Length);
    Array.Copy((Array) ct, u.Length + v.Length, (Array) d, 0, d.Length);
    Array.Copy((Array) ct, u.Length + v.Length + d.Length, (Array) salt, 0, salt.Length);
  }
}
