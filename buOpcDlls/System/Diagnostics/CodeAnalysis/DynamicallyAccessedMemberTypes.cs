// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.CodeAnalysis.DynamicallyAccessedMemberTypes
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace System.Diagnostics.CodeAnalysis;

[Flags]
internal enum DynamicallyAccessedMemberTypes
{
  None = 0,
  PublicParameterlessConstructor = 1,
  PublicConstructors = 3,
  NonPublicConstructors = 4,
  PublicMethods = 8,
  NonPublicMethods = 16, // 0x00000010
  PublicFields = 32, // 0x00000020
  NonPublicFields = 64, // 0x00000040
  PublicNestedTypes = 128, // 0x00000080
  NonPublicNestedTypes = 256, // 0x00000100
  PublicProperties = 512, // 0x00000200
  NonPublicProperties = 1024, // 0x00000400
  PublicEvents = 2048, // 0x00000800
  NonPublicEvents = 4096, // 0x00001000
  Interfaces = 8192, // 0x00002000
  All = -1, // 0xFFFFFFFF
}
