using System;
using System.Buffers;
using System.Diagnostics.CodeAnalysis;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg;

internal readonly struct JpegAdobeApplicationSpecific
{
	private static readonly byte[] _adobeKey = "Adobe"u8.ToArray();

	public byte[] DctVersion { get; }

	public byte[] Flags0 { get; }

	public byte[] Flags1 { get; }

	public byte ColorTransformCode { get; }

	private JpegAdobeApplicationSpecific(byte[] dctVersion, byte[] flags0, byte[] flags1, byte colorTransformCode)
	{
		DctVersion = dctVersion;
		Flags0 = flags0;
		Flags1 = flags1;
		ColorTransformCode = colorTransformCode;
	}

	public static bool TryParse(ReadOnlySequence<byte> buffer, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out JpegAdobeApplicationSpecific? adobeApplicationSpecific)
	{
		ReadOnlySpan<byte> span = buffer.First.Span;
		if (span.Length >= 12 && ((Span<byte>)_adobeKey).SequenceEqual(span.Slice(0, 5)))
		{
			byte[] dctVersion = span.Slice(5, 2).ToArray();
			byte[] flags = span.Slice(7, 2).ToArray();
			byte[] flags2 = span.Slice(9, 2).ToArray();
			byte colorTransformCode = span.Slice(11, 1)[0];
			adobeApplicationSpecific = new JpegAdobeApplicationSpecific(dctVersion, flags, flags2, colorTransformCode);
			return true;
		}
		adobeApplicationSpecific = null;
		return false;
	}
}
