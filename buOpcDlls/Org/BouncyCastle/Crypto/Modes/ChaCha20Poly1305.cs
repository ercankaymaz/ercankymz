// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Modes.ChaCha20Poly1305
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Modes;

public class ChaCha20Poly1305 : IAeadCipher
{
  private const int BufSize = 64 /*0x40*/;
  private const int KeySize = 32 /*0x20*/;
  private const int NonceSize = 12;
  private const int MacSize = 16 /*0x10*/;
  private static readonly byte[] Zeroes = new byte[15];
  private const ulong AadLimit = 18446744073709551615 /*0xFFFFFFFFFFFFFFFF*/;
  private const ulong DataLimit = 274877906880;
  private readonly ChaCha7539Engine mChacha20;
  private readonly IMac mPoly1305;
  private readonly byte[] mKey = new byte[32 /*0x20*/];
  private readonly byte[] mNonce = new byte[12];
  private readonly byte[] mBuf = new byte[80 /*0x50*/];
  private readonly byte[] mMac = new byte[16 /*0x10*/];
  private byte[] mInitialAad;
  private ulong mAadCount;
  private ulong mDataCount;
  private ChaCha20Poly1305.State mState;
  private int mBufPos;

  public ChaCha20Poly1305()
    : this((IMac) new Poly1305())
  {
  }

  public ChaCha20Poly1305(IMac poly1305)
  {
    if (poly1305 == null)
      throw new ArgumentNullException(nameof (poly1305));
    if (16 /*0x10*/ != poly1305.GetMacSize())
      throw new ArgumentException("must be a 128-bit MAC", nameof (poly1305));
    this.mChacha20 = new ChaCha7539Engine();
    this.mPoly1305 = poly1305;
  }

  public virtual string AlgorithmName => nameof (ChaCha20Poly1305);

  public virtual void Init(bool forEncryption, ICipherParameters parameters)
  {
    KeyParameter parameters1;
    byte[] numArray;
    ICipherParameters parameters2;
    switch (parameters)
    {
      case AeadParameters aeadParameters:
        int macSize = aeadParameters.MacSize;
        if (128 /*0x80*/ != macSize)
          throw new ArgumentException("Invalid value for MAC size: " + macSize.ToString());
        parameters1 = aeadParameters.Key;
        numArray = aeadParameters.GetNonce();
        parameters2 = (ICipherParameters) new ParametersWithIV((ICipherParameters) parameters1, numArray);
        this.mInitialAad = aeadParameters.GetAssociatedText();
        break;
      case ParametersWithIV parametersWithIv:
        parameters1 = (KeyParameter) parametersWithIv.Parameters;
        numArray = parametersWithIv.GetIV();
        parameters2 = (ICipherParameters) parametersWithIv;
        this.mInitialAad = (byte[]) null;
        break;
      default:
        throw new ArgumentException("invalid parameters passed to ChaCha20Poly1305", nameof (parameters));
    }
    if (parameters1 == null)
    {
      if (this.mState == ChaCha20Poly1305.State.Uninitialized)
        throw new ArgumentException("Key must be specified in initial init");
    }
    else if (32 /*0x20*/ != parameters1.KeyLength)
      throw new ArgumentException("Key must be 256 bits");
    if (12 != numArray.Length)
      throw new ArgumentException("Nonce must be 96 bits");
    if (this.mState != 0 & forEncryption && Arrays.AreEqual(this.mNonce, numArray) && (parameters1 == null || parameters1.FixedTimeEquals(this.mKey)))
      throw new ArgumentException("cannot reuse nonce for ChaCha20Poly1305 encryption");
    parameters1?.CopyTo(this.mKey, 0, 32 /*0x20*/);
    Array.Copy((Array) numArray, 0, (Array) this.mNonce, 0, 12);
    this.mChacha20.Init(true, parameters2);
    this.mState = forEncryption ? ChaCha20Poly1305.State.EncInit : ChaCha20Poly1305.State.DecInit;
    this.Reset(true, false);
  }

