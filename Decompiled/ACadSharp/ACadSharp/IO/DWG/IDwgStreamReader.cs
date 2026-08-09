using System;
using System.IO;
using System.Text;
using CSMath;
using CSUtilities.Converters;

namespace ACadSharp.IO.DWG;

internal interface IDwgStreamReader
{
	int BitShift { get; }

	Encoding Encoding { get; set; }

	bool IsEmpty { get; }

	long Position { get; set; }

	Stream Stream { get; }

	void Advance(int offset);

	void AdvanceByte();

	ulong HandleReference();

	ulong HandleReference(ulong referenceHandle);

	ulong HandleReference(ulong referenceHandle, out DwgReferenceType reference);

	long PositionInBits();

	XY Read2BitDouble();

	XY Read2BitDoubleWithDefault(XY defValues);

	byte Read2Bits();

	XY Read2RawDouble();

	XYZ Read3BitDouble();

	XYZ Read3BitDoubleWithDefault(XYZ defValues);

	XYZ Read3RawDouble();

	DateTime Read8BitJulianDate();

	bool ReadBit();

	short ReadBitAsShort();

	double ReadBitDouble();

	double ReadBitDoubleWithDefault(double def);

	XYZ ReadBitExtrusion();

	int ReadBitLong();

	long ReadBitLongLong();

	short ReadBitShort();

	bool ReadBitShortAsBool();

	double ReadBitThickness();

	byte ReadByte();

	byte[] ReadBytes(int length);

	Color ReadCmColor(bool useTextStream = false);

	Color ReadColorByIndex();

	DateTime ReadDateTime();

	double ReadDouble();

	Color ReadEnColor(out Transparency transparency, out bool flag);

	int ReadInt();

	ulong ReadModularChar();

	int ReadModularShort();

	ObjectType ReadObjectType();

	char ReadRawChar();

	long ReadRawLong();

	ulong ReadRawULong();

	byte[] ReadSentinel();

	short ReadShort();

	short ReadShort<T>() where T : IEndianConverter, new();

	long ReadSignedModularChar();

	string ReadTextUnicode();

	TimeSpan ReadTimeSpan();

	uint ReadUInt();

	string ReadVariableText();

	ushort ResetShift();

	long SetPositionByFlag(long position);

	void SetPositionInBits(long positon);
}
