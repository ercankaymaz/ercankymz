using System;
using System.Diagnostics.CodeAnalysis;

namespace SixLabors.ImageSharp.Formats.Jpeg;

public sealed class JpegImageFormatDetector : IImageFormatDetector
{
	public int HeaderSize => 11;

	public bool TryDetectFormat(ReadOnlySpan<byte> header, [NotNullWhen(true)] out IImageFormat? format)
	{
		format = (IsSupportedFileFormat(header) ? JpegFormat.Instance : null);
		return format != null;
	}

	private bool IsSupportedFileFormat(ReadOnlySpan<byte> header)
	{
		if (header.Length >= HeaderSize)
		{
			if (!IsJfif(header) && !IsExif(header))
			{
				return IsJpeg(header);
			}
			return true;
		}
		return false;
	}

	private static bool IsJfif(ReadOnlySpan<byte> header)
	{
		if (header[6] == 74 && header[7] == 70 && header[8] == 73 && header[9] == 70)
		{
			return header[10] == 0;
		}
		return false;
	}

	private static bool IsExif(ReadOnlySpan<byte> header)
	{
		if (header[6] == 69 && header[7] == 120 && header[8] == 105 && header[9] == 102)
		{
			return header[10] == 0;
		}
		return false;
	}

	private static bool IsJpeg(ReadOnlySpan<byte> header)
	{
		if (header[0] == byte.MaxValue)
		{
			return header[1] == 216;
		}
		return false;
	}
}
