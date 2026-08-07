// Decompiled with JetBrains decompiler
// Type: Opc.Ua.JsonNetworkMessageContentMask
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
public enum JsonNetworkMessageContentMask : uint
{
  [EnumMember(Value = "None_0")] None = 0,
  [EnumMember(Value = "NetworkMessageHeader_1")] NetworkMessageHeader = 1,
  [EnumMember(Value = "DataSetMessageHeader_2")] DataSetMessageHeader = 2,
  [EnumMember(Value = "SingleDataSetMessage_4")] SingleDataSetMessage = 4,
  [EnumMember(Value = "PublisherId_8")] PublisherId = 8,
  [EnumMember(Value = "DataSetClassId_16")] DataSetClassId = 16, // 0x00000010
  [EnumMember(Value = "ReplyTo_32")] ReplyTo = 32, // 0x00000020
}
