// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Signers.PssSigner
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Signers;

public class PssSigner : ISigner
{
  public const byte TrailerImplicit = 188;
  private readonly IDigest contentDigest1;
  private readonly IDigest contentDigest2;
  private readonly IDigest mgfDigest;
  private readonly IAsymmetricBlockCipher cipher;
  private SecureRandom random;
  private int hLen;
  private int mgfhLen;
  private int sLen;
  private bool sSet;
  private int emBits;
  private byte[] salt;
  private byte[] mDash;
  private byte[] block;
  private byte trailer;

  public static PssSigner CreateRawSigner(IAsymmetricBlockCipher cipher, IDigest digest)
  {
    return new PssSigner(cipher, (IDigest) new NullDigest(), digest, digest, digest.GetDigestSize(), (byte[]) null, (byte) 188);
  }

  public static PssSigner CreateRawSigner(
    IAsymmetricBlockCipher cipher,
    IDigest contentDigest,
    IDigest mgfDigest,
    int saltLen,
    byte trailer)
  {
    return new PssSigner(cipher, (IDigest) new NullDigest(), contentDigest, mgfDigest, saltLen, (byte[]) null, trailer);
  }

  public static PssSigner CreateRawSigner(
    IAsymmetricBlockCipher cipher,
    IDigest contentDigest,
    IDigest mgfDigest,
    byte[] salt,
    byte trailer)
  {
    return new PssSigner(cipher, (IDigest) new NullDigest(), contentDigest, mgfDigest, salt.Length, salt, trailer);
  }

  public PssSigner(IAsymmetricBlockCipher cipher, IDigest digest)
    : this(cipher, digest, digest.GetDigestSize())
  {
  }

  public PssSigner(IAsymmetricBlockCipher cipher, IDigest digest, int saltLen)
    : this(cipher, digest, saltLen, (byte) 188)
  {
  }

  public PssSigner(IAsymmetricBlockCipher cipher, IDigest digest, byte[] salt)
    : this(cipher, digest, digest, digest, salt.Length, salt, (byte) 188)
  {
  }

  public PssSigner(
    IAsymmetricBlockCipher cipher,
    IDigest contentDigest,
    IDigest mgfDigest,
    int saltLen)
    : this(cipher, contentDigest, mgfDigest, saltLen, (byte) 188)
  {
  }

  public PssSigner(
    IAsymmetricBlockCipher cipher,
    IDigest contentDigest,
    IDigest mgfDigest,
    byte[] salt)
    : this(cipher, contentDigest, contentDigest, mgfDigest, salt.Length, salt, (byte) 188)
  {
  }

  public PssSigner(IAsymmetricBlockCipher cipher, IDigest digest, int saltLen, byte trailer)
    : this(cipher, digest, digest, saltLen, trailer)
  {
  }

  public PssSigner(
    IAsymmetricBlockCipher cipher,
    IDigest contentDigest,
    IDigest mgfDigest,
    int saltLen,
    byte trailer)
    : this(cipher, contentDigest, contentDigest, mgfDigest, saltLen, (byte[]) null, trailer)
  {
  }

  private PssSigner(
    IAsymmetricBlockCipher cipher,
    IDigest contentDigest1,
    IDigest contentDigest2,
    IDigest mgfDigest,
    int saltLen,
    byte[] salt,
    byte trailer)
  {
    this.cipher = cipher;
    this.contentDigest1 = contentDigest1;
    this.contentDigest2 = contentDigest2;
    this.mgfDigest = mgfDigest;
    this.hLen = contentDigest2.GetDigestSize();
    this.mgfhLen = mgfDigest.GetDigestSize();
    this.sLen = saltLen;
    this.sSet = salt != null;
    this.salt = !this.sSet ? new byte[saltLen] : salt;
    this.mDash = new byte[8 + saltLen + this.hLen];
    this.trailer = trailer;
  }

  public virtual string AlgorithmName => this.mgfDigest.AlgorithmName + "withRSAandMGF1";

  public virtual void Init(bool forSigning, ICipherParameters parameters)
  {
    if (parameters is ParametersWithRandom parameters1)
    {
      parameters = parameters1.Parameters;
      this.random = parameters1.Random;
      this.cipher.Init(forSigning, (ICipherParameters) parameters1);
    }
    else
    {
      this.random = forSigning ? CryptoServicesRegistrar.GetSecureRandom() : (SecureRandom) null;
      this.cipher.Init(forSigning, parameters);
    }
    this.emBits = (!(parameters is RsaBlindingParameters blindingParameters) ? (RsaKeyParameters) parameters : blindingParameters.PublicKey).Modulus.BitLength - 1;
    if (this.emBits < 8 * this.hLen + 8 * this.sLen + 9)
      throw new ArgumentException("key too small for specified hash and salt lengths");
    this.block = new byte[(this.emBits + 7) / 8];
  }

  private void ClearBlock(byte[] block) => Array.Clear((Array) block, 0, block.Length);

  public virtual void Update(byte input) => this.contentDigest1.Update(input);

  public virtual void BlockUpdate(byte[] input, int inOff, int inLen)
  {
    this.contentDigest1.BlockUpdate(input, inOff, inLen);
  }

  public virtual int GetMaxSignatureSize() => this.cipher.GetOutputBlockSize();

