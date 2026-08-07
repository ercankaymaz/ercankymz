// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.RC2WrapEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class RC2WrapEngine : IWrapper
{
  private CbcBlockCipher engine;
  private ICipherParameters parameters;
  private ParametersWithIV paramPlusIV;
  private byte[] iv;
  private bool forWrapping;
  private SecureRandom sr;
  private static readonly byte[] IV2 = new byte[8]
  {
    (byte) 74,
    (byte) 221,
    (byte) 162,
    (byte) 44,
    (byte) 121,
    (byte) 232,
    (byte) 33,
    (byte) 5
  };
  private readonly IDigest sha1 = (IDigest) new Sha1Digest();
  private readonly byte[] digest = new byte[20];

  public virtual void Init(bool forWrapping, ICipherParameters parameters)
  {
    this.forWrapping = forWrapping;
    this.engine = new CbcBlockCipher((IBlockCipher) new RC2Engine());
    if (parameters is ParametersWithRandom parametersWithRandom)
    {
      this.sr = parametersWithRandom.Random;
      parameters = parametersWithRandom.Parameters;
    }
    else
      this.sr = forWrapping ? CryptoServicesRegistrar.GetSecureRandom() : (SecureRandom) null;
    if (parameters is ParametersWithIV)
    {
      if (!forWrapping)
        throw new ArgumentException("You should not supply an IV for unwrapping");
      this.paramPlusIV = (ParametersWithIV) parameters;
      this.iv = this.paramPlusIV.GetIV();
      this.parameters = this.paramPlusIV.Parameters;
      if (this.iv.Length != 8)
        throw new ArgumentException("IV is not 8 octets");
    }
    else
    {
      this.parameters = parameters;
      if (!this.forWrapping)
        return;
      this.iv = new byte[8];
      this.sr.NextBytes(this.iv);
      this.paramPlusIV = new ParametersWithIV(this.parameters, this.iv);
    }
  }

  public virtual string AlgorithmName => "RC2";

  public virtual byte[] Wrap(byte[] input, int inOff, int length)
  {
    if (!this.forWrapping)
      throw new InvalidOperationException("Not initialized for wrapping");
    int keyLen = length + 8 & -8;
    int length1 = this.iv.Length;
    byte[] numArray = Arrays.CopyOf(this.iv, length1 + keyLen + 8);
    numArray[length1] = (byte) length;
    Array.Copy((Array) input, inOff, (Array) numArray, length1 + 1, length);
    int len = keyLen - length - 1;
    if (len > 0)
      this.sr.NextBytes(numArray, length1 + keyLen - len, len);
    this.CalculateCmsKeyChecksum(numArray, length1, keyLen, numArray, length1 + keyLen);
    int blockSize = this.engine.GetBlockSize();
    this.engine.Init(true, (ICipherParameters) this.paramPlusIV);
    int num1;
    for (num1 = length1; num1 < numArray.Length; num1 += blockSize)
      this.engine.ProcessBlock(numArray, num1, numArray, num1);
    if (num1 != numArray.Length)
      throw new InvalidOperationException("Not multiple of block length");
    Array.Reverse((Array) numArray);
    this.engine.Init(true, (ICipherParameters) new ParametersWithIV(this.parameters, RC2WrapEngine.IV2));
    int num2;
    for (num2 = 0; num2 < numArray.Length; num2 += blockSize)
      this.engine.ProcessBlock(numArray, num2, numArray, num2);
    if (num2 != numArray.Length)
      throw new InvalidOperationException("Not multiple of block length");
    return numArray;
  }

  public virtual byte[] Unwrap(byte[] input, int inOff, int length)
  {
    if (this.forWrapping)
      throw new InvalidOperationException("Not set for unwrapping");
    if (input == null)
      throw new InvalidCipherTextException("Null pointer as ciphertext");
    int num1 = length % this.engine.GetBlockSize() == 0 ? this.engine.GetBlockSize() : throw new InvalidCipherTextException("Ciphertext not multiple of " + this.engine.GetBlockSize().ToString());
    byte[] numArray = new byte[length];
    this.engine.Init(false, (ICipherParameters) new ParametersWithIV(this.parameters, RC2WrapEngine.IV2));
    int outOff;
    for (outOff = 0; outOff < numArray.Length; outOff += num1)
      this.engine.ProcessBlock(input, inOff + outOff, numArray, outOff);
    if (outOff != numArray.Length)
      throw new InvalidOperationException("Not multiple of block length");
    Array.Reverse((Array) numArray);
    this.iv = Arrays.CopyOf(numArray, 8);
    this.paramPlusIV = new ParametersWithIV(this.parameters, this.iv);
    this.engine.Init(false, (ICipherParameters) this.paramPlusIV);
    int num2;
    for (num2 = 8; num2 < numArray.Length; num2 += num1)
      this.engine.ProcessBlock(numArray, num2, numArray, num2);
    if (num2 != numArray.Length)
      throw new InvalidOperationException("Not multiple of block length");
    if (!this.CheckCmsKeyChecksum(numArray, 8, numArray.Length - 16 /*0x10*/, numArray, numArray.Length - 8))
      throw new InvalidCipherTextException("Checksum inside ciphertext is corrupted");
    int num3 = numArray.Length - 16 /*0x10*/ - (int) numArray[8] - 1;
    if ((num3 & 7) != num3)
      throw new InvalidCipherTextException($"Invalid padding length ({num3.ToString()})");
    return Arrays.CopyOfRange(numArray, 9, 9 + (int) numArray[8]);
  }

  private void CalculateCmsKeyChecksum(
    byte[] key,
    int keyOff,
    int keyLen,
    byte[] cks,
    int cksOff)
  {
    this.sha1.BlockUpdate(key, keyOff, keyLen);
    this.sha1.DoFinal(this.digest, 0);
    Array.Copy((Array) this.digest, 0, (Array) cks, cksOff, 8);
  }

  private bool CheckCmsKeyChecksum(byte[] key, int keyOff, int keyLen, byte[] cks, int cksOff)
  {
    this.sha1.BlockUpdate(key, keyOff, keyLen);
    this.sha1.DoFinal(this.digest, 0);
    return Arrays.FixedTimeEquals(8, this.digest, 0, cks, cksOff);
  }
}
