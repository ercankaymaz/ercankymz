// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Modes.CcmBlockCipher
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Crypto.Modes;

public class CcmBlockCipher : IAeadBlockCipher, IAeadCipher
{
  private static readonly int BlockSize = 16 /*0x10*/;
  private readonly IBlockCipher cipher;
  private readonly byte[] macBlock;
  private bool forEncryption;
  private byte[] nonce;
  private byte[] initialAssociatedText;
  private int macSize;
  private ICipherParameters keyParam;
  private readonly MemoryStream associatedText = new MemoryStream();
  private readonly MemoryStream data = new MemoryStream();

  public CcmBlockCipher(IBlockCipher cipher)
  {
    this.cipher = cipher;
    this.macBlock = new byte[CcmBlockCipher.BlockSize];
    if (cipher.GetBlockSize() != CcmBlockCipher.BlockSize)
      throw new ArgumentException($"cipher required with a block size of {CcmBlockCipher.BlockSize.ToString()}.");
  }

  public virtual IBlockCipher UnderlyingCipher => this.cipher;

  public virtual void Init(bool forEncryption, ICipherParameters parameters)
  {
    this.forEncryption = forEncryption;
    ICipherParameters cipherParameters;
    switch (parameters)
    {
      case AeadParameters aeadParameters:
        this.nonce = aeadParameters.GetNonce();
        this.initialAssociatedText = aeadParameters.GetAssociatedText();
        this.macSize = this.GetMacSize(forEncryption, aeadParameters.MacSize);
        cipherParameters = (ICipherParameters) aeadParameters.Key;
        break;
      case ParametersWithIV parametersWithIv:
        this.nonce = parametersWithIv.GetIV();
        this.initialAssociatedText = (byte[]) null;
        this.macSize = this.GetMacSize(forEncryption, 64 /*0x40*/);
        cipherParameters = parametersWithIv.Parameters;
        break;
      default:
        throw new ArgumentException("invalid parameters passed to CCM");
    }
    if (cipherParameters != null)
      this.keyParam = cipherParameters;
    if (this.nonce.Length < 7 || this.nonce.Length > 13)
      throw new ArgumentException("nonce must have length from 7 to 13 octets");
    this.Reset();
  }

  public virtual string AlgorithmName => this.cipher.AlgorithmName + "/CCM";

  public virtual int GetBlockSize() => this.cipher.GetBlockSize();

  public virtual void ProcessAadByte(byte input) => this.associatedText.WriteByte(input);

  public virtual void ProcessAadBytes(byte[] inBytes, int inOff, int len)
  {
    this.associatedText.Write(inBytes, inOff, len);
  }

  public virtual int ProcessByte(byte input, byte[] outBytes, int outOff)
  {
    this.data.WriteByte(input);
    return 0;
  }

  public virtual int ProcessBytes(
    byte[] inBytes,
    int inOff,
    int inLen,
    byte[] outBytes,
    int outOff)
  {
    Org.BouncyCastle.Crypto.Check.DataLength(inBytes, inOff, inLen, "input buffer too short");
    this.data.Write(inBytes, inOff, inLen);
    return 0;
  }

  public virtual int DoFinal(byte[] outBytes, int outOff)
  {
    int num = this.ProcessPacket(this.data.GetBuffer(), 0, Convert.ToInt32(this.data.Length), outBytes, outOff);
    this.Reset();
    return num;
  }

  public virtual void Reset()
  {
    this.associatedText.SetLength(0L);
    this.data.SetLength(0L);
  }

  public virtual byte[] GetMac() => Arrays.CopyOfRange(this.macBlock, 0, this.macSize);

  public virtual int GetUpdateOutputSize(int len) => 0;

  public virtual int GetOutputSize(int len)
  {
    int num = Convert.ToInt32(this.data.Length) + len;
    if (this.forEncryption)
      return num + this.macSize;
    return num >= this.macSize ? num - this.macSize : 0;
  }

