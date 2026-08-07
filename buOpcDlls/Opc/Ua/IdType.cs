// Decompiled with JetBrains decompiler
// Type: Opc.Ua.IdType
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
public enum IdType
{
  [EnumMember(Value = "Numeric_0")] Numeric,
  [EnumMember(Value = "String_1")] String,
  [EnumMember(Value = "Guid_2")] Guid,
  [EnumMember(Value = "Opaque_3")] Opaque,
}
