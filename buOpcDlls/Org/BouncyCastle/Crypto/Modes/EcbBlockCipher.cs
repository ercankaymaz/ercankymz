// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Modes.EcbBlockCipher
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Modes;

public class EcbBlockCipher : IBlockCipherMode, IBlockCipher
{
  private readonly IBlockCipher m_cipher;

  internal static IBlockCipherMode GetBlockCipherMode(IBlockCipher blockCipher)
  {
    return blockCipher is IBlockCipherMode blockCipherMode ? blockCipherMode : (IBlockCipherMode) new EcbBlockCipher(blockCipher);
  }

  public EcbBlockCipher(IBlockCipher cipher)
  {
    this.m_cipher = cipher ?? throw new ArgumentNullException(nameof (cipher));
  }

  public bool IsPartialBlockOkay => false;

  public string AlgorithmName => this.m_cipher.AlgorithmName + "/ECB";

  public int GetBlockSize() => this.m_cipher.GetBlockSize();

  public IBlockCipher UnderlyingCipher => this.m_cipher;

  public void Init(bool forEncryption, ICipherParameters parameters)
  {
    this.m_cipher.Init(forEncryption, parameters);
  }

  public int ProcessBlock(byte[] inBuf, int inOff, byte[] outBuf, int outOff)
  {
    return this.m_cipher.ProcessBlock(inBuf, inOff, outBuf, outOff);
  }

  public void Reset()
  {
  }
}
