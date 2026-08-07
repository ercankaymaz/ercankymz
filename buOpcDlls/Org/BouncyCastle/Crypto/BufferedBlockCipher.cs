// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.BufferedBlockCipher
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto;

public class BufferedBlockCipher : BufferedCipherBase
{
  internal byte[] buf;
  internal int bufOff;
  internal bool forEncryption;
  internal IBlockCipherMode m_cipherMode;

  protected BufferedBlockCipher()
  {
  }

  public BufferedBlockCipher(IBlockCipher cipher)
    : this(EcbBlockCipher.GetBlockCipherMode(cipher))
  {
  }

  public BufferedBlockCipher(IBlockCipherMode cipherMode)
  {
    this.m_cipherMode = cipherMode != null ? cipherMode : throw new ArgumentNullException(nameof (cipherMode));
    this.buf = new byte[cipherMode.GetBlockSize()];
    this.bufOff = 0;
  }

  public override string AlgorithmName => this.m_cipherMode.AlgorithmName;

  public override void Init(bool forEncryption, ICipherParameters parameters)
  {
    this.forEncryption = forEncryption;
    if (parameters is ParametersWithRandom parametersWithRandom)
      parameters = parametersWithRandom.Parameters;
    this.Reset();
    this.m_cipherMode.Init(forEncryption, parameters);
  }

  public override int GetBlockSize() => this.m_cipherMode.GetBlockSize();

  public override int GetUpdateOutputSize(int length)
  {
    int num = length + this.bufOff;
    return num - num % this.buf.Length;
  }

  public override int GetOutputSize(int length) => length + this.bufOff;

  public override int ProcessByte(byte input, byte[] output, int outOff)
  {
    this.buf[this.bufOff++] = input;
    if (this.bufOff != this.buf.Length)
      return 0;
    if (outOff + this.buf.Length > output.Length)
      throw new DataLengthException("output buffer too short");
    this.bufOff = 0;
    return this.m_cipherMode.ProcessBlock(this.buf, 0, output, outOff);
  }

  public override byte[] ProcessByte(byte input)
  {
    int updateOutputSize = this.GetUpdateOutputSize(1);
    byte[] numArray = updateOutputSize > 0 ? new byte[updateOutputSize] : (byte[]) null;
    int length = this.ProcessByte(input, numArray, 0);
    if (updateOutputSize > 0 && length < updateOutputSize)
    {
      byte[] destinationArray = new byte[length];
      Array.Copy((Array) numArray, 0, (Array) destinationArray, 0, length);
      numArray = destinationArray;
    }
    return numArray;
  }

  public override byte[] ProcessBytes(byte[] input, int inOff, int length)
  {
    if (input == null)
      throw new ArgumentNullException(nameof (input));
    if (length < 1)
      return (byte[]) null;
    int updateOutputSize = this.GetUpdateOutputSize(length);
    byte[] numArray = updateOutputSize > 0 ? new byte[updateOutputSize] : (byte[]) null;
    int length1 = this.ProcessBytes(input, inOff, length, numArray, 0);
    if (updateOutputSize > 0 && length1 < updateOutputSize)
    {
      byte[] destinationArray = new byte[length1];
      Array.Copy((Array) numArray, 0, (Array) destinationArray, 0, length1);
      numArray = destinationArray;
    }
    return numArray;
  }

  public override int ProcessBytes(
    byte[] input,
    int inOff,
    int length,
    byte[] output,
    int outOff)
  {
    if (length < 1)
    {
      if (length < 0)
        throw new ArgumentException("Can't have a negative input length!");
      return 0;
    }
    int num1 = 0;
    int length1 = this.buf.Length;
    int length2 = length1 - this.bufOff;
    if (length >= length2)
    {
      Array.Copy((Array) input, inOff, (Array) this.buf, this.bufOff, length2);
      inOff += length2;
      length -= length2;
      int num2 = length1 + length;
      if (outOff > output.Length - num2)
        Check.OutputLength(output, outOff, num2 - num2 % length1, "output buffer too short");
      num1 = this.m_cipherMode.ProcessBlock(this.buf, 0, output, outOff);
      this.bufOff = 0;
      for (; length >= length1; length -= length1)
      {
        num1 += this.m_cipherMode.ProcessBlock(input, inOff, output, outOff + num1);
        inOff += length1;
      }
    }
    Array.Copy((Array) input, inOff, (Array) this.buf, this.bufOff, length);
    this.bufOff += length;
    return num1;
  }

  public override byte[] DoFinal()
  {
    byte[] numArray = BufferedCipherBase.EmptyBuffer;
    int outputSize = this.GetOutputSize(0);
    if (outputSize > 0)
    {
      numArray = new byte[outputSize];
      int length = this.DoFinal(numArray, 0);
      if (length < numArray.Length)
      {
        byte[] destinationArray = new byte[length];
        Array.Copy((Array) numArray, 0, (Array) destinationArray, 0, length);
        numArray = destinationArray;
      }
    }
    else
      this.Reset();
    return numArray;
  }

  public override byte[] DoFinal(byte[] input, int inOff, int inLen)
  {
    if (input == null)
      throw new ArgumentNullException(nameof (input));
    int outputSize = this.GetOutputSize(inLen);
    byte[] numArray = BufferedCipherBase.EmptyBuffer;
    if (outputSize > 0)
    {
      numArray = new byte[outputSize];
      int outOff = inLen > 0 ? this.ProcessBytes(input, inOff, inLen, numArray, 0) : 0;
      int length = outOff + this.DoFinal(numArray, outOff);
      if (length < numArray.Length)
      {
        byte[] destinationArray = new byte[length];
        Array.Copy((Array) numArray, 0, (Array) destinationArray, 0, length);
        numArray = destinationArray;
      }
    }
    else
      this.Reset();
    return numArray;
  }

  public override int DoFinal(byte[] output, int outOff)
  {
    try
    {
      if (this.bufOff != 0)
      {
        Check.DataLength(!this.m_cipherMode.IsPartialBlockOkay, "data not block size aligned");
        Check.OutputLength(output, outOff, this.bufOff, "output buffer too short for DoFinal()");
        this.m_cipherMode.ProcessBlock(this.buf, 0, this.buf, 0);
        Array.Copy((Array) this.buf, 0, (Array) output, outOff, this.bufOff);
      }
      return this.bufOff;
    }
    finally
    {
      this.Reset();
    }
  }

  public override void Reset()
  {
    Array.Clear((Array) this.buf, 0, this.buf.Length);
    this.bufOff = 0;
    this.m_cipherMode.Reset();
  }
}
