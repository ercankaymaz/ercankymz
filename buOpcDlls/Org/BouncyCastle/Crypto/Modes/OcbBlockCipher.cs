// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Modes.OcbBlockCipher
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Crypto.Modes;

public class OcbBlockCipher : IAeadBlockCipher, IAeadCipher
{
  private const int BLOCK_SIZE = 16 /*0x10*/;
  private readonly IBlockCipher hashCipher;
  private readonly IBlockCipher mainCipher;
  private bool forEncryption;
  private int macSize;
  private byte[] initialAssociatedText;
  private IList<byte[]> L;
  private byte[] L_Asterisk;
  private byte[] L_Dollar;
  private byte[] KtopInput;
  private byte[] Stretch = new byte[24];
  private byte[] OffsetMAIN_0 = new byte[16 /*0x10*/];
  private byte[] hashBlock;
  private byte[] mainBlock;
  private int hashBlockPos;
  private int mainBlockPos;
  private long hashBlockCount;
  private long mainBlockCount;
  private byte[] OffsetHASH;
  private byte[] Sum;
  private byte[] OffsetMAIN = new byte[16 /*0x10*/];
  private byte[] Checksum;
  private byte[] macBlock;

  public OcbBlockCipher(IBlockCipher hashCipher, IBlockCipher mainCipher)
  {
    if (hashCipher == null)
      throw new ArgumentNullException(nameof (hashCipher));
    if (hashCipher.GetBlockSize() != 16 /*0x10*/)
      throw new ArgumentException("must have a block size of " + 16 /*0x10*/.ToString(), nameof (hashCipher));
    if (mainCipher == null)
      throw new ArgumentNullException(nameof (mainCipher));
    if (mainCipher.GetBlockSize() != 16 /*0x10*/)
      throw new ArgumentException("must have a block size of " + 16 /*0x10*/.ToString(), nameof (mainCipher));
    if (!hashCipher.AlgorithmName.Equals(mainCipher.AlgorithmName))
      throw new ArgumentException("'hashCipher' and 'mainCipher' must be the same algorithm");
    this.hashCipher = hashCipher;
    this.mainCipher = mainCipher;
  }

  public virtual string AlgorithmName => this.mainCipher.AlgorithmName + "/OCB";

  public virtual IBlockCipher UnderlyingCipher => this.mainCipher;

