// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BrowseResultMask
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
public enum BrowseResultMask
{
  [EnumMember(Value = "None_0")] None = 0,
  [EnumMember(Value = "ReferenceTypeId_1")] ReferenceTypeId = 1,
  [EnumMember(Value = "IsForward_2")] IsForward = 2,
  [EnumMember(Value = "ReferenceTypeInfo_3")] ReferenceTypeInfo = 3,
  [EnumMember(Value = "NodeClass_4")] NodeClass = 4,
  [EnumMember(Value = "BrowseName_8")] BrowseName = 8,
  [EnumMember(Value = "DisplayName_16")] DisplayName = 16, // 0x00000010
  [EnumMember(Value = "TypeDefinition_32")] TypeDefinition = 32, // 0x00000020
  [EnumMember(Value = "TargetInfo_60")] TargetInfo = 60, // 0x0000003C
  [EnumMember(Value = "All_63")] All = 63, // 0x0000003F
}
