// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Modes.CtsBlockCipher
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Modes;

public class CtsBlockCipher : BufferedBlockCipher
{
  private readonly int blockSize;

  public CtsBlockCipher(IBlockCipher cipher)
    : this(EcbBlockCipher.GetBlockCipherMode(cipher))
  {
  }

  public CtsBlockCipher(IBlockCipherMode cipherMode)
  {
    switch (cipherMode)
    {
      case CbcBlockCipher _:
      case EcbBlockCipher _:
        this.m_cipherMode = cipherMode;
        this.blockSize = cipherMode.GetBlockSize();
        this.buf = new byte[this.blockSize * 2];
        this.bufOff = 0;
        break;
      default:
        throw new ArgumentException("CtsBlockCipher can only accept ECB, or CBC ciphers");
    }
  }

  public override int GetUpdateOutputSize(int length)
  {
    int num1 = length + this.bufOff;
    int num2 = num1 % this.buf.Length;
    return num2 == 0 ? num1 - this.buf.Length : num1 - num2;
  }

  public override int GetOutputSize(int length) => length + this.bufOff;

  public override int ProcessByte(byte input, byte[] output, int outOff)
  {
    int num = 0;
    if (this.bufOff == this.buf.Length)
    {
      num = this.m_cipherMode.ProcessBlock(this.buf, 0, output, outOff);
      Array.Copy((Array) this.buf, this.blockSize, (Array) this.buf, 0, this.blockSize);
      this.bufOff = this.blockSize;
    }
    this.buf[this.bufOff++] = (byte) (int) input;
    return num;
  }

  public override int ProcessBytes(
    byte[] input,
    int inOff,
    int length,
    byte[] output,
    int outOff)
  {
    if (length < 0)
      throw new ArgumentException("Can't have a negative input length!");
    int blockSize = this.GetBlockSize();
    int updateOutputSize = this.GetUpdateOutputSize(length);
    if (updateOutputSize > 0)
      Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, updateOutputSize, "output buffer too short");
    int num = 0;
    int length1 = this.buf.Length - this.bufOff;
    if (length > length1)
    {
      Array.Copy((Array) input, inOff, (Array) this.buf, this.bufOff, length1);
      num = this.m_cipherMode.ProcessBlock(this.buf, 0, output, outOff);
      Array.Copy((Array) this.buf, blockSize, (Array) this.buf, 0, blockSize);
      this.bufOff = blockSize;
      length -= length1;
      inOff += length1;
      while (length > blockSize)
      {
        Array.Copy((Array) input, inOff, (Array) this.buf, this.bufOff, blockSize);
        num += this.m_cipherMode.ProcessBlock(this.buf, 0, output, outOff + num);
        Array.Copy((Array) this.buf, blockSize, (Array) this.buf, 0, blockSize);
        length -= blockSize;
        inOff += blockSize;
      }
    }
    Array.Copy((Array) input, inOff, (Array) this.buf, this.bufOff, length);
    this.bufOff += length;
    return num;
  }

  public override int DoFinal(byte[] output, int outOff)
  {
    if (this.bufOff + outOff > output.Length)
      throw new DataLengthException("output buffer too small in DoFinal");
    int blockSize = this.m_cipherMode.GetBlockSize();
    int length = this.bufOff - blockSize;
    byte[] numArray = new byte[blockSize];
    if (this.forEncryption)
    {
      this.m_cipherMode.ProcessBlock(this.buf, 0, numArray, 0);
      if (this.bufOff < blockSize)
        throw new DataLengthException("need at least one block of input for CTS");
      for (int bufOff = this.bufOff; bufOff != this.buf.Length; ++bufOff)
        this.buf[bufOff] = numArray[bufOff - blockSize];
      for (int index = blockSize; index != this.bufOff; ++index)
        this.buf[index] ^= numArray[index - blockSize];
      this.m_cipherMode.UnderlyingCipher.ProcessBlock(this.buf, blockSize, output, outOff);
      Array.Copy((Array) numArray, 0, (Array) output, outOff + blockSize, length);
    }
    else
    {
      byte[] sourceArray = new byte[blockSize];
      this.m_cipherMode.UnderlyingCipher.ProcessBlock(this.buf, 0, numArray, 0);
      for (int index = blockSize; index != this.bufOff; ++index)
        sourceArray[index - blockSize] = (byte) ((uint) numArray[index - blockSize] ^ (uint) this.buf[index]);
      Array.Copy((Array) this.buf, blockSize, (Array) numArray, 0, length);
      this.m_cipherMode.ProcessBlock(numArray, 0, output, outOff);
      Array.Copy((Array) sourceArray, 0, (Array) output, outOff + blockSize, length);
    }
    int bufOff1 = this.bufOff;
    this.Reset();
    return bufOff1;
  }
}
