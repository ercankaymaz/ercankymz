// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.BasicTlsSrpIdentity
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Tls;

public class BasicTlsSrpIdentity : TlsSrpIdentity
{
  protected readonly byte[] m_identity;
  protected readonly byte[] m_password;

  public BasicTlsSrpIdentity(byte[] identity, byte[] password)
  {
    this.m_identity = Arrays.Clone(identity);
    this.m_password = Arrays.Clone(password);
  }

  public BasicTlsSrpIdentity(string identity, string password)
  {
    this.m_identity = Strings.ToUtf8ByteArray(identity);
    this.m_password = Strings.ToUtf8ByteArray(password);
  }

  public virtual byte[] GetSrpIdentity() => this.m_identity;

  public virtual byte[] GetSrpPassword() => this.m_password;
}
