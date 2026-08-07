// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Signers.Iso9796d2PssSigner
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Signers;

public class Iso9796d2PssSigner : ISignerWithRecovery, ISigner
{
  private IDigest digest;
  private IAsymmetricBlockCipher cipher;
  private SecureRandom random;
  private byte[] standardSalt;
  private int hLen;
  private int trailer;
  private int keyBits;
  private byte[] block;
  private byte[] mBuf;
  private int messageLength;
  private readonly int saltLength;
  private bool fullMessage;
  private byte[] recoveredMessage;
  private byte[] preSig;
  private byte[] preBlock;
  private int preMStart;
  private int preTLength;

  public byte[] GetRecoveredMessage() => this.recoveredMessage;

  public Iso9796d2PssSigner(
    IAsymmetricBlockCipher cipher,
    IDigest digest,
    int saltLength,
    bool isImplicit)
  {
    this.cipher = cipher;
    this.digest = digest;
    this.hLen = digest.GetDigestSize();
    this.saltLength = saltLength;
    if (isImplicit)
      this.trailer = 188;
    else
      this.trailer = !IsoTrailers.NoTrailerAvailable(digest) ? IsoTrailers.GetTrailer(digest) : throw new ArgumentException("no valid trailer", nameof (digest));
  }

  public Iso9796d2PssSigner(IAsymmetricBlockCipher cipher, IDigest digest, int saltLength)
    : this(cipher, digest, saltLength, false)
  {
  }

  public virtual string AlgorithmName => this.digest.AlgorithmName + "withISO9796-2S2";

  public virtual void Init(bool forSigning, ICipherParameters parameters)
  {
    RsaKeyParameters parameters1;
    switch (parameters)
    {
      case ParametersWithRandom parametersWithRandom:
        parameters1 = (RsaKeyParameters) parametersWithRandom.Parameters;
        this.random = forSigning ? parametersWithRandom.Random : (SecureRandom) null;
        break;
      case ParametersWithSalt parametersWithSalt:
        if (!forSigning)
          throw new ArgumentException("ParametersWithSalt only valid for signing", nameof (parameters));
        parameters1 = (RsaKeyParameters) parametersWithSalt.Parameters;
        this.standardSalt = parametersWithSalt.GetSalt();
        if (this.standardSalt.Length != this.saltLength)
          throw new ArgumentException("Fixed salt is of wrong length");
        break;
      default:
        parameters1 = (RsaKeyParameters) parameters;
        this.random = forSigning ? CryptoServicesRegistrar.GetSecureRandom() : (SecureRandom) null;
        break;
    }
    this.cipher.Init(forSigning, (ICipherParameters) parameters1);
    this.keyBits = parameters1.Modulus.BitLength;
    this.block = new byte[(this.keyBits + 7) / 8];
    this.mBuf = this.trailer != 188 ? new byte[this.block.Length - this.digest.GetDigestSize() - this.saltLength - 1 - 2] : new byte[this.block.Length - this.digest.GetDigestSize() - this.saltLength - 1 - 1];
    this.Reset();
  }

  private bool IsSameAs(byte[] a, byte[] b)
  {
    if (this.messageLength != b.Length)
      return false;
    bool flag = true;
    for (int index = 0; index != b.Length; ++index)
    {
      if ((int) a[index] != (int) b[index])
        flag = false;
    }
    return flag;
  }

  private void ClearBlock(byte[] block) => Array.Clear((Array) block, 0, block.Length);

