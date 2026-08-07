// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Hqc.HqcParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Hqc;

public sealed class HqcParameters : ICipherParameters
{
  public static HqcParameters hqc128 = new HqcParameters(nameof (hqc128), 17669, 46, 384, 16 /*0x10*/, 31 /*0x1F*/, 15, 66, 75, 75, 16767881, 4, new int[31 /*0x1F*/]
  {
    89,
    69,
    153,
    116,
    176 /*0xB0*/,
    117,
    111,
    75,
    73,
    233,
    242,
    233,
    65,
    210,
    21,
    139,
    103,
    173,
    67,
    118,
    105,
    210,
    174,
    110,
    74,
    69,
    228,
    82,
    (int) byte.MaxValue,
    181,
    1
  }, 128 /*0x80*/);
  public static HqcParameters hqc192 = new HqcParameters(nameof (hqc192), 35851, 56, 640, 24, 33, 16 /*0x10*/, 100, 114, 114, 16742417, 5, new int[33]
  {
    45,
    216,
    239,
    24,
    253,
    104,
    27,
    40,
    107,
    50,
    163,
    210,
    227,
    134,
    224 /*0xE0*/,
    158,
    119,
    13,
    158,
    1,
    238,
    164,
    82,
    43,
    15,
    232,
    246,
    142,
    50,
    189,
    29,
    232,
    1
  }, 192 /*0xC0*/);
  public static HqcParameters hqc256 = new HqcParameters(nameof (hqc256), 57637, 90, 640, 32 /*0x20*/, 59, 29, 131, 149, 149, 16772367, 5, new int[59]
  {
    49,
    167,
    49,
    39,
    200,
    121,
    124,
    91,
    240 /*0xF0*/,
    63 /*0x3F*/,
    148,
    71,
    150,
    123,
    87,
    101,
    32 /*0x20*/,
    215,
    159,
    71,
    201,
    115,
    97,
    210,
    186,
    183,
    141,
    217,
    123,
    12,
    31 /*0x1F*/,
    243,
    180,
    219,
    152,
    239,
    99,
    141,
    4,
    246,
    191,
    144 /*0x90*/,
    8,
    232,
    47,
    27,
    141,
    178,
    130,
    64 /*0x40*/,
    124,
    47,
    39,
    188,
    216,
    48 /*0x30*/,
    199,
    187,
    1
  }, 256 /*0x0100*/);
  private string name;
  private int n;
  private int n1;
  private int n2;
  private int k;
  private int g;
  private int delta;
  private int w;
  private int wr;
  private int we;
  private int utilRejectionThreshold;
  private int fft;
  private int[] generatorPoly;
  private int defaultKeySize;
  internal const int PARAM_M = 8;
  internal const int GF_MUL_ORDER = 255 /*0xFF*/;
  private HqcEngine hqcEngine;

  private HqcParameters(
    string name,
    int n,
    int n1,
    int n2,
    int k,
    int g,
    int delta,
    int w,
    int wr,
    int we,
    int utilRejectionThreshold,
    int fft,
    int[] generatorPoly,
    int defaultKeySize)
  {
    this.name = name;
    this.n = n;
    this.n1 = n1;
    this.n2 = n2;
    this.k = k;
    this.delta = delta;
    this.w = w;
    this.wr = wr;
    this.we = we;
    this.generatorPoly = generatorPoly;
    this.g = g;
    this.utilRejectionThreshold = utilRejectionThreshold;
    this.fft = fft;
    this.defaultKeySize = defaultKeySize;
    this.hqcEngine = new HqcEngine(n, n1, n2, k, g, delta, w, wr, we, utilRejectionThreshold, fft, generatorPoly);
  }

  public int N => this.n;

  public int K => this.k;

  public int Delta => this.delta;

  public int W => this.w;

  public int Wr => this.wr;

  public int We => this.we;

  public int N1 => this.n1;

  public int N2 => this.n2;

  public int Sha512Bytes => 64 /*0x40*/;

  public int NBytes => (this.n + 7) / 8;

  public int N1n2Bytes => (this.n1 * this.n2 + 7) / 8;

  public int DefaultKeySize => this.defaultKeySize;

  public int SaltSizeBytes => 16 /*0x10*/;

  internal HqcEngine Engine => this.hqcEngine;
}
