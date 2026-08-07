// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Cmce.CmceParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Cmce;

public sealed class CmceParameters : ICipherParameters
{
  private static readonly int[] poly3488 = new int[3]
  {
    3,
    1,
    0
  };
  private static readonly int[] poly4608 = new int[4]
  {
    10,
    9,
    6,
    0
  };
  private static readonly int[] poly6688 = new int[4]
  {
    7,
    2,
    1,
    0
  };
  private static readonly int[] poly6960 = new int[2]
  {
    8,
    0
  };
  private static readonly int[] poly8192 = new int[4]
  {
    7,
    2,
    1,
    0
  };
  public static readonly CmceParameters mceliece348864r3 = new CmceParameters("mceliece348864", 12, 3488, 64 /*0x40*/, CmceParameters.poly3488, false, 128 /*0x80*/);
  public static readonly CmceParameters mceliece348864fr3 = new CmceParameters("mceliece348864f", 12, 3488, 64 /*0x40*/, CmceParameters.poly3488, true, 128 /*0x80*/);
  public static readonly CmceParameters mceliece460896r3 = new CmceParameters("mceliece460896", 13, 4608, 96 /*0x60*/, CmceParameters.poly4608, false, 192 /*0xC0*/);
  public static readonly CmceParameters mceliece460896fr3 = new CmceParameters("mceliece460896f", 13, 4608, 96 /*0x60*/, CmceParameters.poly4608, true, 192 /*0xC0*/);
  public static readonly CmceParameters mceliece6688128r3 = new CmceParameters("mceliece6688128", 13, 6688, 128 /*0x80*/, CmceParameters.poly6688, false, 256 /*0x0100*/);
  public static readonly CmceParameters mceliece6688128fr3 = new CmceParameters("mceliece6688128f", 13, 6688, 128 /*0x80*/, CmceParameters.poly6688, true, 256 /*0x0100*/);
  public static readonly CmceParameters mceliece6960119r3 = new CmceParameters("mceliece6960119", 13, 6960, 119, CmceParameters.poly6960, false, 256 /*0x0100*/);
  public static readonly CmceParameters mceliece6960119fr3 = new CmceParameters("mceliece6960119f", 13, 6960, 119, CmceParameters.poly6960, true, 256 /*0x0100*/);
  public static readonly CmceParameters mceliece8192128r3 = new CmceParameters("mceliece8192128", 13, 8192 /*0x2000*/, 128 /*0x80*/, CmceParameters.poly8192, false, 256 /*0x0100*/);
  public static readonly CmceParameters mceliece8192128fr3 = new CmceParameters("mceliece8192128f", 13, 8192 /*0x2000*/, 128 /*0x80*/, CmceParameters.poly8192, true, 256 /*0x0100*/);
  private readonly string name;
  private readonly int m;
  private readonly int n;
  private readonly int t;
  private readonly bool usePivots;
  private readonly int defaultKeySize;
  private readonly ICmceEngine engine;

  private CmceParameters(
    string name,
    int m,
    int n,
    int t,
    int[] p,
    bool usePivots,
    int defaultKeySize)
  {
    this.name = name;
    this.m = m;
    this.n = n;
    this.t = t;
    this.usePivots = usePivots;
    this.defaultKeySize = defaultKeySize;
    if (m != 12)
    {
      if (m != 13)
        throw new ArgumentException();
      this.engine = (ICmceEngine) new CmceEngine<GF13>(m, n, t, p, usePivots, defaultKeySize);
    }
    else
      this.engine = (ICmceEngine) new CmceEngine<GF12>(m, n, t, p, usePivots, defaultKeySize);
  }

  public string Name => this.name;

  public int M => this.m;

  public int N => this.n;

  public int T => this.t;

  public int Mu => !this.usePivots ? 0 : 32 /*0x20*/;

  public int Nu => !this.usePivots ? 0 : 64 /*0x40*/;

  public int DefaultKeySize => this.defaultKeySize;

  internal ICmceEngine Engine => this.engine;
}
