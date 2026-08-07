// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Macs.CbcBlockCipherMac
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Macs;

public class CbcBlockCipherMac : IMac
{
  private byte[] buf;
  private int bufOff;
  private IBlockCipherMode m_cipherMode;
  private IBlockCipherPadding padding;
  private int macSize;

  public CbcBlockCipherMac(IBlockCipher cipher)
    : this(cipher, cipher.GetBlockSize() * 8 / 2, (IBlockCipherPadding) null)
  {
  }

  public CbcBlockCipherMac(IBlockCipher cipher, IBlockCipherPadding padding)
    : this(cipher, cipher.GetBlockSize() * 8 / 2, padding)
  {
  }

  public CbcBlockCipherMac(IBlockCipher cipher, int macSizeInBits)
    : this(cipher, macSizeInBits, (IBlockCipherPadding) null)
  {
  }

  public CbcBlockCipherMac(IBlockCipher cipher, int macSizeInBits, IBlockCipherPadding padding)
  {
    if (macSizeInBits % 8 != 0)
      throw new ArgumentException("MAC size must be multiple of 8");
    this.m_cipherMode = (IBlockCipherMode) new CbcBlockCipher(cipher);
    this.padding = padding;
    this.macSize = macSizeInBits / 8;
    this.buf = new byte[cipher.GetBlockSize()];
    this.bufOff = 0;
  }

  public string AlgorithmName => this.m_cipherMode.AlgorithmName;

  public void Init(ICipherParameters parameters)
  {
    this.Reset();
    this.m_cipherMode.Init(true, parameters);
  }

  public int GetMacSize() => this.macSize;

  public void Update(byte input)
  {
    if (this.bufOff == this.buf.Length)
    {
      this.m_cipherMode.ProcessBlock(this.buf, 0, this.buf, 0);
      this.bufOff = 0;
    }
    this.buf[this.bufOff++] = input;
  }

  public void BlockUpdate(byte[] input, int inOff, int len)
  {
    if (len < 0)
      throw new ArgumentException("Can't have a negative input length!");
    int blockSize = this.m_cipherMode.GetBlockSize();
    int length = blockSize - this.bufOff;
    if (len > length)
    {
      Array.Copy((Array) input, inOff, (Array) this.buf, this.bufOff, length);
      this.m_cipherMode.ProcessBlock(this.buf, 0, this.buf, 0);
      this.bufOff = 0;
      len -= length;
      inOff += length;
      while (len > blockSize)
      {
        this.m_cipherMode.ProcessBlock(input, inOff, this.buf, 0);
        len -= blockSize;
        inOff += blockSize;
      }
    }
    Array.Copy((Array) input, inOff, (Array) this.buf, this.bufOff, len);
    this.bufOff += len;
  }

  public int DoFinal(byte[] output, int outOff)
  {
    int blockSize = this.m_cipherMode.GetBlockSize();
    if (this.padding == null)
    {
      while (this.bufOff < blockSize)
        this.buf[this.bufOff++] = (byte) 0;
    }
    else
    {
      if (this.bufOff == blockSize)
      {
        this.m_cipherMode.ProcessBlock(this.buf, 0, this.buf, 0);
        this.bufOff = 0;
      }
      this.padding.AddPadding(this.buf, this.bufOff);
    }
    this.m_cipherMode.ProcessBlock(this.buf, 0, this.buf, 0);
    Array.Copy((Array) this.buf, 0, (Array) output, outOff, this.macSize);
    this.Reset();
    return this.macSize;
  }

  public void Reset()
  {
    Array.Clear((Array) this.buf, 0, this.buf.Length);
    this.bufOff = 0;
    this.m_cipherMode.Reset();
  }
}
