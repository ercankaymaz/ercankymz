// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Macs.Poly1305
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Macs;

public class Poly1305 : IMac
{
  private const int BlockSize = 16 /*0x10*/;
  private readonly IBlockCipher cipher;
  private uint r0;
  private uint r1;
  private uint r2;
  private uint r3;
  private uint r4;
  private uint s1;
  private uint s2;
  private uint s3;
  private uint s4;
  private uint k0;
  private uint k1;
  private uint k2;
  private uint k3;
  private byte[] currentBlock = new byte[16 /*0x10*/];
  private int currentBlockOffset;
  private uint h0;
  private uint h1;
  private uint h2;
  private uint h3;
  private uint h4;

  public Poly1305() => this.cipher = (IBlockCipher) null;

  public Poly1305(IBlockCipher cipher)
  {
    this.cipher = cipher.GetBlockSize() == 16 /*0x10*/ ? cipher : throw new ArgumentException("Poly1305 requires a 128 bit block cipher.");
  }

  public void Init(ICipherParameters parameters)
  {
    byte[] nonce = (byte[]) null;
    if (this.cipher != null)
    {
      nonce = parameters is ParametersWithIV parametersWithIv ? parametersWithIv.GetIV() : throw new ArgumentException("Poly1305 requires an IV when used with a block cipher.", nameof (parameters));
      parameters = parametersWithIv.Parameters;
    }
    if (!(parameters is KeyParameter keyParameter))
      throw new ArgumentException("Poly1305 requires a key.");
    this.SetKey(keyParameter, nonce);
    this.Reset();
  }

  private void SetKey(KeyParameter keyParameter, byte[] nonce)
  {
    byte[] key = keyParameter.GetKey();
    if (key.Length != 32 /*0x20*/)
      throw new ArgumentException("Poly1305 key must be 256 bits.");
    if (this.cipher != null && (nonce == null || nonce.Length != 16 /*0x10*/))
      throw new ArgumentException("Poly1305 requires a 128 bit IV.");
    uint uint32_1 = Pack.LE_To_UInt32(key, 0);
    uint uint32_2 = Pack.LE_To_UInt32(key, 4);
    uint uint32_3 = Pack.LE_To_UInt32(key, 8);
    uint uint32_4 = Pack.LE_To_UInt32(key, 12);
    this.r0 = uint32_1 & 67108863U /*0x03FFFFFF*/;
    this.r1 = (uint) (((int) (uint32_1 >> 26) | (int) uint32_2 << 6) & 67108611);
    this.r2 = (uint) (((int) (uint32_2 >> 20) | (int) uint32_3 << 12) & 67092735);
    this.r3 = (uint) (((int) (uint32_3 >> 14) | (int) uint32_4 << 18) & 66076671);
    this.r4 = uint32_4 >> 8 & 1048575U /*0x0FFFFF*/;
    this.s1 = this.r1 * 5U;
    this.s2 = this.r2 * 5U;
    this.s3 = this.r3 * 5U;
    this.s4 = this.r4 * 5U;
    if (this.cipher == null)
    {
      this.k0 = Pack.LE_To_UInt32(key, 16 /*0x10*/);
      this.k1 = Pack.LE_To_UInt32(key, 20);
      this.k2 = Pack.LE_To_UInt32(key, 24);
      this.k3 = Pack.LE_To_UInt32(key, 28);
    }
    else
    {
      byte[] numArray = new byte[16 /*0x10*/];
      this.cipher.Init(true, (ICipherParameters) new KeyParameter(key, 16 /*0x10*/, 16 /*0x10*/));
      this.cipher.ProcessBlock(nonce, 0, numArray, 0);
      this.k0 = Pack.LE_To_UInt32(numArray, 0);
      this.k1 = Pack.LE_To_UInt32(numArray, 4);
      this.k2 = Pack.LE_To_UInt32(numArray, 8);
      this.k3 = Pack.LE_To_UInt32(numArray, 12);
    }
  }

  public string AlgorithmName
  {
    get => this.cipher != null ? "Poly1305-" + this.cipher.AlgorithmName : nameof (Poly1305);
  }

  public int GetMacSize() => 16 /*0x10*/;

  public void Update(byte input)
  {
    this.currentBlock[this.currentBlockOffset++] = input;
    if (this.currentBlockOffset != 16 /*0x10*/)
      return;
    this.ProcessBlock(this.currentBlock, 0);
    this.currentBlockOffset = 0;
  }

