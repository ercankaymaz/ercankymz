using System;
using System.Text;

namespace SixLabors.ImageSharp.Metadata.Profiles.Exif;

internal static class ExifConstants
{
	public static ReadOnlySpan<byte> LittleEndianByteOrderMarker => "II*\0"u8;

	public static ReadOnlySpan<byte> BigEndianByteOrderMarker => new byte[4] { 77, 77, 0, 42 };

	public static Encoding DefaultEncoding => Encoding.UTF8;
}
