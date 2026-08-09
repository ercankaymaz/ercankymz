using System.Buffers.Binary;
using System.Buffers.Text;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Diagnostics;

[System_002EDiagnostics_002EDiagnosticSource_002EIsReadOnly]
[SecuritySafeCritical]
[ComVisible(true)]
public struct ActivitySpanId : IEquatable<ActivitySpanId>
{
	private readonly string _hexString;

	internal ActivitySpanId(string hexString)
	{
		_hexString = hexString;
	}

	public unsafe static ActivitySpanId CreateRandom()
	{
		ulong num = default(ulong);
		ActivityTraceId.SetToRandomBytes(new Span<byte>(&num, 8));
		return new ActivitySpanId(HexConverter.ToString(new ReadOnlySpan<byte>(&num, 8), HexConverter.Casing.Lower));
	}

	public static ActivitySpanId CreateFromBytes(ReadOnlySpan<byte> idData)
	{
		if (idData.Length != 8)
		{
			throw new ArgumentOutOfRangeException("idData");
		}
		return new ActivitySpanId(HexConverter.ToString(idData, HexConverter.Casing.Lower));
	}

	public static ActivitySpanId CreateFromUtf8String(ReadOnlySpan<byte> idData)
	{
		return new ActivitySpanId(idData);
	}

	public static ActivitySpanId CreateFromString(ReadOnlySpan<char> idData)
	{
		if (idData.Length != 16 || !ActivityTraceId.IsLowerCaseHexAndNotAllZeros(idData))
		{
			throw new ArgumentOutOfRangeException("idData");
		}
		return new ActivitySpanId(idData.ToString());
	}

	[System_002EDiagnostics_002EDiagnosticSource_002ENullableContext(1)]
	public string ToHexString()
	{
		return _hexString ?? "0000000000000000";
	}

	[System_002EDiagnostics_002EDiagnosticSource_002ENullableContext(1)]
	public override string ToString()
	{
		return ToHexString();
	}

	public static bool operator ==(ActivitySpanId spanId1, ActivitySpanId spandId2)
	{
		return spanId1._hexString == spandId2._hexString;
	}

	public static bool operator !=(ActivitySpanId spanId1, ActivitySpanId spandId2)
	{
		return spanId1._hexString != spandId2._hexString;
	}

	public bool Equals(ActivitySpanId spanId)
	{
		return _hexString == spanId._hexString;
	}

	[System_002EDiagnostics_002EDiagnosticSource_002ENullableContext(2)]
	public override bool Equals([System_002EDiagnostics_002EDiagnosticSource3462135_002ENotNullWhen(true)] object obj)
	{
		if (obj is ActivitySpanId activitySpanId)
		{
			return _hexString == activitySpanId._hexString;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return ToHexString().GetHashCode();
	}

	private unsafe ActivitySpanId(ReadOnlySpan<byte> idData)
	{
		if (idData.Length != 16)
		{
			throw new ArgumentOutOfRangeException("idData");
		}
		if (!Utf8Parser.TryParse(idData, out ulong value, out int _, 'x'))
		{
			_hexString = CreateRandom()._hexString;
			return;
		}
		if (BitConverter.IsLittleEndian)
		{
			value = BinaryPrimitives.ReverseEndianness(value);
		}
		_hexString = HexConverter.ToString(new ReadOnlySpan<byte>(&value, 8), HexConverter.Casing.Lower);
	}

	public void CopyTo(Span<byte> destination)
	{
		ActivityTraceId.SetSpanFromHexChars(ToHexString().AsSpan(), destination);
	}
}
