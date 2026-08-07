// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Prng.X931SecureRandom
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Crypto.Prng;

public class X931SecureRandom : SecureRandom
{
  private readonly bool mPredictionResistant;
  private readonly SecureRandom mRandomSource;
  private readonly X931Rng mDrbg;

  internal X931SecureRandom(SecureRandom randomSource, X931Rng drbg, bool predictionResistant)
    : base((IRandomGenerator) null)
  {
    this.mRandomSource = randomSource;
    this.mDrbg = drbg;
    this.mPredictionResistant = predictionResistant;
  }

  public override void SetSeed(byte[] seed)
  {
    lock (this)
    {
      if (this.mRandomSource == null)
        return;
      this.mRandomSource.SetSeed(seed);
    }
  }

  public override void SetSeed(long seed)
  {
    lock (this)
    {
      if (this.mRandomSource == null)
        return;
      this.mRandomSource.SetSeed(seed);
    }
  }

  public override void NextBytes(byte[] bytes) => this.NextBytes(bytes, 0, bytes.Length);

  public override void NextBytes(byte[] buf, int off, int len)
  {
    lock (this)
    {
      if (this.mDrbg.Generate(buf, off, len, this.mPredictionResistant) >= 0)
        return;
      this.mDrbg.Reseed();
      this.mDrbg.Generate(buf, off, len, this.mPredictionResistant);
    }
  }

  public override byte[] GenerateSeed(int numBytes)
  {
    return EntropyUtilities.GenerateSeed(this.mDrbg.EntropySource, numBytes);
  }
}
