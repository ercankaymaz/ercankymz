using System.Numerics;
using System.Runtime.CompilerServices;

namespace SixLabors.ImageSharp.ColorSpaces.Conversion;

internal sealed class LinearRgbToCieXyzConverter : LinearRgbAndCieXyzConverterBase
{
	private readonly Matrix4x4 conversionMatrix;

	public RgbWorkingSpace SourceWorkingSpace { get; }

	public LinearRgbToCieXyzConverter()
		: this(Rgb.DefaultWorkingSpace)
	{
	}

	public LinearRgbToCieXyzConverter(RgbWorkingSpace workingSpace)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		SourceWorkingSpace = workingSpace;
		conversionMatrix = LinearRgbAndCieXyzConverterBase.GetRgbToCieXyzMatrix(workingSpace);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public CieXyz Convert(in LinearRgb input)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		return new CieXyz(Vector3.Transform(input.ToVector3(), conversionMatrix));
	}
}
