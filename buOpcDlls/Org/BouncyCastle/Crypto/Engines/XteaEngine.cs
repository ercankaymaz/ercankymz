// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.XteaEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class XteaEngine : IBlockCipher
{
  private const int rounds = 32 /*0x20*/;
  private const int block_size = 8;
  private const int delta = -1640531527;
  private uint[] _S = new uint[4];
  private uint[] _sum0 = new uint[32 /*0x20*/];
  private uint[] _sum1 = new uint[32 /*0x20*/];
  private bool _initialised;
  private bool _forEncryption;

  public XteaEngine() => this._initialised = false;

  public virtual string AlgorithmName => "XTEA";

  public virtual int GetBlockSize() => 8;

  public virtual void Init(bool forEncryption, ICipherParameters parameters)
  {
    if (!(parameters is KeyParameter))
      throw new ArgumentException("invalid parameter passed to TEA init - " + Platform.GetTypeName((object) parameters));
    this._forEncryption = forEncryption;
    this._initialised = true;
    this.setKey(((KeyParameter) parameters).GetKey());
  }

  public virtual int ProcessBlock(byte[] inBytes, int inOff, byte[] outBytes, int outOff)
  {
    if (!this._initialised)
      throw new InvalidOperationException(this.AlgorithmName + " not initialised");
    Org.BouncyCastle.Crypto.Check.DataLength(inBytes, inOff, 8, "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(outBytes, outOff, 8, "output buffer too short");
    return !this._forEncryption ? this.DecryptBlock(inBytes, inOff, outBytes, outOff) : this.EncryptBlock(inBytes, inOff, outBytes, outOff);
  }

  private void setKey(byte[] key)
  {
    int off = 0;
    int index1 = 0;
    while (index1 < 4)
    {
      this._S[index1] = Pack.BE_To_UInt32(key, off);
      ++index1;
      off += 4;
    }
    int num = 0;
    for (int index2 = 0; index2 < 32 /*0x20*/; ++index2)
    {
      this._sum0[index2] = (uint) num + this._S[num & 3];
      num += -1640531527;
      this._sum1[index2] = (uint) num + this._S[num >> 11 & 3];
    }
  }

  private int EncryptBlock(byte[] inBytes, int inOff, byte[] outBytes, int outOff)
  {
    uint uint32_1 = Pack.BE_To_UInt32(inBytes, inOff);
    uint uint32_2 = Pack.BE_To_UInt32(inBytes, inOff + 4);
    for (int index = 0; index < 32 /*0x20*/; ++index)
    {
      uint32_1 += (uint32_2 << 4 ^ uint32_2 >> 5) + uint32_2 ^ this._sum0[index];
      uint32_2 += (uint32_1 << 4 ^ uint32_1 >> 5) + uint32_1 ^ this._sum1[index];
    }
    Pack.UInt32_To_BE(uint32_1, outBytes, outOff);
    Pack.UInt32_To_BE(uint32_2, outBytes, outOff + 4);
    return 8;
  }

  private int DecryptBlock(byte[] inBytes, int inOff, byte[] outBytes, int outOff)
  {
    uint uint32_1 = Pack.BE_To_UInt32(inBytes, inOff);
    uint uint32_2 = Pack.BE_To_UInt32(inBytes, inOff + 4);
    for (int index = 31 /*0x1F*/; index >= 0; --index)
    {
      uint32_2 -= (uint32_1 << 4 ^ uint32_1 >> 5) + uint32_1 ^ this._sum1[index];
      uint32_1 -= (uint32_2 << 4 ^ uint32_2 >> 5) + uint32_2 ^ this._sum0[index];
    }
    Pack.UInt32_To_BE(uint32_1, outBytes, outOff);
    Pack.UInt32_To_BE(uint32_2, outBytes, outOff + 4);
    return 8;
  }
}
