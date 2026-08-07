// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber.KyberParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber;

public sealed class KyberParameters : ICipherParameters
{
  public static KyberParameters kyber512 = new KyberParameters(nameof (kyber512), 2, 128 /*0x80*/, false);
  public static KyberParameters kyber768 = new KyberParameters(nameof (kyber768), 3, 192 /*0xC0*/, false);
  public static KyberParameters kyber1024 = new KyberParameters(nameof (kyber1024), 4, 256 /*0x0100*/, false);
  public static KyberParameters kyber512_aes = new KyberParameters("kyber512-aes", 2, 128 /*0x80*/, true);
  public static KyberParameters kyber768_aes = new KyberParameters("kyber768-aes", 3, 192 /*0xC0*/, true);
  public static KyberParameters kyber1024_aes = new KyberParameters("kyber1024-aes", 4, 256 /*0x0100*/, true);
  private string m_name;
  private int m_sessionKeySize;
  private KyberEngine m_engine;

  private KyberParameters(string name, int k, int sessionKeySize, bool usingAes)
  {
    this.m_name = name;
    this.m_sessionKeySize = sessionKeySize;
    this.m_engine = new KyberEngine(k, usingAes);
  }

  public string Name => this.m_name;

  public int K => this.m_engine.K;

  public int SessionKeySize => this.m_sessionKeySize;

  internal KyberEngine Engine => this.m_engine;
}
