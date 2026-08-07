// Decompiled with JetBrains decompiler
// Type: Opc.Ua.UadpDataSetMessageContentMask
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
public enum UadpDataSetMessageContentMask : uint
{
  [EnumMember(Value = "None_0")] None = 0,
  [EnumMember(Value = "Timestamp_1")] Timestamp = 1,
  [EnumMember(Value = "PicoSeconds_2")] PicoSeconds = 2,
  [EnumMember(Value = "Status_4")] Status = 4,
  [EnumMember(Value = "MajorVersion_8")] MajorVersion = 8,
  [EnumMember(Value = "MinorVersion_16")] MinorVersion = 16, // 0x00000010
  [EnumMember(Value = "SequenceNumber_32")] SequenceNumber = 32, // 0x00000020
}