  public virtual int GetOutputSize(int len)
  {
    int num = Math.Max(0, len);
    switch (this.mState)
    {
      case ChaCha20Poly1305.State.EncData:
      case ChaCha20Poly1305.State.EncFinal:
        return num + this.mBufPos + 16 /*0x10*/;
      case ChaCha20Poly1305.State.DecInit:
      case ChaCha20Poly1305.State.DecAad:
        return Math.Max(0, num - 16 /*0x10*/);
      case ChaCha20Poly1305.State.DecData:
      case ChaCha20Poly1305.State.DecFinal:
        return Math.Max(0, num + this.mBufPos - 16 /*0x10*/);
      default:
        return num + 16 /*0x10*/;
    }
  }

  public virtual int GetUpdateOutputSize(int len)
  {
    int num = Math.Max(0, len);
    switch (this.mState)
    {
      case ChaCha20Poly1305.State.EncData:
      case ChaCha20Poly1305.State.EncFinal:
        num += this.mBufPos;
        break;
      case ChaCha20Poly1305.State.DecInit:
      case ChaCha20Poly1305.State.DecAad:
        num = Math.Max(0, num - 16 /*0x10*/);
        break;
      case ChaCha20Poly1305.State.DecData:
      case ChaCha20Poly1305.State.DecFinal:
        num = Math.Max(0, num + this.mBufPos - 16 /*0x10*/);
        break;
    }
    return num - num % 64 /*0x40*/;
  }

  public virtual void ProcessAadByte(byte input)
  {
    this.CheckAad();
    this.mAadCount = this.IncrementCount(this.mAadCount, 1U, ulong.MaxValue);
    this.mPoly1305.Update(input);
  }

  public virtual void ProcessAadBytes(byte[] inBytes, int inOff, int len)
  {
    if (inBytes == null)
      throw new ArgumentNullException(nameof (inBytes));
    if (inOff < 0)
      throw new ArgumentException("cannot be negative", nameof (inOff));
    if (len < 0)
      throw new ArgumentException("cannot be negative", nameof (len));
    Org.BouncyCastle.Crypto.Check.DataLength(inBytes, inOff, len, "input buffer too short");
    this.CheckAad();
    if (len <= 0)
      return;
    this.mAadCount = this.IncrementCount(this.mAadCount, (uint) len, ulong.MaxValue);
    this.mPoly1305.BlockUpdate(inBytes, inOff, len);
  }

  public virtual int ProcessByte(byte input, byte[] outBytes, int outOff)
  {
    this.CheckData();
    switch (this.mState)
    {
      case ChaCha20Poly1305.State.EncData:
        this.mBuf[this.mBufPos] = input;
        if (++this.mBufPos != 64 /*0x40*/)
          return 0;
        this.ProcessBlock(this.mBuf, 0, outBytes, outOff);
        this.mPoly1305.BlockUpdate(outBytes, outOff, 64 /*0x40*/);
        this.mBufPos = 0;
        return 64 /*0x40*/;
      case ChaCha20Poly1305.State.DecData:
        this.mBuf[this.mBufPos] = input;
        if (++this.mBufPos != this.mBuf.Length)
          return 0;
        this.mPoly1305.BlockUpdate(this.mBuf, 0, 64 /*0x40*/);
        this.ProcessBlock(this.mBuf, 0, outBytes, outOff);
        Array.Copy((Array) this.mBuf, 64 /*0x40*/, (Array) this.mBuf, 0, 16 /*0x10*/);
        this.mBufPos = 16 /*0x10*/;
        return 64 /*0x40*/;
      default:
        throw new InvalidOperationException();
    }
  }

