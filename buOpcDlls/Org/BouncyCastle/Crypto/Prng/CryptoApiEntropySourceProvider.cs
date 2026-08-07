// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Prng.CryptoApiEntropySourceProvider
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Security.Cryptography;

#nullable disable
namespace Org.BouncyCastle.Crypto.Prng;

public class CryptoApiEntropySourceProvider : IEntropySourceProvider
{
  private readonly RandomNumberGenerator mRng;
  private readonly bool mPredictionResistant;

  public CryptoApiEntropySourceProvider()
    : this(RandomNumberGenerator.Create(), true)
  {
  }

  public CryptoApiEntropySourceProvider(RandomNumberGenerator rng, bool isPredictionResistant)
  {
    this.mRng = rng != null ? rng : throw new ArgumentNullException(nameof (rng));
    this.mPredictionResistant = isPredictionResistant;
  }

  public IEntropySource Get(int bitsRequired)
  {
    return (IEntropySource) new CryptoApiEntropySourceProvider.CryptoApiEntropySource(this.mRng, this.mPredictionResistant, bitsRequired);
  }

  private class CryptoApiEntropySource : IEntropySource
  {
    private readonly RandomNumberGenerator mRng;
    private readonly bool mPredictionResistant;
    private readonly int mEntropySize;

    internal CryptoApiEntropySource(
      RandomNumberGenerator rng,
      bool predictionResistant,
      int entropySize)
    {
      this.mRng = rng;
      this.mPredictionResistant = predictionResistant;
      this.mEntropySize = entropySize;
    }

    bool IEntropySource.IsPredictionResistant => this.mPredictionResistant;

    byte[] IEntropySource.GetEntropy()
    {
      byte[] data = new byte[(this.mEntropySize + 7) / 8];
      this.mRng.GetBytes(data);
      return data;
    }

    int IEntropySource.EntropySize => this.mEntropySize;
  }
}
