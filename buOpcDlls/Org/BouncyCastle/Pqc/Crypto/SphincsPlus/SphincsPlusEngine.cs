// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.SphincsPlus.SphincsPlusEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.SphincsPlus;

internal abstract class SphincsPlusEngine
{
  internal bool robust;
  internal int N;
  internal uint WOTS_W;
  internal int WOTS_LOGW;
  internal int WOTS_LEN;
  internal int WOTS_LEN1;
  internal int WOTS_LEN2;
  internal uint D;
  internal int A;
  internal int K;
  internal uint FH;
  internal uint H_PRIME;
  internal uint T;

  internal SphincsPlusEngine(bool robust, int n, uint w, uint d, int a, int k, uint h)
  {
    this.N = n;
    if (w == 16U /*0x10*/)
    {
      this.WOTS_LOGW = 4;
      this.WOTS_LEN1 = 8 * this.N / this.WOTS_LOGW;
      if (this.N <= 8)
        this.WOTS_LEN2 = 2;
      else if (this.N <= 136)
      {
        this.WOTS_LEN2 = 3;
      }
      else
      {
        if (this.N > 256 /*0x0100*/)
          throw new ArgumentException("cannot precompute SPX_WOTS_LEN2 for n outside {2, .., 256}");
        this.WOTS_LEN2 = 4;
      }
    }
    else
    {
      if (w != 256U /*0x0100*/)
        throw new ArgumentException("wots_w assumed 16 or 256");
      this.WOTS_LOGW = 8;
      this.WOTS_LEN1 = 8 * this.N / this.WOTS_LOGW;
      if (this.N <= 1)
      {
        this.WOTS_LEN2 = 1;
      }
      else
      {
        if (this.N > 256 /*0x0100*/)
          throw new ArgumentException("cannot precompute SPX_WOTS_LEN2 for n outside {2, .., 256}");
        this.WOTS_LEN2 = 2;
      }
    }
    this.WOTS_W = w;
    this.WOTS_LEN = this.WOTS_LEN1 + this.WOTS_LEN2;
    this.robust = robust;
    this.D = d;
    this.A = a;
    this.K = k;
    this.FH = h;
    this.H_PRIME = h / d;
    this.T = (uint) (1 << a);
  }

  public abstract void Init(byte[] pkSeed);

  public abstract byte[] F(byte[] pkSeed, Adrs adrs, byte[] m1);

  public abstract void H(byte[] pkSeed, Adrs adrs, byte[] m1, byte[] m2, byte[] output);

  public abstract IndexedDigest H_msg(byte[] prf, byte[] pkSeed, byte[] pkRoot, byte[] message);

  public abstract void T_l(byte[] pkSeed, Adrs adrs, byte[] m, byte[] output);

  public abstract void PRF(byte[] pkSeed, byte[] skSeed, Adrs adrs, byte[] prf, int prfOff);

  public abstract byte[] PRF_msg(byte[] prf, byte[] randomiser, byte[] message);

  internal class Sha2Engine : SphincsPlusEngine
  {
    private HMac treeHMac;
    private Mgf1BytesGenerator mgf1;
    private byte[] hmacBuf;
    private IDigest msgDigest;
    private byte[] msgDigestBuf;
    private int bl;
    private IDigest sha256;
    private byte[] sha256Buf;
    private IMemoable msgMemo;
    private IMemoable sha256Memo;

    public Sha2Engine(bool robust, int n, uint w, uint d, int a, int k, uint h)
      : base(robust, n, w, d, a, k, h)
    {
      this.sha256 = (IDigest) new Sha256Digest();
      this.sha256Buf = new byte[this.sha256.GetDigestSize()];
      if (n == 16 /*0x10*/)
      {
        this.msgDigest = (IDigest) new Sha256Digest();
        this.treeHMac = new HMac((IDigest) new Sha256Digest());
        this.mgf1 = new Mgf1BytesGenerator((IDigest) new Sha256Digest());
        this.bl = 64 /*0x40*/;
      }
      else
      {
        this.msgDigest = (IDigest) new Sha512Digest();
        this.treeHMac = new HMac((IDigest) new Sha512Digest());
        this.mgf1 = new Mgf1BytesGenerator((IDigest) new Sha512Digest());
        this.bl = 128 /*0x80*/;
      }
      this.hmacBuf = new byte[this.treeHMac.GetMacSize()];
      this.msgDigestBuf = new byte[this.msgDigest.GetDigestSize()];
    }

