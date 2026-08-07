// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.AbstractTlsKeyExchange
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class AbstractTlsKeyExchange : TlsKeyExchange
{
  protected readonly int m_keyExchange;
  protected TlsContext m_context;

  protected AbstractTlsKeyExchange(int keyExchange) => this.m_keyExchange = keyExchange;

  public virtual void Init(TlsContext context) => this.m_context = context;

  public abstract void SkipServerCredentials();

  public abstract void ProcessServerCredentials(TlsCredentials serverCredentials);

  public virtual void ProcessServerCertificate(Certificate serverCertificate)
  {
    throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  public virtual bool RequiresServerKeyExchange => false;

  public virtual byte[] GenerateServerKeyExchange()
  {
    if (this.RequiresServerKeyExchange)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    return (byte[]) null;
  }

  public virtual void SkipServerKeyExchange()
  {
    if (this.RequiresServerKeyExchange)
      throw new TlsFatalAlert((short) 10);
  }

  public virtual void ProcessServerKeyExchange(Stream input)
  {
    if (!this.RequiresServerKeyExchange)
      throw new TlsFatalAlert((short) 10);
  }

  public virtual short[] GetClientCertificateTypes() => (short[]) null;

  public virtual void SkipClientCredentials()
  {
  }

  public abstract void ProcessClientCredentials(TlsCredentials clientCredentials);

  public virtual void ProcessClientCertificate(Certificate clientCertificate)
  {
  }

  public abstract void GenerateClientKeyExchange(Stream output);

  public virtual void ProcessClientKeyExchange(Stream input)
  {
    throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  public virtual bool RequiresCertificateVerify => true;

  public abstract TlsSecret GeneratePreMasterSecret();
}