  public virtual byte[] GenerateSignature()
  {
    if (this.contentDigest1.GetDigestSize() != this.hLen)
      throw new InvalidOperationException();
    this.contentDigest1.DoFinal(this.mDash, this.mDash.Length - this.hLen - this.sLen);
    if (this.sLen != 0)
    {
      if (!this.sSet)
        this.random.NextBytes(this.salt);
      this.salt.CopyTo((Array) this.mDash, this.mDash.Length - this.sLen);
    }
    byte[] numArray1 = new byte[this.hLen];
    this.contentDigest2.BlockUpdate(this.mDash, 0, this.mDash.Length);
    this.contentDigest2.DoFinal(numArray1, 0);
    this.block[this.block.Length - this.sLen - 1 - this.hLen - 1] = (byte) 1;
    this.salt.CopyTo((Array) this.block, this.block.Length - this.sLen - this.hLen - 1);
    byte[] numArray2 = this.MaskGeneratorFunction(numArray1, 0, numArray1.Length, this.block.Length - this.hLen - 1);
    for (int index = 0; index != numArray2.Length; ++index)
      this.block[index] ^= numArray2[index];
    numArray1.CopyTo((Array) this.block, this.block.Length - this.hLen - 1);
    this.block[0] &= (byte) ((uint) byte.MaxValue >> this.block.Length * 8 - this.emBits);
    this.block[this.block.Length - 1] = this.trailer;
    byte[] signature = this.cipher.ProcessBlock(this.block, 0, this.block.Length);
    this.ClearBlock(this.block);
    return signature;
  }

  public virtual bool VerifySignature(byte[] signature)
  {
    if (this.contentDigest1.GetDigestSize() != this.hLen)
      throw new InvalidOperationException();
    this.contentDigest1.DoFinal(this.mDash, this.mDash.Length - this.hLen - this.sLen);
    byte[] numArray1 = this.cipher.ProcessBlock(signature, 0, signature.Length);
    Arrays.Fill(this.block, 0, this.block.Length - numArray1.Length, (byte) 0);
    numArray1.CopyTo((Array) this.block, this.block.Length - numArray1.Length);
    uint num = (uint) byte.MaxValue >> this.block.Length * 8 - this.emBits;
    if ((int) this.block[0] == (int) (byte) ((uint) this.block[0] & num) && (int) this.block[this.block.Length - 1] == (int) this.trailer)
    {
      byte[] numArray2 = this.MaskGeneratorFunction(this.block, this.block.Length - this.hLen - 1, this.hLen, this.block.Length - this.hLen - 1);
      for (int index = 0; index != numArray2.Length; ++index)
        this.block[index] ^= numArray2[index];
      this.block[0] &= (byte) num;
      for (int index = 0; index != this.block.Length - this.hLen - this.sLen - 2; ++index)
      {
        if (this.block[index] != (byte) 0)
        {
          this.ClearBlock(this.block);
          return false;
        }
      }
      if (this.block[this.block.Length - this.hLen - this.sLen - 2] != (byte) 1)
      {
        this.ClearBlock(this.block);
        return false;
      }
      if (this.sSet)
        Array.Copy((Array) this.salt, 0, (Array) this.mDash, this.mDash.Length - this.sLen, this.sLen);
      else
        Array.Copy((Array) this.block, this.block.Length - this.sLen - this.hLen - 1, (Array) this.mDash, this.mDash.Length - this.sLen, this.sLen);
      this.contentDigest2.BlockUpdate(this.mDash, 0, this.mDash.Length);
      this.contentDigest2.DoFinal(this.mDash, this.mDash.Length - this.hLen);
      int index1 = this.block.Length - this.hLen - 1;
      for (int index2 = this.mDash.Length - this.hLen; index2 != this.mDash.Length; ++index2)
      {
        if (((int) this.block[index1] ^ (int) this.mDash[index2]) == 0)
        {
          ++index1;
        }
        else
        {
          this.ClearBlock(this.mDash);
          this.ClearBlock(this.block);
          return false;
        }
      }
      this.ClearBlock(this.mDash);
      this.ClearBlock(this.block);
      return true;
    }
    this.ClearBlock(this.block);
    return false;
  }

  public virtual void Reset() => this.contentDigest1.Reset();

  private void ItoOSP(int i, byte[] sp)
  {
    sp[0] = (byte) (i >>> 24);
    sp[1] = (byte) (i >>> 16 /*0x10*/);
    sp[2] = (byte) (i >>> 8);
    sp[3] = (byte) i;
  }

  private byte[] MaskGeneratorFunction(byte[] Z, int zOff, int zLen, int length)
  {
    if (!(this.mgfDigest is IXof mgfDigest))
      return this.MaskGeneratorFunction1(Z, zOff, zLen, length);
    byte[] output = new byte[length];
    mgfDigest.BlockUpdate(Z, zOff, zLen);
    mgfDigest.OutputFinal(output, 0, output.Length);
    return output;
  }

  private byte[] MaskGeneratorFunction1(byte[] Z, int zOff, int zLen, int length)
  {
    byte[] destinationArray = new byte[length];
    byte[] numArray1 = new byte[this.mgfhLen];
    byte[] numArray2 = new byte[4];
    int i = 0;
    this.mgfDigest.Reset();
    for (; i < length / this.mgfhLen; ++i)
    {
      this.ItoOSP(i, numArray2);
      this.mgfDigest.BlockUpdate(Z, zOff, zLen);
      this.mgfDigest.BlockUpdate(numArray2, 0, numArray2.Length);
      this.mgfDigest.DoFinal(numArray1, 0);
      numArray1.CopyTo((Array) destinationArray, i * this.mgfhLen);
    }
    if (i * this.mgfhLen < length)
    {
      this.ItoOSP(i, numArray2);
      this.mgfDigest.BlockUpdate(Z, zOff, zLen);
      this.mgfDigest.BlockUpdate(numArray2, 0, numArray2.Length);
      this.mgfDigest.DoFinal(numArray1, 0);
      Array.Copy((Array) numArray1, 0, (Array) destinationArray, i * this.mgfhLen, destinationArray.Length - i * this.mgfhLen);
    }
    return destinationArray;
  }
}
