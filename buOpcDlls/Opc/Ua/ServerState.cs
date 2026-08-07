// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ServerState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public enum ServerState
{
  [EnumMember(Value = "Running_0")] Running,
  [EnumMember(Value = "Failed_1")] Failed,
  [EnumMember(Value = "NoConfiguration_2")] NoConfiguration,
  [EnumMember(Value = "Suspended_3")] Suspended,
  [EnumMember(Value = "Shutdown_4")] Shutdown,
  [EnumMember(Value = "Test_5")] Test,
  [EnumMember(Value = "CommunicationFault_6")] CommunicationFault,
  [EnumMember(Value = "Unknown_7")] Unknown,
}