  public virtual byte[] ProcessPacket(byte[] input, int inOff, int inLen)
  {
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, inLen, "input buffer too short");
    byte[] output;
    if (this.forEncryption)
      output = new byte[inLen + this.macSize];
    else
      output = inLen >= this.macSize ? new byte[inLen - this.macSize] : throw new InvalidCipherTextException("data too short");
    this.ProcessPacket(input, inOff, inLen, output, 0);
    return output;
  }

  public virtual int ProcessPacket(byte[] input, int inOff, int inLen, byte[] output, int outOff)
  {
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, inLen, "input buffer too short");
    if (this.keyParam == null)
      throw new InvalidOperationException("CCM cipher unitialized.");
    int num1 = 15 - this.nonce.Length;
    if (num1 < 4)
    {
      int num2 = 1 << 8 * num1;
      if (inLen >= num2)
        throw new InvalidOperationException("CCM packet too large for choice of q.");
    }
    byte[] iv = new byte[CcmBlockCipher.BlockSize];
    iv[0] = (byte) (num1 - 1 & 7);
    this.nonce.CopyTo((Array) iv, 1);
    SicBlockCipher sicBlockCipher = new SicBlockCipher(this.cipher);
    sicBlockCipher.Init(this.forEncryption, (ICipherParameters) new ParametersWithIV(this.keyParam, iv));
    int num3 = inOff;
    int num4 = outOff;
    int num5;
    if (this.forEncryption)
    {
      num5 = inLen + this.macSize;
      Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, num5, "Output buffer too short.");
      this.CalculateMac(input, inOff, inLen, this.macBlock);
      byte[] numArray1 = new byte[CcmBlockCipher.BlockSize];
      sicBlockCipher.ProcessBlock(this.macBlock, 0, numArray1, 0);
      for (; num3 < inOff + inLen - CcmBlockCipher.BlockSize; num3 += CcmBlockCipher.BlockSize)
      {
        sicBlockCipher.ProcessBlock(input, num3, output, num4);
        num4 += CcmBlockCipher.BlockSize;
      }
      byte[] numArray2 = new byte[CcmBlockCipher.BlockSize];
      Array.Copy((Array) input, num3, (Array) numArray2, 0, inLen + inOff - num3);
      sicBlockCipher.ProcessBlock(numArray2, 0, numArray2, 0);
      Array.Copy((Array) numArray2, 0, (Array) output, num4, inLen + inOff - num3);
      Array.Copy((Array) numArray1, 0, (Array) output, outOff + inLen, this.macSize);
    }
    else
    {
      if (inLen < this.macSize)
        throw new InvalidCipherTextException("data too short");
      num5 = inLen - this.macSize;
      Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, num5, "Output buffer too short.");
      Array.Copy((Array) input, inOff + num5, (Array) this.macBlock, 0, this.macSize);
      sicBlockCipher.ProcessBlock(this.macBlock, 0, this.macBlock, 0);
      for (int macSize = this.macSize; macSize != this.macBlock.Length; ++macSize)
        this.macBlock[macSize] = (byte) 0;
      for (; num3 < inOff + num5 - CcmBlockCipher.BlockSize; num3 += CcmBlockCipher.BlockSize)
      {
        sicBlockCipher.ProcessBlock(input, num3, output, num4);
        num4 += CcmBlockCipher.BlockSize;
      }
      byte[] numArray3 = new byte[CcmBlockCipher.BlockSize];
      Array.Copy((Array) input, num3, (Array) numArray3, 0, num5 - (num3 - inOff));
      sicBlockCipher.ProcessBlock(numArray3, 0, numArray3, 0);
      Array.Copy((Array) numArray3, 0, (Array) output, num4, num5 - (num3 - inOff));
      byte[] numArray4 = new byte[CcmBlockCipher.BlockSize];
      this.CalculateMac(output, outOff, num5, numArray4);
      if (!Arrays.FixedTimeEquals(this.macBlock, numArray4))
        throw new InvalidCipherTextException("mac check in CCM failed");
    }
    return num5;
  }

  private int CalculateMac(byte[] data, int dataOff, int dataLen, byte[] macBlock)
  {
    CbcBlockCipherMac cbcBlockCipherMac = new CbcBlockCipherMac(this.cipher, this.macSize * 8);
    cbcBlockCipherMac.Init(this.keyParam);
    byte[] numArray = new byte[16 /*0x10*/];
    if (this.HasAssociatedText())
      numArray[0] |= (byte) 64 /*0x40*/;
    numArray[0] |= (byte) (((cbcBlockCipherMac.GetMacSize() - 2) / 2 & 7) << 3);
    numArray[0] |= (byte) (15 - this.nonce.Length - 1 & 7);
    Array.Copy((Array) this.nonce, 0, (Array) numArray, 1, this.nonce.Length);
    int num1 = dataLen;
    int num2 = 1;
    while (num1 > 0)
    {
      numArray[numArray.Length - num2] = (byte) (num1 & (int) byte.MaxValue);
      num1 >>= 8;
      ++num2;
    }
    cbcBlockCipherMac.BlockUpdate(numArray, 0, numArray.Length);
    if (this.HasAssociatedText())
    {
      int associatedTextLength = this.GetAssociatedTextLength();
      int num3;
      if (associatedTextLength < 65280)
      {
        cbcBlockCipherMac.Update((byte) (associatedTextLength >> 8));
        cbcBlockCipherMac.Update((byte) associatedTextLength);
        num3 = 2;
      }
      else
      {
        cbcBlockCipherMac.Update(byte.MaxValue);
        cbcBlockCipherMac.Update((byte) 254);
        cbcBlockCipherMac.Update((byte) (associatedTextLength >> 24));
        cbcBlockCipherMac.Update((byte) (associatedTextLength >> 16 /*0x10*/));
        cbcBlockCipherMac.Update((byte) (associatedTextLength >> 8));
        cbcBlockCipherMac.Update((byte) associatedTextLength);
        num3 = 6;
      }
      if (this.initialAssociatedText != null)
        cbcBlockCipherMac.BlockUpdate(this.initialAssociatedText, 0, this.initialAssociatedText.Length);
      if (this.associatedText.Length > 0L)
      {
        byte[] buffer = this.associatedText.GetBuffer();
        int int32 = Convert.ToInt32(this.associatedText.Length);
        cbcBlockCipherMac.BlockUpdate(buffer, 0, int32);
      }
      int num4 = (num3 + associatedTextLength) % 16 /*0x10*/;
      if (num4 != 0)
      {
        for (int index = num4; index < 16 /*0x10*/; ++index)
          cbcBlockCipherMac.Update((byte) 0);
      }
    }
    cbcBlockCipherMac.BlockUpdate(data, dataOff, dataLen);
    return cbcBlockCipherMac.DoFinal(macBlock, 0);
  }

  private int GetMacSize(bool forEncryption, int requestedMacBits)
  {
    if (forEncryption && (requestedMacBits < 32 /*0x20*/ || requestedMacBits > 128 /*0x80*/ || (requestedMacBits & 15) != 0))
      throw new ArgumentException("tag length in octets must be one of {4,6,8,10,12,14,16}");
    return requestedMacBits >> 3;
  }

  private int GetAssociatedTextLength()
  {
    return Convert.ToInt32(this.associatedText.Length) + (this.initialAssociatedText == null ? 0 : this.initialAssociatedText.Length);
  }

  private bool HasAssociatedText() => this.GetAssociatedTextLength() > 0;
}
