// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Signers.Iso9796d2Signer
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Signers;

public class Iso9796d2Signer : ISignerWithRecovery, ISigner
{
  private IDigest digest;
  private IAsymmetricBlockCipher cipher;
  private int trailer;
  private int keyBits;
  private byte[] block;
  private byte[] mBuf;
  private int messageLength;
  private bool fullMessage;
  private byte[] recoveredMessage;
  private byte[] preSig;
  private byte[] preBlock;

  public byte[] GetRecoveredMessage() => this.recoveredMessage;

  public Iso9796d2Signer(IAsymmetricBlockCipher cipher, IDigest digest, bool isImplicit)
  {
    this.cipher = cipher;
    this.digest = digest;
    if (isImplicit)
      this.trailer = 188;
    else
      this.trailer = !IsoTrailers.NoTrailerAvailable(digest) ? IsoTrailers.GetTrailer(digest) : throw new ArgumentException("no valid trailer", nameof (digest));
  }

  public Iso9796d2Signer(IAsymmetricBlockCipher cipher, IDigest digest)
    : this(cipher, digest, false)
  {
  }

  public virtual string AlgorithmName => this.digest.AlgorithmName + "withISO9796-2S1";

  public virtual void Init(bool forSigning, ICipherParameters parameters)
  {
    RsaKeyParameters parameters1 = (RsaKeyParameters) parameters;
    this.cipher.Init(forSigning, (ICipherParameters) parameters1);
    this.keyBits = parameters1.Modulus.BitLength;
    this.block = new byte[(this.keyBits + 7) / 8];
    this.mBuf = this.trailer != 188 ? new byte[this.block.Length - this.digest.GetDigestSize() - 3] : new byte[this.block.Length - this.digest.GetDigestSize() - 2];
    this.Reset();
  }

  private bool IsSameAs(byte[] a, byte[] b)
  {
    int length;
    if (this.messageLength > this.mBuf.Length)
    {
      if (this.mBuf.Length > b.Length)
        return false;
      length = this.mBuf.Length;
    }
    else
    {
      if (this.messageLength != b.Length)
        return false;
      length = b.Length;
    }
    bool flag = true;
    for (int index = 0; index != length; ++index)
    {
      if ((int) a[index] != (int) b[index])
        flag = false;
    }
    return flag;
  }

  private void ClearBlock(byte[] block) => Array.Clear((Array) block, 0, block.Length);

  public virtual void UpdateWithRecoveredMessage(byte[] signature)
  {
    byte[] sourceArray = this.cipher.ProcessBlock(signature, 0, signature.Length);
    if (((int) sourceArray[0] & 192 /*0xC0*/ ^ 64 /*0x40*/) != 0)
      throw new InvalidCipherTextException("malformed signature");
    if (((int) sourceArray[sourceArray.Length - 1] & 15 ^ 12) != 0)
      throw new InvalidCipherTextException("malformed signature");
    int num1;
    if (((int) sourceArray[sourceArray.Length - 1] & (int) byte.MaxValue ^ 188) == 0)
    {
      num1 = 1;
    }
    else
    {
      int num2 = ((int) sourceArray[sourceArray.Length - 2] & (int) byte.MaxValue) << 8 | (int) sourceArray[sourceArray.Length - 1] & (int) byte.MaxValue;
      if (IsoTrailers.NoTrailerAvailable(this.digest))
        throw new ArgumentException("unrecognised hash in signature");
      if (num2 != IsoTrailers.GetTrailer(this.digest))
        throw new InvalidOperationException("signer initialised with wrong digest for trailer " + num2.ToString());
      num1 = 2;
    }
    int index = 0;
    while (index != sourceArray.Length && ((int) sourceArray[index] & 15 ^ 10) != 0)
      ++index;
    int sourceIndex = index + 1;
    int num3 = sourceArray.Length - num1 - this.digest.GetDigestSize();
    if (num3 - sourceIndex <= 0)
      throw new InvalidCipherTextException("malformed block");
    if (((int) sourceArray[0] & 32 /*0x20*/) == 0)
    {
      this.fullMessage = true;
      this.recoveredMessage = new byte[num3 - sourceIndex];
      Array.Copy((Array) sourceArray, sourceIndex, (Array) this.recoveredMessage, 0, this.recoveredMessage.Length);
    }
    else
    {
      this.fullMessage = false;
      this.recoveredMessage = new byte[num3 - sourceIndex];
      Array.Copy((Array) sourceArray, sourceIndex, (Array) this.recoveredMessage, 0, this.recoveredMessage.Length);
    }
    this.preSig = signature;
    this.preBlock = sourceArray;
    this.digest.BlockUpdate(this.recoveredMessage, 0, this.recoveredMessage.Length);
    this.messageLength = this.recoveredMessage.Length;
    this.recoveredMessage.CopyTo((Array) this.mBuf, 0);
  }

