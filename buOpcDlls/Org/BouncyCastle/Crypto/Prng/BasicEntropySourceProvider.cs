// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Prng.BasicEntropySourceProvider
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Prng;

public class BasicEntropySourceProvider : IEntropySourceProvider
{
  private readonly SecureRandom mSecureRandom;
  private readonly bool mPredictionResistant;

  public BasicEntropySourceProvider(SecureRandom secureRandom, bool isPredictionResistant)
  {
    this.mSecureRandom = secureRandom != null ? secureRandom : throw new ArgumentNullException(nameof (secureRandom));
    this.mPredictionResistant = isPredictionResistant;
  }

  public IEntropySource Get(int bitsRequired)
  {
    return (IEntropySource) new BasicEntropySourceProvider.BasicEntropySource(this.mSecureRandom, this.mPredictionResistant, bitsRequired);
  }

  private class BasicEntropySource : IEntropySource
  {
    private readonly SecureRandom mSecureRandom;
    private readonly bool mPredictionResistant;
    private readonly int mEntropySize;

    internal BasicEntropySource(
      SecureRandom secureRandom,
      bool predictionResistant,
      int entropySize)
    {
      this.mSecureRandom = secureRandom != null ? secureRandom : throw new ArgumentNullException(nameof (secureRandom));
      this.mPredictionResistant = predictionResistant;
      this.mEntropySize = entropySize;
    }

    bool IEntropySource.IsPredictionResistant => this.mPredictionResistant;

    byte[] IEntropySource.GetEntropy()
    {
      return SecureRandom.GetNextBytes(this.mSecureRandom, (this.mEntropySize + 7) / 8);
    }

    int IEntropySource.EntropySize => this.mEntropySize;
  }
}
