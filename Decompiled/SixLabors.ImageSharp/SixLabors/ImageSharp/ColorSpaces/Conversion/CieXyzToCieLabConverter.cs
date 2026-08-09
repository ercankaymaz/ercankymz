using System;
using System.Runtime.CompilerServices;

namespace SixLabors.ImageSharp.ColorSpaces.Conversion;

internal sealed class CieXyzToCieLabConverter
{
	public CieXyz LabWhitePoint { get; }

	public CieXyzToCieLabConverter()
		: this(CieLab.DefaultWhitePoint)
	{
	}

	public CieXyzToCieLabConverter(CieXyz labWhitePoint)
	{
		LabWhitePoint = labWhitePoint;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public CieLab Convert(in CieXyz input)
	{
		float x = LabWhitePoint.X;
		float y = LabWhitePoint.Y;
		float z = LabWhitePoint.Z;
		float num = input.X / x;
		float num2 = input.Y / y;
		float num3 = input.Z / z;
		float num4 = ((num > 0.008856452f) ? MathF.Pow(num, 0.3333333f) : ((903.2963f * num + 16f) * (1f / 116f)));
		float num5 = ((num2 > 0.008856452f) ? MathF.Pow(num2, 0.3333333f) : ((903.2963f * num2 + 16f) * (1f / 116f)));
		float num6 = ((num3 > 0.008856452f) ? MathF.Pow(num3, 0.3333333f) : ((903.2963f * num3 + 16f) * (1f / 116f)));
		float l = 116f * num5 - 16f;
		float a = 500f * (num4 - num5);
		float b = 200f * (num5 - num6);
		return new CieLab(l, a, b, LabWhitePoint);
	}
}
