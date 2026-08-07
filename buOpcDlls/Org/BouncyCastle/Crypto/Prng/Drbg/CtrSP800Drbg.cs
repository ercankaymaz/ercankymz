// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Prng.Drbg.CtrSP800Drbg
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Encoders;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Prng.Drbg;

public sealed class CtrSP800Drbg : ISP80090Drbg
{
  private static readonly long TDEA_RESEED_MAX = 2147483648 /*0x80000000*/;
  private static readonly long AES_RESEED_MAX = 140737488355328 /*0x800000000000*/;
  private static readonly int TDEA_MAX_BITS_REQUEST = 4096 /*0x1000*/;
  private static readonly int AES_MAX_BITS_REQUEST = 262144 /*0x040000*/;
  private readonly IEntropySource mEntropySource;
  private readonly IBlockCipher mEngine;
  private readonly int mKeySizeInBits;
  private readonly int mSeedLength;
  private readonly int mSecurityStrength;
  private byte[] mKey;
  private byte[] mV;
  private long mReseedCounter;
  private bool mIsTdea;
  private static readonly byte[] K_BITS = Hex.DecodeStrict("000102030405060708090A0B0C0D0E0F101112131415161718191A1B1C1D1E1F");

  public CtrSP800Drbg(
    IBlockCipher engine,
    int keySizeInBits,
    int securityStrength,
    IEntropySource entropySource,
    byte[] personalizationString,
    byte[] nonce)
  {
    if (securityStrength > 256 /*0x0100*/)
      throw new ArgumentException("Requested security strength is not supported by the derivation function");
    if (this.GetMaxSecurityStrength(engine, keySizeInBits) < securityStrength)
      throw new ArgumentException("Requested security strength is not supported by block cipher and key size");
    if (entropySource.EntropySize < securityStrength)
      throw new ArgumentException("Not enough entropy for security strength required");
    this.mEntropySource = entropySource;
    this.mEngine = engine;
    this.mKeySizeInBits = keySizeInBits;
    this.mSecurityStrength = securityStrength;
    this.mSeedLength = keySizeInBits + engine.GetBlockSize() * 8;
    this.mIsTdea = this.IsTdea(engine);
    this.CTR_DRBG_Instantiate_algorithm(personalizationString, nonce);
  }

  private void CTR_DRBG_Instantiate_algorithm(byte[] personalisationString, byte[] nonce)
  {
    byte[] seed = this.BlockCipherDF(Arrays.ConcatenateAll(this.GetEntropy(), nonce, personalisationString), this.mSeedLength / 8);
    int blockSize = this.mEngine.GetBlockSize();
    this.mKey = new byte[(this.mKeySizeInBits + 7) / 8];
    this.mV = new byte[blockSize];
    this.CTR_DRBG_Update(seed, this.mKey, this.mV);
    this.mReseedCounter = 1L;
  }

  private void CTR_DRBG_Update(byte[] seed, byte[] key, byte[] v)
  {
    byte[] numArray1 = new byte[seed.Length];
    byte[] numArray2 = new byte[this.mEngine.GetBlockSize()];
    int num = 0;
    int blockSize = this.mEngine.GetBlockSize();
    this.mEngine.Init(true, (ICipherParameters) this.ExpandToKeyParameter(key));
    for (; num * blockSize < seed.Length; ++num)
    {
      this.AddOneTo(v);
      this.mEngine.ProcessBlock(v, 0, numArray2, 0);
      int length = Math.Min(blockSize, numArray1.Length - num * blockSize);
      Array.Copy((Array) numArray2, 0, (Array) numArray1, num * blockSize, length);
    }
    this.Xor(numArray1, seed, numArray1, 0);
    Array.Copy((Array) numArray1, 0, (Array) key, 0, key.Length);
    Array.Copy((Array) numArray1, key.Length, (Array) v, 0, v.Length);
  }

  private void CTR_DRBG_Reseed_algorithm(byte[] additionalInput)
  {
    this.CTR_DRBG_Update(this.BlockCipherDF(Arrays.Concatenate(this.GetEntropy(), additionalInput), this.mSeedLength / 8), this.mKey, this.mV);
    this.mReseedCounter = 1L;
  }

