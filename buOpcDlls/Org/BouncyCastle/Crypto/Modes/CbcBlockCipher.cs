// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Modes.CbcBlockCipher
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Modes;

public sealed class CbcBlockCipher : IBlockCipherMode, IBlockCipher
{
  private byte[] IV;
  private byte[] cbcV;
  private byte[] cbcNextV;
  private int blockSize;
  private IBlockCipher cipher;
  private bool encrypting;

  public CbcBlockCipher(IBlockCipher cipher)
  {
    this.cipher = cipher;
    this.blockSize = cipher.GetBlockSize();
    this.IV = new byte[this.blockSize];
    this.cbcV = new byte[this.blockSize];
    this.cbcNextV = new byte[this.blockSize];
  }

  public IBlockCipher UnderlyingCipher => this.cipher;

  public void Init(bool forEncryption, ICipherParameters parameters)
  {
    bool encrypting = this.encrypting;
    this.encrypting = forEncryption;
    if (parameters is ParametersWithIV parametersWithIv)
    {
      byte[] iv = parametersWithIv.GetIV();
      if (iv.Length != this.blockSize)
        throw new ArgumentException("initialisation vector must be the same length as block size");
      Array.Copy((Array) iv, 0, (Array) this.IV, 0, iv.Length);
      parameters = parametersWithIv.Parameters;
    }
    this.Reset();
    if (parameters != null)
      this.cipher.Init(this.encrypting, parameters);
    else if (encrypting != this.encrypting)
      throw new ArgumentException("cannot change encrypting state without providing key.");
  }

  public string AlgorithmName => this.cipher.AlgorithmName + "/CBC";

  public bool IsPartialBlockOkay => false;

  public int GetBlockSize() => this.cipher.GetBlockSize();

  public int ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
  {
    return !this.encrypting ? this.DecryptBlock(input, inOff, output, outOff) : this.EncryptBlock(input, inOff, output, outOff);
  }

  public void Reset()
  {
    Array.Copy((Array) this.IV, 0, (Array) this.cbcV, 0, this.IV.Length);
    Array.Clear((Array) this.cbcNextV, 0, this.cbcNextV.Length);
  }

  private int EncryptBlock(byte[] input, int inOff, byte[] outBytes, int outOff)
  {
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, this.blockSize, "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(outBytes, outOff, this.blockSize, "output buffer too short");
    for (int index = 0; index < this.blockSize; ++index)
      this.cbcV[index] ^= input[inOff + index];
    int num = this.cipher.ProcessBlock(this.cbcV, 0, outBytes, outOff);
    Array.Copy((Array) outBytes, outOff, (Array) this.cbcV, 0, this.cbcV.Length);
    return num;
  }

  private int DecryptBlock(byte[] input, int inOff, byte[] outBytes, int outOff)
  {
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, this.blockSize, "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(outBytes, outOff, this.blockSize, "output buffer too short");
    Array.Copy((Array) input, inOff, (Array) this.cbcNextV, 0, this.blockSize);
    int num = this.cipher.ProcessBlock(input, inOff, outBytes, outOff);
    for (int index = 0; index < this.blockSize; ++index)
      outBytes[outOff + index] ^= this.cbcV[index];
    byte[] cbcV = this.cbcV;
    this.cbcV = this.cbcNextV;
    this.cbcNextV = cbcV;
    return num;
  }
}
