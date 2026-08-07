// Decompiled with JetBrains decompiler
// Type: Opc.Ua.JsonDataSetMessageContentMask
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
public enum JsonDataSetMessageContentMask : uint
{
  [EnumMember(Value = "None_0")] None = 0,
  [EnumMember(Value = "DataSetWriterId_1")] DataSetWriterId = 1,
  [EnumMember(Value = "MetaDataVersion_2")] MetaDataVersion = 2,
  [EnumMember(Value = "SequenceNumber_4")] SequenceNumber = 4,
  [EnumMember(Value = "Timestamp_8")] Timestamp = 8,
  [EnumMember(Value = "Status_16")] Status = 16, // 0x00000010
  [EnumMember(Value = "MessageType_32")] MessageType = 32, // 0x00000020
}
