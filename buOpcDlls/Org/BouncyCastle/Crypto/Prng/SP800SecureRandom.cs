// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Prng.SP800SecureRandom
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Prng.Drbg;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Crypto.Prng;

public class SP800SecureRandom : SecureRandom
{
  private readonly IDrbgProvider mDrbgProvider;
  private readonly bool mPredictionResistant;
  private readonly SecureRandom mRandomSource;
  private readonly IEntropySource mEntropySource;
  private ISP80090Drbg mDrbg;

  internal SP800SecureRandom(
    SecureRandom randomSource,
    IEntropySource entropySource,
    IDrbgProvider drbgProvider,
    bool predictionResistant)
    : base((IRandomGenerator) null)
  {
    this.mRandomSource = randomSource;
    this.mEntropySource = entropySource;
    this.mDrbgProvider = drbgProvider;
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
      if (this.mDrbg == null)
        this.mDrbg = this.mDrbgProvider.Get(this.mEntropySource);
      if (this.mDrbg.Generate(buf, off, len, (byte[]) null, this.mPredictionResistant) >= 0)
        return;
      this.mDrbg.Reseed((byte[]) null);
      this.mDrbg.Generate(buf, off, len, (byte[]) null, this.mPredictionResistant);
    }
  }

  public override byte[] GenerateSeed(int numBytes)
  {
    return EntropyUtilities.GenerateSeed(this.mEntropySource, numBytes);
  }

  public virtual void Reseed(byte[] additionalInput)
  {
    lock (this)
    {
      if (this.mDrbg == null)
        this.mDrbg = this.mDrbgProvider.Get(this.mEntropySource);
      this.mDrbg.Reseed(additionalInput);
    }
  }
}
