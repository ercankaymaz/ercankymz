using System.Numerics;
using System.Runtime.CompilerServices;

namespace SixLabors.ImageSharp.ColorSpaces.Conversion;

internal sealed class CieXyzAndLmsConverter
{
	public static readonly Matrix4x4 DefaultTransformationMatrix = LmsAdaptationMatrix.Bradford;

	private Matrix4x4 inverseTransformationMatrix;

	private Matrix4x4 transformationMatrix;

	public CieXyzAndLmsConverter()
		: this(DefaultTransformationMatrix)
	{
	}//IL_0001: Unknown result type (might be due to invalid IL or missing references)


	public CieXyzAndLmsConverter(Matrix4x4 transformationMatrix)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		this.transformationMatrix = transformationMatrix;
		Matrix4x4.Invert(this.transformationMatrix, ref inverseTransformationMatrix);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Lms Convert(in CieXyz input)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		return new Lms(Vector3.Transform(input.ToVector3(), transformationMatrix));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public CieXyz Convert(in Lms input)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		return new CieXyz(Vector3.Transform(input.ToVector3(), inverseTransformationMatrix));
	}
}
