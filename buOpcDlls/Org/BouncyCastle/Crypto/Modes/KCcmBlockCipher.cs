// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Modes.KCcmBlockCipher
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities;
using System;
using System.IO;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Crypto.Modes;

public class KCcmBlockCipher : IAeadBlockCipher, IAeadCipher
{
  private static readonly int BYTES_IN_INT = 4;
  private static readonly int BITS_IN_BYTE = 8;
  private static readonly int MAX_MAC_BIT_LENGTH = 512 /*0x0200*/;
  private static readonly int MIN_MAC_BIT_LENGTH = 64 /*0x40*/;
  private IBlockCipher engine;
  private int macSize;
  private bool forEncryption;
  private byte[] initialAssociatedText;
  private byte[] mac;
  private byte[] macBlock;
  private byte[] nonce;
  private byte[] G1;
  private byte[] buffer;
  private byte[] s;
  private byte[] counter;
  private readonly MemoryStream associatedText = new MemoryStream();
  private readonly MemoryStream data = new MemoryStream();
  private int Nb_ = 4;

  private void SetNb(int Nb)
  {
    this.Nb_ = Nb == 4 || Nb == 6 || Nb == 8 ? Nb : throw new ArgumentException("Nb = 4 is recommended by DSTU7624 but can be changed to only 6 or 8 in this implementation");
  }

  public KCcmBlockCipher(IBlockCipher engine)
    : this(engine, 4)
  {
  }

  public KCcmBlockCipher(IBlockCipher engine, int Nb)
  {
    this.engine = engine;
    this.macSize = engine.GetBlockSize();
    this.nonce = new byte[engine.GetBlockSize()];
    this.initialAssociatedText = new byte[engine.GetBlockSize()];
    this.mac = new byte[engine.GetBlockSize()];
    this.macBlock = new byte[engine.GetBlockSize()];
    this.G1 = new byte[engine.GetBlockSize()];
    this.buffer = new byte[engine.GetBlockSize()];
    this.s = new byte[engine.GetBlockSize()];
    this.counter = new byte[engine.GetBlockSize()];
    this.SetNb(Nb);
  }

  public virtual void Init(bool forEncryption, ICipherParameters parameters)
  {
    ICipherParameters parameters1;
    switch (parameters)
    {
      case AeadParameters aeadParameters:
        if (aeadParameters.MacSize > KCcmBlockCipher.MAX_MAC_BIT_LENGTH || aeadParameters.MacSize < KCcmBlockCipher.MIN_MAC_BIT_LENGTH || aeadParameters.MacSize % 8 != 0)
          throw new ArgumentException("Invalid mac size specified");
        this.nonce = aeadParameters.GetNonce();
        this.macSize = aeadParameters.MacSize / KCcmBlockCipher.BITS_IN_BYTE;
        this.initialAssociatedText = aeadParameters.GetAssociatedText();
        parameters1 = (ICipherParameters) aeadParameters.Key;
        break;
      case ParametersWithIV parametersWithIv:
        this.nonce = parametersWithIv.GetIV();
        this.macSize = this.engine.GetBlockSize();
        this.initialAssociatedText = (byte[]) null;
        parameters1 = parametersWithIv.Parameters;
        break;
      default:
        throw new ArgumentException("Invalid parameters specified");
    }
    this.mac = new byte[this.macSize];
    this.forEncryption = forEncryption;
    this.engine.Init(true, parameters1);
    this.counter[0] = (byte) 1;
    if (this.initialAssociatedText == null)
      return;
    this.ProcessAadBytes(this.initialAssociatedText, 0, this.initialAssociatedText.Length);
  }

  public virtual string AlgorithmName => this.engine.AlgorithmName + "/KCCM";

  public virtual int GetBlockSize() => this.engine.GetBlockSize();

  public virtual IBlockCipher UnderlyingCipher => this.engine;

  public virtual void ProcessAadByte(byte input) => this.associatedText.WriteByte(input);

  public virtual void ProcessAadBytes(byte[] input, int inOff, int len)
  {
    this.associatedText.Write(input, inOff, len);
  }

