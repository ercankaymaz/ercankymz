// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.StreamBlockCipher
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Modes;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto;

public class StreamBlockCipher : IStreamCipher
{
  private readonly IBlockCipherMode m_cipherMode;
  private readonly byte[] oneByte = new byte[1];

  public StreamBlockCipher(IBlockCipherMode cipherMode)
  {
    if (cipherMode == null)
      throw new ArgumentNullException(nameof (cipherMode));
    this.m_cipherMode = cipherMode.GetBlockSize() == 1 ? cipherMode : throw new ArgumentException("block cipher block size != 1.", nameof (cipherMode));
  }

  public void Init(bool forEncryption, ICipherParameters parameters)
  {
    this.m_cipherMode.Init(forEncryption, parameters);
  }

  public string AlgorithmName => this.m_cipherMode.AlgorithmName;

  public byte ReturnByte(byte input)
  {
    this.oneByte[0] = input;
    this.m_cipherMode.ProcessBlock(this.oneByte, 0, this.oneByte, 0);
    return this.oneByte[0];
  }

  public void ProcessBytes(byte[] input, int inOff, int length, byte[] output, int outOff)
  {
    Check.DataLength(input, inOff, length, "input buffer too short");
    Check.OutputLength(output, outOff, length, "output buffer too short");
    for (int index = 0; index != length; ++index)
      this.m_cipherMode.ProcessBlock(input, inOff + index, output, outOff + index);
  }

  public void Reset() => this.m_cipherMode.Reset();
}