  public void BlockUpdate(byte[] input, int inOff, int len)
  {
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, len, "input buffer too short");
    int length1 = 16 /*0x10*/ - this.currentBlockOffset;
    if (len < length1)
    {
      Array.Copy((Array) input, inOff, (Array) this.currentBlock, this.currentBlockOffset, len);
      this.currentBlockOffset += len;
    }
    else
    {
      int num = 0;
      if (this.currentBlockOffset > 0)
      {
        Array.Copy((Array) input, inOff, (Array) this.currentBlock, this.currentBlockOffset, length1);
        num = length1;
        this.ProcessBlock(this.currentBlock, 0);
      }
      int length2;
      for (; (length2 = len - num) >= 16 /*0x10*/; num += 16 /*0x10*/)
        this.ProcessBlock(input, inOff + num);
      Array.Copy((Array) input, inOff + num, (Array) this.currentBlock, 0, length2);
      this.currentBlockOffset = length2;
    }
  }

  private void ProcessBlock(byte[] buf, int off)
  {
    uint uint32_1 = Pack.LE_To_UInt32(buf, off);
    uint uint32_2 = Pack.LE_To_UInt32(buf, off + 4);
    uint uint32_3 = Pack.LE_To_UInt32(buf, off + 8);
    uint uint32_4 = Pack.LE_To_UInt32(buf, off + 12);
    this.h0 += uint32_1 & 67108863U /*0x03FFFFFF*/;
    this.h1 += (uint) (((int) uint32_2 << 6 | (int) (uint32_1 >> 26)) & 67108863 /*0x03FFFFFF*/);
    this.h2 += (uint) (((int) uint32_3 << 12 | (int) (uint32_2 >> 20)) & 67108863 /*0x03FFFFFF*/);
    this.h3 += (uint) (((int) uint32_4 << 18 | (int) (uint32_3 >> 14)) & 67108863 /*0x03FFFFFF*/);
    this.h4 += 16777216U /*0x01000000*/ | uint32_4 >> 8;
    ulong num1 = (ulong) ((long) this.h0 * (long) this.r0 + (long) this.h1 * (long) this.s4 + (long) this.h2 * (long) this.s3 + (long) this.h3 * (long) this.s2 + (long) this.h4 * (long) this.s1);
    ulong num2 = (ulong) ((long) this.h0 * (long) this.r1 + (long) this.h1 * (long) this.r0 + (long) this.h2 * (long) this.s4 + (long) this.h3 * (long) this.s3 + (long) this.h4 * (long) this.s2);
    ulong num3 = (ulong) ((long) this.h0 * (long) this.r2 + (long) this.h1 * (long) this.r1 + (long) this.h2 * (long) this.r0 + (long) this.h3 * (long) this.s4 + (long) this.h4 * (long) this.s3);
    ulong num4 = (ulong) ((long) this.h0 * (long) this.r3 + (long) this.h1 * (long) this.r2 + (long) this.h2 * (long) this.r1 + (long) this.h3 * (long) this.r0 + (long) this.h4 * (long) this.s4);
    ulong num5 = (ulong) ((long) this.h0 * (long) this.r4 + (long) this.h1 * (long) this.r3 + (long) this.h2 * (long) this.r2 + (long) this.h3 * (long) this.r1 + (long) this.h4 * (long) this.r0);
    this.h0 = (uint) num1 & 67108863U /*0x03FFFFFF*/;
    ulong num6 = num2 + (num1 >> 26);
    this.h1 = (uint) num6 & 67108863U /*0x03FFFFFF*/;
    ulong num7 = num3 + (num6 >> 26);
    this.h2 = (uint) num7 & 67108863U /*0x03FFFFFF*/;
    ulong num8 = num4 + (num7 >> 26);
    this.h3 = (uint) num8 & 67108863U /*0x03FFFFFF*/;
    ulong num9 = num5 + (num8 >> 26);
    this.h4 = (uint) num9 & 67108863U /*0x03FFFFFF*/;
    this.h0 += (uint) (num9 >> 26) * 5U;
    this.h1 += this.h0 >> 26;
    this.h0 &= 67108863U /*0x03FFFFFF*/;
  }

  public int DoFinal(byte[] output, int outOff)
  {
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, 16 /*0x10*/, "output buffer is too short.");
    if (this.currentBlockOffset > 0)
    {
      if (this.currentBlockOffset < 16 /*0x10*/)
      {
        this.currentBlock[this.currentBlockOffset++] = (byte) 1;
        while (this.currentBlockOffset < 16 /*0x10*/)
          this.currentBlock[this.currentBlockOffset++] = (byte) 0;
        this.h4 -= 16777216U /*0x01000000*/;
      }
      this.ProcessBlock(this.currentBlock, 0);
    }
    this.h0 += 5U;
    this.h1 += this.h0 >> 26;
    this.h0 &= 67108863U /*0x03FFFFFF*/;
    this.h2 += this.h1 >> 26;
    this.h1 &= 67108863U /*0x03FFFFFF*/;
    this.h3 += this.h2 >> 26;
    this.h2 &= 67108863U /*0x03FFFFFF*/;
    this.h4 += this.h3 >> 26;
    this.h3 &= 67108863U /*0x03FFFFFF*/;
    long num1;
    Pack.UInt32_To_LE((uint) (int) (num1 = (long) (((int) (this.h4 >> 26) - 1) * 5) + ((long) this.k0 + (long) (this.h0 | this.h1 << 26))), output, outOff);
    long num2;
    Pack.UInt32_To_LE((uint) (int) (num2 = (num1 >> 32 /*0x20*/) + ((long) this.k1 + (long) (this.h1 >> 6 | this.h2 << 20))), output, outOff + 4);
    long num3;
    Pack.UInt32_To_LE((uint) (int) (num3 = (num2 >> 32 /*0x20*/) + ((long) this.k2 + (long) (this.h2 >> 12 | this.h3 << 14))), output, outOff + 8);
    Pack.UInt32_To_LE((uint) ((num3 >> 32 /*0x20*/) + ((long) this.k3 + (long) (this.h3 >> 18 | this.h4 << 8))), output, outOff + 12);
    this.Reset();
    return 16 /*0x10*/;
  }

  public void Reset()
  {
    this.currentBlockOffset = 0;
    this.h4 = 0U;
    this.h3 = 0U;
    this.h2 = 0U;
    this.h1 = 0U;
    this.h0 = 0U;
  }
}
