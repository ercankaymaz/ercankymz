// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Profiles
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public static class Profiles
{
  public const string UaTcpTransport = "http://opcfoundation.org/UA-Profile/Transport/uatcp-uasc-uabinary";
  public const string UaWssTransport = "http://opcfoundation.org/UA-Profile/Transport/uawss-uasc-uabinary";
  public const string HttpsBinaryTransport = "http://opcfoundation.org/UA-Profile/Transport/https-uabinary";
  public const string PubSubUdpUadpTransport = "http://opcfoundation.org/UA-Profile/Transport/pubsub-udp-uadp";
  public const string PubSubMqttUadpTransport = "http://opcfoundation.org/UA-Profile/Transport/pubsub-mqtt-uadp";
  public const string PubSubMqttJsonTransport = "http://opcfoundation.org/UA-Profile/Transport/pubsub-mqtt-json";
  public const string JwtUserToken = "http://opcfoundation.org/UA/UserToken#JWT";
  public const string HttpsSecurityPolicyHeader = "OPCUA-SecurityPolicy";

  public static string NormalizeUri(string profileUri)
  {
    string.IsNullOrEmpty(profileUri);
    return profileUri;
  }
}
