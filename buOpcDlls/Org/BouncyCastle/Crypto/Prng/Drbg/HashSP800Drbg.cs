// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Prng.Drbg.HashSP800Drbg
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Crypto.Prng.Drbg;

public sealed class HashSP800Drbg : ISP80090Drbg
{
  private static readonly byte[] ONE = new byte[1]
  {
    (byte) 1
  };
  private static readonly long RESEED_MAX = 140737488355328 /*0x800000000000*/;
  private static readonly int MAX_BITS_REQUEST = 262144 /*0x040000*/;
  private static readonly IDictionary<string, int> SeedLens = (IDictionary<string, int>) new Dictionary<string, int>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  private readonly IDigest mDigest;
  private readonly IEntropySource mEntropySource;
  private readonly int mSecurityStrength;
  private readonly int mSeedLength;
  private byte[] mV;
  private byte[] mC;
  private long mReseedCounter;

  static HashSP800Drbg()
  {
    HashSP800Drbg.SeedLens.Add("SHA-1", 440);
    HashSP800Drbg.SeedLens.Add("SHA-224", 440);
    HashSP800Drbg.SeedLens.Add("SHA-256", 440);
    HashSP800Drbg.SeedLens.Add("SHA-512/256", 440);
    HashSP800Drbg.SeedLens.Add("SHA-512/224", 440);
    HashSP800Drbg.SeedLens.Add("SHA-384", 888);
    HashSP800Drbg.SeedLens.Add("SHA-512", 888);
  }

  public HashSP800Drbg(
    IDigest digest,
    int securityStrength,
    IEntropySource entropySource,
    byte[] personalizationString,
    byte[] nonce)
  {
    if (securityStrength > DrbgUtilities.GetMaxSecurityStrength(digest))
      throw new ArgumentException("Requested security strength is not supported by the derivation function");
    if (entropySource.EntropySize < securityStrength)
      throw new ArgumentException("Not enough entropy for security strength required");
    this.mDigest = digest;
    this.mEntropySource = entropySource;
    this.mSecurityStrength = securityStrength;
    this.mSeedLength = HashSP800Drbg.SeedLens[digest.AlgorithmName];
    byte[] seedMaterial = Arrays.ConcatenateAll(this.GetEntropy(), nonce, personalizationString);
    this.mV = new byte[(this.mSeedLength + 7) / 8];
    DrbgUtilities.HashDF(this.mDigest, seedMaterial, this.mSeedLength, this.mV);
    byte[] numArray = new byte[this.mV.Length + 1];
    Array.Copy((Array) this.mV, 0, (Array) numArray, 1, this.mV.Length);
    this.mC = new byte[(this.mSeedLength + 7) / 8];
    DrbgUtilities.HashDF(this.mDigest, numArray, this.mSeedLength, this.mC);
    this.mReseedCounter = 1L;
  }

  public int BlockSize => this.mDigest.GetDigestSize() * 8;

  public int Generate(
    byte[] output,
    int outputOff,
    int outputLen,
    byte[] additionalInput,
    bool predictionResistant)
  {
    int num = outputLen * 8;
    if (num > HashSP800Drbg.MAX_BITS_REQUEST)
      throw new ArgumentException("Number of bits per request limited to " + HashSP800Drbg.MAX_BITS_REQUEST.ToString(), nameof (output));
    if (this.mReseedCounter > HashSP800Drbg.RESEED_MAX)
      return -1;
    if (predictionResistant)
    {
      this.Reseed(additionalInput);
      additionalInput = (byte[]) null;
    }
    if (additionalInput != null)
    {
      byte[] numArray = new byte[1 + this.mV.Length + additionalInput.Length];
      numArray[0] = (byte) 2;
      Array.Copy((Array) this.mV, 0, (Array) numArray, 1, this.mV.Length);
      Array.Copy((Array) additionalInput, 0, (Array) numArray, 1 + this.mV.Length, additionalInput.Length);
      this.AddTo(this.mV, this.Hash(numArray));
    }
    byte[] sourceArray = this.Hashgen(this.mV, outputLen);
    byte[] numArray1 = new byte[this.mV.Length + 1];
    Array.Copy((Array) this.mV, 0, (Array) numArray1, 1, this.mV.Length);
    numArray1[0] = (byte) 3;
    this.AddTo(this.mV, this.Hash(numArray1));
    this.AddTo(this.mV, this.mC);
    byte[] numArray2 = new byte[4];
    Pack.UInt32_To_BE((uint) this.mReseedCounter, numArray2);
    this.AddTo(this.mV, numArray2);
    ++this.mReseedCounter;
    byte[] destinationArray = output;
    int destinationIndex = outputOff;
    int length = outputLen;
    Array.Copy((Array) sourceArray, 0, (Array) destinationArray, destinationIndex, length);
    return num;
  }

  private byte[] GetEntropy()
  {
    byte[] entropy = this.mEntropySource.GetEntropy();
    if (entropy.Length >= (this.mSecurityStrength + 7) / 8)
      return entropy;
    throw new InvalidOperationException("Insufficient entropy provided by entropy source");
  }

  private void AddTo(byte[] longer, byte[] shorter)
  {
    int num1 = longer.Length - shorter.Length;
    uint num2 = 0;
    int length = shorter.Length;
    while (--length >= 0)
    {
      uint num3 = num2 + ((uint) longer[num1 + length] + (uint) shorter[length]);
      longer[num1 + length] = (byte) num3;
      num2 = num3 >> 8;
    }
    int index = num1;
    while (--index >= 0)
    {
      uint num4 = num2 + (uint) longer[index];
      longer[index] = (byte) num4;
      num2 = num4 >> 8;
    }
  }

  public void Reseed(byte[] additionalInput)
  {
    byte[] entropy = this.GetEntropy();
    DrbgUtilities.HashDF(this.mDigest, Arrays.ConcatenateAll(HashSP800Drbg.ONE, this.mV, entropy, additionalInput), this.mSeedLength, this.mV);
    byte[] numArray = new byte[this.mV.Length + 1];
    numArray[0] = (byte) 0;
    Array.Copy((Array) this.mV, 0, (Array) numArray, 1, this.mV.Length);
    DrbgUtilities.HashDF(this.mDigest, numArray, this.mSeedLength, this.mC);
    this.mReseedCounter = 1L;
  }

  private void DoHash(byte[] input, byte[] output)
  {
    this.mDigest.BlockUpdate(input, 0, input.Length);
    this.mDigest.DoFinal(output, 0);
  }

  private byte[] Hash(byte[] input)
  {
    byte[] output = new byte[this.mDigest.GetDigestSize()];
    this.DoHash(input, output);
    return output;
  }

  private byte[] Hashgen(byte[] input, int length)
  {
    int digestSize = this.mDigest.GetDigestSize();
    int num = length / digestSize;
    byte[] numArray1 = (byte[]) input.Clone();
    byte[] destinationArray = new byte[length];
    byte[] numArray2 = new byte[digestSize];
    for (int index = 0; index <= num; ++index)
    {
      this.DoHash(numArray1, numArray2);
      int length1 = Math.Min(digestSize, length - index * digestSize);
      Array.Copy((Array) numArray2, 0, (Array) destinationArray, index * digestSize, length1);
      this.AddTo(numArray1, HashSP800Drbg.ONE);
    }
    return destinationArray;
  }
}
