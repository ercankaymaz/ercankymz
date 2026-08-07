// Decompiled with JetBrains decompiler
// Type: Opc.Ua.StructureType
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
public enum StructureType
{
  [EnumMember(Value = "Structure_0")] Structure,
  [EnumMember(Value = "StructureWithOptionalFields_1")] StructureWithOptionalFields,
  [EnumMember(Value = "Union_2")] Union,
  [EnumMember(Value = "StructureWithSubtypedValues_3")] StructureWithSubtypedValues,
  [EnumMember(Value = "UnionWithSubtypedValues_4")] UnionWithSubtypedValues,
}
