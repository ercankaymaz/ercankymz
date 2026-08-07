// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Macs.MacCfbBlockCipher
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Macs;

internal class MacCfbBlockCipher : IBlockCipherMode, IBlockCipher
{
  private byte[] IV;
  private byte[] cfbV;
  private byte[] cfbOutV;
  private readonly int blockSize;
  private readonly IBlockCipher cipher;

  public MacCfbBlockCipher(IBlockCipher cipher, int bitBlockSize)
  {
    this.cipher = cipher;
    this.blockSize = bitBlockSize / 8;
    this.IV = new byte[cipher.GetBlockSize()];
    this.cfbV = new byte[cipher.GetBlockSize()];
    this.cfbOutV = new byte[cipher.GetBlockSize()];
  }

  public void Init(bool forEncryption, ICipherParameters parameters)
  {
    if (parameters is ParametersWithIV parametersWithIv)
    {
      byte[] iv = parametersWithIv.GetIV();
      if (iv.Length < this.IV.Length)
        Array.Copy((Array) iv, 0, (Array) this.IV, this.IV.Length - iv.Length, iv.Length);
      else
        Array.Copy((Array) iv, 0, (Array) this.IV, 0, this.IV.Length);
      parameters = parametersWithIv.Parameters;
    }
    this.Reset();
    this.cipher.Init(true, parameters);
  }

  public string AlgorithmName
  {
    get => $"{this.cipher.AlgorithmName}/CFB{(this.blockSize * 8).ToString()}";
  }

  public IBlockCipher UnderlyingCipher => this.cipher;

  public bool IsPartialBlockOkay => true;

  public int GetBlockSize() => this.blockSize;

  public int ProcessBlock(byte[] input, int inOff, byte[] outBytes, int outOff)
  {
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, this.blockSize, "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(outBytes, outOff, this.blockSize, "output buffer too short");
    this.cipher.ProcessBlock(this.cfbV, 0, this.cfbOutV, 0);
    for (int index = 0; index < this.blockSize; ++index)
      outBytes[outOff + index] = (byte) ((uint) this.cfbOutV[index] ^ (uint) input[inOff + index]);
    Array.Copy((Array) this.cfbV, this.blockSize, (Array) this.cfbV, 0, this.cfbV.Length - this.blockSize);
    Array.Copy((Array) outBytes, outOff, (Array) this.cfbV, this.cfbV.Length - this.blockSize, this.blockSize);
    return this.blockSize;
  }

  public void Reset() => this.IV.CopyTo((Array) this.cfbV, 0);

  public void GetMacBlock(byte[] mac) => this.cipher.ProcessBlock(this.cfbV, 0, mac, 0);
}
