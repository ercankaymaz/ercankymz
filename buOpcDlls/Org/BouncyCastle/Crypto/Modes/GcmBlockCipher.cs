// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Modes.GcmBlockCipher
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Modes.Gcm;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Modes;

public sealed class GcmBlockCipher : IAeadBlockCipher, IAeadCipher
{
  private const int BlockSize = 16 /*0x10*/;
  private readonly IBlockCipher cipher;
  private readonly IGcmMultiplier multiplier;
  private IGcmExponentiator exp;
  private bool forEncryption;
  private bool initialised;
  private int macSize;
  private byte[] lastKey;
  private byte[] nonce;
  private byte[] initialAssociatedText;
  private byte[] H;
  private byte[] J0;
  private byte[] bufBlock;
  private byte[] macBlock;
  private byte[] S;
  private byte[] S_at;
  private byte[] S_atPre;
  private byte[] counter;
  private uint counter32;
  private uint blocksRemaining;
  private int bufOff;
  private ulong totalLength;
  private byte[] atBlock;
  private int atBlockPos;
  private ulong atLength;
  private ulong atLengthPre;

  internal static IGcmMultiplier CreateGcmMultiplier()
  {
    return BasicGcmMultiplier.IsHardwareAccelerated ? (IGcmMultiplier) new BasicGcmMultiplier() : (IGcmMultiplier) new Tables4kGcmMultiplier();
  }

  public GcmBlockCipher(IBlockCipher c)
    : this(c, (IGcmMultiplier) null)
  {
  }

  [Obsolete("Will be removed")]
  public GcmBlockCipher(IBlockCipher c, IGcmMultiplier m)
  {
    if (c.GetBlockSize() != 16 /*0x10*/)
      throw new ArgumentException($"cipher required with a block size of {16 /*0x10*/.ToString()}.");
    if (m == null)
      m = GcmBlockCipher.CreateGcmMultiplier();
    this.cipher = c;
    this.multiplier = m;
  }

  public string AlgorithmName => this.cipher.AlgorithmName + "/GCM";

  public IBlockCipher UnderlyingCipher => this.cipher;

  public int GetBlockSize() => 16 /*0x10*/;

  public void Init(bool forEncryption, ICipherParameters parameters)
  {
    this.forEncryption = forEncryption;
    this.macBlock = (byte[]) null;
    this.initialised = true;
    byte[] b;
    KeyParameter parameters1;
    switch (parameters)
    {
      case AeadParameters aeadParameters:
        b = aeadParameters.GetNonce();
        this.initialAssociatedText = aeadParameters.GetAssociatedText();
        int macSize = aeadParameters.MacSize;
        if (macSize < 32 /*0x20*/ || macSize > 128 /*0x80*/ || macSize % 8 != 0)
          throw new ArgumentException("Invalid value for MAC size: " + macSize.ToString());
        this.macSize = macSize / 8;
        parameters1 = aeadParameters.Key;
        break;
      case ParametersWithIV parametersWithIv:
        b = parametersWithIv.GetIV();
        this.initialAssociatedText = (byte[]) null;
        this.macSize = 16 /*0x10*/;
        parameters1 = (KeyParameter) parametersWithIv.Parameters;
        break;
      default:
        throw new ArgumentException("invalid parameters passed to GCM");
    }
    this.bufBlock = new byte[forEncryption ? 16 /*0x10*/ : 16 /*0x10*/ + this.macSize];
    if (b.Length < 1)
      throw new ArgumentException("IV must be at least 1 byte");
    if (forEncryption && this.nonce != null && Arrays.AreEqual(this.nonce, b))
    {
      if (parameters1 == null)
        throw new ArgumentException("cannot reuse nonce for GCM encryption");
      if (this.lastKey != null && parameters1.FixedTimeEquals(this.lastKey))
        throw new ArgumentException("cannot reuse nonce for GCM encryption");
    }
    this.nonce = b;
    if (parameters1 != null)
      this.lastKey = parameters1.GetKey();
    if (parameters1 != null)
    {
      this.cipher.Init(true, (ICipherParameters) parameters1);
      this.H = new byte[16 /*0x10*/];
      this.cipher.ProcessBlock(this.H, 0, this.H, 0);
      this.multiplier.Init(this.H);
      this.exp = (IGcmExponentiator) null;
    }
    else if (this.H == null)
      throw new ArgumentException("Key must be specified in initial Init");
    this.J0 = new byte[16 /*0x10*/];
    if (this.nonce.Length == 12)
    {
      Array.Copy((Array) this.nonce, 0, (Array) this.J0, 0, this.nonce.Length);
      this.J0[15] = (byte) 1;
    }
    else
    {
      this.gHASH(this.J0, this.nonce, this.nonce.Length);
      byte[] numArray = new byte[16 /*0x10*/];
      Pack.UInt64_To_BE((ulong) this.nonce.Length * 8UL, numArray, 8);
      this.gHASHBlock(this.J0, numArray);
    }
    this.S = new byte[16 /*0x10*/];
    this.S_at = new byte[16 /*0x10*/];
    this.S_atPre = new byte[16 /*0x10*/];
    this.atBlock = new byte[16 /*0x10*/];
    this.atBlockPos = 0;
    this.atLength = 0UL;
    this.atLengthPre = 0UL;
    this.counter = Arrays.Clone(this.J0);
    this.counter32 = Pack.BE_To_UInt32(this.counter, 12);
    this.blocksRemaining = 4294967294U;
    this.bufOff = 0;
    this.totalLength = 0UL;
    if (this.initialAssociatedText == null)
      return;
    this.ProcessAadBytes(this.initialAssociatedText, 0, this.initialAssociatedText.Length);
  }