  public virtual int ProcessBytes(
    byte[] inBytes,
    int inOff,
    int len,
    byte[] outBytes,
    int outOff)
  {
    if (inBytes == null)
      throw new ArgumentNullException(nameof (inBytes));
    if (inOff < 0)
      throw new ArgumentException("cannot be negative", nameof (inOff));
    if (len < 0)
      throw new ArgumentException("cannot be negative", nameof (len));
    Org.BouncyCastle.Crypto.Check.DataLength(inBytes, inOff, len, "input buffer too short");
    if (outOff < 0)
      throw new ArgumentException("cannot be negative", nameof (outOff));
    this.CheckData();
    int inLen = 0;
    switch (this.mState)
    {
      case ChaCha20Poly1305.State.EncData:
        int length1 = 64 /*0x40*/ - this.mBufPos;
        if (len < length1)
        {
          Array.Copy((Array) inBytes, inOff, (Array) this.mBuf, this.mBufPos, len);
          this.mBufPos += len;
          break;
        }
        int num1 = inOff + len - 64 /*0x40*/;
        int num2 = num1 - 64 /*0x40*/;
        if (this.mBufPos > 0)
        {
          Array.Copy((Array) inBytes, inOff, (Array) this.mBuf, this.mBufPos, length1);
          this.ProcessBlock(this.mBuf, 0, outBytes, outOff);
          inOff += length1;
          inLen = 64 /*0x40*/;
        }
        while (inOff <= num2)
        {
          this.ProcessBlocks2(inBytes, inOff, outBytes, outOff + inLen);
          inOff += 128 /*0x80*/;
          inLen += 128 /*0x80*/;
        }
        if (inOff <= num1)
        {
          this.ProcessBlock(inBytes, inOff, outBytes, outOff + inLen);
          inOff += 64 /*0x40*/;
          inLen += 64 /*0x40*/;
        }
        this.mPoly1305.BlockUpdate(outBytes, outOff, inLen);
        this.mBufPos = 64 /*0x40*/ + num1 - inOff;
        Array.Copy((Array) inBytes, inOff, (Array) this.mBuf, 0, this.mBufPos);
        break;
      case ChaCha20Poly1305.State.DecData:
        int num3 = this.mBuf.Length - this.mBufPos;
        if (len < num3)
        {
          Array.Copy((Array) inBytes, inOff, (Array) this.mBuf, this.mBufPos, len);
          this.mBufPos += len;
          break;
        }
        if (this.mBufPos >= 64 /*0x40*/)
        {
          this.mPoly1305.BlockUpdate(this.mBuf, 0, 64 /*0x40*/);
          this.ProcessBlock(this.mBuf, 0, outBytes, outOff);
          Array.Copy((Array) this.mBuf, 64 /*0x40*/, (Array) this.mBuf, 0, this.mBufPos -= 64 /*0x40*/);
          inLen = 64 /*0x40*/;
          int num4 = num3 + 64 /*0x40*/;
          if (len < num4)
          {
            Array.Copy((Array) inBytes, inOff, (Array) this.mBuf, this.mBufPos, len);
            this.mBufPos += len;
            break;
          }
        }
        int num5 = inOff + len - this.mBuf.Length;
        int num6 = num5 - 64 /*0x40*/;
        int length2 = 64 /*0x40*/ - this.mBufPos;
        Array.Copy((Array) inBytes, inOff, (Array) this.mBuf, this.mBufPos, length2);
        this.mPoly1305.BlockUpdate(this.mBuf, 0, 64 /*0x40*/);
        this.ProcessBlock(this.mBuf, 0, outBytes, outOff + inLen);
        inOff += length2;
        inLen += 64 /*0x40*/;
        while (inOff <= num6)
        {
          this.mPoly1305.BlockUpdate(inBytes, inOff, 128 /*0x80*/);
          this.ProcessBlocks2(inBytes, inOff, outBytes, outOff + inLen);
          inOff += 128 /*0x80*/;
          inLen += 128 /*0x80*/;
        }
        if (inOff <= num5)
        {
          this.mPoly1305.BlockUpdate(inBytes, inOff, 64 /*0x40*/);
          this.ProcessBlock(inBytes, inOff, outBytes, outOff + inLen);
          inOff += 64 /*0x40*/;
          inLen += 64 /*0x40*/;
        }
        this.mBufPos = this.mBuf.Length + num5 - inOff;
        Array.Copy((Array) inBytes, inOff, (Array) this.mBuf, 0, this.mBufPos);
        break;
      default:
        throw new InvalidOperationException();
    }
    return inLen;
  }

