// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Generators.DsaParametersGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Encoders;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Generators;

public class DsaParametersGenerator
{
  private IDigest digest;
  private int L;
  private int N;
  private int certainty;
  private SecureRandom random;
  private bool use186_3;
  private int usageIndex;

  public DsaParametersGenerator()
    : this((IDigest) new Sha1Digest())
  {
  }

  public DsaParametersGenerator(IDigest digest) => this.digest = digest;

  public virtual void Init(int size, int certainty, SecureRandom random)
  {
    if (!DsaParametersGenerator.IsValidDsaStrength(size))
      throw new ArgumentException("size must be from 512 - 1024 and a multiple of 64", nameof (size));
    this.use186_3 = false;
    this.L = size;
    this.N = DsaParametersGenerator.GetDefaultN(size);
    this.certainty = certainty;
    this.random = random;
  }

  public virtual void Init(DsaParameterGenerationParameters parameters)
  {
    this.use186_3 = true;
    this.L = parameters.L;
    this.N = parameters.N;
    this.certainty = parameters.Certainty;
    this.random = parameters.Random;
    this.usageIndex = parameters.UsageIndex;
    if (this.L < 1024 /*0x0400*/ || this.L > 3072 /*0x0C00*/ || this.L % 1024 /*0x0400*/ != 0)
      throw new ArgumentException("Values must be between 1024 and 3072 and a multiple of 1024", "L");
    if (this.L == 1024 /*0x0400*/ && this.N != 160 /*0xA0*/)
      throw new ArgumentException("N must be 160 for L = 1024");
    if (this.L == 2048 /*0x0800*/ && this.N != 224 /*0xE0*/ && this.N != 256 /*0x0100*/)
      throw new ArgumentException("N must be 224 or 256 for L = 2048");
    if (this.L == 3072 /*0x0C00*/ && this.N != 256 /*0x0100*/)
      throw new ArgumentException("N must be 256 for L = 3072");
    if (this.digest.GetDigestSize() * 8 < this.N)
      throw new InvalidOperationException("Digest output size too small for value of N");
  }

  public virtual DsaParameters GenerateParameters()
  {
    return !this.use186_3 ? this.GenerateParameters_FIPS186_2() : this.GenerateParameters_FIPS186_3();
  }

  protected virtual DsaParameters GenerateParameters_FIPS186_2()
  {
    byte[] numArray1 = new byte[20];
    byte[] numArray2 = new byte[20];
    byte[] numArray3 = new byte[20];
    byte[] bytes = new byte[20];
    int num = (this.L - 1) / 160 /*0xA0*/;
    byte[] numArray4 = new byte[this.L / 8];
    if (!(this.digest is Sha1Digest))
      throw new InvalidOperationException("can only use SHA-1 for generating FIPS 186-2 parameters");
label_12:
    BigInteger q;
    do
    {
      this.random.NextBytes(numArray1);
      DsaParametersGenerator.Hash(this.digest, numArray1, numArray2);
      Array.Copy((Array) numArray1, 0, (Array) numArray3, 0, numArray1.Length);
      DsaParametersGenerator.Inc(numArray3);
      DsaParametersGenerator.Hash(this.digest, numArray3, numArray3);
      for (int index = 0; index != bytes.Length; ++index)
        bytes[index] = (byte) ((uint) numArray2[index] ^ (uint) numArray3[index]);
      bytes[0] |= (byte) 128 /*0x80*/;
      bytes[19] |= (byte) 1;
      q = new BigInteger(1, bytes);
    }
    while (!q.IsProbablePrime(this.certainty));
    byte[] numArray5 = Arrays.Clone(numArray1);
    DsaParametersGenerator.Inc(numArray5);
    for (int counter = 0; counter < 4096 /*0x1000*/; ++counter)
    {
      for (int index = 0; index < num; ++index)
      {
        DsaParametersGenerator.Inc(numArray5);
        DsaParametersGenerator.Hash(this.digest, numArray5, numArray2);
        Array.Copy((Array) numArray2, 0, (Array) numArray4, numArray4.Length - (index + 1) * numArray2.Length, numArray2.Length);
      }
      DsaParametersGenerator.Inc(numArray5);
      DsaParametersGenerator.Hash(this.digest, numArray5, numArray2);
      Array.Copy((Array) numArray2, numArray2.Length - (numArray4.Length - num * numArray2.Length), (Array) numArray4, 0, numArray4.Length - num * numArray2.Length);
      numArray4[0] |= (byte) 128 /*0x80*/;
      BigInteger bigInteger = new BigInteger(1, numArray4);
      BigInteger p = bigInteger.Subtract(bigInteger.Mod(q.ShiftLeft(1)).Subtract(BigInteger.One));
      if (p.BitLength == this.L && p.IsProbablePrime(this.certainty))
      {
        BigInteger generatorFipS1862 = this.CalculateGenerator_FIPS186_2(p, q, this.random);
        return new DsaParameters(p, q, generatorFipS1862, new DsaValidationParameters(numArray1, counter));
      }
    }
    goto label_12;
  }