  public byte[] GetMac()
  {
    return this.macBlock != null ? (byte[]) this.macBlock.Clone() : new byte[this.macSize];
  }

  public int GetOutputSize(int len)
  {
    int num = len + this.bufOff;
    if (this.forEncryption)
      return num + this.macSize;
    return num >= this.macSize ? num - this.macSize : 0;
  }

  public int GetUpdateOutputSize(int len)
  {
    int num = len + this.bufOff;
    if (!this.forEncryption)
    {
      if (num < this.macSize)
        return 0;
      num -= this.macSize;
    }
    return num - num % 16 /*0x10*/;
  }

  public void ProcessAadByte(byte input)
  {
    this.CheckStatus();
    this.atBlock[this.atBlockPos] = input;
    if (++this.atBlockPos != 16 /*0x10*/)
      return;
    this.gHASHBlock(this.S_at, this.atBlock);
    this.atBlockPos = 0;
    this.atLength += 16UL /*0x10*/;
  }

  public void ProcessAadBytes(byte[] inBytes, int inOff, int len)
  {
    this.CheckStatus();
    if (this.atBlockPos > 0)
    {
      int length = 16 /*0x10*/ - this.atBlockPos;
      if (len < length)
      {
        Array.Copy((Array) inBytes, inOff, (Array) this.atBlock, this.atBlockPos, len);
        this.atBlockPos += len;
        return;
      }
      Array.Copy((Array) inBytes, inOff, (Array) this.atBlock, this.atBlockPos, length);
      this.gHASHBlock(this.S_at, this.atBlock);
      this.atLength += 16UL /*0x10*/;
      inOff += length;
      len -= length;
    }
    int num;
    for (num = inOff + len - 16 /*0x10*/; inOff <= num; inOff += 16 /*0x10*/)
    {
      this.gHASHBlock(this.S_at, inBytes, inOff);
      this.atLength += 16UL /*0x10*/;
    }
    this.atBlockPos = 16 /*0x10*/ + num - inOff;
    Array.Copy((Array) inBytes, inOff, (Array) this.atBlock, 0, this.atBlockPos);
  }

  private void InitCipher()
  {
    if (this.atLength > 0UL)
    {
      Array.Copy((Array) this.S_at, 0, (Array) this.S_atPre, 0, 16 /*0x10*/);
      this.atLengthPre = this.atLength;
    }
    if (this.atBlockPos > 0)
    {
      this.gHASHPartial(this.S_atPre, this.atBlock, 0, this.atBlockPos);
      this.atLengthPre += (ulong) (uint) this.atBlockPos;
    }
    if (this.atLengthPre <= 0UL)
      return;
    Array.Copy((Array) this.S_atPre, 0, (Array) this.S, 0, 16 /*0x10*/);
  }

