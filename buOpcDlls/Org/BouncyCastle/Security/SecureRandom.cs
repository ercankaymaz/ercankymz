// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Security.SecureRandom
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Prng;
using Org.BouncyCastle.Crypto.Utilities;
using System;
using System.Threading;

#nullable disable
namespace Org.BouncyCastle.Security;

public class SecureRandom : Random
{
  private static long counter = DateTime.UtcNow.Ticks;
  private static readonly SecureRandom MasterRandom = new SecureRandom((IRandomGenerator) new CryptoApiRandomGenerator());
  internal static readonly SecureRandom ArbitraryRandom = new SecureRandom((IRandomGenerator) new VmpcRandomGenerator(), 16 /*0x10*/);
  protected readonly IRandomGenerator generator;
  private static readonly double DoubleScale = 1.0 / Convert.ToDouble(9007199254740992L /*0x20000000000000*/);

  private static long NextCounterValue() => Interlocked.Increment(ref SecureRandom.counter);

  private static DigestRandomGenerator CreatePrng(string digestName, bool autoSeed)
  {
    IDigest digest = DigestUtilities.GetDigest(digestName);
    if (digest == null)
      return (DigestRandomGenerator) null;
    DigestRandomGenerator generator = new DigestRandomGenerator(digest);
    if (autoSeed)
      SecureRandom.AutoSeed((IRandomGenerator) generator, 2 * digest.GetDigestSize());
    return generator;
  }

  public static byte[] GetNextBytes(SecureRandom secureRandom, int length)
  {
    byte[] buffer = new byte[length];
    secureRandom.NextBytes(buffer);
    return buffer;
  }

  public static SecureRandom GetInstance(string algorithm)
  {
    return SecureRandom.GetInstance(algorithm, true);
  }

  public static SecureRandom GetInstance(string algorithm, bool autoSeed)
  {
    if (algorithm == null)
      throw new ArgumentNullException(nameof (algorithm));
    if (algorithm.EndsWith("PRNG", StringComparison.OrdinalIgnoreCase))
    {
      DigestRandomGenerator prng = SecureRandom.CreatePrng(algorithm.Substring(0, algorithm.Length - "PRNG".Length), autoSeed);
      if (prng != null)
        return new SecureRandom((IRandomGenerator) prng);
    }
    throw new ArgumentException("Unrecognised PRNG algorithm: " + algorithm, nameof (algorithm));
  }

  public SecureRandom()
    : this((IRandomGenerator) SecureRandom.CreatePrng("SHA256", true))
  {
  }

  public SecureRandom(IRandomGenerator generator)
    : base(0)
  {
    this.generator = generator;
  }

  public SecureRandom(IRandomGenerator generator, int autoSeedLengthInBytes)
    : base(0)
  {
    SecureRandom.AutoSeed(generator, autoSeedLengthInBytes);
    this.generator = generator;
  }

  public virtual byte[] GenerateSeed(int length)
  {
    return SecureRandom.GetNextBytes(SecureRandom.MasterRandom, length);
  }

  public virtual void SetSeed(byte[] seed) => this.generator.AddSeedMaterial(seed);

  public virtual void SetSeed(long seed) => this.generator.AddSeedMaterial(seed);

  public override int Next() => this.NextInt() & int.MaxValue;

  public override int Next(int maxValue)
  {
    if (maxValue < 2)
    {
      if (maxValue < 0)
        throw new ArgumentOutOfRangeException(nameof (maxValue), "cannot be negative");
      return 0;
    }
    if ((maxValue & maxValue - 1) == 0)
      return (int) ((long) (this.NextInt() & int.MaxValue) * (long) maxValue >> 31 /*0x1F*/);
    int num1;
    int num2;
    do
    {
      num1 = this.NextInt() & int.MaxValue;
      num2 = num1 % maxValue;
    }
    while (num1 - num2 + (maxValue - 1) < 0);
    return num2;
  }

  public override int Next(int minValue, int maxValue)
  {
    if (maxValue <= minValue)
      return maxValue == minValue ? minValue : throw new ArgumentException("maxValue cannot be less than minValue");
    int maxValue1 = maxValue - minValue;
    if (maxValue1 > 0)
      return minValue + this.Next(maxValue1);
    int num;
    do
    {
      num = this.NextInt();
    }
    while (num < minValue || num >= maxValue);
    return num;
  }

  public override void NextBytes(byte[] buf) => this.generator.NextBytes(buf);

  public virtual void NextBytes(byte[] buf, int off, int len)
  {
    this.generator.NextBytes(buf, off, len);
  }

  public override double NextDouble()
  {
    return Convert.ToDouble((ulong) (this.NextLong() >>> 11)) * SecureRandom.DoubleScale;
  }

  public virtual int NextInt()
  {
    byte[] numArray = new byte[4];
    this.NextBytes(numArray);
    return (int) Pack.BE_To_UInt32(numArray);
  }

  public virtual long NextLong()
  {
    byte[] numArray = new byte[8];
    this.NextBytes(numArray);
    return (long) Pack.BE_To_UInt64(numArray);
  }

  private static void AutoSeed(IRandomGenerator generator, int seedLength)
  {
    generator.AddSeedMaterial(SecureRandom.NextCounterValue());
    byte[] numArray = new byte[seedLength];
    SecureRandom.MasterRandom.NextBytes(numArray);
    generator.AddSeedMaterial(numArray);
  }
}
