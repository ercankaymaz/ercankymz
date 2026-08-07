// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.TlsKeyExchange
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public interface TlsKeyExchange
{
  void Init(TlsContext context);

  void SkipServerCredentials();

  void ProcessServerCredentials(TlsCredentials serverCredentials);

  void ProcessServerCertificate(Certificate serverCertificate);

  bool RequiresServerKeyExchange { get; }

  byte[] GenerateServerKeyExchange();

  void SkipServerKeyExchange();

  void ProcessServerKeyExchange(Stream input);

  short[] GetClientCertificateTypes();

  void SkipClientCredentials();

  void ProcessClientCredentials(TlsCredentials clientCredentials);

  void ProcessClientCertificate(Certificate clientCertificate);

  void GenerateClientKeyExchange(Stream output);

  void ProcessClientKeyExchange(Stream input);

  bool RequiresCertificateVerify { get; }

  TlsSecret GeneratePreMasterSecret();
}
