// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ModelChangeStructureVerbMask
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
public enum ModelChangeStructureVerbMask
{
  [EnumMember(Value = "NodeAdded_1")] NodeAdded = 1,
  [EnumMember(Value = "NodeDeleted_2")] NodeDeleted = 2,
  [EnumMember(Value = "ReferenceAdded_4")] ReferenceAdded = 4,
  [EnumMember(Value = "ReferenceDeleted_8")] ReferenceDeleted = 8,
  [EnumMember(Value = "DataTypeChanged_16")] DataTypeChanged = 16, // 0x00000010
}
