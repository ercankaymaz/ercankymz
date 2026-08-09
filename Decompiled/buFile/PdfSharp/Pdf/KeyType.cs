using System;

namespace PdfSharp.Pdf;

[Flags]
internal enum KeyType
{
	Name = 1,
	String = 2,
	Boolean = 3,
	Integer = 4,
	Real = 5,
	Date = 6,
	Rectangle = 7,
	Array = 8,
	Dictionary = 9,
	Stream = 0xA,
	NumberTree = 0xB,
	Function = 0xC,
	TextString = 0xD,
	ByteString = 0xE,
	NameOrArray = 0x10,
	NameOrDictionary = 0x20,
	ArrayOrDictionary = 0x30,
	StreamOrArray = 0x40,
	StreamOrName = 0x50,
	ArrayOrNameOrString = 0x60,
	FunctionOrName = 0x70,
	Various = 0x80,
	TypeMask = 0xFF,
	Optional = 0x100,
	Required = 0x200,
	Inheritable = 0x400,
	MustBeIndirect = 0x1000,
	MustNotBeIndirect = 0x2000
}