    public override void Init(byte[] pkSeed)
    {
      byte[] input = new byte[this.bl];
      this.msgDigest.BlockUpdate(pkSeed, 0, pkSeed.Length);
      this.msgDigest.BlockUpdate(input, 0, this.bl - this.N);
      this.msgMemo = ((IMemoable) this.msgDigest).Copy();
      this.msgDigest.Reset();
      this.sha256.BlockUpdate(pkSeed, 0, pkSeed.Length);
      this.sha256.BlockUpdate(input, 0, 64 /*0x40*/ - this.N);
      this.sha256Memo = ((IMemoable) this.sha256).Copy();
      this.sha256.Reset();
    }

    public override byte[] F(byte[] pkSeed, Adrs adrs, byte[] m1)
    {
      byte[] numArray = this.CompressedAdrs(adrs);
      if (this.robust)
        m1 = this.Bitmask256(Arrays.Concatenate(pkSeed, numArray), m1);
      ((IMemoable) this.sha256).Reset(this.sha256Memo);
      this.sha256.BlockUpdate(numArray, 0, numArray.Length);
      this.sha256.BlockUpdate(m1, 0, m1.Length);
      this.sha256.DoFinal(this.sha256Buf, 0);
      return Arrays.CopyOfRange(this.sha256Buf, 0, this.N);
    }

    public override void H(byte[] pkSeed, Adrs adrs, byte[] m1, byte[] m2, byte[] output)
    {
      byte[] numArray = this.CompressedAdrs(adrs);
      ((IMemoable) this.msgDigest).Reset(this.msgMemo);
      this.msgDigest.BlockUpdate(numArray, 0, numArray.Length);
      if (this.robust)
      {
        byte[] input = this.Bitmask(Arrays.Concatenate(pkSeed, numArray), m1, m2);
        this.msgDigest.BlockUpdate(input, 0, input.Length);
      }
      else
      {
        this.msgDigest.BlockUpdate(m1, 0, m1.Length);
        this.msgDigest.BlockUpdate(m2, 0, m2.Length);
      }
      this.msgDigest.DoFinal(this.msgDigestBuf, 0);
      Array.Copy((Array) this.msgDigestBuf, 0, (Array) output, 0, this.N);
    }

    public override IndexedDigest H_msg(byte[] prf, byte[] pkSeed, byte[] pkRoot, byte[] message)
    {
      int num1 = (this.A * this.K + 7) / 8;
      uint num2 = this.FH / this.D;
      uint num3 = this.FH - num2;
      uint len1 = (num2 + 7U) / 8U;
      uint len2 = (num3 + 7U) / 8U;
      int length = num1 + (int) len2 + (int) len1;
      byte[] output = new byte[this.msgDigest.GetDigestSize()];
      this.msgDigest.BlockUpdate(prf, 0, prf.Length);
      this.msgDigest.BlockUpdate(pkSeed, 0, pkSeed.Length);
      this.msgDigest.BlockUpdate(pkRoot, 0, pkRoot.Length);
      this.msgDigest.BlockUpdate(message, 0, message.Length);
      this.msgDigest.DoFinal(output, 0);
      byte[] m = new byte[length];
      byte[] numArray = this.Bitmask(Arrays.ConcatenateAll(prf, pkSeed, output), m);
      return new IndexedDigest(Pack.BE_To_UInt64_Low(numArray, num1, (int) len2) & ulong.MaxValue >> 64 /*0x40*/ - (int) num3, Pack.BE_To_UInt32_Low(numArray, num1 + (int) len2, (int) len1) & uint.MaxValue >> 32 /*0x20*/ - (int) num2, Arrays.CopyOfRange(numArray, 0, num1));
    }

    public override void T_l(byte[] pkSeed, Adrs adrs, byte[] m, byte[] output)
    {
      byte[] numArray = this.CompressedAdrs(adrs);
      if (this.robust)
        m = this.Bitmask(Arrays.Concatenate(pkSeed, numArray), m);
      ((IMemoable) this.msgDigest).Reset(this.msgMemo);
      this.msgDigest.BlockUpdate(numArray, 0, numArray.Length);
      this.msgDigest.BlockUpdate(m, 0, m.Length);
      this.msgDigest.DoFinal(this.msgDigestBuf, 0);
      Array.Copy((Array) this.msgDigestBuf, 0, (Array) output, 0, this.N);
    }

    public override void PRF(byte[] pkSeed, byte[] skSeed, Adrs adrs, byte[] prf, int prfOff)
    {
      int length = skSeed.Length;
      ((IMemoable) this.sha256).Reset(this.sha256Memo);
      byte[] input = this.CompressedAdrs(adrs);
      this.sha256.BlockUpdate(input, 0, input.Length);
      this.sha256.BlockUpdate(skSeed, 0, skSeed.Length);
      this.sha256.DoFinal(this.sha256Buf, 0);
      Array.Copy((Array) this.sha256Buf, 0, (Array) prf, prfOff, length);
    }