  public int ProcessByte(byte input, byte[] output, int outOff)
  {
    this.CheckStatus();
    this.bufBlock[this.bufOff] = input;
    if (++this.bufOff != this.bufBlock.Length)
      return 0;
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, 16 /*0x10*/, "output buffer too short");
    if (this.blocksRemaining == 0U)
      throw new InvalidOperationException("Attempt to process too many blocks");
    --this.blocksRemaining;
    if (this.totalLength == 0UL)
      this.InitCipher();
    if (this.forEncryption)
    {
      this.EncryptBlock(this.bufBlock, 0, output, outOff);
      this.bufOff = 0;
    }
    else
    {
      this.DecryptBlock(this.bufBlock, 0, output, outOff);
      Array.Copy((Array) this.bufBlock, 16 /*0x10*/, (Array) this.bufBlock, 0, this.macSize);
      this.bufOff = this.macSize;
    }
    this.totalLength += 16UL /*0x10*/;
    return 16 /*0x10*/;
  }

  public int ProcessBytes(byte[] input, int inOff, int len, byte[] output, int outOff)
  {
    this.CheckStatus();
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, len, "input buffer too short");
    int num1 = this.bufOff + len;
    int len1;
    if (this.forEncryption)
    {
      len1 = num1 & -16;
      if (len1 > 0)
      {
        Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, len1, "output buffer too short");
        uint num2 = (uint) (len1 >>> 4);
        if (this.blocksRemaining < num2)
          throw new InvalidOperationException("Attempt to process too many blocks");
        this.blocksRemaining -= num2;
        if (this.totalLength == 0UL)
          this.InitCipher();
      }
      if (this.bufOff > 0)
      {
        int length = 16 /*0x10*/ - this.bufOff;
        if (len < length)
        {
          Array.Copy((Array) input, inOff, (Array) this.bufBlock, this.bufOff, len);
          this.bufOff += len;
          return 0;
        }
        Array.Copy((Array) input, inOff, (Array) this.bufBlock, this.bufOff, length);
        inOff += length;
        len -= length;
        this.EncryptBlock(this.bufBlock, 0, output, outOff);
        outOff += 16 /*0x10*/;
      }
      int num3 = inOff + len - 16 /*0x10*/;
      int num4 = num3 - 16 /*0x10*/;
      while (inOff <= num4)
      {
        this.EncryptBlocks2(input, inOff, output, outOff);
        inOff += 32 /*0x20*/;
        outOff += 32 /*0x20*/;
      }
      if (inOff <= num3)
      {
        this.EncryptBlock(input, inOff, output, outOff);
        inOff += 16 /*0x10*/;
      }
      this.bufOff = 16 /*0x10*/ + num3 - inOff;
      Array.Copy((Array) input, inOff, (Array) this.bufBlock, 0, this.bufOff);
    }
    else
    {
      len1 = num1 - this.macSize & -16;
      if (len1 > 0)
      {
        Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, len1, "output buffer too short");
        uint num5 = (uint) (len1 >>> 4);
        if (this.blocksRemaining < num5)
          throw new InvalidOperationException("Attempt to process too many blocks");
        this.blocksRemaining -= num5;
        if (this.totalLength == 0UL)
          this.InitCipher();
      }
      int num6 = this.bufBlock.Length - this.bufOff;
      if (len < num6)
      {
        Array.Copy((Array) input, inOff, (Array) this.bufBlock, this.bufOff, len);
        this.bufOff += len;
        return 0;
      }
      if (this.bufOff >= 16 /*0x10*/)
      {
        this.DecryptBlock(this.bufBlock, 0, output, outOff);
        outOff += 16 /*0x10*/;
        this.bufOff -= 16 /*0x10*/;
        Array.Copy((Array) this.bufBlock, 16 /*0x10*/, (Array) this.bufBlock, 0, this.bufOff);
        int num7 = num6 + 16 /*0x10*/;
        if (len < num7)
        {
          Array.Copy((Array) input, inOff, (Array) this.bufBlock, this.bufOff, len);
          this.bufOff += len;
          this.totalLength += 16UL /*0x10*/;
          return 16 /*0x10*/;
        }
      }
      int num8 = inOff + len - this.bufBlock.Length;
      int num9 = num8 - 16 /*0x10*/;
      int length = 16 /*0x10*/ - this.bufOff;
      Array.Copy((Array) input, inOff, (Array) this.bufBlock, this.bufOff, length);
      inOff += length;
      this.DecryptBlock(this.bufBlock, 0, output, outOff);
      outOff += 16 /*0x10*/;
      while (inOff <= num9)
      {
        this.DecryptBlocks2(input, inOff, output, outOff);
        inOff += 32 /*0x20*/;
        outOff += 32 /*0x20*/;
      }
      if (inOff <= num8)
      {
        this.DecryptBlock(input, inOff, output, outOff);
        inOff += 16 /*0x10*/;
      }
      this.bufOff = this.bufBlock.Length + num8 - inOff;
      Array.Copy((Array) input, inOff, (Array) this.bufBlock, 0, this.bufOff);
    }
    this.totalLength += (ulong) (uint) len1;
    return len1;
  }

  public int DoFinal(byte[] output, int outOff)
  {
    this.CheckStatus();
    int bufOff = this.bufOff;
    if (this.forEncryption)
    {
      Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, bufOff + this.macSize, "output buffer too short");
    }
    else
    {
      if (bufOff < this.macSize)
        throw new InvalidCipherTextException("data too short");
      bufOff -= this.macSize;
      Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, bufOff, "output buffer too short");
    }
    if (this.totalLength == 0UL)
      this.InitCipher();
    if (bufOff > 0)
    {
      if (this.blocksRemaining == 0U)
        throw new InvalidOperationException("Attempt to process too many blocks");
      --this.blocksRemaining;
      this.ProcessPartial(this.bufBlock, 0, bufOff, output, outOff);
    }
    this.atLength += (ulong) (uint) this.atBlockPos;
    if (this.atLength > this.atLengthPre)
    {
      if (this.atBlockPos > 0)
        this.gHASHPartial(this.S_at, this.atBlock, 0, this.atBlockPos);
      if (this.atLengthPre > 0UL)
        GcmUtilities.Xor(this.S_at, this.S_atPre);
      long pow = (long) this.totalLength * 8L + (long) sbyte.MaxValue >>> 7;
      byte[] numArray = new byte[16 /*0x10*/];
      if (this.exp == null)
      {
        this.exp = (IGcmExponentiator) new BasicGcmExponentiator();
        this.exp.Init(this.H);
      }
      this.exp.ExponentiateX(pow, numArray);
      GcmUtilities.Multiply(this.S_at, numArray);
      GcmUtilities.Xor(this.S, this.S_at);
    }
    byte[] numArray1 = new byte[16 /*0x10*/];
    Pack.UInt64_To_BE(this.atLength * 8UL, numArray1, 0);
    Pack.UInt64_To_BE(this.totalLength * 8UL, numArray1, 8);
    this.gHASHBlock(this.S, numArray1);
    byte[] numArray2 = new byte[16 /*0x10*/];
    this.cipher.ProcessBlock(this.J0, 0, numArray2, 0);
    GcmUtilities.Xor(numArray2, this.S);
    int num = bufOff;
    this.macBlock = new byte[this.macSize];
    Array.Copy((Array) numArray2, 0, (Array) this.macBlock, 0, this.macSize);
    if (this.forEncryption)
    {
      Array.Copy((Array) this.macBlock, 0, (Array) output, outOff + this.bufOff, this.macSize);
      num += this.macSize;
    }
    else
    {
      byte[] numArray3 = new byte[this.macSize];
      Array.Copy((Array) this.bufBlock, bufOff, (Array) numArray3, 0, this.macSize);
      if (!Arrays.FixedTimeEquals(this.macBlock, numArray3))
        throw new InvalidCipherTextException("mac check in GCM failed");
    }
    this.Reset(false);
    return num;
  }

  public void Reset() => this.Reset(true);

  private void Reset(bool clearMac)
  {
    this.S = new byte[16 /*0x10*/];
    this.S_at = new byte[16 /*0x10*/];
    this.S_atPre = new byte[16 /*0x10*/];
    this.atBlock = new byte[16 /*0x10*/];
    this.atBlockPos = 0;
    this.atLength = 0UL;
    this.atLengthPre = 0UL;
    this.counter = Arrays.Clone(this.J0);
    this.counter32 = Pack.BE_To_UInt32(this.counter, 12);
    this.blocksRemaining = 4294967294U;
    this.bufOff = 0;
    this.totalLength = 0UL;
    if (this.bufBlock != null)
      Arrays.Fill(this.bufBlock, (byte) 0);
    if (clearMac)
      this.macBlock = (byte[]) null;
    if (this.forEncryption)
    {
      this.initialised = false;
    }
    else
    {
      if (this.initialAssociatedText == null)
        return;
      this.ProcessAadBytes(this.initialAssociatedText, 0, this.initialAssociatedText.Length);
    }
  }

  private void DecryptBlock(byte[] inBuf, int inOff, byte[] outBuf, int outOff)
  {
    byte[] block = new byte[16 /*0x10*/];
    this.GetNextCtrBlock(block);
    for (int index = 0; index < 16 /*0x10*/; index += 4)
    {
      byte num1 = inBuf[inOff + index];
      byte num2 = inBuf[inOff + index + 1];
      byte num3 = inBuf[inOff + index + 2];
      byte num4 = inBuf[inOff + index + 3];
      this.S[index] ^= num1;
      this.S[index + 1] ^= num2;
      this.S[index + 2] ^= num3;
      this.S[index + 3] ^= num4;
      outBuf[outOff + index] = (byte) ((uint) num1 ^ (uint) block[index]);
      outBuf[outOff + index + 1] = (byte) ((uint) num2 ^ (uint) block[index + 1]);
      outBuf[outOff + index + 2] = (byte) ((uint) num3 ^ (uint) block[index + 2]);
      outBuf[outOff + index + 3] = (byte) ((uint) num4 ^ (uint) block[index + 3]);
    }
    this.multiplier.MultiplyH(this.S);
  }

  private void DecryptBlocks2(byte[] inBuf, int inOff, byte[] outBuf, int outOff)
  {
    byte[] block = new byte[16 /*0x10*/];
    this.GetNextCtrBlock(block);
    for (int index = 0; index < 16 /*0x10*/; index += 4)
    {
      byte num1 = inBuf[inOff + index];
      byte num2 = inBuf[inOff + index + 1];
      byte num3 = inBuf[inOff + index + 2];
      byte num4 = inBuf[inOff + index + 3];
      this.S[index] ^= num1;
      this.S[index + 1] ^= num2;
      this.S[index + 2] ^= num3;
      this.S[index + 3] ^= num4;
      outBuf[outOff + index] = (byte) ((uint) num1 ^ (uint) block[index]);
      outBuf[outOff + index + 1] = (byte) ((uint) num2 ^ (uint) block[index + 1]);
      outBuf[outOff + index + 2] = (byte) ((uint) num3 ^ (uint) block[index + 2]);
      outBuf[outOff + index + 3] = (byte) ((uint) num4 ^ (uint) block[index + 3]);
    }
    this.multiplier.MultiplyH(this.S);
    inOff += 16 /*0x10*/;
    outOff += 16 /*0x10*/;
    this.GetNextCtrBlock(block);
    for (int index = 0; index < 16 /*0x10*/; index += 4)
    {
      byte num5 = inBuf[inOff + index];
      byte num6 = inBuf[inOff + index + 1];
      byte num7 = inBuf[inOff + index + 2];
      byte num8 = inBuf[inOff + index + 3];
      this.S[index] ^= num5;
      this.S[index + 1] ^= num6;
      this.S[index + 2] ^= num7;
      this.S[index + 3] ^= num8;
      outBuf[outOff + index] = (byte) ((uint) num5 ^ (uint) block[index]);
      outBuf[outOff + index + 1] = (byte) ((uint) num6 ^ (uint) block[index + 1]);
      outBuf[outOff + index + 2] = (byte) ((uint) num7 ^ (uint) block[index + 2]);
      outBuf[outOff + index + 3] = (byte) ((uint) num8 ^ (uint) block[index + 3]);
    }
    this.multiplier.MultiplyH(this.S);
  }

  private void EncryptBlock(byte[] inBuf, int inOff, byte[] outBuf, int outOff)
  {
    byte[] block = new byte[16 /*0x10*/];
    this.GetNextCtrBlock(block);
    for (int index = 0; index < 16 /*0x10*/; index += 4)
    {
      byte num1 = (byte) ((uint) block[index] ^ (uint) inBuf[inOff + index]);
      byte num2 = (byte) ((uint) block[index + 1] ^ (uint) inBuf[inOff + index + 1]);
      byte num3 = (byte) ((uint) block[index + 2] ^ (uint) inBuf[inOff + index + 2]);
      byte num4 = (byte) ((uint) block[index + 3] ^ (uint) inBuf[inOff + index + 3]);
      this.S[index] ^= num1;
      this.S[index + 1] ^= num2;
      this.S[index + 2] ^= num3;
      this.S[index + 3] ^= num4;
      outBuf[outOff + index] = num1;
      outBuf[outOff + index + 1] = num2;
      outBuf[outOff + index + 2] = num3;
      outBuf[outOff + index + 3] = num4;
    }
    this.multiplier.MultiplyH(this.S);
  }

  private void EncryptBlocks2(byte[] inBuf, int inOff, byte[] outBuf, int outOff)
  {
    byte[] block = new byte[16 /*0x10*/];
    this.GetNextCtrBlock(block);
    for (int index = 0; index < 16 /*0x10*/; index += 4)
    {
      byte num1 = (byte) ((uint) block[index] ^ (uint) inBuf[inOff + index]);
      byte num2 = (byte) ((uint) block[index + 1] ^ (uint) inBuf[inOff + index + 1]);
      byte num3 = (byte) ((uint) block[index + 2] ^ (uint) inBuf[inOff + index + 2]);
      byte num4 = (byte) ((uint) block[index + 3] ^ (uint) inBuf[inOff + index + 3]);
      this.S[index] ^= num1;
      this.S[index + 1] ^= num2;
      this.S[index + 2] ^= num3;
      this.S[index + 3] ^= num4;
      outBuf[outOff + index] = num1;
      outBuf[outOff + index + 1] = num2;
      outBuf[outOff + index + 2] = num3;
      outBuf[outOff + index + 3] = num4;
    }
    this.multiplier.MultiplyH(this.S);
    inOff += 16 /*0x10*/;
    outOff += 16 /*0x10*/;
    this.GetNextCtrBlock(block);
    for (int index = 0; index < 16 /*0x10*/; index += 4)
    {
      byte num5 = (byte) ((uint) block[index] ^ (uint) inBuf[inOff + index]);
      byte num6 = (byte) ((uint) block[index + 1] ^ (uint) inBuf[inOff + index + 1]);
      byte num7 = (byte) ((uint) block[index + 2] ^ (uint) inBuf[inOff + index + 2]);
      byte num8 = (byte) ((uint) block[index + 3] ^ (uint) inBuf[inOff + index + 3]);
      this.S[index] ^= num5;
      this.S[index + 1] ^= num6;
      this.S[index + 2] ^= num7;
      this.S[index + 3] ^= num8;
      outBuf[outOff + index] = num5;
      outBuf[outOff + index + 1] = num6;
      outBuf[outOff + index + 2] = num7;
      outBuf[outOff + index + 3] = num8;
    }
    this.multiplier.MultiplyH(this.S);
  }

  private void GetNextCtrBlock(byte[] block)
  {
    Pack.UInt32_To_BE(++this.counter32, this.counter, 12);
    this.cipher.ProcessBlock(this.counter, 0, block, 0);
  }

  private void ProcessPartial(byte[] buf, int off, int len, byte[] output, int outOff)
  {
    byte[] numArray = new byte[16 /*0x10*/];
    this.GetNextCtrBlock(numArray);
    if (this.forEncryption)
    {
      GcmUtilities.Xor(buf, off, numArray, 0, len);
      this.gHASHPartial(this.S, buf, off, len);
    }
    else
    {
      this.gHASHPartial(this.S, buf, off, len);
      GcmUtilities.Xor(buf, off, numArray, 0, len);
    }
    Array.Copy((Array) buf, off, (Array) output, outOff, len);
    this.totalLength += (ulong) (uint) len;
  }

  private void gHASH(byte[] Y, byte[] b, int len)
  {
    for (int off = 0; off < len; off += 16 /*0x10*/)
    {
      int len1 = Math.Min(len - off, 16 /*0x10*/);
      this.gHASHPartial(Y, b, off, len1);
    }
  }

  private void gHASHBlock(byte[] Y, byte[] b)
  {
    GcmUtilities.Xor(Y, b);
    this.multiplier.MultiplyH(Y);
  }

  private void gHASHBlock(byte[] Y, byte[] b, int off)
  {
    GcmUtilities.Xor(Y, b, off);
    this.multiplier.MultiplyH(Y);
  }

  private void gHASHPartial(byte[] Y, byte[] b, int off, int len)
  {
    GcmUtilities.Xor(Y, b, off, len);
    this.multiplier.MultiplyH(Y);
  }

  private void CheckStatus()
  {
    if (this.initialised)
      return;
    if (this.forEncryption)
      throw new InvalidOperationException("GCM cipher cannot be reused for encryption");
    throw new InvalidOperationException("GCM cipher needs to be initialized");
  }
}
