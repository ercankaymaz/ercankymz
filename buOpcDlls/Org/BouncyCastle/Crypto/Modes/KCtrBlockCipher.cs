// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Modes.KCtrBlockCipher
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Modes;

public class KCtrBlockCipher : IStreamCipher, IBlockCipherMode, IBlockCipher
{
  private byte[] IV;
  private byte[] ofbV;
  private byte[] ofbOutV;
  private bool initialised;
  private int byteCount;
  private readonly int blockSize;
  private readonly IBlockCipher cipher;

  public KCtrBlockCipher(IBlockCipher cipher)
  {
    this.cipher = cipher;
    this.IV = new byte[cipher.GetBlockSize()];
    this.blockSize = cipher.GetBlockSize();
    this.ofbV = new byte[cipher.GetBlockSize()];
    this.ofbOutV = new byte[cipher.GetBlockSize()];
  }

  public IBlockCipher UnderlyingCipher => this.cipher;

  public void Init(bool forEncryption, ICipherParameters parameters)
  {
    this.initialised = true;
    ParametersWithIV parametersWithIv = parameters is ParametersWithIV ? (ParametersWithIV) parameters : throw new ArgumentException("Invalid parameter passed");
    byte[] iv = parametersWithIv.GetIV();
    int destinationIndex = this.IV.Length - iv.Length;
    Array.Clear((Array) this.IV, 0, this.IV.Length);
    Array.Copy((Array) iv, 0, (Array) this.IV, destinationIndex, iv.Length);
    parameters = parametersWithIv.Parameters;
    if (parameters != null)
      this.cipher.Init(true, parameters);
    this.Reset();
  }

  public string AlgorithmName => this.cipher.AlgorithmName + "/KCTR";

  public bool IsPartialBlockOkay => true;

  public int GetBlockSize() => this.cipher.GetBlockSize();

  public byte ReturnByte(byte input) => this.CalculateByte(input);

  public void ProcessBytes(byte[] input, int inOff, int len, byte[] output, int outOff)
  {
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, len, "input buffer too small");
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, len, "output buffer too short");
    int num1 = inOff;
    int num2 = inOff + len;
    int num3 = outOff;
    while (num1 < num2)
      output[num3++] = this.CalculateByte(input[num1++]);
  }

  protected byte CalculateByte(byte b)
  {
    if (this.byteCount == 0)
    {
      this.incrementCounterAt(0);
      this.checkCounter();
      this.cipher.ProcessBlock(this.ofbV, 0, this.ofbOutV, 0);
      return (byte) ((uint) this.ofbOutV[this.byteCount++] ^ (uint) b);
    }
    int num = (int) (byte) ((uint) this.ofbOutV[this.byteCount++] ^ (uint) b);
    if (this.byteCount != this.ofbV.Length)
      return (byte) num;
    this.byteCount = 0;
    return (byte) num;
  }

  public int ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
  {
    int blockSize = this.GetBlockSize();
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, blockSize, "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, blockSize, "output buffer too short");
    this.ProcessBytes(input, inOff, blockSize, output, outOff);
    return blockSize;
  }

  public void Reset()
  {
    if (this.initialised)
      this.cipher.ProcessBlock(this.IV, 0, this.ofbV, 0);
    this.byteCount = 0;
  }

  private void incrementCounterAt(int pos)
  {
    int num = pos;
    do
      ;
    while (num < this.ofbV.Length && ++this.ofbV[num++] == (byte) 0);
  }

  private void checkCounter()
  {
  }
}