  private void ProcessAAD(byte[] assocText, int assocOff, int assocLen, int dataLen)
  {
    if (assocLen - assocOff < this.engine.GetBlockSize())
      throw new ArgumentException("authText buffer too short");
    if (assocLen % this.engine.GetBlockSize() != 0)
      throw new ArgumentException("padding not supported");
    Array.Copy((Array) this.nonce, 0, (Array) this.G1, 0, this.nonce.Length - this.Nb_ - 1);
    this.intToBytes(dataLen, this.buffer, 0);
    Array.Copy((Array) this.buffer, 0, (Array) this.G1, this.nonce.Length - this.Nb_ - 1, KCcmBlockCipher.BYTES_IN_INT);
    this.G1[this.G1.Length - 1] = this.getFlag(true, this.macSize);
    this.engine.ProcessBlock(this.G1, 0, this.macBlock, 0);
    this.intToBytes(assocLen, this.buffer, 0);
    if (assocLen <= this.engine.GetBlockSize() - this.Nb_)
    {
      for (int index = 0; index < assocLen; ++index)
        this.buffer[index + this.Nb_] ^= assocText[assocOff + index];
      for (int index = 0; index < this.engine.GetBlockSize(); ++index)
        this.macBlock[index] ^= this.buffer[index];
      this.engine.ProcessBlock(this.macBlock, 0, this.macBlock, 0);
    }
    else
    {
      for (int index = 0; index < this.engine.GetBlockSize(); ++index)
        this.macBlock[index] ^= this.buffer[index];
      this.engine.ProcessBlock(this.macBlock, 0, this.macBlock, 0);
      for (int index1 = assocLen; index1 != 0; index1 -= this.engine.GetBlockSize())
      {
        for (int index2 = 0; index2 < this.engine.GetBlockSize(); ++index2)
          this.macBlock[index2] ^= assocText[index2 + assocOff];
        this.engine.ProcessBlock(this.macBlock, 0, this.macBlock, 0);
        assocOff += this.engine.GetBlockSize();
      }
    }
  }

  public virtual int ProcessByte(byte input, byte[] output, int outOff)
  {
    this.data.WriteByte(input);
    return 0;
  }

