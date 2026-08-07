// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Modes.EaxBlockCipher
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Modes;

public class EaxBlockCipher : IAeadBlockCipher, IAeadCipher
{
  private SicBlockCipher cipher;
  private bool forEncryption;
  private int blockSize;
  private IMac mac;
  private byte[] nonceMac;
  private byte[] associatedTextMac;
  private byte[] macBlock;
  private int macSize;
  private byte[] bufBlock;
  private int bufOff;
  private bool cipherInitialized;
  private byte[] initialAssociatedText;

  public EaxBlockCipher(IBlockCipher cipher)
  {
    this.blockSize = cipher.GetBlockSize();
    this.mac = (IMac) new CMac(cipher);
    this.macBlock = new byte[this.blockSize];
    this.associatedTextMac = new byte[this.mac.GetMacSize()];
    this.nonceMac = new byte[this.mac.GetMacSize()];
    this.cipher = new SicBlockCipher(cipher);
  }

  public virtual string AlgorithmName => this.cipher.UnderlyingCipher.AlgorithmName + "/EAX";

  public virtual IBlockCipher UnderlyingCipher => (IBlockCipher) this.cipher;

  public virtual int GetBlockSize() => this.cipher.GetBlockSize();

  public virtual void Init(bool forEncryption, ICipherParameters parameters)
  {
    this.forEncryption = forEncryption;
    byte[] input1;
    ICipherParameters parameters1;
    switch (parameters)
    {
      case AeadParameters aeadParameters:
        input1 = aeadParameters.GetNonce();
        this.initialAssociatedText = aeadParameters.GetAssociatedText();
        this.macSize = aeadParameters.MacSize / 8;
        parameters1 = (ICipherParameters) aeadParameters.Key;
        break;
      case ParametersWithIV parametersWithIv:
        input1 = parametersWithIv.GetIV();
        this.initialAssociatedText = (byte[]) null;
        this.macSize = this.mac.GetMacSize() / 2;
        parameters1 = parametersWithIv.Parameters;
        break;
      default:
        throw new ArgumentException("invalid parameters passed to EAX");
    }
    this.bufBlock = new byte[forEncryption ? this.blockSize : this.blockSize + this.macSize];
    byte[] input2 = new byte[this.blockSize];
    this.mac.Init(parameters1);
    input2[this.blockSize - 1] = (byte) 0;
    this.mac.BlockUpdate(input2, 0, this.blockSize);
    this.mac.BlockUpdate(input1, 0, input1.Length);
    this.mac.DoFinal(this.nonceMac, 0);
    this.cipher.Init(true, (ICipherParameters) new ParametersWithIV((ICipherParameters) null, this.nonceMac));
    this.Reset();
  }

  private void InitCipher()
  {
    if (this.cipherInitialized)
      return;
    this.cipherInitialized = true;
    this.mac.DoFinal(this.associatedTextMac, 0);
    byte[] input = new byte[this.blockSize];
    input[this.blockSize - 1] = (byte) 2;
    this.mac.BlockUpdate(input, 0, this.blockSize);
  }

  private void CalculateMac()
  {
    byte[] output = new byte[this.blockSize];
    this.mac.DoFinal(output, 0);
    for (int index = 0; index < this.macBlock.Length; ++index)
      this.macBlock[index] = (byte) ((uint) this.nonceMac[index] ^ (uint) this.associatedTextMac[index] ^ (uint) output[index]);
  }

  public virtual void Reset() => this.Reset(true);

  private void Reset(bool clearMac)
  {
    this.cipher.Reset();
    this.mac.Reset();
    this.bufOff = 0;
    Array.Clear((Array) this.bufBlock, 0, this.bufBlock.Length);
    if (clearMac)
      Array.Clear((Array) this.macBlock, 0, this.macBlock.Length);
    byte[] input = new byte[this.blockSize];
    input[this.blockSize - 1] = (byte) 1;
    this.mac.BlockUpdate(input, 0, this.blockSize);
    this.cipherInitialized = false;
    if (this.initialAssociatedText == null)
      return;
    this.ProcessAadBytes(this.initialAssociatedText, 0, this.initialAssociatedText.Length);
  }

  public virtual void ProcessAadByte(byte input)
  {
    if (this.cipherInitialized)
      throw new InvalidOperationException("AAD data cannot be added after encryption/decryption processing has begun.");
    this.mac.Update(input);
  }

