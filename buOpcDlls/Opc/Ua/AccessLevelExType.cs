// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AccessLevelExType
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
public enum AccessLevelExType : uint
{
  [EnumMember(Value = "None_0")] None = 0,
  [EnumMember(Value = "CurrentRead_1")] CurrentRead = 1,
  [EnumMember(Value = "CurrentWrite_2")] CurrentWrite = 2,
  [EnumMember(Value = "HistoryRead_4")] HistoryRead = 4,
  [EnumMember(Value = "HistoryWrite_8")] HistoryWrite = 8,
  [EnumMember(Value = "SemanticChange_16")] SemanticChange = 16, // 0x00000010
  [EnumMember(Value = "StatusWrite_32")] StatusWrite = 32, // 0x00000020
  [EnumMember(Value = "TimestampWrite_64")] TimestampWrite = 64, // 0x00000040
  [EnumMember(Value = "NonatomicRead_256")] NonatomicRead = 256, // 0x00000100
  [EnumMember(Value = "NonatomicWrite_512")] NonatomicWrite = 512, // 0x00000200
  [EnumMember(Value = "WriteFullArrayOnly_1024")] WriteFullArrayOnly = 1024, // 0x00000400
  [EnumMember(Value = "NoSubDataTypes_2048")] NoSubDataTypes = 2048, // 0x00000800
}
