// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.BufferedStreamCipher
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto;

public class BufferedStreamCipher : BufferedCipherBase
{
  private readonly IStreamCipher m_cipher;

  public BufferedStreamCipher(IStreamCipher cipher)
  {
    this.m_cipher = cipher ?? throw new ArgumentNullException(nameof (cipher));
  }

  public override string AlgorithmName => this.m_cipher.AlgorithmName;

  public override void Init(bool forEncryption, ICipherParameters parameters)
  {
    if (parameters is ParametersWithRandom parametersWithRandom)
      parameters = parametersWithRandom.Parameters;
    this.m_cipher.Init(forEncryption, parameters);
  }

  public override int GetBlockSize() => 0;

  public override int GetOutputSize(int inputLen) => inputLen;

  public override int GetUpdateOutputSize(int inputLen) => inputLen;

  public override byte[] ProcessByte(byte input)
  {
    return new byte[1]{ this.m_cipher.ReturnByte(input) };
  }

  public override int ProcessByte(byte input, byte[] output, int outOff)
  {
    if (outOff >= output.Length)
      throw new DataLengthException("output buffer too short");
    output[outOff] = this.m_cipher.ReturnByte(input);
    return 1;
  }

  public override byte[] ProcessBytes(byte[] input, int inOff, int length)
  {
    if (length < 1)
      return (byte[]) null;
    byte[] output = new byte[length];
    this.m_cipher.ProcessBytes(input, inOff, length, output, 0);
    return output;
  }

  public override int ProcessBytes(
    byte[] input,
    int inOff,
    int length,
    byte[] output,
    int outOff)
  {
    if (length < 1)
      return 0;
    this.m_cipher.ProcessBytes(input, inOff, length, output, outOff);
    return length;
  }

  public override byte[] DoFinal()
  {
    this.m_cipher.Reset();
    return BufferedCipherBase.EmptyBuffer;
  }

  public override byte[] DoFinal(byte[] input, int inOff, int length)
  {
    if (length < 1)
      return BufferedCipherBase.EmptyBuffer;
    byte[] output = new byte[length];
    this.m_cipher.ProcessBytes(input, inOff, length, output, 0);
    this.m_cipher.Reset();
    return output;
  }

  public override void Reset() => this.m_cipher.Reset();
}
