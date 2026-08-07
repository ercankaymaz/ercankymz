// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Saber.SaberParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Saber;

public sealed class SaberParameters : ICipherParameters
{
  public static SaberParameters lightsaberkem128r3 = new SaberParameters(nameof (lightsaberkem128r3), 2, 128 /*0x80*/, false, false);
  public static SaberParameters saberkem128r3 = new SaberParameters(nameof (saberkem128r3), 3, 128 /*0x80*/, false, false);
  public static SaberParameters firesaberkem128r3 = new SaberParameters(nameof (firesaberkem128r3), 4, 128 /*0x80*/, false, false);
  public static SaberParameters lightsaberkem192r3 = new SaberParameters(nameof (lightsaberkem192r3), 2, 192 /*0xC0*/, false, false);
  public static SaberParameters saberkem192r3 = new SaberParameters(nameof (saberkem192r3), 3, 192 /*0xC0*/, false, false);
  public static SaberParameters firesaberkem192r3 = new SaberParameters(nameof (firesaberkem192r3), 4, 192 /*0xC0*/, false, false);
  public static SaberParameters lightsaberkem256r3 = new SaberParameters(nameof (lightsaberkem256r3), 2, 256 /*0x0100*/, false, false);
  public static SaberParameters saberkem256r3 = new SaberParameters(nameof (saberkem256r3), 3, 256 /*0x0100*/, false, false);
  public static SaberParameters firesaberkem256r3 = new SaberParameters(nameof (firesaberkem256r3), 4, 256 /*0x0100*/, false, false);
  public static SaberParameters lightsaberkem90sr3 = new SaberParameters(nameof (lightsaberkem90sr3), 2, 256 /*0x0100*/, true, false);
  public static SaberParameters saberkem90sr3 = new SaberParameters(nameof (saberkem90sr3), 3, 256 /*0x0100*/, true, false);
  public static SaberParameters firesaberkem90sr3 = new SaberParameters(nameof (firesaberkem90sr3), 4, 256 /*0x0100*/, true, false);
  public static SaberParameters ulightsaberkemr3 = new SaberParameters(nameof (ulightsaberkemr3), 2, 256 /*0x0100*/, false, true);
  public static SaberParameters usaberkemr3 = new SaberParameters(nameof (usaberkemr3), 3, 256 /*0x0100*/, false, true);
  public static SaberParameters ufiresaberkemr3 = new SaberParameters(nameof (ufiresaberkemr3), 4, 256 /*0x0100*/, false, true);
  public static SaberParameters ulightsaberkem90sr3 = new SaberParameters(nameof (ulightsaberkem90sr3), 2, 256 /*0x0100*/, true, true);
  public static SaberParameters usaberkem90sr3 = new SaberParameters(nameof (usaberkem90sr3), 3, 256 /*0x0100*/, true, true);
  public static SaberParameters ufiresaberkem90sr3 = new SaberParameters(nameof (ufiresaberkem90sr3), 4, 256 /*0x0100*/, true, true);
  private readonly string name;
  private readonly int l;
  private readonly int defaultKeySize;
  private readonly SaberEngine engine;

  private SaberParameters(
    string name,
    int l,
    int defaultKeySize,
    bool usingAes,
    bool usingEffectiveMasking)
  {
    this.name = name;
    this.l = l;
    this.defaultKeySize = defaultKeySize;
    this.engine = new SaberEngine(l, defaultKeySize, usingAes, usingEffectiveMasking);
  }

  public string Name => this.name;

  public int L => this.l;

  public int DefaultKeySize => this.defaultKeySize;

  internal SaberEngine Engine => this.engine;
}
