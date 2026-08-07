// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcTlsSrp6Server
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Agreement.Srp;
using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

internal sealed class BcTlsSrp6Server : TlsSrp6Server
{
  private readonly Srp6Server m_srp6Server;

  internal BcTlsSrp6Server(Srp6Server srp6Server) => this.m_srp6Server = srp6Server;

  public BigInteger GenerateServerCredentials() => this.m_srp6Server.GenerateServerCredentials();

  public BigInteger CalculateSecret(BigInteger clientA)
  {
    try
    {
      return this.m_srp6Server.CalculateSecret(clientA);
    }
    catch (CryptoException ex)
    {
      throw new TlsFatalAlert((short) 47, (Exception) ex);
    }
  }
}