  public virtual void UpdateWithRecoveredMessage(byte[] signature)
  {
    byte[] numArray1 = this.cipher.ProcessBlock(signature, 0, signature.Length);
    if (numArray1.Length < (this.keyBits + 7) / 8)
    {
      byte[] destinationArray = new byte[(this.keyBits + 7) / 8];
      Array.Copy((Array) numArray1, 0, (Array) destinationArray, destinationArray.Length - numArray1.Length, numArray1.Length);
      this.ClearBlock(numArray1);
      numArray1 = destinationArray;
    }
    int num1;
    if (((int) numArray1[numArray1.Length - 1] & (int) byte.MaxValue ^ 188) == 0)
    {
      num1 = 1;
    }
    else
    {
      int num2 = ((int) numArray1[numArray1.Length - 2] & (int) byte.MaxValue) << 8 | (int) numArray1[numArray1.Length - 1] & (int) byte.MaxValue;
      if (IsoTrailers.NoTrailerAvailable(this.digest))
        throw new ArgumentException("unrecognised hash in signature");
      if (num2 != IsoTrailers.GetTrailer(this.digest))
        throw new InvalidOperationException("signer initialised with wrong digest for trailer " + num2.ToString());
      num1 = 2;
    }
    this.digest.DoFinal(new byte[this.hLen], 0);
    byte[] numArray2 = this.MaskGeneratorFunction1(numArray1, numArray1.Length - this.hLen - num1, this.hLen, numArray1.Length - this.hLen - num1);
    for (int index = 0; index != numArray2.Length; ++index)
      numArray1[index] ^= numArray2[index];
    numArray1[0] &= (byte) 127 /*0x7F*/;
    int sourceIndex = 0;
    do
      ;
    while (sourceIndex < numArray1.Length && numArray1[sourceIndex++] != (byte) 1);
    if (sourceIndex >= numArray1.Length)
      this.ClearBlock(numArray1);
    this.fullMessage = sourceIndex > 1;
    this.recoveredMessage = new byte[numArray2.Length - sourceIndex - this.saltLength];
    Array.Copy((Array) numArray1, sourceIndex, (Array) this.recoveredMessage, 0, this.recoveredMessage.Length);
    this.recoveredMessage.CopyTo((Array) this.mBuf, 0);
    this.preSig = signature;
    this.preBlock = numArray1;
    this.preMStart = sourceIndex;
    this.preTLength = num1;
  }

  public virtual void Update(byte input)
  {
    if (this.preSig == null && this.messageLength < this.mBuf.Length)
      this.mBuf[this.messageLength++] = input;
    else
      this.digest.Update(input);
  }

  public virtual void BlockUpdate(byte[] input, int inOff, int inLen)
  {
    if (this.preSig == null)
    {
      for (; inLen > 0 && this.messageLength < this.mBuf.Length; --inLen)
      {
        this.Update(input[inOff]);
        ++inOff;
      }
    }
    if (inLen <= 0)
      return;
    this.digest.BlockUpdate(input, inOff, inLen);
  }

  public virtual int GetMaxSignatureSize() => this.cipher.GetOutputBlockSize();

  public virtual byte[] GenerateSignature()
  {
    byte[] numArray1 = new byte[this.digest.GetDigestSize()];
    this.digest.DoFinal(numArray1, 0);
    byte[] numArray2 = new byte[8];
    this.LtoOSP((long) (this.messageLength * 8), numArray2);
    this.digest.BlockUpdate(numArray2, 0, numArray2.Length);
    this.digest.BlockUpdate(this.mBuf, 0, this.messageLength);
    this.digest.BlockUpdate(numArray1, 0, numArray1.Length);
    byte[] numArray3;
    if (this.standardSalt != null)
    {
      numArray3 = this.standardSalt;
    }
    else
    {
      numArray3 = new byte[this.saltLength];
      this.random.NextBytes(numArray3);
    }
    this.digest.BlockUpdate(numArray3, 0, numArray3.Length);
    byte[] numArray4 = new byte[this.digest.GetDigestSize()];
    this.digest.DoFinal(numArray4, 0);
    int num = 2;
    if (this.trailer == 188)
      num = 1;
    int index1 = this.block.Length - this.messageLength - numArray3.Length - this.hLen - num - 1;
    this.block[index1] = (byte) 1;
    Array.Copy((Array) this.mBuf, 0, (Array) this.block, index1 + 1, this.messageLength);
    Array.Copy((Array) numArray3, 0, (Array) this.block, index1 + 1 + this.messageLength, numArray3.Length);
    byte[] numArray5 = this.MaskGeneratorFunction1(numArray4, 0, numArray4.Length, this.block.Length - this.hLen - num);
    for (int index2 = 0; index2 != numArray5.Length; ++index2)
      this.block[index2] ^= numArray5[index2];
    Array.Copy((Array) numArray4, 0, (Array) this.block, this.block.Length - this.hLen - num, this.hLen);
    if (this.trailer == 188)
    {
      this.block[this.block.Length - 1] = (byte) 188;
    }
    else
    {
      this.block[this.block.Length - 2] = (byte) (this.trailer >>> 8);
      this.block[this.block.Length - 1] = (byte) this.trailer;
    }
    this.block[0] &= (byte) 127 /*0x7F*/;
    byte[] signature = this.cipher.ProcessBlock(this.block, 0, this.block.Length);
    this.ClearBlock(this.mBuf);
    this.ClearBlock(this.block);
    this.messageLength = 0;
    return signature;
  }