    public override byte[] PRF_msg(byte[] prf, byte[] randomiser, byte[] message)
    {
      this.treeHMac.Init((ICipherParameters) new KeyParameter(prf));
      this.treeHMac.BlockUpdate(randomiser, 0, randomiser.Length);
      this.treeHMac.BlockUpdate(message, 0, message.Length);
      this.treeHMac.DoFinal(this.hmacBuf, 0);
      return Arrays.CopyOfRange(this.hmacBuf, 0, this.N);
    }

    private byte[] CompressedAdrs(Adrs adrs)
    {
      byte[] destinationArray = new byte[22];
      Array.Copy((Array) adrs.value, Adrs.OFFSET_LAYER + 3, (Array) destinationArray, 0, 1);
      Array.Copy((Array) adrs.value, Adrs.OFFSET_TREE + 4, (Array) destinationArray, 1, 8);
      Array.Copy((Array) adrs.value, Adrs.OFFSET_TYPE + 3, (Array) destinationArray, 9, 1);
      Array.Copy((Array) adrs.value, 20, (Array) destinationArray, 10, 12);
      return destinationArray;
    }

    protected byte[] Bitmask(byte[] key, byte[] m)
    {
      byte[] numArray = new byte[m.Length];
      this.mgf1.Init((IDerivationParameters) new MgfParameters(key));
      this.mgf1.GenerateBytes(numArray, 0, numArray.Length);
      Bytes.XorTo(m.Length, m, numArray);
      return numArray;
    }

    protected byte[] Bitmask(byte[] key, byte[] m1, byte[] m2)
    {
      byte[] numArray = new byte[m1.Length + m2.Length];
      this.mgf1.Init((IDerivationParameters) new MgfParameters(key));
      this.mgf1.GenerateBytes(numArray, 0, numArray.Length);
      Bytes.XorTo(m1.Length, m1, numArray);
      Bytes.XorTo(m2.Length, m2, 0, numArray, m1.Length);
      return numArray;
    }

    protected byte[] Bitmask256(byte[] key, byte[] m)
    {
      byte[] numArray = new byte[m.Length];
      Mgf1BytesGenerator mgf1BytesGenerator = new Mgf1BytesGenerator((IDigest) new Sha256Digest());
      mgf1BytesGenerator.Init((IDerivationParameters) new MgfParameters(key));
      mgf1BytesGenerator.GenerateBytes(numArray, 0, numArray.Length);
      Bytes.XorTo(m.Length, m, numArray);
      return numArray;
    }
  }

  internal class Shake256Engine : SphincsPlusEngine
  {
    private IXof treeDigest;
    private IXof maskDigest;

    public Shake256Engine(bool robust, int n, uint w, uint d, int a, int k, uint h)
      : base(robust, n, w, d, a, k, h)
    {
      this.treeDigest = (IXof) new ShakeDigest(256 /*0x0100*/);
      this.maskDigest = (IXof) new ShakeDigest(256 /*0x0100*/);
    }

    public override void Init(byte[] pkSeed)
    {
    }

    public override byte[] F(byte[] pkSeed, Adrs adrs, byte[] m1)
    {
      byte[] input = m1;
      if (this.robust)
        input = this.Bitmask(pkSeed, adrs, m1);
      byte[] output = new byte[this.N];
      this.treeDigest.BlockUpdate(pkSeed, 0, pkSeed.Length);
      this.treeDigest.BlockUpdate(adrs.value, 0, adrs.value.Length);
      this.treeDigest.BlockUpdate(input, 0, input.Length);
      this.treeDigest.OutputFinal(output, 0, output.Length);
      return output;
    }

    public override void H(byte[] pkSeed, Adrs adrs, byte[] m1, byte[] m2, byte[] output)
    {
      this.treeDigest.BlockUpdate(pkSeed, 0, pkSeed.Length);
      this.treeDigest.BlockUpdate(adrs.value, 0, adrs.value.Length);
      if (this.robust)
      {
        byte[] input = this.Bitmask(pkSeed, adrs, m1, m2);
        this.treeDigest.BlockUpdate(input, 0, input.Length);
      }
      else
      {
        this.treeDigest.BlockUpdate(m1, 0, m1.Length);
        this.treeDigest.BlockUpdate(m2, 0, m2.Length);
      }
      this.treeDigest.OutputFinal(output, 0, this.N);
    }

