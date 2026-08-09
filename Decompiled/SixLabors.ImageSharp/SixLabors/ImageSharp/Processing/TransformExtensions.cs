using System.Numerics;
using SixLabors.ImageSharp.Processing.Processors.Transforms;

namespace SixLabors.ImageSharp.Processing;

public static class TransformExtensions
{
	public static IImageProcessingContext Transform(this IImageProcessingContext source, AffineTransformBuilder builder)
	{
		return source.Transform(builder, KnownResamplers.Bicubic);
	}

	public static IImageProcessingContext Transform(this IImageProcessingContext source, AffineTransformBuilder builder, IResampler sampler)
	{
		return source.Transform(new Rectangle(Point.Empty, source.GetCurrentSize()), builder, sampler);
	}

	public static IImageProcessingContext Transform(this IImageProcessingContext source, Rectangle sourceRectangle, AffineTransformBuilder builder, IResampler sampler)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		Matrix3x2 transform = builder.BuildMatrix(sourceRectangle);
		Size transformedSize = builder.GetTransformedSize(sourceRectangle);
		return source.Transform(sourceRectangle, transform, transformedSize, sampler);
	}

	public static IImageProcessingContext Transform(this IImageProcessingContext source, Rectangle sourceRectangle, Matrix3x2 transform, Size targetDimensions, IResampler sampler)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		return source.ApplyProcessor(new AffineTransformProcessor(transform, sampler, targetDimensions), sourceRectangle);
	}

	public static IImageProcessingContext Transform(this IImageProcessingContext source, ProjectiveTransformBuilder builder)
	{
		return source.Transform(builder, KnownResamplers.Bicubic);
	}

	public static IImageProcessingContext Transform(this IImageProcessingContext source, ProjectiveTransformBuilder builder, IResampler sampler)
	{
		return source.Transform(new Rectangle(Point.Empty, source.GetCurrentSize()), builder, sampler);
	}

	public static IImageProcessingContext Transform(this IImageProcessingContext source, Rectangle sourceRectangle, ProjectiveTransformBuilder builder, IResampler sampler)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		Matrix4x4 transform = builder.BuildMatrix(sourceRectangle);
		Size transformedSize = builder.GetTransformedSize(sourceRectangle);
		return source.Transform(sourceRectangle, transform, transformedSize, sampler);
	}

	public static IImageProcessingContext Transform(this IImageProcessingContext source, Rectangle sourceRectangle, Matrix4x4 transform, Size targetDimensions, IResampler sampler)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		return source.ApplyProcessor(new ProjectiveTransformProcessor(transform, sampler, targetDimensions), sourceRectangle);
	}
}
