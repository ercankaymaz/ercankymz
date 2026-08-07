// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ServerSecurityPolicy
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class ServerSecurityPolicy
{
  private MessageSecurityMode m_securityMode;
  private string m_securityPolicyUri;

  public ServerSecurityPolicy() => this.Initialize();

  private void Initialize()
  {
    this.m_securityMode = MessageSecurityMode.SignAndEncrypt;
    this.m_securityPolicyUri = "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256";
  }

  [OnDeserializing]
  public void Initialize(StreamingContext context) => this.Initialize();

  public static byte CalculateSecurityLevel(MessageSecurityMode mode, string policyUri)
  {
    if (mode == MessageSecurityMode.Invalid || mode == MessageSecurityMode.None)
      return 0;
    byte securityLevel;
    switch (policyUri)
    {
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic128Rsa15":
        securityLevel = (byte) 2;
        break;
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic256":
        securityLevel = (byte) 4;
        break;
      case "http://opcfoundation.org/UA/SecurityPolicy#Basic256Sha256":
        securityLevel = (byte) 6;
        break;
      case "http://opcfoundation.org/UA/SecurityPolicy#Aes128_Sha256_RsaOaep":
        securityLevel = (byte) 8;
        break;
      case "http://opcfoundation.org/UA/SecurityPolicy#Aes256_Sha256_RsaPss":
        securityLevel = (byte) 10;
        break;
      default:
        return 0;
    }
    if (mode == MessageSecurityMode.SignAndEncrypt)
      securityLevel += (byte) 100;
    return securityLevel;
  }

  [DataMember(IsRequired = false, Order = 1)]
  public MessageSecurityMode SecurityMode
  {
    get => this.m_securityMode;
    set => this.m_securityMode = value;
  }

  [DataMember(IsRequired = false, Order = 2)]
  public string SecurityPolicyUri
  {
    get => this.m_securityPolicyUri;
    set => this.m_securityPolicyUri = value;
  }
}
