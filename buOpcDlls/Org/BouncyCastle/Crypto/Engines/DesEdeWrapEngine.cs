// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.DesEdeWrapEngine
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

public class DesEdeWrapEngine : IWrapper
{
  private CbcBlockCipher engine;
  private KeyParameter param;
  private ParametersWithIV paramPlusIV;
  private byte[] iv;
  private bool forWrapping;
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
    this.engine = new CbcBlockCipher((IBlockCipher) new DesEdeEngine());
    SecureRandom secureRandom = (SecureRandom) null;
    if (parameters is ParametersWithRandom parametersWithRandom)
    {
      parameters = parametersWithRandom.Parameters;
      secureRandom = parametersWithRandom.Random;
    }
    if (parameters is KeyParameter keyParameter)
    {
      this.param = keyParameter;
      if (!this.forWrapping)
        return;
      this.iv = new byte[8];
      CryptoServicesRegistrar.GetSecureRandom(secureRandom).NextBytes(this.iv);
      this.paramPlusIV = new ParametersWithIV((ICipherParameters) this.param, this.iv);
    }
    else
    {
      if (!(parameters is ParametersWithIV parametersWithIv))
        return;
      if (!forWrapping)
        throw new ArgumentException("You should not supply an IV for unwrapping");
      this.paramPlusIV = parametersWithIv;
      this.iv = parametersWithIv.GetIV();
      this.param = (KeyParameter) parametersWithIv.Parameters;
      if (this.iv.Length != 8)
        throw new ArgumentException("IV is not 8 octets", nameof (parameters));
    }
  }

  public virtual string AlgorithmName => "DESede";

  public virtual byte[] Wrap(byte[] input, int inOff, int length)
  {
    if (!this.forWrapping)
      throw new InvalidOperationException("Not initialized for wrapping");
    byte[] numArray1 = new byte[length];
    Array.Copy((Array) input, inOff, (Array) numArray1, 0, length);
    byte[] cmsKeyChecksum = this.CalculateCmsKeyChecksum(numArray1);
    byte[] numArray2 = new byte[numArray1.Length + cmsKeyChecksum.Length];
    Array.Copy((Array) numArray1, 0, (Array) numArray2, 0, numArray1.Length);
    Array.Copy((Array) cmsKeyChecksum, 0, (Array) numArray2, numArray1.Length, cmsKeyChecksum.Length);
    int blockSize = this.engine.GetBlockSize();
    if (numArray2.Length % blockSize != 0)
      throw new InvalidOperationException("Not multiple of block length");
    this.engine.Init(true, (ICipherParameters) this.paramPlusIV);
    byte[] numArray3 = new byte[numArray2.Length];
    for (int index = 0; index != numArray2.Length; index += blockSize)
      this.engine.ProcessBlock(numArray2, index, numArray3, index);
    byte[] numArray4 = new byte[this.iv.Length + numArray3.Length];
    Array.Copy((Array) this.iv, 0, (Array) numArray4, 0, this.iv.Length);
    Array.Copy((Array) numArray3, 0, (Array) numArray4, this.iv.Length, numArray3.Length);
    Array.Reverse((Array) numArray4);
    this.engine.Init(true, (ICipherParameters) new ParametersWithIV((ICipherParameters) this.param, DesEdeWrapEngine.IV2));
    for (int index = 0; index != numArray4.Length; index += blockSize)
      this.engine.ProcessBlock(numArray4, index, numArray4, index);
    return numArray4;
  }

  public virtual byte[] Unwrap(byte[] input, int inOff, int length)
  {
    if (this.forWrapping)
      throw new InvalidOperationException("Not set for unwrapping");
    if (input == null)
      throw new InvalidCipherTextException("Null pointer as ciphertext");
    int blockSize = this.engine.GetBlockSize();
    if (length % blockSize != 0)
      throw new InvalidCipherTextException("Ciphertext not multiple of " + blockSize.ToString());
    this.engine.Init(false, (ICipherParameters) new ParametersWithIV((ICipherParameters) this.param, DesEdeWrapEngine.IV2));
    byte[] numArray1 = new byte[length];
    for (int outOff = 0; outOff != numArray1.Length; outOff += blockSize)
      this.engine.ProcessBlock(input, inOff + outOff, numArray1, outOff);
    Array.Reverse((Array) numArray1);
    this.iv = new byte[8];
    byte[] numArray2 = new byte[numArray1.Length - 8];
    Array.Copy((Array) numArray1, 0, (Array) this.iv, 0, 8);
    Array.Copy((Array) numArray1, 8, (Array) numArray2, 0, numArray1.Length - 8);
    this.paramPlusIV = new ParametersWithIV((ICipherParameters) this.param, this.iv);
    this.engine.Init(false, (ICipherParameters) this.paramPlusIV);
    byte[] numArray3 = new byte[numArray2.Length];
    for (int index = 0; index != numArray3.Length; index += blockSize)
      this.engine.ProcessBlock(numArray2, index, numArray3, index);
    byte[] numArray4 = new byte[numArray3.Length - 8];
    byte[] numArray5 = new byte[8];
    Array.Copy((Array) numArray3, 0, (Array) numArray4, 0, numArray3.Length - 8);
    Array.Copy((Array) numArray3, numArray3.Length - 8, (Array) numArray5, 0, 8);
    return this.CheckCmsKeyChecksum(numArray4, numArray5) ? numArray4 : throw new InvalidCipherTextException("Checksum inside ciphertext is corrupted");
  }

  private byte[] CalculateCmsKeyChecksum(byte[] key)
  {
    this.sha1.BlockUpdate(key, 0, key.Length);
    this.sha1.DoFinal(this.digest, 0);
    byte[] destinationArray = new byte[8];
    Array.Copy((Array) this.digest, 0, (Array) destinationArray, 0, 8);
    return destinationArray;
  }

  private bool CheckCmsKeyChecksum(byte[] key, byte[] checksum)
  {
    return Arrays.FixedTimeEquals(this.CalculateCmsKeyChecksum(key), checksum);
  }
}
