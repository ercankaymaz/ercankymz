// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.KeyType
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System;

#nullable disable
namespace PdfSharp.Pdf;

[Flags]
internal enum KeyType
{
  Name = 1,
  String = 2,
  Boolean = String | Name, // 0x00000003
  Integer = 4,
  Real = Integer | Name, // 0x00000005
  Date = Integer | String, // 0x00000006
  Rectangle = Date | Name, // 0x00000007
  Array = 8,
  Dictionary = Array | Name, // 0x00000009
  Stream = Array | String, // 0x0000000A
  NumberTree = Stream | Name, // 0x0000000B
  Function = Array | Integer, // 0x0000000C
  TextString = Function | Name, // 0x0000000D
  ByteString = Function | String, // 0x0000000E
  NameOrArray = 16, // 0x00000010
  NameOrDictionary = 32, // 0x00000020
  ArrayOrDictionary = NameOrDictionary | NameOrArray, // 0x00000030
  StreamOrArray = 64, // 0x00000040
  StreamOrName = StreamOrArray | NameOrArray, // 0x00000050
  ArrayOrNameOrString = StreamOrArray | NameOrDictionary, // 0x00000060
  FunctionOrName = ArrayOrNameOrString | NameOrArray, // 0x00000070
  Various = 128, // 0x00000080
  TypeMask = Various | FunctionOrName | ByteString | Name, // 0x000000FF
  Optional = 256, // 0x00000100
  Required = 512, // 0x00000200
  Inheritable = 1024, // 0x00000400
  MustBeIndirect = 4096, // 0x00001000
  MustNotBeIndirect = 8192, // 0x00002000
}