  public virtual int DoFinal(byte[] outBytes, int outOff)
  {
    if (outBytes == null)
      throw new ArgumentNullException(nameof (outBytes));
    if (outOff < 0)
      throw new ArgumentException("cannot be negative", nameof (outOff));
    this.CheckData();
    Array.Clear((Array) this.mMac, 0, 16 /*0x10*/);
    int num;
    switch (this.mState)
    {
      case ChaCha20Poly1305.State.EncData:
        num = this.mBufPos + 16 /*0x10*/;
        Org.BouncyCastle.Crypto.Check.OutputLength(outBytes, outOff, num, "output buffer too short");
        if (this.mBufPos > 0)
        {
          this.ProcessData(this.mBuf, 0, this.mBufPos, outBytes, outOff);
          this.mPoly1305.BlockUpdate(outBytes, outOff, this.mBufPos);
        }
        this.FinishData(ChaCha20Poly1305.State.EncFinal);
        Array.Copy((Array) this.mMac, 0, (Array) outBytes, outOff + this.mBufPos, 16 /*0x10*/);
        break;
      case ChaCha20Poly1305.State.DecData:
        if (this.mBufPos < 16 /*0x10*/)
          throw new InvalidCipherTextException("data too short");
        num = this.mBufPos - 16 /*0x10*/;
        Org.BouncyCastle.Crypto.Check.OutputLength(outBytes, outOff, num, "output buffer too short");
        if (num > 0)
        {
          this.mPoly1305.BlockUpdate(this.mBuf, 0, num);
          this.ProcessData(this.mBuf, 0, num, outBytes, outOff);
        }
        this.FinishData(ChaCha20Poly1305.State.DecFinal);
        if (!Arrays.FixedTimeEquals(16 /*0x10*/, this.mMac, 0, this.mBuf, num))
          throw new InvalidCipherTextException("mac check in ChaCha20Poly1305 failed");
        break;
      default:
        throw new InvalidOperationException();
    }
    this.Reset(false, true);
    return num;
  }

  public virtual byte[] GetMac() => Arrays.Clone(this.mMac);

  public virtual void Reset() => this.Reset(true, true);

  private void CheckAad()
  {
    switch (this.mState)
    {
      case ChaCha20Poly1305.State.EncInit:
        this.mState = ChaCha20Poly1305.State.EncAad;
        break;
      case ChaCha20Poly1305.State.EncAad:
        break;
      case ChaCha20Poly1305.State.EncFinal:
        throw new InvalidOperationException(this.AlgorithmName + " cannot be reused for encryption");
      case ChaCha20Poly1305.State.DecInit:
        this.mState = ChaCha20Poly1305.State.DecAad;
        break;
      case ChaCha20Poly1305.State.DecAad:
        break;
      default:
        throw new InvalidOperationException(this.AlgorithmName + " needs to be initialized");
    }
  }

  private void CheckData()
  {
    switch (this.mState)
    {
      case ChaCha20Poly1305.State.EncInit:
      case ChaCha20Poly1305.State.EncAad:
        this.FinishAad(ChaCha20Poly1305.State.EncData);
        break;
      case ChaCha20Poly1305.State.EncData:
        break;
      case ChaCha20Poly1305.State.EncFinal:
        throw new InvalidOperationException(this.AlgorithmName + " cannot be reused for encryption");
      case ChaCha20Poly1305.State.DecInit:
      case ChaCha20Poly1305.State.DecAad:
        this.FinishAad(ChaCha20Poly1305.State.DecData);
        break;
      case ChaCha20Poly1305.State.DecData:
        break;
      default:
        throw new InvalidOperationException(this.AlgorithmName + " needs to be initialized");
    }
  }

  private void FinishAad(ChaCha20Poly1305.State nextState)
  {
    this.PadMac(this.mAadCount);
    this.mState = nextState;
  }

  private void FinishData(ChaCha20Poly1305.State nextState)
  {
    this.PadMac(this.mDataCount);
    byte[] numArray = new byte[16 /*0x10*/];
    Pack.UInt64_To_LE(this.mAadCount, numArray, 0);
    Pack.UInt64_To_LE(this.mDataCount, numArray, 8);
    this.mPoly1305.BlockUpdate(numArray, 0, 16 /*0x10*/);
    this.mPoly1305.DoFinal(this.mMac, 0);
    this.mState = nextState;
  }

