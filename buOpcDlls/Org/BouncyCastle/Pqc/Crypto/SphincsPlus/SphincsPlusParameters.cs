// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.SphincsPlus.SphincsPlusParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.SphincsPlus;

public sealed class SphincsPlusParameters
{
  public static SphincsPlusParameters sha2_128f = new SphincsPlusParameters("sha2-128f-robust", (ISphincsPlusEngineProvider) new Sha2EngineProvider(true, 16 /*0x10*/, 16U /*0x10*/, 22U, 6, 33, 66U));
  public static SphincsPlusParameters sha2_128s = new SphincsPlusParameters("sha2-128s-robust", (ISphincsPlusEngineProvider) new Sha2EngineProvider(true, 16 /*0x10*/, 16U /*0x10*/, 7U, 12, 14, 63U /*0x3F*/));
  public static SphincsPlusParameters sha2_192f = new SphincsPlusParameters("sha2-192f-robust", (ISphincsPlusEngineProvider) new Sha2EngineProvider(true, 24, 16U /*0x10*/, 22U, 8, 33, 66U));
  public static SphincsPlusParameters sha2_192s = new SphincsPlusParameters("sha2-192s-robust", (ISphincsPlusEngineProvider) new Sha2EngineProvider(true, 24, 16U /*0x10*/, 7U, 14, 17, 63U /*0x3F*/));
  public static SphincsPlusParameters sha2_256f = new SphincsPlusParameters("sha2-256f-robust", (ISphincsPlusEngineProvider) new Sha2EngineProvider(true, 32 /*0x20*/, 16U /*0x10*/, 17U, 9, 35, 68U));
  public static SphincsPlusParameters sha2_256s = new SphincsPlusParameters("sha2-256s-robust", (ISphincsPlusEngineProvider) new Sha2EngineProvider(true, 32 /*0x20*/, 16U /*0x10*/, 8U, 14, 22, 64U /*0x40*/));
  public static SphincsPlusParameters sha2_128f_simple = new SphincsPlusParameters("sha2-128f-simple", (ISphincsPlusEngineProvider) new Sha2EngineProvider(false, 16 /*0x10*/, 16U /*0x10*/, 22U, 6, 33, 66U));
  public static SphincsPlusParameters sha2_128s_simple = new SphincsPlusParameters("sha2-128s-simple", (ISphincsPlusEngineProvider) new Sha2EngineProvider(false, 16 /*0x10*/, 16U /*0x10*/, 7U, 12, 14, 63U /*0x3F*/));
  public static SphincsPlusParameters sha2_192f_simple = new SphincsPlusParameters("sha2-192f-simple", (ISphincsPlusEngineProvider) new Sha2EngineProvider(false, 24, 16U /*0x10*/, 22U, 8, 33, 66U));
  public static SphincsPlusParameters sha2_192s_simple = new SphincsPlusParameters("sha2-192s-simple", (ISphincsPlusEngineProvider) new Sha2EngineProvider(false, 24, 16U /*0x10*/, 7U, 14, 17, 63U /*0x3F*/));
  public static SphincsPlusParameters sha2_256f_simple = new SphincsPlusParameters("sha2-256f-simple", (ISphincsPlusEngineProvider) new Sha2EngineProvider(false, 32 /*0x20*/, 16U /*0x10*/, 17U, 9, 35, 68U));
  public static SphincsPlusParameters sha2_256s_simple = new SphincsPlusParameters("sha2-256s-simple", (ISphincsPlusEngineProvider) new Sha2EngineProvider(false, 32 /*0x20*/, 16U /*0x10*/, 8U, 14, 22, 64U /*0x40*/));
  public static SphincsPlusParameters shake_128f = new SphincsPlusParameters("shake-128f-robust", (ISphincsPlusEngineProvider) new Shake256EngineProvider(true, 16 /*0x10*/, 16U /*0x10*/, 22U, 6, 33, 66U));
  public static SphincsPlusParameters shake_128s = new SphincsPlusParameters("shake-128s-robust", (ISphincsPlusEngineProvider) new Shake256EngineProvider(true, 16 /*0x10*/, 16U /*0x10*/, 7U, 12, 14, 63U /*0x3F*/));
  public static SphincsPlusParameters shake_192f = new SphincsPlusParameters("shake-192f-robust", (ISphincsPlusEngineProvider) new Shake256EngineProvider(true, 24, 16U /*0x10*/, 22U, 8, 33, 66U));
  public static SphincsPlusParameters shake_192s = new SphincsPlusParameters("shake-192s-robust", (ISphincsPlusEngineProvider) new Shake256EngineProvider(true, 24, 16U /*0x10*/, 7U, 14, 17, 63U /*0x3F*/));
  public static SphincsPlusParameters shake_256f = new SphincsPlusParameters("shake-256f-robust", (ISphincsPlusEngineProvider) new Shake256EngineProvider(true, 32 /*0x20*/, 16U /*0x10*/, 17U, 9, 35, 68U));
  public static SphincsPlusParameters shake_256s = new SphincsPlusParameters("shake-256s-robust", (ISphincsPlusEngineProvider) new Shake256EngineProvider(true, 32 /*0x20*/, 16U /*0x10*/, 8U, 14, 22, 64U /*0x40*/));
  public static SphincsPlusParameters shake_128f_simple = new SphincsPlusParameters("shake-128f-simple", (ISphincsPlusEngineProvider) new Shake256EngineProvider(false, 16 /*0x10*/, 16U /*0x10*/, 22U, 6, 33, 66U));
  public static SphincsPlusParameters shake_128s_simple = new SphincsPlusParameters("shake-128s-simple", (ISphincsPlusEngineProvider) new Shake256EngineProvider(false, 16 /*0x10*/, 16U /*0x10*/, 7U, 12, 14, 63U /*0x3F*/));
  public static SphincsPlusParameters shake_192f_simple = new SphincsPlusParameters("shake-192f-simple", (ISphincsPlusEngineProvider) new Shake256EngineProvider(false, 24, 16U /*0x10*/, 22U, 8, 33, 66U));
  public static SphincsPlusParameters shake_192s_simple = new SphincsPlusParameters("shake-192s-simple", (ISphincsPlusEngineProvider) new Shake256EngineProvider(false, 24, 16U /*0x10*/, 7U, 14, 17, 63U /*0x3F*/));
  public static SphincsPlusParameters shake_256f_simple = new SphincsPlusParameters("shake-256f-simple", (ISphincsPlusEngineProvider) new Shake256EngineProvider(false, 32 /*0x20*/, 16U /*0x10*/, 17U, 9, 35, 68U));
  public static SphincsPlusParameters shake_256s_simple = new SphincsPlusParameters("shake-256s-simple", (ISphincsPlusEngineProvider) new Shake256EngineProvider(false, 32 /*0x20*/, 16U /*0x10*/, 8U, 14, 22, 64U /*0x40*/));
  public static SphincsPlusParameters haraka_128f = new SphincsPlusParameters("haraka-128f-robust", (ISphincsPlusEngineProvider) new Haraka256EngineProvider(true, 16 /*0x10*/, 16U /*0x10*/, 22U, 6, 33, 66U));
  public static SphincsPlusParameters haraka_128s = new SphincsPlusParameters("haraka-128s-robust", (ISphincsPlusEngineProvider) new Haraka256EngineProvider(true, 16 /*0x10*/, 16U /*0x10*/, 7U, 12, 14, 63U /*0x3F*/));
  public static SphincsPlusParameters haraka_256f = new SphincsPlusParameters("haraka-256f-robust", (ISphincsPlusEngineProvider) new Haraka256EngineProvider(true, 32 /*0x20*/, 16U /*0x10*/, 17U, 9, 35, 68U));
  public static SphincsPlusParameters haraka_256s = new SphincsPlusParameters("haraka-256s-robust", (ISphincsPlusEngineProvider) new Haraka256EngineProvider(true, 32 /*0x20*/, 16U /*0x10*/, 8U, 14, 22, 64U /*0x40*/));
  public static SphincsPlusParameters haraka_192f = new SphincsPlusParameters("haraka-192f-robust", (ISphincsPlusEngineProvider) new Haraka256EngineProvider(true, 24, 16U /*0x10*/, 22U, 8, 33, 66U));
  public static SphincsPlusParameters haraka_192s = new SphincsPlusParameters("haraka-192s-robust", (ISphincsPlusEngineProvider) new Haraka256EngineProvider(true, 24, 16U /*0x10*/, 7U, 14, 17, 63U /*0x3F*/));
  public static SphincsPlusParameters haraka_128f_simple = new SphincsPlusParameters("haraka-128f-simple", (ISphincsPlusEngineProvider) new Haraka256EngineProvider(false, 16 /*0x10*/, 16U /*0x10*/, 22U, 6, 33, 66U));
  public static SphincsPlusParameters haraka_128s_simple = new SphincsPlusParameters("haraka-128s-simple", (ISphincsPlusEngineProvider) new Haraka256EngineProvider(false, 16 /*0x10*/, 16U /*0x10*/, 7U, 12, 14, 63U /*0x3F*/));
  public static SphincsPlusParameters haraka_192f_simple = new SphincsPlusParameters("haraka-192f-simple", (ISphincsPlusEngineProvider) new Haraka256EngineProvider(false, 24, 16U /*0x10*/, 22U, 8, 33, 66U));
  public static SphincsPlusParameters haraka_192s_simple = new SphincsPlusParameters("haraka-192s-simple", (ISphincsPlusEngineProvider) new Haraka256EngineProvider(false, 24, 16U /*0x10*/, 7U, 14, 17, 63U /*0x3F*/));
  public static SphincsPlusParameters haraka_256f_simple = new SphincsPlusParameters("haraka-256f-simple", (ISphincsPlusEngineProvider) new Haraka256EngineProvider(false, 32 /*0x20*/, 16U /*0x10*/, 17U, 9, 35, 68U));
  public static SphincsPlusParameters haraka_256s_simple = new SphincsPlusParameters("haraka-256s-simple", (ISphincsPlusEngineProvider) new Haraka256EngineProvider(false, 32 /*0x20*/, 16U /*0x10*/, 8U, 14, 22, 64U /*0x40*/));
  private static uint sphincsPlus_sha2_128f_robust = 65793;
  private static uint sphincsPlus_sha2_128s_robust = 65794;
  private static uint sphincsPlus_sha2_192f_robust = 65795;
  private static uint sphincsPlus_sha2_192s_robust = 65796;
  private static uint sphincsPlus_sha2_256f_robust = 65797;
  private static uint sphincsPlus_sha2_256s_robust = 65798;
  private static uint sphincsPlus_sha2_128f_simple = 66049;
  private static uint sphincsPlus_sha2_128s_simple = 66050;
  private static uint sphincsPlus_sha2_192f_simple = 66051;
  private static uint sphincsPlus_sha2_192s_simple = 66052;
  private static uint sphincsPlus_sha2_256f_simple = 66053;
  private static uint sphincsPlus_sha2_256s_simple = 66054;
  private static uint sphincsPlus_shake_128f_robust = 131329;
  private static uint sphincsPlus_shake_128s_robust = 131330;
  private static uint sphincsPlus_shake_192f_robust = 131331;
  private static uint sphincsPlus_shake_192s_robust = 131332;
  private static uint sphincsPlus_shake_256f_robust = 131333;
  private static uint sphincsPlus_shake_256s_robust = 131334;
  private static uint sphincsPlus_shake_128f_simple = 131585;
  private static uint sphincsPlus_shake_128s_simple = 131586;
  private static uint sphincsPlus_shake_192f_simple = 131587;
  private static uint sphincsPlus_shake_192s_simple = 131588;
  private static uint sphincsPlus_shake_256f_simple = 131589;
  private static uint sphincsPlus_shake_256s_simple = 131590;
  private static uint sphincsPlus_haraka_128f_robust = 196865;
  private static uint sphincsPlus_haraka_128s_robust = 196866;
  private static uint sphincsPlus_haraka_192f_robust = 196867;
  private static uint sphincsPlus_haraka_192s_robust = 196868;
  private static uint sphincsPlus_haraka_256f_robust = 196869;
  private static uint sphincsPlus_haraka_256s_robust = 196870;
  private static uint sphincsPlus_haraka_128f_simple = 197121;
  private static uint sphincsPlus_haraka_128s_simple = 197122;
  private static uint sphincsPlus_haraka_192f_simple = 197123;
  private static uint sphincsPlus_haraka_192s_simple = 197124;
  private static uint sphincsPlus_haraka_256f_simple = 197125;
  private static uint sphincsPlus_haraka_256s_simple = 197126;
  private static Dictionary<uint, SphincsPlusParameters> oidToParams = new Dictionary<uint, SphincsPlusParameters>();
  private static Dictionary<SphincsPlusParameters, uint> paramsToOid = new Dictionary<SphincsPlusParameters, uint>();
  private readonly string m_name;
  private readonly ISphincsPlusEngineProvider m_engineProvider;