    public override IndexedDigest H_msg(byte[] R, byte[] pkSeed, byte[] pkRoot, byte[] message)
    {
      int num1 = (this.A * this.K + 7) / 8;
      uint num2 = this.FH / this.D;
      uint num3 = this.FH - num2;
      uint len1 = (num2 + 7U) / 8U;
      uint len2 = (num3 + 7U) / 8U;
      byte[] numArray = new byte[(int) (uint) ((ulong) num1 + (ulong) len2 + (ulong) len1)];
      this.treeDigest.BlockUpdate(R, 0, R.Length);
      this.treeDigest.BlockUpdate(pkSeed, 0, pkSeed.Length);
      this.treeDigest.BlockUpdate(pkRoot, 0, pkRoot.Length);
      this.treeDigest.BlockUpdate(message, 0, message.Length);
      this.treeDigest.OutputFinal(numArray, 0, numArray.Length);
      return new IndexedDigest(Pack.BE_To_UInt64_Low(numArray, num1, (int) len2) & ulong.MaxValue >> 64 /*0x40*/ - (int) num3, Pack.BE_To_UInt32_Low(numArray, num1 + (int) len2, (int) len1) & uint.MaxValue >> 32 /*0x20*/ - (int) num2, Arrays.CopyOfRange(numArray, 0, num1));
    }

    public override void T_l(byte[] pkSeed, Adrs adrs, byte[] m, byte[] output)
    {
      byte[] input = m;
      if (this.robust)
        input = this.Bitmask(pkSeed, adrs, m);
      this.treeDigest.BlockUpdate(pkSeed, 0, pkSeed.Length);
      this.treeDigest.BlockUpdate(adrs.value, 0, adrs.value.Length);
      this.treeDigest.BlockUpdate(input, 0, input.Length);
      this.treeDigest.OutputFinal(output, 0, this.N);
    }

    public override void PRF(byte[] pkSeed, byte[] skSeed, Adrs adrs, byte[] prf, int prfOff)
    {
      this.treeDigest.BlockUpdate(pkSeed, 0, pkSeed.Length);
      this.treeDigest.BlockUpdate(adrs.value, 0, adrs.value.Length);
      this.treeDigest.BlockUpdate(skSeed, 0, skSeed.Length);
      this.treeDigest.OutputFinal(prf, prfOff, this.N);
    }

    public override byte[] PRF_msg(byte[] prf, byte[] randomiser, byte[] message)
    {
      this.treeDigest.BlockUpdate(prf, 0, prf.Length);
      this.treeDigest.BlockUpdate(randomiser, 0, randomiser.Length);
      this.treeDigest.BlockUpdate(message, 0, message.Length);
      byte[] output = new byte[this.N];
      this.treeDigest.OutputFinal(output, 0, output.Length);
      return output;
    }

    protected byte[] Bitmask(byte[] pkSeed, Adrs adrs, byte[] m)
    {
      byte[] numArray = new byte[m.Length];
      this.maskDigest.BlockUpdate(pkSeed, 0, pkSeed.Length);
      this.maskDigest.BlockUpdate(adrs.value, 0, adrs.value.Length);
      this.maskDigest.OutputFinal(numArray, 0, numArray.Length);
      Bytes.XorTo(m.Length, m, numArray);
      return numArray;
    }

    protected byte[] Bitmask(byte[] pkSeed, Adrs adrs, byte[] m1, byte[] m2)
    {
      byte[] numArray = new byte[m1.Length + m2.Length];
      this.maskDigest.BlockUpdate(pkSeed, 0, pkSeed.Length);
      this.maskDigest.BlockUpdate(adrs.value, 0, adrs.value.Length);
      this.maskDigest.OutputFinal(numArray, 0, numArray.Length);
      Bytes.XorTo(m1.Length, m1, numArray);
      Bytes.XorTo(m2.Length, m2, 0, numArray, m1.Length);
      return numArray;
    }
  }

