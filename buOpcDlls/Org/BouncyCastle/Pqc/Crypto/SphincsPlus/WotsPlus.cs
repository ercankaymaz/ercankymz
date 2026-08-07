// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.SphincsPlus.WotsPlus
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.SphincsPlus;

internal class WotsPlus
{
  private SphincsPlusEngine engine;
  private uint w;

  internal WotsPlus(SphincsPlusEngine engine)
  {
    this.engine = engine;
    this.w = this.engine.WOTS_W;
  }

  internal void PKGen(byte[] skSeed, byte[] pkSeed, Adrs paramAdrs, byte[] output)
  {
    Adrs adrs1 = new Adrs(paramAdrs);
    byte[][] numArray1 = new byte[this.engine.WOTS_LEN][];
    byte[] numArray2 = new byte[this.engine.N];
    for (uint chainAddr = 0; (long) chainAddr < (long) this.engine.WOTS_LEN; ++chainAddr)
    {
      Adrs adrs2 = new Adrs(paramAdrs);
      adrs2.SetAdrsType(Adrs.WOTS_PRF);
      adrs2.SetKeyPairAddress(paramAdrs.GetKeyPairAddress());
      adrs2.SetChainAddress(chainAddr);
      adrs2.SetHashAddress(0U);
      this.engine.PRF(pkSeed, skSeed, adrs2, numArray2, 0);
      adrs2.SetAdrsType(Adrs.WOTS_HASH);
      adrs2.SetKeyPairAddress(paramAdrs.GetKeyPairAddress());
      adrs2.SetChainAddress(chainAddr);
      adrs2.SetHashAddress(0U);
      numArray1[(int) chainAddr] = this.Chain(numArray2, 0U, this.w - 1U, pkSeed, adrs2);
    }
    adrs1.SetAdrsType(Adrs.WOTS_PK);
    adrs1.SetKeyPairAddress(paramAdrs.GetKeyPairAddress());
    this.engine.T_l(pkSeed, adrs1, Arrays.ConcatenateAll(numArray1), output);
  }

  private byte[] Chain(byte[] X, uint i, uint s, byte[] pkSeed, Adrs adrs)
  {
    if (s == 0U)
      return Arrays.Clone(X);
    if (i + s > this.w - 1U)
      return (byte[]) null;
    byte[] m1 = X;
    for (uint index = 0; index < s; ++index)
    {
      adrs.SetHashAddress(i + index);
      m1 = this.engine.F(pkSeed, adrs, m1);
    }
    return m1;
  }

  internal byte[] Sign(byte[] M, byte[] skSeed, byte[] pkSeed, Adrs paramAdrs)
  {
    Adrs adrs = new Adrs(paramAdrs);
    uint[] output = new uint[this.engine.WOTS_LEN];
    this.BaseW(M, 0, this.w, output, 0, this.engine.WOTS_LEN1);
    uint n = 0;
    for (int index = 0; index < this.engine.WOTS_LEN1; ++index)
      n += this.w - 1U - output[index];
    if (this.engine.WOTS_LOGW % 8 != 0)
      n <<= 8 - this.engine.WOTS_LEN2 * this.engine.WOTS_LOGW % 8;
    int num = (this.engine.WOTS_LEN2 * this.engine.WOTS_LOGW + 7) / 8;
    this.BaseW(Pack.UInt32_To_BE(n), 4 - num, this.w, output, this.engine.WOTS_LEN1, this.engine.WOTS_LEN2);
    byte[][] numArray1 = new byte[this.engine.WOTS_LEN][];
    byte[] numArray2 = new byte[this.engine.N];
    for (int chainAddr = 0; chainAddr < this.engine.WOTS_LEN; ++chainAddr)
    {
      adrs.SetAdrsType(Adrs.WOTS_PRF);
      adrs.SetKeyPairAddress(paramAdrs.GetKeyPairAddress());
      adrs.SetChainAddress((uint) chainAddr);
      adrs.SetHashAddress(0U);
      this.engine.PRF(pkSeed, skSeed, adrs, numArray2, 0);
      adrs.SetAdrsType(Adrs.WOTS_HASH);
      adrs.SetKeyPairAddress(paramAdrs.GetKeyPairAddress());
      adrs.SetChainAddress((uint) chainAddr);
      adrs.SetHashAddress(0U);
      numArray1[chainAddr] = this.Chain(numArray2, 0U, output[chainAddr], pkSeed, adrs);
    }
    return Arrays.ConcatenateAll(numArray1);
  }

  internal void BaseW(byte[] X, int XOff, uint w, uint[] output, int outOff, int outLen)
  {
    int num1 = 0;
    int num2 = 0;
    for (int index = 0; index < outLen; ++index)
    {
      if (num2 == 0)
      {
        num1 = (int) X[XOff++];
        num2 += 8;
      }
      num2 -= this.engine.WOTS_LOGW;
      output[outOff++] = (uint) ((ulong) (num1 >> num2) & (ulong) (w - 1U));
    }
  }

  internal void PKFromSig(byte[] sig, byte[] M, byte[] pkSeed, Adrs adrs, byte[] output)
  {
    Adrs adrs1 = new Adrs(adrs);
    uint[] output1 = new uint[this.engine.WOTS_LEN];
    this.BaseW(M, 0, this.w, output1, 0, this.engine.WOTS_LEN1);
    uint num1 = 0;
    for (int index = 0; index < this.engine.WOTS_LEN1; ++index)
      num1 += this.w - 1U - output1[index];
    uint n = num1 << 8 - this.engine.WOTS_LEN2 * this.engine.WOTS_LOGW % 8;
    int num2 = (this.engine.WOTS_LEN2 * this.engine.WOTS_LOGW + 7) / 8;
    this.BaseW(Pack.UInt32_To_BE(n), 4 - num2, this.w, output1, this.engine.WOTS_LEN1, this.engine.WOTS_LEN2);
    byte[] numArray1 = new byte[this.engine.N];
    byte[][] numArray2 = new byte[this.engine.WOTS_LEN][];
    for (int chainAddr = 0; chainAddr < this.engine.WOTS_LEN; ++chainAddr)
    {
      adrs.SetChainAddress((uint) chainAddr);
      int sourceIndex = this.engine.N * chainAddr;
      Array.Copy((Array) sig, sourceIndex, (Array) numArray1, 0, this.engine.N);
      numArray2[chainAddr] = this.Chain(numArray1, output1[chainAddr], this.w - 1U - output1[chainAddr], pkSeed, adrs);
    }
    adrs1.SetAdrsType(Adrs.WOTS_PK);
    adrs1.SetKeyPairAddress(adrs.GetKeyPairAddress());
    this.engine.T_l(pkSeed, adrs1, Arrays.ConcatenateAll(numArray2), output);
  }
}
