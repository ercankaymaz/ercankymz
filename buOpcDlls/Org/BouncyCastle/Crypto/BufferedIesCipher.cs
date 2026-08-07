// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.BufferedIesCipher
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Engines;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Crypto;

public class BufferedIesCipher : BufferedCipherBase
{
  private readonly IesEngine engine;
  private bool forEncryption;
  private MemoryStream buffer = new MemoryStream();

  public BufferedIesCipher(IesEngine engine)
  {
    this.engine = engine != null ? engine : throw new ArgumentNullException(nameof (engine));
  }

  public override string AlgorithmName => "IES";

  public override void Init(bool forEncryption, ICipherParameters parameters)
  {
    this.forEncryption = forEncryption;
    throw new NotImplementedException("IES");
  }

  public override int GetBlockSize() => 0;

  public override int GetOutputSize(int inputLen)
  {
    if (this.engine == null)
      throw new InvalidOperationException("cipher not initialised");
    int num = inputLen + Convert.ToInt32(this.buffer.Length);
    return !this.forEncryption ? num - 20 : num + 20;
  }

  public override int GetUpdateOutputSize(int inputLen) => 0;

  public override byte[] ProcessByte(byte input)
  {
    this.buffer.WriteByte(input);
    return (byte[]) null;
  }

  public override int ProcessByte(byte input, byte[] output, int outOff)
  {
    this.buffer.WriteByte(input);
    return 0;
  }

  public override byte[] ProcessBytes(byte[] input, int inOff, int length)
  {
    if (input == null)
      throw new ArgumentNullException(nameof (input));
    if (inOff < 0)
      throw new ArgumentException(nameof (inOff));
    if (length < 0)
      throw new ArgumentException(nameof (length));
    if (inOff + length > input.Length)
      throw new ArgumentException("invalid offset/length specified for input array");
    this.buffer.Write(input, inOff, length);
    return (byte[]) null;
  }

  public override byte[] DoFinal()
  {
    byte[] array = this.buffer.ToArray();
    this.Reset();
    return this.engine.ProcessBlock(array, 0, array.Length);
  }

  public override byte[] DoFinal(byte[] input, int inOff, int length)
  {
    this.ProcessBytes(input, inOff, length);
    return this.DoFinal();
  }

  public override void Reset() => this.buffer.SetLength(0L);
}