  protected virtual BigInteger CalculateGenerator_FIPS186_2(
    BigInteger p,
    BigInteger q,
    SecureRandom r)
  {
    BigInteger e = p.Subtract(BigInteger.One).Divide(q);
    BigInteger max = p.Subtract(BigInteger.Two);
    BigInteger generatorFipS1862;
    do
    {
      generatorFipS1862 = BigIntegers.CreateRandomInRange(BigInteger.Two, max, r).ModPow(e, p);
    }
    while (generatorFipS1862.BitLength <= 1);
    return generatorFipS1862;
  }

  protected virtual DsaParameters GenerateParameters_FIPS186_3()
  {
    IDigest digest = this.digest;
    int num1 = digest.GetDigestSize() * 8;
    byte[] numArray1 = new byte[this.N / 8];
    int num2 = (this.L - 1) / num1;
    int n1 = (this.L - 1) % num1;
    byte[] numArray2 = new byte[digest.GetDigestSize()];
label_10:
    BigInteger q;
    do
    {
      this.random.NextBytes(numArray1);
      DsaParametersGenerator.Hash(digest, numArray1, numArray2);
      q = new BigInteger(1, numArray2).Mod(BigInteger.One.ShiftLeft(this.N - 1)).SetBit(0).SetBit(this.N - 1);
    }
    while (!q.IsProbablePrime(this.certainty));
    byte[] numArray3 = Arrays.Clone(numArray1);
    int num3 = 4 * this.L;
    for (int counter = 0; counter < num3; ++counter)
    {
      BigInteger bigInteger1 = BigInteger.Zero;
      int num4 = 0;
      int n2 = 0;
      while (num4 <= num2)
      {
        DsaParametersGenerator.Inc(numArray3);
        DsaParametersGenerator.Hash(digest, numArray3, numArray2);
        BigInteger bigInteger2 = new BigInteger(1, numArray2);
        if (num4 == num2)
          bigInteger2 = bigInteger2.Mod(BigInteger.One.ShiftLeft(n1));
        bigInteger1 = bigInteger1.Add(bigInteger2.ShiftLeft(n2));
        ++num4;
        n2 += num1;
      }
      BigInteger bigInteger3 = bigInteger1.Add(BigInteger.One.ShiftLeft(this.L - 1));
      BigInteger p = bigInteger3.Subtract(bigInteger3.Mod(q.ShiftLeft(1)).Subtract(BigInteger.One));
      if (p.BitLength == this.L && p.IsProbablePrime(this.certainty))
      {
        if (this.usageIndex >= 0)
        {
          BigInteger fipS1863Verifiable = this.CalculateGenerator_FIPS186_3_Verifiable(digest, p, q, numArray1, this.usageIndex);
          if (fipS1863Verifiable != null)
            return new DsaParameters(p, q, fipS1863Verifiable, new DsaValidationParameters(numArray1, counter, this.usageIndex));
        }
        BigInteger s1863Unverifiable = this.CalculateGenerator_FIPS186_3_Unverifiable(p, q, this.random);
        return new DsaParameters(p, q, s1863Unverifiable, new DsaValidationParameters(numArray1, counter));
      }
    }
    goto label_10;
  }

  protected virtual BigInteger CalculateGenerator_FIPS186_3_Unverifiable(
    BigInteger p,
    BigInteger q,
    SecureRandom r)
  {
    return this.CalculateGenerator_FIPS186_2(p, q, r);
  }

  protected virtual BigInteger CalculateGenerator_FIPS186_3_Verifiable(
    IDigest d,
    BigInteger p,
    BigInteger q,
    byte[] seed,
    int index)
  {
    BigInteger e = p.Subtract(BigInteger.One).Divide(q);
    byte[] sourceArray = Hex.DecodeStrict("6767656E");
    byte[] numArray1 = new byte[seed.Length + sourceArray.Length + 1 + 2];
    Array.Copy((Array) seed, 0, (Array) numArray1, 0, seed.Length);
    Array.Copy((Array) sourceArray, 0, (Array) numArray1, seed.Length, sourceArray.Length);
    numArray1[numArray1.Length - 3] = (byte) index;
    byte[] numArray2 = new byte[d.GetDigestSize()];
    for (int index1 = 1; index1 < 65536 /*0x010000*/; ++index1)
    {
      DsaParametersGenerator.Inc(numArray1);
      DsaParametersGenerator.Hash(d, numArray1, numArray2);
      BigInteger fipS1863Verifiable = new BigInteger(1, numArray2).ModPow(e, p);
      if (fipS1863Verifiable.CompareTo(BigInteger.Two) >= 0)
        return fipS1863Verifiable;
    }
    return (BigInteger) null;
  }

  private static bool IsValidDsaStrength(int strength)
  {
    return strength >= 512 /*0x0200*/ && strength <= 1024 /*0x0400*/ && strength % 64 /*0x40*/ == 0;
  }

  protected static void Hash(IDigest d, byte[] input, byte[] output)
  {
    d.BlockUpdate(input, 0, input.Length);
    d.DoFinal(output, 0);
  }

  private static int GetDefaultN(int L) => L <= 1024 /*0x0400*/ ? 160 /*0xA0*/ : 256 /*0x0100*/;

  protected static void Inc(byte[] buf)
  {
    for (int index = buf.Length - 1; index >= 0; --index)
    {
      byte num = (byte) ((uint) buf[index] + 1U);
      buf[index] = num;
      if (num != (byte) 0)
        break;
    }
  }
}