  public virtual void ProcessAadBytes(byte[] inBytes, int inOff, int len)
  {
    if (this.cipherInitialized)
      throw new InvalidOperationException("AAD data cannot be added after encryption/decryption processing has begun.");
    this.mac.BlockUpdate(inBytes, inOff, len);
  }

  public virtual int ProcessByte(byte input, byte[] outBytes, int outOff)
  {
    this.InitCipher();
    return this.Process(input, outBytes, outOff);
  }

  public virtual int ProcessBytes(
    byte[] inBytes,
    int inOff,
    int len,
    byte[] outBytes,
    int outOff)
  {
    this.InitCipher();
    int num = 0;
    for (int index = 0; index != len; ++index)
      num += this.Process(inBytes[inOff + index], outBytes, outOff + num);
    return num;
  }

  public virtual int DoFinal(byte[] outBytes, int outOff)
  {
    this.InitCipher();
    int bufOff = this.bufOff;
    byte[] numArray = new byte[this.bufBlock.Length];
    this.bufOff = 0;
    if (this.forEncryption)
    {
      Org.BouncyCastle.Crypto.Check.OutputLength(outBytes, outOff, bufOff + this.macSize, "output buffer too short");
      this.cipher.ProcessBlock(this.bufBlock, 0, numArray, 0);
      Array.Copy((Array) numArray, 0, (Array) outBytes, outOff, bufOff);
      this.mac.BlockUpdate(numArray, 0, bufOff);
      this.CalculateMac();
      Array.Copy((Array) this.macBlock, 0, (Array) outBytes, outOff + bufOff, this.macSize);
      this.Reset(false);
      return bufOff + this.macSize;
    }
    if (bufOff < this.macSize)
      throw new InvalidCipherTextException("data too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(outBytes, outOff, bufOff - this.macSize, "output buffer too short");
    if (bufOff > this.macSize)
    {
      this.mac.BlockUpdate(this.bufBlock, 0, bufOff - this.macSize);
      this.cipher.ProcessBlock(this.bufBlock, 0, numArray, 0);
      Array.Copy((Array) numArray, 0, (Array) outBytes, outOff, bufOff - this.macSize);
    }
    this.CalculateMac();
    if (!this.VerifyMac(this.bufBlock, bufOff - this.macSize))
      throw new InvalidCipherTextException("mac check in EAX failed");
    this.Reset(false);
    return bufOff - this.macSize;
  }

  public virtual byte[] GetMac()
  {
    byte[] destinationArray = new byte[this.macSize];
    Array.Copy((Array) this.macBlock, 0, (Array) destinationArray, 0, this.macSize);
    return destinationArray;
  }

  public virtual int GetUpdateOutputSize(int len)
  {
    int num = len + this.bufOff;
    if (!this.forEncryption)
    {
      if (num < this.macSize)
        return 0;
      num -= this.macSize;
    }
    return num - num % this.blockSize;
  }

  public virtual int GetOutputSize(int len)
  {
    int num = len + this.bufOff;
    if (this.forEncryption)
      return num + this.macSize;
    return num >= this.macSize ? num - this.macSize : 0;
  }

  private int Process(byte b, byte[] outBytes, int outOff)
  {
    this.bufBlock[this.bufOff++] = b;
    if (this.bufOff != this.bufBlock.Length)
      return 0;
    Org.BouncyCastle.Crypto.Check.OutputLength(outBytes, outOff, this.blockSize, "Output buffer is too short");
    int num;
    if (this.forEncryption)
    {
      num = this.cipher.ProcessBlock(this.bufBlock, 0, outBytes, outOff);
      this.mac.BlockUpdate(outBytes, outOff, this.blockSize);
    }
    else
    {
      this.mac.BlockUpdate(this.bufBlock, 0, this.blockSize);
      num = this.cipher.ProcessBlock(this.bufBlock, 0, outBytes, outOff);
    }
    this.bufOff = 0;
    if (!this.forEncryption)
    {
      Array.Copy((Array) this.bufBlock, this.blockSize, (Array) this.bufBlock, 0, this.macSize);
      this.bufOff = this.macSize;
    }
    return num;
  }

  private bool VerifyMac(byte[] mac, int off)
  {
    return Arrays.FixedTimeEquals(this.macSize, mac, off, this.macBlock, 0);
  }

  private enum Tag : byte
  {
    N,
    H,
    C,
  }
}
