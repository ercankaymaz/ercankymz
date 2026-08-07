// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.ExtensionType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class ExtensionType
{
  public const int server_name = 0;
  public const int max_fragment_length = 1;
  public const int client_certificate_url = 2;
  public const int trusted_ca_keys = 3;
  public const int truncated_hmac = 4;
  public const int status_request = 5;
  public const int user_mapping = 6;
  public const int client_authz = 7;
  public const int server_authz = 8;
  public const int cert_type = 9;
  public const int supported_groups = 10;
  public const int ec_point_formats = 11;
  public const int srp = 12;
  public const int signature_algorithms = 13;
  public const int use_srtp = 14;
  public const int heartbeat = 15;
  public const int application_layer_protocol_negotiation = 16 /*0x10*/;
  public const int status_request_v2 = 17;
  public const int signed_certificate_timestamp = 18;
  public const int client_certificate_type = 19;
  public const int server_certificate_type = 20;
  public const int padding = 21;
  public const int encrypt_then_mac = 22;
  public const int extended_master_secret = 23;
  public const int token_binding = 24;
  public const int cached_info = 25;
  public const int compress_certificate = 27;
  public const int record_size_limit = 28;
  public const int session_ticket = 35;
  public const int pre_shared_key = 41;
  public const int early_data = 42;
  public const int supported_versions = 43;
  public const int cookie = 44;
  public const int psk_key_exchange_modes = 45;
  public const int certificate_authorities = 47;
  public const int oid_filters = 48 /*0x30*/;
  public const int post_handshake_auth = 49;
  public const int signature_algorithms_cert = 50;
  public const int key_share = 51;
  public const int connection_id = 54;
  public const int renegotiation_info = 65281;

  public static string GetName(int extensionType)
  {
    switch (extensionType)
    {
      case 0:
        return "server_name";
      case 1:
        return "max_fragment_length";
      case 2:
        return "client_certificate_url";
      case 3:
        return "trusted_ca_keys";
      case 4:
        return "truncated_hmac";
      case 5:
        return "status_request";
      case 6:
        return "user_mapping";
      case 7:
        return "client_authz";
      case 8:
        return "server_authz";
      case 9:
        return "cert_type";
      case 10:
        return "supported_groups";
      case 11:
        return "ec_point_formats";
      case 12:
        return "srp";
      case 13:
        return "signature_algorithms";
      case 14:
        return "use_srtp";
      case 15:
        return "heartbeat";
      case 16 /*0x10*/:
        return "application_layer_protocol_negotiation";
      case 17:
        return "status_request_v2";
      case 18:
        return "signed_certificate_timestamp";
      case 19:
        return "client_certificate_type";
      case 20:
        return "server_certificate_type";
      case 21:
        return "padding";
      case 22:
        return "encrypt_then_mac";
      case 23:
        return "extended_master_secret";
      case 24:
        return "token_binding";
      case 25:
        return "cached_info";
      case 27:
        return "compress_certificate";
      case 28:
        return "record_size_limit";
      case 35:
        return "session_ticket";
      case 41:
        return "pre_shared_key";
      case 42:
        return "early_data";
      case 43:
        return "supported_versions";
      case 44:
        return "cookie";
      case 45:
        return "psk_key_exchange_modes";
      case 47:
        return "certificate_authorities";
      case 48 /*0x30*/:
        return "oid_filters";
      case 49:
        return "post_handshake_auth";
      case 50:
        return "signature_algorithms_cert";
      case 51:
        return "key_share";
      case 54:
        return "connection_id";
      case 65281:
        return "renegotiation_info";
      default:
        return "UNKNOWN";
    }
  }

  public static string GetText(int extensionType)
  {
    return $"{ExtensionType.GetName(extensionType)}({extensionType.ToString()})";
  }

  public static bool IsRecognized(int extensionType)
  {
    switch (extensionType)
    {
      case 0:
      case 1:
      case 2:
      case 3:
      case 4:
      case 5:
      case 6:
      case 7:
      case 8:
      case 9:
      case 10:
      case 11:
      case 12:
      case 13:
      case 14:
      case 15:
      case 16 /*0x10*/:
      case 17:
      case 18:
      case 19:
      case 20:
      case 21:
      case 22:
      case 23:
      case 24:
      case 25:
      case 27:
      case 28:
      case 35:
      case 41:
      case 42:
      case 43:
      case 44:
      case 45:
      case 47:
      case 48 /*0x30*/:
      case 49:
      case 50:
      case 51:
      case 54:
      case 65281:
        return true;
      default:
        return false;
    }
  }
}
