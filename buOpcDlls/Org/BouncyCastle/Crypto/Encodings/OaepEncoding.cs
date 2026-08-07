// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Encodings.OaepEncoding
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Encodings;

public class OaepEncoding : IAsymmetricBlockCipher
{
  private byte[] defHash;
  private IDigest mgf1Hash;
  private IAsymmetricBlockCipher engine;
  private SecureRandom random;
  private bool forEncryption;

  public OaepEncoding(IAsymmetricBlockCipher cipher)
    : this(cipher, (IDigest) new Sha1Digest(), (byte[]) null)
  {
  }

  public OaepEncoding(IAsymmetricBlockCipher cipher, IDigest hash)
    : this(cipher, hash, (byte[]) null)
  {
  }

  public OaepEncoding(IAsymmetricBlockCipher cipher, IDigest hash, byte[] encodingParams)
    : this(cipher, hash, hash, encodingParams)
  {
  }

  public OaepEncoding(
    IAsymmetricBlockCipher cipher,
    IDigest hash,
    IDigest mgf1Hash,
    byte[] encodingParams)
  {
    this.engine = cipher;
    this.mgf1Hash = mgf1Hash;
    this.defHash = new byte[hash.GetDigestSize()];
    hash.Reset();
    if (encodingParams != null)
      hash.BlockUpdate(encodingParams, 0, encodingParams.Length);
    hash.DoFinal(this.defHash, 0);
  }

  public string AlgorithmName => this.engine.AlgorithmName + "/OAEPPadding";

  public IAsymmetricBlockCipher UnderlyingCipher => this.engine;

  public void Init(bool forEncryption, ICipherParameters parameters)
  {
    this.random = !(parameters is ParametersWithRandom parametersWithRandom) ? (forEncryption ? CryptoServicesRegistrar.GetSecureRandom() : (SecureRandom) null) : parametersWithRandom.Random;
    this.engine.Init(forEncryption, parameters);
    this.forEncryption = forEncryption;
  }

  public int GetInputBlockSize()
  {
    int inputBlockSize = this.engine.GetInputBlockSize();
    return this.forEncryption ? inputBlockSize - 1 - 2 * this.defHash.Length : inputBlockSize;
  }

  public int GetOutputBlockSize()
  {
    int outputBlockSize = this.engine.GetOutputBlockSize();
    return this.forEncryption ? outputBlockSize : outputBlockSize - 1 - 2 * this.defHash.Length;
  }

  public byte[] ProcessBlock(byte[] inBytes, int inOff, int inLen)
  {
    return this.forEncryption ? this.EncodeBlock(inBytes, inOff, inLen) : this.DecodeBlock(inBytes, inOff, inLen);
  }

  private byte[] EncodeBlock(byte[] inBytes, int inOff, int inLen)
  {
    Org.BouncyCastle.Crypto.Check.DataLength(inLen > this.GetInputBlockSize(), "input data too long");
    byte[] numArray1 = new byte[this.GetInputBlockSize() + 1 + 2 * this.defHash.Length];
    Array.Copy((Array) inBytes, inOff, (Array) numArray1, numArray1.Length - inLen, inLen);
    numArray1[numArray1.Length - inLen - 1] = (byte) 1;
    Array.Copy((Array) this.defHash, 0, (Array) numArray1, this.defHash.Length, this.defHash.Length);
    byte[] nextBytes = SecureRandom.GetNextBytes(this.random, this.defHash.Length);
    byte[] numArray2 = this.MaskGeneratorFunction(nextBytes, 0, nextBytes.Length, numArray1.Length - this.defHash.Length);
    for (int length = this.defHash.Length; length != numArray1.Length; ++length)
      numArray1[length] ^= numArray2[length - this.defHash.Length];
    Array.Copy((Array) nextBytes, 0, (Array) numArray1, 0, this.defHash.Length);
    byte[] numArray3 = this.MaskGeneratorFunction(numArray1, this.defHash.Length, numArray1.Length - this.defHash.Length, this.defHash.Length);
    for (int index = 0; index != this.defHash.Length; ++index)
      numArray1[index] ^= numArray3[index];
    return this.engine.ProcessBlock(numArray1, 0, numArray1.Length);
  }