  public virtual void Update(byte input)
  {
    this.digest.Update(input);
    if (this.messageLength < this.mBuf.Length)
      this.mBuf[this.messageLength] = input;
    ++this.messageLength;
  }

  public virtual void BlockUpdate(byte[] input, int inOff, int inLen)
  {
    for (; inLen > 0 && this.messageLength < this.mBuf.Length; --inLen)
    {
      this.Update(input[inOff]);
      ++inOff;
    }
    if (inLen <= 0)
      return;
    this.digest.BlockUpdate(input, inOff, inLen);
    this.messageLength += inLen;
  }

  public virtual int GetMaxSignatureSize() => this.cipher.GetOutputBlockSize();

  public virtual byte[] GenerateSignature()
  {
    int digestSize = this.digest.GetDigestSize();
    int num1;
    int outOff;
    if (this.trailer == 188)
    {
      num1 = 8;
      outOff = this.block.Length - digestSize - 1;
      this.digest.DoFinal(this.block, outOff);
      this.block[this.block.Length - 1] = (byte) 188;
    }
    else
    {
      num1 = 16 /*0x10*/;
      outOff = this.block.Length - digestSize - 2;
      this.digest.DoFinal(this.block, outOff);
      this.block[this.block.Length - 2] = (byte) (this.trailer >>> 8);
      this.block[this.block.Length - 1] = (byte) this.trailer;
    }
    int num2 = (digestSize + this.messageLength) * 8 + num1 + 4 - this.keyBits;
    byte num3;
    int destinationIndex;
    if (num2 > 0)
    {
      int length = this.messageLength - (num2 + 7) / 8;
      num3 = (byte) 96 /*0x60*/;
      destinationIndex = outOff - length;
      Array.Copy((Array) this.mBuf, 0, (Array) this.block, destinationIndex, length);
    }
    else
    {
      num3 = (byte) 64 /*0x40*/;
      destinationIndex = outOff - this.messageLength;
      Array.Copy((Array) this.mBuf, 0, (Array) this.block, destinationIndex, this.messageLength);
    }
    if (destinationIndex - 1 > 0)
    {
      for (int index = destinationIndex - 1; index != 0; --index)
        this.block[index] = (byte) 187;
      this.block[destinationIndex - 1] ^= (byte) 1;
      this.block[0] = (byte) 11;
      this.block[0] |= num3;
    }
    else
    {
      this.block[0] = (byte) 10;
      this.block[0] |= num3;
    }
    byte[] signature = this.cipher.ProcessBlock(this.block, 0, this.block.Length);
    this.messageLength = 0;
    this.ClearBlock(this.mBuf);
    this.ClearBlock(this.block);
    return signature;
  }

