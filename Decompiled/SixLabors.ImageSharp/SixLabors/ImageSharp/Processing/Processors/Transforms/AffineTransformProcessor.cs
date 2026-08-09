using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Memory;
using SixLabors.ImageSharp.PixelFormats;

namespace SixLabors.ImageSharp.Processing.Processors.Transforms;

public class AffineTransformProcessor : CloningImageProcessor
{
	public IResampler Sampler { get; }

	public Matrix3x2 TransformMatrix { get; }

	public Size DestinationSize { get; }

	public AffineTransformProcessor(Matrix3x2 matrix, IResampler sampler, Size targetDimensions)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		Guard.NotNull(sampler, "sampler");
		Guard.MustBeValueType(sampler, "sampler");
		if (TransformUtils.IsDegenerate(matrix))
		{
			throw new DegenerateTransformException("Matrix is degenerate. Check input values.");
		}
		Sampler = sampler;
		TransformMatrix = matrix;
		DestinationSize = targetDimensions;
	}

	public override ICloningImageProcessor<TPixel> CreatePixelSpecificCloningProcessor<TPixel>(Configuration configuration, Image<TPixel> source, Rectangle sourceRectangle)
	{
		return new AffineTransformProcessor<TPixel>(configuration, this, source, sourceRectangle);
	}
}
internal class AffineTransformProcessor<TPixel> : TransformProcessor<TPixel>, IResamplingTransformImageProcessor<TPixel>, IImageProcessor<TPixel>, IDisposable where TPixel : unmanaged, IPixel<TPixel>
{
	private readonly struct NNAffineOperation(Buffer2D<TPixel> source, Rectangle bounds, Buffer2D<TPixel> destination, Matrix3x2 matrix) : IRowOperation
	{
		private readonly Buffer2D<TPixel> source = source;

		private readonly Buffer2D<TPixel> destination = destination;

		private readonly Rectangle bounds = bounds;

		private readonly Matrix3x2 matrix = matrix;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Invoke(int y)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			Span<TPixel> span = destination.DangerousGetRowSpan(y);
			for (int i = 0; i < span.Length; i++)
			{
				Vector2 val = Vector2.Transform(new Vector2((float)i, (float)y), matrix);
				int x = (int)MathF.Round(val.X);
				int y2 = (int)MathF.Round(val.Y);
				if (bounds.Contains(x, y2))
				{
					span[i] = source.GetElementUnsafe(x, y2);
				}
			}
		}
	}

	private readonly struct AffineOperation<TResampler>(Configuration configuration, Buffer2D<TPixel> source, Rectangle bounds, Buffer2D<TPixel> destination, in TResampler sampler, Matrix3x2 matrix) : IRowIntervalOperation<Vector4> where TResampler : struct, IResampler
	{
		private readonly Configuration configuration = configuration;

		private readonly Buffer2D<TPixel> source = source;

		private readonly Rectangle bounds = bounds;

		private readonly Buffer2D<TPixel> destination = destination;

		private readonly TResampler sampler = sampler;

		private readonly Matrix3x2 matrix = matrix;

		private readonly float yRadius = LinearTransformUtility.GetSamplingRadius(in sampler, source.Height, destination.Height);

		private readonly float xRadius = LinearTransformUtility.GetSamplingRadius(in sampler, source.Width, destination.Width);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetRequiredBufferLength(Rectangle bounds)
		{
			return bounds.Width;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Invoke(in RowInterval rows, Span<Vector4> span)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0165: Unknown result type (might be due to invalid IL or missing references)
			//IL_0169: Unknown result type (might be due to invalid IL or missing references)
			//IL_0170: Unknown result type (might be due to invalid IL or missing references)
			//IL_0175: Unknown result type (might be due to invalid IL or missing references)
			//IL_017a: Unknown result type (might be due to invalid IL or missing references)
			Matrix3x2 val = matrix;
			TResampler val2 = sampler;
			float radius = yRadius;
			float radius2 = xRadius;
			int y = bounds.Y;
			int max = bounds.Bottom - 1;
			int x = bounds.X;
			int max2 = bounds.Right - 1;
			for (int i = rows.Min; i < rows.Max; i++)
			{
				Span<TPixel> span2 = destination.DangerousGetRowSpan(i);
				PixelOperations<TPixel>.Instance.ToVector4(configuration, span2, span, PixelConversionModifiers.Scale);
				for (int j = 0; j < span.Length; j++)
				{
					Vector2 val3 = Vector2.Transform(new Vector2((float)j, (float)i), val);
					float y2 = val3.Y;
					float x2 = val3.X;
					int rangeStart = LinearTransformUtility.GetRangeStart(radius, y2, y, max);
					int rangeEnd = LinearTransformUtility.GetRangeEnd(radius, y2, y, max);
					int rangeStart2 = LinearTransformUtility.GetRangeStart(radius2, x2, x, max2);
					int rangeEnd2 = LinearTransformUtility.GetRangeEnd(radius2, x2, x, max2);
					if (rangeEnd == rangeStart || rangeEnd2 == rangeStart2)
					{
						continue;
					}
					Vector4 val4 = Vector4.Zero;
					for (int k = rangeStart; k <= rangeEnd; k++)
					{
						float value = val2.GetValue((float)k - y2);
						for (int l = rangeStart2; l <= rangeEnd2; l++)
						{
							float value2 = val2.GetValue((float)l - x2);
							Vector4 val5 = source.GetElementUnsafe(l, k).ToScaledVector4();
							Numerics.Premultiply(ref val5);
							val4 += val5 * value2 * value;
						}
					}
					span[j] = val4;
				}
				Numerics.UnPremultiply(span);
				PixelOperations<TPixel>.Instance.FromVector4Destructive(configuration, span, span2, PixelConversionModifiers.Scale);
			}
		}

		void IRowIntervalOperation<Vector4>.Invoke(in RowInterval rows, Span<Vector4> span)
		{
			Invoke(in rows, span);
		}
	}

	private readonly Size destinationSize;

	private readonly Matrix3x2 transformMatrix;

	private readonly IResampler resampler;

	private ImageFrame<TPixel>? source;

	private ImageFrame<TPixel>? destination;

	public AffineTransformProcessor(Configuration configuration, AffineTransformProcessor definition, Image<TPixel> source, Rectangle sourceRectangle)
		: base(configuration, source, sourceRectangle)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		destinationSize = definition.DestinationSize;
		transformMatrix = definition.TransformMatrix;
		resampler = definition.Sampler;
	}

	protected override Size GetDestinationSize()
	{
		return destinationSize;
	}

	protected override void OnFrameApply(ImageFrame<TPixel> source, ImageFrame<TPixel> destination)
	{
		this.source = source;
		this.destination = destination;
		resampler.ApplyTransform(this);
	}

	public void ApplyTransform<TResampler>(in TResampler sampler) where TResampler : struct, IResampler
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		Configuration configuration = base.Configuration;
		ImageFrame<TPixel> imageFrame = source;
		ImageFrame<TPixel> imageFrame2 = destination;
		Matrix3x2 val = transformMatrix;
		if (((Matrix3x2)(ref val)).Equals(Matrix3x2.Identity))
		{
			Rectangle rectangle = Rectangle.Intersect(base.SourceRectangle, imageFrame2.Bounds());
			Buffer2DRegion<TPixel> region = imageFrame.PixelBuffer.GetRegion(rectangle);
			Buffer2DRegion<TPixel> region2 = imageFrame2.PixelBuffer.GetRegion(rectangle);
			for (int i = 0; i < region.Height; i++)
			{
				region.DangerousGetRowSpan(i).CopyTo(region2.DangerousGetRowSpan(i));
			}
		}
		else
		{
			Matrix3x2.Invert(val, ref val);
			if (sampler is NearestNeighborResampler)
			{
				NNAffineOperation operation = new NNAffineOperation(imageFrame.PixelBuffer, Rectangle.Intersect(base.SourceRectangle, imageFrame.Bounds()), imageFrame2.PixelBuffer, val);
				ParallelRowIterator.IterateRows(configuration, imageFrame2.Bounds(), in operation);
			}
			else
			{
				AffineOperation<TResampler> operation2 = new AffineOperation<TResampler>(configuration, imageFrame.PixelBuffer, Rectangle.Intersect(base.SourceRectangle, imageFrame.Bounds()), imageFrame2.PixelBuffer, in sampler, val);
				ParallelRowIterator.IterateRowIntervals<AffineOperation<TResampler>, Vector4>(configuration, imageFrame2.Bounds(), in operation2);
			}
		}
	}

	void IResamplingTransformImageProcessor<TPixel>.ApplyTransform<TResampler>(in TResampler sampler)
	{
		ApplyTransform(in sampler);
	}
}
