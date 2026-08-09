using System.Runtime.CompilerServices;

namespace SixLabors.ImageSharp.ColorSpaces.Conversion;

internal abstract class CieXyzAndHunterLabConverterBase
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float ComputeKa(CieXyz whitePoint)
	{
		if (whitePoint.Equals(Illuminants.C))
		{
			return 175f;
		}
		return 88.36599f * (whitePoint.X + whitePoint.Y);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float ComputeKb(CieXyz whitePoint)
	{
		if (whitePoint == Illuminants.C)
		{
			return 70f;
		}
		return 32.0939f * (whitePoint.Y + whitePoint.Z);
	}
}
