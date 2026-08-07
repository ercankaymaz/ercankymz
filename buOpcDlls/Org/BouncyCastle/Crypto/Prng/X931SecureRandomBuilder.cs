// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Prng.X931SecureRandomBuilder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Date;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Prng;

public class X931SecureRandomBuilder
{
  private readonly SecureRandom mRandom;
  private IEntropySourceProvider mEntropySourceProvider;
  private byte[] mDateTimeVector;

  public X931SecureRandomBuilder()
    : this(CryptoServicesRegistrar.GetSecureRandom(), false)
  {
  }

  public X931SecureRandomBuilder(SecureRandom entropySource, bool predictionResistant)
  {
    this.mRandom = entropySource != null ? entropySource : throw new ArgumentNullException(nameof (entropySource));
    this.mEntropySourceProvider = (IEntropySourceProvider) new BasicEntropySourceProvider(this.mRandom, predictionResistant);
  }

  public X931SecureRandomBuilder(IEntropySourceProvider entropySourceProvider)
  {
    this.mRandom = (SecureRandom) null;
    this.mEntropySourceProvider = entropySourceProvider;
  }

  public X931SecureRandomBuilder SetDateTimeVector(byte[] dateTimeVector)
  {
    this.mDateTimeVector = dateTimeVector;
    return this;
  }

  public X931SecureRandom Build(IBlockCipher engine, KeyParameter key, bool predictionResistant)
  {
    if (this.mDateTimeVector == null)
    {
      this.mDateTimeVector = new byte[engine.GetBlockSize()];
      Pack.UInt64_To_BE((ulong) DateTimeUtilities.CurrentUnixMs(), this.mDateTimeVector, 0);
    }
    engine.Init(true, (ICipherParameters) key);
    return new X931SecureRandom(this.mRandom, new X931Rng(engine, this.mDateTimeVector, this.mEntropySourceProvider.Get(engine.GetBlockSize() * 8)), predictionResistant);
  }
}
