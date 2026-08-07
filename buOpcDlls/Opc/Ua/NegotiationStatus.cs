// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NegotiationStatus
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
public enum NegotiationStatus
{
  [EnumMember(Value = "InProgress_0")] InProgress,
  [EnumMember(Value = "Complete_1")] Complete,
  [EnumMember(Value = "Failed_2")] Failed,
  [EnumMember(Value = "Unknown_3")] Unknown,
  [EnumMember(Value = "NoNegotiation_4")] NoNegotiation,
}
