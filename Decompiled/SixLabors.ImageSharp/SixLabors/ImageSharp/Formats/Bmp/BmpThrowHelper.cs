using System;

namespace SixLabors.ImageSharp.Formats.Bmp;

internal static class BmpThrowHelper
{
	public static void ThrowInvalidImageContentException(string errorMessage)
	{
		throw new InvalidImageContentException(errorMessage);
	}

	public static void ThrowNotSupportedException(string errorMessage)
	{
		throw new NotSupportedException(errorMessage);
	}
}