  public virtual int ProcessBytes(byte[] input, int inOff, int inLen, byte[] output, int outOff)
  {
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, inLen, "input buffer too short");
    this.data.Write(input, inOff, inLen);
    return 0;
  }

  public int ProcessPacket(byte[] input, int inOff, int len, byte[] output, int outOff)
  {
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, len, "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, len, "output buffer too short");
    if (this.associatedText.Length > 0L)
      this.ProcessAAD(this.associatedText.GetBuffer(), 0, Convert.ToInt32(this.associatedText.Length), Convert.ToInt32(this.data.Length) - (this.forEncryption ? 0 : this.macSize));
    if (this.forEncryption)
    {
      Org.BouncyCastle.Crypto.Check.DataLength(len % this.engine.GetBlockSize() != 0, "partial blocks not supported");
      this.CalculateMac(input, inOff, len);
      this.engine.ProcessBlock(this.nonce, 0, this.s, 0);
      int num = len;
      while (num > 0)
      {
        this.ProcessBlock(input, inOff, output, outOff);
        num -= this.engine.GetBlockSize();
        inOff += this.engine.GetBlockSize();
        outOff += this.engine.GetBlockSize();
      }
      for (int index = 0; index < this.counter.Length; ++index)
        this.s[index] += this.counter[index];
      this.engine.ProcessBlock(this.s, 0, this.buffer, 0);
      for (int index = 0; index < this.macSize; ++index)
        output[outOff + index] = (byte) ((uint) this.buffer[index] ^ (uint) this.macBlock[index]);
      Array.Copy((Array) this.macBlock, 0, (Array) this.mac, 0, this.macSize);
      this.Reset();
      return len + this.macSize;
    }
    Org.BouncyCastle.Crypto.Check.DataLength((len - this.macSize) % this.engine.GetBlockSize() != 0, "partial blocks not supported");
    this.engine.ProcessBlock(this.nonce, 0, this.s, 0);
    int num1 = len / this.engine.GetBlockSize();
    for (int index = 0; index < num1; ++index)
    {
      this.ProcessBlock(input, inOff, output, outOff);
      inOff += this.engine.GetBlockSize();
      outOff += this.engine.GetBlockSize();
    }
    if (len > inOff)
    {
      for (int index = 0; index < this.counter.Length; ++index)
        this.s[index] += this.counter[index];
      this.engine.ProcessBlock(this.s, 0, this.buffer, 0);
      for (int index = 0; index < this.macSize; ++index)
        output[outOff + index] = (byte) ((uint) this.buffer[index] ^ (uint) input[inOff + index]);
      outOff += this.macSize;
    }
    for (int index = 0; index < this.counter.Length; ++index)
      this.s[index] += this.counter[index];
    this.engine.ProcessBlock(this.s, 0, this.buffer, 0);
    Array.Copy((Array) output, outOff - this.macSize, (Array) this.buffer, 0, this.macSize);
    this.CalculateMac(output, 0, outOff - this.macSize);
    Array.Copy((Array) this.macBlock, 0, (Array) this.mac, 0, this.macSize);
    byte[] numArray = new byte[this.macSize];
    Array.Copy((Array) this.buffer, 0, (Array) numArray, 0, this.macSize);
    if (!Arrays.FixedTimeEquals(this.mac, numArray))
      throw new InvalidCipherTextException("mac check failed");
    this.Reset();
    return len - this.macSize;
  }

  private void CalculateMac(byte[] authText, int authOff, int len)
  {
    int blockSize = this.engine.GetBlockSize();
    int num = len;
    while (num > 0)
    {
      for (int index = 0; index < blockSize; ++index)
        this.macBlock[index] ^= authText[authOff + index];
      this.engine.ProcessBlock(this.macBlock, 0, this.macBlock, 0);
      num -= blockSize;
      authOff += blockSize;
    }
  }

  private void ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
  {
    for (int index = 0; index < this.counter.Length; ++index)
      this.s[index] += this.counter[index];
    this.engine.ProcessBlock(this.s, 0, this.buffer, 0);
    for (int index = 0; index < this.engine.GetBlockSize(); ++index)
      output[outOff + index] = (byte) ((uint) this.buffer[index] ^ (uint) input[inOff + index]);
  }

  public virtual int DoFinal(byte[] output, int outOff)
  {
    int num = this.ProcessPacket(this.data.GetBuffer(), 0, Convert.ToInt32(this.data.Length), output, outOff);
    this.Reset();
    return num;
  }

  public virtual byte[] GetMac() => Arrays.Clone(this.mac);

  public virtual int GetUpdateOutputSize(int len) => len;

  public virtual int GetOutputSize(int len) => len + this.macSize;

  public virtual void Reset()
  {
    Arrays.Fill(this.G1, (byte) 0);
    Arrays.Fill(this.buffer, (byte) 0);
    Arrays.Fill(this.counter, (byte) 0);
    Arrays.Fill(this.macBlock, (byte) 0);
    this.counter[0] = (byte) 1;
    this.data.SetLength(0L);
    this.associatedText.SetLength(0L);
    if (this.initialAssociatedText == null)
      return;
    this.ProcessAadBytes(this.initialAssociatedText, 0, this.initialAssociatedText.Length);
  }

  private void intToBytes(int num, byte[] outBytes, int outOff)
  {
    outBytes[outOff + 3] = (byte) (num >> 24);
    outBytes[outOff + 2] = (byte) (num >> 16 /*0x10*/);
    outBytes[outOff + 1] = (byte) (num >> 8);
    outBytes[outOff] = (byte) num;
  }

  private byte getFlag(bool authTextPresents, int macSize)
  {
    StringBuilder stringBuilder = new StringBuilder();
    if (authTextPresents)
      stringBuilder.Append("1");
    else
      stringBuilder.Append("0");
    switch (macSize)
    {
      case 8:
        stringBuilder.Append("010");
        break;
      case 16 /*0x10*/:
        stringBuilder.Append("011");
        break;
      case 32 /*0x20*/:
        stringBuilder.Append("100");
        break;
      case 48 /*0x30*/:
        stringBuilder.Append("101");
        break;
      case 64 /*0x40*/:
        stringBuilder.Append("110");
        break;
    }
    string str = Convert.ToString(this.Nb_ - 1, 2);
    while (str.Length < 4)
      str = new StringBuilder(str).Insert(0, "0").ToString();
    stringBuilder.Append(str);
    return (byte) Convert.ToInt32(stringBuilder.ToString(), 2);
  }
}
