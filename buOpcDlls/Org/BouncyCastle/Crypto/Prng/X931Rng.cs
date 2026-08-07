// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Prng.X931Rng
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Prng;

internal class X931Rng
{
  private const long BLOCK64_RESEED_MAX = 32768 /*0x8000*/;
  private const long BLOCK128_RESEED_MAX = 8388608 /*0x800000*/;
  private const int BLOCK64_MAX_BITS_REQUEST = 4096 /*0x1000*/;
  private const int BLOCK128_MAX_BITS_REQUEST = 262144 /*0x040000*/;
  private readonly IBlockCipher mEngine;
  private readonly IEntropySource mEntropySource;
  private readonly byte[] mDT;
  private readonly byte[] mI;
  private readonly byte[] mR;
  private byte[] mV;
  private long mReseedCounter = 1;

  internal X931Rng(IBlockCipher engine, byte[] dateTimeVector, IEntropySource entropySource)
  {
    this.mEngine = engine;
    this.mEntropySource = entropySource;
    this.mDT = new byte[engine.GetBlockSize()];
    Array.Copy((Array) dateTimeVector, 0, (Array) this.mDT, 0, this.mDT.Length);
    this.mI = new byte[engine.GetBlockSize()];
    this.mR = new byte[engine.GetBlockSize()];
  }

  internal int Generate(byte[] output, int outputOff, int outputLen, bool predictionResistant)
  {
    if (this.mR.Length == 8)
    {
      if (this.mReseedCounter > 32768L /*0x8000*/)
        return -1;
      if (outputLen > 512 /*0x0200*/)
        throw new ArgumentException("Number of bits per request limited to " + 4096 /*0x1000*/.ToString(), nameof (output));
    }
    else
    {
      if (this.mReseedCounter > 8388608L /*0x800000*/)
        return -1;
      if (outputLen > 32768 /*0x8000*/)
        throw new ArgumentException("Number of bits per request limited to " + 262144 /*0x040000*/.ToString(), nameof (output));
    }
    if (predictionResistant || this.mV == null)
    {
      this.mV = this.mEntropySource.GetEntropy();
      if (this.mV.Length != this.mEngine.GetBlockSize())
        throw new InvalidOperationException("Insufficient entropy returned");
    }
    int num = outputLen / this.mR.Length;
    for (int index = 0; index < num; ++index)
    {
      this.mEngine.ProcessBlock(this.mDT, 0, this.mI, 0);
      this.Process(this.mR, this.mI, this.mV);
      this.Process(this.mV, this.mR, this.mI);
      Array.Copy((Array) this.mR, 0, (Array) output, outputOff + index * this.mR.Length, this.mR.Length);
      this.Increment(this.mDT);
    }
    int length = outputLen - num * this.mR.Length;
    if (length > 0)
    {
      this.mEngine.ProcessBlock(this.mDT, 0, this.mI, 0);
      this.Process(this.mR, this.mI, this.mV);
      this.Process(this.mV, this.mR, this.mI);
      Array.Copy((Array) this.mR, 0, (Array) output, outputOff + num * this.mR.Length, length);
      this.Increment(this.mDT);
    }
    ++this.mReseedCounter;
    return outputLen * 8;
  }

  internal void Reseed()
  {
    this.mV = this.mEntropySource.GetEntropy();
    if (this.mV.Length != this.mEngine.GetBlockSize())
      throw new InvalidOperationException("Insufficient entropy returned");
    this.mReseedCounter = 1L;
  }

  internal IEntropySource EntropySource => this.mEntropySource;

  private void Process(byte[] res, byte[] a, byte[] b)
  {
    for (int index = 0; index != res.Length; ++index)
      res[index] = (byte) ((uint) a[index] ^ (uint) b[index]);
    this.mEngine.ProcessBlock(res, 0, res, 0);
  }

  private void Increment(byte[] val)
  {
    int index = val.Length - 1;
    while (index >= 0 && ++val[index] == (byte) 0)
      --index;
  }
}
