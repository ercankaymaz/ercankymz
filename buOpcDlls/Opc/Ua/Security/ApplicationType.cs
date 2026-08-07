// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Security.ApplicationType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua.Security;

[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "ApplicationType", Namespace = "http://opcfoundation.org/UA/2011/03/SecuredApplication.xsd")]
[ComVisible(true)]
public enum ApplicationType
{
  [EnumMember] Server_0,
  [EnumMember] Client_1,
  [EnumMember] ClientAndServer_2,
  [EnumMember] DiscoveryServer_3,
}
