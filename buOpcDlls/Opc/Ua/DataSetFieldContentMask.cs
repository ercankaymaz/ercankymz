// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DataSetFieldContentMask
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
public enum DataSetFieldContentMask : uint
{
  [EnumMember(Value = "None_0")] None = 0,
  [EnumMember(Value = "StatusCode_1")] StatusCode = 1,
  [EnumMember(Value = "SourceTimestamp_2")] SourceTimestamp = 2,
  [EnumMember(Value = "ServerTimestamp_4")] ServerTimestamp = 4,
  [EnumMember(Value = "SourcePicoSeconds_8")] SourcePicoSeconds = 8,
  [EnumMember(Value = "ServerPicoSeconds_16")] ServerPicoSeconds = 16, // 0x00000010
  [EnumMember(Value = "RawData_32")] RawData = 32, // 0x00000020
}
