// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PermissionType
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
public enum PermissionType : uint
{
  [EnumMember(Value = "None_0")] None = 0,
  [EnumMember(Value = "Browse_1")] Browse = 1,
  [EnumMember(Value = "ReadRolePermissions_2")] ReadRolePermissions = 2,
  [EnumMember(Value = "WriteAttribute_4")] WriteAttribute = 4,
  [EnumMember(Value = "WriteRolePermissions_8")] WriteRolePermissions = 8,
  [EnumMember(Value = "WriteHistorizing_16")] WriteHistorizing = 16, // 0x00000010
  [EnumMember(Value = "Read_32")] Read = 32, // 0x00000020
  [EnumMember(Value = "Write_64")] Write = 64, // 0x00000040
  [EnumMember(Value = "ReadHistory_128")] ReadHistory = 128, // 0x00000080
  [EnumMember(Value = "InsertHistory_256")] InsertHistory = 256, // 0x00000100
  [EnumMember(Value = "ModifyHistory_512")] ModifyHistory = 512, // 0x00000200
  [EnumMember(Value = "DeleteHistory_1024")] DeleteHistory = 1024, // 0x00000400
  [EnumMember(Value = "ReceiveEvents_2048")] ReceiveEvents = 2048, // 0x00000800
  [EnumMember(Value = "Call_4096")] Call = 4096, // 0x00001000
  [EnumMember(Value = "AddReference_8192")] AddReference = 8192, // 0x00002000
  [EnumMember(Value = "RemoveReference_16384")] RemoveReference = 16384, // 0x00004000
  [EnumMember(Value = "DeleteNode_32768")] DeleteNode = 32768, // 0x00008000
  [EnumMember(Value = "AddNode_65536")] AddNode = 65536, // 0x00010000
}
