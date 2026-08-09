using System;

namespace SixLabors.ImageSharp.Formats.Jpeg.Components.Decoder;

internal static class ProfileResolver
{
	public static ReadOnlySpan<byte> JFifMarker => "JFIF\0"u8;

	public static ReadOnlySpan<byte> JFxxMarker => "JFXX\0"u8;

	public static ReadOnlySpan<byte> IccMarker => "ICC_PROFILE\0"u8;

	public static ReadOnlySpan<byte> AdobePhotoshopApp13Marker => "Photoshop 3.0\0"u8;

	public static ReadOnlySpan<byte> AdobeImageResourceBlockMarker => "8BIM"u8;

	public static ReadOnlySpan<byte> AdobeIptcMarker => new byte[2] { 4, 4 };

	public static ReadOnlySpan<byte> ExifMarker => new byte[6] { 69, 120, 105, 102, 0, 0 };

	public static ReadOnlySpan<byte> XmpMarker => "http://ns.adobe.com/xap/1.0/\0"u8;

	public static ReadOnlySpan<byte> AdobeMarker => "Adobe"u8;

	public static bool IsProfile(ReadOnlySpan<byte> bytesToCheck, ReadOnlySpan<byte> profileIdentifier)
	{
		if (bytesToCheck.Length >= profileIdentifier.Length)
		{
			return MemoryExtensions.SequenceEqual<byte>(bytesToCheck.Slice(0, profileIdentifier.Length), profileIdentifier);
		}
		return false;
	}
}
