// Decompiled with JetBrains decompiler
// Type: Opc.Ua.UadpNetworkMessageContentMask
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
public enum UadpNetworkMessageContentMask : uint
{
  [EnumMember(Value = "None_0")] None = 0,
  [EnumMember(Value = "PublisherId_1")] PublisherId = 1,
  [EnumMember(Value = "GroupHeader_2")] GroupHeader = 2,
  [EnumMember(Value = "WriterGroupId_4")] WriterGroupId = 4,
  [EnumMember(Value = "GroupVersion_8")] GroupVersion = 8,
  [EnumMember(Value = "NetworkMessageNumber_16")] NetworkMessageNumber = 16, // 0x00000010
  [EnumMember(Value = "SequenceNumber_32")] SequenceNumber = 32, // 0x00000020
  [EnumMember(Value = "PayloadHeader_64")] PayloadHeader = 64, // 0x00000040
  [EnumMember(Value = "Timestamp_128")] Timestamp = 128, // 0x00000080
  [EnumMember(Value = "PicoSeconds_256")] PicoSeconds = 256, // 0x00000100
  [EnumMember(Value = "DataSetClassId_512")] DataSetClassId = 512, // 0x00000200
  [EnumMember(Value = "PromotedFields_1024")] PromotedFields = 1024, // 0x00000400
}