  public virtual void Init(bool forEncryption, ICipherParameters parameters)
  {
    bool forEncryption1 = this.forEncryption;
    this.forEncryption = forEncryption;
    this.macBlock = (byte[]) null;
    byte[] N;
    KeyParameter parameters1;
    switch (parameters)
    {
      case AeadParameters aeadParameters:
        N = aeadParameters.GetNonce();
        this.initialAssociatedText = aeadParameters.GetAssociatedText();
        int macSize = aeadParameters.MacSize;
        if (macSize < 64 /*0x40*/ || macSize > 128 /*0x80*/ || macSize % 8 != 0)
          throw new ArgumentException("Invalid value for MAC size: " + macSize.ToString());
        this.macSize = macSize / 8;
        parameters1 = aeadParameters.Key;
        break;
      case ParametersWithIV parametersWithIv:
        N = parametersWithIv.GetIV();
        this.initialAssociatedText = (byte[]) null;
        this.macSize = 16 /*0x10*/;
        parameters1 = (KeyParameter) parametersWithIv.Parameters;
        break;
      default:
        throw new ArgumentException("invalid parameters passed to OCB");
    }
    this.hashBlock = new byte[16 /*0x10*/];
    this.mainBlock = new byte[forEncryption ? 16 /*0x10*/ : 16 /*0x10*/ + this.macSize];
    if (N.Length > 15)
      throw new ArgumentException("IV must be no more than 15 bytes");
    if (parameters1 != null)
    {
      this.hashCipher.Init(true, (ICipherParameters) parameters1);
      this.mainCipher.Init(forEncryption, (ICipherParameters) parameters1);
      this.KtopInput = (byte[]) null;
    }
    else if (forEncryption1 != forEncryption)
      throw new ArgumentException("cannot change encrypting state without providing key.");
    this.L_Asterisk = new byte[16 /*0x10*/];
    this.hashCipher.ProcessBlock(this.L_Asterisk, 0, this.L_Asterisk, 0);
    this.L_Dollar = OcbBlockCipher.OCB_double(this.L_Asterisk);
    this.L = (IList<byte[]>) new List<byte[]>();
    this.L.Add(OcbBlockCipher.OCB_double(this.L_Dollar));
    int num1 = this.ProcessNonce(N);
    int num2 = num1 % 8;
    int sourceIndex = num1 / 8;
    if (num2 == 0)
    {
      Array.Copy((Array) this.Stretch, sourceIndex, (Array) this.OffsetMAIN_0, 0, 16 /*0x10*/);
    }
    else
    {
      for (int index = 0; index < 16 /*0x10*/; ++index)
      {
        uint num3 = (uint) this.Stretch[sourceIndex];
        uint num4 = (uint) this.Stretch[++sourceIndex];
        this.OffsetMAIN_0[index] = (byte) (num3 << num2 | num4 >> 8 - num2);
      }
    }
    this.hashBlockPos = 0;
    this.mainBlockPos = 0;
    this.hashBlockCount = 0L;
    this.mainBlockCount = 0L;
    this.OffsetHASH = new byte[16 /*0x10*/];
    this.Sum = new byte[16 /*0x10*/];
    Array.Copy((Array) this.OffsetMAIN_0, 0, (Array) this.OffsetMAIN, 0, 16 /*0x10*/);
    this.Checksum = new byte[16 /*0x10*/];
    if (this.initialAssociatedText == null)
      return;
    this.ProcessAadBytes(this.initialAssociatedText, 0, this.initialAssociatedText.Length);
  }

  protected virtual int ProcessNonce(byte[] N)
  {
    byte[] numArray1 = new byte[16 /*0x10*/];
    Array.Copy((Array) N, 0, (Array) numArray1, numArray1.Length - N.Length, N.Length);
    numArray1[0] = (byte) (this.macSize << 4);
    numArray1[15 - N.Length] |= (byte) 1;
    int num = (int) numArray1[15] & 63 /*0x3F*/;
    numArray1[15] &= (byte) 192 /*0xC0*/;
    if (this.KtopInput == null || !Arrays.AreEqual(numArray1, this.KtopInput))
    {
      byte[] numArray2 = new byte[16 /*0x10*/];
      this.KtopInput = numArray1;
      this.hashCipher.ProcessBlock(this.KtopInput, 0, numArray2, 0);
      Array.Copy((Array) numArray2, 0, (Array) this.Stretch, 0, 16 /*0x10*/);
      for (int index = 0; index < 8; ++index)
        this.Stretch[16 /*0x10*/ + index] = (byte) ((uint) numArray2[index] ^ (uint) numArray2[index + 1]);
    }
    return num;
  }

  public virtual int GetBlockSize() => 16 /*0x10*/;

  public virtual byte[] GetMac()
  {
    return this.macBlock != null ? Arrays.Clone(this.macBlock) : new byte[this.macSize];
  }

  public virtual int GetOutputSize(int len)
  {
    int num = len + this.mainBlockPos;
    if (this.forEncryption)
      return num + this.macSize;
    return num >= this.macSize ? num - this.macSize : 0;
  }

  public virtual int GetUpdateOutputSize(int len)
  {
    int num = len + this.mainBlockPos;
    if (!this.forEncryption)
    {
      if (num < this.macSize)
        return 0;
      num -= this.macSize;
    }
    return num - num % 16 /*0x10*/;
  }

  public virtual void ProcessAadByte(byte input)
  {
    this.hashBlock[this.hashBlockPos] = input;
    if (++this.hashBlockPos != this.hashBlock.Length)
      return;
    this.ProcessHashBlock();
  }

