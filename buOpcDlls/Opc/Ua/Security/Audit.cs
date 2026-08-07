// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Security.Audit
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

#nullable disable
namespace Opc.Ua.Security;

[ComVisible(true)]
public static class Audit
{
  public static void SecureChannelCreated(
    string implementationInfo,
    string endpointUrl,
    string secureChannelId,
    EndpointDescription endpoint,
    X509Certificate2 clientCertificate,
    X509Certificate2 serverCertificate,
    BinaryEncodingSupport encodingSupport)
  {
    if ((Utils.TraceMask & 512 /*0x0200*/) == 0)
      return;
    if (endpoint != null)
    {
      string str;
      switch (encodingSupport)
      {
        case BinaryEncodingSupport.Required:
          str = "Binary";
          break;
        case BinaryEncodingSupport.None:
          str = "Xml";
          break;
        default:
          str = "BinaryOrXml";
          break;
      }
      Utils.LogInfo("SECURE CHANNEL CREATED [{0}] [ID={1}] Connected To: {2} [{3}/{4}/{5}]", (object) implementationInfo, (object) secureChannelId, (object) endpointUrl, (object) endpoint.SecurityMode.ToString(), (object) SecurityPolicies.GetDisplayName(endpoint.SecurityPolicyUri), (object) str);
      if (endpoint.SecurityMode == MessageSecurityMode.None)
        return;
      Utils.LogCertificate("Client Certificate: ", clientCertificate);
      Utils.LogCertificate("Server Certificate: ", serverCertificate);
    }
    else
      Utils.LogInfo("SECURE CHANNEL CREATED [{0}] [ID={1}] Connected To: {2}", (object) implementationInfo, (object) secureChannelId, (object) endpointUrl);
  }

  public static void SecureChannelRenewed(string implementationInfo, string secureChannelId)
  {
    if ((Utils.TraceMask & 512 /*0x0200*/) == 0)
      return;
    Utils.LogInfo("SECURE CHANNEL RENEWED [{0}] [ID={1}]", (object) implementationInfo, (object) secureChannelId);
  }
}
