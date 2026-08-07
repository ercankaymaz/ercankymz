// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Modes.CfbBlockCipher
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Modes;

public class CfbBlockCipher : IBlockCipherMode, IBlockCipher
{
  private byte[] IV;
  private byte[] cfbV;
  private byte[] cfbOutV;
  private bool encrypting;
  private readonly int blockSize;
  private readonly IBlockCipher cipher;

  public CfbBlockCipher(IBlockCipher cipher, int bitBlockSize)
  {
    if (bitBlockSize < 8 || (bitBlockSize & 7) != 0)
      throw new ArgumentException($"CFB{bitBlockSize.ToString()} not supported", nameof (bitBlockSize));
    this.cipher = cipher;
    this.blockSize = bitBlockSize / 8;
    this.IV = new byte[cipher.GetBlockSize()];
    this.cfbV = new byte[cipher.GetBlockSize()];
    this.cfbOutV = new byte[cipher.GetBlockSize()];
  }

  public IBlockCipher UnderlyingCipher => this.cipher;

  public void Init(bool forEncryption, ICipherParameters parameters)
  {
    this.encrypting = forEncryption;
    if (parameters is ParametersWithIV parametersWithIv)
    {
      byte[] iv = parametersWithIv.GetIV();
      int num = this.IV.Length - iv.Length;
      Array.Copy((Array) iv, 0, (Array) this.IV, num, iv.Length);
      Array.Clear((Array) this.IV, 0, num);
      parameters = parametersWithIv.Parameters;
    }
    this.Reset();
    if (parameters == null)
      return;
    this.cipher.Init(true, parameters);
  }

  public string AlgorithmName
  {
    get => $"{this.cipher.AlgorithmName}/CFB{(this.blockSize * 8).ToString()}";
  }

  public bool IsPartialBlockOkay => true;

  public int GetBlockSize() => this.blockSize;

  public int ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
  {
    return !this.encrypting ? this.DecryptBlock(input, inOff, output, outOff) : this.EncryptBlock(input, inOff, output, outOff);
  }

  private int EncryptBlock(byte[] input, int inOff, byte[] outBytes, int outOff)
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

  private int DecryptBlock(byte[] input, int inOff, byte[] outBytes, int outOff)
  {
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, this.blockSize, "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(outBytes, outOff, this.blockSize, "output buffer too short");
    this.cipher.ProcessBlock(this.cfbV, 0, this.cfbOutV, 0);
    Array.Copy((Array) this.cfbV, this.blockSize, (Array) this.cfbV, 0, this.cfbV.Length - this.blockSize);
    Array.Copy((Array) input, inOff, (Array) this.cfbV, this.cfbV.Length - this.blockSize, this.blockSize);
    for (int index = 0; index < this.blockSize; ++index)
      outBytes[outOff + index] = (byte) ((uint) this.cfbOutV[index] ^ (uint) input[inOff + index]);
    return this.blockSize;
  }

  public void Reset() => Array.Copy((Array) this.IV, 0, (Array) this.cfbV, 0, this.IV.Length);
}
