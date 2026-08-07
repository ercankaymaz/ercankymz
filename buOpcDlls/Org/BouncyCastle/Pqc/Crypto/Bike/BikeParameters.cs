// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Bike.BikeParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Bike;

public sealed class BikeParameters : ICipherParameters
{
  public static BikeParameters bike128 = new BikeParameters(nameof (bike128), 12323, 142, 134, 256 /*0x0100*/, 5, 3, 128 /*0x80*/);
  public static BikeParameters bike192 = new BikeParameters(nameof (bike192), 24659, 206, 199, 256 /*0x0100*/, 5, 3, 192 /*0xC0*/);
  public static BikeParameters bike256 = new BikeParameters(nameof (bike256), 40973, 274, 264, 256 /*0x0100*/, 5, 3, 256 /*0x0100*/);
  private readonly string name;
  private readonly int r;
  private readonly int w;
  private readonly int t;
  private readonly int l;
  private readonly int nbIter;
  private readonly int tau;
  private readonly int defaultKeySize;
  private readonly BikeEngine bikeEngine;

  private BikeParameters(
    string name,
    int r,
    int w,
    int t,
    int l,
    int nbIter,
    int tau,
    int defaultKeySize)
  {
    this.name = name;
    this.r = r;
    this.w = w;
    this.t = t;
    this.l = l;
    this.nbIter = nbIter;
    this.tau = tau;
    this.defaultKeySize = defaultKeySize;
    this.bikeEngine = new BikeEngine(r, w, t, l, nbIter, tau);
  }

  public int R => this.r;

  public int RByte => (this.r + 7) / 8;

  public int LByte => this.l / 8;

  public int W => this.w;

  public int T => this.t;

  public int L => this.l;

  public int NbIter => this.nbIter;

  public int Tau => this.tau;

  public string Name => this.name;

  public int DefaultKeySize => this.defaultKeySize;

  internal BikeEngine BikeEngine => this.bikeEngine;
}
