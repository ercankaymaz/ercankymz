// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.TlsContext
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;

#nullable disable
namespace Org.BouncyCastle.Tls;

public interface TlsContext
{
  TlsCrypto Crypto { get; }

  TlsNonceGenerator NonceGenerator { get; }

  SecurityParameters SecurityParameters { get; }

  bool IsServer { get; }

  ProtocolVersion[] ClientSupportedVersions { get; }

  ProtocolVersion ClientVersion { get; }

  ProtocolVersion RsaPreMasterSecretVersion { get; }

  ProtocolVersion ServerVersion { get; }

  TlsSession ResumableSession { get; }

  TlsSession Session { get; }

  object UserObject { get; set; }

  byte[] ExportChannelBinding(int channelBinding);

  byte[] ExportEarlyKeyingMaterial(string asciiLabel, byte[] context_value, int length);

  byte[] ExportKeyingMaterial(string asciiLabel, byte[] context_value, int length);
}
