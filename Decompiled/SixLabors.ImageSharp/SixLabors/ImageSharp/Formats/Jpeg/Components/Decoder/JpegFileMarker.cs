using System.Globalization;
using System.Runtime.CompilerServices;

namespace SixLabors.ImageSharp.Formats.Jpeg.Components.Decoder;

internal readonly struct JpegFileMarker
{
	public bool Invalid
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get;
	}

	public byte Marker
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get;
	}

	public long Position
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get;
	}

	public JpegFileMarker(byte marker, long position)
		: this(marker, position, invalid: false)
	{
	}

	public JpegFileMarker(byte marker, long position, bool invalid)
	{
		Marker = marker;
		Position = position;
		Invalid = invalid;
	}

	public override string ToString()
	{
		return Marker.ToString("X", CultureInfo.InvariantCulture);
	}
}