  public virtual void ProcessAadBytes(byte[] input, int off, int len)
  {
    for (int index = 0; index < len; ++index)
    {
      this.hashBlock[this.hashBlockPos] = input[off + index];
      if (++this.hashBlockPos == this.hashBlock.Length)
        this.ProcessHashBlock();
    }
  }

  public virtual int ProcessByte(byte input, byte[] output, int outOff)
  {
    this.mainBlock[this.mainBlockPos] = input;
    if (++this.mainBlockPos != this.mainBlock.Length)
      return 0;
    this.ProcessMainBlock(output, outOff);
    return 16 /*0x10*/;
  }

  public virtual int ProcessBytes(byte[] input, int inOff, int len, byte[] output, int outOff)
  {
    int num = 0;
    for (int index = 0; index < len; ++index)
    {
      this.mainBlock[this.mainBlockPos] = input[inOff + index];
      if (++this.mainBlockPos == this.mainBlock.Length)
      {
        this.ProcessMainBlock(output, outOff + num);
        num += 16 /*0x10*/;
      }
    }
    return num;
  }

  public virtual int DoFinal(byte[] output, int outOff)
  {
    byte[] numArray1 = (byte[]) null;
    if (!this.forEncryption)
    {
      if (this.mainBlockPos < this.macSize)
        throw new InvalidCipherTextException("data too short");
      this.mainBlockPos -= this.macSize;
      numArray1 = new byte[this.macSize];
      Array.Copy((Array) this.mainBlock, this.mainBlockPos, (Array) numArray1, 0, this.macSize);
    }
    if (this.hashBlockPos > 0)
    {
      OcbBlockCipher.OCB_extend(this.hashBlock, this.hashBlockPos);
      this.UpdateHASH(this.L_Asterisk);
    }
    if (this.mainBlockPos > 0)
    {
      if (this.forEncryption)
      {
        OcbBlockCipher.OCB_extend(this.mainBlock, this.mainBlockPos);
        OcbBlockCipher.Xor(this.Checksum, this.mainBlock);
      }
      OcbBlockCipher.Xor(this.OffsetMAIN, this.L_Asterisk);
      byte[] numArray2 = new byte[16 /*0x10*/];
      this.hashCipher.ProcessBlock(this.OffsetMAIN, 0, numArray2, 0);
      OcbBlockCipher.Xor(this.mainBlock, numArray2);
      Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, this.mainBlockPos, "output buffer too short");
      Array.Copy((Array) this.mainBlock, 0, (Array) output, outOff, this.mainBlockPos);
      if (!this.forEncryption)
      {
        OcbBlockCipher.OCB_extend(this.mainBlock, this.mainBlockPos);
        OcbBlockCipher.Xor(this.Checksum, this.mainBlock);
      }
    }
    OcbBlockCipher.Xor(this.Checksum, this.OffsetMAIN);
    OcbBlockCipher.Xor(this.Checksum, this.L_Dollar);
    this.hashCipher.ProcessBlock(this.Checksum, 0, this.Checksum, 0);
    OcbBlockCipher.Xor(this.Checksum, this.Sum);
    this.macBlock = new byte[this.macSize];
    Array.Copy((Array) this.Checksum, 0, (Array) this.macBlock, 0, this.macSize);
    int mainBlockPos = this.mainBlockPos;
    if (this.forEncryption)
    {
      Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, mainBlockPos + this.macSize, "output buffer too short");
      Array.Copy((Array) this.macBlock, 0, (Array) output, outOff + mainBlockPos, this.macSize);
      mainBlockPos += this.macSize;
    }
    else if (!Arrays.FixedTimeEquals(this.macBlock, numArray1))
      throw new InvalidCipherTextException("mac check in OCB failed");
    this.Reset(false);
    return mainBlockPos;
  }

  public virtual void Reset() => this.Reset(true);

  protected virtual void Clear(byte[] bs)
  {
    if (bs == null)
      return;
    Array.Clear((Array) bs, 0, bs.Length);
  }

  protected virtual byte[] GetLSub(int n)
  {
    while (n >= this.L.Count)
      this.L.Add(OcbBlockCipher.OCB_double(this.L[this.L.Count - 1]));
    return this.L[n];
  }

  protected virtual void ProcessHashBlock()
  {
    this.UpdateHASH(this.GetLSub(OcbBlockCipher.OCB_ntz(++this.hashBlockCount)));
    this.hashBlockPos = 0;
  }

  protected virtual void ProcessMainBlock(byte[] output, int outOff)
  {
    Org.BouncyCastle.Crypto.Check.DataLength(output, outOff, 16 /*0x10*/, "Output buffer too short");
    if (this.forEncryption)
    {
      OcbBlockCipher.Xor(this.Checksum, this.mainBlock);
      this.mainBlockPos = 0;
    }
    OcbBlockCipher.Xor(this.OffsetMAIN, this.GetLSub(OcbBlockCipher.OCB_ntz(++this.mainBlockCount)));
    OcbBlockCipher.Xor(this.mainBlock, this.OffsetMAIN);
    this.mainCipher.ProcessBlock(this.mainBlock, 0, this.mainBlock, 0);
    OcbBlockCipher.Xor(this.mainBlock, this.OffsetMAIN);
    Array.Copy((Array) this.mainBlock, 0, (Array) output, outOff, 16 /*0x10*/);
    if (this.forEncryption)
      return;
    OcbBlockCipher.Xor(this.Checksum, this.mainBlock);
    Array.Copy((Array) this.mainBlock, 16 /*0x10*/, (Array) this.mainBlock, 0, this.macSize);
    this.mainBlockPos = this.macSize;
  }

  protected virtual void Reset(bool clearMac)
  {
    this.Clear(this.hashBlock);
    this.Clear(this.mainBlock);
    this.hashBlockPos = 0;
    this.mainBlockPos = 0;
    this.hashBlockCount = 0L;
    this.mainBlockCount = 0L;
    this.Clear(this.OffsetHASH);
    this.Clear(this.Sum);
    Array.Copy((Array) this.OffsetMAIN_0, 0, (Array) this.OffsetMAIN, 0, 16 /*0x10*/);
    this.Clear(this.Checksum);
    if (clearMac)
      this.macBlock = (byte[]) null;
    if (this.initialAssociatedText == null)
      return;
    this.ProcessAadBytes(this.initialAssociatedText, 0, this.initialAssociatedText.Length);
  }

  protected virtual void UpdateHASH(byte[] LSub)
  {
    OcbBlockCipher.Xor(this.OffsetHASH, LSub);
    OcbBlockCipher.Xor(this.hashBlock, this.OffsetHASH);
    this.hashCipher.ProcessBlock(this.hashBlock, 0, this.hashBlock, 0);
    OcbBlockCipher.Xor(this.Sum, this.hashBlock);
  }

  protected static byte[] OCB_double(byte[] block)
  {
    byte[] output = new byte[16 /*0x10*/];
    int num = OcbBlockCipher.ShiftLeft(block, output);
    output[15] ^= (byte) (135 >> (1 - num << 3));
    return output;
  }

  protected static void OCB_extend(byte[] block, int pos)
  {
    block[pos] = (byte) 128 /*0x80*/;
    while (++pos < 16 /*0x10*/)
      block[pos] = (byte) 0;
  }

  protected static int OCB_ntz(long x)
  {
    if (x == 0L)
      return 64 /*0x40*/;
    int num = 0;
    for (ulong index = (ulong) x; ((long) index & 1L) == 0L; index >>= 1)
      ++num;
    return num;
  }

  protected static int ShiftLeft(byte[] block, byte[] output)
  {
    int index = 16 /*0x10*/;
    uint num1 = 0;
    while (--index >= 0)
    {
      uint num2 = (uint) block[index];
      output[index] = (byte) (num2 << 1 | num1);
      num1 = num2 >> 7 & 1U;
    }
    return (int) num1;
  }

  protected static void Xor(byte[] block, byte[] val)
  {
    for (int index = 15; index >= 0; --index)
      block[index] ^= val[index];
  }
}
