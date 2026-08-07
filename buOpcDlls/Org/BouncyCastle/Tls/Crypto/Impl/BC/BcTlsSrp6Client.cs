// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcTlsSrp6Client
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Agreement.Srp;
using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

internal sealed class BcTlsSrp6Client : TlsSrp6Client
{
  private readonly Srp6Client m_srp6Client;

  internal BcTlsSrp6Client(Srp6Client srpClient) => this.m_srp6Client = srpClient;

  public BigInteger CalculateSecret(BigInteger serverB)
  {
    try
    {
      return this.m_srp6Client.CalculateSecret(serverB);
    }
    catch (CryptoException ex)
    {
      throw new TlsFatalAlert((short) 47, (Exception) ex);
    }
  }

  public BigInteger GenerateClientCredentials(byte[] srpSalt, byte[] identity, byte[] password)
  {
    return this.m_srp6Client.GenerateClientCredentials(srpSalt, identity, password);
  }
}
