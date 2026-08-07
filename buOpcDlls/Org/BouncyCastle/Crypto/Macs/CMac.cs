// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Macs.CMac
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Macs;

public class CMac : IMac
{
  private const byte CONSTANT_128 = 135;
  private const byte CONSTANT_64 = 27;
  private byte[] ZEROES;
  private byte[] mac;
  private byte[] buf;
  private int bufOff;
  private IBlockCipherMode m_cipherMode;
  private int macSize;
  private byte[] L;
  private byte[] Lu;
  private byte[] Lu2;

  public CMac(IBlockCipher cipher)
    : this(cipher, cipher.GetBlockSize() * 8)
  {
  }

  public CMac(IBlockCipher cipher, int macSizeInBits)
  {
    if (macSizeInBits % 8 != 0)
      throw new ArgumentException("MAC size must be multiple of 8");
    if (macSizeInBits > cipher.GetBlockSize() * 8)
      throw new ArgumentException("MAC size must be less or equal to " + (cipher.GetBlockSize() * 8).ToString());
    this.m_cipherMode = cipher.GetBlockSize() == 8 || cipher.GetBlockSize() == 16 /*0x10*/ ? (IBlockCipherMode) new CbcBlockCipher(cipher) : throw new ArgumentException("Block size must be either 64 or 128 bits");
    this.macSize = macSizeInBits / 8;
    this.mac = new byte[cipher.GetBlockSize()];
    this.buf = new byte[cipher.GetBlockSize()];
    this.ZEROES = new byte[cipher.GetBlockSize()];
    this.bufOff = 0;
  }

  public string AlgorithmName => this.m_cipherMode.AlgorithmName;

  private static int ShiftLeft(byte[] block, byte[] output)
  {
    int length = block.Length;
    uint num1 = 0;
    while (--length >= 0)
    {
      uint num2 = (uint) block[length];
      output[length] = (byte) (num2 << 1 | num1);
      num1 = num2 >> 7 & 1U;
    }
    return (int) num1;
  }

  private static byte[] DoubleLu(byte[] input)
  {
    byte[] output = new byte[input.Length];
    int num1 = CMac.ShiftLeft(input, output);
    int num2 = input.Length == 16 /*0x10*/ ? 135 : 27;
    output[input.Length - 1] ^= (byte) (num2 >> (1 - num1 << 3));
    return output;
  }

  public void Init(ICipherParameters parameters)
  {
    if (parameters is KeyParameter)
    {
      this.m_cipherMode.Init(true, parameters);
      this.L = new byte[this.ZEROES.Length];
      this.m_cipherMode.ProcessBlock(this.ZEROES, 0, this.L, 0);
      this.Lu = CMac.DoubleLu(this.L);
      this.Lu2 = CMac.DoubleLu(this.Lu);
    }
    else if (parameters != null)
      throw new ArgumentException("CMac mode only permits key to be set.", nameof (parameters));
    this.Reset();
  }

  public int GetMacSize() => this.macSize;

  public void Update(byte input)
  {
    if (this.bufOff == this.buf.Length)
    {
      this.m_cipherMode.ProcessBlock(this.buf, 0, this.mac, 0);
      this.bufOff = 0;
    }
    this.buf[this.bufOff++] = input;
  }

  public void BlockUpdate(byte[] inBytes, int inOff, int len)
  {
    if (len < 0)
      throw new ArgumentException("Can't have a negative input length!");
    int blockSize = this.m_cipherMode.GetBlockSize();
    int length = blockSize - this.bufOff;
    if (len > length)
    {
      Array.Copy((Array) inBytes, inOff, (Array) this.buf, this.bufOff, length);
      this.m_cipherMode.ProcessBlock(this.buf, 0, this.mac, 0);
      this.bufOff = 0;
      len -= length;
      inOff += length;
      while (len > blockSize)
      {
        this.m_cipherMode.ProcessBlock(inBytes, inOff, this.mac, 0);
        len -= blockSize;
        inOff += blockSize;
      }
    }
    Array.Copy((Array) inBytes, inOff, (Array) this.buf, this.bufOff, len);
    this.bufOff += len;
  }

  public int DoFinal(byte[] outBytes, int outOff)
  {
    byte[] numArray;
    if (this.bufOff == this.m_cipherMode.GetBlockSize())
    {
      numArray = this.Lu;
    }
    else
    {
      new ISO7816d4Padding().AddPadding(this.buf, this.bufOff);
      numArray = this.Lu2;
    }
    for (int index = 0; index < this.mac.Length; ++index)
      this.buf[index] ^= numArray[index];
    this.m_cipherMode.ProcessBlock(this.buf, 0, this.mac, 0);
    Array.Copy((Array) this.mac, 0, (Array) outBytes, outOff, this.macSize);
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
