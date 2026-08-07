// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Prng.SP800SecureRandomBuilder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Prng.Drbg;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Prng;

public class SP800SecureRandomBuilder
{
  private readonly SecureRandom mRandom;
  private readonly IEntropySourceProvider mEntropySourceProvider;
  private byte[] mPersonalizationString;
  private int mSecurityStrength = 256 /*0x0100*/;
  private int mEntropyBitsRequired = 256 /*0x0100*/;

  public SP800SecureRandomBuilder()
    : this(CryptoServicesRegistrar.GetSecureRandom(), false)
  {
  }

  public SP800SecureRandomBuilder(SecureRandom entropySource, bool predictionResistant)
  {
    this.mRandom = entropySource != null ? entropySource : throw new ArgumentNullException(nameof (entropySource));
    this.mEntropySourceProvider = (IEntropySourceProvider) new BasicEntropySourceProvider(entropySource, predictionResistant);
  }

  public SP800SecureRandomBuilder(IEntropySourceProvider entropySourceProvider)
  {
    this.mRandom = (SecureRandom) null;
    this.mEntropySourceProvider = entropySourceProvider;
  }

  public SP800SecureRandomBuilder SetPersonalizationString(byte[] personalizationString)
  {
    this.mPersonalizationString = personalizationString;
    return this;
  }

  public SP800SecureRandomBuilder SetSecurityStrength(int securityStrength)
  {
    this.mSecurityStrength = securityStrength;
    return this;
  }

  public SP800SecureRandomBuilder SetEntropyBitsRequired(int entropyBitsRequired)
  {
    this.mEntropyBitsRequired = entropyBitsRequired;
    return this;
  }

  public SP800SecureRandom BuildHash(IDigest digest, byte[] nonce, bool predictionResistant)
  {
    return new SP800SecureRandom(this.mRandom, this.mEntropySourceProvider.Get(this.mEntropyBitsRequired), (IDrbgProvider) new SP800SecureRandomBuilder.HashDrbgProvider(digest, nonce, this.mPersonalizationString, this.mSecurityStrength), predictionResistant);
  }

  public SP800SecureRandom BuildCtr(
    IBlockCipher cipher,
    int keySizeInBits,
    byte[] nonce,
    bool predictionResistant)
  {
    return new SP800SecureRandom(this.mRandom, this.mEntropySourceProvider.Get(this.mEntropyBitsRequired), (IDrbgProvider) new SP800SecureRandomBuilder.CtrDrbgProvider(cipher, keySizeInBits, nonce, this.mPersonalizationString, this.mSecurityStrength), predictionResistant);
  }

  public SP800SecureRandom BuildHMac(IMac hMac, byte[] nonce, bool predictionResistant)
  {
    return new SP800SecureRandom(this.mRandom, this.mEntropySourceProvider.Get(this.mEntropyBitsRequired), (IDrbgProvider) new SP800SecureRandomBuilder.HMacDrbgProvider(hMac, nonce, this.mPersonalizationString, this.mSecurityStrength), predictionResistant);
  }

  private class HashDrbgProvider : IDrbgProvider
  {
    private readonly IDigest mDigest;
    private readonly byte[] mNonce;
    private readonly byte[] mPersonalizationString;
    private readonly int mSecurityStrength;

    public HashDrbgProvider(
      IDigest digest,
      byte[] nonce,
      byte[] personalizationString,
      int securityStrength)
    {
      this.mDigest = digest;
      this.mNonce = nonce;
      this.mPersonalizationString = personalizationString;
      this.mSecurityStrength = securityStrength;
    }

    public ISP80090Drbg Get(IEntropySource entropySource)
    {
      return (ISP80090Drbg) new HashSP800Drbg(this.mDigest, this.mSecurityStrength, entropySource, this.mPersonalizationString, this.mNonce);
    }
  }

  private class HMacDrbgProvider : IDrbgProvider
  {
    private readonly IMac mHMac;
    private readonly byte[] mNonce;
    private readonly byte[] mPersonalizationString;
    private readonly int mSecurityStrength;

    public HMacDrbgProvider(
      IMac hMac,
      byte[] nonce,
      byte[] personalizationString,
      int securityStrength)
    {
      this.mHMac = hMac;
      this.mNonce = nonce;
      this.mPersonalizationString = personalizationString;
      this.mSecurityStrength = securityStrength;
    }

    public ISP80090Drbg Get(IEntropySource entropySource)
    {
      return (ISP80090Drbg) new HMacSP800Drbg(this.mHMac, this.mSecurityStrength, entropySource, this.mPersonalizationString, this.mNonce);
    }
  }

  private class CtrDrbgProvider : IDrbgProvider
  {
    private readonly IBlockCipher mBlockCipher;
    private readonly int mKeySizeInBits;
    private readonly byte[] mNonce;
    private readonly byte[] mPersonalizationString;
    private readonly int mSecurityStrength;

    public CtrDrbgProvider(
      IBlockCipher blockCipher,
      int keySizeInBits,
      byte[] nonce,
      byte[] personalizationString,
      int securityStrength)
    {
      this.mBlockCipher = blockCipher;
      this.mKeySizeInBits = keySizeInBits;
      this.mNonce = nonce;
      this.mPersonalizationString = personalizationString;
      this.mSecurityStrength = securityStrength;
    }

    public ISP80090Drbg Get(IEntropySource entropySource)
    {
      return (ISP80090Drbg) new CtrSP800Drbg(this.mBlockCipher, this.mKeySizeInBits, this.mSecurityStrength, entropySource, this.mPersonalizationString, this.mNonce);
    }
  }
}
