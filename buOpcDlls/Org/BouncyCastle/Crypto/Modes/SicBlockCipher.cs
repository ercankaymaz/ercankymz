// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Modes.SicBlockCipher
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Modes;

public class SicBlockCipher : IBlockCipherMode, IBlockCipher
{
  private readonly IBlockCipher cipher;
  private readonly int blockSize;
  private readonly byte[] counter;
  private readonly byte[] counterOut;
  private byte[] IV;

  public SicBlockCipher(IBlockCipher cipher)
  {
    this.cipher = cipher;
    this.blockSize = cipher.GetBlockSize();
    this.counter = new byte[this.blockSize];
    this.counterOut = new byte[this.blockSize];
    this.IV = new byte[this.blockSize];
  }

  public IBlockCipher UnderlyingCipher => this.cipher;

  public virtual void Init(bool forEncryption, ICipherParameters parameters)
  {
    this.IV = parameters is ParametersWithIV parametersWithIv ? Arrays.Clone(parametersWithIv.GetIV()) : throw new ArgumentException("CTR/SIC mode requires ParametersWithIV", nameof (parameters));
    if (this.blockSize < this.IV.Length)
      throw new ArgumentException($"CTR/SIC mode requires IV no greater than: {this.blockSize.ToString()} bytes.");
    int num = Math.Min(8, this.blockSize / 2);
    if (this.blockSize - this.IV.Length > num)
      throw new ArgumentException($"CTR/SIC mode requires IV of at least: {(this.blockSize - num).ToString()} bytes.");
    this.Reset();
    if (parametersWithIv.Parameters == null)
      return;
    this.cipher.Init(true, parametersWithIv.Parameters);
  }

  public virtual string AlgorithmName => this.cipher.AlgorithmName + "/SIC";

  public virtual bool IsPartialBlockOkay => true;

  public virtual int GetBlockSize() => this.cipher.GetBlockSize();

  public virtual int ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
  {
    this.cipher.ProcessBlock(this.counter, 0, this.counterOut, 0);
    for (int index = 0; index < this.counterOut.Length; ++index)
      output[outOff + index] = (byte) ((uint) this.counterOut[index] ^ (uint) input[inOff + index]);
    int length = this.counter.Length;
    do
      ;
    while (--length >= 0 && ++this.counter[length] == (byte) 0);
    return this.counter.Length;
  }

  public virtual void Reset()
  {
    Arrays.Fill(this.counter, (byte) 0);
    Array.Copy((Array) this.IV, 0, (Array) this.counter, 0, this.IV.Length);
  }
}
