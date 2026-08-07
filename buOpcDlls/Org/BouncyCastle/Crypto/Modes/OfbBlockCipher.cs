// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Modes.OfbBlockCipher
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Modes;

public class OfbBlockCipher : IBlockCipherMode, IBlockCipher
{
  private byte[] IV;
  private byte[] ofbV;
  private byte[] ofbOutV;
  private readonly int blockSize;
  private readonly IBlockCipher cipher;

  public OfbBlockCipher(IBlockCipher cipher, int blockSize)
  {
    this.cipher = cipher;
    this.blockSize = blockSize / 8;
    this.IV = new byte[cipher.GetBlockSize()];
    this.ofbV = new byte[cipher.GetBlockSize()];
    this.ofbOutV = new byte[cipher.GetBlockSize()];
  }

  public IBlockCipher UnderlyingCipher => this.cipher;

  public void Init(bool forEncryption, ICipherParameters parameters)
  {
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
    if (parameters == null)
      return;
    this.cipher.Init(true, parameters);
  }

  public string AlgorithmName
  {
    get => $"{this.cipher.AlgorithmName}/OFB{(this.blockSize * 8).ToString()}";
  }

  public bool IsPartialBlockOkay => true;

  public int GetBlockSize() => this.blockSize;

  public int ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
  {
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, this.blockSize, "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, this.blockSize, "output buffer too short");
    this.cipher.ProcessBlock(this.ofbV, 0, this.ofbOutV, 0);
    for (int index = 0; index < this.blockSize; ++index)
      output[outOff + index] = (byte) ((uint) this.ofbOutV[index] ^ (uint) input[inOff + index]);
    Array.Copy((Array) this.ofbV, this.blockSize, (Array) this.ofbV, 0, this.ofbV.Length - this.blockSize);
    Array.Copy((Array) this.ofbOutV, 0, (Array) this.ofbV, this.ofbV.Length - this.blockSize, this.blockSize);
    return this.blockSize;
  }

  public void Reset() => Array.Copy((Array) this.IV, 0, (Array) this.ofbV, 0, this.IV.Length);
}
