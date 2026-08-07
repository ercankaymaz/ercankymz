// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.BasicTlsPskIdentity
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Tls;

public class BasicTlsPskIdentity : TlsPskIdentity
{
  protected readonly byte[] m_identity;
  protected readonly byte[] m_psk;

  public BasicTlsPskIdentity(byte[] identity, byte[] psk)
  {
    this.m_identity = Arrays.Clone(identity);
    this.m_psk = Arrays.Clone(psk);
  }

  public BasicTlsPskIdentity(string identity, byte[] psk)
  {
    this.m_identity = Strings.ToUtf8ByteArray(identity);
    this.m_psk = Arrays.Clone(psk);
  }

  public virtual void SkipIdentityHint()
  {
  }

  public virtual void NotifyIdentityHint(byte[] psk_identity_hint)
  {
  }

  public virtual byte[] GetPskIdentity() => this.m_identity;

  public byte[] GetPsk() => Arrays.Clone(this.m_psk);
}