  private void Xor(byte[] output, byte[] a, byte[] b, int bOff)
  {
    for (int index = 0; index < output.Length; ++index)
      output[index] = (byte) ((uint) a[index] ^ (uint) b[bOff + index]);
  }

  private void AddOneTo(byte[] longer)
  {
    uint num1 = 1;
    int length = longer.Length;
    while (--length >= 0)
    {
      uint num2 = num1 + (uint) longer[length];
      longer[length] = (byte) num2;
      num1 = num2 >> 8;
    }
  }

  private byte[] GetEntropy()
  {
    byte[] entropy = this.mEntropySource.GetEntropy();
    if (entropy.Length >= (this.mSecurityStrength + 7) / 8)
      return entropy;
    throw new InvalidOperationException("Insufficient entropy provided by entropy source");
  }

  private byte[] BlockCipherDF(byte[] input, int N)
  {
    int blockSize = this.mEngine.GetBlockSize();
    int length1 = input.Length;
    byte[] numArray1 = new byte[(8 + length1 + 1 + blockSize - 1) / blockSize * blockSize];
    Pack.UInt32_To_BE((uint) length1, numArray1, 0);
    Pack.UInt32_To_BE((uint) N, numArray1, 4);
    Array.Copy((Array) input, 0, (Array) numArray1, 8, length1);
    numArray1[8 + length1] = (byte) 128 /*0x80*/;
    byte[] numArray2 = new byte[this.mKeySizeInBits / 8 + blockSize];
    byte[] numArray3 = new byte[blockSize];
    byte[] numArray4 = new byte[blockSize];
    int n = 0;
    byte[] numArray5 = new byte[this.mKeySizeInBits / 8];
    Array.Copy((Array) CtrSP800Drbg.K_BITS, 0, (Array) numArray5, 0, numArray5.Length);
    this.mEngine.Init(true, (ICipherParameters) this.ExpandToKeyParameter(numArray5));
    for (; n * blockSize * 8 < this.mKeySizeInBits + blockSize * 8; ++n)
    {
      Pack.UInt32_To_BE((uint) n, numArray4, 0);
      this.BCC(numArray3, numArray4, numArray1);
      int length2 = Math.Min(blockSize, numArray2.Length - n * blockSize);
      Array.Copy((Array) numArray3, 0, (Array) numArray2, n * blockSize, length2);
    }
    byte[] numArray6 = new byte[blockSize];
    Array.Copy((Array) numArray2, 0, (Array) numArray5, 0, numArray5.Length);
    Array.Copy((Array) numArray2, numArray5.Length, (Array) numArray6, 0, numArray6.Length);
    byte[] destinationArray = new byte[N];
    int num = 0;
    this.mEngine.Init(true, (ICipherParameters) this.ExpandToKeyParameter(numArray5));
    for (; num * blockSize < destinationArray.Length; ++num)
    {
      this.mEngine.ProcessBlock(numArray6, 0, numArray6, 0);
      int length3 = Math.Min(blockSize, destinationArray.Length - num * blockSize);
      Array.Copy((Array) numArray6, 0, (Array) destinationArray, num * blockSize, length3);
    }
    return destinationArray;
  }

  private void BCC(byte[] bccOut, byte[] iV, byte[] data)
  {
    int blockSize = this.mEngine.GetBlockSize();
    byte[] numArray1 = new byte[blockSize];
    int num = data.Length / blockSize;
    byte[] numArray2 = new byte[blockSize];
    this.mEngine.ProcessBlock(iV, 0, numArray1, 0);
    for (int index = 0; index < num; ++index)
    {
      this.Xor(numArray2, numArray1, data, index * blockSize);
      this.mEngine.ProcessBlock(numArray2, 0, numArray1, 0);
    }
    Array.Copy((Array) numArray1, 0, (Array) bccOut, 0, bccOut.Length);
  }

  public int BlockSize => this.mV.Length * 8;

