// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Modes.OpenPgpCfbBlockCipher
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Modes;

public class OpenPgpCfbBlockCipher : IBlockCipherMode, IBlockCipher
{
  private byte[] IV;
  private byte[] FR;
  private byte[] FRE;
  private readonly IBlockCipher cipher;
  private readonly int blockSize;
  private int count;
  private bool forEncryption;

  public OpenPgpCfbBlockCipher(IBlockCipher cipher)
  {
    this.cipher = cipher;
    this.blockSize = cipher.GetBlockSize();
    this.IV = new byte[this.blockSize];
    this.FR = new byte[this.blockSize];
    this.FRE = new byte[this.blockSize];
  }

  public IBlockCipher UnderlyingCipher => this.cipher;

  public string AlgorithmName => this.cipher.AlgorithmName + "/OpenPGPCFB";

  public bool IsPartialBlockOkay => true;

  public int GetBlockSize() => this.cipher.GetBlockSize();

  public int ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
  {
    return !this.forEncryption ? this.DecryptBlock(input, inOff, output, outOff) : this.EncryptBlock(input, inOff, output, outOff);
  }

  public void Reset()
  {
    this.count = 0;
    Array.Copy((Array) this.IV, 0, (Array) this.FR, 0, this.FR.Length);
  }

  public void Init(bool forEncryption, ICipherParameters parameters)
  {
    this.forEncryption = forEncryption;
    if (parameters is ParametersWithIV parametersWithIv)
    {
      byte[] iv = parametersWithIv.GetIV();
      if (iv.Length < this.IV.Length)
      {
        Array.Copy((Array) iv, 0, (Array) this.IV, this.IV.Length - iv.Length, iv.Length);
        for (int index = 0; index < this.IV.Length - iv.Length; ++index)
          this.IV[index] = (byte) 0;
      }
      else
        Array.Copy((Array) iv, 0, (Array) this.IV, 0, this.IV.Length);
      parameters = parametersWithIv.Parameters;
    }
    this.Reset();
    this.cipher.Init(true, parameters);
  }

  private byte EncryptByte(byte data, int blockOff)
  {
    return (byte) ((uint) this.FRE[blockOff] ^ (uint) data);
  }

  private int EncryptBlock(byte[] input, int inOff, byte[] outBytes, int outOff)
  {
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, this.blockSize, "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(outBytes, outOff, this.blockSize, "output buffer too short");
    if (this.count > this.blockSize)
    {
      this.FR[this.blockSize - 2] = outBytes[outOff] = this.EncryptByte(input[inOff], this.blockSize - 2);
      this.FR[this.blockSize - 1] = outBytes[outOff + 1] = this.EncryptByte(input[inOff + 1], this.blockSize - 1);
      this.cipher.ProcessBlock(this.FR, 0, this.FRE, 0);
      for (int index = 2; index < this.blockSize; ++index)
        this.FR[index - 2] = outBytes[outOff + index] = this.EncryptByte(input[inOff + index], index - 2);
    }
    else if (this.count == 0)
    {
      this.cipher.ProcessBlock(this.FR, 0, this.FRE, 0);
      for (int blockOff = 0; blockOff < this.blockSize; ++blockOff)
        this.FR[blockOff] = outBytes[outOff + blockOff] = this.EncryptByte(input[inOff + blockOff], blockOff);
      this.count += this.blockSize;
    }
    else if (this.count == this.blockSize)
    {
      this.cipher.ProcessBlock(this.FR, 0, this.FRE, 0);
      outBytes[outOff] = this.EncryptByte(input[inOff], 0);
      outBytes[outOff + 1] = this.EncryptByte(input[inOff + 1], 1);
      Array.Copy((Array) this.FR, 2, (Array) this.FR, 0, this.blockSize - 2);
      Array.Copy((Array) outBytes, outOff, (Array) this.FR, this.blockSize - 2, 2);
      this.cipher.ProcessBlock(this.FR, 0, this.FRE, 0);
      for (int index = 2; index < this.blockSize; ++index)
        this.FR[index - 2] = outBytes[outOff + index] = this.EncryptByte(input[inOff + index], index - 2);
      this.count += this.blockSize;
    }
    return this.blockSize;
  }

  private int DecryptBlock(byte[] input, int inOff, byte[] outBytes, int outOff)
  {
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, this.blockSize, "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(outBytes, outOff, this.blockSize, "output buffer too short");
    if (this.count > this.blockSize)
    {
      byte data1 = input[inOff];
      this.FR[this.blockSize - 2] = data1;
      outBytes[outOff] = this.EncryptByte(data1, this.blockSize - 2);
      byte data2 = input[inOff + 1];
      this.FR[this.blockSize - 1] = data2;
      outBytes[outOff + 1] = this.EncryptByte(data2, this.blockSize - 1);
      this.cipher.ProcessBlock(this.FR, 0, this.FRE, 0);
      for (int index = 2; index < this.blockSize; ++index)
      {
        byte data3 = input[inOff + index];
        this.FR[index - 2] = data3;
        outBytes[outOff + index] = this.EncryptByte(data3, index - 2);
      }
    }
    else if (this.count == 0)
    {
      this.cipher.ProcessBlock(this.FR, 0, this.FRE, 0);
      for (int blockOff = 0; blockOff < this.blockSize; ++blockOff)
      {
        this.FR[blockOff] = input[inOff + blockOff];
        outBytes[outOff + blockOff] = this.EncryptByte(input[inOff + blockOff], blockOff);
      }
      this.count += this.blockSize;
    }
    else if (this.count == this.blockSize)
    {
      this.cipher.ProcessBlock(this.FR, 0, this.FRE, 0);
      byte data4 = input[inOff];
      byte data5 = input[inOff + 1];
      outBytes[outOff] = this.EncryptByte(data4, 0);
      outBytes[outOff + 1] = this.EncryptByte(data5, 1);
      Array.Copy((Array) this.FR, 2, (Array) this.FR, 0, this.blockSize - 2);
      this.FR[this.blockSize - 2] = data4;
      this.FR[this.blockSize - 1] = data5;
      this.cipher.ProcessBlock(this.FR, 0, this.FRE, 0);
      for (int index = 2; index < this.blockSize; ++index)
      {
        byte data6 = input[inOff + index];
        this.FR[index - 2] = data6;
        outBytes[outOff + index] = this.EncryptByte(data6, index - 2);
      }
      this.count += this.blockSize;
    }
    return this.blockSize;
  }
}
