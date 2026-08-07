// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NodeClass
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
public enum NodeClass
{
  [EnumMember(Value = "Unspecified_0")] Unspecified = 0,
  [EnumMember(Value = "Object_1")] Object = 1,
  [EnumMember(Value = "Variable_2")] Variable = 2,
  [EnumMember(Value = "Method_4")] Method = 4,
  [EnumMember(Value = "ObjectType_8")] ObjectType = 8,
  [EnumMember(Value = "VariableType_16")] VariableType = 16, // 0x00000010
  [EnumMember(Value = "ReferenceType_32")] ReferenceType = 32, // 0x00000020
  [EnumMember(Value = "DataType_64")] DataType = 64, // 0x00000040
  [EnumMember(Value = "View_128")] View = 128, // 0x00000080
}
