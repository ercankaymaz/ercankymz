// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AttributeWriteMask
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[Flags]
[ComVisible(true)]
public enum AttributeWriteMask : uint
{
  [EnumMember(Value = "None_0")] None = 0,
  [EnumMember(Value = "AccessLevel_1")] AccessLevel = 1,
  [EnumMember(Value = "ArrayDimensions_2")] ArrayDimensions = 2,
  [EnumMember(Value = "BrowseName_4")] BrowseName = 4,
  [EnumMember(Value = "ContainsNoLoops_8")] ContainsNoLoops = 8,
  [EnumMember(Value = "DataType_16")] DataType = 16, // 0x00000010
  [EnumMember(Value = "Description_32")] Description = 32, // 0x00000020
  [EnumMember(Value = "DisplayName_64")] DisplayName = 64, // 0x00000040
  [EnumMember(Value = "EventNotifier_128")] EventNotifier = 128, // 0x00000080
  [EnumMember(Value = "Executable_256")] Executable = 256, // 0x00000100
  [EnumMember(Value = "Historizing_512")] Historizing = 512, // 0x00000200
  [EnumMember(Value = "InverseName_1024")] InverseName = 1024, // 0x00000400
  [EnumMember(Value = "IsAbstract_2048")] IsAbstract = 2048, // 0x00000800
  [EnumMember(Value = "MinimumSamplingInterval_4096")] MinimumSamplingInterval = 4096, // 0x00001000
  [EnumMember(Value = "NodeClass_8192")] NodeClass = 8192, // 0x00002000
  [EnumMember(Value = "NodeId_16384")] NodeId = 16384, // 0x00004000
  [EnumMember(Value = "Symmetric_32768")] Symmetric = 32768, // 0x00008000
  [EnumMember(Value = "UserAccessLevel_65536")] UserAccessLevel = 65536, // 0x00010000
  [EnumMember(Value = "UserExecutable_131072")] UserExecutable = 131072, // 0x00020000
  [EnumMember(Value = "UserWriteMask_262144")] UserWriteMask = 262144, // 0x00040000
  [EnumMember(Value = "ValueRank_524288")] ValueRank = 524288, // 0x00080000
  [EnumMember(Value = "WriteMask_1048576")] WriteMask = 1048576, // 0x00100000
  [EnumMember(Value = "ValueForVariableType_2097152")] ValueForVariableType = 2097152, // 0x00200000
  [EnumMember(Value = "DataTypeDefinition_4194304")] DataTypeDefinition = 4194304, // 0x00400000
  [EnumMember(Value = "RolePermissions_8388608")] RolePermissions = 8388608, // 0x00800000
  [EnumMember(Value = "AccessRestrictions_16777216")] AccessRestrictions = 16777216, // 0x01000000
  [EnumMember(Value = "AccessLevelEx_33554432")] AccessLevelEx = 33554432, // 0x02000000
}
