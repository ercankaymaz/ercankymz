// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.TlsKeyExchangeFactory
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;

#nullable disable
namespace Org.BouncyCastle.Tls;

public interface TlsKeyExchangeFactory
{
  TlsKeyExchange CreateDHKeyExchange(int keyExchange);

  TlsKeyExchange CreateDHanonKeyExchangeClient(int keyExchange, TlsDHGroupVerifier dhGroupVerifier);

  TlsKeyExchange CreateDHanonKeyExchangeServer(int keyExchange, TlsDHConfig dhConfig);

  TlsKeyExchange CreateDheKeyExchangeClient(int keyExchange, TlsDHGroupVerifier dhGroupVerifier);

  TlsKeyExchange CreateDheKeyExchangeServer(int keyExchange, TlsDHConfig dhConfig);

  TlsKeyExchange CreateECDHKeyExchange(int keyExchange);

  TlsKeyExchange CreateECDHanonKeyExchangeClient(int keyExchange);

  TlsKeyExchange CreateECDHanonKeyExchangeServer(int keyExchange, TlsECConfig ecConfig);

  TlsKeyExchange CreateECDheKeyExchangeClient(int keyExchange);

  TlsKeyExchange CreateECDheKeyExchangeServer(int keyExchange, TlsECConfig ecConfig);

  TlsKeyExchange CreatePskKeyExchangeClient(
    int keyExchange,
    TlsPskIdentity pskIdentity,
    TlsDHGroupVerifier dhGroupVerifier);

  TlsKeyExchange CreatePskKeyExchangeServer(
    int keyExchange,
    TlsPskIdentityManager pskIdentityManager,
    TlsDHConfig dhConfig,
    TlsECConfig ecConfig);

  TlsKeyExchange CreateRsaKeyExchange(int keyExchange);

  TlsKeyExchange CreateSrpKeyExchangeClient(
    int keyExchange,
    TlsSrpIdentity srpIdentity,
    TlsSrpConfigVerifier srpConfigVerifier);

  TlsKeyExchange CreateSrpKeyExchangeServer(int keyExchange, TlsSrpLoginParameters loginParameters);
}