  internal class HarakaSEngine(bool robust, int n, uint w, uint d, int a, int k, uint h) : 
    SphincsPlusEngine(robust, n, w, d, a, k, h)
  {
    public HarakaSXof harakaSXof;
    public HarakaS256Digest harakaS256Digest;
    public HarakaS512Digest harakaS512Digest;

    public override void Init(byte[] pkSeed)
    {
      this.harakaSXof = new HarakaSXof(pkSeed);
      this.harakaS256Digest = new HarakaS256Digest(this.harakaSXof);
      this.harakaS512Digest = new HarakaS512Digest((HarakaSBase) this.harakaSXof);
    }

    public override byte[] F(byte[] pkSeed, Adrs adrs, byte[] m1)
    {
      byte[] numArray = new byte[32 /*0x20*/];
      this.harakaS512Digest.BlockUpdate(adrs.value, 0, adrs.value.Length);
      if (this.robust)
      {
        this.harakaS256Digest.BlockUpdate(adrs.value, 0, adrs.value.Length);
        this.harakaS256Digest.DoFinal(numArray, 0);
        Bytes.XorTo(m1.Length, m1, numArray);
        this.harakaS512Digest.BlockUpdate(numArray, 0, m1.Length);
      }
      else
        this.harakaS512Digest.BlockUpdate(m1, 0, m1.Length);
      this.harakaS512Digest.DoFinal(numArray, 0);
      return this.N != 32 /*0x20*/ ? Arrays.CopyOfRange(numArray, 0, this.N) : numArray;
    }

    public override void H(byte[] pkSeed, Adrs adrs, byte[] m1, byte[] m2, byte[] output)
    {
      byte[] numArray = new byte[m1.Length + m2.Length];
      Array.Copy((Array) m1, 0, (Array) numArray, 0, m1.Length);
      Array.Copy((Array) m2, 0, (Array) numArray, m1.Length, m2.Length);
      if (this.robust)
        this.Bitmask(adrs, numArray);
      this.harakaSXof.BlockUpdate(adrs.value, 0, adrs.value.Length);
      this.harakaSXof.BlockUpdate(numArray, 0, numArray.Length);
      this.harakaSXof.OutputFinal(output, 0, this.N);
    }

    public override IndexedDigest H_msg(byte[] prf, byte[] pkSeed, byte[] pkRoot, byte[] message)
    {
      int num1 = this.A * this.K + 7 >> 3;
      uint num2 = this.FH / this.D;
      uint num3 = this.FH - num2;
      uint len1 = num2 + 7U >> 3;
      uint len2 = num3 + 7U >> 3;
      byte[] numArray = new byte[(long) num1 + (long) len2 + (long) len1];
      this.harakaSXof.BlockUpdate(prf, 0, prf.Length);
      this.harakaSXof.BlockUpdate(pkRoot, 0, pkRoot.Length);
      this.harakaSXof.BlockUpdate(message, 0, message.Length);
      this.harakaSXof.OutputFinal(numArray, 0, numArray.Length);
      return new IndexedDigest(Pack.BE_To_UInt64_Low(numArray, num1, (int) len2) & ulong.MaxValue >> 64 /*0x40*/ - (int) num3, Pack.BE_To_UInt32_Low(numArray, num1 + (int) len2, (int) len1) & uint.MaxValue >> 32 /*0x20*/ - (int) num2, Arrays.CopyOfRange(numArray, 0, num1));
    }

    public override void T_l(byte[] pkSeed, Adrs adrs, byte[] m, byte[] output)
    {
      if (this.robust)
        this.Bitmask(adrs, m);
      this.harakaSXof.BlockUpdate(adrs.value, 0, adrs.value.Length);
      this.harakaSXof.BlockUpdate(m, 0, m.Length);
      this.harakaSXof.OutputFinal(output, 0, this.N);
    }

    public override void PRF(byte[] pkSeed, byte[] skSeed, Adrs adrs, byte[] prf, int prfOff)
    {
      byte[] numArray = new byte[32 /*0x20*/];
      this.harakaS512Digest.BlockUpdate(adrs.value, 0, adrs.value.Length);
      this.harakaS512Digest.BlockUpdate(skSeed, 0, skSeed.Length);
      this.harakaS512Digest.DoFinal(numArray, 0);
      Array.Copy((Array) numArray, 0, (Array) prf, prfOff, this.N);
    }

    public override byte[] PRF_msg(byte[] prf, byte[] randomiser, byte[] message)
    {
      byte[] output = new byte[this.N];
      this.harakaSXof.BlockUpdate(prf, 0, prf.Length);
      this.harakaSXof.BlockUpdate(randomiser, 0, randomiser.Length);
      this.harakaSXof.BlockUpdate(message, 0, message.Length);
      this.harakaSXof.OutputFinal(output, 0, output.Length);
      return output;
    }

    protected void Bitmask(Adrs adrs, byte[] m)
    {
      byte[] numArray = new byte[m.Length];
      this.harakaSXof.BlockUpdate(adrs.value, 0, adrs.value.Length);
      this.harakaSXof.OutputFinal(numArray, 0, numArray.Length);
      Bytes.XorTo(m.Length, numArray, m);
    }
  }
}
