using System.Numerics;
using System.Runtime.CompilerServices;

namespace SixLabors.ImageSharp.ColorSpaces.Conversion;

internal sealed class CieXyzToLinearRgbConverter : LinearRgbAndCieXyzConverterBase
{
	private readonly Matrix4x4 conversionMatrix;

	public RgbWorkingSpace TargetWorkingSpace { get; }

	public CieXyzToLinearRgbConverter()
		: this(Rgb.DefaultWorkingSpace)
	{
	}

	public CieXyzToLinearRgbConverter(RgbWorkingSpace workingSpace)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		TargetWorkingSpace = workingSpace;
		Matrix4x4 val = default(Matrix4x4);
		Matrix4x4.Invert(LinearRgbAndCieXyzConverterBase.GetRgbToCieXyzMatrix(workingSpace), ref val);
		conversionMatrix = val;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public LinearRgb Convert(in CieXyz input)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		return new LinearRgb(Vector3.Transform(input.ToVector3(), conversionMatrix), TargetWorkingSpace);
	}
}
