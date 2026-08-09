using System;
using System.Diagnostics.CodeAnalysis;

namespace SixLabors.ImageSharp.Formats.Qoi;

public class QoiImageFormatDetector : IImageFormatDetector
{
	public int HeaderSize => 14;

	public bool TryDetectFormat(ReadOnlySpan<byte> header, [NotNullWhen(true)] out IImageFormat? format)
	{
		format = (IsSupportedFileFormat(header) ? QoiFormat.Instance : null);
		return format != null;
	}

	private bool IsSupportedFileFormat(ReadOnlySpan<byte> header)
	{
		if (header.Length >= HeaderSize)
		{
			return MemoryExtensions.SequenceEqual<byte>(QoiConstants.Magic, header.Slice(0, 4));
		}
		return false;
	}
}
