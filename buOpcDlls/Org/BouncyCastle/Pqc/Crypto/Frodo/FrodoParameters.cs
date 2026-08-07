// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Frodo.FrodoParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Frodo;

public sealed class FrodoParameters : ICipherParameters
{
  private static short[] cdf_table640 = new short[13]
  {
    (short) 4643,
    (short) 13363,
    (short) 20579,
    (short) 25843,
    (short) 29227,
    (short) 31145,
    (short) 32103,
    (short) 32525,
    (short) 32689,
    (short) 32745,
    (short) 32762,
    (short) 32766,
    short.MaxValue
  };
  private static short[] cdf_table976 = new short[11]
  {
    (short) 5638,
    (short) 15915,
    (short) 23689,
    (short) 28571,
    (short) 31116,
    (short) 32217,
    (short) 32613,
    (short) 32731,
    (short) 32760,
    (short) 32766,
    short.MaxValue
  };
  private static short[] cdf_table1344 = new short[7]
  {
    (short) 9142,
    (short) 23462,
    (short) 30338,
    (short) 32361,
    (short) 32725,
    (short) 32765,
    short.MaxValue
  };
  public static FrodoParameters frodokem19888r3 = new FrodoParameters("frodokem19888", 640, 15, 2, FrodoParameters.cdf_table640, (IDigest) new ShakeDigest(128 /*0x80*/), (FrodoMatrixGenerator) new FrodoMatrixGenerator.Aes128MatrixGenerator(640, 32768 /*0x8000*/));
  public static FrodoParameters frodokem19888shaker3 = new FrodoParameters("frodokem19888shake", 640, 15, 2, FrodoParameters.cdf_table640, (IDigest) new ShakeDigest(128 /*0x80*/), (FrodoMatrixGenerator) new FrodoMatrixGenerator.Shake128MatrixGenerator(640, 32768 /*0x8000*/));
  public static FrodoParameters frodokem31296r3 = new FrodoParameters("frodokem31296", 976, 16 /*0x10*/, 3, FrodoParameters.cdf_table976, (IDigest) new ShakeDigest(256 /*0x0100*/), (FrodoMatrixGenerator) new FrodoMatrixGenerator.Aes128MatrixGenerator(976, 65536 /*0x010000*/));
  public static FrodoParameters frodokem31296shaker3 = new FrodoParameters("frodokem31296shake", 976, 16 /*0x10*/, 3, FrodoParameters.cdf_table976, (IDigest) new ShakeDigest(256 /*0x0100*/), (FrodoMatrixGenerator) new FrodoMatrixGenerator.Shake128MatrixGenerator(976, 65536 /*0x010000*/));
  public static FrodoParameters frodokem43088r3 = new FrodoParameters("frodokem43088", 1344, 16 /*0x10*/, 4, FrodoParameters.cdf_table1344, (IDigest) new ShakeDigest(256 /*0x0100*/), (FrodoMatrixGenerator) new FrodoMatrixGenerator.Aes128MatrixGenerator(1344, 65536 /*0x010000*/));
  public static FrodoParameters frodokem43088shaker3 = new FrodoParameters("frodokem43088shake", 1344, 16 /*0x10*/, 4, FrodoParameters.cdf_table1344, (IDigest) new ShakeDigest(256 /*0x0100*/), (FrodoMatrixGenerator) new FrodoMatrixGenerator.Shake128MatrixGenerator(1344, 65536 /*0x010000*/));
  private string name;
  private int n;
  private int d;
  private int b;
  private short[] cdf_table;
  private IDigest digest;
  private FrodoMatrixGenerator mGen;
  private int defaultKeySize;
  private FrodoEngine engine;

  private FrodoParameters(
    string name,
    int n,
    int d,
    int b,
    short[] cdf_table,
    IDigest digest,
    FrodoMatrixGenerator mGen)
  {
    this.name = name;
    this.n = n;
    this.d = d;
    this.b = b;
    this.cdf_table = cdf_table;
    this.digest = digest;
    this.mGen = mGen;
    this.defaultKeySize = this.B * FrodoEngine.nbar * FrodoEngine.nbar;
    this.engine = new FrodoEngine(n, d, b, cdf_table, digest, mGen);
  }

  public FrodoEngine Engine => this.engine;

  public int N => this.n;

  public string Name => this.name;

  public int D => this.d;

  public int B => this.b;

  public short[] CdfTable => this.cdf_table;

  public IDigest Digest => this.digest;

  public int DefaultKeySize => this.defaultKeySize;

  public FrodoMatrixGenerator MGen => this.mGen;
}