  private byte[] DecodeBlock(byte[] inBytes, int inOff, int inLen)
  {
    byte[] sourceArray = this.engine.ProcessBlock(inBytes, inOff, inLen);
    byte[] numArray1 = new byte[this.engine.GetOutputBlockSize()];
    int num1 = numArray1.Length - (2 * this.defHash.Length + 1) >> 31 /*0x1F*/;
    if (sourceArray.Length <= numArray1.Length)
    {
      Array.Copy((Array) sourceArray, 0, (Array) numArray1, numArray1.Length - sourceArray.Length, sourceArray.Length);
    }
    else
    {
      Array.Copy((Array) sourceArray, 0, (Array) numArray1, 0, numArray1.Length);
      num1 |= 1;
    }
    byte[] numArray2 = this.MaskGeneratorFunction(numArray1, this.defHash.Length, numArray1.Length - this.defHash.Length, this.defHash.Length);
    for (int index = 0; index != this.defHash.Length; ++index)
      numArray1[index] ^= numArray2[index];
    byte[] numArray3 = this.MaskGeneratorFunction(numArray1, 0, this.defHash.Length, numArray1.Length - this.defHash.Length);
    for (int length = this.defHash.Length; length != numArray1.Length; ++length)
      numArray1[length] ^= numArray3[length - this.defHash.Length];
    for (int index = 0; index != this.defHash.Length; ++index)
      num1 |= (int) this.defHash[index] ^ (int) numArray1[this.defHash.Length + index];
    int num2 = -1;
    for (int index = 2 * this.defHash.Length; index != numArray1.Length; ++index)
    {
      int num3 = ((int) -numArray1[index] & num2) >> 31 /*0x1F*/;
      num2 += index & num3;
    }
    int num4 = num1 | num2 >> 31 /*0x1F*/;
    int index1 = num2 + 1;
    if ((num4 | (int) numArray1[index1] ^ 1) != 0)
    {
      Arrays.Fill(numArray1, (byte) 0);
      throw new InvalidCipherTextException("data wrong");
    }
    int sourceIndex = index1 + 1;
    byte[] destinationArray = new byte[numArray1.Length - sourceIndex];
    Array.Copy((Array) numArray1, sourceIndex, (Array) destinationArray, 0, destinationArray.Length);
    Array.Clear((Array) numArray1, 0, numArray1.Length);
    return destinationArray;
  }

  private byte[] MaskGeneratorFunction(byte[] Z, int zOff, int zLen, int length)
  {
    if (!(this.mgf1Hash is IXof mgf1Hash))
      return this.MaskGeneratorFunction1(Z, zOff, zLen, length);
    byte[] output = new byte[length];
    mgf1Hash.BlockUpdate(Z, zOff, zLen);
    mgf1Hash.OutputFinal(output, 0, length);
    return output;
  }

  private byte[] MaskGeneratorFunction1(byte[] Z, int zOff, int zLen, int length)
  {
    byte[] destinationArray = new byte[length];
    byte[] numArray1 = new byte[this.mgf1Hash.GetDigestSize()];
    byte[] numArray2 = new byte[4];
    int n = 0;
    this.mgf1Hash.Reset();
    for (; n < length / numArray1.Length; ++n)
    {
      Pack.UInt32_To_BE((uint) n, numArray2);
      this.mgf1Hash.BlockUpdate(Z, zOff, zLen);
      this.mgf1Hash.BlockUpdate(numArray2, 0, numArray2.Length);
      this.mgf1Hash.DoFinal(numArray1, 0);
      Array.Copy((Array) numArray1, 0, (Array) destinationArray, n * numArray1.Length, numArray1.Length);
    }
    if (n * numArray1.Length < length)
    {
      Pack.UInt32_To_BE((uint) n, numArray2);
      this.mgf1Hash.BlockUpdate(Z, zOff, zLen);
      this.mgf1Hash.BlockUpdate(numArray2, 0, numArray2.Length);
      this.mgf1Hash.DoFinal(numArray1, 0);
      Array.Copy((Array) numArray1, 0, (Array) destinationArray, n * numArray1.Length, destinationArray.Length - n * numArray1.Length);
    }
    return destinationArray;
  }
}