  public virtual bool VerifySignature(byte[] signature)
  {
    byte[] numArray;
    if (this.preSig == null)
    {
      try
      {
        numArray = this.cipher.ProcessBlock(signature, 0, signature.Length);
      }
      catch (Exception ex)
      {
        return false;
      }
    }
    else
    {
      if (!Arrays.AreEqual(this.preSig, signature))
        throw new InvalidOperationException("updateWithRecoveredMessage called on different signature");
      numArray = this.preBlock;
      this.preSig = (byte[]) null;
      this.preBlock = (byte[]) null;
    }
    if (((int) numArray[0] & 192 /*0xC0*/ ^ 64 /*0x40*/) != 0 || ((int) numArray[numArray.Length - 1] & 15 ^ 12) != 0)
      return this.ReturnFalse(numArray);
    int num1;
    if (((int) numArray[numArray.Length - 1] & (int) byte.MaxValue ^ 188) == 0)
    {
      num1 = 1;
    }
    else
    {
      int num2 = ((int) numArray[numArray.Length - 2] & (int) byte.MaxValue) << 8 | (int) numArray[numArray.Length - 1] & (int) byte.MaxValue;
      if (IsoTrailers.NoTrailerAvailable(this.digest))
        throw new ArgumentException("unrecognised hash in signature");
      if (num2 != IsoTrailers.GetTrailer(this.digest))
        throw new InvalidOperationException("signer initialised with wrong digest for trailer " + num2.ToString());
      num1 = 2;
    }
    int index1 = 0;
    while (index1 != numArray.Length && ((int) numArray[index1] & 15 ^ 10) != 0)
      ++index1;
    int num3 = index1 + 1;
    byte[] output = new byte[this.digest.GetDigestSize()];
    int num4 = numArray.Length - num1 - output.Length;
    if (num4 - num3 <= 0)
      return this.ReturnFalse(numArray);
    if (((int) numArray[0] & 32 /*0x20*/) == 0)
    {
      this.fullMessage = true;
      if (this.messageLength > num4 - num3)
        return this.ReturnFalse(numArray);
      this.digest.Reset();
      this.digest.BlockUpdate(numArray, num3, num4 - num3);
      this.digest.DoFinal(output, 0);
      bool flag = true;
      for (int index2 = 0; index2 != output.Length; ++index2)
      {
        numArray[num4 + index2] ^= output[index2];
        if (numArray[num4 + index2] != (byte) 0)
          flag = false;
      }
      if (!flag)
        return this.ReturnFalse(numArray);
      this.recoveredMessage = new byte[num4 - num3];
      Array.Copy((Array) numArray, num3, (Array) this.recoveredMessage, 0, this.recoveredMessage.Length);
    }
    else
    {
      this.fullMessage = false;
      this.digest.DoFinal(output, 0);
      bool flag = true;
      for (int index3 = 0; index3 != output.Length; ++index3)
      {
        numArray[num4 + index3] ^= output[index3];
        if (numArray[num4 + index3] != (byte) 0)
          flag = false;
      }
      if (!flag)
        return this.ReturnFalse(numArray);
      this.recoveredMessage = new byte[num4 - num3];
      Array.Copy((Array) numArray, num3, (Array) this.recoveredMessage, 0, this.recoveredMessage.Length);
    }
    if (this.messageLength != 0 && !this.IsSameAs(this.mBuf, this.recoveredMessage))
      return this.ReturnFalse(numArray);
    this.ClearBlock(this.mBuf);
    this.ClearBlock(numArray);
    this.messageLength = 0;
    return true;
  }

  public virtual void Reset()
  {
    this.digest.Reset();
    this.messageLength = 0;
    this.ClearBlock(this.mBuf);
    if (this.recoveredMessage != null)
      this.ClearBlock(this.recoveredMessage);
    this.recoveredMessage = (byte[]) null;
    this.fullMessage = false;
    if (this.preSig == null)
      return;
    this.preSig = (byte[]) null;
    this.ClearBlock(this.preBlock);
    this.preBlock = (byte[]) null;
  }

  private bool ReturnFalse(byte[] block)
  {
    this.messageLength = 0;
    this.ClearBlock(this.mBuf);
    this.ClearBlock(block);
    return false;
  }

  public virtual bool HasFullMessage() => this.fullMessage;
}
