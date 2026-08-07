// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.ChaCha7539Engine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class ChaCha7539Engine : Salsa20Engine
{
  public override string AlgorithmName => "ChaCha7539";

  protected override int NonceSize => 12;

  protected override void AdvanceCounter()
  {
    if (++this.engineState[12] == 0U)
      throw new InvalidOperationException("attempt to increase counter past 2^32.");
  }

  protected override void ResetCounter() => this.engineState[12] = 0U;

  protected override void SetKey(byte[] keyBytes, byte[] ivBytes)
  {
    if (keyBytes != null)
    {
      if (keyBytes.Length != 32 /*0x20*/)
        throw new ArgumentException(this.AlgorithmName + " requires 256 bit key");
      Salsa20Engine.PackTauOrSigma(keyBytes.Length, this.engineState, 0);
      Pack.LE_To_UInt32(keyBytes, 0, this.engineState, 4, 8);
    }
    Pack.LE_To_UInt32(ivBytes, 0, this.engineState, 13, 3);
  }

  protected override void GenerateKeyStream(byte[] output)
  {
    ChaChaEngine.ChachaCore(this.rounds, this.engineState, output);
  }

  internal void DoFinal(byte[] inBuf, int inOff, int inLen, byte[] outBuf, int outOff)
  {
    if (!this.initialised)
      throw new InvalidOperationException(this.AlgorithmName + " not initialised");
    if (this.index != 0)
      throw new InvalidOperationException(this.AlgorithmName + " not in block-aligned state");
    Org.BouncyCastle.Crypto.Check.DataLength(inBuf, inOff, inLen, "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(outBuf, outOff, inLen, "output buffer too short");
    while (inLen >= 128 /*0x80*/)
    {
      this.ProcessBlocks2(inBuf, inOff, outBuf, outOff);
      inOff += 128 /*0x80*/;
      inLen -= 128 /*0x80*/;
      outOff += 128 /*0x80*/;
    }
    if (inLen >= 64 /*0x40*/)
    {
      this.ImplProcessBlock(inBuf, inOff, outBuf, outOff);
      inOff += 64 /*0x40*/;
      inLen -= 64 /*0x40*/;
      outOff += 64 /*0x40*/;
    }
    if (inLen > 0)
    {
      this.GenerateKeyStream(this.keyStream);
      this.AdvanceCounter();
      for (int index = 0; index < inLen; ++index)
        outBuf[outOff + index] = (byte) ((uint) inBuf[index + inOff] ^ (uint) this.keyStream[index]);
    }
    this.engineState[12] = 0U;
  }

  internal void ProcessBlock(byte[] inBytes, int inOff, byte[] outBytes, int outOff)
  {
    if (!this.initialised)
      throw new InvalidOperationException(this.AlgorithmName + " not initialised");
    if (this.LimitExceeded(64U /*0x40*/))
      throw new MaxBytesExceededException("2^38 byte limit per IV would be exceeded; Change IV");
    this.ImplProcessBlock(inBytes, inOff, outBytes, outOff);
  }

  internal void ProcessBlocks2(byte[] inBytes, int inOff, byte[] outBytes, int outOff)
  {
    if (!this.initialised)
      throw new InvalidOperationException(this.AlgorithmName + " not initialised");
    if (this.LimitExceeded(128U /*0x80*/))
      throw new MaxBytesExceededException("2^38 byte limit per IV would be exceeded; Change IV");
    this.ImplProcessBlock(inBytes, inOff, outBytes, outOff);
    this.ImplProcessBlock(inBytes, inOff + 64 /*0x40*/, outBytes, outOff + 64 /*0x40*/);
  }

  internal void ImplProcessBlock(byte[] inBuf, int inOff, byte[] outBuf, int outOff)
  {
    ChaChaEngine.ChachaCore(this.rounds, this.engineState, this.keyStream);
    this.AdvanceCounter();
    for (int index = 0; index < 64 /*0x40*/; ++index)
      outBuf[outOff + index] = (byte) ((uint) this.keyStream[index] ^ (uint) inBuf[inOff + index]);
  }
}
