using System;
using System.Drawing;

namespace ImageProcessor.Common.Extensions;

internal static class RectangleExtensions
{
	public static bool IsEqual(this Rectangle first, Rectangle second, int threshold)
	{
		return Math.Abs(first.X - second.X) < threshold && Math.Abs(first.Y - second.Y) < threshold && Math.Abs(first.Width - second.Width) < threshold && Math.Abs(first.Height - second.Height) < threshold;
	}
}