  static SphincsPlusParameters()
  {
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_sha2_128f_robust] = SphincsPlusParameters.sha2_128f;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_sha2_128s_robust] = SphincsPlusParameters.sha2_128s;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_sha2_192f_robust] = SphincsPlusParameters.sha2_192f;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_sha2_192s_robust] = SphincsPlusParameters.sha2_192s;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_sha2_256f_robust] = SphincsPlusParameters.sha2_256f;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_sha2_256s_robust] = SphincsPlusParameters.sha2_256s;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_sha2_128f_simple] = SphincsPlusParameters.sha2_128f_simple;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_sha2_128s_simple] = SphincsPlusParameters.sha2_128s_simple;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_sha2_192f_simple] = SphincsPlusParameters.sha2_192f_simple;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_sha2_192s_simple] = SphincsPlusParameters.sha2_192s_simple;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_sha2_256f_simple] = SphincsPlusParameters.sha2_256f_simple;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_sha2_256s_simple] = SphincsPlusParameters.sha2_256s_simple;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_shake_128f_robust] = SphincsPlusParameters.shake_128f;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_shake_128s_robust] = SphincsPlusParameters.shake_128s;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_shake_192f_robust] = SphincsPlusParameters.shake_192f;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_shake_192s_robust] = SphincsPlusParameters.shake_192s;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_shake_256f_robust] = SphincsPlusParameters.shake_256f;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_shake_256s_robust] = SphincsPlusParameters.shake_256s;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_shake_128f_simple] = SphincsPlusParameters.shake_128f_simple;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_shake_128s_simple] = SphincsPlusParameters.shake_128s_simple;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_shake_192f_simple] = SphincsPlusParameters.shake_192f_simple;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_shake_192s_simple] = SphincsPlusParameters.shake_192s_simple;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_shake_256f_simple] = SphincsPlusParameters.shake_256f_simple;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_shake_256s_simple] = SphincsPlusParameters.shake_256s_simple;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_haraka_128f_simple] = SphincsPlusParameters.haraka_128f_simple;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_haraka_128f_robust] = SphincsPlusParameters.haraka_128f;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_haraka_192f_simple] = SphincsPlusParameters.haraka_192f_simple;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_haraka_192f_robust] = SphincsPlusParameters.haraka_192f;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_haraka_256f_simple] = SphincsPlusParameters.haraka_256f_simple;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_haraka_256f_robust] = SphincsPlusParameters.haraka_256f;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_haraka_128s_simple] = SphincsPlusParameters.haraka_128s_simple;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_haraka_128s_robust] = SphincsPlusParameters.haraka_128s;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_haraka_192s_simple] = SphincsPlusParameters.haraka_192s_simple;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_haraka_192s_robust] = SphincsPlusParameters.haraka_192s;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_haraka_256s_simple] = SphincsPlusParameters.haraka_256s_simple;
    SphincsPlusParameters.oidToParams[SphincsPlusParameters.sphincsPlus_haraka_256s_robust] = SphincsPlusParameters.haraka_256s;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.sha2_128f] = SphincsPlusParameters.sphincsPlus_sha2_128f_robust;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.sha2_128s] = SphincsPlusParameters.sphincsPlus_sha2_128s_robust;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.sha2_192f] = SphincsPlusParameters.sphincsPlus_sha2_192f_robust;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.sha2_192s] = SphincsPlusParameters.sphincsPlus_sha2_192s_robust;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.sha2_256f] = SphincsPlusParameters.sphincsPlus_sha2_256f_robust;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.sha2_256s] = SphincsPlusParameters.sphincsPlus_sha2_256s_robust;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.sha2_128f_simple] = SphincsPlusParameters.sphincsPlus_sha2_128f_simple;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.sha2_128s_simple] = SphincsPlusParameters.sphincsPlus_sha2_128s_simple;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.sha2_192f_simple] = SphincsPlusParameters.sphincsPlus_sha2_192f_simple;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.sha2_192s_simple] = SphincsPlusParameters.sphincsPlus_sha2_192s_simple;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.sha2_256f_simple] = SphincsPlusParameters.sphincsPlus_sha2_256f_simple;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.sha2_256s_simple] = SphincsPlusParameters.sphincsPlus_sha2_256s_simple;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.shake_128f] = SphincsPlusParameters.sphincsPlus_shake_128f_robust;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.shake_128s] = SphincsPlusParameters.sphincsPlus_shake_128s_robust;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.shake_192f] = SphincsPlusParameters.sphincsPlus_shake_192f_robust;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.shake_192s] = SphincsPlusParameters.sphincsPlus_shake_192s_robust;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.shake_256f] = SphincsPlusParameters.sphincsPlus_shake_256f_robust;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.shake_256s] = SphincsPlusParameters.sphincsPlus_shake_256s_robust;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.shake_128f_simple] = SphincsPlusParameters.sphincsPlus_shake_128f_simple;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.shake_128s_simple] = SphincsPlusParameters.sphincsPlus_shake_128s_simple;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.shake_192f_simple] = SphincsPlusParameters.sphincsPlus_shake_192f_simple;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.shake_192s_simple] = SphincsPlusParameters.sphincsPlus_shake_192s_simple;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.shake_256f_simple] = SphincsPlusParameters.sphincsPlus_shake_256f_simple;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.shake_256s_simple] = SphincsPlusParameters.sphincsPlus_shake_256s_simple;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.haraka_128f_simple] = SphincsPlusParameters.sphincsPlus_haraka_128f_simple;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.haraka_192f_simple] = SphincsPlusParameters.sphincsPlus_haraka_192f_simple;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.haraka_256f_simple] = SphincsPlusParameters.sphincsPlus_haraka_256f_simple;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.haraka_128s_simple] = SphincsPlusParameters.sphincsPlus_haraka_128s_simple;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.haraka_192s_simple] = SphincsPlusParameters.sphincsPlus_haraka_192s_simple;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.haraka_256s_simple] = SphincsPlusParameters.sphincsPlus_haraka_256s_simple;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.haraka_128f] = SphincsPlusParameters.sphincsPlus_haraka_128f_robust;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.haraka_192f] = SphincsPlusParameters.sphincsPlus_haraka_192f_robust;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.haraka_256f] = SphincsPlusParameters.sphincsPlus_haraka_256f_robust;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.haraka_128s] = SphincsPlusParameters.sphincsPlus_haraka_128s_robust;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.haraka_192s] = SphincsPlusParameters.sphincsPlus_haraka_192s_robust;
    SphincsPlusParameters.paramsToOid[SphincsPlusParameters.haraka_256s] = SphincsPlusParameters.sphincsPlus_haraka_256s_robust;
  }

  private SphincsPlusParameters(string name, ISphincsPlusEngineProvider engineProvider)
  {
    this.m_name = name;
    this.m_engineProvider = engineProvider;
  }

  public string Name => this.m_name;

  internal int N => this.m_engineProvider.N;

  internal SphincsPlusEngine GetEngine() => this.m_engineProvider.Get();

  public static SphincsPlusParameters GetParams(int id)
  {
    return SphincsPlusParameters.oidToParams[Convert.ToUInt32(id)];
  }

  public static int GetID(SphincsPlusParameters parameters)
  {
    return Convert.ToInt32(SphincsPlusParameters.paramsToOid[parameters]);
  }

  public byte[] GetEncoded() => Pack.UInt32_To_BE((uint) SphincsPlusParameters.GetID(this));
}
