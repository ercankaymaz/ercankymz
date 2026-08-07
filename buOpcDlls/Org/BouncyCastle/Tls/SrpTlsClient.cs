// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.SrpTlsClient
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Tls;

public class SrpTlsClient : AbstractTlsClient
{
  private static readonly int[] DefaultCipherSuites = new int[1]
  {
    49182
  };
  protected readonly TlsSrpIdentity m_srpIdentity;

  public SrpTlsClient(TlsCrypto crypto, byte[] identity, byte[] password)
    : this(crypto, (TlsSrpIdentity) new BasicTlsSrpIdentity(identity, password))
  {
  }

  public SrpTlsClient(TlsCrypto crypto, TlsSrpIdentity srpIdentity)
    : base(crypto)
  {
    this.m_srpIdentity = srpIdentity;
  }

  protected override int[] GetSupportedCipherSuites()
  {
    return TlsUtilities.GetSupportedCipherSuites(this.Crypto, SrpTlsClient.DefaultCipherSuites);
  }

  protected override ProtocolVersion[] GetSupportedVersions() => ProtocolVersion.TLSv12.Only();

  protected virtual bool RequireSrpServerExtension => false;

  public override IDictionary<int, byte[]> GetClientExtensions()
  {
    IDictionary<int, byte[]> extensions = TlsExtensionsUtilities.EnsureExtensionsInitialised(base.GetClientExtensions());
    TlsSrpUtilities.AddSrpExtension(extensions, this.m_srpIdentity.GetSrpIdentity());
    return extensions;
  }

  public override void ProcessServerExtensions(IDictionary<int, byte[]> serverExtensions)
  {
    if (!TlsUtilities.HasExpectedEmptyExtensionData(serverExtensions, 12, (short) 47) && this.RequireSrpServerExtension)
      throw new TlsFatalAlert((short) 47);
    base.ProcessServerExtensions(serverExtensions);
  }

  public override TlsSrpIdentity GetSrpIdentity() => this.m_srpIdentity;

  public override TlsAuthentication GetAuthentication()
  {
    throw new TlsFatalAlert((short) 80 /*0x50*/);
  }
}
