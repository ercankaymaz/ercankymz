// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.BufferedCipherBase
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Crypto;

public abstract class BufferedCipherBase : IBufferedCipher
{
  protected static readonly byte[] EmptyBuffer = new byte[0];

  public abstract string AlgorithmName { get; }

  public abstract void Init(bool forEncryption, ICipherParameters parameters);

  public abstract int GetBlockSize();

  public abstract int GetOutputSize(int inputLen);

  public abstract int GetUpdateOutputSize(int inputLen);

  public abstract byte[] ProcessByte(byte input);

  public virtual int ProcessByte(byte input, byte[] output, int outOff)
  {
    byte[] numArray = this.ProcessByte(input);
    if (numArray == null)
      return 0;
    if (outOff + numArray.Length > output.Length)
      throw new DataLengthException("output buffer too short");
    numArray.CopyTo((Array) output, outOff);
    return numArray.Length;
  }

  public virtual byte[] ProcessBytes(byte[] input) => this.ProcessBytes(input, 0, input.Length);

  public abstract byte[] ProcessBytes(byte[] input, int inOff, int length);

  public virtual int ProcessBytes(byte[] input, byte[] output, int outOff)
  {
    return this.ProcessBytes(input, 0, input.Length, output, outOff);
  }

  public virtual int ProcessBytes(byte[] input, int inOff, int length, byte[] output, int outOff)
  {
    byte[] numArray = this.ProcessBytes(input, inOff, length);
    if (numArray == null)
      return 0;
    if (outOff + numArray.Length > output.Length)
      throw new DataLengthException("output buffer too short");
    numArray.CopyTo((Array) output, outOff);
    return numArray.Length;
  }

  public abstract byte[] DoFinal();

  public virtual byte[] DoFinal(byte[] input) => this.DoFinal(input, 0, input.Length);

  public abstract byte[] DoFinal(byte[] input, int inOff, int length);

  public virtual int DoFinal(byte[] output, int outOff)
  {
    byte[] numArray = this.DoFinal();
    if (outOff + numArray.Length > output.Length)
      throw new DataLengthException("output buffer too short");
    numArray.CopyTo((Array) output, outOff);
    return numArray.Length;
  }

  public virtual int DoFinal(byte[] input, byte[] output, int outOff)
  {
    return this.DoFinal(input, 0, input.Length, output, outOff);
  }

  public virtual int DoFinal(byte[] input, int inOff, int length, byte[] output, int outOff)
  {
    int num = this.ProcessBytes(input, inOff, length, output, outOff);
    return num + this.DoFinal(output, outOff + num);
  }

  public abstract void Reset();
}
