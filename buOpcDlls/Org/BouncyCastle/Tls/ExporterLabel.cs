// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.ExporterLabel
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class ExporterLabel
{
  public const string client_finished = "client finished";
  public const string server_finished = "server finished";
  public const string master_secret = "master secret";
  public const string key_expansion = "key expansion";
  public const string client_EAP_encryption = "client EAP encryption";
  public const string ttls_keying_material = "ttls keying material";
  public const string ttls_challenge = "ttls challenge";
  public const string dtls_srtp = "EXTRACTOR-dtls_srtp";
  public const string extended_master_secret = "extended master secret";
  public const string token_binding = "EXPORTER-Token-Binding";
}
