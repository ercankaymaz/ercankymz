using System;
using System.Diagnostics.CodeAnalysis;

namespace SixLabors.ImageSharp.Formats.Gif;

public sealed class GifImageFormatDetector : IImageFormatDetector
{
	public int HeaderSize => 6;

	public bool TryDetectFormat(ReadOnlySpan<byte> header, [NotNullWhen(true)] out IImageFormat? format)
	{
		format = (IsSupportedFileFormat(header) ? GifFormat.Instance : null);
		return format != null;
	}

	private bool IsSupportedFileFormat(ReadOnlySpan<byte> header)
	{
		if (header.Length >= HeaderSize && header[0] == 71 && header[1] == 73 && header[2] == 70 && header[3] == 56 && (header[4] == 57 || header[4] == 55))
		{
			return header[5] == 97;
		}
		return false;
	}
}
