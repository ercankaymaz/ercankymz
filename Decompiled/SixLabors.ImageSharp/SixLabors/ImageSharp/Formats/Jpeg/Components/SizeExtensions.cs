using System;
using System.Numerics;

namespace SixLabors.ImageSharp.Formats.Jpeg.Components;

internal static class SizeExtensions
{
	public static Size MultiplyBy(this Size a, Size b)
	{
		return new Size(a.Width * b.Width, a.Height * b.Height);
	}

	public static Size DivideBy(this Size a, Size b)
	{
		return new Size(a.Width / b.Width, a.Height / b.Height);
	}

	public static Size DivideRoundUp(this Size originalSize, int divX, int divY)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		Vector2 val = (SizeF)originalSize;
		val /= new Vector2((float)divX, (float)divY);
		val.X = MathF.Ceiling(val.X);
		val.Y = MathF.Ceiling(val.Y);
		return new Size((int)val.X, (int)val.Y);
	}

	public static Size DivideRoundUp(this Size originalSize, int divisor)
	{
		return originalSize.DivideRoundUp(divisor, divisor);
	}

	public static Size DivideRoundUp(this Size originalSize, Size divisor)
	{
		return originalSize.DivideRoundUp(divisor.Width, divisor.Height);
	}
}