  public int Generate(
    byte[] output,
    int outputOff,
    int outputLen,
    byte[] additionalInput,
    bool predictionResistant)
  {
    if (this.mIsTdea)
    {
      if (this.mReseedCounter > CtrSP800Drbg.TDEA_RESEED_MAX)
        return -1;
      if (outputLen > CtrSP800Drbg.TDEA_MAX_BITS_REQUEST / 8)
        throw new ArgumentException("Number of bits per request limited to " + CtrSP800Drbg.TDEA_MAX_BITS_REQUEST.ToString(), nameof (output));
    }
    else
    {
      if (this.mReseedCounter > CtrSP800Drbg.AES_RESEED_MAX)
        return -1;
      if (outputLen > CtrSP800Drbg.AES_MAX_BITS_REQUEST / 8)
        throw new ArgumentException("Number of bits per request limited to " + CtrSP800Drbg.AES_MAX_BITS_REQUEST.ToString(), nameof (output));
    }
    if (predictionResistant)
    {
      this.CTR_DRBG_Reseed_algorithm(additionalInput);
      additionalInput = (byte[]) null;
    }
    if (additionalInput != null)
    {
      additionalInput = this.BlockCipherDF(additionalInput, this.mSeedLength / 8);
      this.CTR_DRBG_Update(additionalInput, this.mKey, this.mV);
    }
    else
      additionalInput = new byte[this.mSeedLength];
    byte[] numArray = new byte[this.mV.Length];
    this.mEngine.Init(true, (ICipherParameters) this.ExpandToKeyParameter(this.mKey));
    int num = 0;
    for (int index = outputLen / numArray.Length; num <= index; ++num)
    {
      int length = Math.Min(numArray.Length, outputLen - num * numArray.Length);
      if (length != 0)
      {
        this.AddOneTo(this.mV);
        this.mEngine.ProcessBlock(this.mV, 0, numArray, 0);
        Array.Copy((Array) numArray, 0, (Array) output, outputOff + num * numArray.Length, length);
      }
    }
    this.CTR_DRBG_Update(additionalInput, this.mKey, this.mV);
    ++this.mReseedCounter;
    return outputLen * 8;
  }

  public void Reseed(byte[] additionalInput) => this.CTR_DRBG_Reseed_algorithm(additionalInput);

  private bool IsTdea(IBlockCipher cipher)
  {
    return cipher.AlgorithmName.Equals("DESede") || cipher.AlgorithmName.Equals("TDEA");
  }

  private int GetMaxSecurityStrength(IBlockCipher cipher, int keySizeInBits)
  {
    if (this.IsTdea(cipher) && keySizeInBits == 168)
      return 112 /*0x70*/;
    return cipher.AlgorithmName.Equals("AES") ? keySizeInBits : -1;
  }

  private KeyParameter ExpandToKeyParameter(byte[] key)
  {
    if (!this.mIsTdea)
      return new KeyParameter(key);
    byte[] numArray = new byte[24];
    this.PadKey(key, 0, numArray, 0);
    this.PadKey(key, 7, numArray, 8);
    this.PadKey(key, 14, numArray, 16 /*0x10*/);
    return new KeyParameter(numArray);
  }

  private void PadKey(byte[] keyMaster, int keyOff, byte[] tmp, int tmpOff)
  {
    tmp[tmpOff] = (byte) ((uint) keyMaster[keyOff] & 254U);
    tmp[tmpOff + 1] = (byte) ((int) keyMaster[keyOff] << 7 | ((int) keyMaster[keyOff + 1] & 252) >> 1);
    tmp[tmpOff + 2] = (byte) ((int) keyMaster[keyOff + 1] << 6 | ((int) keyMaster[keyOff + 2] & 248) >> 2);
    tmp[tmpOff + 3] = (byte) ((int) keyMaster[keyOff + 2] << 5 | ((int) keyMaster[keyOff + 3] & 240 /*0xF0*/) >> 3);
    tmp[tmpOff + 4] = (byte) ((int) keyMaster[keyOff + 3] << 4 | ((int) keyMaster[keyOff + 4] & 224 /*0xE0*/) >> 4);
    tmp[tmpOff + 5] = (byte) ((int) keyMaster[keyOff + 4] << 3 | ((int) keyMaster[keyOff + 5] & 192 /*0xC0*/) >> 5);
    tmp[tmpOff + 6] = (byte) ((int) keyMaster[keyOff + 5] << 2 | ((int) keyMaster[keyOff + 6] & 128 /*0x80*/) >> 6);
    tmp[tmpOff + 7] = (byte) ((uint) keyMaster[keyOff + 6] << 1);
    DesParameters.SetOddParity(tmp, tmpOff, 8);
  }
}