  public virtual bool VerifySignature(byte[] signature)
  {
    byte[] numArray1 = new byte[this.hLen];
    this.digest.DoFinal(numArray1, 0);
    if (this.preSig == null)
    {
      try
      {
        this.UpdateWithRecoveredMessage(signature);
      }
      catch (Exception ex)
      {
        return false;
      }
    }
    else if (!Arrays.AreEqual(this.preSig, signature))
      throw new InvalidOperationException("UpdateWithRecoveredMessage called on different signature");
    byte[] preBlock = this.preBlock;
    int preMstart = this.preMStart;
    int preTlength = this.preTLength;
    this.preSig = (byte[]) null;
    this.preBlock = (byte[]) null;
    byte[] numArray2 = new byte[8];
    this.LtoOSP((long) (this.recoveredMessage.Length * 8), numArray2);
    this.digest.BlockUpdate(numArray2, 0, numArray2.Length);
    if (this.recoveredMessage.Length != 0)
      this.digest.BlockUpdate(this.recoveredMessage, 0, this.recoveredMessage.Length);
    this.digest.BlockUpdate(numArray1, 0, numArray1.Length);
    if (this.standardSalt != null)
      this.digest.BlockUpdate(this.standardSalt, 0, this.standardSalt.Length);
    else
      this.digest.BlockUpdate(preBlock, preMstart + this.recoveredMessage.Length, this.saltLength);
    byte[] numArray3 = new byte[this.digest.GetDigestSize()];
    this.digest.DoFinal(numArray3, 0);
    int num = preBlock.Length - preTlength - numArray3.Length;
    bool flag = true;
    for (int index = 0; index != numArray3.Length; ++index)
    {
      if ((int) numArray3[index] != (int) preBlock[num + index])
        flag = false;
    }
    this.ClearBlock(preBlock);
    this.ClearBlock(numArray3);
    if (!flag)
    {
      this.fullMessage = false;
      this.messageLength = 0;
      this.ClearBlock(this.recoveredMessage);
      return false;
    }
    if (this.messageLength != 0 && !this.IsSameAs(this.mBuf, this.recoveredMessage))
    {
      this.messageLength = 0;
      this.ClearBlock(this.mBuf);
      return false;
    }
    this.messageLength = 0;
    this.ClearBlock(this.mBuf);
    return true;
  }

  public virtual void Reset()
  {
    this.digest.Reset();
    this.messageLength = 0;
    if (this.mBuf != null)
      this.ClearBlock(this.mBuf);
    if (this.recoveredMessage != null)
    {
      this.ClearBlock(this.recoveredMessage);
      this.recoveredMessage = (byte[]) null;
    }
    this.fullMessage = false;
    if (this.preSig == null)
      return;
    this.preSig = (byte[]) null;
    this.ClearBlock(this.preBlock);
    this.preBlock = (byte[]) null;
  }

  public virtual bool HasFullMessage() => this.fullMessage;

  private void ItoOSP(int i, byte[] sp)
  {
    sp[0] = (byte) (i >>> 24);
    sp[1] = (byte) (i >>> 16 /*0x10*/);
    sp[2] = (byte) (i >>> 8);
    sp[3] = (byte) i;
  }

  private void LtoOSP(long l, byte[] sp)
  {
    sp[0] = (byte) (l >>> 56);
    sp[1] = (byte) (l >>> 48 /*0x30*/);
    sp[2] = (byte) (l >>> 40);
    sp[3] = (byte) (l >>> 32 /*0x20*/);
    sp[4] = (byte) (l >>> 24);
    sp[5] = (byte) (l >>> 16 /*0x10*/);
    sp[6] = (byte) (l >>> 8);
    sp[7] = (byte) l;
  }

  private byte[] MaskGeneratorFunction1(byte[] Z, int zOff, int zLen, int length)
  {
    byte[] destinationArray = new byte[length];
    byte[] numArray1 = new byte[this.hLen];
    byte[] numArray2 = new byte[4];
    int i = 0;
    this.digest.Reset();
    do
    {
      this.ItoOSP(i, numArray2);
      this.digest.BlockUpdate(Z, zOff, zLen);
      this.digest.BlockUpdate(numArray2, 0, numArray2.Length);
      this.digest.DoFinal(numArray1, 0);
      Array.Copy((Array) numArray1, 0, (Array) destinationArray, i * this.hLen, this.hLen);
    }
    while (++i < length / this.hLen);
    if (i * this.hLen < length)
    {
      this.ItoOSP(i, numArray2);
      this.digest.BlockUpdate(Z, zOff, zLen);
      this.digest.BlockUpdate(numArray2, 0, numArray2.Length);
      this.digest.DoFinal(numArray1, 0);
      Array.Copy((Array) numArray1, 0, (Array) destinationArray, i * this.hLen, destinationArray.Length - i * this.hLen);
    }
    return destinationArray;
  }
}
