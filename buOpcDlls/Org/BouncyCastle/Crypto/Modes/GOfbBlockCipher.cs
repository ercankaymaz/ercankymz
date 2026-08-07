// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Modes.GOfbBlockCipher
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Modes;

public class GOfbBlockCipher : IBlockCipherMode, IBlockCipher
{
  private byte[] IV;
  private byte[] ofbV;
  private byte[] ofbOutV;
  private readonly int blockSize;
  private readonly IBlockCipher cipher;
  private bool firstStep = true;
  private int N3;
  private int N4;
  private const int C1 = 16843012;
  private const int C2 = 16843009;

  public GOfbBlockCipher(IBlockCipher cipher)
  {
    this.cipher = cipher;
    this.blockSize = cipher.GetBlockSize();
    if (this.blockSize != 8)
      throw new ArgumentException("GCTR only for 64 bit block ciphers");
    this.IV = new byte[cipher.GetBlockSize()];
    this.ofbV = new byte[cipher.GetBlockSize()];
    this.ofbOutV = new byte[cipher.GetBlockSize()];
  }

  public IBlockCipher UnderlyingCipher => this.cipher;

  public void Init(bool forEncryption, ICipherParameters parameters)
  {
    this.firstStep = true;
    this.N3 = 0;
    this.N4 = 0;
    if (parameters is ParametersWithIV)
    {
      ParametersWithIV parametersWithIv = (ParametersWithIV) parameters;
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

  public string AlgorithmName => this.cipher.AlgorithmName + "/GCTR";

  public bool IsPartialBlockOkay => true;

  public int GetBlockSize() => this.blockSize;

  public int ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
  {
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, this.blockSize, "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, this.blockSize, "output buffer too short");
    if (this.firstStep)
    {
      this.firstStep = false;
      this.cipher.ProcessBlock(this.ofbV, 0, this.ofbOutV, 0);
      this.N3 = (int) Pack.LE_To_UInt32(this.ofbOutV, 0);
      this.N4 = (int) Pack.LE_To_UInt32(this.ofbOutV, 4);
    }
    this.N3 += 16843009;
    this.N4 += 16843012;
    if (this.N4 < 16843012 && this.N4 > 0)
      ++this.N4;
    Pack.UInt32_To_LE((uint) this.N3, this.ofbV, 0);
    Pack.UInt32_To_LE((uint) this.N4, this.ofbV, 4);
    this.cipher.ProcessBlock(this.ofbV, 0, this.ofbOutV, 0);
    for (int index = 0; index < this.blockSize; ++index)
      output[outOff + index] = (byte) ((uint) this.ofbOutV[index] ^ (uint) input[inOff + index]);
    Array.Copy((Array) this.ofbV, this.blockSize, (Array) this.ofbV, 0, this.ofbV.Length - this.blockSize);
    Array.Copy((Array) this.ofbOutV, 0, (Array) this.ofbV, this.ofbV.Length - this.blockSize, this.blockSize);
    return this.blockSize;
  }

  public void Reset() => Array.Copy((Array) this.IV, 0, (Array) this.ofbV, 0, this.IV.Length);
}
