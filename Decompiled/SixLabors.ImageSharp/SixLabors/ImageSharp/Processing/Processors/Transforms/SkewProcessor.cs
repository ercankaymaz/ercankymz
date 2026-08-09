using System.Numerics;

namespace SixLabors.ImageSharp.Processing.Processors.Transforms;

public sealed class SkewProcessor : AffineTransformProcessor
{
	public float DegreesX { get; }

	public float DegreesY { get; }

	public SkewProcessor(float degreesX, float degreesY, Size sourceSize)
		: this(degreesX, degreesY, KnownResamplers.Bicubic, sourceSize)
	{
	}

	public SkewProcessor(float degreesX, float degreesY, IResampler sampler, Size sourceSize)
		: this(TransformUtils.CreateSkewTransformMatrixDegrees(degreesX, degreesY, sourceSize, TransformSpace.Pixel), sampler, sourceSize)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		DegreesX = degreesX;
		DegreesY = degreesY;
	}

	private SkewProcessor(Matrix3x2 skewMatrix, IResampler sampler, Size sourceSize)
		: base(skewMatrix, sampler, TransformUtils.GetTransformedSize(skewMatrix, sourceSize, TransformSpace.Pixel))
	{
	}//IL_0001: Unknown result type (might be due to invalid IL or missing references)
	//IL_0003: Unknown result type (might be due to invalid IL or missing references)

}
