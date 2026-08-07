// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.AlertDescription
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class AlertDescription
{
  public const short close_notify = 0;
  public const short unexpected_message = 10;
  public const short bad_record_mac = 20;
  public const short decryption_failed = 21;
  public const short record_overflow = 22;
  public const short decompression_failure = 30;
  public const short handshake_failure = 40;
  public const short no_certificate = 41;
  public const short bad_certificate = 42;
  public const short unsupported_certificate = 43;
  public const short certificate_revoked = 44;
  public const short certificate_expired = 45;
  public const short certificate_unknown = 46;
  public const short illegal_parameter = 47;
  public const short unknown_ca = 48 /*0x30*/;
  public const short access_denied = 49;
  public const short decode_error = 50;
  public const short decrypt_error = 51;
  public const short export_restriction = 60;
  public const short protocol_version = 70;
  public const short insufficient_security = 71;
  public const short internal_error = 80 /*0x50*/;
  public const short user_canceled = 90;
  public const short no_renegotiation = 100;
  public const short unsupported_extension = 110;
  public const short certificate_unobtainable = 111;
  public const short unrecognized_name = 112 /*0x70*/;
  public const short bad_certificate_status_response = 113;
  public const short bad_certificate_hash_value = 114;
  public const short unknown_psk_identity = 115;
  public const short no_application_protocol = 120;
  public const short inappropriate_fallback = 86;
  public const short missing_extension = 109;
  public const short certificate_required = 116;

  public static string GetName(short alertDescription)
  {
    switch (alertDescription)
    {
      case 0:
        return "close_notify";
      case 10:
        return "unexpected_message";
      case 20:
        return "bad_record_mac";
      case 21:
        return "decryption_failed";
      case 22:
        return "record_overflow";
      case 30:
        return "decompression_failure";
      case 40:
        return "handshake_failure";
      case 41:
        return "no_certificate";
      case 42:
        return "bad_certificate";
      case 43:
        return "unsupported_certificate";
      case 44:
        return "certificate_revoked";
      case 45:
        return "certificate_expired";
      case 46:
        return "certificate_unknown";
      case 47:
        return "illegal_parameter";
      case 48 /*0x30*/:
        return "unknown_ca";
      case 49:
        return "access_denied";
      case 50:
        return "decode_error";
      case 51:
        return "decrypt_error";
      case 60:
        return "export_restriction";
      case 70:
        return "protocol_version";
      case 71:
        return "insufficient_security";
      case 80 /*0x50*/:
        return "internal_error";
      case 86:
        return "inappropriate_fallback";
      case 90:
        return "user_canceled";
      case 100:
        return "no_renegotiation";
      case 109:
        return "missing_extension";
      case 110:
        return "unsupported_extension";
      case 111:
        return "certificate_unobtainable";
      case 112 /*0x70*/:
        return "unrecognized_name";
      case 113:
        return "bad_certificate_status_response";
      case 114:
        return "bad_certificate_hash_value";
      case 115:
        return "unknown_psk_identity";
      case 116:
        return "certificate_required";
      case 120:
        return "no_application_protocol";
      default:
        return "UNKNOWN";
    }
  }

  public static string GetText(short alertDescription)
  {
    return $"{AlertDescription.GetName(alertDescription)}({alertDescription.ToString()})";
  }
}
