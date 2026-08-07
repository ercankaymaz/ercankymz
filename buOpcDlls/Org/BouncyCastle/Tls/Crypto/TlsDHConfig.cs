// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.TlsDHConfig
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto;

public class TlsDHConfig
{
  protected readonly DHGroup m_explicitGroup;
  protected readonly int m_namedGroup;
  protected readonly bool m_padded;

  public TlsDHConfig(DHGroup explicitGroup)
  {
    this.m_explicitGroup = explicitGroup;
    this.m_namedGroup = -1;
    this.m_padded = false;
  }

  public TlsDHConfig(int namedGroup, bool padded)
  {
    this.m_explicitGroup = (DHGroup) null;
    this.m_namedGroup = namedGroup;
    this.m_padded = padded;
  }

  public virtual DHGroup ExplicitGroup => this.m_explicitGroup;

  public virtual int NamedGroup => this.m_namedGroup;

  public virtual bool IsPadded => this.m_padded;
}
