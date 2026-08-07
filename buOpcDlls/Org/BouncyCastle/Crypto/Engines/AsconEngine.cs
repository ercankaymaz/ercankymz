// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.AsconEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public sealed class AsconEngine : IAeadCipher
{
  private readonly AsconEngine.AsconParameters asconParameters;
  private readonly int CRYPTO_KEYBYTES;
  private readonly int CRYPTO_ABYTES;
  private readonly int ASCON_AEAD_RATE;
  private readonly int nr;
  private byte[] mac;
  private ulong K0;
  private ulong K1;
  private ulong K2;
  private ulong N0;
  private ulong N1;
  private readonly ulong ASCON_IV;
  private ulong x0;
  private ulong x1;
  private ulong x2;
  private ulong x3;
  private ulong x4;
  private string algorithmName;
  private AsconEngine.State m_state;
  private byte[] initialAssociatedText;
  private readonly int m_bufferSizeDecrypt;
  private readonly byte[] m_buf;
  private int m_bufPos;

  public AsconEngine(AsconEngine.AsconParameters asconParameters)
  {
    this.asconParameters = asconParameters;
    switch (asconParameters)
    {
      case AsconEngine.AsconParameters.ascon80pq:
        this.CRYPTO_KEYBYTES = 20;
        this.CRYPTO_ABYTES = 16 /*0x10*/;
        this.ASCON_AEAD_RATE = 8;
        this.ASCON_IV = 11547242664487288832UL /*0xA0400C0600000000*/;
        this.algorithmName = "Ascon-80pq AEAD";
        break;
      case AsconEngine.AsconParameters.ascon128a:
        this.CRYPTO_KEYBYTES = 16 /*0x10*/;
        this.CRYPTO_ABYTES = 16 /*0x10*/;
        this.ASCON_AEAD_RATE = 16 /*0x10*/;
        this.ASCON_IV = 9259414062373011456UL /*0x80800C0800000000*/;
        this.algorithmName = "Ascon-128a AEAD";
        break;
      case AsconEngine.AsconParameters.ascon128:
        this.CRYPTO_KEYBYTES = 16 /*0x10*/;
        this.CRYPTO_ABYTES = 16 /*0x10*/;
        this.ASCON_AEAD_RATE = 8;
        this.ASCON_IV = 9241399655273594880UL /*0x80400C0600000000*/;
        this.algorithmName = "Ascon-128 AEAD";
        break;
      default:
        throw new ArgumentException("invalid parameter setting for ASCON AEAD");
    }
    this.nr = this.ASCON_AEAD_RATE == 8 ? 6 : 8;
    this.m_bufferSizeDecrypt = this.ASCON_AEAD_RATE + this.CRYPTO_ABYTES;
    this.m_buf = new byte[this.m_bufferSizeDecrypt];
  }

  public int GetKeyBytesSize() => this.CRYPTO_KEYBYTES;

  public int GetIVBytesSize() => this.CRYPTO_ABYTES;

  public string AlgorithmName => this.algorithmName;

  public void Init(bool forEncryption, ICipherParameters parameters)
  {
    KeyParameter keyParameter;
    byte[] bs;
    switch (parameters)
    {
      case AeadParameters aeadParameters:
        keyParameter = aeadParameters.Key;
        bs = aeadParameters.GetNonce();
        this.initialAssociatedText = aeadParameters.GetAssociatedText();
        int macSize = aeadParameters.MacSize;
        if (macSize != this.CRYPTO_ABYTES * 8)
          throw new ArgumentException("Invalid value for MAC size: " + macSize.ToString());
        break;
      case ParametersWithIV parametersWithIv:
        keyParameter = parametersWithIv.Parameters as KeyParameter;
        bs = parametersWithIv.GetIV();
        this.initialAssociatedText = (byte[]) null;
        break;
      default:
        throw new ArgumentException("invalid parameters passed to Ascon");
    }
    if (keyParameter == null)
      throw new ArgumentException("Ascon Init parameters must include a key");
    if (bs.Length != this.CRYPTO_ABYTES)
      throw new ArgumentException($"{this.asconParameters.ToString()} requires exactly {this.CRYPTO_ABYTES.ToString()} bytes of IV");
    byte[] key = keyParameter.GetKey();
    if (key.Length != this.CRYPTO_KEYBYTES)
      throw new ArgumentException($"{this.asconParameters.ToString()} key must be {this.CRYPTO_KEYBYTES.ToString()} bytes long");
    this.N0 = Pack.BE_To_UInt64(bs, 0);
    this.N1 = Pack.BE_To_UInt64(bs, 8);
    if (this.CRYPTO_KEYBYTES == 16 /*0x10*/)
    {
      this.K1 = Pack.BE_To_UInt64(key, 0);
      this.K2 = Pack.BE_To_UInt64(key, 8);
    }
    else
    {
      if (this.CRYPTO_KEYBYTES != 20)
        throw new InvalidOperationException();
      this.K0 = (ulong) Pack.BE_To_UInt32(key, 0);
      this.K1 = Pack.BE_To_UInt64(key, 4);
      this.K2 = Pack.BE_To_UInt64(key, 12);
    }
    this.m_state = forEncryption ? AsconEngine.State.EncInit : AsconEngine.State.DecInit;
    this.Reset(true);
  }

  public void ProcessAadByte(byte input)
  {
    this.CheckAad();
    this.m_buf[this.m_bufPos] = input;
    if (++this.m_bufPos != this.ASCON_AEAD_RATE)
      return;
    this.ProcessBufferAad(this.m_buf, 0);
    this.m_bufPos = 0;
  }

  public void ProcessAadBytes(byte[] inBytes, int inOff, int len)
  {
    Org.BouncyCastle.Crypto.Check.DataLength(inBytes, inOff, len, "input buffer too short");
    if (len <= 0)
      return;
    this.CheckAad();
    if (this.m_bufPos > 0)
    {
      int length = this.ASCON_AEAD_RATE - this.m_bufPos;
      if (len < length)
      {
        Array.Copy((Array) inBytes, inOff, (Array) this.m_buf, this.m_bufPos, len);
        this.m_bufPos += len;
        return;
      }
      Array.Copy((Array) inBytes, inOff, (Array) this.m_buf, this.m_bufPos, length);
      inOff += length;
      len -= length;
      this.ProcessBufferAad(this.m_buf, 0);
    }
    for (; len >= this.ASCON_AEAD_RATE; len -= this.ASCON_AEAD_RATE)
    {
      this.ProcessBufferAad(inBytes, inOff);
      inOff += this.ASCON_AEAD_RATE;
    }
    Array.Copy((Array) inBytes, inOff, (Array) this.m_buf, 0, len);
    this.m_bufPos = len;
  }

  public int ProcessByte(byte input, byte[] outBytes, int outOff)
  {
    return this.ProcessBytes(new byte[1]{ input }, 0, 1, outBytes, outOff);
  }

  public int ProcessBytes(byte[] inBytes, int inOff, int len, byte[] outBytes, int outOff)
  {
    Org.BouncyCastle.Crypto.Check.DataLength(inBytes, inOff, len, "input buffer too short");
    int num1 = this.CheckData() ? 1 : 0;
    int num2 = 0;
    if (num1 != 0)
    {
      if (this.m_bufPos > 0)
      {
        int length = this.ASCON_AEAD_RATE - this.m_bufPos;
        if (len < length)
        {
          Array.Copy((Array) inBytes, inOff, (Array) this.m_buf, this.m_bufPos, len);
          this.m_bufPos += len;
          return 0;
        }
        Array.Copy((Array) inBytes, inOff, (Array) this.m_buf, this.m_bufPos, length);
        inOff += length;
        len -= length;
        this.ProcessBufferEncrypt(this.m_buf, 0, outBytes, outOff);
        num2 = this.ASCON_AEAD_RATE;
      }
      while (len >= this.ASCON_AEAD_RATE)
      {
        this.ProcessBufferEncrypt(inBytes, inOff, outBytes, outOff + num2);
        inOff += this.ASCON_AEAD_RATE;
        len -= this.ASCON_AEAD_RATE;
        num2 += this.ASCON_AEAD_RATE;
      }
    }
    else
    {
      int num3 = this.m_bufferSizeDecrypt - this.m_bufPos;
      if (len < num3)
      {
        Array.Copy((Array) inBytes, inOff, (Array) this.m_buf, this.m_bufPos, len);
        this.m_bufPos += len;
        return 0;
      }
      if (this.m_bufPos >= this.ASCON_AEAD_RATE)
      {
        this.ProcessBufferDecrypt(this.m_buf, 0, outBytes, outOff);
        this.m_bufPos -= this.ASCON_AEAD_RATE;
        Array.Copy((Array) this.m_buf, this.ASCON_AEAD_RATE, (Array) this.m_buf, 0, this.m_bufPos);
        num2 = this.ASCON_AEAD_RATE;
        int num4 = num3 + this.ASCON_AEAD_RATE;
        if (len < num4)
        {
          Array.Copy((Array) inBytes, inOff, (Array) this.m_buf, this.m_bufPos, len);
          this.m_bufPos += len;
          return num2;
        }
      }
      int length = this.ASCON_AEAD_RATE - this.m_bufPos;
      Array.Copy((Array) inBytes, inOff, (Array) this.m_buf, this.m_bufPos, length);
      inOff += length;
      len -= length;
      this.ProcessBufferDecrypt(this.m_buf, 0, outBytes, outOff + num2);
      num2 += this.ASCON_AEAD_RATE;
      while (len >= this.m_bufferSizeDecrypt)
      {
        this.ProcessBufferDecrypt(inBytes, inOff, outBytes, outOff + num2);
        inOff += this.ASCON_AEAD_RATE;
        len -= this.ASCON_AEAD_RATE;
        num2 += this.ASCON_AEAD_RATE;
      }
    }
    Array.Copy((Array) inBytes, inOff, (Array) this.m_buf, 0, len);
    this.m_bufPos = len;
    return num2;
  }

  public int DoFinal(byte[] outBytes, int outOff)
  {
    int len;
    if (this.CheckData())
    {
      len = this.m_bufPos + this.CRYPTO_ABYTES;
      Org.BouncyCastle.Crypto.Check.OutputLength(outBytes, outOff, len, "output buffer too short");
      this.ProcessFinalEncrypt(this.m_buf, 0, this.m_bufPos, outBytes, outOff);
      this.mac = new byte[this.CRYPTO_ABYTES];
      Pack.UInt64_To_BE(this.x3, this.mac, 0);
      Pack.UInt64_To_BE(this.x4, this.mac, 8);
      Array.Copy((Array) this.mac, 0, (Array) outBytes, outOff + this.m_bufPos, this.CRYPTO_ABYTES);
      this.Reset(false);
    }
    else
    {
      if (this.m_bufPos < this.CRYPTO_ABYTES)
        throw new InvalidCipherTextException("data too short");
      this.m_bufPos -= this.CRYPTO_ABYTES;
      len = this.m_bufPos;
      Org.BouncyCastle.Crypto.Check.OutputLength(outBytes, outOff, len, "output buffer too short");
      this.ProcessFinalDecrypt(this.m_buf, 0, this.m_bufPos, outBytes, outOff);
      this.x3 ^= Pack.BE_To_UInt64(this.m_buf, this.m_bufPos);
      this.x4 ^= Pack.BE_To_UInt64(this.m_buf, this.m_bufPos + 8);
      if (((long) this.x3 | (long) this.x4) != 0L)
        throw new InvalidCipherTextException($"mac check in {this.AlgorithmName} failed");
      this.Reset(true);
    }
    return len;
  }

  public byte[] GetMac() => this.mac;

  public int GetUpdateOutputSize(int len)
  {
    int num = Math.Max(0, len);
    switch (this.m_state)
    {
      case AsconEngine.State.EncData:
      case AsconEngine.State.EncFinal:
        num += this.m_bufPos;
        break;
      case AsconEngine.State.DecInit:
      case AsconEngine.State.DecAad:
        num = Math.Max(0, num - this.CRYPTO_ABYTES);
        break;
      case AsconEngine.State.DecData:
      case AsconEngine.State.DecFinal:
        num = Math.Max(0, num + this.m_bufPos - this.CRYPTO_ABYTES);
        break;
    }
    return num - num % this.ASCON_AEAD_RATE;
  }

  public int GetOutputSize(int len)
  {
    int num = Math.Max(0, len);
    switch (this.m_state)
    {
      case AsconEngine.State.EncData:
      case AsconEngine.State.EncFinal:
        return num + this.m_bufPos + this.CRYPTO_ABYTES;
      case AsconEngine.State.DecInit:
      case AsconEngine.State.DecAad:
        return Math.Max(0, num - this.CRYPTO_ABYTES);
      case AsconEngine.State.DecData:
      case AsconEngine.State.DecFinal:
        return Math.Max(0, num + this.m_bufPos - this.CRYPTO_ABYTES);
      default:
        return num + this.CRYPTO_ABYTES;
    }
  }

  public void Reset() => this.Reset(true);

  private void CheckAad()
  {
    switch (this.m_state)
    {
      case AsconEngine.State.EncInit:
        this.m_state = AsconEngine.State.EncAad;
        break;
      case AsconEngine.State.EncAad:
        break;
      case AsconEngine.State.EncFinal:
        throw new InvalidOperationException(this.AlgorithmName + " cannot be reused for encryption");
      case AsconEngine.State.DecInit:
        this.m_state = AsconEngine.State.DecAad;
        break;
      case AsconEngine.State.DecAad:
        break;
      default:
        throw new InvalidOperationException(this.AlgorithmName + " needs to be initialized");
    }
  }

  private bool CheckData()
  {
    switch (this.m_state)
    {
      case AsconEngine.State.EncInit:
      case AsconEngine.State.EncAad:
        this.FinishAad(AsconEngine.State.EncData);
        return true;
      case AsconEngine.State.EncData:
        return true;
      case AsconEngine.State.EncFinal:
        throw new InvalidOperationException(this.AlgorithmName + " cannot be reused for encryption");
      case AsconEngine.State.DecInit:
      case AsconEngine.State.DecAad:
        this.FinishAad(AsconEngine.State.DecData);
        return false;
      case AsconEngine.State.DecData:
        return false;
      default:
        throw new InvalidOperationException(this.AlgorithmName + " needs to be initialized");
    }
  }

  private void FinishAad(AsconEngine.State nextState)
  {
    switch (this.m_state)
    {
      case AsconEngine.State.EncAad:
      case AsconEngine.State.DecAad:
        this.m_buf[this.m_bufPos] = (byte) 128 /*0x80*/;
        if (this.m_bufPos >= 8)
        {
          this.x0 ^= Pack.BE_To_UInt64(this.m_buf, 0);
          this.x1 ^= Pack.BE_To_UInt64(this.m_buf, 8) & (ulong) (-1L << 56 - (this.m_bufPos - 8 << 3));
        }
        else
          this.x0 ^= Pack.BE_To_UInt64(this.m_buf, 0) & (ulong) (-1L << 56 - (this.m_bufPos << 3));
        this.P(this.nr);
        break;
    }
    this.x4 ^= 1UL;
    this.m_bufPos = 0;
    this.m_state = nextState;
  }

  private void FinishData(AsconEngine.State nextState)
  {
    switch (this.asconParameters)
    {
      case AsconEngine.AsconParameters.ascon80pq:
        this.x1 ^= this.K0 << 32 /*0x20*/ | this.K1 >> 32 /*0x20*/;
        this.x2 ^= this.K1 << 32 /*0x20*/ | this.K2 >> 32 /*0x20*/;
        this.x3 ^= this.K2 << 32 /*0x20*/;
        break;
      case AsconEngine.AsconParameters.ascon128a:
        this.x2 ^= this.K1;
        this.x3 ^= this.K2;
        break;
      case AsconEngine.AsconParameters.ascon128:
        this.x1 ^= this.K1;
        this.x2 ^= this.K2;
        break;
      default:
        throw new InvalidOperationException();
    }
    this.P(12);
    this.x3 ^= this.K1;
    this.x4 ^= this.K2;
    this.m_state = nextState;
  }

  private void P(int nr)
  {
    if (nr >= 8)
    {
      if (nr == 12)
      {
        this.ROUND(240UL /*0xF0*/);
        this.ROUND(225UL);
        this.ROUND(210UL);
        this.ROUND(195UL);
      }
      this.ROUND(180UL);
      this.ROUND(165UL);
    }
    this.ROUND(150UL);
    this.ROUND(135UL);
    this.ROUND(120UL);
    this.ROUND(105UL);
    this.ROUND(90UL);
    this.ROUND(75UL);
  }

  private void ROUND(ulong c)
  {
    ulong i1 = (ulong) ((long) this.x0 ^ (long) this.x1 ^ (long) this.x2 ^ (long) this.x3 ^ (long) c ^ (long) this.x1 & ((long) this.x0 ^ (long) this.x2 ^ (long) this.x4 ^ (long) c));
    ulong i2 = (ulong) ((long) this.x0 ^ (long) this.x2 ^ (long) this.x3 ^ (long) this.x4 ^ (long) c ^ ((long) this.x1 ^ (long) this.x2 ^ (long) c) & ((long) this.x1 ^ (long) this.x3));
    ulong i3 = (ulong) ((long) this.x1 ^ (long) this.x2 ^ (long) this.x4 ^ (long) c ^ (long) this.x3 & (long) this.x4);
    ulong i4 = (ulong) ((long) this.x0 ^ (long) this.x1 ^ (long) this.x2 ^ (long) c ^ ~(long) this.x0 & ((long) this.x3 ^ (long) this.x4));
    ulong i5 = (ulong) ((long) this.x1 ^ (long) this.x3 ^ (long) this.x4 ^ ((long) this.x0 ^ (long) this.x4) & (long) this.x1);
    this.x0 = i1 ^ Longs.RotateRight(i1, 19) ^ Longs.RotateRight(i1, 28);
    this.x1 = i2 ^ Longs.RotateRight(i2, 39) ^ Longs.RotateRight(i2, 61);
    this.x2 = (ulong) ~((long) i3 ^ (long) Longs.RotateRight(i3, 1) ^ (long) Longs.RotateRight(i3, 6));
    this.x3 = i4 ^ Longs.RotateRight(i4, 10) ^ Longs.RotateRight(i4, 17);
    this.x4 = i5 ^ Longs.RotateRight(i5, 7) ^ Longs.RotateRight(i5, 41);
  }

  private void ascon_aeadinit()
  {
    this.x0 = this.ASCON_IV;
    if (this.CRYPTO_KEYBYTES == 20)
      this.x0 ^= this.K0;
    this.x1 = this.K1;
    this.x2 = this.K2;
    this.x3 = this.N0;
    this.x4 = this.N1;
    this.P(12);
    if (this.CRYPTO_KEYBYTES == 20)
      this.x2 ^= this.K0;
    this.x3 ^= this.K1;
    this.x4 ^= this.K2;
  }

  private void ProcessBufferAad(byte[] buffer, int bufOff)
  {
    this.x0 ^= Pack.BE_To_UInt64(buffer, bufOff);
    if (this.ASCON_AEAD_RATE == 16 /*0x10*/)
      this.x1 ^= Pack.BE_To_UInt64(buffer, bufOff + 8);
    this.P(this.nr);
  }

  private void ProcessBufferDecrypt(byte[] buffer, int bufOff, byte[] output, int outOff)
  {
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, this.ASCON_AEAD_RATE, "output buffer too short");
    ulong uint64_1 = Pack.BE_To_UInt64(buffer, bufOff);
    Pack.UInt64_To_BE(this.x0 ^ uint64_1, output, outOff);
    this.x0 = uint64_1;
    if (this.ASCON_AEAD_RATE == 16 /*0x10*/)
    {
      ulong uint64_2 = Pack.BE_To_UInt64(buffer, bufOff + 8);
      Pack.UInt64_To_BE(this.x1 ^ uint64_2, output, outOff + 8);
      this.x1 = uint64_2;
    }
    this.P(this.nr);
  }

  private void ProcessBufferEncrypt(byte[] buffer, int bufOff, byte[] output, int outOff)
  {
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, this.ASCON_AEAD_RATE, "output buffer too short");
    this.x0 ^= Pack.BE_To_UInt64(buffer, bufOff);
    Pack.UInt64_To_BE(this.x0, output, outOff);
    if (this.ASCON_AEAD_RATE == 16 /*0x10*/)
    {
      this.x1 ^= Pack.BE_To_UInt64(buffer, bufOff + 8);
      Pack.UInt64_To_BE(this.x1, output, outOff + 8);
    }
    this.P(this.nr);
  }

  private void ProcessFinalDecrypt(byte[] input, int inOff, int inLen, byte[] output, int outOff)
  {
    if (inLen >= 8)
    {
      ulong uint64 = Pack.BE_To_UInt64(input, inOff);
      this.x0 ^= uint64;
      Pack.UInt64_To_BE(this.x0, output, outOff);
      this.x0 = uint64;
      inOff += 8;
      outOff += 8;
      inLen -= 8;
      this.x1 ^= AsconEngine.PAD(inLen);
      if (inLen != 0)
      {
        ulong uint64High = Pack.BE_To_UInt64_High(input, inOff, inLen);
        this.x1 ^= uint64High;
        Pack.UInt64_To_BE_High(this.x1, output, outOff, inLen);
        this.x1 &= ulong.MaxValue >> (inLen << 3);
        this.x1 ^= uint64High;
      }
    }
    else
    {
      this.x0 ^= AsconEngine.PAD(inLen);
      if (inLen != 0)
      {
        ulong uint64High = Pack.BE_To_UInt64_High(input, inOff, inLen);
        this.x0 ^= uint64High;
        Pack.UInt64_To_BE_High(this.x0, output, outOff, inLen);
        this.x0 &= ulong.MaxValue >> (inLen << 3);
        this.x0 ^= uint64High;
      }
    }
    this.FinishData(AsconEngine.State.DecFinal);
  }

  private void ProcessFinalEncrypt(byte[] input, int inOff, int inLen, byte[] output, int outOff)
  {
    if (inLen >= 8)
    {
      this.x0 ^= Pack.BE_To_UInt64(input, inOff);
      Pack.UInt64_To_BE(this.x0, output, outOff);
      inOff += 8;
      outOff += 8;
      inLen -= 8;
      this.x1 ^= AsconEngine.PAD(inLen);
      if (inLen != 0)
      {
        this.x1 ^= Pack.BE_To_UInt64_High(input, inOff, inLen);
        Pack.UInt64_To_BE_High(this.x1, output, outOff, inLen);
      }
    }
    else
    {
      this.x0 ^= AsconEngine.PAD(inLen);
      if (inLen != 0)
      {
        this.x0 ^= Pack.BE_To_UInt64_High(input, inOff, inLen);
        Pack.UInt64_To_BE_High(this.x0, output, outOff, inLen);
      }
    }
    this.FinishData(AsconEngine.State.EncFinal);
  }

  private void Reset(bool clearMac)
  {
    if (clearMac)
      this.mac = (byte[]) null;
    Arrays.Clear(this.m_buf);
    this.m_bufPos = 0;
    switch (this.m_state)
    {
      case AsconEngine.State.EncInit:
      case AsconEngine.State.DecInit:
        this.ascon_aeadinit();
        if (this.initialAssociatedText == null)
          break;
        this.ProcessAadBytes(this.initialAssociatedText, 0, this.initialAssociatedText.Length);
        break;
      case AsconEngine.State.EncAad:
      case AsconEngine.State.EncData:
      case AsconEngine.State.EncFinal:
        this.m_state = AsconEngine.State.EncFinal;
        break;
      case AsconEngine.State.DecAad:
      case AsconEngine.State.DecData:
      case AsconEngine.State.DecFinal:
        this.m_state = AsconEngine.State.DecInit;
        goto case AsconEngine.State.EncInit;
      default:
        throw new InvalidOperationException(this.AlgorithmName + " needs to be initialized");
    }
  }

  private static ulong PAD(int i) => 9223372036854775808UL /*0x8000000000000000*/ >> (i << 3);

  public enum AsconParameters
  {
    ascon80pq,
    ascon128a,
    ascon128,
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
