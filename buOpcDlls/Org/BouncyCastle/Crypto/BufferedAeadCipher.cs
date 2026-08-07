// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.BufferedAeadCipher
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto;

public class BufferedAeadCipher : BufferedCipherBase
{
  private readonly IAeadCipher cipher;

  public BufferedAeadCipher(IAeadCipher cipher)
  {
    this.cipher = cipher ?? throw new ArgumentNullException(nameof (cipher));
  }

  public override string AlgorithmName => this.cipher.AlgorithmName;

  public override void Init(bool forEncryption, ICipherParameters parameters)
  {
    if (parameters is ParametersWithRandom parametersWithRandom)
      parameters = parametersWithRandom.Parameters;
    this.cipher.Init(forEncryption, parameters);
  }

  public override int GetBlockSize() => 0;

  public override int GetUpdateOutputSize(int length) => this.cipher.GetUpdateOutputSize(length);

  public override int GetOutputSize(int length) => this.cipher.GetOutputSize(length);

  public override int ProcessByte(byte input, byte[] output, int outOff)
  {
    return this.cipher.ProcessByte(input, output, outOff);
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
    return this.cipher.ProcessBytes(input, inOff, length, output, outOff);
  }

  public override byte[] DoFinal()
  {
    byte[] numArray = new byte[this.GetOutputSize(0)];
    int length = this.DoFinal(numArray, 0);
    if (length < numArray.Length)
    {
      byte[] destinationArray = new byte[length];
      Array.Copy((Array) numArray, 0, (Array) destinationArray, 0, length);
      numArray = destinationArray;
    }
    return numArray;
  }

  public override byte[] DoFinal(byte[] input, int inOff, int inLen)
  {
    if (input == null)
      throw new ArgumentNullException(nameof (input));
    byte[] numArray = new byte[this.GetOutputSize(inLen)];
    int outOff = inLen > 0 ? this.ProcessBytes(input, inOff, inLen, numArray, 0) : 0;
    int length = outOff + this.DoFinal(numArray, outOff);
    if (length < numArray.Length)
    {
      byte[] destinationArray = new byte[length];
      Array.Copy((Array) numArray, 0, (Array) destinationArray, 0, length);
      numArray = destinationArray;
    }
    return numArray;
  }

  public override int DoFinal(byte[] output, int outOff) => this.cipher.DoFinal(output, outOff);

  public override void Reset() => this.cipher.Reset();
}
