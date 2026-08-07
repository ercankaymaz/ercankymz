// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.DefaultTlsKeyExchangeFactory
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;

#nullable disable
namespace Org.BouncyCastle.Tls;

public class DefaultTlsKeyExchangeFactory : AbstractTlsKeyExchangeFactory
{
  public override TlsKeyExchange CreateDHKeyExchange(int keyExchange)
  {
    return (TlsKeyExchange) new TlsDHKeyExchange(keyExchange);
  }

  public override TlsKeyExchange CreateDHanonKeyExchangeClient(
    int keyExchange,
    TlsDHGroupVerifier dhGroupVerifier)
  {
    return (TlsKeyExchange) new TlsDHanonKeyExchange(keyExchange, dhGroupVerifier);
  }

  public override TlsKeyExchange CreateDHanonKeyExchangeServer(
    int keyExchange,
    TlsDHConfig dhConfig)
  {
    return (TlsKeyExchange) new TlsDHanonKeyExchange(keyExchange, dhConfig);
  }

  public override TlsKeyExchange CreateDheKeyExchangeClient(
    int keyExchange,
    TlsDHGroupVerifier dhGroupVerifier)
  {
    return (TlsKeyExchange) new TlsDheKeyExchange(keyExchange, dhGroupVerifier);
  }

  public override TlsKeyExchange CreateDheKeyExchangeServer(int keyExchange, TlsDHConfig dhConfig)
  {
    return (TlsKeyExchange) new TlsDheKeyExchange(keyExchange, dhConfig);
  }

  public override TlsKeyExchange CreateECDHKeyExchange(int keyExchange)
  {
    return (TlsKeyExchange) new TlsECDHKeyExchange(keyExchange);
  }

  public override TlsKeyExchange CreateECDHanonKeyExchangeClient(int keyExchange)
  {
    return (TlsKeyExchange) new TlsECDHanonKeyExchange(keyExchange);
  }

  public override TlsKeyExchange CreateECDHanonKeyExchangeServer(
    int keyExchange,
    TlsECConfig ecConfig)
  {
    return (TlsKeyExchange) new TlsECDHanonKeyExchange(keyExchange, ecConfig);
  }

  public override TlsKeyExchange CreateECDheKeyExchangeClient(int keyExchange)
  {
    return (TlsKeyExchange) new TlsECDheKeyExchange(keyExchange);
  }

  public override TlsKeyExchange CreateECDheKeyExchangeServer(int keyExchange, TlsECConfig ecConfig)
  {
    return (TlsKeyExchange) new TlsECDheKeyExchange(keyExchange, ecConfig);
  }

  public override TlsKeyExchange CreatePskKeyExchangeClient(
    int keyExchange,
    TlsPskIdentity pskIdentity,
    TlsDHGroupVerifier dhGroupVerifier)
  {
    return (TlsKeyExchange) new TlsPskKeyExchange(keyExchange, pskIdentity, dhGroupVerifier);
  }

  public override TlsKeyExchange CreatePskKeyExchangeServer(
    int keyExchange,
    TlsPskIdentityManager pskIdentityManager,
    TlsDHConfig dhConfig,
    TlsECConfig ecConfig)
  {
    return (TlsKeyExchange) new TlsPskKeyExchange(keyExchange, pskIdentityManager, dhConfig, ecConfig);
  }

  public override TlsKeyExchange CreateRsaKeyExchange(int keyExchange)
  {
    return (TlsKeyExchange) new TlsRsaKeyExchange(keyExchange);
  }

  public override TlsKeyExchange CreateSrpKeyExchangeClient(
    int keyExchange,
    TlsSrpIdentity srpIdentity,
    TlsSrpConfigVerifier srpConfigVerifier)
  {
    return (TlsKeyExchange) new TlsSrpKeyExchange(keyExchange, srpIdentity, srpConfigVerifier);
  }

  public override TlsKeyExchange CreateSrpKeyExchangeServer(
    int keyExchange,
    TlsSrpLoginParameters loginParameters)
  {
    return (TlsKeyExchange) new TlsSrpKeyExchange(keyExchange, loginParameters);
  }
}
