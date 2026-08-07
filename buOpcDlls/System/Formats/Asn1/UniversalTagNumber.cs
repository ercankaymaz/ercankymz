// Decompiled with JetBrains decompiler
// Type: System.Formats.Asn1.UniversalTagNumber
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;

#nullable disable
namespace System.Formats.Asn1;

[ComVisible(true)]
public enum UniversalTagNumber
{
  EndOfContents = 0,
  Boolean = 1,
  Integer = 2,
  BitString = 3,
  OctetString = 4,
  Null = 5,
  ObjectIdentifier = 6,
  ObjectDescriptor = 7,
  External = 8,
  InstanceOf = 8,
  Real = 9,
  Enumerated = 10, // 0x0000000A
  Embedded = 11, // 0x0000000B
  UTF8String = 12, // 0x0000000C
  RelativeObjectIdentifier = 13, // 0x0000000D
  Time = 14, // 0x0000000E
  Sequence = 16, // 0x00000010
  SequenceOf = 16, // 0x00000010
  Set = 17, // 0x00000011
  SetOf = 17, // 0x00000011
  NumericString = 18, // 0x00000012
  PrintableString = 19, // 0x00000013
  T61String = 20, // 0x00000014
  TeletexString = 20, // 0x00000014
  VideotexString = 21, // 0x00000015
  IA5String = 22, // 0x00000016
  UtcTime = 23, // 0x00000017
  GeneralizedTime = 24, // 0x00000018
  GraphicString = 25, // 0x00000019
  ISO646String = 26, // 0x0000001A
  VisibleString = 26, // 0x0000001A
  GeneralString = 27, // 0x0000001B
  UniversalString = 28, // 0x0000001C
  UnrestrictedCharacterString = 29, // 0x0000001D
  BMPString = 30, // 0x0000001E
  Date = 31, // 0x0000001F
  TimeOfDay = 32, // 0x00000020
  DateTime = 33, // 0x00000021
  Duration = 34, // 0x00000022
  ObjectIdentifierIRI = 35, // 0x00000023
  RelativeObjectIdentifierIRI = 36, // 0x00000024
}
