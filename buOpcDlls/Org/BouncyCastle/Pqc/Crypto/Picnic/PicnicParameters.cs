// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Picnic.PicnicParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Picnic;

public sealed class PicnicParameters : ICipherParameters
{
  public static PicnicParameters picnicl1fs = new PicnicParameters(nameof (picnicl1fs), 1);
  public static PicnicParameters picnicl1ur = new PicnicParameters(nameof (picnicl1ur), 2);
  public static PicnicParameters picnicl3fs = new PicnicParameters(nameof (picnicl3fs), 3);
  public static PicnicParameters picnicl3ur = new PicnicParameters(nameof (picnicl3ur), 4);
  public static PicnicParameters picnicl5fs = new PicnicParameters(nameof (picnicl5fs), 5);
  public static PicnicParameters picnicl5ur = new PicnicParameters(nameof (picnicl5ur), 6);
  public static PicnicParameters picnic3l1 = new PicnicParameters(nameof (picnic3l1), 7);
  public static PicnicParameters picnic3l3 = new PicnicParameters(nameof (picnic3l3), 8);
  public static PicnicParameters picnic3l5 = new PicnicParameters(nameof (picnic3l5), 9);
  public static PicnicParameters picnicl1full = new PicnicParameters(nameof (picnicl1full), 10);
  public static PicnicParameters picnicl3full = new PicnicParameters(nameof (picnicl3full), 11);
  public static PicnicParameters picnicl5full = new PicnicParameters(nameof (picnicl5full), 12);
  private string name;
  private int param;

  private PicnicParameters(string name, int param)
  {
    this.name = name;
    this.param = param;
  }

  public string Name => this.name;

  internal PicnicEngine GetEngine()
  {
    switch (this.param)
    {
      case 1:
      case 2:
      case 7:
      case 10:
        return new PicnicEngine(this.param, PicnicParameters.L1Constants.Instance);
      case 3:
      case 4:
      case 8:
      case 11:
        return new PicnicEngine(this.param, PicnicParameters.L3Constants.Instance);
      case 5:
      case 6:
      case 9:
      case 12:
        return new PicnicEngine(this.param, PicnicParameters.L5Constants.Instance);
      default:
        return (PicnicEngine) null;
    }
  }

  private class L1Constants
  {
    internal static readonly LowmcConstants Instance = (LowmcConstants) new LowmcConstantsL1();
  }

  private class L3Constants
  {
    internal static readonly LowmcConstants Instance = (LowmcConstants) new LowmcConstantsL3();
  }

  private class L5Constants
  {
    internal static readonly LowmcConstants Instance = (LowmcConstants) new LowmcConstantsL5();
  }
}