  private ulong IncrementCount(ulong count, uint increment, ulong limit)
  {
    if (count > limit - (ulong) increment)
      throw new InvalidOperationException("Limit exceeded");
    return count + (ulong) increment;
  }

  private void InitMac()
  {
    byte[] numArray = new byte[64 /*0x40*/];
    try
    {
      this.mChacha20.ProcessBytes(numArray, 0, 64 /*0x40*/, numArray, 0);
      this.mPoly1305.Init((ICipherParameters) new KeyParameter(numArray, 0, 32 /*0x20*/));
    }
    finally
    {
      Array.Clear((Array) numArray, 0, 64 /*0x40*/);
    }
  }

  private void PadMac(ulong count)
  {
    int num = (int) count & 15;
    if (num == 0)
      return;
    this.mPoly1305.BlockUpdate(ChaCha20Poly1305.Zeroes, 0, 16 /*0x10*/ - num);
  }

  private void ProcessBlock(byte[] inBytes, int inOff, byte[] outBytes, int outOff)
  {
    Org.BouncyCastle.Crypto.Check.OutputLength(outBytes, outOff, 64 /*0x40*/, "output buffer too short");
    this.mChacha20.ProcessBlock(inBytes, inOff, outBytes, outOff);
    this.mDataCount = this.IncrementCount(this.mDataCount, 64U /*0x40*/, 274877906880UL);
  }

  private void ProcessBlocks2(byte[] inBytes, int inOff, byte[] outBytes, int outOff)
  {
    Org.BouncyCastle.Crypto.Check.OutputLength(outBytes, outOff, 128 /*0x80*/, "output buffer too short");
    this.mChacha20.ProcessBlocks2(inBytes, inOff, outBytes, outOff);
    this.mDataCount = this.IncrementCount(this.mDataCount, 128U /*0x80*/, 274877906880UL);
  }

  private void ProcessData(byte[] inBytes, int inOff, int inLen, byte[] outBytes, int outOff)
  {
    Org.BouncyCastle.Crypto.Check.OutputLength(outBytes, outOff, inLen, "output buffer too short");
    this.mChacha20.ProcessBytes(inBytes, inOff, inLen, outBytes, outOff);
    this.mDataCount = this.IncrementCount(this.mDataCount, (uint) inLen, 274877906880UL);
  }

  private void Reset(bool clearMac, bool resetCipher)
  {
    Array.Clear((Array) this.mBuf, 0, this.mBuf.Length);
    if (clearMac)
      Array.Clear((Array) this.mMac, 0, this.mMac.Length);
    this.mAadCount = 0UL;
    this.mDataCount = 0UL;
    this.mBufPos = 0;
    switch (this.mState)
    {
      case ChaCha20Poly1305.State.EncInit:
      case ChaCha20Poly1305.State.DecInit:
        if (resetCipher)
          this.mChacha20.Reset();
        this.InitMac();
        if (this.mInitialAad == null)
          break;
        this.ProcessAadBytes(this.mInitialAad, 0, this.mInitialAad.Length);
        break;
      case ChaCha20Poly1305.State.EncAad:
      case ChaCha20Poly1305.State.EncData:
      case ChaCha20Poly1305.State.EncFinal:
        this.mState = ChaCha20Poly1305.State.EncFinal;
        break;
      case ChaCha20Poly1305.State.DecAad:
      case ChaCha20Poly1305.State.DecData:
      case ChaCha20Poly1305.State.DecFinal:
        this.mState = ChaCha20Poly1305.State.DecInit;
        goto case ChaCha20Poly1305.State.EncInit;
      default:
        throw new InvalidOperationException(this.AlgorithmName + " needs to be initialized");
    }
  }

  private enum State
  {
    Uninitialized,
    EncInit,
    EncAad,
    EncData,
    EncFinal,
    DecInit,
    DecAad,
    DecData,
    DecFinal,
  }
}
