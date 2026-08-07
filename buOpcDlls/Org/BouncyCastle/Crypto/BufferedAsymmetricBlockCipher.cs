// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.BufferedAsymmetricBlockCipher
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Crypto;

public class BufferedAsymmetricBlockCipher : BufferedCipherBase
{
  private readonly IAsymmetricBlockCipher cipher;
  private byte[] buffer;
  private int bufOff;

  public BufferedAsymmetricBlockCipher(IAsymmetricBlockCipher cipher) => this.cipher = cipher;

  internal int GetBufferPosition() => this.bufOff;

  public override string AlgorithmName => this.cipher.AlgorithmName;

  public override int GetBlockSize() => this.cipher.GetInputBlockSize();

  public override int GetOutputSize(int length) => this.cipher.GetOutputBlockSize();

  public override int GetUpdateOutputSize(int length) => 0;

  public override void Init(bool forEncryption, ICipherParameters parameters)
  {
    this.Reset();
    this.cipher.Init(forEncryption, parameters);
    this.buffer = new byte[this.cipher.GetInputBlockSize() + (forEncryption ? 1 : 0)];
    this.bufOff = 0;
  }

  public override byte[] ProcessByte(byte input)
  {
    if (this.bufOff >= this.buffer.Length)
      throw new DataLengthException("attempt to process message too long for cipher");
    this.buffer[this.bufOff++] = input;
    return (byte[]) null;
  }

  public override int ProcessByte(byte input, byte[] output, int outOff)
  {
    if (this.bufOff >= this.buffer.Length)
      throw new DataLengthException("attempt to process message too long for cipher");
    this.buffer[this.bufOff++] = input;
    return 0;
  }

  public override byte[] ProcessBytes(byte[] input, int inOff, int length)
  {
    if (length < 1)
      return (byte[]) null;
    if (input == null)
      throw new ArgumentNullException(nameof (input));
    if (this.bufOff + length > this.buffer.Length)
      throw new DataLengthException("attempt to process message too long for cipher");
    Array.Copy((Array) input, inOff, (Array) this.buffer, this.bufOff, length);
    this.bufOff += length;
    return (byte[]) null;
  }

  public override byte[] DoFinal()
  {
    byte[] numArray = this.bufOff > 0 ? this.cipher.ProcessBlock(this.buffer, 0, this.bufOff) : BufferedCipherBase.EmptyBuffer;
    this.Reset();
    return numArray;
  }

  public override byte[] DoFinal(byte[] input, int inOff, int length)
  {
    this.ProcessBytes(input, inOff, length);
    return this.DoFinal();
  }

  public override void Reset()
  {
    if (this.buffer == null)
      return;
    Array.Clear((Array) this.buffer, 0, this.buffer.Length);
    this.bufOff = 0;
  }
}
