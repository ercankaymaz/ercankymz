// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Macs.Dstu7564Mac
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Macs;

public class Dstu7564Mac : IMac
{
  private Dstu7564Digest engine;
  private int macSize;
  private ulong inputLength;
  private byte[] paddedKey;
  private byte[] invertedKey;

  public string AlgorithmName => "DSTU7564Mac";

  public Dstu7564Mac(int macSizeBits)
  {
    this.engine = new Dstu7564Digest(macSizeBits);
    this.macSize = macSizeBits / 8;
  }

  public void Init(ICipherParameters parameters)
  {
    byte[] input = parameters is KeyParameter ? ((KeyParameter) parameters).GetKey() : throw new ArgumentException("Bad parameter passed");
    this.invertedKey = new byte[input.Length];
    this.paddedKey = this.PadKey(input);
    for (int index = 0; index < this.invertedKey.Length; ++index)
      this.invertedKey[index] = (byte) ((uint) input[index] ^ (uint) byte.MaxValue);
    this.engine.BlockUpdate(this.paddedKey, 0, this.paddedKey.Length);
  }

  public int GetMacSize() => this.macSize;

  public void BlockUpdate(byte[] input, int inOff, int len)
  {
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, len, "input buffer too short");
    if (this.paddedKey == null)
      throw new InvalidOperationException(this.AlgorithmName + " not initialised");
    this.engine.BlockUpdate(input, inOff, len);
    this.inputLength += (ulong) len;
  }

  public void Update(byte input)
  {
    this.engine.Update(input);
    ++this.inputLength;
  }

  public int DoFinal(byte[] output, int outOff)
  {
    if (this.paddedKey == null)
      throw new InvalidOperationException(this.AlgorithmName + " not initialised");
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, this.macSize, "output buffer too short");
    this.Pad();
    this.engine.BlockUpdate(this.invertedKey, 0, this.invertedKey.Length);
    this.inputLength = 0UL;
    return this.engine.DoFinal(output, outOff);
  }

  public void Reset()
  {
    this.inputLength = 0UL;
    this.engine.Reset();
    if (this.paddedKey == null)
      return;
    this.engine.BlockUpdate(this.paddedKey, 0, this.paddedKey.Length);
  }

  private void Pad()
  {
    int length = this.engine.GetByteLength() - (int) (this.inputLength % (ulong) this.engine.GetByteLength());
    if (length < 13)
      length += this.engine.GetByteLength();
    byte[] numArray = new byte[length];
    numArray[0] = (byte) 128 /*0x80*/;
    Pack.UInt64_To_LE(this.inputLength * 8UL, numArray, numArray.Length - 12);
    this.engine.BlockUpdate(numArray, 0, numArray.Length);
  }

  private byte[] PadKey(byte[] input)
  {
    int length = (input.Length + this.engine.GetByteLength() - 1) / this.engine.GetByteLength() * this.engine.GetByteLength();
    if (this.engine.GetByteLength() - input.Length % this.engine.GetByteLength() < 13)
      length += this.engine.GetByteLength();
    byte[] numArray = new byte[length];
    Array.Copy((Array) input, 0, (Array) numArray, 0, input.Length);
    numArray[input.Length] = (byte) 128 /*0x80*/;
    Pack.UInt32_To_LE((uint) (input.Length * 8), numArray, numArray.Length - 12);
    return numArray;
  }
}
